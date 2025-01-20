namespace SharedModels.Models
{
	using Base;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Family_Status")]
	[Serializable]
	public partial class FamilyStatus : EntityBase
	{
		[Column("status")]
		[Required]
		[StringLength(32)]
		[JsonProperty]
		public string Status { get; private set; }
		[JsonIgnore]
		public virtual ICollection<Questionnaire> Questionnaires { get; private set; }
			= new HashSet<Questionnaire>();

		public FamilyStatus() { }
		public FamilyStatus(string status)
			=> Status = status;
	}
}