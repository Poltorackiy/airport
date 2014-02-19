using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportLibrary
{
	public partial class FlightListControl : UserControl
	{
		public int SelectedFlight = 0;

		public void ReloadFlightList()
		{
			findButton_Click(findButton, new EventArgs());
		}

		public bool EventButtonVisible
		{
			get
			{
				return eventButton.Visible;
			}
			set
			{
				eventButton.Visible = value;
			}
		}

		public bool UnexEventButtonVisible
		{
			get
			{
				return unexEventButton.Visible;
			}
			set
			{
				unexEventButton.Visible = value;
			}
		}

		public bool PassengersButtonVisible
		{
			get
			{
				return passengersButton.Visible;
			}
			set
			{
				passengersButton.Visible = value;
			}
		}

		public bool BuyersButtonVisible
		{
			get
			{
				return buyersButton.Visible;
			}
			set
			{
				buyersButton.Visible = value;
			}
		}

		public FlightListControl()
		{
			InitializeComponent();
		}

		private void FlightListControl_Load(object sender, EventArgs e)
		{
			startDateTimePicker.Enabled = false;
			endDateTimePicker.Enabled = false;
			cityComboBox.Enabled = false;
			airportComboBox.Enabled = false;
			
			//adding countries to combobox
			addCountriesToComboBox();
			endDateTimePicker.Value = DateTime.Today.AddDays(5.0);
		}

		private void iWantToSelectBeginDateButton_CheckedChanged(object sender, EventArgs e)
		{
			if (iWantToSelectBeginDateButton.Checked == true)
			{
				startDateTimePicker.Enabled = true;
			}
			else if (iWantToSelectBeginDateButton.Checked == false)
			{
				startDateTimePicker.Enabled = false;
			}
		}

		private void iWantToSelectEndDateButton_CheckedChanged(object sender, EventArgs e)
		{
			if (iWantToSelectEndDateButton.Checked == true)
				endDateTimePicker.Enabled = true;
			else if (iWantToSelectEndDateButton.Checked == false)
				endDateTimePicker.Enabled = false;
		}

		private void addCountriesToComboBox()
		{
			CountriesList cl = CountriesList.GetRefCountriesList();
			CountryInfo youShouldSelectCountry = new CountryInfo();
			youShouldSelectCountry.CountryID = 0;
			youShouldSelectCountry.CountryName = "Выберите страну...";
			cl.Insert(0, youShouldSelectCountry);
			countryComboBox.DataSource = null;
			countryComboBox.DataSource = cl;
			countryComboBox.DisplayMember = "CountryName";
			countryComboBox.ValueMember = "CountryID";
		}

		private void addCitiesToComboBox(int CountryID)
		{
			CitiesList cl = CitiesList.GetCitiesListByCountry(CountryID);
			CityInfo ci = new CityInfo();
			ci.CityID = 0;
			ci.CityName = "Выберите город...";
			cl.Insert(0, ci);
			cityComboBox.DataSource = null;
			//cityComboBox.SelectedItem = null;
			//cityComboBox.Items.Clear();
			cityComboBox.DataSource = cl;
			cityComboBox.DisplayMember = "CityName";
			cityComboBox.ValueMember = "CityID";
		}

		private void addAirportsToComboBox(int CityID)
		{
			AirPortList apl = AirPortList.GetRefAirportListByCity(CityID);
			AirPortInfo apinfo = new AirPortInfo();
			apinfo.AirPortID = 0;
			apinfo.AirPortName = "Выберите аэропорт...";
			apl.Insert(0, apinfo);
			airportComboBox.DataSource = null;
			airportComboBox.DataSource = apl;
			airportComboBox.DisplayMember = "AirPortName";
			airportComboBox.ValueMember = "AirPortID";
		}

		private void countryComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			CountryInfo ci = (CountryInfo)countryComboBox.SelectedItem;
			if (ci.CountryID == 0)
			{
				cityComboBox.Enabled = false;
				airportComboBox.Enabled = false;
			}
			else
			{
				addCitiesToComboBox(ci.CountryID);
				cityComboBox.Enabled = true;
			}
		}

		private void cityComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cityComboBox.SelectedItem != null)
			{
				CityInfo ci = (CityInfo)cityComboBox.SelectedItem;
				if (ci.CityID == 0)
					airportComboBox.Enabled = false;
				else
				{
					addAirportsToComboBox(ci.CityID);
					airportComboBox.Enabled = true;
				}
			}
		}

		private void findButton_Click(object sender, EventArgs e)
		{
			//date filter
			DateTime startDate = Convert.ToDateTime("1900-01-01");
			DateTime endDate = DateTime.Today.AddYears(30);
			if (noBeginDateButton.Checked == true)
				startDate = Convert.ToDateTime("1900-01-01");
			else if (currentBeginDateButton.Checked == true)
				startDate = DateTime.Today;
			else if (iWantToSelectBeginDateButton.Checked == true)
			{
				startDate = startDateTimePicker.Value;
			}
			if (noEndDateButton.Checked == true)
				endDate = DateTime.Today.AddYears(30);
			else if (iWantToSelectEndDateButton.Checked == true)
			{
				endDate = endDateTimePicker.Value;
				endDate = endDate.AddHours(23);
				endDate = endDate.AddMinutes(59);
			}

			if (startDate > endDate)
				MessageBox.Show("Введённая дата начала не может быть больше конечной даты. Уточните пожалуйста условия поиска.", "Введите корректные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else	//if date is correct
			{
				//place filter
				int _countryID = 0;
				int _cityID = 0;
				int _airportID = 0;

				if (cityComboBox.Enabled == true)
					_cityID = Convert.ToInt32(cityComboBox.SelectedValue);
				if (airportComboBox.Enabled == true)
					_airportID = Convert.ToInt32(airportComboBox.SelectedValue);
				_countryID = Convert.ToInt32(countryComboBox.SelectedValue);

				//getting data
				FlightList fl = null;
				if (_countryID == 0 && _cityID == 0 && _airportID == 0)
				{
					fl = FlightList.GetAllFlights(startDate, endDate);
				}
				else if (_countryID != 0 && _cityID == 0 && _airportID == 0)
				{
					fl = FlightList.GetAllFlights(_countryID, startDate, endDate);
				}
				else if (_countryID != 0 && _cityID != 0 && _airportID == 0)
				{
					fl = FlightList.GetAllFlights(_countryID, _cityID, startDate, endDate);
				}
				else if (_countryID != 0 && _cityID != 0 && _airportID != 0)
				{
					fl = FlightList.GetAllFlights(_countryID, _cityID, _airportID, startDate, endDate);
				}


				//check if no errors
				if (fl == null)
					MessageBox.Show("Не удалось подключиться к базе данных.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else if (fl != null)
				{
					flightsDataGridView.DataSource = fl;
				}
			}//correct date

		}

		private void flightsDataGridView_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				SelectedFlight = (int)flightsDataGridView.SelectedRows[0].Cells[0].Value;
			}
			catch (Exception)
			{
				SelectedFlight = 0;
			}
		}


	}
}
