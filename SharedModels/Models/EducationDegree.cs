namespace SharedModels.Models
{
	using Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Education_Degree")]
	public partial class EducationDegree : EntityBase
	{
		[Column("degree")]
		[Required]
		[StringLength(32)]
		public string Degree { get; private set; }
		public virtual ICollection<Education> Educations { get; private set; }
			= new HashSet<Education>();
		public virtual ICollection<EducationDegreePoint> EducationDegreePoints
		{ get; private set; } = new HashSet<EducationDegreePoint>();
		public virtual ICollection<EducationDegreeRequirement> EducationDegreeRequirements
		{ get; private set; } = new HashSet<EducationDegreeRequirement>();

		public EducationDegree() { }
		public EducationDegree(string degree)
			=> Degree = degree;
	}
}