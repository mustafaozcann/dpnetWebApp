using System;
using Microsoft.Extensions.Configuration;
using dpNetWebApp.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace dpNetWebApp
{
	public class MySQLRepository
	{
		private string _connectionString { get; set;}

		public MySQLRepository()
		{
			IConfiguration configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables()
				.Build();

			_connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

		}

		public PatternModel Read(int patternId)
		{

            string patternName = "";
            string whichProblemSolution= "";
            string content = "";
            byte[] codeExample = {123};
            byte[] umlDiagram = {123};


            using (MySqlConnection connection = new MySqlConnection(_connectionString))
			{
               


                try
				{
                    connection.Open();

                    string sql = "Select * from Patterns Where PatternID=@ID";
					MySqlCommand command = new MySqlCommand(sql, connection);
					command.Parameters.Add("@ID", MySql.Data.MySqlClient.MySqlDbType.Int64).Value = patternId;
					
					
					

					using(var reader = command.ExecuteReader())
					{

						while (reader.Read())
						{

							Console.WriteLine("girdim");

							patternName = reader["PatternName"].ToString();
							whichProblemSolution = reader["WhichProblemSolution"].ToString();
							content = "";
							codeExample = (byte[])reader["CodeExample"];
                            umlDiagram = (byte[])reader["UmlDiagram"];

                        }
                    }


					command.Dispose();


				}
				catch(MySqlException ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
					Console.WriteLine(ex.Message);
				}


			}


            return new PatternModel(patternName, whichProblemSolution, content, codeExample, umlDiagram);





		}
	}
}

