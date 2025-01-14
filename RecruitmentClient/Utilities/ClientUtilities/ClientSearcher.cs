using System;

using RecruitmentLibrary.Search;

namespace RecruitmentClient.Utilities.ClientUtilities
{
	internal enum ClientSortOption : byte
	{
		Date,
		Alphabet,
		Salary
	}

	internal class ClientSearcher : Searcher
	{
		internal int? MinSalary { get; private set; }
		internal int? MaxSalary { get; private set; }
		internal ClientSortOption SortOption { get; private set; }

		internal ClientSearcher(string position, DateTime? minDate,
			int? minSalary, int? maxSalary, ClientSortOption sortOption) :
			base(position, minDate)
		{
			MinSalary = minSalary;
			MaxSalary = maxSalary;
			SortOption = sortOption;
		}

		internal new string GetFilter(string dateName)
		{
			string result = base.GetFilter(dateName);

			if (MinSalary.HasValue)
				result += $"AND salary >= {MinSalary} ";
			if (MaxSalary.HasValue)
				result += $"AND salary <= {MaxSalary} ";

			return result.TrimEnd(' ');
		}
		internal string GetSort(string dateName)
		{
			string result = "ORDER BY ";
			if (SortOption == ClientSortOption.Date)
				result += $"{dateName} DESC";
			else if (SortOption == ClientSortOption.Alphabet)
				result += "position_name ASC";
			else if (SortOption == ClientSortOption.Salary)
				result += "salary DESC";
			else
				result = string.Empty;

			return result;
		}
	}
}