namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Application")]
	public partial class ApplicationDbView
	{
		[Key]
		[Column(name: "id", Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(name: "date_submission", Order = 1, TypeName = "datetime2")]
		public DateTime DateSubmission { get; private set; }
		[Key]
		[Column(name: "scores", Order = 2)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Scores { get; private set; }
		[Key]
		[Column(name: "status", Order = 3)]
		[StringLength(32)]
		public string Status { get; private set; }
		[Column("additional_info")]
		public string AdditionalInfo { get; private set; }
		[Column("reason_rejection")]
		public string ReasonRejection { get; private set; }
		[Key]
		[Column(name: "position_name", Order = 4)]
		[StringLength(64)]
		public string PositionName { get; private set; }
		[Column("position_description")]
		public string PositionDescription { get; private set; }
		[Key]
		[Column(name: "id_candidate", Order = 5)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CandidateId { get; private set; }
		[Key]
		[Column(name: "id_vacancy", Order = 6)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int VacancyId { get; private set; }

		public ApplicationDbView() { }
		public ApplicationDbView(string positionName, string positionDescription, string status,
			DateTime dateSubmission, string reasonRejection)
		{
			PositionName = positionName;
			PositionDescription = positionDescription;
			Status = status;
			DateSubmission = dateSubmission;
			ReasonRejection = reasonRejection;
		}
		public ApplicationDbView(int id, string positionName, string positionDescription,
			string status, DateTime dateSubmission, string reasonRejection, int scores,
			string additionalInfo, int candidateId, int vacancyId)
			: this(positionName, positionDescription, status, dateSubmission, reasonRejection)
		{
			Id = id;
			Scores = scores;
			AdditionalInfo = additionalInfo;
			CandidateId = candidateId;
			VacancyId = vacancyId;
		}
	}
}