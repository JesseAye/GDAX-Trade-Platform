using GDAXSharp;
using GDAXSharp.WebSocket.Models.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDAX_Trade_Platform
{
	public partial class OrderBook : Form
	{
		GDAXClient gdaxClient;
		public bool ReadyForL2Updates = false;

		public OrderBook(GDAXClient _gdaxClient)
		{
			InitializeComponent();
			gdaxClient = _gdaxClient;

			Thread t = new Thread(MainLoopAsync);
			t.Start();
		}

		private async void MainLoopAsync()
		{
			var initialOrderBook = await gdaxClient.ProductsService.GetProductOrderBookAsync(GDAXSharp.Shared.Types.ProductType.LtcUsd, GDAXSharp.Services.Products.Types.ProductLevel.Two);
			
			for(int i = 0; i != 15; i++)
			{
				//Grab a clone of the column layout from their respective table
				DataGridViewRow bidRow  = (DataGridViewRow)BidBuyTable.Rows[0].Clone();
				DataGridViewRow askRow = (DataGridViewRow)AskSellTable.Rows[0].Clone();

				//Use our incoming data from initialOrderBook at index x, and load them into our row variables
				bidRow.SetValues(initialOrderBook.Bids.ElementAt(i).Size, initialOrderBook.Bids.ElementAt(i).Price, 0);
				askRow.SetValues(initialOrderBook.Asks.ElementAt(i).Size, initialOrderBook.Asks.ElementAt(i).Price, 0);

				//Invoke the form (beacuse this is a different thread) so we can add the rows to their tables
				this.Invoke(new Action(delegate ()
				{
					BidBuyTable.Rows.Add(bidRow);
					AskSellTable.Rows.Add(askRow);
				}));
			}

			ReadyForL2Updates = true;

			while(!Disposing)
			{
			}
		}

		public bool ReceiveL2Update(Level2 data)
		{
			//For each change in the Level 2 data
			for(int i = 0; i <= data.Changes.Count - 1; i++)
			{
				//Test if the change at i is sell or buy 
				switch (data.Changes.ElementAt(i).ElementAt(i))
				{
					case "sell": //if our element at i was a sell order, apply changes to the AskSellTable

						//For each row already in AskSellTable
						for(int j = 0; j <= AskSellTable.RowCount - 1; j++)
						{
							if (AskSellTable.Rows[j].Cells[1].Value != null)
							{
								//Check if the Price of the change to apply is already a row in our table
								if (data.Changes[i].ElementAt(1).Remove(data.Changes[i].ElementAt(1).Length - 6) == AskSellTable.Rows[j].Cells[1].Value.ToString())
								{
									AskSellTable.Rows[j].Cells[0].Value = data.Changes[i].ElementAt(2);
								}
							}
						}
						break;

					case "buy": //if our element at i was a buy order, apply changes to the BuyBidTable

						//For each row already in AskSellTable
						for (int j = 0; j <= BidBuyTable.RowCount - 1; j++)
						{
							if (BidBuyTable.Rows[j].Cells[1].Value != null)
							{
								//Check if the Price of the change to apply is already a row in our table
								// 9026.47000000  13 chars
								if (data.Changes[i].ElementAt(1).Remove(data.Changes[i].ElementAt(1).Length - 6) == BidBuyTable.Rows[j].Cells[1].Value.ToString())
								{
									BidBuyTable.Rows[j].Cells[0].Value = data.Changes[i].ElementAt(2);
								}
							}
						}
						break;


					default:
						break;
				}
			}
			//*/
			

			if(ReadyForL2Updates)
			{
				
			}
			return true;
		}
	}
}
