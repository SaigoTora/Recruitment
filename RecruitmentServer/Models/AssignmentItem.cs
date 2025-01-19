namespace RecruitmentServer.Models
{
	internal class AssignmentItem
	{// Class for solving the assignment problem
		internal int VacancyId { get; private set; }
		internal int CandidateId { get; private set; }
		internal int Scores { get; private set; }

		public AssignmentItem() { }
		public AssignmentItem(int vacancyId, int candidateId, int scores)
		{
			VacancyId = vacancyId;
			CandidateId = candidateId;
			Scores = scores;
		}
	}
}