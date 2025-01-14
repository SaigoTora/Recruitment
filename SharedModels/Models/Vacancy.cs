namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Vacancy")]
	public partial class Vacancy : EntityBase
	{
		[Column(TypeName = "money")]
		public decimal Salary { get; private set; }
		[Column(TypeName = "datetime2")]
		public DateTime DatePublication { get; private set; }
		public string Info { get; private set; }
		public bool Relevance { get; private set; }
		public int IdPoint { get; private set; }
		public int IdRequirement { get; private set; }
		public int IdPosition { get; private set; }
		public virtual Point Point { get; private set; }
		public virtual Position Position { get; private set; }
		public virtual Requirement Requirement { get; private set; }
		public virtual ICollection<Application> Application { get; private set; }
			= new HashSet<Application>();
	}
}