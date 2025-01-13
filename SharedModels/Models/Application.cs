namespace SharedModels.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Application")]
	public partial class Application
	{
		public int Id { get; private set; }
		[Column(TypeName = "datetime2")]
		public DateTime DateSubmission { get; private set; }
		public int Scores { get; private set; }
		public string AdditionalInfo { get; private set; }
		public string ReasonRejection { get; private set; }
		public int IdApplicationStatus { get; private set; }
		public int IdCandidate { get; private set; }
		public int IdVacancy { get; private set; }
		public virtual ApplicationStatus ApplicationStatus { get; private set; }
		public virtual Candidate Candidate { get; private set; }
		public virtual Vacancy Vacancy { get; private set; }
		public virtual ICollection<Interview> Interview { get; private set; }

		public Application()
			=> Interview = new HashSet<Interview>();
	}
}