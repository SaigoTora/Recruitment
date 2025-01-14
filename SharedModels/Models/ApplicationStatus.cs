namespace SharedModels.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Application_Status")]
	public partial class ApplicationStatus
	{
		public int Id { get; private set; }
		[Required]
		[StringLength(32)]
		public string Status { get; private set; }
		public virtual ICollection<Application> Application { get; private set; }
			= new HashSet<Application>();
	}
}