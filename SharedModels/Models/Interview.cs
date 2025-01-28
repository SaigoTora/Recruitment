using Newtonsoft.Json;
using SharedModels.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
	[Table("Interview")]
	[Serializable]
	public partial class Interview : EntityBase
	{
		[Column(name: "date_event", TypeName = "datetime2")]
		[JsonProperty]
		public DateTime DateEvent { get; private set; }
		[Column("id_application")]
		[JsonProperty]
		public int ApplicationId { get; private set; }
		[Column("id_interview_status")]
		[JsonProperty]
		public int InterviewStatusId { get; private set; }
		[JsonProperty]
		public virtual Application Application { get; private set; }
		[JsonProperty]
		public virtual InterviewStatus InterviewStatus { get; private set; }
		[JsonIgnore]
		public virtual ICollection<Employee> Employees { get; private set; }
			= new HashSet<Employee>();

		public Interview() { }
		public Interview(DateTime dateEvent, int applicationId, int interviewStatusId)
		{
			DateEvent = dateEvent;
			ApplicationId = applicationId;
			InterviewStatusId = interviewStatusId;
		}

		public DateTime GetLocalDateEvent()
			=> DateEvent.ToLocalTime();
		public void ChangeDateEvent(DateTime dateEvent)
			=> DateEvent = dateEvent;
		public void ChangeStatusId(InterviewStatus interviewStatus)
		{
			InterviewStatusId = interviewStatus.Id;
			InterviewStatus = interviewStatus;
		}
	}
}