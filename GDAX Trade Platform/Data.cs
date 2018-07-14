using GDAXSharp;
using GDAXSharp.Network.Authentication;
using GDAXSharp.Services.Products.Models.Responses;
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
		private DataTable FullBidsTable;
		private DataTable FullAsksTable;

		//Public properties for our private variables
		/// <summary>
		/// Returns the instance of GDAXClient
		/// </summary>
		public GDAXClient Client { get { return gdaxClient; } }
		public DataTable CurrentBids { get { return BidsDataTable; } }
		public DataTable CurrentAsks { get { return AsksDataTable; } }

		/// <summary>
		/// Occurs once GetOrderBook() has completed
		/// </summary>
		public event EventHandler<EventArgs> OrderBookReceived;
		/// <summary>
		/// Occurs once WebSocket_OnLevel2UpdateReceived() has completed
		/// </summary>
		public event EventHandler<Coords> Level2Received;

		public Data()
		{
			BidsDataTable = new DataTable();
			FullBidsTable = new DataTable();
			BidsDataTable.Columns.Add("Market Size", typeof(decimal));
			BidsDataTable.Columns.Add("Price (USD)", typeof(decimal));
			BidsDataTable.Columns.Add("My Size", typeof(decimal));
			FullBidsTable.Columns.Add("Market Size", typeof(decimal));
			FullBidsTable.Columns.Add("Price (USD)", typeof(decimal));
			FullBidsTable.Columns.Add("My Size", typeof(decimal));

			AsksDataTable = new DataTable();
			FullAsksTable = new DataTable();
			AsksDataTable.Columns.Add("Market Size", typeof(decimal));
			AsksDataTable.Columns.Add("Price (USD)", typeof(decimal));
			AsksDataTable.Columns.Add("My Size", typeof(decimal));
			FullAsksTable.Columns.Add("Market Size", typeof(decimal));
			FullAsksTable.Columns.Add("Price (USD)", typeof(decimal));
			FullAsksTable.Columns.Add("My Size", typeof(decimal));
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
			Thread _OrderBookT = new Thread(ResetOrderBook);
			Console.WriteLine("Authenticate called ResetOrderBook");
			_OrderBookT.Start();

			var Channels = new List<ChannelType>() { ChannelType.Heartbeat, ChannelType.Level2, ChannelType.Ticker };

			//Begin a new websocket with the current product type, and channels listed above
			var webSocket = gdaxClient.WebSocket;
			webSocket.Start(new List<ProductType> { productType }, Channels);
			
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
			//Begin looping through each change received in the Level 2 update
			for (int i = 0; i < e.LastOrder.Changes.Count; i++)
			{
				Changes change = new Changes()
				{
					MarketSize = Convert.ToDecimal(e.LastOrder.Changes.ElementAt(i).ElementAt(2)),
					Price = Convert.ToDecimal(e.LastOrder.Changes.ElementAt(i).ElementAt(1)),
					orderType = e.LastOrder.Changes.ElementAt(i).ElementAt(0)
				};

				//If the change at this price has no more market size
				if (change.MarketSize == new decimal(0))
				{
					if (change.orderType == "buy")
					{
						//Search through each row for a matching price
						for (int j = 0; j <= BidsDataTable.Rows.Count - 1; j++)
						{
							if (Convert.ToDecimal(BidsDataTable.Rows[j][1]) == change.Price)
							{
								BidsDataTable.Rows[j].Delete();
								BidsDataTable.AcceptChanges();

								DataRow row = BidsDataTable.NewRow();
								row[0] = FullBidsTable.Rows[14][0];
								row[1] = FullBidsTable.Rows[14][1];
								row[2] = FullBidsTable.Rows[14][2];
								BidsDataTable.Rows.Add(row); // Get the 15th row from full Bids
							}
						}
					}

					else if (change.orderType == "sell")
					{
						//Search through each row for a matching price
						for (int j = 0; j <= AsksDataTable.Rows.Count - 1; j++)
						{
							if (Convert.ToDecimal(AsksDataTable.Rows[j][1]) == change.Price)
							{
								AsksDataTable.Rows[j].Delete();
								AsksDataTable.AcceptChanges();

								DataRow row = AsksDataTable.NewRow();
								row[0] = FullAsksTable.Rows[14][0];
								row[1] = FullAsksTable.Rows[14][1];
								row[2] = FullAsksTable.Rows[14][2];
								AsksDataTable.Rows.Add(row); // Get the 15th row from full Asks
							}
						}
					}
				}

				else
				{
					DataRow row;
					
					switch (change.orderType)
					{
						case "sell":
						{
							//Check if we have a new ask at mid market price, or in other words, moving the mid market price
							if (change.Price < Convert.ToDecimal(AsksDataTable.Rows[0][1]))
							{
								AsksDataTable.Rows[14].Delete();

								row = FullAsksTable.NewRow();
								row[0] = change.MarketSize;
								row[1] = change.Price;
								row[2] = 0;

								FullAsksTable.Rows.InsertAt(row, 0);

								row = AsksDataTable.NewRow();
								row[0] = change.MarketSize;
								row[1] = change.Price;
								row[2] = 0;
								
								AsksDataTable.Rows.InsertAt(row, 0);
							}

							else
							{
								for (int j = 0; j < 49; j++)
								{
									if (Convert.ToDecimal(FullAsksTable.Rows[j][1]) == change.Price)
									{
										FullAsksTable.Rows[j][0] = change.MarketSize;

										if (j <= 14)
											AsksDataTable.Rows[j][0] = FullAsksTable.Rows[j][0];

										break;
									}
								}
							}

							break;
						}

						case "buy":
						{
							//Check if we have a new bid at mid market price, or in other words, moving the mid market price
							if (change.Price > Convert.ToDecimal(BidsDataTable.Rows[0][1]))
							{
								BidsDataTable.Rows[14].Delete();

								row = FullBidsTable.NewRow();
								row[0] = change.MarketSize;
								row[1] = change.Price;
								row[2] = 0;

								FullBidsTable.Rows.InsertAt(row, 0);

								row = BidsDataTable.NewRow();
								row[0] = change.MarketSize;
								row[1] = change.Price;
								row[2] = 0;

								BidsDataTable.Rows.InsertAt(row, 0);
								}

							else
							{
								for (int j = 0; j < 49; j++)
								{
									if (Convert.ToDecimal(FullBidsTable.Rows[j][1]) == change.Price)
									{
										FullBidsTable.Rows[j][0] = change.MarketSize;

										if (j <= 14)
											BidsDataTable.Rows[j][0] = FullBidsTable.Rows[j][0];

										break;
									}
								}
							}

							break;
						}

						default:
							break;
					}
				}

				AsksDataTable.AcceptChanges();
				BidsDataTable.AcceptChanges();
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
		private async void ResetOrderBook()
		{
			Console.WriteLine("ResetOrderBook Started");
			ProductsOrderBookResponse _orderBook;
			try
			{
				//Get the current order book
				_orderBook = await gdaxClient.ProductsService.GetProductOrderBookAsync(productType, ProductLevel.Two);
			}

			//If caught, chances are it's rate limit exceeded
			catch (GDAXSharp.Exceptions.GDAXSharpHttpException ex)
			{
				return;
			}
			DataRow row;

			//Clear the existing tables
			BidsDataTable.Clear();
			AsksDataTable.Clear();

			//Begin loop so we can get the full order book into our Full Ask/Bids Tables
			for (int i = 0; i <= 49; i++)
			{
				row = FullBidsTable.NewRow();
				row[0] = Convert.ToDecimal(_orderBook.Bids.ElementAt(i).Size);
				row[1] = Convert.ToDecimal(_orderBook.Bids.ElementAt(i).Price);
				row[2] = Convert.ToDecimal(0);
				FullBidsTable.Rows.Add(row);

				row = FullAsksTable.NewRow();
				row[0] = Convert.ToDecimal(_orderBook.Asks.ElementAt(i).Size);
				row[1] = Convert.ToDecimal(_orderBook.Asks.ElementAt(i).Price);
				row[2] = Convert.ToDecimal(0);
				FullAsksTable.Rows.Add(row);
			}

			//Begin loop so we can get the 15 prices closest to Mid Market Price in both directions
			for (int i = 0; i <= 14; i++)
			{
				row = BidsDataTable.NewRow();
				row[0] = FullBidsTable.Rows[i][0];
				row[1] = FullBidsTable.Rows[i][1];
				row[2] = FullBidsTable.Rows[i][2];
				BidsDataTable.Rows.Add(row);

				row = AsksDataTable.NewRow();
				row[0] = FullAsksTable.Rows[i][0];
				row[1] = FullAsksTable.Rows[i][1];
				row[2] = FullAsksTable.Rows[i][2];
				AsksDataTable.Rows.Add(row);
			}

			AsksDataTable.AcceptChanges();
			BidsDataTable.AcceptChanges();

			//Worth it to make sure vars are cleared?
			row = null;

			//Raise the OrderBookReceived event
			OnOrderBookReceived(this, new EventArgs());

			Console.WriteLine("ResetOrderBook Finished");
		}

		private async void RefreshOrderBook()
		{
			Console.WriteLine("RefreshOrderBook Finished");

			ProductType pt = productType;
			DataTable bidsdt = new DataTable();
			DataTable asksdt = new DataTable();
			DataRow row;

			bidsdt.Columns.Add("Market Size", typeof(decimal));
			bidsdt.Columns.Add("Price (USD)", typeof(decimal));
			bidsdt.Columns.Add("My Size", typeof(decimal));

			asksdt.Columns.Add("Market Size", typeof(decimal));
			asksdt.Columns.Add("Price (USD)", typeof(decimal));
			asksdt.Columns.Add("My Size", typeof(decimal));

			while (pt == productType)
			{
				Thread.Sleep(4950);
				ProductsOrderBookResponse _orderBook;

				try
				{
					//Get the current order book
					_orderBook = await gdaxClient.ProductsService.GetProductOrderBookAsync(productType, ProductLevel.Two);
				}

				//If caught, chances are it's rate limit exceeded
				catch (GDAXSharp.Exceptions.GDAXSharpHttpException ex)
				{
					return;
				}

				for (int i = 0; i <= 49; i++)
				{
					row = bidsdt.NewRow();
					row[0] = Convert.ToDecimal(_orderBook.Bids.ElementAt(i).Size);
					row[1] = Convert.ToDecimal(_orderBook.Bids.ElementAt(i).Price);
					row[2] = Convert.ToDecimal(0);
					bidsdt.Rows.Add(row);

					row = asksdt.NewRow();
					row[0] = Convert.ToDecimal(_orderBook.Asks.ElementAt(i).Size);
					row[1] = Convert.ToDecimal(_orderBook.Asks.ElementAt(i).Price);
					row[2] = Convert.ToDecimal(0);
					asksdt.Rows.Add(row);
				}

				FullAsksTable = asksdt;
				FullBidsTable = bidsdt;

				bidsdt.Clear();
				asksdt.Clear();
				row = null;
			}
			Console.WriteLine("RefreshOrderBook Finished");
		}

		/// <summary>
		/// Event method for when the Order Book has been received and entered into the DataTables
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnOrderBookReceived(object sender, EventArgs e)
		{
			var handler = OrderBookReceived; // We do not want racing conditions!
			handler?.Invoke(sender, e);
		}

		/// <summary>
		/// Event method for when the Level 2 updates have been received and entered into the DataTables
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnLevel2Received(object sender, Coords e)
		{
			var handler = Level2Received; // We do not want racing conditions!
			handler?.Invoke(sender, e);
		}
	}

	public struct Coords
	{
		public OrderType orderType;
		public ushort x;
		public ushort y;
	}

	public struct Changes
	{
		public string orderType;
		public decimal MarketSize;
		public decimal Price;
	}

	public enum OrderType
	{
		Bid,
		Ask
	}
}
