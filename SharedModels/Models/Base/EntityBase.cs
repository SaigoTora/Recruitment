using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models.Base
{
	[Serializable]
	public class EntityBase
	{
		[Key]
		[JsonProperty]
		public int Id { get; protected set; }

		protected EntityBase() { }
		public EntityBase(int id)
			=> Id = id;
	}
}