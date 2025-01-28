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
	}
}