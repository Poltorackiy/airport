using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirportLibrary
{
    public class Configs
    {
        //public string connectionString = @"Data Source=konstantin\konstantinsql; Initial Catalog=Airport; Integrated Security=True";

		public string connectionString
		{
			get
			{
				SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
				str.DataSource = @"konstantin\konstantinsql";
				str.InitialCatalog = "Airport";
				str.IntegratedSecurity = UserSettings.Default.IntegratedSecurity;
				str.UserID = UserSettings.Default.Login;
				str.Password = UserSettings.Default.Password;
				return str.ToString();
			}
		}

		bool _integrSec = false;
		string _login = "";
		string _pass = "";
		string _error = "";

		public bool IntegratedSecurity
		{
			get
			{
				return UserSettings.Default.IntegratedSecurity;
			}
			set
			{
				_integrSec = value;
				UserSettings.Default.IntegratedSecurity = value;
			}
		}

		public string Login
		{
			get
			{
				return UserSettings.Default.Login;
			}
			set
			{
				_login = value;
				UserSettings.Default.Login = value;
				
			}
		}

		public string Password
		{
			get
			{
				return UserSettings.Default.Password;
			}
			set
			{
				UserSettings.Default.Password = value;
			}
		}

		public string ErrorString
		{
			get
			{
				return _error;
			}
		}

		public string ConnectString
		{
			get
			{
				SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
				str.DataSource = UserSettings.Default.ServerName + @"\" + UserSettings.Default.DBEngineName;
				str.InitialCatalog = "Airport";
				str.IntegratedSecurity = UserSettings.Default.IntegratedSecurity;
				str.UserID = UserSettings.Default.Login;
				str.Password = UserSettings.Default.Password;
				return str.ToString();
			}
		}

		public bool TryToConnect(bool Remember)
		{
			bool _connectionState = false;
			SqlConnection cn = new SqlConnection();
			cn.ConnectionString = this.ConnectString;
			try
			{
				cn.Open();
				cn.Close();
				_connectionState = true;
				if (Remember == true)
					UserSettings.Default.Save();//(!!!)
			}
			catch (SqlException ex)
			{
				_error = "#: " + ex.Number + " Сообщение: " + ex.Message;
				_connectionState = false;
			}

			return _connectionState;
		}

		public static bool HasUserAccess(string StoredProcedureName)
		{
			SqlConnection cn = new SqlConnection();
			Configs cfg = new Configs();
			cn.ConnectionString = cfg.ConnectString;
			SqlCommand cm = cn.CreateCommand();
			cm.CommandText = "SELECT * FROM sys.procedures WHERE name NOT LIKE 'sp_%' AND name = '" + StoredProcedureName + "';";
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
				if (dr.HasRows)
					return true;
				else
					return false;
			}
			catch (SqlException)
			{
				return false;
			}
		}

		public static void ForgetSettings()
		{
			UserSettings.Default.Reset();
		}

    }
}
