using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
    public class CitiesList : List <CityInfo>
    {
        public static CitiesList GetDefaultCitiesList()
        {
            CitiesList cList = new CitiesList();
            Configs config = new Configs();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = config.connectionString;
            cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "SelectCitiesList";
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                CityInfo info = new CityInfo();
                info.CityID = Convert.ToInt32(dr["id"]);
                info.CountryID = (int)dr["countryID"];
                info.CityName = dr["CityName"].ToString();
                info.SignGMT = dr["SignGMT"].ToString();
                info.GMT = Convert.ToDateTime(dr["CityGMT"]);

                cList.Add(info);
            }
            cn.Close();
            cn.Dispose();
            return cList;
        }

        public static CitiesList GetCitiesListByCountry(int countryID)
        {
            CitiesList cl = new CitiesList();
            Configs cfg = new Configs();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cfg.connectionString;
            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "RefSelectCitiesListByID";
            cm.Parameters.Add(new SqlParameter("CountryID", countryID));

            try
            {
                cn.Open();
                SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    CityInfo qq = new CityInfo();
                    qq.CityID = (int)dr["id"];
                    qq.CityName = dr["Name"].ToString();
                    cl.Add(qq);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return cl;
        }

    }
}
