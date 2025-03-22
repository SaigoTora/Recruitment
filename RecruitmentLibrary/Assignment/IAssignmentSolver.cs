namespace RecruitmentLibrary.Assignment
{
	public interface IAssignmentSolver
	{
		int[] Solve(int[,] costs, bool findMax);
	}
}