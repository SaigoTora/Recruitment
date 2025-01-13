namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Vacancy")]
	public partial class ViewVacancy
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(Order = 1)]
		[StringLength(64)]
		public string PositionName { get; private set; }
		public string PositionDescription { get; private set; }
		[Key]
		[Column(Order = 2, TypeName = "money")]
		public decimal Salary { get; private set; }
		[Key]
		[Column(Order = 3, TypeName = "datetime2")]
		public DateTime DatePublication { get; private set; }
		public int? ApplicationCount { get; private set; }
		public string Info { get; private set; }
		[Key]
		[Column(Order = 4)]
		public bool Relevance { get; private set; }
		[Key]
		[Column(Order = 5)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdPoint { get; private set; }
		[Key]
		[Column(Order = 6)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdRequirement { get; private set; }

		public ViewVacancy(int id, string positionName, string positionDescription,
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
		public ViewVacancy(int id, string positionName, string positionDescription,
			decimal salary, DateTime datePublication, string info, bool relevance,
			int applicationCount, int idPoint, int idRequirement)
			: this(id, positionName, positionDescription, salary, datePublication, info)
		{
			Relevance = relevance;
			ApplicationCount = applicationCount;
			IdPoint = idPoint;
			IdRequirement = idRequirement;
		}
	}
}