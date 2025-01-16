namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Application_Status")]
	public partial class ApplicationStatus : EntityBase
	{
		[Column("status")]
		[Required]
		[StringLength(32)]
		public string Status { get; private set; }
		public virtual ICollection<Application> Applications { get; private set; }
			= new HashSet<Application>();

		public ApplicationStatus() { }
		public ApplicationStatus(string status)
			=> Status = status;
	}
}