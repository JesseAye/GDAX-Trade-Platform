using GDAXSharp;
using GDAXSharp.Network.Authentication;
using GDAXSharp.Shared.Types;
using GDAXSharp.WebSocket.Models.Response;
using GDAXSharp.WebSocket.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDAX_Trade_Platform
{
	public partial class MainForm : Form
	{
		GDAXClient gdaxClient;
		OrderBook orderBook;
		Order order;

		public MainForm()
		{
			InitializeComponent();
			Authentication getAuth = new Authentication(this);
			getAuth.ShowDialog();

			if(OrderBookMenuItem.Checked == true)
			{
				orderBook = new OrderBook(gdaxClient);
				orderBook.Show();
			}

			order = new Order(gdaxClient);
			order.Show();
		}

		public bool Authenticate(Authenticator auth, bool isSandbox)
		{
			gdaxClient = new GDAXClient(auth, isSandbox);

			var productTypes = new List<ProductType>() { ProductType.LtcUsd };
			var channels = new List<ChannelType>() { ChannelType.Level2, ChannelType.User }; // When not providing any channels, the socket will subscribe to all channels

			var webSocket = gdaxClient.WebSocket;
			webSocket.Start(productTypes, channels);

			// EventHandler for the heartbeat response type
			webSocket.OnHeartbeatReceived += WebSocket_OnHeartbeatReceived;
			webSocket.OnLevel2UpdateReceived += WebSocket_OnLevel2UpdateReceived;

			return true;
		}

		private static void WebSocket_OnHeartbeatReceived(object sender, WebfeedEventArgs<Heartbeat> e)
		{
			
		}

		private void WebSocket_OnLevel2UpdateReceived(object sender, WebfeedEventArgs<Level2> e)
		{
			if((orderBook != null) && (!orderBook.Disposing))
			{
				orderBook.ReceiveL2Update(e.LastOrder);
			}
		}

		async Task<Decimal> MidMarketPrice()
		{
			var PT = await gdaxClient.ProductsService.GetProductTickerAsync(ProductType.LtcUsd);

			return (PT.Ask + PT.Bid) / 2;
		}

		private async Task ExecuteOrderAsync()
		{
			//var sendorder = await gdaxClient.OrdersService.PlaceLimitOrderAsync(GDAXSharp.Services.Orders.Types.OrderSide.Buy, ProductType.LtcUsd, Convert.ToDecimal(AmountBox.Text), Convert.ToDecimal(PriceBox.Text)
			//		, GDAXSharp.Services.Orders.Types.TimeInForce.Gtc, true);
		}

		private void OrderBookMenuItem_CheckStateChanged(object sender, EventArgs e)
		{
			if (OrderBookMenuItem.Checked)
			{
				orderBook = new OrderBook(gdaxClient);
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
