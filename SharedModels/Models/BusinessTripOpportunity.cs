namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Business_Trip_Opportunity")]
	public partial class BusinessTripOpportunity : EntityBase
	{
		[Required]
		[StringLength(32)]
		public string Opportunity { get; private set; }
		public virtual ICollection<Questionnaire> Questionnaire { get; private set; }
			= new HashSet<Questionnaire>();
	}
}