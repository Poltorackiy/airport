using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
    public class CountriesList : List <CountryInfo>
    {
        public static CountriesList GetDefaultCountriesList()
        {
            CountriesList cList = new CountriesList();

            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;
            cn.Open();

            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "CountriesSelect";

            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                CountryInfo cInfo = new CountryInfo();
                cInfo.CountryID = Convert.ToInt32(dr["ID"]);
                cInfo.CountryName = dr["name"].ToString();
                cList.Add(cInfo);
            }

            cn.Close();
            cn.Dispose();
            return cList;
        }

		public static CountriesList GetRefCountriesList()
		{
			CountriesList cl = new CountriesList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "RefCountriesSelect";
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				while (dr.Read())
				{
					CountryInfo ci = new CountryInfo();
					ci.CountryID = (int)dr["ID"];
					ci.CountryName = dr["NAME"].ToString();
					cl.Add(ci);
				}
				return cl;
			}
			catch (SqlException)
			{
				return null;
			}
		}


    }
}
