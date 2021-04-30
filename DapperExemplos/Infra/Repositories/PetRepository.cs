using Dapper;
using Dapper.Contrib.Extensions;
using DapperExemplos.Domain.Dto;
using DapperExemplos.Domain.Entities;
using DapperExemplos.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExemplos.Infra.Repositories
{
	public class PetRepository : IPetRepository
	{
		private readonly ISqlConnectionFactory _connectionFactory;

		public PetRepository(ISqlConnectionFactory connection)
		{
			_connectionFactory = connection;
		}

		//Add
		public async Task<Pet> AddAsync(PetDto pet)
		{
			Pet newPet = new Pet()
			{
				Id = Guid.NewGuid(),
				Name = pet.Name,
				Description = pet.Description,
				Type = pet.Type
			};

			using var connection = _connectionFactory.Connection();
			connection.Open();
			await connection.InsertAsync(newPet);

			return newPet;
		}

		//Get
		public async Task<IEnumerable<PetDto>> GetAsync()
		{
			const string sql = "SELECT Name, Description, Type FROM Pet";

			using var connection = _connectionFactory.Connection();
			return await connection.QueryAsync<PetDto>(sql, commandType: CommandType.Text);
		}

		//GetById
		public async Task<PetDto> GetByIdAsync(Guid id)
		{
			const string sql = "SELECT Name, Description, Type FROM Pet WHERE Id = @id;";

			//tratando SQL injection (ESTUDAR)
			var parameters = new DynamicParameters();

			parameters.Add(name: "@id", id);

			using var connection = _connectionFactory.Connection();
			return await connection.QuerySingleOrDefaultAsync<PetDto>(sql, parameters, commandType: CommandType.Text);
		}

		//Update
		public async Task UpdateAsync(Guid id, PetDto pet)
		{
			const string sql = "UPDATE Pet SET Name = @Name, Description = @Description, Type = @Type WHERE Id = @Id;";

			var parameters = new DynamicParameters();

			parameters.Add("@Id", id);
			parameters.Add("@Name", pet.Name);
			parameters.Add("@Description", pet.Description);
			parameters.Add("@Type", pet.Type);

			using var connection = _connectionFactory.Connection();
			await connection.ExecuteAsync(sql, parameters, commandType: CommandType.Text);
		}

		//Patch
		public async Task PartialUpdateAsync(Guid id, PetDto pet)
		{
			PetDto newPet = await GetByIdAsync(id);

			if (pet.Name != null)
				newPet.Name = pet.Name;
			if (pet.Description != null)
				newPet.Description = pet.Description;

			const string sql = "UPDATE Pet SET Name = @Name, Description = @Description WHERE Id = @Id;";

			var parameters = new DynamicParameters();

			parameters.Add("@Id", id);
			parameters.Add("@Name", newPet.Name);
			parameters.Add("@Description", newPet.Description);

			using var connection = _connectionFactory.Connection();
			await connection.ExecuteAsync(sql, parameters, commandType: CommandType.Text);
		}

		//Delete
		public async Task DeleteAsync(Guid id)
		{
			const string sql = "DELETE FROM Pet WHERE Id = @Id";

			var parameters = new DynamicParameters();

			parameters.Add("@Id", id);

			using var connection = _connectionFactory.Connection();
			await connection.ExecuteAsync(sql, parameters, commandType: CommandType.Text);
		}
	}
}
