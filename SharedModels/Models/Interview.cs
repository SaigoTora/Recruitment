namespace SharedModels.Models
{
	using Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Interview")]
	public partial class Interview : EntityBase
	{
		[Column(name: "date_event", TypeName = "datetime2")]
		public DateTime DateEvent { get; private set; }
		[Column("id_application")]
		public int ApplicationId { get; private set; }
		[Column("id_interview_status")]
		public int InterviewStatusId { get; private set; }
		public virtual Application Application { get; private set; }
		public virtual InterviewStatus InterviewStatus { get; private set; }
		public virtual ICollection<Employee> Employees { get; private set; }
			= new HashSet<Employee>();

		public Interview() { }
		public Interview(DateTime dateEvent, int applicationId, int interviewStatusId)
		{
			DateEvent = dateEvent;
			ApplicationId = applicationId;
			InterviewStatusId = interviewStatusId;
		}
		public Interview(string positionName, string positionDescription,
			string status, DateTime dateEvent)
		{
			Application?.Vacancy?.Position?.ChangeName(positionName);
			Application?.Vacancy?.Position?.ChangeDescription(positionDescription);
			InterviewStatus = new InterviewStatus(status);
			DateEvent = dateEvent;
		}

		public void ChangeDateEvent(DateTime dateEvent)
			=> DateEvent = dateEvent;
		public void ChangeStatusId(InterviewStatus interviewStatus)
		{
			InterviewStatusId = interviewStatus.Id;
			InterviewStatus = interviewStatus;
		}
	}
}