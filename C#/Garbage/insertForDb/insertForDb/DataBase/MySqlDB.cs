using System;

using insertForDb.DataBase.SqlQuestion;
using MySql.Data.MySqlClient;

namespace insertForDb.DataBase
{
	class MySqlDB
	{

		#region Singleton
		static MySqlDB sql;
		private MySqlDB() { }
		
		public static MySqlDB GetConnectDB()
		{
			if(sql == null)
			{
				sql = new MySqlDB();
				sql.Connect();
			}
			return sql;
		}
		#endregion

		private MySqlConnection Connection;
		public Questions questions;
		private async void Connect()
		{
			if (Connection == null)
			{
				string connStr = "server=localhost;user=root;database=pc7;password=root;";

				Connection = new MySqlConnection(connStr);
				await Connection.OpenAsync();
				questions = new Questions(Connection);
				return;
			}
			throw new Exception("DB already exists");
		}

		public async void DestroyConnect()
		{
			if (Connection != null)
				await Connection.CloseAsync();
			if (questions != null)
				questions = null;
			if (sql != null)
				sql = null;
		}
		

	}
}
