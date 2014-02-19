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
using System.Data;

namespace AirPortSolution
{
    public partial class AirPortsForm : Form
    {
        AirPortList _myAirPortList = new AirPortList();
        public AirPortsForm()
        {
            InitializeComponent();
        }

        private void AirPortsForm_Load(object sender, EventArgs e)
        {
            RefreshItems();
			
        }

        private void RefreshItems()
        {
            _myAirPortList = AirPortList.GetDefaultAirPortList();
            airPortListDataGridView.DataSource = null;
            airPortListDataGridView.DataSource = _myAirPortList;
			if (_myAirPortList.Count == 0)
			{
				EditButton.Visible = false;
				deleteButton.Visible = false;
			}
			else if (_myAirPortList.Count > 0)
			{
				EditButton.Visible = true;
				deleteButton.Visible = true;
				
				if (Configs.HasUserAccess("GetAirport"))
					EditButton.Visible = true;
				else
					EditButton.Visible = false;

				if (Configs.HasUserAccess("DeleteAirport"))
					deleteButton.Visible = true;
				else
					deleteButton.Visible = false;
			}

			if (Configs.HasUserAccess("InsertAirport"))
				addButton.Visible = true;
			else
				addButton.Visible = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int selectedID = (int)airPortListDataGridView.SelectedRows[0].Cells[0].Value;
            AirPortEditForm myForm = new AirPortEditForm();
            myForm.act = AirPortEditForm.Action.update;
            myForm._Airport.GetAirport(selectedID);
            DialogResult result = myForm.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
				RefreshItems();
        }

		private void deleteButton_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Вы действительно хотите удалить данный аэропорт?", "Подтвердите удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
			if (dr == System.Windows.Forms.DialogResult.OK)
			{
				int selectedID = (int)airPortListDataGridView.SelectedRows[0].Cells[0].Value;
				AirPortInfo _airport = new AirPortInfo();
				_airport.AirPortID = selectedID;
				_airport.DeleteAirport();
				if (_airport.e != null)
				{
					//547
					if (_airport.e.Number == 547)
					{
						MessageBox.Show("Не могу удалить аэропорт. C выбранным аэропортом связаны другие данные.", "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						MessageBox.Show("Неизвестная ошибка, возможно сервер недоступен. Обратитесь к администратору.", "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				RefreshItems();
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			AirPortEditForm myForm = new AirPortEditForm();
			myForm.act = AirPortEditForm.Action.insert;
			DialogResult result = myForm.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
				RefreshItems();
		}



    }
}
