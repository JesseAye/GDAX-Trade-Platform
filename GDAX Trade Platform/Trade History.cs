using GDAXSharp.WebSocket.Models.Response;
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
	public partial class Trade_History : Form
	{
		Data ClientData;

		private DataTable TradesTable;
		public DataTable TradeHistory { get { return TradesTable; } }

		public Trade_History(ref Data ClientDataRef)
		{
			InitializeComponent();
			ClientData = ClientDataRef;
			ClientData.TickerReceived += TickerReceived;

			TradesTable = new DataTable();
			TradesTable.Columns.Add("Trade Size");
			TradesTable.Columns.Add("Price");
			TradesTable.Columns.Add("Time");

			dataGridView1.DataSource = TradesTable;

			TradesTable.Rows.Add("1", "1.00", "10:00");
		}

		private void TickerReceived(object sender, WebfeedEventArgs<Ticker> e)
		{
			DataRow row = TradesTable.NewRow();
			row[0] = e.LastOrder.LastSize;
			row[1] = e.LastOrder.Price;
			row[2] = e.LastOrder.Time;
			TradesTable.Rows.InsertAt(row, 0);
			TradesTable.AcceptChanges();

			dataGridView1.Invoke((MethodInvoker)delegate
			{
				dataGridView1.Invalidate();
			});

			/*
			BeginInvoke(new Action(delegate ()
			{
				dataGridView1.Update();
			}));
			*/
		}

		private void Trade_History_Load(object sender, EventArgs e)
		{
			this.dataGridView1.VirtualMode = true;
		}
	}
}
