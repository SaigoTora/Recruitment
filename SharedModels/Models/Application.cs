namespace SharedModels.Models
{
	using Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Application")]
	public partial class Application : EntityBase
	{
		[Column(name: "date_submission", TypeName = "datetime2")]
		public DateTime DateSubmission { get; private set; }
		[Column("scores")]
		public int Scores { get; private set; }
		[Column("additional_info")]
		public string AdditionalInfo { get; private set; }
		[Column("reason_rejection")]
		public string ReasonRejection { get; private set; }
		[Column("id_application_status")]
		public int ApplicationStatusId { get; private set; }
		[Column("id_candidate")]
		public int CandidateId { get; private set; }
		[Column("id_vacancy")]
		public int VacancyId { get; private set; }
		public virtual ApplicationStatus ApplicationStatus { get; private set; }
		public virtual Candidate Candidate { get; private set; }
		public virtual Vacancy Vacancy { get; private set; }
		public virtual ICollection<Interview> Interviews { get; private set; }
			= new HashSet<Interview>();

		public Application() { }
		public Application(DateTime dateSubmission, string additionalInfo, int applicationStatusId,
			int candidateId, int vacancyId)
		{
			DateSubmission = dateSubmission;
			AdditionalInfo = additionalInfo;
			ApplicationStatusId = applicationStatusId;
			CandidateId = candidateId;
			VacancyId = vacancyId;
		}
		public Application(string positionName, string positionDescription, string status,
			DateTime dateSubmission, string reasonRejection)
		{
			Vacancy?.Position?.ChangeName(positionName);
			Vacancy?.Position?.ChangeDescription(positionDescription);
			ApplicationStatus = new ApplicationStatus(status);
			DateSubmission = dateSubmission;
			ReasonRejection = reasonRejection;
		}

		public void ChangeDateSubmission(DateTime dateSubmission)
			=> DateSubmission = dateSubmission;
		public void ChangeReasonRejection(string reasonRejection)
			=> ReasonRejection = reasonRejection;
		public void ChangeStatusId(int applicationStatusId)
			=> ApplicationStatusId = applicationStatusId;
	}
}