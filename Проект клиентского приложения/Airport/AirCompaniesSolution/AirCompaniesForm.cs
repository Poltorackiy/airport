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

namespace AirCompaniesSolution
{
    public partial class AirCompaniesForm : Form
    {
        AirCompaniesList _acList = new AirCompaniesList();
        public AirCompaniesForm()
        {
            InitializeComponent();
        }

        void RefreshItems()
        {
            _acList = AirCompaniesList.GetDefaultAircompaniesList();
            airCompaniesListBindingSource.DataSource = null;
            airCompaniesListBindingSource.DataSource = _acList;
			if (Configs.HasUserAccess("AirCompanyInsert"))
				buttonAdd.Visible = true;
			else
				buttonAdd.Visible = false;
			if (Configs.HasUserAccess("AirCompanyDelete"))
				buttonDelete.Visible = true;
			else
				buttonDelete.Visible = false;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            this.RefreshItems();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AirCompaniesEditForm newForm = new AirCompaniesEditForm();

            if (newForm.ShowDialog() == DialogResult.OK)
            {
                newForm._newAirCompanyInfo.InsertNewAircompany();
            }
            this.RefreshItems();
        }

        private void AirCompaniesForm_Load(object sender, EventArgs e)
        {
            this.RefreshItems();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int airCompID = (int)airCompaniesListDataGridView.SelectedRows[0].Cells[0].Value;

            AirCompaniesEditForm newForm = new AirCompaniesEditForm();
            foreach (AirCompanyInfo airCompany in _acList)
            {
                if (airCompany.AirCompanyID == airCompID)
                {
                    newForm._newAirCompanyInfo = airCompany;
                    if (newForm.ShowDialog() == DialogResult.OK)
                    {
                        newForm._newAirCompanyInfo.UpdateAircompany();
                    }
                }
            }
            this.RefreshItems();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int airCompID = (int)airCompaniesListDataGridView.SelectedRows[0].Cells[0].Value;

            foreach (AirCompanyInfo airCompany in _acList)
            {
                if (airCompany.AirCompanyID == airCompID)
                {
                    airCompany.DeleteAircompany();
                }
            }
            this.RefreshItems();
        }
    }
}
