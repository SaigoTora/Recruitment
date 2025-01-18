namespace SharedModels.Models
{
	using SharedModels.Models.Base;
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
		public int IdApplicationStatus { get; private set; }
		[Column("id_candidate")]
		public int IdCandidate { get; private set; }
		[Column("id_vacancy")]
		public int IdVacancy { get; private set; }
		public virtual ApplicationStatus ApplicationStatus { get; private set; }
		public virtual Candidate Candidate { get; private set; }
		public virtual Vacancy Vacancy { get; private set; }
		public virtual ICollection<Interview> Interviews { get; private set; }
			= new HashSet<Interview>();

		public Application() { }
		public Application(DateTime dateSubmission, string additionalInfo, int idApplicationStatus,
			int idCandidate, int idVacancy)
		{
			DateSubmission = dateSubmission;
			AdditionalInfo = additionalInfo;
			IdApplicationStatus = idApplicationStatus;
			IdCandidate = idCandidate;
			IdVacancy = idVacancy;
		}

		public void ChangeDateSubmission(DateTime dateSubmission)
			=> DateSubmission = dateSubmission;
		public void ChangeReasonRejection(string reasonRejection)
			=> ReasonRejection = reasonRejection;
		public void ChangeStatusId(int idApplicationStatus)
			=> IdApplicationStatus = idApplicationStatus;
	}
}