namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Business_Trip_Opportunity")]
	public partial class BusinessTripOpportunity : EntityBase
	{
		[Column("opportunity")]
		[Required]
		[StringLength(32)]
		public string Opportunity { get; private set; }
		public virtual ICollection<Questionnaire> Questionnaires { get; private set; }
			= new HashSet<Questionnaire>();

		public BusinessTripOpportunity() { }
		public BusinessTripOpportunity(string opportunity)
			=> Opportunity = opportunity;
	}
}