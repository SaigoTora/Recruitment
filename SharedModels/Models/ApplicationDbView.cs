namespace SharedModels.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("View_Application")]
	public partial class ApplicationDbView
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; private set; }
		[Key]
		[Column(Order = 1, TypeName = "datetime2")]
		public DateTime DateSubmission { get; private set; }
		[Key]
		[Column(Order = 2)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Scores { get; private set; }
		[Key]
		[Column(Order = 3)]
		[StringLength(32)]
		public string Status { get; private set; }
		public string AdditionalInfo { get; private set; }
		public string ReasonRejection { get; private set; }
		[Key]
		[Column(Order = 4)]
		[StringLength(64)]
		public string PositionName { get; private set; }
		public string PositionDescription { get; private set; }
		[Key]
		[Column(Order = 5)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdCandidate { get; private set; }
		[Key]
		[Column(Order = 6)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IdVacancy { get; private set; }

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
			string additionalInfo, int idCandidate, int idVacancy)
			: this(positionName, positionDescription, status, dateSubmission, reasonRejection)
		{
			Id = id;
			Scores = scores;
			AdditionalInfo = additionalInfo;
			IdCandidate = idCandidate;
			IdVacancy = idVacancy;
		}
	}
}