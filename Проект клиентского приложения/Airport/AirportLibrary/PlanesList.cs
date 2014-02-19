using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
	public class PlanesList : List <PlaneInfo>
	{
		public static PlanesList GetDefaultPlanesList()
		{
			PlanesList _plist = new PlanesList();
			Configs cfg = new Configs();
			SqlConnection cn = new SqlConnection();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectAirplaneList";
			try 
			{	        
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				while (dr.Read())
				{
					PlaneInfo _i = new PlaneInfo();
					_i.AircompanyID = (int)dr["idAircompany"];
					_i.AircompanyName = dr["AircompanyName"].ToString();
					_i.PlaneID = (int)dr["id"];
					_i.PlaneModel = dr["PlaneModel"].ToString();
					_i.PlaneNumber = dr["PlaneNumber"].ToString();
					_plist.Add(_i);
				}
			}
			catch (SqlException)
			{
				return null;
				throw;
			}
			return _plist;
		}

		public static PlanesList GetRefPlanesList()
		{
			SqlConnection cn = new SqlConnection();
			PlanesList pl = new PlanesList();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.connectionString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "SelectRefPlaneList";

			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				while (dr.Read())
				{
					PlaneInfo pi = new PlaneInfo();
					pi.PlaneID = (int)dr["id"];
					pi.PlaneNumber = dr["PlaneName"].ToString();
					pl.Add(pi);
				}
				return pl;
			}
			catch (SqlException)
			{
				return null;
			}
		}

	}
}
