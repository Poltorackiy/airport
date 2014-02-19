using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
	public class PlaneInfo
	{
		SqlException _e = null;
		int _id = 0;
		int _aircompanyID = 0;
		string _planeModel = "";
		string _planeNumber = "";
		string _aircompanyName = "";

		public int PlaneID
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

		public string PlaneNumber
		{
			get
			{
				return _planeNumber;
			}
			set
			{
				_planeNumber = value;
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

		public void GetPlane(int planeID)
		{
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "GetPlaneInfo";
			cm.Parameters.Add(new SqlParameter("PlaneID", planeID));
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				while (dr.Read())
				{
					_id = (int)dr["id"];
					_aircompanyID = (int)dr["idAircompany"];
					_planeModel = dr["PlaneModel"].ToString();
					_planeNumber = dr["PlaneNumber"].ToString();
				}
			}
			catch (SqlException ex)
			{
				_e = ex;
			}
		}

		public void UpdatePlane()
		{
			Configs cfg = new Configs();
			SqlConnection cn = new SqlConnection();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "UpdatePlane";
			cm.Parameters.Add(new SqlParameter("PlaneID", _id));
			cm.Parameters.Add(new SqlParameter("AircompanyID", _aircompanyID));
			cm.Parameters.Add(new SqlParameter("PlaneModel", _planeModel));
			cm.Parameters.Add(new SqlParameter("PlaneNumber", _planeNumber));
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

		public void InsertPlane()
		{
			Configs cfg = new Configs();
			SqlConnection cn = new SqlConnection();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "InsertPlane";
			cm.Parameters.Add(new SqlParameter("AircompanyID", _aircompanyID));
			cm.Parameters.Add(new SqlParameter("PlaneModel", _planeModel));
			cm.Parameters.Add(new SqlParameter("PlaneNumber", _planeNumber));
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

		public void DeletePlane()
		{
			Configs cfg = new Configs();
			SqlConnection cn = new SqlConnection();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "DeletePlane";
			cm.Parameters.Add(new SqlParameter("PlaneID", _id));
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
