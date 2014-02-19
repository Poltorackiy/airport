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

namespace PlaneSolution
{
	public partial class PlanesForm : Form
	{
		public PlanesForm()
		{
			InitializeComponent();
		}

		private void PlanesForm_Load(object sender, EventArgs e)
		{
			RefreshItems();
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			RefreshItems();
		}

		void RefreshItems()
		{
			PlanesList _plist = PlanesList.GetDefaultPlanesList();
			if (_plist == null)
			{
				MessageBox.Show("Произошла ошибка при подключении к базе данных.", "Внутренняя ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			else
			{
				dataGridView1.DataSource = null;
				dataGridView1.DataSource = _plist;
				//dataGridView1.AllowUserToOrderColumns = true;
				if (_plist.Count == 0)
				{
					editButton.Visible = false;
					deleteButton.Visible = false;
				}
				else
				{
					editButton.Visible = true;
					deleteButton.Visible = true;

					if (Configs.HasUserAccess("GetPlaneInfo"))
						editButton.Visible = true;
					else
						editButton.Visible = false;

					if (Configs.HasUserAccess("DeletePlane"))
						deleteButton.Visible = true;
					else
						deleteButton.Visible = false;

				}
				if (Configs.HasUserAccess("InsertPlane"))
					addButton.Visible = true;
				else
					addButton.Visible = false;
			}

		}

		private void addButton_Click(object sender, EventArgs e)
		{
			PlaneEdit myForm = new PlaneEdit();
			myForm.act = PlaneEdit.Action.Insert;
			DialogResult result = myForm.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
				RefreshItems();
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			int _selectedID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
			PlaneEdit myForm = new PlaneEdit();
			myForm.act = PlaneEdit.Action.Update;
			myForm._plane.GetPlane(_selectedID);
			DialogResult result = myForm.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
				RefreshItems();
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			int _selectedID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
			DialogResult result = MessageBox.Show("Вы действительно хотите удалить данную запись о самолёте?", "Подтвердите удаление", MessageBoxButtons.OKCancel);
			PlaneInfo _plane = new PlaneInfo();
			_plane.PlaneID = _selectedID;
			_plane.DeletePlane();
			if (_plane.e != null)
			{
				string errormsg = "";
				if (_plane.e.Number == 547)
				{
					errormsg = "С данным самолётом связаны рейсы. Удалить невозможно";
				}
				else
				{
					errormsg = "Неизвестная ошибка, операция не завершена по неизвестной причине";
				}
				MessageBox.Show(errormsg, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show("Операция выполнена успешно", "Удаление завершено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				RefreshItems();
			}
		}




	}
}
