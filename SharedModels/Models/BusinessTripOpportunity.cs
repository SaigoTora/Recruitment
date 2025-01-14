namespace SharedModels.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Business_Trip_Opportunity")]
	public partial class BusinessTripOpportunity
	{
		public int Id { get; private set; }
		[Required]
		[StringLength(32)]
		public string Opportunity { get; private set; }
		public virtual ICollection<Questionnaire> Questionnaire { get; private set; }
			= new HashSet<Questionnaire>();
	}
}