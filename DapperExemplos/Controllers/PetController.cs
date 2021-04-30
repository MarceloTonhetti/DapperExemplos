using DapperExemplos.Domain.Dto;
using DapperExemplos.Domain.Entities;
using DapperExemplos.Infra.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExemplos.Controllers
{
	[Route(template:"/api/pets")]
	public class PetController : ControllerBase
	{
		private readonly IPetRepository _repository;

		public PetController(IPetRepository repository)
		{
			_repository = repository;
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync([FromBody] PetDto pet)
		{
			Pet newPet = await _repository.AddAsync(pet);

			return Created(uri:$"/api/pets/{newPet.Id}", newPet);
		}

		[HttpGet]
		public async Task<IEnumerable<PetDto>> GetAsync()
		{
			return await _repository.GetAsync();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsynC(Guid id)
		{
			return Ok(await _repository.GetByIdAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsyn([FromRoute]Guid id, [FromBody] PetDto pet)
		{
			await _repository.UpdateAsync(id, pet);
			return NoContent();
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> PartialUpdateAsync([FromRoute] Guid id, [FromBody] PetDto pet)
		{
			await _repository.PartialUpdateAsync(id, pet);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			await _repository.DeleteAsync(id);
			return NoContent();
		}
	}
}
