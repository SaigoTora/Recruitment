namespace SharedModels.Models
{
	using Base;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Business_Trip_Opportunity")]
	[Serializable]
	public partial class BusinessTripOpportunity : EntityBase
	{
		[Column("opportunity")]
		[Required]
		[StringLength(32)]
		[JsonProperty]
		public string Opportunity { get; private set; }
		[JsonIgnore]
		public virtual ICollection<Questionnaire> Questionnaires { get; private set; }
			= new HashSet<Questionnaire>();

		public BusinessTripOpportunity() { }
		public BusinessTripOpportunity(string opportunity)
			=> Opportunity = opportunity;
	}
}