using System;

namespace SharedModels.Search
{
	public enum SortOption : byte
	{
		Date,
		Salary,
		AlphabetPosition,
		AlphabetName,
		NumberOfApplications,
		NumberOfPoints,
	}

	public class FullSearcher : Searcher
	{
		public int? MinValue { get; private set; }
		public int? MaxValue { get; private set; }
		public bool? IsRelevance { get; private set; }
		public string Status { get; private set; }
		public string FullName { get; private set; }
		public SortOption SortOption { get; private set; }

		public FullSearcher(string position, DateTime? minDate, int? min, int? max,
			bool? isRelevance, string status, string fullName, SortOption sortOption)
			: base(position, minDate)
		{
			MinValue = min;
			MaxValue = max;
			IsRelevance = isRelevance;
			Status = status;
			FullName = fullName;
			SortOption = sortOption;
		}

		public string GetFilter(string dateName, string minMaxName)
		{
			string result = "1 = 1 " + GetFilter(dateName);

			if (MinValue != null)
				result += $"AND {minMaxName} >= {MinValue} ";
			if (MaxValue != null)
				result += $"AND {minMaxName} <= {MaxValue} ";
			if (IsRelevance != null)
				result += $"AND relevance = '{IsRelevance}' ";
			if (Status != null && Status.Length > 0)
				result += $"AND  status = '{Status}' ";
			if (FullName != null && FullName.Length > 0)
				result += $"AND surname LIKE '%{FullName}%' OR" +
					$" name LIKE '%{FullName}%' OR father_name LIKE '%{FullName}%' ";

			return result.TrimEnd(' ');
		}
		public string GetSort(string dateName)
		{
			string result = "ORDER BY ";
			if (SortOption == SortOption.Date)
				result += $"{dateName} DESC";
			else if (SortOption == SortOption.AlphabetPosition)
				result += $"position_name ASC";
			else if (SortOption == SortOption.AlphabetName)
				result += $"surname,name,father_name ASC";
			else if (SortOption == SortOption.NumberOfApplications)
				result += "application_count DESC";
			else if (SortOption == SortOption.NumberOfPoints)
				result += "scores DESC";
			else
				result = string.Empty;

			return result;
		}
	}
}