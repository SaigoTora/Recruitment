using System;
using System.Linq;

namespace RecruitmentLibrary.Assignment
{
	public static class AuctionAssignmentSolver
	{
		private static int[] _agentsTasks;
		private static double[] _prices;

		public static int[] Solve(int[,] costs, bool findMax)
		{
			int n = costs.GetLength(0), m = costs.GetLength(1);
			int minDimension = Math.Min(n, m);
			bool? hasMoreRows = null;
			if (n > m) hasMoreRows = true;
			else if (n < m) hasMoreRows = false;

			if (n != m)
				costs = CreateSquareMatrix(costs);
			n = costs.GetLength(0);

			_agentsTasks = new int[n];
			_prices = new double[n];
			for (int i = 0; i < n; i++)
				_agentsTasks[i] = -1;

			return RunAuctionIteration(costs, n, findMax, minDimension, hasMoreRows);
		}

		private static int[,] CreateSquareMatrix(int[,] matrix)
		{
			int n = matrix.GetLength(0), m = matrix.GetLength(1);
			if (n == m)
				return matrix;

			int maxLength = Math.Max(n, m);
			int[,] result = new int[maxLength, maxLength];

			for (int i = 0; i < maxLength; i++)
				for (int j = 0; j < maxLength; j++)
				{
					if (i >= n || j >= m)
						result[i, j] = -1;
					else
						result[i, j] = matrix[i, j];
				}

			return result;
		}

		private static int[] RunAuctionIteration(int[,] costs, int n, bool findMax,
			int minDimension, bool? hasMoreRows)
		{
			double epsilon = 1.0 / (n + 1);

			bool unassignedExists;
			do
			{
				unassignedExists = false;
				for (int agent = 0; agent < n; agent++)
				{
					if (_agentsTasks[agent] != -1)
						continue;

					unassignedExists = true;
					(int bestTask, double bestValue, double secondBestValue) = GetBestTasks(costs,
						n, agent, findMax);

					if (bestTask != -1)
					{
						double bid = bestValue - secondBestValue + epsilon;
						SetPricesAndAgentsTasks(n, agent, bestTask, bid);
					}
				}
			} while (unassignedExists);

			return GenerateAgentsTasks(n, minDimension, hasMoreRows);
		}
		private static (int bestTask, double bestValue, double secondBestValue) GetBestTasks(
			int[,] costs, int n, int agent, bool findMax)
		{
			int bestTask = -1;
			double bestValue = double.NegativeInfinity, secondBestValue = double.NegativeInfinity;

			for (int task = 0; task < n; task++)
			{
				double value = (findMax ? costs[agent, task] : -costs[agent, task])
					- _prices[task];
				if (value > bestValue)
				{
					secondBestValue = bestValue;
					bestValue = value;
					bestTask = task;
				}
				else if (value > secondBestValue)
					secondBestValue = value;
			}

			return (bestTask, bestValue, secondBestValue);
		}
		private static void SetPricesAndAgentsTasks(int n, int agent, int bestTask, double bid)
		{
			_prices[bestTask] += bid;

			for (int otherAgent = 0; otherAgent < n; otherAgent++)
				if (_agentsTasks[otherAgent] == bestTask)
				{
					_agentsTasks[otherAgent] = -1;
					break;
				}

			_agentsTasks[agent] = bestTask;
		}
		private static int[] GenerateAgentsTasks(int n, int minDimension, bool? hasMoreRows)
		{
			if (hasMoreRows.HasValue)
			{
				if (hasMoreRows.Value)
				{
					for (int i = 0; i < n; i++)
						if (_agentsTasks[i] >= minDimension)
							_agentsTasks[i] = -1;
				}
				else
					return _agentsTasks.Take(minDimension).ToArray();
			}

			return _agentsTasks;
		}
	}
}