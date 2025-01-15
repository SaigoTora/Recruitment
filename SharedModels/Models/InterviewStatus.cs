namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Interview_Status")]
	public partial class InterviewStatus : EntityBase
	{
		[Column("status")]
		[Required]
		[StringLength(32)]
		public string Status { get; private set; }
		public virtual ICollection<Interview> Interview { get; private set; }
			= new HashSet<Interview>();

		public InterviewStatus() { }
		public InterviewStatus(string status)
			=> Status = status;
	}
}