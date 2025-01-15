namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Position")]
	public partial class Position : EntityBase
	{
		[Column("name")]
		[Required]
		[StringLength(64)]
		public string Name { get; private set; }
		[Column("description")]
		public string Description { get; private set; }
		public virtual ICollection<Vacancy> Vacancy { get; private set; }
			= new HashSet<Vacancy>();

		public Position() { }
		public Position(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}