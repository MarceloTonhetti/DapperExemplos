using DapperExemplos.Domain.Fixed;

namespace DapperExemplos.Domain.Dto
{
	public class PetDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public TypePet Type { get; set; }
	}
}
