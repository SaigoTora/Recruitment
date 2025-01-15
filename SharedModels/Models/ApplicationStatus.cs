namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Application_Status")]
	public partial class ApplicationStatus : EntityBase
	{
		[Required]
		[StringLength(32)]
		[Column("status")]
		public string Status { get; private set; }
		public virtual ICollection<Application> Application { get; private set; }
			= new HashSet<Application>();
	}
}