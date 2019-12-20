using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp_Dapper
{
	public class BenchMarkDotNet
	{
		[Benchmark]
		public void ExecuteSqlUsingDapper()
		{
			var connectionString = "Server = localhost; Database = Dapper; Integrated Security=True;";
			using (var connection = new SqlConnection(connectionString))
			{
				var query = "INSERT INTO [dbo].[CUSTOMER] " +
				            "(CustomerId, CustomerName) " +
				            $"VALUES('{Guid.NewGuid()}', 'Suhas')";
				connection.Execute(query);
			}
		}

		[Benchmark]
		public void ExecuteSqlUsingSqlCommand()
		{
			var connectionString = "Server = localhost; Database = Dapper; Integrated Security=True;";
			using (var connection = new SqlConnection(connectionString))
			{
				var query = "INSERT INTO [dbo].[CUSTOMER] " +
				            "(CustomerId, CustomerName) " +
				            $"VALUES('{Guid.NewGuid()}', 'Suhas')";
				var command = new SqlCommand(query, connection);
				connection.Open();
				command.ExecuteReader();
				connection.Close();
			}
		}
	}
}
