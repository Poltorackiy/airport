using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
    public class AirPortList :List <AirPortInfo>
    {
        private static SqlException _e = null;

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

        public static AirPortList GetDefaultAirPortList()
        {
            AirPortList myAirPortList = new AirPortList();
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "SelectAirPortList";
            try
            {
                cn.Open();
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    AirPortInfo air = new AirPortInfo();
                    air.AirPortID = (int)dr["id"];
                    air.AirPortName = dr["AirPortName"].ToString();
                    air.CityName = dr["CityName"].ToString();
                    air.CountryName = dr["CountryName"].ToString();
                    myAirPortList.Add(air);
                }
            }
            catch (SqlException ex)
            {
                _e = ex;
            }

            return myAirPortList;
        }

		public static AirPortList GetRefAirportListByCity(int CityID)
		{
			AirPortList al = new AirPortList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectRefAirportListByCity";
			cm.Parameters.Add(new SqlParameter("idCity", CityID));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				while (dr.Read())
				{
					AirPortInfo ap = new AirPortInfo();
					ap.AirPortID = (int)dr["id"];
					ap.AirPortName = dr["Name"].ToString();
					al.Add(ap);
				}
				return al;
			}
			catch (SqlException)
			{
				return null;
			}
		}

    }
}
