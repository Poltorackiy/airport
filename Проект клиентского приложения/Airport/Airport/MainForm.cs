using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirCompaniesSolution;
using CountriesSolution;
using CitiesSolution;
using AirPortSolution;
using PlaneSolution;
using SheduleSolution;
using AirportLibrary;

namespace Airport
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void aircompaniesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AirCompaniesForm aircompaniesForm = new AirCompaniesForm();
            aircompaniesForm.MdiParent = this;
            aircompaniesForm.Show();
        }

        private void countriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountriesForm countriesForm = new CountriesForm();
            countriesForm.MdiParent = this;
            countriesForm.Show();
        }

        private void citiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CitiesForm cityForm = new CitiesForm();
            cityForm.MdiParent = this;
            cityForm.Show();
        }

        private void airportsViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AirPortsForm airportsForm = new AirPortsForm();
            airportsForm.MdiParent = this;
            airportsForm.WindowState = FormWindowState.Maximized;
            airportsForm.Show();

		}

		private void planesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlanesForm planesForm = new PlanesForm();
			planesForm.MdiParent = this;
			planesForm.WindowState = FormWindowState.Maximized;
			planesForm.Show();
		}

		private void sheduleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FlightListForm sheduleForm = new FlightListForm();
			sheduleForm.MdiParent = this;
			sheduleForm.WindowState = FormWindowState.Maximized;
			sheduleForm.Show();
		}

		private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoginForm myForm = new LoginForm();
			if (myForm.ShowDialog() == DialogResult.OK)
			{
				CheckAccess();
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Configs cfg = new Configs();
			if (cfg.TryToConnect(false) == true)
			{
				CheckAccess();
			}
			else
			{
				LockAccess();
				LoginToolStripMenuItem_Click(this.LoginToolStripMenuItem, new EventArgs());
			}
		}

		private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Configs cfg = new Configs();
			cfg.IntegratedSecurity = false;
			cfg.Login = "";
			cfg.Password = "";
			MessageBox.Show("До скорых встреч!", "До встречи", MessageBoxButtons.OK, MessageBoxIcon.Information);
			LockAccess();
			Configs.ForgetSettings();
		}

		private void CheckAccess()
		{
			LockAccess();
			//editToolStripMenuItem.Visible = true;
			logoutToolStripMenuItem.Visible = true;
			LoginToolStripMenuItem.Visible = false;

			//страны
			if (Configs.HasUserAccess("CountriesSelect"))
			{
				dataToolStripMenuItem.Visible = true;
				airportsToolStripMenuItem.Visible = true;
				countriesToolStripMenuItem.Visible = true;
			}

			//города
			if (Configs.HasUserAccess("SelectCitiesList"))
			{
				dataToolStripMenuItem.Visible = true;
				airportsToolStripMenuItem.Visible = true;
				citiesToolStripMenuItem.Visible = true;
			}

			//аэропорты
			if (Configs.HasUserAccess("SelectAirPortList"))
			{
				dataToolStripMenuItem.Visible = true;
				airportsToolStripMenuItem.Visible = true;
				airportsViewToolStripMenuItem.Visible = true;
			}

			//авиакомпании
			if (Configs.HasUserAccess("AirCompanySelect"))
			{
				dataToolStripMenuItem.Visible = true;
				aircompaniesToolStripMenuItem.Visible = true;
				aircompaniesOpenToolStripMenuItem.Visible = true;
			}

			//самолёты
			if (Configs.HasUserAccess("SelectAirplaneList"))
			{
				dataToolStripMenuItem.Visible = true;
				aircompaniesToolStripMenuItem.Visible = true;
				planesToolStripMenuItem.Visible = true;
			}

			//расписание
			if (Configs.HasUserAccess("SelectFlights"))
			{
				sheduleToolStripMenuItem.Visible = true;
			}


		}

		private void LockAccess()
		{
			editToolStripMenuItem.Visible = false;
			dataToolStripMenuItem.Visible = false;
			sheduleToolStripMenuItem.Visible = false;
			logoutToolStripMenuItem.Visible = false;
			LoginToolStripMenuItem.Visible = true;
			countriesToolStripMenuItem.Visible = false;
			citiesToolStripMenuItem.Visible = false;
			airportsViewToolStripMenuItem.Visible = false;
			airportsToolStripMenuItem.Visible = false;
			aircompaniesToolStripMenuItem.Visible = false;
			aircompaniesOpenToolStripMenuItem.Visible = false;
			planesToolStripMenuItem.Visible = false;
			for (int i = 0; i < this.MdiChildren.Length; i++)
			{
				this.MdiChildren[i].Close();
			}
		}


    }
}
