namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Family_Status")]
	public partial class FamilyStatus : EntityBase
	{
		[Column("status")]
		[Required]
		[StringLength(32)]
		public string Status { get; private set; }
		public virtual ICollection<Questionnaire> Questionnaires { get; private set; }
			= new HashSet<Questionnaire>();

		public FamilyStatus() { }
		public FamilyStatus(string status)
			=> Status = status;
	}
}