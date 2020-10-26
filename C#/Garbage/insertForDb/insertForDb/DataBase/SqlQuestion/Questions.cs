using insertForDb.tablesClass;
using MySql.Data.MySqlClient;
using System;

using System.Threading.Tasks;

namespace insertForDb.DataBase.SqlQuestion
{
	class Questions
	{
		private MySqlConnection sqlConnection;
		MySqlCommand mySqlCommand;
		private HusbandsContract contract;
		
		
		object ob = new object();
		public Questions(MySqlConnection sqlConnection)
		{
			this.sqlConnection = sqlConnection;
			this.contract = new HusbandsContract();
			
		}

		public async void QuestionsCreatePeople(Husbands husbands)
		{
			try
			{
				if (sqlConnection != null)
				{
					string command = $"INSERT INTO husbands VALUE ({++husbands.id},'{husbands.name}','{husbands.surname}','{husbands.numperPhone}','{husbands.address}',NULL); "+
						$"INSERT INTO contract VALUES ({++contract.id},{husbands.id},'{DateTime.Now.Date.ToString().Split(" ")[0]}')";
					
				 	 await SendCommand(command);
					
					
					
				}
			}
			catch (Exception ex)
			{
				
				Console.WriteLine(ex.Message);
				
			}

		}

		public async void QuestionsCreatePeople(Clients clients)
		{
			try
			{
				if (sqlConnection != null)
				{
					string command = $"INSERT INTO clients VALUE ({++clients.id},'{clients.name}','{clients.surname}','{clients.numperPhone}','{clients.address}');";
						
					await SendCommand(command);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				
			}
		}
		public async void QyestionsCreateOrdering(Ordering ordering)
		{
			try
			{
				if (sqlConnection != null)
				{
					string command = $"INSERT INTO ordering VALUE ({++ordering.id},{ordering.husbandId},{ordering.clientId},{ordering.numberService})";

					await SendCommand(command);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

			}
		}

		public async Task QuestionCreateService()
		{
			try
			{
				for (int i = 1; i != 6; i++)
				{
					string command = $"INSERT INTO service(id) VALUE ({i});";
					await SendCommand(command);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				
			}
		}
		private async Task SendCommand(string command)
		{
			try
			{
				
				mySqlCommand = new MySqlCommand(command, sqlConnection);
				await mySqlCommand.ExecuteScalarAsync();
				

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			
			}
		}


	}
}
