using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AirportLibrary
{
    public class CityInfo
    {
        private SqlException _e = null;
        private int _cityID = 0;
        private int _countryID = 0;
        private string _cityName = "";
        private string _countryName = "";
        private long _population = 0;
        private string _signGMT = "+";
        private DateTime _gmt = new DateTime(1900, 1, 1);
        private string _stringGMT = "";

        public SqlException e
        {
            get
            {
                return _e;
            }
            set
            {
                _e = value;
            }
        }

        public int CityID
        {
            get
            {
                return _cityID;
            }
            set
            {
                _cityID = value;
            }
        }

        public int CountryID
        {
            get
            {
                return _countryID;
            }
            set
            {
                _countryID = value;
            }
        }

        public string CityName
        {
            get
            {
                return _cityName;
            }
            set
            {
                _cityName = value;
            }
        }
        //Извлекать ли страну из этой же процедуры или можно отдельную
        public string CountryName
        {
            get
            {
                CountryInfo country = new CountryInfo();
                country.GetCountry(_countryID);
                return country.CountryName;
            }
        }

        public long Population
        {
            get
            {
                return _population;
            }
            set
            {
                _population = value;
            }
        }

        public string SignGMT
        {
            get
            {
                return _signGMT;
            }
            set
            {
                _signGMT = value;
            }
        }

        public DateTime GMT
        {
            get
            {
                return _gmt;
            }
            set
            {
                _gmt = value;
            }
        }

        public string StringGMT
        {
            get
            {
                return _signGMT + GMT.ToString("HH:mm");
            }
        }


        public void InsertCity()
        {
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;
            //cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "CityInsert";
            cm.Parameters.Add(new SqlParameter("@CountryID", _countryID));
            cm.Parameters.Add(new SqlParameter("@CityName", _cityName));
            cm.Parameters.Add(new SqlParameter("@Population", _population));
            cm.Parameters.Add(new SqlParameter("@GMT", _gmt));
            cm.Parameters.Add(new SqlParameter("@SignGMT", _signGMT));
            try
            { 
                cn.Open();
                cm.ExecuteNonQuery(); 
            }
            catch (SqlException e)
            {
                _e = e;
            }
            cn.Close();
            cn.Dispose();
        }

        public void UpdateCity()
        {
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;
            
            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "CityUpdate";
            cm.Parameters.Add(new SqlParameter("@CityID", _cityID));
            cm.Parameters.Add(new SqlParameter("@CountryID", _countryID));
            cm.Parameters.Add(new SqlParameter("@CityName", _cityName));
            cm.Parameters.Add(new SqlParameter("@Population", _population));
            cm.Parameters.Add(new SqlParameter("@GMT", _gmt));
            cm.Parameters.Add(new SqlParameter("@SignGMT", _signGMT));

            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                _e = e;
            }
            cn.Close();
            cn.Dispose();
        }
        public void GetCity(int cityID)
        {
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;
            cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "GetCity";
            cm.Parameters.Add(new SqlParameter("@CityID", cityID));
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                _cityID = (int)dr["ID"];
                _cityName = dr["Name"].ToString();
                _countryID = (int)dr["idcountry"];
                _gmt = (DateTime)dr["GMT"];
                _signGMT = dr["SignGMT"].ToString();
                _population = (long)dr["Population"];
            }
            cn.Close();
            cn.Dispose();
        }

        public void DeleteCity()
        {
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "CityDelete";
            cm.Parameters.Add(new SqlParameter("@CityID", _cityID));
            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                _e = e;
            }
            cn.Close();
            cn.Dispose();
        }
    }
}
