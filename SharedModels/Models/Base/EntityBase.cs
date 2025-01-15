using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models.Base
{
	public class EntityBase
	{
		[Key]
		public int Id { get; protected set; }

		public EntityBase() { }
		public EntityBase(int id)
			=> Id = id;
	}
}