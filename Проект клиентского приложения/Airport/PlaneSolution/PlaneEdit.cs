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
using System.Data.SqlClient;
using AirCompaniesSolution;

namespace PlaneSolution
{
	public partial class PlaneEdit : Form
	{
		public PlaneEdit()
		{
			InitializeComponent();
		}

		public enum Action
		{
			Insert, Update
		}

		public PlaneInfo _plane = new PlaneInfo();

		public Action act;

		private void PlaneEdit_Load(object sender, EventArgs e)
		{
			AirCompaniesList _aclist = AirCompaniesList.GetRefAircompaniesList();
			if (_aclist.Count == 0)
			{
				MessageBox.Show("Ни одной авиакомпании не найдено. Добавьте их или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
			else
			{
				airCompanycomboBox.DataSource = _aclist;
				airCompanycomboBox.DisplayMember = "AirCompanyName";
				airCompanycomboBox.ValueMember = "AirCompanyID";
				planeNumberTextbox.Text = _plane.PlaneNumber;
				modeltextBox.Text = _plane.PlaneModel;
				if (act == Action.Update)
				{
					airCompanycomboBox.SelectedValue = _plane.AircompanyID;
					if (Configs.HasUserAccess("UpdatePlane"))
						OKbutton.Visible = true;
					else
						OKbutton.Visible = false;
				}
			}
		}

		private void OKbutton_Click(object sender, EventArgs e)
		{
			_plane.AircompanyID = (int)airCompanycomboBox.SelectedValue;
			_plane.PlaneModel = modeltextBox.Text;
			_plane.PlaneNumber = planeNumberTextbox.Text;
			if (act == Action.Insert)
			{
				_plane.InsertPlane();
			}
			else if (act == Action.Update)
			{
				_plane.UpdatePlane();
			}

			if (_plane.e != null)
			{
				MessageBox.Show("Невозможно добавить или обновить информацию о самолёте.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				_plane.e = null;
			}
			else
			{
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}


		}
	}
}
