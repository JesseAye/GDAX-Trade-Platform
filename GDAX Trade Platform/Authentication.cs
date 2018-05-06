using GDAXSharp;
using System;
using System.Windows.Forms;

namespace GDAX_Trade_Platform
{
	public partial class Authentication : Form
	{
		Data ClientData;

		public Authentication(ref Data ClientDataRef)
		{
			InitializeComponent();
			ClientData = ClientDataRef;
		}

		private void AuthenticateButton_Click(object sender, EventArgs e)
		{
			ClientData.Authenticate(new GDAXSharp.Network.Authentication.Authenticator(KeyBox.Text, SigBox.Text, PassBox.Text), IsSandboxCheckBox.Checked);
			this.Dispose();
			this.Close();
		}
	}
}
