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

			ClientData.OrderBookReceived += RefreshBothDGVs;
		}

		private void RefreshBothDGVs(object sender, EventArgs e)
		{
			Invoke(new Action(delegate ()
			{
				BidBuyTable.DataSource = null;

				//System.InvalidOperationException: 'Rows cannot be programmatically added to the DataGridView's rows collection when the control is data-bound.'
				BidBuyTable.DataSource = ClientData.CurrentBids;

				BidBuyTable.Columns[0].Width = 86;
				BidBuyTable.Columns[1].Width = 86;
				BidBuyTable.Columns[2].Width = 67;

				AskSellTable.DataSource = null;
				AskSellTable.DataSource = ClientData.CurrentAsks;

				AskSellTable.Columns[0].Width = 86;
				AskSellTable.Columns[1].Width = 86;
				AskSellTable.Columns[2].Width = 67;
			}));
		}
	}
}
