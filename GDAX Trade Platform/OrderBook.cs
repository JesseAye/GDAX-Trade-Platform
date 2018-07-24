using System;
using System.Threading;
using System.Threading.Tasks;
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
		}

		private void OrderBook_Load(object sender, EventArgs e)
		{
			Task t = new Task(RefreshBothDGVs);
			t.Start();
		}

		private void RefreshBothDGVs()
		{
			while (true)
			{
				Invoke(new Action(delegate ()
				{
					BidBuyTable.Invalidate();
					AskSellTable.Invalidate();
					this.Text = "OrderBook - " + ClientData.PendChangesCount + " Changes pending";
				}));
				Thread.Sleep(50);
			}
		}
	}
}
