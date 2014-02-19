using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirportLibrary;

namespace Airport
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		bool _integratedSec = false;
		string _login = "";
		string _pass = "";
		bool _remember = false;

		public bool IntegratedSecurity
		{
			get
			{
				return _integratedSec;
			}
		}

		public string Login
		{
			get
			{
				return _login;
			}
		}

		public string Password
		{
			get
			{
				return _pass;
			}
		}



		private void LoginForm_Load(object sender, EventArgs e)
		{
			if (integratedSecurityRadioButton.Checked == true)
			{
				logintextBox.Enabled = false;
				passwordTextBox.Enabled = false;
			}
			else if (noIntegratedSecurityRadioButton.Checked == true)
			{
				logintextBox.Enabled = true;
				passwordTextBox.Enabled = true;
			}



		}

		private void integratedSecurityRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (integratedSecurityRadioButton.Checked == true)
			{
				logintextBox.Enabled = false;
				passwordTextBox.Enabled = false;
			}
			else if (noIntegratedSecurityRadioButton.Checked == true)
			{
				logintextBox.Enabled = true;
				passwordTextBox.Enabled = true;
			}


		}

		private void OKbutton_Click(object sender, EventArgs e)
		{
			Configs cfg = new Configs();
			if (integratedSecurityRadioButton.Checked == true)
			{
				_integratedSec = true;
			}
			else
			{
				_integratedSec = false;
			}

			cfg.IntegratedSecurity = _integratedSec;
			cfg.Login = logintextBox.Text;
			cfg.Password = passwordTextBox.Text;

			if (remembercheckBox.Checked == true)
				_remember = true;
			else if (remembercheckBox.Checked == false)
				_remember = false;

			if (cfg.TryToConnect(_remember) == true)
			{
				MessageBox.Show("Добро пожаловать!", "Приветствие", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
			else
			{
				MessageBox.Show("Неуспешно. Попробуйте еще раз. " + cfg.ErrorString, "Oooppps!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}



	}
}
