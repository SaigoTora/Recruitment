namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Vacancy")]
	public partial class VacancyDbView
	{
		[Key]
		[Column(name: "id", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(name: "position_name", Order = 1)]
		[StringLength(64)]
		public string PositionName { get; private set; }
		[Column("position_description")]
		public string PositionDescription { get; private set; }
		[Key]
		[Column(name: "salary", Order = 2, TypeName = "money")]
		public decimal Salary { get; private set; }
		[Key]
		[Column(name: "date_publication", Order = 3, TypeName = "datetime2")]
		public DateTime DatePublication { get; private set; }
		[Column("application_count")]
		public int? ApplicationCount { get; private set; }
		[Column("info")]
		public string Info { get; private set; }
		[Key]
		[Column(name: "relevance", Order = 4)]
		public bool Relevance { get; private set; }
		[Key]
		[Column(name: "id_point", Order = 5)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int PointId { get; private set; }
		[Key]
		[Column(name: "id_requirement", Order = 6)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RequirementId { get; private set; }

		public VacancyDbView() { }
		public VacancyDbView(int id, string positionName, string positionDescription,
			decimal salary, DateTime datePublication,
			string info)
		{
			Id = id;
			PositionName = positionName;
			PositionDescription = positionDescription;
			Salary = salary;
			DatePublication = datePublication;
			Info = info;
		}
	}
}