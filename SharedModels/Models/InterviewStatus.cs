namespace SharedModels.Models
{
	using Base;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Interview_Status")]
	[Serializable]
	public partial class InterviewStatus : EntityBase
	{
		[Column("status")]
		[Required]
		[StringLength(32)]
		[JsonProperty]
		public string Status { get; private set; }
		[JsonIgnore]
		public virtual ICollection<Interview> Interviews { get; private set; }
			= new HashSet<Interview>();

		public InterviewStatus() { }
		public InterviewStatus(string status)
			=> Status = status;
	}
}