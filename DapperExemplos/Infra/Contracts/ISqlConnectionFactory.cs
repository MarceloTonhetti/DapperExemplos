using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExemplos.Infra.Contracts
{
	public interface ISqlConnectionFactory
	{
		IDbConnection Connection();
	}
}
