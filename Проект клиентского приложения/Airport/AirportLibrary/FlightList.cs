using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
	public class FlightList : List<FlightInfo>
	{
		public static FlightList GetAllFlights()
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}

		public static FlightList GetAllFlights(DateTime EndDate)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("EndDate", EndDate));
			cm.Parameters.Add(new SqlParameter("BeginDate", DateTime.Today));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}

		public static FlightList GetAllFlights(DateTime BeginDate, DateTime EndDate)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("BeginDate", BeginDate));
			cm.Parameters.Add(new SqlParameter("EndDate", EndDate));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}

			
		}

		//country
		public static FlightList GetAllFlights(int Country)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("idCountry", Country));

			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}

		public static FlightList GetAllFlights(int Country, DateTime EndDate)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("idCountry", Country));
			cm.Parameters.Add(new SqlParameter("EndDate", EndDate));
			cm.Parameters.Add(new SqlParameter("BeginDate", DateTime.Today));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}

		public static FlightList GetAllFlights(int Country, DateTime BeginDate, DateTime EndDate)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("idCountry", Country));
			cm.Parameters.Add(new SqlParameter("BeginDate", BeginDate));
			cm.Parameters.Add(new SqlParameter("EndDate", EndDate));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}

		//country and city
		public static FlightList GetAllFlights(int Country, int City)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("idCountry", Country));
			cm.Parameters.Add(new SqlParameter("idCity", City));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}

		public static FlightList GetAllFlights(int Country, int City, DateTime EndDate)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("idCountry", Country));
			cm.Parameters.Add(new SqlParameter("idCity", City));
			cm.Parameters.Add(new SqlParameter("EndDate", EndDate));
			cm.Parameters.Add(new SqlParameter("BeginDate", DateTime.Today));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}

		public static FlightList GetAllFlights(int Country, int City, DateTime BeginDate, DateTime EndDate)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("idCountry", Country));
			cm.Parameters.Add(new SqlParameter("idCity", City));
			cm.Parameters.Add(new SqlParameter("BeginDate", BeginDate));
			cm.Parameters.Add(new SqlParameter("EndDate", EndDate));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}


		//country, city and airport
		public static FlightList GetAllFlights(int Country, int City, int Airport)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("idCountry", Country));
			cm.Parameters.Add(new SqlParameter("idCity", City));
			cm.Parameters.Add(new SqlParameter("idAirport", Airport));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}

		public static FlightList GetAllFlights(int Country, int City, int Airport, DateTime EndDate)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("idCountry", Country));
			cm.Parameters.Add(new SqlParameter("idCity", City));
			cm.Parameters.Add(new SqlParameter("idAirport", Airport));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}

		public static FlightList GetAllFlights(int Country, int City, int Airport, DateTime BeginDate, DateTime EndDate)
		{
			FlightList flist = new FlightList();
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectFlights";
			cm.Parameters.Add(new SqlParameter("idCountry", Country));
			cm.Parameters.Add(new SqlParameter("idCity", City));
			cm.Parameters.Add(new SqlParameter("idAirport", Airport));
			cm.Parameters.Add(new SqlParameter("BeginDate", BeginDate));
			cm.Parameters.Add(new SqlParameter("EndDate", EndDate));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				flist = ReadFromSqlDataReader(dr);
				return flist;
			}
			catch (SqlException ex)
			{
				return null;
			}
		}


		public static FlightList ReadFromSqlDataReader(SqlDataReader dr)
		{
			FlightList _fl = new FlightList();
			while (dr.Read())
			{
				FlightInfo _f = new FlightInfo();
				_f.ID = (int)dr["ID"];
				_f.AircompanyID = (int)dr["idAircompany"];
				_f.PlaneID = (int)dr["idPlane"];
				_f.AirPortID = (int)dr["idAirPort"];
				_f.FlightType = dr["FlightType"].ToString();
				_f.DateTimeStart = (DateTime)dr["DateTimeStart"];
				_f.Duration = dr["Duration"].ToString();
				_f.DateTimeArrival = (DateTime)dr["DateTimeArrival"];
				_f.PriceEconom = (decimal)dr["PriceEconom"];
				_f.PriceBusiness = (decimal)dr["PriceBusiness"];
				_f.PriceFirst = (decimal)dr["PriceFirst"];
				_f.DateTimeStartGMT = (DateTime)dr["DateTimeStartGMT"];
				_f.DateTimeArrivalGMT = (DateTime)dr["DateTimeArrivalGMT"];
				_f.Status = dr["Status"].ToString();
				_f.AircompanyName = dr["AircompanyName"].ToString();
				_f.PlaneModel = dr["PlaneModel"].ToString();
				_f.AirportName = dr["AirPortName"].ToString();
				_f.CityName = dr["CityName"].ToString();
				_f.CountryName = dr["CountryName"].ToString();
				_fl.Add(_f);
			}
			return _fl;
		}



	}
}
