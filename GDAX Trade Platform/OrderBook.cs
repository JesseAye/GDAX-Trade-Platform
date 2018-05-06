using System;
using System.Windows.Forms;

namespace GDAX_Trade_Platform
{
	public partial class OrderBook : Form
	{
		Data ClientData;

		public OrderBook(ref Data ClientDataRef)
		{
			InitializeComponent();
			ClientData = ClientDataRef;

			BidBuyTable.DataSource = ClientData.CurrentBids;

			BidBuyTable.Columns[0].Width = 86;
			BidBuyTable.Columns[1].Width = 86;
			BidBuyTable.Columns[2].Width = 67;

			AskSellTable.DataSource = ClientData.CurrentAsks;

			AskSellTable.Columns[0].Width = 86;
			AskSellTable.Columns[1].Width = 86;
			AskSellTable.Columns[2].Width = 67;

			ClientData.OrderBookReceived += OnOrderBookReceived;
		}

		private void OnOrderBookReceived(object sender, EventArgs e)
		{
			Invoke(new Action(delegate ()
			{
				BidBuyTable.Refresh();
				AskSellTable.Refresh();
			}));
		}
		//TODO: Figure out how to refresh individual cells upon Level 2 updates

		/*
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
			

			if(ReadyForL2Updates)
			{
				
			}
			return true;
		}
		*/
	}
}
