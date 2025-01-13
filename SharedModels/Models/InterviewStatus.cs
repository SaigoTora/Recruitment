namespace SharedModels.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Interview_Status")]
	public partial class InterviewStatus
	{
		public int Id { get; private set; }
		[Required]
		[StringLength(32)]
		public string Status { get; private set; }
		public virtual ICollection<Interview> Interview { get; private set; }

		public InterviewStatus(string status)
		{
			Interview = new HashSet<Interview>();
			Status = status;
		}
	}
}