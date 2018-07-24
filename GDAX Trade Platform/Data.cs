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

/*
 * TODO:
 * For some reason, whenever there is a major single order that clears out a few orders in the order book, PendChanges goes crazy and stacks thousands of objects
 * before crashing.
 */

namespace GDAX_Trade_Platform
{
	public class Data
	{
		#region Variables
		// Private variables
		private GDAXClient gdaxClient;
		private ProductType productType;
		private DataTable BidsDataTable;
		private DataTable AsksDataTable;
		private DataTable FullBidsTable;
		private DataTable FullAsksTable;
		public List<Changes> PendChanges;

		// Public properties for our private variables
		/// <summary>
		/// Returns the instance of GDAXClient
		/// </summary>
		public GDAXClient Client { get { return gdaxClient; } }
		public DataTable CurrentBids { get { return BidsDataTable; } }
		public DataTable CurrentAsks { get { return AsksDataTable; } }
		public int PendChangesCount { get { return PendChanges.Count; } }
		#endregion

		#region Events
		/// <summary>
		/// Occurs once GetOrderBook() has completed
		/// </summary>
		public event EventHandler<EventArgs> OrderBookReceived;
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
		/// Occurs once WebSocket_OnLevel2UpdateReceived() has completed
		/// </summary>
		public event EventHandler<EventArgs> Level2Received;
		/// <summary>
		/// Event method for when the Level 2 updates have been received and entered into the DataTables
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnLevel2Received(object sender, EventArgs e)
		{
			var handler = Level2Received; // We do not want racing conditions!
			handler?.Invoke(sender, e);
		}

		/// <summary>
		/// Occurs once WebSocket_OnTickerReceived() has completed
		/// </summary>
		public event EventHandler<WebfeedEventArgs<Ticker>> TickerReceived;
		/// <summary>
		/// Event method for when the Ticker has been received
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnTickerReceived(object sender, WebfeedEventArgs<Ticker> e)
		{
			var handler = TickerReceived;
			handler?.Invoke(sender, e);
		}
		#endregion

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
			_OrderBookT.Start();

			var Channels = new List<ChannelType>() { ChannelType.Heartbeat, ChannelType.Level2, ChannelType.Ticker };

			//Begin a new websocket with the current product type, and channels listed above
			var webSocket = gdaxClient.WebSocket;
			webSocket.Start(new List<ProductType> { productType }, Channels);
			
			webSocket.OnHeartbeatReceived += WebSocket_OnHeartbeatReceived;
			webSocket.OnLevel2UpdateReceived += WebSocket_OnLevel2UpdateReceived;
			webSocket.OnTickerReceived += WebSocket_OnTickerReceived;

			PendChanges = new List<Changes>();
			Thread _PendingChangesT = new Thread(PendingChangesT);
			_PendingChangesT.Start();
		}

		/// <summary>
		/// Constantly loops and checks to see if there are changes to be made per the PendChanges var
		/// </summary>
		private async void PendingChangesT()
		{
			while(true)
			{
				// Check to see if we have any pending changes
				if(PendChanges.Count > 0)
				{
					if(PendChanges.Count > 150)
					{
						Console.WriteLine("Potential problem. PendChanges.Count has exceeded 150.");
					}
					// Make sure we start working on the correct data
					switch (PendChanges[0].orderType)
					{
						case "sell":
						{
							// Let's make sure that we'll be iterating for a row that SHOULD be on the table
							if (PendChanges[0].Price <= Convert.ToDecimal(FullAsksTable.Rows[FullAsksTable.Rows.Count - 1][1]))
							{
								// If we either need to update a row or add a row
								if (PendChanges[0].MarketSize > 0)
								{
									// If the price of the pending change is lower than the lowest existing in the full table
									// This was placed outside of the for loop as it would be extra overhead
									if (PendChanges[0].Price < Convert.ToDecimal(FullAsksTable.Rows[0][1]))
									{
										DataRow row = FullAsksTable.NewRow();
										row[0] = PendChanges[0].MarketSize;
										row[1] = PendChanges[0].Price;
										row[2] = 0;
										//Insert the pending change at the top of the table
										FullAsksTable.Rows.InsertAt(row, 0);
										row = null;

										row = AsksDataTable.NewRow();
										row[0] = PendChanges[0].MarketSize;
										row[1] = PendChanges[0].Price;
										row[2] = 0;
										//Insert the pending change at the top of the table
										AsksDataTable.Rows.InsertAt(row, 0);

										//Remove the last row
										AsksDataTable.Rows.RemoveAt(AsksDataTable.Rows.Count - 1);
									}

									// If the price of the pending change is equal to the lowest existing in the full table
									else if (PendChanges[0].Price == Convert.ToDecimal(FullAsksTable.Rows[0][1]))
									{
										FullAsksTable.Rows[0][0] = PendChanges[0].MarketSize;
										AsksDataTable.Rows[0][0] = PendChanges[0].MarketSize;
									}

									// If the price of the pending change is greater than the lowest existing in the full table
									else
									{
										// Starting at 1 since we've just compared the PendChange to row at index 0
										for (int i = 1; i <= FullAsksTable.Rows.Count - 1; i++)
										{
											if (PendChanges[0].Price == Convert.ToDecimal(FullAsksTable.Rows[i][1]))
											{
												FullAsksTable.Rows[i][0] = PendChanges[0].MarketSize;
												break;
											}

											else if (PendChanges[0].Price < Convert.ToDecimal(FullAsksTable.Rows[i][1]))
											{
												DataRow row = FullAsksTable.NewRow();
												row[0] = PendChanges[0].MarketSize;
												row[1] = PendChanges[0].Price;
												row[2] = 0;
												FullAsksTable.Rows.InsertAt(row, i);
												row = null;

												if (i <= AsksDataTable.Rows.Count - 1)
												{
													row = AsksDataTable.NewRow();
													row[0] = PendChanges[0].MarketSize;
													row[1] = PendChanges[0].Price;
													row[2] = 0;
													AsksDataTable.Rows.InsertAt(row, i);
													AsksDataTable.Rows.RemoveAt(15);
												}

												break;
											}
										}
									}
								}

								// Else, the market size is 0, we need to remove a row
								else
								{
									// If our table is running low on rows, just go ahead and redownload the whole orderbook
									if (FullAsksTable.Rows.Count < 20)
									{
										RefreshOrderBook();
									}

									else
									{
										for (int i = 0; i <= FullAsksTable.Rows.Count - 1; i++)
										{
											if (Convert.ToDecimal(FullAsksTable.Rows[i][1]) == PendChanges[0].Price)
											{
												FullAsksTable.Rows.RemoveAt(i);

												if (i <= AsksDataTable.Rows.Count - 1)
												{
													AsksDataTable.Rows.RemoveAt(i);

													DataRow row = AsksDataTable.NewRow();

													row[0] = FullAsksTable.Rows[14][0];
													row[1] = FullAsksTable.Rows[14][1];
													row[2] = 0;

													AsksDataTable.Rows.Add(row);

												}
											}
										}
									}
								}

								FullAsksTable.AcceptChanges();
								AsksDataTable.AcceptChanges();

								//PendChanges.RemoveAt(0);
							}
							break;
						}

						case "buy":
						{
							// Let's make sure that we'll be iterating for a row that SHOULD be on the table
							if (PendChanges[0].Price >= Convert.ToDecimal(FullBidsTable.Rows[FullBidsTable.Rows.Count - 1][1]))
							{
								// If we either need to update a row or add a row
								if (PendChanges[0].MarketSize > 0)
								{
									// If the price of the pending change is lower than the lowest existing in the full table
									// This was placed outside of the for loop as it would be extra overhead
									if (PendChanges[0].Price > Convert.ToDecimal(FullBidsTable.Rows[0][1]))
									{
										DataRow row = FullBidsTable.NewRow();
										row[0] = PendChanges[0].MarketSize;
										row[1] = PendChanges[0].Price;
										row[2] = 0;
										//Insert the pending change at the top of the table
										FullBidsTable.Rows.InsertAt(row, 0);
										row = null;

										row = BidsDataTable.NewRow();
										row[0] = PendChanges[0].MarketSize;
										row[1] = PendChanges[0].Price;
										row[2] = 0;
										//Insert the pending change at the top of the table
										BidsDataTable.Rows.InsertAt(row, 0);

										//Remove the last row
										BidsDataTable.Rows.RemoveAt(BidsDataTable.Rows.Count - 1);
									}

									// If the price of the pending change is equal to the lowest existing in the full table
									else if (PendChanges[0].Price == Convert.ToDecimal(FullBidsTable.Rows[0][1]))
									{
										FullBidsTable.Rows[0][0] = PendChanges[0].MarketSize;
										BidsDataTable.Rows[0][0] = PendChanges[0].MarketSize;
									}

									// If the price of the pending change is greater than the lowest existing in the full table
									else
									{
										// Starting at 1 since we've just compared the PendChange to row at index 0
										for (int i = 1; i <= FullBidsTable.Rows.Count - 1; i++)
										{
											if (PendChanges[0].Price == Convert.ToDecimal(FullBidsTable.Rows[i][1]))
											{
												FullBidsTable.Rows[i][0] = PendChanges[0].MarketSize;
												break;
											}

											else if (PendChanges[0].Price > Convert.ToDecimal(FullBidsTable.Rows[i][1]))
											{
												DataRow row = FullBidsTable.NewRow();
												row[0] = PendChanges[0].MarketSize;
												row[1] = PendChanges[0].Price;
												row[2] = 0;
												FullBidsTable.Rows.InsertAt(row, i);
												row = null;

												if (i <= BidsDataTable.Rows.Count - 1)
												{
													row = BidsDataTable.NewRow();
													row[0] = PendChanges[0].MarketSize;
													row[1] = PendChanges[0].Price;
													row[2] = 0;
													BidsDataTable.Rows.InsertAt(row, i);
													BidsDataTable.Rows.RemoveAt(15);
												}

												break;
											}
										}
									}
								}

								// Else, the market size is 0, we need to remove a row
								else
								{
									// If our table is running low on rows, just go ahead and redownload the whole orderbook
									if (FullBidsTable.Rows.Count < 20)
									{
										RefreshOrderBook();
									}

									else
									{
										for (int i = 0; i <= FullBidsTable.Rows.Count - 1; i++)
										{
											if (Convert.ToDecimal(FullBidsTable.Rows[i][1]) == PendChanges[0].Price)
											{
												FullBidsTable.Rows.RemoveAt(i);

												if (i <= BidsDataTable.Rows.Count - 1)
												{
													BidsDataTable.Rows.RemoveAt(i);

													DataRow row = BidsDataTable.NewRow();

													row[0] = FullBidsTable.Rows[14][0];
													row[1] = FullBidsTable.Rows[14][1];
													row[2] = 0;

													BidsDataTable.Rows.Add(row);

												}
											}
										}
									}
								}

								FullBidsTable.AcceptChanges();
								BidsDataTable.AcceptChanges();

								//PendChanges.RemoveAt(0);
							}
							break;
						}

						default:
						{
							break;
						}
					}
					
					PendChanges.RemoveAt(0);
				}
			}
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
			// Begin looping through each change received in the Level 2 update
			for (int i = 0; i < e.LastOrder.Changes.Count; i++)
			{
				// Doing this just makes it easier to use
				Changes change = new Changes()
				{
					MarketSize = Convert.ToDecimal(e.LastOrder.Changes.ElementAt(i).ElementAt(2)),
					Price = Convert.ToDecimal(e.LastOrder.Changes.ElementAt(i).ElementAt(1)),
					orderType = e.LastOrder.Changes.ElementAt(i).ElementAt(0)
				};

				// As janky as (I think) this is, this takes off the trailing zeros
				change.Price = decimal.Parse(change.Price.ToString("G29"));
				PendChanges.Add(change);
			}
		}

		/// <summary>
		/// When an update to the ticker is received
		/// </summary>
		private void WebSocket_OnTickerReceived(object sender, WebfeedEventArgs<Ticker> e)
		{
			TickerReceived(this, e);
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
