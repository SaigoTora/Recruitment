namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Education_Form")]
	public partial class EducationForm : EntityBase
	{
		[Required]
		[StringLength(32)]
		public string Form { get; private set; }
		public virtual ICollection<Education> Education { get; private set; }
			= new HashSet<Education>();
	}
}