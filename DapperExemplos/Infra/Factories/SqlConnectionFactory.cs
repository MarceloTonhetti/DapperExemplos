using DapperExemplos.Infra.Contracts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExemplos.Infra.Factories
{
	public class SqlConnectionFactory : ISqlConnectionFactory
	{
		public IDbConnection Connection() => new SqlConnection("Data Source=DESKTOP-9BFKV0K\\SQLEXPRESS;Initial Catalog=DapperExemplos;Integrated Security=True;");
	}
}
