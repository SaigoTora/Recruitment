namespace SharedModels.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Interview")]
	public partial class Interview
	{
		public int Id { get; private set; }
		[Column(TypeName = "datetime2")]
		public DateTime DateEvent { get; private set; }
		public int IdApplication { get; private set; }
		public int IdInterviewStatus { get; private set; }
		public virtual Application Application { get; private set; }
		public virtual ICollection<Employee> Employee { get; private set; }
		public virtual InterviewStatus Interview_Status { get; private set; }

		public Interview()
			=> Employee = new HashSet<Employee>();

		public void ChangeDateEvent(DateTime dateTime)
			=> DateEvent = dateTime;
	}
}