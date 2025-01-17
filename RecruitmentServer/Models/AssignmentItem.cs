namespace RecruitmentServer.Models
{
	internal class AssignmentItem
	{// Class for solving the assignment problem
		internal int VacancyId { get; private set; }
		internal int CandidateId { get; private set; }
		internal int Scores { get; private set; }

		public AssignmentItem() { }
		public AssignmentItem(int idVacancy, int idCandidate, int scores)
		{
			VacancyId = idVacancy;
			CandidateId = idCandidate;
			Scores = scores;
		}
	}
}