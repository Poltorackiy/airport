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

namespace CountriesSolution
{
    public partial class CountriesForm : Form
    {
        CountriesList _cList = new CountriesList();

        public CountriesForm()
        {
            InitializeComponent();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshItems();
        }

        void RefreshItems()
        {
            _cList = CountriesList.GetDefaultCountriesList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _cList;

			if (Configs.HasUserAccess("CountryInsert"))
				buttonAdd.Visible = true;
			else
				buttonAdd.Visible = false;

			if (Configs.HasUserAccess("GetCountry"))
				buttonEdit.Visible = true;
			else
				buttonEdit.Visible = false;

			if (Configs.HasUserAccess("CountryDelete"))
				buttonDelete.Visible = true;
			else
				buttonDelete.Visible = false;
        }

        private void CountriesForm_Load(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CountriesEditForm newForm = new CountriesEditForm();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                newForm._cInfo.InsertNewCountry();
            }
            RefreshItems();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
			if (dataGridView1.SelectedRows != null)
			{
				int _countryID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

				CountriesEditForm newForm = new CountriesEditForm();
				foreach (CountryInfo cInfo in _cList)
				{
					if (cInfo.CountryID == _countryID)
					{
						cInfo.GetCountry(_countryID);
						newForm._cInfo = cInfo;
						if (newForm.ShowDialog() == DialogResult.OK)
						{
							newForm._cInfo.UpdateCountry();
						}
					}
				}
				RefreshItems();
			}
			else
			{
				MessageBox.Show("Элементы не выбраны или отсутствуют", "Элемент не выбран", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int _countryID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            foreach (CountryInfo cInfo in _cList)
            {
                if (cInfo.CountryID == _countryID)
                {
                    cInfo.GetCountry(_countryID);
                    cInfo.DeleteCountry();
                }
            }
            RefreshItems();
        }


    }
}
