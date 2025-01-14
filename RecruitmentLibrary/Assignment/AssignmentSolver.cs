using System;

namespace RecruitmentLibrary.Assignment
{
	public class AssignmentSolver
	{
		private readonly struct Location
		{
			internal readonly int row;
			internal readonly int column;

			internal Location(int row, int column)
			{
				this.row = row;
				this.column = column;
			}
		}

		public static int[] HungarianAlgorithm(int[,] costs, bool findMax)
		{
			if (costs == null)
				throw new ArgumentNullException(nameof(costs));

			int n = costs.GetLength(0);// Initial matrix dimensions
			int m = costs.GetLength(1);
			if (costs.GetLength(0) != costs.GetLength(1))
				costs = CreateSquareMatrix(costs);

			if (findMax)
			{// If the assignment is resolved to the maximum
				for (int i = 0; i < costs.GetLength(0); i++)
				{
					int max = costs[i, 0];
					for (int j = 0; j < costs.GetLength(1); j++)
						max = Math.Max(max, costs[i, j]);

					for (int j = 0; j < costs.GetLength(1); j++)
						costs[i, j] = max - costs[i, j];
				}
			}

			int height = costs.GetLength(0);
			int width = costs.GetLength(1);

			for (int i = 0; i < height; i++)
			{// Row reduction
				int min = int.MaxValue;// Minimum value in the current row
				for (int j = 0; j < width; j++)
					min = Math.Min(min, costs[i, j]);

				for (int j = 0; j < width; j++)
					costs[i, j] -= min;
			}
			for (int i = 0; i < width; i++)
			{// Column reduction
				int min = int.MaxValue;// Minimum value in the current column
				for (int j = 0; j < height; j++)
					min = Math.Min(min, costs[j, i]);

				for (int j = 0; j < height; j++)
					costs[j, i] -= min;
			}

			byte[,] masks = new byte[height, width];
			bool[] rowsCovered = new bool[height];
			bool[] colsCovered = new bool[width];

			// Obtaining a mask, where we denote by the number 1 those elements that
			// are zero in the original matrix and do not have 0 at the intersection
			for (int i = 0; i < height; i++)
				for (int j = 0; j < width; j++)
					if (costs[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
					{
						masks[i, j] = 1;
						rowsCovered[i] = true;
						colsCovered[j] = true;
					}

			ClearCovers(rowsCovered, colsCovered);

			Location[] path = new Location[width * height];
			Location pathStart = default;
			int step = 1;

			while (step != -1)
			{
				if (step == 1)
					step = RunStep1(masks, colsCovered);
				if (step == 2)
					step = RunStep2(costs, masks, rowsCovered, colsCovered, ref pathStart);
				if (step == 3)
					step = RunStep3(masks, rowsCovered, colsCovered, path, pathStart);
				if (step == 4)
					step = RunStep4(costs, rowsCovered, colsCovered);
			}

			// Convert the mask matrix to the desired size
			byte[,] newMasks = new byte[n, m];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					newMasks[i, j] = masks[i, j];

			// The resulting array, where the index is the worker and the value is the task
			int[] agentsTasks = new int[newMasks.GetLength(0)];

			for (int i = 0; i < newMasks.GetLength(0); i++)
				for (int j = 0; j < newMasks.GetLength(1); j++)
				{
					if (newMasks[i, j] == 1)
					{
						agentsTasks[i] = j;
						break;
					}
					else if (j == newMasks.GetLength(1) - 1)
						agentsTasks[i] = -1;// If the worker was not up to the task
				}

			return agentsTasks;
		}

		private static int[,] CreateSquareMatrix(int[,] matrix)
		{
			if (matrix.GetLength(0) == matrix.GetLength(1))
				return matrix;

			int maxLength = Math.Max(matrix.GetLength(0), matrix.GetLength(1));
			int[,] buf = new int[maxLength, maxLength];
			int max = matrix[0, 0];

			for (int i = 0; i < matrix.GetLength(0); i++)// Writing existing elements into an array
				for (int j = 0; j < matrix.GetLength(1); j++)// and finding the maximum
				{
					buf[i, j] = matrix[i, j];
					max = Math.Max(max, matrix[i, j]);
				}

			if (matrix.GetLength(0) > matrix.GetLength(1))
			{// If there are more rows than columns
				for (int i = 0; i < matrix.GetLength(0); i++)
					for (int j = matrix.GetLength(1); j < matrix.GetLength(0); j++)
						buf[i, j] = max;
			}
			else
			{// If there are more columns than rows
				for (int i = matrix.GetLength(0); i < matrix.GetLength(1); i++)
					for (int j = 0; j < matrix.GetLength(1); j++)
						buf[i, j] = max;
			}
			return buf;
		}
		private static int RunStep1(byte[,] masks, bool[] colsCovered)
		{// Method that fills the colsCovered array and returns the next step number (2 or -1)
			if (masks == null)
				throw new ArgumentNullException(nameof(masks));

			if (colsCovered == null)
				throw new ArgumentNullException(nameof(colsCovered));

			// Mark the data in colsCovered
			for (int i = 0; i < masks.GetLength(0); i++)
				for (int j = 0; j < masks.GetLength(1); j++)
					if (masks[i, j] == 1)
						colsCovered[j] = true;

			// Find the number of crossed out columns
			int colsCoveredCount = 0;
			for (int j = 0; j < colsCovered.Length; j++)
				if (colsCovered[j])
					colsCoveredCount++;

			// If all columns are crossed out, this is the last step in the cycle.
			if (colsCoveredCount == colsCovered.Length)
				return -1;

			return 2;
		}
		private static int RunStep2(int[,] costs, byte[,] masks, bool[] rowsCovered,
			bool[] colsCovered, ref Location pathStart)
		{// Method that modifies the colsCovered and rowsCovered arrays
		 // and also returns the next step number (4 or 3)
			if (costs == null)
				throw new ArgumentNullException(nameof(costs));
			if (masks == null)
				throw new ArgumentNullException(nameof(masks));
			if (rowsCovered == null)
				throw new ArgumentNullException(nameof(rowsCovered));
			if (colsCovered == null)
				throw new ArgumentNullException(nameof(colsCovered));

			while (true)
			{
				Location location = FindZero(costs, rowsCovered, colsCovered);
				if (location.row == -1)// If no uncrossed zero was found
					return 4;

				masks[location.row, location.column] = 2;

				int indexCol = FindIndexInRow(masks, location.row);
				if (indexCol != -1)
				{// If the index was found
					rowsCovered[location.row] = true;
					colsCovered[indexCol] = false;
				}
				else
				{
					pathStart = location;
					return 3;
				}
			}
		}
		private static int RunStep3(byte[,] masks, bool[] rowsCovered,
			bool[] colsCovered, Location[] path, Location pathStart)
		{// Method that modifies the path array and also returns the next step number(1)
			if (masks == null)
				throw new ArgumentNullException(nameof(masks));

			if (rowsCovered == null)
				throw new ArgumentNullException(nameof(rowsCovered));

			if (colsCovered == null)
				throw new ArgumentNullException(nameof(colsCovered));

			int pathIndex = 0;
			path[0] = pathStart;

			while (true)
			{
				int row = FindIndexInColumn(masks, path[pathIndex].column);
				if (row == -1)
					break;

				pathIndex++;
				path[pathIndex] = new Location(row, path[pathIndex - 1].column);

				int col = FindPrimeInRow(masks, path[pathIndex].row);

				pathIndex++;
				path[pathIndex] = new Location(path[pathIndex - 1].row, col);
			}

			ConvertPath(masks, path, pathIndex + 1);
			ClearCovers(rowsCovered, colsCovered);
			ClearPrimes(masks);

			return 1;
		}
		private static int RunStep4(int[,] costs, bool[] rowsCovered, bool[] colsCovered)
		{// Method that changes the data in costs and returns the next step number(2)
			if (costs == null)
				throw new ArgumentNullException(nameof(costs));

			if (rowsCovered == null)
				throw new ArgumentNullException(nameof(rowsCovered));

			if (colsCovered == null)
				throw new ArgumentNullException(nameof(colsCovered));

			int minValue = FindMinimum(costs, rowsCovered, colsCovered);

			// Add or subtract the minimum depending on the strikethrough
			for (int i = 0; i < costs.GetLength(0); i++)
				for (int j = 0; j < costs.GetLength(1); j++)
				{
					if (rowsCovered[i])
						costs[i, j] += minValue;
					if (!colsCovered[j])
						costs[i, j] -= minValue;
				}

			return 2;
		}

		private static int FindMinimum(int[,] costs, bool[] rowsCovered, bool[] colsCovered)
		{// Method that finds the minimum value among NOT crossed out elements
			if (costs == null)
				throw new ArgumentNullException(nameof(costs));
			if (rowsCovered == null)
				throw new ArgumentNullException(nameof(rowsCovered));
			if (colsCovered == null)
				throw new ArgumentNullException(nameof(colsCovered));

			int minValue = int.MaxValue;

			for (int i = 0; i < costs.GetLength(0); i++)
				for (int j = 0; j < costs.GetLength(1); j++)
					if (!rowsCovered[i] && !colsCovered[j])
						minValue = Math.Min(minValue, costs[i, j]);

			return minValue;
		}
		private static int FindIndexInRow(byte[,] masks, int row)
		{// The method returns the column index if there is a unit in a particular row
			if (masks == null)
				throw new ArgumentNullException(nameof(masks));

			for (int j = 0; j < masks.GetLength(1); j++)
				if (masks[row, j] == 1)
					return j;

			return -1;// If not found
		}
		private static int FindIndexInColumn(byte[,] masks, int col)
		{// The method returns the row index if there is a unit in a certain column
			if (masks == null)
				throw new ArgumentNullException(nameof(masks));

			for (int i = 0; i < masks.GetLength(0); i++)
				if (masks[i, col] == 1)
					return i;

			return -1;// If not found
		}
		private static int FindPrimeInRow(byte[,] masks, int row)
		{// The method returns the column index if there is a two in a given row
			if (masks == null)
				throw new ArgumentNullException(nameof(masks));

			for (int j = 0; j < masks.GetLength(1); j++)
				if (masks[row, j] == 2)
					return j;

			return -1;// If not found
		}
		private static Location FindZero(int[,] costs, bool[] rowsCovered, bool[] colsCovered)
		{// The method returns the position of the first uncrossed zero
			if (costs == null)
				throw new ArgumentNullException(nameof(costs));
			if (rowsCovered == null)
				throw new ArgumentNullException(nameof(rowsCovered));
			if (colsCovered == null)
				throw new ArgumentNullException(nameof(colsCovered));

			for (int i = 0; i < costs.GetLength(0); i++)
				for (int j = 0; j < costs.GetLength(1); j++)
					if (costs[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
						return new Location(i, j);

			// If zero was not found
			return new Location(-1, -1);
		}
		private static void ConvertPath(byte[,] masks, Location[] path, int pathLength)
		{// A method that modifies the data in the masks matrix
			if (masks == null)
				throw new ArgumentNullException(nameof(masks));

			if (path == null)
				throw new ArgumentNullException(nameof(path));

			int row, column;
			for (int i = 0; i < pathLength; i++)
			{
				row = path[i].row;
				column = path[i].column;

				if (masks[row, column] == 1)
					masks[row, column] = 0;

				else if (masks[row, column] == 2)
					masks[row, column] = 1;
			}
		}
		private static void ClearPrimes(byte[,] masks)
		{// Method that writes 0 for elements with value 2
			if (masks == null)
				throw new ArgumentNullException(nameof(masks));

			for (var i = 0; i < masks.GetLength(0); i++)
				for (var j = 0; j < masks.GetLength(1); j++)
					if (masks[i, j] == 2)
						masks[i, j] = 0;
		}
		private static void ClearCovers(bool[] rowsCovered, bool[] colsCovered)
		{// Method that writes false for boolean arrays
			if (rowsCovered == null)
				throw new ArgumentNullException(nameof(rowsCovered));
			if (colsCovered == null)
				throw new ArgumentNullException(nameof(colsCovered));

			if (rowsCovered.Length == colsCovered.Length)
				for (int i = 0; i < rowsCovered.Length; i++)
				{// If they are the same length
					rowsCovered[i] = false;
					colsCovered[i] = false;
				}
			else
			{// If their lengths are different
				for (int i = 0; i < rowsCovered.Length; i++)
					rowsCovered[i] = false;
				for (int i = 0; i < colsCovered.Length; i++)
					colsCovered[i] = false;
			}
		}
	}
}