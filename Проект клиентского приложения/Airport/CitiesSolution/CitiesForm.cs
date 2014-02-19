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
    public partial class CitiesForm : Form
    {
        CitiesList _cList = new CitiesList();
        public CitiesForm()
        {
            InitializeComponent();
        }

        void RefreshItems()
        {
            _cList = CitiesList.GetDefaultCitiesList();
            citiesListDataGridView.DataSource = null;
            citiesListDataGridView.DataSource = _cList;

			if (Configs.HasUserAccess("CityInsert"))
				buttonAdd.Visible = true;
			else
				buttonAdd.Visible = false;

			if (Configs.HasUserAccess("GetCity"))
				buttonEdit.Visible = true;
			else
				buttonEdit.Visible = false;

			if (Configs.HasUserAccess("CityDelete"))
				buttonDelete.Visible = true;
			else
				buttonDelete.Visible = false;
        }

        private void CitiesForm_Load(object sender, EventArgs e)
        {
            RefreshItems();
            citiesListDataGridView.AutoResizeColumns();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            CityEditForm myform = new CityEditForm();
            int selectedRow = (int)citiesListDataGridView.SelectedRows[0].Cells[0].Value;
            CityInfo ci = new CityInfo();
            ci.GetCity(selectedRow);
            myform._cityInfo = ci;
            myform.Text += ci.CityName;
            if (myform.ShowDialog() == DialogResult.OK)
            {
                myform._cityInfo.UpdateCity();
                if (myform._cityInfo.e != null)
                {
                    MessageBox.Show(myform._cityInfo.e.Message, "Транзакция не выполнена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshItems();
            }
        }

        private void citiesListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CityEditForm myform = new CityEditForm();
            myform.Text += "Новый";
            if (myform.ShowDialog() == DialogResult.OK)
            {
                myform._cityInfo.InsertCity();
                if(myform._cityInfo.e != null)
                {
                    MessageBox.Show(myform._cityInfo.e.Message, "Город не добавлен!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RefreshItems();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтвердите удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (result == DialogResult.OK)
            {
                int _selectedRowID = (int)citiesListDataGridView.SelectedRows[0].Cells[0].Value;
                CityInfo city = new CityInfo();
                city.GetCity(_selectedRowID);
                city.DeleteCity();
                if (city.e != null)
                {
                    MessageBox.Show(city.e.Message, "Город не был удалён!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            RefreshItems();
        }
    }
}
