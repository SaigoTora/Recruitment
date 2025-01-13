namespace SharedModels.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("EducationDegree_Requirement")]
	public partial class EducationDegreeRequirement
	{
		public int Id { get; private set; }
		public int IdRequirement { get; private set; }
		public int IdEducationDegree { get; private set; }
		public virtual EducationDegree EducationDegree { get; private set; }
		public virtual Requirement Requirement { get; private set; }

		public EducationDegreeRequirement(int idRequirement, int idEducationDegree)
		{
			IdRequirement = idRequirement;
			IdEducationDegree = idEducationDegree;
		}
	}
}