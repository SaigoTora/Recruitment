using System;

using RecruitmentLibrary.ApplicationInfo;

namespace RecruitmentServer.Utilities.ServerUtilities
{
	internal enum ServerSortOption : byte
	{
		Date,
		AlphabetPosition,
		AlphabetName,
		NumberOfApplications,
		NumberOfPoints,
	}

	internal class ServerSearcher : Searcher
	{
		internal int? MinValue { get; private set; }
		internal int? MaxValue { get; private set; }
		internal bool? IsRelevance { get; private set; }
		internal string Status { get; private set; }
		internal string FullName { get; private set; }
		internal ServerSortOption SortOption { get; private set; }

		internal ServerSearcher(string position, DateTime? minDate, int? min, int? max,
			bool? isRelevance, string status, string fullName, ServerSortOption sortOption)
			: base(position, minDate)
		{
			MinValue = min;
			MaxValue = max;
			IsRelevance = isRelevance;
			Status = status;
			FullName = fullName;
			SortOption = sortOption;
		}

		internal string GetFilter(string dateName, string minMaxName)
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
		internal string GetSort(string dateName)
		{
			string result = "ORDER BY ";
			if (SortOption == ServerSortOption.Date)
				result += $"{dateName} DESC";
			else if (SortOption == ServerSortOption.AlphabetPosition)
				result += $"position_name ASC";
			else if (SortOption == ServerSortOption.AlphabetName)
				result += $"surname,name,father_name ASC";
			else if (SortOption == ServerSortOption.NumberOfApplications)
				result += "application_count DESC";
			else if (SortOption == ServerSortOption.NumberOfPoints)
				result += "scores DESC";
			else
				result = string.Empty;

			return result;
		}
	}
}