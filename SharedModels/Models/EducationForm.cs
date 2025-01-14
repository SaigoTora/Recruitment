namespace SharedModels.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Education_Form")]
	public partial class EducationForm
	{
		public int Id { get; private set; }
		[Required]
		[StringLength(32)]
		public string Form { get; private set; }
		public virtual ICollection<Education> Education { get; private set; }
			= new HashSet<Education>();
	}
}