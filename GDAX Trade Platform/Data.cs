using GDAXSharp;
using GDAXSharp.Network.Authentication;
using GDAXSharp.Services.Products.Types;
using GDAXSharp.Shared.Types;
using GDAXSharp.WebSocket.Models.Response;
using GDAXSharp.WebSocket.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace GDAX_Trade_Platform
{

	public class Data
	{
		//Private variables
		private GDAXClient gdaxClient;
		private ProductType productType;
		private DataTable BidsDataTable;
		private DataTable AsksDataTable;

		//Public properties for our private variables
		/// <summary>
		/// Returns the instance of GDAXClient
		/// </summary>
		public GDAXClient Client { get { return gdaxClient; } }
		/*
		/// <summary>
		/// The current Bids in the order book
		/// </summary>
		public IEnumerable<Bid> CurrentBids { get { return Bids; } }
		/// <summary>
		/// The current Asks in the order book
		/// </summary>
		public IEnumerable<Ask> CurrentAsks { get { return Asks; } }
		*/
		public DataTable CurrentBids { get { return BidsDataTable; } }
		public DataTable CurrentAsks { get { return AsksDataTable; } }

		/// <summary>
		/// Occurs once GetOrderBook() has completed
		/// </summary>
		public event EventHandler<EventArgs> OrderBookReceived;

		public Data()
		{
			BidsDataTable = new DataTable();
			BidsDataTable.Columns.Add("Market Size", typeof(decimal));
			BidsDataTable.Columns.Add("Price (USD)", typeof(decimal));
			BidsDataTable.Columns.Add("My Size", typeof(decimal));

			AsksDataTable = new DataTable();
			AsksDataTable.Columns.Add("Market Size", typeof(decimal));
			AsksDataTable.Columns.Add("Price (USD)", typeof(decimal));
			AsksDataTable.Columns.Add("My Size", typeof(decimal));
		}

		/// <summary>
		/// Authenticate the GDAXClient, and start up async operations
		/// </summary>
		/// <param name="authenticator">The instance of class Authenticator used to actually authenicate GDAXClient</param>
		/// <param name="isSandbox">Will this run in the Sandbox API/Market?</param>
		internal void Authenticate(Authenticator authenticator, bool isSandbox)
		{
			//Instantiate our GDAXClient
			gdaxClient = new GDAXClient(authenticator, isSandbox);

			//Start up a new thread that gets the current order book
			Thread _OrderBookT = new Thread(GetOrderBook);
			_OrderBookT.Start();

			var Channels = new List<ChannelType>() { ChannelType.Heartbeat, ChannelType.Level2, ChannelType.Ticker };

			var webSocket = gdaxClient.WebSocket;
			webSocket.Start(new List<ProductType> { productType }, Channels);

			// EventHandler for the heartbeat response type
			webSocket.OnHeartbeatReceived += WebSocket_OnHeartbeatReceived;
			webSocket.OnLevel2UpdateReceived += WebSocket_OnLevel2UpdateReceived;
			webSocket.OnTickerReceived += WebSocket_OnTickerReceived;
		}

		/// <summary>
		/// When Heartbeat is received from GDAX
		/// </summary>
		private static void WebSocket_OnHeartbeatReceived(object sender, WebfeedEventArgs<Heartbeat> e)
		{

		}

		/// <summary>
		/// When an update to the level 2 order book is received
		/// </summary>
		private void WebSocket_OnLevel2UpdateReceived(object sender, WebfeedEventArgs<Level2> e)
		{
			for(int i = 0; i < e.LastOrder.Changes.Count; i++)
			{
				switch (e.LastOrder.Changes.ElementAt(i).ElementAt(0))
				{
					//if our element at i was a sell order, apply changes to the CurrentAsks table
					case "sell":
						{
							//If the sell order at this price has no more market size
							if (e.LastOrder.Changes.ElementAt(i).ElementAt(2) == "0")
							{
							
							}
							break;
						}

					//if our element at i was a buy order, apply changes to the CurrentBids table
					case "buy":
						{
							//If the buy order at this price has no more market size
							if (e.LastOrder.Changes.ElementAt(i).ElementAt(2) == "0")
							{

							}
							break;
						}


					default:
						break;
				}
			}
		}

		/// <summary>
		/// When an update to the ticker is received
		/// </summary>
		private void WebSocket_OnTickerReceived(object sender, WebfeedEventArgs<Ticker> e)
		{
		}

		/// <summary>
		/// Clears the current order book, and downloads a new set of data
		/// </summary>
		private async void GetOrderBook()
		{
			//Get the current order book
			var _orderBook = await gdaxClient.ProductsService.GetProductOrderBookAsync(productType, ProductLevel.Two);
			DataRow row;

			BidsDataTable.Clear();
			AsksDataTable.Clear();

			//Begin loop so we can get the 15 prices closest to Mid Market Price in both directions
			for(int i = 0; i < 15; i++)
			{
				row = BidsDataTable.NewRow();
				row[0] = Convert.ToDecimal(_orderBook.Bids.ElementAt(i).Size);
				row[1] = Convert.ToDecimal(_orderBook.Bids.ElementAt(i).Price);
				row[2] = Convert.ToDecimal(0);
				BidsDataTable.Rows.Add(row);

				row = AsksDataTable.NewRow();
				row[0] = Convert.ToDecimal(_orderBook.Asks.ElementAt(i).Size);
				row[1] = Convert.ToDecimal(_orderBook.Asks.ElementAt(i).Price);
				row[2] = Convert.ToDecimal(0);
				AsksDataTable.Rows.Add(row);
			}

			OnOrderBookReceived(this, new EventArgs());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnOrderBookReceived(object sender, EventArgs e)
		{
			var handler = OrderBookReceived; // We do not want racing conditions!
			handler?.Invoke(sender, e);
		}
	}
}
