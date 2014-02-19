using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AirportLibrary;

namespace AirCompaniesSolution
{
    public class AirCompanyInfo
    {
        private string _connectionString = "";

        private int _airCompanyID = 0;
        private string _airCompanyName = "";
        private string _airCompanyPhone = "";
        private string _airCompanyAddress = "";

        public int AirCompanyID
        {
            get
            {
                return _airCompanyID;
            }
            set
            {
                _airCompanyID = value;
            }
        }

        public string AirCompanyName
        {
            get
            {
                return _airCompanyName;
            }
            set
            {
                _airCompanyName = value;
            }
        }

        public string AirCompanyPhone
        {
            get
            {
                return _airCompanyPhone;
            }
            set
            {
                _airCompanyPhone = value;
            }
        }

        public string AirCompanyAddress
        {
            get
            {
                return _airCompanyAddress;
            }
            set
            {
                _airCompanyAddress = value;
            }
        }

        private string ConnectionString
        {
            get
            {
                Configs c = new Configs();
                return c.connectionString;
            }
        }

        public void InsertNewAircompany()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = this.ConnectionString;
            cn.Open();

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "AircompanyInsert";

            cm.Parameters.Add(new SqlParameter("@name", _airCompanyName));
            cm.Parameters.Add(new SqlParameter("@phone", _airCompanyPhone));
            cm.Parameters.Add(new SqlParameter("@address", _airCompanyAddress));

            cm.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public void UpdateAircompany()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = this.ConnectionString;
            cn.Open();

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "AircompanyUpdate";

            cm.Parameters.Add(new SqlParameter("@name", _airCompanyName));
            cm.Parameters.Add(new SqlParameter("@phone", _airCompanyPhone));
            cm.Parameters.Add(new SqlParameter("@address", _airCompanyAddress));
            cm.Parameters.Add(new SqlParameter("@id", _airCompanyID));

            cm.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public void DeleteAircompany()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = this.ConnectionString;
            cn.Open();

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "AircompanyDelete";

            cm.Parameters.Add(new SqlParameter("@id", _airCompanyID));

            cm.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

    }
}
