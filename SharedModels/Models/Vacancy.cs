using Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Vacancy")]
	[Serializable]
	public partial class Vacancy : EntityBase
	{
		[Column(name: "salary", TypeName = "money")]
		[JsonProperty]
		public decimal Salary { get; private set; }
		[Column(name: "date_publication", TypeName = "datetime2")]
		[JsonProperty]
		public DateTime DatePublication { get; private set; }
		[Column("info")]
		[JsonProperty]
		public string Info { get; private set; }
		[Column("relevance")]
		[JsonProperty]
		public bool Relevance { get; private set; }
		[Column("id_point")]
		[JsonProperty]
		public int PointId { get; private set; }
		[Column("id_requirement")]
		[JsonProperty]
		public int RequirementId { get; private set; }
		[Column("id_position")]
		[JsonProperty]
		public int PositionId { get; private set; }
		[JsonProperty]
		public virtual Point Point { get; private set; }
		[JsonProperty]
		public virtual Position Position { get; private set; }
		[JsonProperty]
		public virtual Requirement Requirement { get; private set; }
		[JsonIgnore]
		public virtual ICollection<Application> Applications { get; private set; }
			= new HashSet<Application>();

		private Vacancy() { }
		public Vacancy(decimal salary, DateTime datePublication, string info, int pointId,
			int requirementId, int positionId)
		{
			Salary = salary;
			DatePublication = datePublication;
			Info = info;
			Relevance = true;
			PointId = pointId;
			RequirementId = requirementId;
			PositionId = positionId;
		}

		public void ChangeRelevance(bool relevance) => Relevance = relevance;
		public void ChangeDatePublication(DateTime datePublication)
			=> DatePublication = datePublication;
	}
}