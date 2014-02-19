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

namespace CitiesSolution
{
    public partial class CityEditForm : Form
    {
        public CityInfo _cityInfo = new CityInfo();
        public CityEditForm()
        {
            InitializeComponent();
        }

        private void CityEditForm_Load(object sender, EventArgs e)
        {
            CountriesList _countriesList = CountriesList.GetDefaultCountriesList();
            countryIDcomboBox.DataSource = _countriesList;
            
            countryIDcomboBox.SelectedValue = _cityInfo.CountryID;
            cityNameTextBox.Text = _cityInfo.CityName;
            if (_cityInfo.SignGMT == "+")
                comboBox1.SelectedIndex = 0;
            else if (_cityInfo.SignGMT == "-")
                comboBox1.SelectedIndex = 1;
            populationTextBox.Text = _cityInfo.Population.ToString();
            cityNameTextBox.Text = _cityInfo.CityName;
            gMTDateTimePicker.Value = _cityInfo.GMT;

			if (_cityInfo.CityID > 0)
			{
				if (Configs.HasUserAccess("CityUpdate"))
					buttonOk.Visible = true;
				else
					buttonOk.Visible = false;
			}
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            bool flag = true;
            DateTime _pickerGmt = gMTDateTimePicker.Value;
            DateTime _gmt = new DateTime(1900, 1, 1, _pickerGmt.Hour, _pickerGmt.Minute, 0);
            if (comboBox1.SelectedIndex == 0)
                _cityInfo.SignGMT = "+";
            else if (comboBox1.SelectedIndex == 1)
                _cityInfo.SignGMT = "-";
            if (IsPopulationLong(populationTextBox.Text) == false)
            {
                MessageBox.Show("Население должно быть числом!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_pickerGmt.Hour > 12 || (_pickerGmt.Hour == 12 && _pickerGmt.Minute > 0))
            {
                MessageBox.Show("Значение часового пояса не может быть больше 12 часов.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else
            {
                _cityInfo.CityName = cityNameTextBox.Text;
                //_cityInfo.CountryID = (int)countryIDcomboBox.SelectedValue;
                _cityInfo.GMT = _gmt;
                _cityInfo.Population = Convert.ToInt64(populationTextBox.Text);
                int selectedCountryID;
                try
                {
                    selectedCountryID = (int)countryIDcomboBox.SelectedValue;
                }
                catch (NullReferenceException ex)
                {
                    flag = false;
                    MessageBox.Show(ex.Message + " Укажите правильно страну.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (flag == true)
                {
                    _cityInfo.CountryID = (int)countryIDcomboBox.SelectedValue;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        //check if population is long
        private bool IsPopulationLong(object pop)
        {
            try
            {
                Convert.ToUInt64(pop);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
