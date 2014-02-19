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

namespace CountriesSolution
{
    public partial class CountriesEditForm : Form
    {
        public CountryInfo _cInfo = new CountryInfo();
        public CountriesEditForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _cInfo.CountryName = countryNameTextBox.Text;
        }

        private void CountriesEditForm_Load(object sender, EventArgs e)
        {
            countryNameTextBox.Text = _cInfo.CountryName;
			if (_cInfo.CountryID > 0)
			{
				if (Configs.HasUserAccess("CountryDelete"))
					buttonOK.Visible = true;
				else
					buttonOK.Visible = false;
			}
        }
    }
}
