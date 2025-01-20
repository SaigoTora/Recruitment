namespace SharedModels.Models
{
	using Base;
	using Newtonsoft.Json;
	using System;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("EducationDegree_Requirement")]
	[Serializable]
	public partial class EducationDegreeRequirement : EntityBase
	{
		[Column("id_requirement")]
		[JsonProperty]
		public int RequirementId { get; private set; }
		[Column("id_education_degree")]
		public int EducationDegreeId { get; private set; }
		[JsonProperty]
		public virtual EducationDegree EducationDegree { get; private set; }
		[JsonIgnore]
		public virtual Requirement Requirement { get; private set; }

		public EducationDegreeRequirement() { }
		public EducationDegreeRequirement(int requirementId, int educationDegreeId)
		{
			RequirementId = requirementId;
			EducationDegreeId = educationDegreeId;
		}
	}
}