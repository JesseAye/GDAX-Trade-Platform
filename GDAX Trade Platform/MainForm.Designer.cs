namespace GDAX_Trade_Platform
{
	partial class MainForm
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
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.WindowsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OrderBookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuStrip
			// 
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WindowsMenuItem});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(924, 24);
			this.MenuStrip.TabIndex = 0;
			// 
			// WindowsMenuItem
			// 
			this.WindowsMenuItem.CheckOnClick = true;
			this.WindowsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrderBookMenuItem});
			this.WindowsMenuItem.Name = "WindowsMenuItem";
			this.WindowsMenuItem.Size = new System.Drawing.Size(68, 20);
			this.WindowsMenuItem.Text = "Windows";
			// 
			// OrderBookMenuItem
			// 
			this.OrderBookMenuItem.Checked = true;
			this.OrderBookMenuItem.CheckOnClick = true;
			this.OrderBookMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.OrderBookMenuItem.Name = "OrderBookMenuItem";
			this.OrderBookMenuItem.Size = new System.Drawing.Size(134, 22);
			this.OrderBookMenuItem.Text = "Order Book";
			this.OrderBookMenuItem.CheckStateChanged += new System.EventHandler(this.OrderBookMenuItem_CheckStateChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(924, 535);
			this.Controls.Add(this.MenuStrip);
			this.MainMenuStrip = this.MenuStrip;
			this.Name = "MainForm";
			this.Text = "GDAX Trading Platform";
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem WindowsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OrderBookMenuItem;
	}
}

