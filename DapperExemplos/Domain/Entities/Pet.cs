using Dapper.Contrib.Extensions;
using DapperExemplos.Domain.Fixed;
using System;

namespace DapperExemplos.Domain.Entities
{
	/*Nottations for Dapper Contrib*/
	[Table(tableName:"[dbo].[Pet]")]
	public class Pet
	{
		[ExplicitKey]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public TypePet Type { get; set; }
	}
}
