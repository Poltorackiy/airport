using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
	public class FlightInfo
	{
		SqlException _e = null;
		int _id = 0;
		int _aircompanyID = 0;
		int _planeID = 0;
		int _airPortID = 0;
		string _aircompanyName = "";
		string _planeModel = "";
		string _airportName = "";
		string _cityName = "";
		string _countryName = "";
		string _flightType = "";
		string _status = "";
		DateTime _dateTimeStart = Convert.ToDateTime("1900-01-01 00:00:00");
		string _duration = "00:00:00";
		DateTime _dateTimeArrival = Convert.ToDateTime("1900-01-01 00:00:00");
		DateTime _periodicity = Convert.ToDateTime("1900-01-01 00:00:00");
		int _numOfFlights = 0;
		decimal _priceEconom = 0.00m;
		decimal _priceBusiness = 0.00m;
		decimal _priceFirst = 0.00m;
		DateTime _filterBeginDate = Convert.ToDateTime("1900-01-01");
		DateTime _filterEndDate = Convert.ToDateTime("2050-01-01");
		DateTime _dateTimeStartGMT = Convert.ToDateTime("1900-01-01 00:00:00");
		DateTime _dateTimeArrivalGMT = Convert.ToDateTime("1900-01-01 00:00:00");

		public int ID
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
		public int AircompanyID
		{
			get
			{
				return _aircompanyID;
			}
			set
			{
				_aircompanyID = value;
			}
		}
		public int PlaneID
		{
			get
			{
				return _planeID;
			}
			set
			{
				_planeID = value;
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
		public string AircompanyName
		{
			get
			{
				return _aircompanyName;
			}
			set
			{
				_aircompanyName = value;
			}
		}
		public string PlaneModel
		{
			get
			{
				return _planeModel;
			}
			set
			{
				_planeModel = value;
			}
		}
		public string AirportName
		{
			get
			{
				return _airportName;
			}
			set
			{
				_airportName = value;
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
		public string FlightType
		{
			get
			{
				return _flightType;
			}
			set
			{
				_flightType = value;
			}
		}
		public string Status
		{
			get
			{
				return _status;
			}
			set
			{
				_status = value;
			}
		}
		public DateTime DateTimeStart
		{
			get
			{
				return _dateTimeStart;
			}
			set
			{
				_dateTimeStart = value;
			}
		}
		public string Duration
		{
			get
			{
				return _duration;
			}
			set
			{
				_duration = value;
			}
		}
		public DateTime DateTimeArrival
		{
			get
			{
				return _dateTimeArrival;
			}
			set
			{
				_dateTimeArrival = value;
			}
		}
		public DateTime Periodicity
		{
			get
			{
				return _periodicity;
			}
			set
			{
				_periodicity = value;
			}
		}
		public DateTime DateTimeStartGMT
		{
			get
			{
				return _dateTimeStartGMT;
			}
			set
			{
				_dateTimeStartGMT = value;
			}
		}
		public DateTime DateTimeArrivalGMT
		{
			get
			{
				return _dateTimeArrivalGMT;
			}
			set
			{
				_dateTimeArrivalGMT = value;
			}
		}
		public DateTime FilterBeginDate
		{
			get
			{
				return _filterBeginDate;
			}
			set
			{
				_filterBeginDate = value;
			}
		}
		public DateTime FilterEndDate
		{
			get
			{
				return _filterEndDate;
			}
			set
			{
				_filterEndDate = value;
			}
		}
		public decimal PriceEconom
		{
			get
			{
				return _priceEconom;
			}
			set
			{
				_priceEconom = value;
			}
		}
		public decimal PriceBusiness
		{
			get
			{
				return _priceBusiness;
			}
			set
			{
				_priceBusiness = value;
			}
		}
		public decimal PriceFirst
		{
			get
			{
				return _priceFirst;
			}
			set
			{
				_priceFirst = value;
			}
		}
		public SqlException e
		{
			get
			{
				return _e;
			}
		}
		public int NumOfFlights
		{
			get
			{
				return _numOfFlights;
			}
			set
			{
				_numOfFlights = value;
			}
		}

		public void GetFlightInfo(int FlightID)
		{
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "GetFlightInfo";
			cm.Parameters.Add(new SqlParameter("idFlight", FlightID));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				while (dr.Read())
				{
					_id = (int)dr["ID"];
					_aircompanyID = (int)dr["idAircompany"];
					_planeID = (int)dr["idPlane"];
					_airPortID = (int)dr["idAirPort"];
					_flightType = dr["FlightType"].ToString();
					_dateTimeStart = (DateTime)dr["DateTimeStart"];
					_duration = dr["Duration"].ToString();
					_dateTimeArrival = (DateTime)dr["DateTimeArrival"];
					_dateTimeStartGMT = (DateTime)dr["DateTimeStartGMT"];
					_dateTimeArrivalGMT = (DateTime)dr["DateTimeArrivalGMT"];
					_priceEconom = (decimal)dr["PriceEconom"];
					_priceBusiness = (decimal)dr["PriceBusiness"];
					_priceFirst = (decimal)dr["PriceFirst"];
					_status = dr["Status"].ToString();
				}
			}
			catch (SqlException ex)
			{
				_e = ex;
			}
		}

		public void InsertFlight()
		{
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "InsertFlight";
			DateTime _durationForInsert = Convert.ToDateTime("1900-01-01 " + _duration);
			cm.Parameters.Add(new SqlParameter("idAircompany", _aircompanyID));
			cm.Parameters.Add(new SqlParameter("idPlane", _planeID));
			cm.Parameters.Add(new SqlParameter("idAirPort", _airPortID));
			cm.Parameters.Add(new SqlParameter("FlightType", _flightType));
			cm.Parameters.Add(new SqlParameter("DateTimeStart", _dateTimeStart));
			cm.Parameters.Add(new SqlParameter("Duration", _duration));
			cm.Parameters.Add(new SqlParameter("NumOfFlights", _numOfFlights));
			cm.Parameters.Add(new SqlParameter("Periodicity", _periodicity));
			cm.Parameters.Add(new SqlParameter("PriceEconom", _priceEconom));
			cm.Parameters.Add(new SqlParameter("PriceBusiness", _priceBusiness));
			cm.Parameters.Add(new SqlParameter("PriceFirst", _priceFirst));
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

		public void EditFlight()
		{
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "UpdateFlight";
			DateTime _durationForUpdate = Convert.ToDateTime("1900-01-01 " + _duration);
			cm.Parameters.Add(new SqlParameter("idFlight", _id));
			cm.Parameters.Add(new SqlParameter("idAircompany", _aircompanyID));
			cm.Parameters.Add(new SqlParameter("idPlane", _planeID));
			cm.Parameters.Add(new SqlParameter("idAirPort", _airPortID));
			cm.Parameters.Add(new SqlParameter("FlightType", _flightType));
			cm.Parameters.Add(new SqlParameter("DateTimeStart", _dateTimeStart));
			cm.Parameters.Add(new SqlParameter("Duration", _duration));
			cm.Parameters.Add(new SqlParameter("PriceEconom", _priceEconom));
			cm.Parameters.Add(new SqlParameter("PriceBusiness", _priceBusiness));
			cm.Parameters.Add(new SqlParameter("PriceFirst", _priceFirst));
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

		public void DeleteFlight()
		{
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "DeleteFlight";
			cm.Parameters.Add(new SqlParameter("idFlight", _id));
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
