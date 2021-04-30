using DapperExemplos.Domain.Dto;
using DapperExemplos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperExemplos.Infra.Contracts
{
	public interface IPetRepository
	{
		Task<Pet> AddAsync(PetDto pet);
		Task<IEnumerable<PetDto>> GetAsync();
		Task<PetDto> GetByIdAsync(Guid id);
		Task UpdateAsync(Guid id, PetDto pet);
		Task PartialUpdateAsync(Guid id, PetDto pet);
		Task DeleteAsync(Guid id);
	}
}
