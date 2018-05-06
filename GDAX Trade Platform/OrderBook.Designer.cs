namespace GDAX_Trade_Platform
{
	partial class OrderBook
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AskSellTable = new System.Windows.Forms.DataGridView();
			this.BidBuyOrdersLabel = new System.Windows.Forms.Label();
			this.AskSellOrdersLabel = new System.Windows.Forms.Label();
			this.BidBuyTable = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.AskSellTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BidBuyTable)).BeginInit();
			this.SuspendLayout();
			// 
			// AskSellTable
			// 
			this.AskSellTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.AskSellTable.Location = new System.Drawing.Point(260, 32);
			this.AskSellTable.Name = "AskSellTable";
			this.AskSellTable.RowHeadersVisible = false;
			this.AskSellTable.Size = new System.Drawing.Size(242, 380);
			this.AskSellTable.TabIndex = 1;
			// 
			// BidBuyOrdersLabel
			// 
			this.BidBuyOrdersLabel.AutoSize = true;
			this.BidBuyOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BidBuyOrdersLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.BidBuyOrdersLabel.Location = new System.Drawing.Point(78, 9);
			this.BidBuyOrdersLabel.Name = "BidBuyOrdersLabel";
			this.BidBuyOrdersLabel.Size = new System.Drawing.Size(129, 20);
			this.BidBuyOrdersLabel.TabIndex = 2;
			this.BidBuyOrdersLabel.Text = "Bid/Buy Orders";
			// 
			// AskSellOrdersLabel
			// 
			this.AskSellOrdersLabel.AutoSize = true;
			this.AskSellOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AskSellOrdersLabel.ForeColor = System.Drawing.Color.Red;
			this.AskSellOrdersLabel.Location = new System.Drawing.Point(314, 9);
			this.AskSellOrdersLabel.Name = "AskSellOrdersLabel";
			this.AskSellOrdersLabel.Size = new System.Drawing.Size(133, 20);
			this.AskSellOrdersLabel.TabIndex = 3;
			this.AskSellOrdersLabel.Text = "Ask/Sell Orders";
			// 
			// BidBuyTable
			// 
			this.BidBuyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.BidBuyTable.Location = new System.Drawing.Point(12, 32);
			this.BidBuyTable.Name = "BidBuyTable";
			this.BidBuyTable.RowHeadersVisible = false;
			this.BidBuyTable.Size = new System.Drawing.Size(242, 380);
			this.BidBuyTable.TabIndex = 4;
			// 
			// OrderBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 419);
			this.Controls.Add(this.BidBuyTable);
			this.Controls.Add(this.AskSellOrdersLabel);
			this.Controls.Add(this.BidBuyOrdersLabel);
			this.Controls.Add(this.AskSellTable);
			this.DoubleBuffered = true;
			this.Name = "OrderBook";
			this.Text = "OrderBook";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.AskSellTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BidBuyTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DataGridView AskSellTable;
		private System.Windows.Forms.Label BidBuyOrdersLabel;
		private System.Windows.Forms.Label AskSellOrdersLabel;
		private System.Windows.Forms.DataGridView BidBuyTable;
	}
}