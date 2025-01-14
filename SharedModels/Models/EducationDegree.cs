namespace SharedModels.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Education_Degree")]
	public partial class EducationDegree
	{
		public int Id { get; private set; }
		[Required]
		[StringLength(32)]
		public string Degree { get; private set; }
		public virtual ICollection<Education> Education { get; private set; }
			= new HashSet<Education>();
		public virtual ICollection<EducationDegreePoint> EducationDegreePoint
		{ get; private set; } = new HashSet<EducationDegreePoint>();
		public virtual ICollection<EducationDegreeRequirement> EducationDegreeRequirement
		{ get; private set; } = new HashSet<EducationDegreeRequirement>();
	}
}