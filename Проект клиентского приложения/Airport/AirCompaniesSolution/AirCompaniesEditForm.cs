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

namespace AirCompaniesSolution
{
    public partial class AirCompaniesEditForm : Form
    {
        public AirCompanyInfo _newAirCompanyInfo = new AirCompanyInfo();

        public AirCompaniesEditForm()
        {
            InitializeComponent();
        }

        private void AirCompaniesEditForm_Load(object sender, EventArgs e)
        {
            this.Text += " - ";
            this.Text += airCompanyNameTextBox.Text;
            if (_newAirCompanyInfo.AirCompanyName.Equals(""))
            {
                this.Text += "Добавить авиакомпанию";
            }
            else
            {
                this.Text += _newAirCompanyInfo.AirCompanyName;
            }
            airCompanyNameTextBox.Text = _newAirCompanyInfo.AirCompanyName;
            airCompanyPhoneTextBox.Text = _newAirCompanyInfo.AirCompanyPhone;
            airCompanyAddressTextBox.Text = _newAirCompanyInfo.AirCompanyAddress;
			if (_newAirCompanyInfo.AirCompanyID > 0)
			{
				if (Configs.HasUserAccess("AirCompanyUpdate"))
					buttonOK.Visible = true;
				else
					buttonOK.Visible = false;
			}
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _newAirCompanyInfo.AirCompanyName = airCompanyNameTextBox.Text;
            _newAirCompanyInfo.AirCompanyPhone = airCompanyPhoneTextBox.Text;
            _newAirCompanyInfo.AirCompanyAddress = airCompanyAddressTextBox.Text;
             
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
