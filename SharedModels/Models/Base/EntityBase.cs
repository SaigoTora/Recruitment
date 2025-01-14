using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models.Base
{
	public class EntityBase
	{
		[Key]
		public int Id { get; protected set; }
		[Timestamp]
		public byte[] Timestamp { get; protected set; }

		public EntityBase(int id, byte[] timestamp)
		{
			Id = id;
			Timestamp = timestamp;
		}
	}
}