using GDAXSharp;
using GDAXSharp.Services.Orders.Types;
using GDAXSharp.Shared.Types;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDAX_Trade_Platform
{
	public partial class Order : Form
	{
		Data ClientData;

		public Order(ref Data ClientDataRef)
		{
			InitializeComponent();
			ClientData = ClientDataRef;

			Thread t = new Thread(MainLoopAsync);
			t.Start();
		}

		private async void MainLoopAsync()
		{
			while (!Disposing)
			{
				var Balances = await ClientData.Client.AccountsService.GetAllAccountsAsync();

				MethodInvoker methodInvoker = delegate
				{
					/*
					//If LTC is avail but USD is not, disable the buy tab
					if (Balances.ElementAt(0).Available < Convert.ToDecimal(0.01)
						&& Balances.ElementAt(2).Available > Convert.ToDecimal(0.00000001))
					{
						BuySellContainer.SelectTab(1);
						BuyTab.Enabled = false;
						BuyTab.Visible = false;

						SellTab.Enabled = true;
						SellTab.Visible = true;

					}

					//If USD is avail but LTC is not, disable the Sell tab
					else if (Balances.ElementAt(0).Available > Convert.ToDecimal(0.01)
						&& Balances.ElementAt(2).Available < Convert.ToDecimal(0.00000001))
					{
						BuySellContainer.SelectTab(0);
						SellTab.Enabled = false;
						SellTab.Visible = false;

						BuyTab.Enabled = true;
						BuyTab.Visible = true;
					}

					//If nothing avail, disable both tabs
					else
					{

					}
					*/

					USDLabel.Text = Balances.ElementAt(1).Available.ToString();
					LTCLabel.Text = Balances.ElementAt(0).Available.ToString();
				};

				Invoke(methodInvoker);
				//0 USD
				//2 LTC
			}
		}

		private void StopBuyLimitCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if(StopBuyLimitCheckBox.Checked == true)
			{
				StopBuyLimitBox.Enabled = true;
				StopBuyLimitBox.Visible = true;
			}

			else
			{
				StopBuyLimitBox.Enabled = false;
				StopBuyLimitBox.Visible = false;
			}
		}

		private void StopSellLimitCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if(StopSellLimitCheckBox.Checked == true)
			{
				StopSellLimitBox.Enabled = true;
				StopSellLimitBox.Visible = true;
			}

			else
			{
				StopSellLimitBox.Enabled = false;
				StopSellLimitBox.Visible = false;
			}
		}

		/// <summary>
		/// Executes a market order
		/// </summary>
		/// <param name="orderSide">Whether order is buy or sell</param>
		/// <param name="productType">Crypto to be traded</param>
		/// <param name="Amount">The amount of the crypto to be traded</param>
		/// <returns></returns>
		private async Task ExecuteMarketOrderAsync(OrderSide orderSide, ProductType productType, Decimal Amount)
		{
			var sendorder = await ClientData.Client.OrdersService.PlaceMarketOrderAsync(orderSide, productType, Amount);
		}

		/// <summary>
		/// Executes a Limit order. This order will only be executed once an order is placed that satisfies the Price desired
		/// </summary>
		/// <param name="orderSide">Whether order is buy or sell</param>
		/// <param name="productType">Crypto to be traded</param>
		/// <param name="Amount">The amount of the crypto to be traded</param>
		/// <param name="Price">The price that needs to be met for this order to be executed</param>
		/// <param name="timeInForce">How long this order will stay open for</param>
		/// <param name="postOnly">Only place order as a maker, no taker orders will be executed.</param>
		/// <returns></returns>
		private async Task ExecuteLimitOrderAsync(OrderSide orderSide, ProductType productType, Decimal Amount,
			Decimal Price, TimeInForce timeInForce = TimeInForce.Gtc, bool postOnly = true)
		{
			var sendorder = await ClientData.Client.OrdersService.PlaceLimitOrderAsync(orderSide, productType, Amount, Price, timeInForce, postOnly);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderSide"></param>
		/// <param name="productType"></param>
		/// <param name="Amount"></param>
		/// <param name="Price"></param>
		/// <param name="test"></param>
		/// <returns></returns>
		private async Task ExecuteStopOrderAsync(OrderSide orderSide, ProductType productType, Decimal Amount, Decimal stopPrice, bool test)
		{
			if (orderSide == OrderSide.Buy)
			{
				if (StopBuyLimitCheckBox.Checked == true)
				{
					var sendorder = await ClientData.Client.OrdersService.PlaceStopOrderAsync(orderSide, productType, Amount, stopPrice);
				}

				else
				{
					var sendorder = await ClientData.Client.OrdersService.PlaceStopOrderAsync(orderSide, productType, Amount, stopPrice);
				}
			}

			else if (orderSide == OrderSide.Sell)
			{
				if (StopSellLimitCheckBox.Checked == true)
				{
					var sendorder = await ClientData.Client.OrdersService.PlaceStopOrderAsync(orderSide, productType, Amount, stopPrice);
				}

				else
				{
					var sendorder = await ClientData.Client.OrdersService.PlaceStopOrderAsync(orderSide, productType, Amount, stopPrice);
				}
			}

		}

		private async Task ExecuteTrailingSellAsync()
		{
			throw new NotImplementedException();
		}

		private async void BuyMarketExecButton_Click(object sender, EventArgs e)
		{
			await ExecuteMarketOrderAsync(OrderSide.Buy, ProductType.LtcUsd, Convert.ToDecimal(MarketBuyAmountBox.Text));
		}

		private async void MarketSellExecButton_Click(object sender, EventArgs e)
		{
			await ExecuteMarketOrderAsync(OrderSide.Sell, ProductType.LtcUsd, Convert.ToDecimal(MarketSellAmountBox.Text));
		}

		private async void LimitBuyExecButton_Click(object sender, EventArgs e)
		{
			await ExecuteLimitOrderAsync(OrderSide.Buy, ProductType.LtcUsd, Convert.ToDecimal(LimitBuyAmountBox.Text), Convert.ToDecimal(LimitBuyPriceBox.Text));
		}

		private async void LimitSellExecButton_Click(object sender, EventArgs e)
		{
			await ExecuteLimitOrderAsync(OrderSide.Sell, ProductType.LtcUsd, Convert.ToDecimal(LimitSellAmountBox.Text), Convert.ToDecimal(LimitSellPriceBox.Text));
		}

		private void StopBuyExecButton_Click(object sender, EventArgs e)
		{

		}

		private void StopSellExecButton_Click(object sender, EventArgs e)
		{

		}
	}
}
