namespace SharedModels.Models
{
	using Base;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("EducationDegree_Requirement")]
	public partial class EducationDegreeRequirement : EntityBase
	{
		[Column("id_requirement")]
		public int RequirementId { get; private set; }
		[Column("id_education_degree")]
		public int EducationDegreeId { get; private set; }
		public virtual EducationDegree EducationDegree { get; private set; }
		public virtual Requirement Requirement { get; private set; }

		public EducationDegreeRequirement() { }
		public EducationDegreeRequirement(int requirementId, int educationDegreeId)
		{
			RequirementId = requirementId;
			EducationDegreeId = educationDegreeId;
		}
	}
}