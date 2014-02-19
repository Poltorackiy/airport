using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
    public class CountryInfo
    {
        private int _id = 0;
        private string _countryName = "";

        public int CountryID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string CountryName
        {
            get
            {
                return _countryName;
            }
            set
            {
                _countryName = value;
            }
        }

        public void InsertNewCountry()
        {
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;
            cn.Open();

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "CountryInsert";

            cm.Parameters.Add(new SqlParameter("@name", _countryName));

            cm.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }

        public void UpdateCountry()
        {
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;
            cn.Open();

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "CountryUpdate";

            cm.Parameters.Add(new SqlParameter("@name", _countryName));
            cm.Parameters.Add(new SqlParameter("@id", _id));

            cm.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }

        public void DeleteCountry()
        {
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;
            //cn.Open();

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "CountryDelete";

            cm.Parameters.Add(new SqlParameter("@id", _id));

			try
			{
				cn.Open();
				cm.ExecuteNonQuery();
				cn.Close();
				cn.Dispose();
			}
			catch (Exception)
			{
			}
            

            
        }

        public void GetCountry(int countryID)
        {
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;
            cn.Open();

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "GetCountry";

            cm.Parameters.Add(new SqlParameter("@id", countryID));
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                _id = (int)dr["id"];
                _countryName = dr["name"].ToString();
            }

            cn.Close();
            cn.Dispose();
        }
    }
}
