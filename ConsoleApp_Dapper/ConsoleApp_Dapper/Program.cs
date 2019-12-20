using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using Dapper;

namespace ConsoleApp_Dapper
{
	class Program
	{
		static void Main(string[] args)
		{
			var connectionString = "Server = {Your Server Name}; Database = {Your Database Name}; Integrated Security=True;";

			#region Create Table
			using (var connection = new SqlConnection(connectionString))
			{
				var query = "CREATE TABLE [dbo].[CUSTOMER]" +
										"(CustomerId UNIQUEIDENTIFIER," +
										"CustomerName NVARCHAR(50))";
				connection.Execute(query);
			}
			#endregion

			#region Insert Data

			using (var connection = new SqlConnection(connectionString))
			{
				var query = "INSERT INTO [dbo].[CUSTOMER] " +
										"(CustomerId, CustomerName) " +
										$"VALUES('{Guid.NewGuid()}', 'Suhas')";
				connection.Execute(query);
			}

			#endregion

			#region Read Data

			using (var connection = new SqlConnection(connectionString))
			{
				var query = "SELECT * FROM [dbo].[CUSTOMER]";
				var customer = new List<Customer>();
				customer = connection.Query<Customer>(query).ToList();
				connection.QueryMultiple(query);
			}

			#endregion

			//BenchmarkRunner.Run<BenchMarkDotNet>();
			Console.ReadLine();
		}
	}
}
