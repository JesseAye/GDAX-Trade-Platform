namespace GDAX_Trade_Platform
{
	partial class Authentication
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
			this.KeyBox = new System.Windows.Forms.TextBox();
			this.SigBox = new System.Windows.Forms.TextBox();
			this.PassBox = new System.Windows.Forms.TextBox();
			this.KeyLabel = new System.Windows.Forms.Label();
			this.SigLabel = new System.Windows.Forms.Label();
			this.PassLabel = new System.Windows.Forms.Label();
			this.AuthenticateButton = new System.Windows.Forms.Button();
			this.IsSandboxCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// KeyBox
			// 
			this.KeyBox.Location = new System.Drawing.Point(94, 13);
			this.KeyBox.Name = "KeyBox";
			this.KeyBox.Size = new System.Drawing.Size(178, 20);
			this.KeyBox.TabIndex = 0;
			// 
			// SigBox
			// 
			this.SigBox.Location = new System.Drawing.Point(94, 40);
			this.SigBox.Name = "SigBox";
			this.SigBox.Size = new System.Drawing.Size(178, 20);
			this.SigBox.TabIndex = 1;
			// 
			// PassBox
			// 
			this.PassBox.Location = new System.Drawing.Point(94, 67);
			this.PassBox.Name = "PassBox";
			this.PassBox.Size = new System.Drawing.Size(177, 20);
			this.PassBox.TabIndex = 2;
			// 
			// KeyLabel
			// 
			this.KeyLabel.AutoSize = true;
			this.KeyLabel.Location = new System.Drawing.Point(12, 16);
			this.KeyLabel.Name = "KeyLabel";
			this.KeyLabel.Size = new System.Drawing.Size(25, 13);
			this.KeyLabel.TabIndex = 3;
			this.KeyLabel.Text = "Key";
			// 
			// SigLabel
			// 
			this.SigLabel.AutoSize = true;
			this.SigLabel.Location = new System.Drawing.Point(12, 43);
			this.SigLabel.Name = "SigLabel";
			this.SigLabel.Size = new System.Drawing.Size(52, 13);
			this.SigLabel.TabIndex = 4;
			this.SigLabel.Text = "Signature";
			// 
			// PassLabel
			// 
			this.PassLabel.AutoSize = true;
			this.PassLabel.Location = new System.Drawing.Point(12, 70);
			this.PassLabel.Name = "PassLabel";
			this.PassLabel.Size = new System.Drawing.Size(62, 13);
			this.PassLabel.TabIndex = 5;
			this.PassLabel.Text = "Passphrase";
			// 
			// AuthenticateButton
			// 
			this.AuthenticateButton.Location = new System.Drawing.Point(187, 93);
			this.AuthenticateButton.Name = "AuthenticateButton";
			this.AuthenticateButton.Size = new System.Drawing.Size(84, 23);
			this.AuthenticateButton.TabIndex = 6;
			this.AuthenticateButton.Text = "Authenticate";
			this.AuthenticateButton.UseVisualStyleBackColor = true;
			this.AuthenticateButton.Click += new System.EventHandler(this.AuthenticateButton_Click);
			// 
			// IsSandboxCheckBox
			// 
			this.IsSandboxCheckBox.AutoSize = true;
			this.IsSandboxCheckBox.Location = new System.Drawing.Point(12, 97);
			this.IsSandboxCheckBox.Name = "IsSandboxCheckBox";
			this.IsSandboxCheckBox.Size = new System.Drawing.Size(118, 17);
			this.IsSandboxCheckBox.TabIndex = 7;
			this.IsSandboxCheckBox.Text = "API Sandbox Mode";
			this.IsSandboxCheckBox.UseVisualStyleBackColor = true;
			// 
			// Authentication
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 126);
			this.Controls.Add(this.IsSandboxCheckBox);
			this.Controls.Add(this.AuthenticateButton);
			this.Controls.Add(this.PassLabel);
			this.Controls.Add(this.SigLabel);
			this.Controls.Add(this.KeyLabel);
			this.Controls.Add(this.PassBox);
			this.Controls.Add(this.SigBox);
			this.Controls.Add(this.KeyBox);
			this.Name = "Authentication";
			this.Text = "Authentication";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox KeyBox;
		private System.Windows.Forms.TextBox SigBox;
		private System.Windows.Forms.TextBox PassBox;
		private System.Windows.Forms.Label KeyLabel;
		private System.Windows.Forms.Label SigLabel;
		private System.Windows.Forms.Label PassLabel;
		private System.Windows.Forms.Button AuthenticateButton;
		private System.Windows.Forms.CheckBox IsSandboxCheckBox;
	}
}