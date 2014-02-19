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
    public class AirCompaniesList : List<AirCompanyInfo>
    {
        public static AirCompaniesList GetDefaultAircompaniesList()
        {
            AirCompaniesList acList = new AirCompaniesList();

            Configs config = new Configs();
            string connectionString = config.connectionString;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AirCompanySelect";

            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                AirCompanyInfo newAirCompany = new AirCompanyInfo();//
                newAirCompany.AirCompanyID = Convert.ToInt32(dr["ID"]);
                newAirCompany.AirCompanyName = dr["AircompanyName"].ToString();
                newAirCompany.AirCompanyPhone = dr["AircompanyPhone"].ToString();
                newAirCompany.AirCompanyAddress = dr["AirCompanyAdress"].ToString();
                acList.Add(newAirCompany);
            }
            connection.Close();
            connection.Dispose();
            return acList;
        }

		public static AirCompaniesList GetRefAircompaniesList()
		{
			AirCompaniesList acList = new AirCompaniesList();

			Configs config = new Configs();
			string connectionString = config.connectionString;
			SqlConnection connection = new SqlConnection();
			connection.ConnectionString = connectionString;
			connection.Open();

			SqlCommand command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "SelectRefAircompaniesList";

			SqlDataReader dr = command.ExecuteReader();

			while (dr.Read())
			{
				AirCompanyInfo newAirCompany = new AirCompanyInfo();//
				newAirCompany.AirCompanyID = Convert.ToInt32(dr["ID"]);
				newAirCompany.AirCompanyName = dr["AircompanyName"].ToString();
				acList.Add(newAirCompany);
			}
			connection.Close();
			connection.Dispose();
			return acList;
		}

    }
}
