namespace SharedModels.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Family_Status")]
	public partial class FamilyStatus
	{
		public int Id { get; private set; }
		[Required]
		[StringLength(32)]
		public string Status { get; private set; }
		public virtual ICollection<Questionnaire> Questionnaire { get; private set; }

		public FamilyStatus()
			=> Questionnaire = new HashSet<Questionnaire>();
	}
}