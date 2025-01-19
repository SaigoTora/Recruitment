namespace SharedModels.Models
{
	using Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Education_Form")]
	public partial class EducationForm : EntityBase
	{
		[Column("form")]
		[Required]
		[StringLength(32)]
		public string Form { get; private set; }
		public virtual ICollection<Education> Educations { get; private set; }
			= new HashSet<Education>();

		public EducationForm() { }
		public EducationForm(string form)
			=> Form = form;
	}
}