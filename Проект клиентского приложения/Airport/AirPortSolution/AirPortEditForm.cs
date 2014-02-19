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

namespace AirPortSolution
{
    public partial class AirPortEditForm : Form
    {
        public AirPortInfo _Airport = new AirPortInfo();
        public enum Action
        {
            insert, update
        }

        public AirPortEditForm()
        {
            InitializeComponent();
        }

        public Action act = new Action();

        private void AirPortEditForm_Load(object sender, EventArgs e)
        {
            CountriesList _countries = CountriesList.GetDefaultCountriesList();
            countryComboBox.DataSource = _countries;
            countryComboBox.DisplayMember = "CountryName";
            countryComboBox.ValueMember = "CountryID";

			//если количество стран равно нулю
			if (_countries.Count == 0)
			{
				DialogResult di = MessageBox.Show("Список стран пустой, операция невозможна. Обратитесь к администратору для решения данной проблемы.", "Операция невозможна", MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (di == System.Windows.Forms.DialogResult.OK)
				{
					this.Close();
				}
			}
				//Если есть страны
			else if (_countries.Count > 0)
			{
				/*int countryID = (int)countryComboBox.SelectedValue;
				CitiesList _cities = CitiesList.GetCitiesListByCountry(countryID);
				CityComboBox.DataSource = _cities;
				CityComboBox.DisplayMember = "CityName";
				CityComboBox.ValueMember = "CityID";
				*/

				//для вставки

				//для обновления
				if (act == Action.update)
				{
					//город и страна, в котором находится аэропорт
					CountryInfo _country = new CountryInfo();
					CityInfo _city = new CityInfo();
					_city.GetCity(_Airport.CityID);
					_country.GetCountry(_city.CountryID);
					int _selectedCountryID = _country.CountryID;
					int _selectedCityID = _city.CityID;

					//Заполняем комбобокс городами
					CitiesList _cities = CitiesList.GetCitiesListByCountry(_selectedCountryID);
					CityComboBox.DataSource = _cities;
					CityComboBox.DisplayMember = "CityName";
					CityComboBox.ValueMember = "CityID";


					countryComboBox.SelectedValue = _selectedCountryID;
					CityComboBox.SelectedValue = _selectedCityID;
					airPortNameTextBox.Text = _Airport.AirPortName;

					if (Configs.HasUserAccess("UpdateAirport"))
						OKbutton.Visible = true;
					else
						OKbutton.Visible = false;
				}
				else if (act == Action.insert)
				{

				}
			}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			CitiesList cl = CitiesList.GetCitiesListByCountry((int)countryComboBox.SelectedValue);
			CityComboBox.DataSource = cl;
			CityComboBox.DisplayMember = "CityName";
			CityComboBox.ValueMember = "CityID";
        }

		private void OKbutton_Click(object sender, EventArgs e)
		{
			CitiesList _cl = (CitiesList)CityComboBox.DataSource;
			if (_cl.Count == 0)
				MessageBox.Show("В указанной стране не содержится городов. Выберите другую страну.", "Не выбран город", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else if (_cl.Count != 0)
			{
				_Airport.AirPortName = airPortNameTextBox.Text;
				_Airport.CityID = (int)CityComboBox.SelectedValue;
				if (act == Action.update)
				{
					_Airport.UpdateAirport();
				}
				else if (act == Action.insert)
					_Airport.InsertAirport();
				if (_Airport.e != null)
				{
					MessageBox.Show("Внутренняя ошибка, данные не могут быть обновлены по неизвестной причине. При повторном появлении ошибки обратитесь к администратору.", "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					this.DialogResult = System.Windows.Forms.DialogResult.OK;
				}

			}
		}

    }
}
