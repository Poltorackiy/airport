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

namespace SheduleSolution
{
	public partial class FlightListForm : Form
	{
		public FlightListForm()
		{
			InitializeComponent();
		}

		private void FlightListForm_Load(object sender, EventArgs e)
		{
			/*FlightListControl flControl = new FlightListControl();
			flControl.Location = new Point(0, 0);
			Size sz = new System.Drawing.Size();
			sz.Width = this.Width;
			sz.Height = this.Height;
			sz.Height = sz.Height - 100;
			flControl.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom);
			flControl.Size = sz;
			this.Controls.Add(flControl);*/

			if (Configs.HasUserAccess("GetFlightInfo"))
				editButton.Visible = true;
			else
				editButton.Visible = false;

			if (Configs.HasUserAccess("InsertFlight"))
				addButton.Visible = true;
			else
				addButton.Visible = false;

			if (Configs.HasUserAccess("DeleteFlight"))
				deleteButton.Visible = true;
			else
				deleteButton.Visible = false;

		}


		private void addButton_Click(object sender, EventArgs e)
		{
			EditFlightForm myForm = new EditFlightForm();
			myForm.act = EditFlightForm.Action.Insert;
			if (myForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				flightListControl1.ReloadFlightList();
			}
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			if (flightListControl1.SelectedFlight > 0)
			{
				EditFlightForm myForm = new EditFlightForm();
				myForm.act = EditFlightForm.Action.Update;
				myForm.FlightInfo.GetFlightInfo(flightListControl1.SelectedFlight);
				if (myForm.FlightInfo.e == null)
				{
					if (myForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
						flightListControl1.ReloadFlightList();
				}
				else if (myForm.FlightInfo.e != null)
				{
					MessageBox.Show("Невозможно отредактировать данную запись", "Ooooppps!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (flightListControl1.SelectedFlight == 0)
			{
				MessageBox.Show("Выберите рейс.", "Ooooppps!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (flightListControl1.SelectedFlight > 0)
			{
				FlightInfo fi = new FlightInfo();
				fi.ID = flightListControl1.SelectedFlight;
				DialogResult result = MessageBox.Show("Вы действительно хотите удалить данный рейс?", "Вы уверены?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if (result == System.Windows.Forms.DialogResult.OK)
				{
					fi.DeleteFlight();
					if (fi.e == null)
					{
						MessageBox.Show("Рейс успешно удалён!", "Какая удача", MessageBoxButtons.OK, MessageBoxIcon.Information);
						flightListControl1.ReloadFlightList();
					}
					else if (fi.e != null)
					{
						if (fi.e.Number == 547)
							MessageBox.Show("С выбранным рейсом связаны другие данные. Удаление невозможно.", "Печаль беда.", MessageBoxButtons.OK, MessageBoxIcon.Error);
						else
							MessageBox.Show("Неизвестная ошибка. Удаление невозможно.", "Печаль беда.", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else if (flightListControl1.SelectedFlight == 0)
			{
				MessageBox.Show("Выберите рейс.", "Ooooppps!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}




	}
}
