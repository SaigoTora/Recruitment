namespace SharedModels.Models
{
	using SharedModels.Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Interview")]
	public partial class Interview : EntityBase
	{
		[Column(name: "date_event", TypeName = "datetime2")]
		public DateTime DateEvent { get; private set; }
		[Column("id_application")]
		public int IdApplication { get; private set; }
		[Column("id_interview_status")]
		public int IdInterviewStatus { get; private set; }
		public virtual Application Application { get; private set; }
		public virtual InterviewStatus InterviewStatus { get; private set; }
		public virtual ICollection<Employee> Employees { get; private set; }
			= new HashSet<Employee>();

		public Interview() { }
		public Interview(DateTime dateEvent, int idApplication, int idInterviewStatus)
		{
			DateEvent = dateEvent;
			IdApplication = idApplication;
			IdInterviewStatus = idInterviewStatus;
		}

		public void ChangeDateEvent(DateTime dateEvent)
			=> DateEvent = dateEvent;
		public void ChangeStatusId(InterviewStatus interviewStatus)
		{
			IdInterviewStatus = interviewStatus.Id;
			InterviewStatus = interviewStatus;
		}
	}
}