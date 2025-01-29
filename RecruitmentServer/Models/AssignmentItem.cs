namespace RecruitmentServer.Models
{
	internal class AssignmentItem
	{// Class for solving the assignment problem
		internal int VacancyId { get; set; }
		internal int CandidateId { get; set; }
		internal int Scores { get; set; }

		internal AssignmentItem() { }
		internal AssignmentItem(int vacancyId, int candidateId, int scores)
		{
			VacancyId = vacancyId;
			CandidateId = candidateId;
			Scores = scores;
		}
	}
}