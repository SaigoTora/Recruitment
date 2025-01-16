namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Vacancy")]
	public partial class Vacancy : EntityBase
	{
		[Column(name: "salary", TypeName = "money")]
		public decimal Salary { get; private set; }
		[Column(name: "date_publication", TypeName = "datetime2")]
		public DateTime DatePublication { get; private set; }
		[Column("info")]
		public string Info { get; private set; }
		[Column("relevance")]
		public bool Relevance { get; private set; }
		[Column("id_point")]
		public int IdPoint { get; private set; }
		[Column("id_requirement")]
		public int IdRequirement { get; private set; }
		[Column("id_position")]
		public int IdPosition { get; private set; }
		public virtual Point Point { get; private set; }
		public virtual Position Position { get; private set; }
		public virtual Requirement Requirement { get; private set; }
		public virtual ICollection<Application> Applications { get; private set; }
			= new HashSet<Application>();

		public Vacancy() { }
		public Vacancy(decimal salary, DateTime datePublication, string info, int idPoint,
			int idRequirement, int idPosition)
		{
			Salary = salary;
			DatePublication = datePublication;
			Info = info;
			Relevance = true;
			IdPoint = idPoint;
			IdRequirement = idRequirement;
			IdPosition = idPosition;
		}
	}
}