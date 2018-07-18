using GDAXSharp.Shared.Types;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDAX_Trade_Platform
{
	public partial class MainForm : Form
	{
		Data ClientData;
		OrderBook orderBook;
		Order order;
		Trade_History trades;

		public MainForm()
		{
			InitializeComponent();
			ClientData = new Data();

			//Modally open the authentication window
			Authentication getAuth = new Authentication(ref ClientData);
			getAuth.ShowDialog();

			if (OrderBookMenuItem.Checked == true)
			{
				orderBook = new OrderBook(ref ClientData);
				orderBook.Show();
			}

			order = new Order(ref ClientData);
			order.Show();

			trades = new Trade_History(ref ClientData);
			trades.Show();
		}

		async Task<Decimal> MidMarketPrice()
		{
			var PT = await ClientData.Client.ProductsService.GetProductTickerAsync(ProductType.LtcUsd);

			return (PT.Ask + PT.Bid) / 2;
		}

		private void OrderBookMenuItem_CheckStateChanged(object sender, EventArgs e)
		{
			if (OrderBookMenuItem.Checked)
			{
				orderBook = new OrderBook(ref ClientData);
				orderBook.Show();

				return;
			}

			else
			{
				orderBook.Close();
				orderBook.Dispose();
				orderBook = null;
				return;
			}
		}
	}
}
