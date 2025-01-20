namespace SharedModels.Models
{
	using Base;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Education_Degree")]
	[Serializable]
	public partial class EducationDegree : EntityBase
	{
		[Column("degree")]
		[Required]
		[StringLength(32)]
		[JsonProperty]
		public string Degree { get; private set; }
		[JsonIgnore]
		public virtual ICollection<Education> Educations { get; private set; }
			= new HashSet<Education>();
		[JsonIgnore]
		public virtual ICollection<EducationDegreePoint> EducationDegreePoints
		{ get; private set; } = new HashSet<EducationDegreePoint>();
		[JsonIgnore]
		public virtual ICollection<EducationDegreeRequirement> EducationDegreeRequirements
		{ get; private set; } = new HashSet<EducationDegreeRequirement>();

		public EducationDegree() { }
		public EducationDegree(string degree)
			=> Degree = degree;
	}
}