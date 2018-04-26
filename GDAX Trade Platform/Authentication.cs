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
	public partial class Authentication : Form
	{
		MainForm TempInst;
		public Authentication(MainForm mainForm)
		{
			InitializeComponent();
			TempInst = mainForm;
		}

		private void AuthenticateButton_Click(object sender, EventArgs e)
		{
			TempInst.Authenticate(new GDAXSharp.Network.Authentication.Authenticator(KeyBox.Text, SigBox.Text, PassBox.Text), IsSandboxCheckBox.Checked);
			this.Dispose();
			this.Close();
		}
	}
}
