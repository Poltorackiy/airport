using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
    public class AirPortInfo
    {
		private SqlException _e = null;
        private int _airPortID = 0;
        private int _cityID = 0;
        private string _airPortName = "";
        private string _cityName = "";
        private string _countryName = "";

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

        public int AirPortID
        {
            get
            {
                return _airPortID;
            }
            set
            {
                _airPortID = value;
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

        public string AirPortName
        {
            get
            {
                return _airPortName;
            }
            set
            {
                _airPortName = value;
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

		public void GetAirport(int AirportID)
		{
			Configs cfg = new Configs();
			SqlConnection cn = new SqlConnection();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "GetAirport";
			cm.Parameters.Add(new SqlParameter("AirportID", AirportID));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				while (dr.Read())
				{
					_airPortID = (int)dr["id"];
					_cityID = (int)dr["idCity"];
					_airPortName = dr["Name"].ToString();
				}
			}
			catch (SqlException ex)
			{
				_e = ex;
			}
		}

		public void DeleteAirport()
		{
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "DeleteAirport";
			cm.Parameters.Add(new SqlParameter("AirportID", _airPortID));
			try
			{
				cn.Open();
				cm.ExecuteNonQuery();
				cn.Close();
			}
			catch (SqlException ex)
			{
				_e = ex;
			}
		}

		public void UpdateAirport()
		{
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "UpdateAirport";
			cm.Parameters.Add(new SqlParameter("AirportID", _airPortID));
			cm.Parameters.Add(new SqlParameter("AirportName", _airPortName));
			cm.Parameters.Add(new SqlParameter("CityID", _cityID));
			try
			{
				cn.Open();
				cm.ExecuteNonQuery();
				cn.Close();
			}
			catch (SqlException ex)
			{
				_e = ex;
			}
		}

		public void InsertAirport()
		{
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "InsertAirport";
			cm.Parameters.Add(new SqlParameter("AirportName", _airPortName));
			cm.Parameters.Add(new SqlParameter("CityID", _cityID));
			try
			{
				cn.Open();
				cm.ExecuteNonQuery();
				cn.Close();
			}
			catch (SqlException ex)
			{
				_e = ex;
			}
		}

    }
}
