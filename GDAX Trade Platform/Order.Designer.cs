namespace GDAX_Trade_Platform
{
	partial class Order
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
			this.BuyLayout = new System.Windows.Forms.TabControl();
			this.MarketBuyTab = new System.Windows.Forms.TabPage();
			this.LimitBuyTab = new System.Windows.Forms.TabPage();
			this.StopBuyTab = new System.Windows.Forms.TabPage();
			this.BuySellContainer = new System.Windows.Forms.TabControl();
			this.BuyTab = new System.Windows.Forms.TabPage();
			this.SellTab = new System.Windows.Forms.TabPage();
			this.SellLayout = new System.Windows.Forms.TabControl();
			this.MarketSellTab = new System.Windows.Forms.TabPage();
			this.LimitSellTab = new System.Windows.Forms.TabPage();
			this.StopSellTab = new System.Windows.Forms.TabPage();
			this.Trailing = new System.Windows.Forms.TabPage();
			this.StaticUSDLabel = new System.Windows.Forms.Label();
			this.StaticLTCLabel = new System.Windows.Forms.Label();
			this.USDLabel = new System.Windows.Forms.Label();
			this.LTCLabel = new System.Windows.Forms.Label();
			this.MarketBuyAmountLabel = new System.Windows.Forms.Label();
			this.MarketBuyAmountBox = new System.Windows.Forms.TextBox();
			this.BuyMarketExecButton = new System.Windows.Forms.Button();
			this.LimitBuyExecButton = new System.Windows.Forms.Button();
			this.LimitBuyAmountBox = new System.Windows.Forms.TextBox();
			this.LimitBuyAmountLabel = new System.Windows.Forms.Label();
			this.LimitBuyPriceBox = new System.Windows.Forms.TextBox();
			this.LimitBuyPriceLabel = new System.Windows.Forms.Label();
			this.StopBuyPriceBox = new System.Windows.Forms.TextBox();
			this.StopBuyPriceLabel = new System.Windows.Forms.Label();
			this.StopBuyExecButton = new System.Windows.Forms.Button();
			this.StopBuyAmountBox = new System.Windows.Forms.TextBox();
			this.StopBuyAmountLabel = new System.Windows.Forms.Label();
			this.StopBuyLimitCheckBox = new System.Windows.Forms.CheckBox();
			this.StopBuyLimitBox = new System.Windows.Forms.TextBox();
			this.StopSellLimitBox = new System.Windows.Forms.TextBox();
			this.StopSellLimitCheckBox = new System.Windows.Forms.CheckBox();
			this.StopSellPriceBox = new System.Windows.Forms.TextBox();
			this.StopSellPriceLabel = new System.Windows.Forms.Label();
			this.StopSellExecButton = new System.Windows.Forms.Button();
			this.StopSellAmountBox = new System.Windows.Forms.TextBox();
			this.StopSellAmountLabel = new System.Windows.Forms.Label();
			this.LimitSellPriceBox = new System.Windows.Forms.TextBox();
			this.LimitSellPriceLabel = new System.Windows.Forms.Label();
			this.LimitSellExecButton = new System.Windows.Forms.Button();
			this.LimitSellAmountBox = new System.Windows.Forms.TextBox();
			this.LimitSellAmountLabel = new System.Windows.Forms.Label();
			this.MarketSellExecButton = new System.Windows.Forms.Button();
			this.MarketSellAmountBox = new System.Windows.Forms.TextBox();
			this.MarketSellAmountLabel = new System.Windows.Forms.Label();
			this.BuyLayout.SuspendLayout();
			this.MarketBuyTab.SuspendLayout();
			this.LimitBuyTab.SuspendLayout();
			this.StopBuyTab.SuspendLayout();
			this.BuySellContainer.SuspendLayout();
			this.BuyTab.SuspendLayout();
			this.SellTab.SuspendLayout();
			this.SellLayout.SuspendLayout();
			this.MarketSellTab.SuspendLayout();
			this.LimitSellTab.SuspendLayout();
			this.StopSellTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// BuyLayout
			// 
			this.BuyLayout.Controls.Add(this.MarketBuyTab);
			this.BuyLayout.Controls.Add(this.LimitBuyTab);
			this.BuyLayout.Controls.Add(this.StopBuyTab);
			this.BuyLayout.Location = new System.Drawing.Point(6, 6);
			this.BuyLayout.Name = "BuyLayout";
			this.BuyLayout.SelectedIndex = 0;
			this.BuyLayout.Size = new System.Drawing.Size(212, 155);
			this.BuyLayout.TabIndex = 0;
			// 
			// MarketBuyTab
			// 
			this.MarketBuyTab.Controls.Add(this.BuyMarketExecButton);
			this.MarketBuyTab.Controls.Add(this.MarketBuyAmountBox);
			this.MarketBuyTab.Controls.Add(this.MarketBuyAmountLabel);
			this.MarketBuyTab.Location = new System.Drawing.Point(4, 22);
			this.MarketBuyTab.Name = "MarketBuyTab";
			this.MarketBuyTab.Padding = new System.Windows.Forms.Padding(3);
			this.MarketBuyTab.Size = new System.Drawing.Size(204, 129);
			this.MarketBuyTab.TabIndex = 0;
			this.MarketBuyTab.Text = "Market";
			this.MarketBuyTab.UseVisualStyleBackColor = true;
			// 
			// LimitBuyTab
			// 
			this.LimitBuyTab.Controls.Add(this.LimitBuyPriceBox);
			this.LimitBuyTab.Controls.Add(this.LimitBuyPriceLabel);
			this.LimitBuyTab.Controls.Add(this.LimitBuyExecButton);
			this.LimitBuyTab.Controls.Add(this.LimitBuyAmountBox);
			this.LimitBuyTab.Controls.Add(this.LimitBuyAmountLabel);
			this.LimitBuyTab.Location = new System.Drawing.Point(4, 22);
			this.LimitBuyTab.Name = "LimitBuyTab";
			this.LimitBuyTab.Padding = new System.Windows.Forms.Padding(3);
			this.LimitBuyTab.Size = new System.Drawing.Size(204, 129);
			this.LimitBuyTab.TabIndex = 1;
			this.LimitBuyTab.Text = "Limit";
			this.LimitBuyTab.UseVisualStyleBackColor = true;
			// 
			// StopBuyTab
			// 
			this.StopBuyTab.Controls.Add(this.StopBuyLimitBox);
			this.StopBuyTab.Controls.Add(this.StopBuyLimitCheckBox);
			this.StopBuyTab.Controls.Add(this.StopBuyPriceBox);
			this.StopBuyTab.Controls.Add(this.StopBuyPriceLabel);
			this.StopBuyTab.Controls.Add(this.StopBuyExecButton);
			this.StopBuyTab.Controls.Add(this.StopBuyAmountBox);
			this.StopBuyTab.Controls.Add(this.StopBuyAmountLabel);
			this.StopBuyTab.Location = new System.Drawing.Point(4, 22);
			this.StopBuyTab.Name = "StopBuyTab";
			this.StopBuyTab.Size = new System.Drawing.Size(204, 129);
			this.StopBuyTab.TabIndex = 2;
			this.StopBuyTab.Text = "Stop";
			this.StopBuyTab.UseVisualStyleBackColor = true;
			// 
			// BuySellContainer
			// 
			this.BuySellContainer.Controls.Add(this.BuyTab);
			this.BuySellContainer.Controls.Add(this.SellTab);
			this.BuySellContainer.Location = new System.Drawing.Point(12, 53);
			this.BuySellContainer.Name = "BuySellContainer";
			this.BuySellContainer.SelectedIndex = 0;
			this.BuySellContainer.Size = new System.Drawing.Size(233, 193);
			this.BuySellContainer.TabIndex = 1;
			// 
			// BuyTab
			// 
			this.BuyTab.Controls.Add(this.BuyLayout);
			this.BuyTab.Location = new System.Drawing.Point(4, 22);
			this.BuyTab.Name = "BuyTab";
			this.BuyTab.Padding = new System.Windows.Forms.Padding(3);
			this.BuyTab.Size = new System.Drawing.Size(225, 167);
			this.BuyTab.TabIndex = 0;
			this.BuyTab.Text = "Buy";
			this.BuyTab.UseVisualStyleBackColor = true;
			// 
			// SellTab
			// 
			this.SellTab.Controls.Add(this.SellLayout);
			this.SellTab.Location = new System.Drawing.Point(4, 22);
			this.SellTab.Name = "SellTab";
			this.SellTab.Padding = new System.Windows.Forms.Padding(3);
			this.SellTab.Size = new System.Drawing.Size(225, 167);
			this.SellTab.TabIndex = 1;
			this.SellTab.Text = "Sell";
			this.SellTab.UseVisualStyleBackColor = true;
			// 
			// SellLayout
			// 
			this.SellLayout.Controls.Add(this.MarketSellTab);
			this.SellLayout.Controls.Add(this.LimitSellTab);
			this.SellLayout.Controls.Add(this.StopSellTab);
			this.SellLayout.Controls.Add(this.Trailing);
			this.SellLayout.Location = new System.Drawing.Point(6, 6);
			this.SellLayout.Name = "SellLayout";
			this.SellLayout.SelectedIndex = 0;
			this.SellLayout.Size = new System.Drawing.Size(212, 155);
			this.SellLayout.TabIndex = 2;
			// 
			// MarketSellTab
			// 
			this.MarketSellTab.Controls.Add(this.MarketSellExecButton);
			this.MarketSellTab.Controls.Add(this.MarketSellAmountBox);
			this.MarketSellTab.Controls.Add(this.MarketSellAmountLabel);
			this.MarketSellTab.Location = new System.Drawing.Point(4, 22);
			this.MarketSellTab.Name = "MarketSellTab";
			this.MarketSellTab.Padding = new System.Windows.Forms.Padding(3);
			this.MarketSellTab.Size = new System.Drawing.Size(204, 129);
			this.MarketSellTab.TabIndex = 0;
			this.MarketSellTab.Text = "Market";
			this.MarketSellTab.UseVisualStyleBackColor = true;
			// 
			// LimitSellTab
			// 
			this.LimitSellTab.Controls.Add(this.LimitSellPriceBox);
			this.LimitSellTab.Controls.Add(this.LimitSellPriceLabel);
			this.LimitSellTab.Controls.Add(this.LimitSellExecButton);
			this.LimitSellTab.Controls.Add(this.LimitSellAmountBox);
			this.LimitSellTab.Controls.Add(this.LimitSellAmountLabel);
			this.LimitSellTab.Location = new System.Drawing.Point(4, 22);
			this.LimitSellTab.Name = "LimitSellTab";
			this.LimitSellTab.Padding = new System.Windows.Forms.Padding(3);
			this.LimitSellTab.Size = new System.Drawing.Size(204, 129);
			this.LimitSellTab.TabIndex = 1;
			this.LimitSellTab.Text = "Limit";
			this.LimitSellTab.UseVisualStyleBackColor = true;
			// 
			// StopSellTab
			// 
			this.StopSellTab.Controls.Add(this.StopSellLimitBox);
			this.StopSellTab.Controls.Add(this.StopSellLimitCheckBox);
			this.StopSellTab.Controls.Add(this.StopSellPriceBox);
			this.StopSellTab.Controls.Add(this.StopSellPriceLabel);
			this.StopSellTab.Controls.Add(this.StopSellExecButton);
			this.StopSellTab.Controls.Add(this.StopSellAmountBox);
			this.StopSellTab.Controls.Add(this.StopSellAmountLabel);
			this.StopSellTab.Location = new System.Drawing.Point(4, 22);
			this.StopSellTab.Name = "StopSellTab";
			this.StopSellTab.Size = new System.Drawing.Size(204, 129);
			this.StopSellTab.TabIndex = 2;
			this.StopSellTab.Text = "Stop";
			this.StopSellTab.UseVisualStyleBackColor = true;
			// 
			// Trailing
			// 
			this.Trailing.Location = new System.Drawing.Point(4, 22);
			this.Trailing.Name = "Trailing";
			this.Trailing.Size = new System.Drawing.Size(203, 452);
			this.Trailing.TabIndex = 3;
			this.Trailing.Text = "Trailing";
			this.Trailing.UseVisualStyleBackColor = true;
			// 
			// StaticUSDLabel
			// 
			this.StaticUSDLabel.AutoSize = true;
			this.StaticUSDLabel.Location = new System.Drawing.Point(12, 9);
			this.StaticUSDLabel.Name = "StaticUSDLabel";
			this.StaticUSDLabel.Size = new System.Drawing.Size(33, 13);
			this.StaticUSDLabel.TabIndex = 2;
			this.StaticUSDLabel.Text = "USD:";
			// 
			// StaticLTCLabel
			// 
			this.StaticLTCLabel.AutoSize = true;
			this.StaticLTCLabel.Location = new System.Drawing.Point(12, 31);
			this.StaticLTCLabel.Name = "StaticLTCLabel";
			this.StaticLTCLabel.Size = new System.Drawing.Size(30, 13);
			this.StaticLTCLabel.TabIndex = 3;
			this.StaticLTCLabel.Text = "LTC:";
			// 
			// USDLabel
			// 
			this.USDLabel.AutoSize = true;
			this.USDLabel.Location = new System.Drawing.Point(51, 9);
			this.USDLabel.Name = "USDLabel";
			this.USDLabel.Size = new System.Drawing.Size(34, 13);
			this.USDLabel.TabIndex = 4;
			this.USDLabel.Text = "$0.00";
			// 
			// LTCLabel
			// 
			this.LTCLabel.AutoSize = true;
			this.LTCLabel.Location = new System.Drawing.Point(51, 31);
			this.LTCLabel.Name = "LTCLabel";
			this.LTCLabel.Size = new System.Drawing.Size(64, 13);
			this.LTCLabel.TabIndex = 5;
			this.LTCLabel.Text = "0.00000000";
			// 
			// MarketBuyAmountLabel
			// 
			this.MarketBuyAmountLabel.AutoSize = true;
			this.MarketBuyAmountLabel.Location = new System.Drawing.Point(9, 15);
			this.MarketBuyAmountLabel.Name = "MarketBuyAmountLabel";
			this.MarketBuyAmountLabel.Size = new System.Drawing.Size(43, 13);
			this.MarketBuyAmountLabel.TabIndex = 1;
			this.MarketBuyAmountLabel.Text = "Amount";
			// 
			// MarketBuyAmountBox
			// 
			this.MarketBuyAmountBox.Location = new System.Drawing.Point(92, 12);
			this.MarketBuyAmountBox.Name = "MarketBuyAmountBox";
			this.MarketBuyAmountBox.Size = new System.Drawing.Size(100, 20);
			this.MarketBuyAmountBox.TabIndex = 2;
			// 
			// BuyMarketExecButton
			// 
			this.BuyMarketExecButton.Location = new System.Drawing.Point(12, 38);
			this.BuyMarketExecButton.Name = "BuyMarketExecButton";
			this.BuyMarketExecButton.Size = new System.Drawing.Size(180, 23);
			this.BuyMarketExecButton.TabIndex = 3;
			this.BuyMarketExecButton.Text = "Execute Market Buy";
			this.BuyMarketExecButton.UseVisualStyleBackColor = true;
			this.BuyMarketExecButton.Click += new System.EventHandler(this.BuyMarketExecButton_Click);
			// 
			// LimitBuyExecButton
			// 
			this.LimitBuyExecButton.Location = new System.Drawing.Point(12, 64);
			this.LimitBuyExecButton.Name = "LimitBuyExecButton";
			this.LimitBuyExecButton.Size = new System.Drawing.Size(180, 23);
			this.LimitBuyExecButton.TabIndex = 6;
			this.LimitBuyExecButton.Text = "Execute Limit Buy";
			this.LimitBuyExecButton.UseVisualStyleBackColor = true;
			this.LimitBuyExecButton.Click += new System.EventHandler(this.LimitBuyExecButton_Click);
			// 
			// LimitBuyAmountBox
			// 
			this.LimitBuyAmountBox.Location = new System.Drawing.Point(92, 12);
			this.LimitBuyAmountBox.Name = "LimitBuyAmountBox";
			this.LimitBuyAmountBox.Size = new System.Drawing.Size(100, 20);
			this.LimitBuyAmountBox.TabIndex = 5;
			// 
			// LimitBuyAmountLabel
			// 
			this.LimitBuyAmountLabel.AutoSize = true;
			this.LimitBuyAmountLabel.Location = new System.Drawing.Point(9, 15);
			this.LimitBuyAmountLabel.Name = "LimitBuyAmountLabel";
			this.LimitBuyAmountLabel.Size = new System.Drawing.Size(43, 13);
			this.LimitBuyAmountLabel.TabIndex = 4;
			this.LimitBuyAmountLabel.Text = "Amount";
			// 
			// LimitBuyPriceBox
			// 
			this.LimitBuyPriceBox.Location = new System.Drawing.Point(92, 38);
			this.LimitBuyPriceBox.Name = "LimitBuyPriceBox";
			this.LimitBuyPriceBox.Size = new System.Drawing.Size(100, 20);
			this.LimitBuyPriceBox.TabIndex = 8;
			// 
			// LimitBuyPriceLabel
			// 
			this.LimitBuyPriceLabel.AutoSize = true;
			this.LimitBuyPriceLabel.Location = new System.Drawing.Point(9, 41);
			this.LimitBuyPriceLabel.Name = "LimitBuyPriceLabel";
			this.LimitBuyPriceLabel.Size = new System.Drawing.Size(31, 13);
			this.LimitBuyPriceLabel.TabIndex = 7;
			this.LimitBuyPriceLabel.Text = "Price";
			// 
			// StopBuyPriceBox
			// 
			this.StopBuyPriceBox.Location = new System.Drawing.Point(92, 38);
			this.StopBuyPriceBox.Name = "StopBuyPriceBox";
			this.StopBuyPriceBox.Size = new System.Drawing.Size(100, 20);
			this.StopBuyPriceBox.TabIndex = 13;
			// 
			// StopBuyPriceLabel
			// 
			this.StopBuyPriceLabel.AutoSize = true;
			this.StopBuyPriceLabel.Location = new System.Drawing.Point(9, 41);
			this.StopBuyPriceLabel.Name = "StopBuyPriceLabel";
			this.StopBuyPriceLabel.Size = new System.Drawing.Size(31, 13);
			this.StopBuyPriceLabel.TabIndex = 12;
			this.StopBuyPriceLabel.Text = "Price";
			// 
			// StopBuyExecButton
			// 
			this.StopBuyExecButton.Location = new System.Drawing.Point(12, 90);
			this.StopBuyExecButton.Name = "StopBuyExecButton";
			this.StopBuyExecButton.Size = new System.Drawing.Size(180, 23);
			this.StopBuyExecButton.TabIndex = 11;
			this.StopBuyExecButton.Text = "Execute Stop Buy";
			this.StopBuyExecButton.UseVisualStyleBackColor = true;
			this.StopBuyExecButton.Click += new System.EventHandler(this.StopBuyExecButton_Click);
			// 
			// StopBuyAmountBox
			// 
			this.StopBuyAmountBox.Location = new System.Drawing.Point(92, 12);
			this.StopBuyAmountBox.Name = "StopBuyAmountBox";
			this.StopBuyAmountBox.Size = new System.Drawing.Size(100, 20);
			this.StopBuyAmountBox.TabIndex = 10;
			// 
			// StopBuyAmountLabel
			// 
			this.StopBuyAmountLabel.AutoSize = true;
			this.StopBuyAmountLabel.Location = new System.Drawing.Point(9, 15);
			this.StopBuyAmountLabel.Name = "StopBuyAmountLabel";
			this.StopBuyAmountLabel.Size = new System.Drawing.Size(43, 13);
			this.StopBuyAmountLabel.TabIndex = 9;
			this.StopBuyAmountLabel.Text = "Amount";
			// 
			// StopBuyLimitCheckBox
			// 
			this.StopBuyLimitCheckBox.AutoSize = true;
			this.StopBuyLimitCheckBox.Location = new System.Drawing.Point(12, 66);
			this.StopBuyLimitCheckBox.Name = "StopBuyLimitCheckBox";
			this.StopBuyLimitCheckBox.Size = new System.Drawing.Size(74, 17);
			this.StopBuyLimitCheckBox.TabIndex = 14;
			this.StopBuyLimitCheckBox.Text = "Limit Price";
			this.StopBuyLimitCheckBox.UseVisualStyleBackColor = true;
			this.StopBuyLimitCheckBox.CheckedChanged += new System.EventHandler(this.StopBuyLimitCheckBox_CheckedChanged);
			// 
			// StopBuyLimitBox
			// 
			this.StopBuyLimitBox.Enabled = false;
			this.StopBuyLimitBox.Location = new System.Drawing.Point(92, 64);
			this.StopBuyLimitBox.Name = "StopBuyLimitBox";
			this.StopBuyLimitBox.Size = new System.Drawing.Size(100, 20);
			this.StopBuyLimitBox.TabIndex = 15;
			this.StopBuyLimitBox.Visible = false;
			// 
			// StopSellLimitBox
			// 
			this.StopSellLimitBox.Enabled = false;
			this.StopSellLimitBox.Location = new System.Drawing.Point(92, 64);
			this.StopSellLimitBox.Name = "StopSellLimitBox";
			this.StopSellLimitBox.Size = new System.Drawing.Size(100, 20);
			this.StopSellLimitBox.TabIndex = 22;
			this.StopSellLimitBox.Visible = false;
			// 
			// StopSellLimitCheckBox
			// 
			this.StopSellLimitCheckBox.AutoSize = true;
			this.StopSellLimitCheckBox.Location = new System.Drawing.Point(12, 66);
			this.StopSellLimitCheckBox.Name = "StopSellLimitCheckBox";
			this.StopSellLimitCheckBox.Size = new System.Drawing.Size(74, 17);
			this.StopSellLimitCheckBox.TabIndex = 21;
			this.StopSellLimitCheckBox.Text = "Limit Price";
			this.StopSellLimitCheckBox.UseVisualStyleBackColor = true;
			this.StopSellLimitCheckBox.CheckedChanged += new System.EventHandler(this.StopSellLimitCheckBox_CheckedChanged);
			// 
			// StopSellPriceBox
			// 
			this.StopSellPriceBox.Location = new System.Drawing.Point(92, 38);
			this.StopSellPriceBox.Name = "StopSellPriceBox";
			this.StopSellPriceBox.Size = new System.Drawing.Size(100, 20);
			this.StopSellPriceBox.TabIndex = 20;
			// 
			// StopSellPriceLabel
			// 
			this.StopSellPriceLabel.AutoSize = true;
			this.StopSellPriceLabel.Location = new System.Drawing.Point(9, 41);
			this.StopSellPriceLabel.Name = "StopSellPriceLabel";
			this.StopSellPriceLabel.Size = new System.Drawing.Size(31, 13);
			this.StopSellPriceLabel.TabIndex = 19;
			this.StopSellPriceLabel.Text = "Price";
			// 
			// StopSellExecButton
			// 
			this.StopSellExecButton.Location = new System.Drawing.Point(12, 90);
			this.StopSellExecButton.Name = "StopSellExecButton";
			this.StopSellExecButton.Size = new System.Drawing.Size(180, 23);
			this.StopSellExecButton.TabIndex = 18;
			this.StopSellExecButton.Text = "Execute Stop Sell";
			this.StopSellExecButton.UseVisualStyleBackColor = true;
			this.StopSellExecButton.Click += new System.EventHandler(this.StopSellExecButton_Click);
			// 
			// StopSellAmountBox
			// 
			this.StopSellAmountBox.Location = new System.Drawing.Point(92, 12);
			this.StopSellAmountBox.Name = "StopSellAmountBox";
			this.StopSellAmountBox.Size = new System.Drawing.Size(100, 20);
			this.StopSellAmountBox.TabIndex = 17;
			// 
			// StopSellAmountLabel
			// 
			this.StopSellAmountLabel.AutoSize = true;
			this.StopSellAmountLabel.Location = new System.Drawing.Point(9, 15);
			this.StopSellAmountLabel.Name = "StopSellAmountLabel";
			this.StopSellAmountLabel.Size = new System.Drawing.Size(43, 13);
			this.StopSellAmountLabel.TabIndex = 16;
			this.StopSellAmountLabel.Text = "Amount";
			// 
			// LimitSellPriceBox
			// 
			this.LimitSellPriceBox.Location = new System.Drawing.Point(92, 38);
			this.LimitSellPriceBox.Name = "LimitSellPriceBox";
			this.LimitSellPriceBox.Size = new System.Drawing.Size(100, 20);
			this.LimitSellPriceBox.TabIndex = 13;
			// 
			// LimitSellPriceLabel
			// 
			this.LimitSellPriceLabel.AutoSize = true;
			this.LimitSellPriceLabel.Location = new System.Drawing.Point(9, 41);
			this.LimitSellPriceLabel.Name = "LimitSellPriceLabel";
			this.LimitSellPriceLabel.Size = new System.Drawing.Size(31, 13);
			this.LimitSellPriceLabel.TabIndex = 12;
			this.LimitSellPriceLabel.Text = "Price";
			// 
			// LimitSellExecButton
			// 
			this.LimitSellExecButton.Location = new System.Drawing.Point(12, 64);
			this.LimitSellExecButton.Name = "LimitSellExecButton";
			this.LimitSellExecButton.Size = new System.Drawing.Size(180, 23);
			this.LimitSellExecButton.TabIndex = 11;
			this.LimitSellExecButton.Text = "Execute Limit Sell";
			this.LimitSellExecButton.UseVisualStyleBackColor = true;
			this.LimitSellExecButton.Click += new System.EventHandler(this.LimitSellExecButton_Click);
			// 
			// LimitSellAmountBox
			// 
			this.LimitSellAmountBox.Location = new System.Drawing.Point(92, 12);
			this.LimitSellAmountBox.Name = "LimitSellAmountBox";
			this.LimitSellAmountBox.Size = new System.Drawing.Size(100, 20);
			this.LimitSellAmountBox.TabIndex = 10;
			// 
			// LimitSellAmountLabel
			// 
			this.LimitSellAmountLabel.AutoSize = true;
			this.LimitSellAmountLabel.Location = new System.Drawing.Point(9, 15);
			this.LimitSellAmountLabel.Name = "LimitSellAmountLabel";
			this.LimitSellAmountLabel.Size = new System.Drawing.Size(43, 13);
			this.LimitSellAmountLabel.TabIndex = 9;
			this.LimitSellAmountLabel.Text = "Amount";
			// 
			// MarketSellExecButton
			// 
			this.MarketSellExecButton.Location = new System.Drawing.Point(12, 38);
			this.MarketSellExecButton.Name = "MarketSellExecButton";
			this.MarketSellExecButton.Size = new System.Drawing.Size(180, 23);
			this.MarketSellExecButton.TabIndex = 6;
			this.MarketSellExecButton.Text = "Execute Market Sell";
			this.MarketSellExecButton.UseVisualStyleBackColor = true;
			this.MarketSellExecButton.Click += new System.EventHandler(this.MarketSellExecButton_Click);
			// 
			// MarketSellAmountBox
			// 
			this.MarketSellAmountBox.Location = new System.Drawing.Point(92, 12);
			this.MarketSellAmountBox.Name = "MarketSellAmountBox";
			this.MarketSellAmountBox.Size = new System.Drawing.Size(100, 20);
			this.MarketSellAmountBox.TabIndex = 5;
			// 
			// MarketSellAmountLabel
			// 
			this.MarketSellAmountLabel.AutoSize = true;
			this.MarketSellAmountLabel.Location = new System.Drawing.Point(9, 15);
			this.MarketSellAmountLabel.Name = "MarketSellAmountLabel";
			this.MarketSellAmountLabel.Size = new System.Drawing.Size(43, 13);
			this.MarketSellAmountLabel.TabIndex = 4;
			this.MarketSellAmountLabel.Text = "Amount";
			// 
			// Order
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(251, 252);
			this.ControlBox = false;
			this.Controls.Add(this.LTCLabel);
			this.Controls.Add(this.USDLabel);
			this.Controls.Add(this.StaticLTCLabel);
			this.Controls.Add(this.StaticUSDLabel);
			this.Controls.Add(this.BuySellContainer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Order";
			this.Text = "Order";
			this.BuyLayout.ResumeLayout(false);
			this.MarketBuyTab.ResumeLayout(false);
			this.MarketBuyTab.PerformLayout();
			this.LimitBuyTab.ResumeLayout(false);
			this.LimitBuyTab.PerformLayout();
			this.StopBuyTab.ResumeLayout(false);
			this.StopBuyTab.PerformLayout();
			this.BuySellContainer.ResumeLayout(false);
			this.BuyTab.ResumeLayout(false);
			this.SellTab.ResumeLayout(false);
			this.SellLayout.ResumeLayout(false);
			this.MarketSellTab.ResumeLayout(false);
			this.MarketSellTab.PerformLayout();
			this.LimitSellTab.ResumeLayout(false);
			this.LimitSellTab.PerformLayout();
			this.StopSellTab.ResumeLayout(false);
			this.StopSellTab.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl BuyLayout;
		private System.Windows.Forms.TabPage MarketBuyTab;
		private System.Windows.Forms.TabPage LimitBuyTab;
		private System.Windows.Forms.TabPage StopBuyTab;
		private System.Windows.Forms.TabControl BuySellContainer;
		private System.Windows.Forms.TabPage BuyTab;
		private System.Windows.Forms.TabPage SellTab;
		private System.Windows.Forms.TabControl SellLayout;
		private System.Windows.Forms.TabPage MarketSellTab;
		private System.Windows.Forms.TabPage LimitSellTab;
		private System.Windows.Forms.TabPage StopSellTab;
		private System.Windows.Forms.TabPage Trailing;
		private System.Windows.Forms.Label StaticUSDLabel;
		private System.Windows.Forms.Label StaticLTCLabel;
		private System.Windows.Forms.Label USDLabel;
		private System.Windows.Forms.Label LTCLabel;
		private System.Windows.Forms.Button BuyMarketExecButton;
		private System.Windows.Forms.TextBox MarketBuyAmountBox;
		private System.Windows.Forms.Label MarketBuyAmountLabel;
		private System.Windows.Forms.TextBox LimitBuyPriceBox;
		private System.Windows.Forms.Label LimitBuyPriceLabel;
		private System.Windows.Forms.Button LimitBuyExecButton;
		private System.Windows.Forms.TextBox LimitBuyAmountBox;
		private System.Windows.Forms.Label LimitBuyAmountLabel;
		private System.Windows.Forms.TextBox StopBuyPriceBox;
		private System.Windows.Forms.Label StopBuyPriceLabel;
		private System.Windows.Forms.Button StopBuyExecButton;
		private System.Windows.Forms.TextBox StopBuyAmountBox;
		private System.Windows.Forms.Label StopBuyAmountLabel;
		private System.Windows.Forms.TextBox StopBuyLimitBox;
		private System.Windows.Forms.CheckBox StopBuyLimitCheckBox;
		private System.Windows.Forms.TextBox StopSellLimitBox;
		private System.Windows.Forms.CheckBox StopSellLimitCheckBox;
		private System.Windows.Forms.TextBox StopSellPriceBox;
		private System.Windows.Forms.Label StopSellPriceLabel;
		private System.Windows.Forms.Button StopSellExecButton;
		private System.Windows.Forms.TextBox StopSellAmountBox;
		private System.Windows.Forms.Label StopSellAmountLabel;
		private System.Windows.Forms.Button MarketSellExecButton;
		private System.Windows.Forms.TextBox MarketSellAmountBox;
		private System.Windows.Forms.Label MarketSellAmountLabel;
		private System.Windows.Forms.TextBox LimitSellPriceBox;
		private System.Windows.Forms.Label LimitSellPriceLabel;
		private System.Windows.Forms.Button LimitSellExecButton;
		private System.Windows.Forms.TextBox LimitSellAmountBox;
		private System.Windows.Forms.Label LimitSellAmountLabel;
	}
}