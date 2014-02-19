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
using AirCompaniesSolution;

namespace SheduleSolution
{
	public partial class EditFlightForm : Form
	{
		public FlightInfo FlightInfo = new FlightInfo();
		public enum Action { Insert, Update };
		public Action act;

		private bool _error = false;
		private bool _loaded = false;


		public EditFlightForm()
		{
			InitializeComponent();
		}

		private void EditFlightForm_Load(object sender, EventArgs e)
		{
			//для всех
			PlanesList _planesList = PlanesList.GetRefPlanesList();
			planecomboBox.DataSource = _planesList;
			planecomboBox.DisplayMember = "PlaneNumber";
			planecomboBox.ValueMember = "PlaneID";

			AirCompaniesList _aircompaniesList = AirCompaniesList.GetRefAircompaniesList();
			aircompanycomboBox.DataSource = _aircompaniesList;
			aircompanycomboBox.DisplayMember = "AirCompanyName";
			aircompanycomboBox.ValueMember = "AirCompanyID";

			if (act == Action.Insert)
			{
				//для вставки
				CountriesList _countriesList = CountriesList.GetRefCountriesList();
				countrycomboBox.DataSource = _countriesList;
				countrycomboBox.DisplayMember = "CountryName";
				countrycomboBox.ValueMember = "CountryID";

				int _selectedCountry = (int)countrycomboBox.SelectedValue;

				CitiesList _citiesList = CitiesList.GetCitiesListByCountry(_selectedCountry);
				citycomboBox.DataSource = _citiesList;
				citycomboBox.DisplayMember = "CityName";
				citycomboBox.ValueMember = "CityID";

				int _selectedCity = (int)citycomboBox.SelectedValue;

				AirPortList _airportList = AirPortList.GetRefAirportListByCity(_selectedCity);
				airportcomboBox.DataSource = _airportList;
				airportcomboBox.DisplayMember = "AirportName";
				airportcomboBox.ValueMember = "AirportID";

				flightTypecomboBox.SelectedIndex = 0;
				
			}

			if (act == Action.Update)
			{
				//для обновления
				try
				{
					aircompanycomboBox.SelectedValue = FlightInfo.AircompanyID;
					planecomboBox.SelectedValue = FlightInfo.PlaneID;

					AirPortInfo _apinfo = new AirPortInfo();
					_apinfo.GetAirport(FlightInfo.AirPortID);
					CityInfo _cityinfo = new CityInfo();
					_cityinfo.GetCity(_apinfo.CityID);

					CountriesList _countriesList = CountriesList.GetRefCountriesList();
					countrycomboBox.DataSource = _countriesList;
					countrycomboBox.DisplayMember = "CountryName";
					countrycomboBox.ValueMember = "CountryID";
					countrycomboBox.SelectedValue = _cityinfo.CountryID;

					CitiesList _citiesList = CitiesList.GetCitiesListByCountry(_cityinfo.CountryID);
					citycomboBox.DataSource = _citiesList;
					citycomboBox.DisplayMember = "CityName";
					citycomboBox.ValueMember = "CityID";
					citycomboBox.SelectedValue = _apinfo.CityID;

					AirPortList _airportList = AirPortList.GetRefAirportListByCity(_apinfo.CityID);
					airportcomboBox.DataSource = _airportList;
					airportcomboBox.DisplayMember = "AirportName";
					airportcomboBox.ValueMember = "AirportID";
					airportcomboBox.SelectedValue = _apinfo.AirPortID;

					if (FlightInfo.FlightType == "Входящий")
						flightTypecomboBox.SelectedIndex = 0;
					else if (FlightInfo.FlightType == "Исходящий")
						flightTypecomboBox.SelectedIndex = 1;

					startdateTimePicker.Value = FlightInfo.DateTimeStart;
					DateTime _tempDuration = Convert.ToDateTime("1900-01-01 " + FlightInfo.Duration);
					economnumericUpDown.Value = FlightInfo.PriceEconom;
					businessnumericUpDown.Value = FlightInfo.PriceBusiness;
					firstnumericUpDown.Value = FlightInfo.PriceFirst;

					numOfFlishgslabel.Visible = false;
					periodicitylabel.Visible = false;

					numOfFlightsnumericUpDown.Visible = false;
					periodicitydateTimePicker.Visible = false;

					if (Configs.HasUserAccess("UpdateFlight"))
						okButton.Visible = true;
					else
						okButton.Visible = false;

					//_loaded = true;
				}
				catch (Exception)
				{
					_error = true;
				}
			}
		}

		private void EditFlightForm_Shown(object sender, EventArgs e)
		{
			if (_error == true)
			{
				MessageBox.Show("Возникла непредвиденная ошибка, невозможно открыть данные.", "Oooppps!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
			_loaded = true;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (economnumericUpDown.Value < 1000 || businessnumericUpDown.Value < 1000 || firstnumericUpDown.Value < 1000)
			{
				MessageBox.Show("Невыгодно делать такую смешную цену на рейс.", "Как же я хочу спать!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				try
				{
					if ((int)airportcomboBox.SelectedValue == 1)
					{
						MessageBox.Show("Нельзя выбирать свой аэропорт.", "Как же я хочу спать!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else
					{
						FlightInfo.AircompanyID = (int)aircompanycomboBox.SelectedValue;
						FlightInfo.AirPortID = (int)airportcomboBox.SelectedValue;
						FlightInfo.PlaneID = (int)planecomboBox.SelectedValue;
						if (flightTypecomboBox.SelectedIndex == 0)
							FlightInfo.FlightType = "Входящий";
						else if (flightTypecomboBox.SelectedIndex == 1)
							FlightInfo.FlightType = "Исходящий";
						FlightInfo.DateTimeStart = startdateTimePicker.Value;
						FlightInfo.DateTimeStart.AddSeconds((-1) * FlightInfo.DateTimeStart.Second);
						string _tempDuration = "";
						if (durationdateTimePicker.Value.Hour < 10)
							_tempDuration += "0";
						_tempDuration += durationdateTimePicker.Value.Hour.ToString() + ":";
						_tempDuration += durationdateTimePicker.Value.Minute.ToString() + ":00";
						FlightInfo.NumOfFlights = (int)numOfFlightsnumericUpDown.Value;
						string _tempPeriodicity = "1900-01-";
						if (periodicitydateTimePicker.Value.Day < 10)
							_tempPeriodicity += "0";
						_tempPeriodicity += periodicitydateTimePicker.Value.Day.ToString() + " ";
						if (periodicitydateTimePicker.Value.Hour < 10)
							_tempPeriodicity += "0";
						_tempPeriodicity += periodicitydateTimePicker.Value.Hour.ToString() + ":";
						if (periodicitydateTimePicker.Value.Minute < 10)
							_tempPeriodicity += "0";
						_tempPeriodicity += periodicitydateTimePicker.Value.Minute.ToString() + ":00";
						FlightInfo.Periodicity = Convert.ToDateTime(_tempPeriodicity);
						FlightInfo.PriceEconom = economnumericUpDown.Value;
						FlightInfo.PriceBusiness = businessnumericUpDown.Value;
						FlightInfo.PriceFirst = firstnumericUpDown.Value;

						if (act == Action.Insert)
						{
							FlightInfo.InsertFlight();
						}
						else if (act == Action.Update)
						{
							FlightInfo.EditFlight();
						}
						if (FlightInfo.e == null)
						{
							this.DialogResult = System.Windows.Forms.DialogResult.OK;
						}
						else if (FlightInfo.e != null)
						{
							MessageBox.Show("Ошибка при добавлении или изменении рейса.", "Oooppps!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
				catch (Exception ex)
				{
					if (ex is NullReferenceException)
					{
						MessageBox.Show("Ошибка. Проверьте, все ли данные вы заполнили.", "Oooppps!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else if (ex is DataException)
					{
						MessageBox.Show("Ошибка в базе данных.", "Oooppps!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						MessageBox.Show("Неизвестная науке ошибка.", "Oooppps!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}//end of checks
		}

		private void countrycomboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (_loaded == true)
			{
				int _selectedCountry = (int)countrycomboBox.SelectedValue;

				CitiesList _citiesList = CitiesList.GetCitiesListByCountry(_selectedCountry);
				//citycomboBox.DataSource = null;
				citycomboBox.DataSource = _citiesList;
				citycomboBox.DisplayMember = "CityName";
				citycomboBox.ValueMember = "CityID";
			}
		}

		private void citycomboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (_loaded == true)
			{
				int _selectedCity = (int)citycomboBox.SelectedValue;

				AirPortList _airportList = AirPortList.GetRefAirportListByCity(_selectedCity);
				//airportcomboBox.DataSource = null;
				airportcomboBox.DataSource = _airportList;
				airportcomboBox.DisplayMember = "AirportName";
				airportcomboBox.ValueMember = "AirportID";
			}
		}

		
	}
}
