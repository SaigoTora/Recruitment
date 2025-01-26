using Base;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("EducationDegree_Requirement")]
	[Serializable]
	public partial class EducationDegreeRequirement : EntityBase
	{
		[Column("id_requirement")]
		[JsonProperty]
		public int RequirementId { get; private set; }
		[Column("id_education_degree")]
		[JsonProperty]
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