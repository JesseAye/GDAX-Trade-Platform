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
			this.BidBuyTable = new System.Windows.Forms.DataGridView();
			this.MarketSizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MySizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AskSellTable = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BidBuyOrdersLabel = new System.Windows.Forms.Label();
			this.AskSellOrdersLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BidBuyTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AskSellTable)).BeginInit();
			this.SuspendLayout();
			// 
			// BidBuyTable
			// 
			this.BidBuyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.BidBuyTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MarketSizeColumn,
            this.PriceColumn,
            this.MySizeColumn});
			this.BidBuyTable.Location = new System.Drawing.Point(12, 32);
			this.BidBuyTable.Name = "BidBuyTable";
			this.BidBuyTable.RowHeadersVisible = false;
			this.BidBuyTable.Size = new System.Drawing.Size(242, 380);
			this.BidBuyTable.TabIndex = 0;
			// 
			// MarketSizeColumn
			// 
			this.MarketSizeColumn.HeaderText = "Market Size";
			this.MarketSizeColumn.Name = "MarketSizeColumn";
			this.MarketSizeColumn.Width = 86;
			// 
			// PriceColumn
			// 
			this.PriceColumn.HeaderText = "Price (USD)";
			this.PriceColumn.Name = "PriceColumn";
			this.PriceColumn.Width = 86;
			// 
			// MySizeColumn
			// 
			this.MySizeColumn.HeaderText = "My Size";
			this.MySizeColumn.Name = "MySizeColumn";
			this.MySizeColumn.Width = 67;
			// 
			// AskSellTable
			// 
			this.AskSellTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.AskSellTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
			this.AskSellTable.Location = new System.Drawing.Point(260, 32);
			this.AskSellTable.Name = "AskSellTable";
			this.AskSellTable.RowHeadersVisible = false;
			this.AskSellTable.Size = new System.Drawing.Size(242, 380);
			this.AskSellTable.TabIndex = 1;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Market Size";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 86;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "Price (USD)";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 86;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "My Size";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 67;
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
			// OrderBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 419);
			this.ControlBox = false;
			this.Controls.Add(this.AskSellOrdersLabel);
			this.Controls.Add(this.BidBuyOrdersLabel);
			this.Controls.Add(this.AskSellTable);
			this.Controls.Add(this.BidBuyTable);
			this.Name = "OrderBook";
			this.Text = "OrderBook";
			((System.ComponentModel.ISupportInitialize)(this.BidBuyTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AskSellTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView BidBuyTable;
		private System.Windows.Forms.DataGridViewTextBoxColumn MarketSizeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn PriceColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn MySizeColumn;
		private System.Windows.Forms.DataGridView AskSellTable;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.Label BidBuyOrdersLabel;
		private System.Windows.Forms.Label AskSellOrdersLabel;
	}
}