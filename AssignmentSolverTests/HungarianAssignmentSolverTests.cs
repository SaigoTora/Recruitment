using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecruitmentLibrary.Assignment;
using System.Linq;

namespace AssignmentSolverTests
{
	[TestClass]
	public class HungarianAssignmentSolverTests
	{
		[TestMethod]
		public void TestHungarianAlgorithm_Scenario1()
		{
			// Arrange
			int[,] matrix = new int[5, 5];
			matrix[0, 0] = 7;
			matrix[0, 1] = 3;
			matrix[0, 2] = 6;
			matrix[0, 3] = 9;
			matrix[0, 4] = 5;

			matrix[1, 0] = 7;
			matrix[1, 1] = 5;
			matrix[1, 2] = 7;
			matrix[1, 3] = 5;
			matrix[1, 4] = 6;

			matrix[2, 0] = 7;
			matrix[2, 1] = 6;
			matrix[2, 2] = 8;
			matrix[2, 3] = 8;
			matrix[2, 4] = 9;

			matrix[3, 0] = 3;
			matrix[3, 1] = 1;
			matrix[3, 2] = 6;
			matrix[3, 3] = 5;
			matrix[3, 4] = 7;

			matrix[4, 0] = 2;
			matrix[4, 1] = 4;
			matrix[4, 2] = 9;
			matrix[4, 3] = 9;
			matrix[4, 4] = 5;

			bool findMax = true;

			// Act
			int[] result = HungarianAssignmentSolver.Solve(matrix, findMax);

			// Assert
			int[] expect = { 3, 0, 1, 4, 2 };
			bool condition = result.SequenceEqual(expect);

			Assert.IsTrue(condition);
		}
		[TestMethod]
		public void TestHungarianAlgorithm_Scenario2()
		{
			// Arrange
			int[,] matrix = new int[3, 2];
			matrix[0, 0] = 2;
			matrix[0, 1] = 8;

			matrix[1, 0] = 4;
			matrix[1, 1] = 6;

			matrix[2, 0] = 5;
			matrix[2, 1] = 1;

			bool findMax = true;

			// Act
			int[] result = HungarianAssignmentSolver.Solve(matrix, findMax);

			// Assert
			int[] expect = { 1, -1, 0 };
			bool condition = result.SequenceEqual(expect);

			Assert.IsTrue(condition);
		}
		[TestMethod]
		public void TestHungarianAlgorithm_Scenario3()
		{
			// Arrange
			int[,] matrix = new int[3, 4];
			matrix[0, 0] = 5;
			matrix[0, 1] = 8;
			matrix[0, 2] = 9;
			matrix[0, 3] = 5;

			matrix[1, 0] = 6;
			matrix[1, 1] = 7;
			matrix[1, 2] = 7;
			matrix[1, 3] = 6;

			matrix[2, 0] = 5;
			matrix[2, 1] = 8;
			matrix[2, 2] = 8;
			matrix[2, 3] = 6;

			bool findMax = true;

			// Act
			int[] result = HungarianAssignmentSolver.Solve(matrix, findMax);

			// Assert
			int[] expect = { 2, 0, 1 };
			bool condition = result.SequenceEqual(expect);

			Assert.IsTrue(condition);
		}
		[TestMethod]
		public void TestHungarianAlgorithm_Scenario4()
		{
			// Arrange
			int[,] matrix = new int[3, 3];
			matrix[0, 0] = 1;
			matrix[0, 1] = 2;
			matrix[0, 2] = 3;

			matrix[1, 0] = 3;
			matrix[1, 1] = 3;
			matrix[1, 2] = 3;

			matrix[2, 0] = 3;
			matrix[2, 1] = 3;
			matrix[2, 2] = 2;

			bool findMax = false;

			// Act
			int[] result = HungarianAssignmentSolver.Solve(matrix, findMax);

			// Assert
			int[] expect = { 0, 1, 2 };
			bool condition = result.SequenceEqual(expect);

			Assert.IsTrue(condition);
		}
		[TestMethod]
		public void TestHungarianAlgorithm_Scenario5()
		{
			// Arrange
			int[,] matrix = new int[5, 4];
			matrix[0, 0] = 10;
			matrix[0, 1] = 19;
			matrix[0, 2] = 8;
			matrix[0, 3] = 15;

			matrix[1, 0] = 10;
			matrix[1, 1] = 18;
			matrix[1, 2] = 7;
			matrix[1, 3] = 17;

			matrix[2, 0] = 13;
			matrix[2, 1] = 16;
			matrix[2, 2] = 9;
			matrix[2, 3] = 14;

			matrix[3, 0] = 12;
			matrix[3, 1] = 19;
			matrix[3, 2] = 8;
			matrix[3, 3] = 19;

			matrix[4, 0] = 14;
			matrix[4, 1] = 17;
			matrix[4, 2] = 10;
			matrix[4, 3] = 19;

			bool findMax = false;

			// Act
			int[] result = HungarianAssignmentSolver.Solve(matrix, findMax);

			// Assert
			int[] expect = { 0, 2, 3, -1, 1 };
			bool condition = result.SequenceEqual(expect);

			Assert.IsTrue(condition);
		}
		[TestMethod]
		public void TestHungarianAlgorithm_Scenario6()
		{
			// Arrange
			int[,] matrix = new int[3, 4];
			matrix[0, 0] = 2;
			matrix[0, 1] = 4;
			matrix[0, 2] = 8;
			matrix[0, 3] = 16;

			matrix[1, 0] = 4;
			matrix[1, 1] = 10;
			matrix[1, 2] = 5;
			matrix[1, 3] = 3;

			matrix[2, 0] = 3;
			matrix[2, 1] = 5;
			matrix[2, 2] = 1;
			matrix[2, 3] = 6;

			bool findMax = false;

			// Act
			int[] result = HungarianAssignmentSolver.Solve(matrix, findMax);

			// Assert
			int[] expect = { 0, 3, 2 };
			bool condition = result.SequenceEqual(expect);

			Assert.IsTrue(condition);
		}
	}
}