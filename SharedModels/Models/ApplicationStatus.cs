using Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Application_Status")]
	[Serializable]
	public partial class ApplicationStatus : EntityBase
	{
		[Column("status")]
		[Required]
		[StringLength(32)]
		[JsonProperty]
		public string Status { get; private set; }
		[JsonIgnore]
		public virtual ICollection<Application> Applications { get; private set; }
			= new HashSet<Application>();

		private ApplicationStatus() { }
		public ApplicationStatus(string status)
			=> Status = status;
	}
}