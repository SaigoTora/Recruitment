using System;

namespace SharedModels.Search
{
	public enum SortOption : byte
	{
		Date,
		Salary,
		AlphabetPosition,
		NumberOfApplications,
		NumberOfPoints,
	}

	public class FullSearcher : BaseSearcher
	{
		public int? MinValue { get; private set; }
		public int? MaxValue { get; private set; }
		public bool? IsRelevance { get; private set; }
		public string Status { get; private set; }
		public SortOption SortOption { get; private set; }

		public FullSearcher(string position, DateTime? minDate, int? min, int? max,
			bool? isRelevance, string status, SortOption sortOption)
			: base(position, minDate)
		{
			MinValue = min;
			MaxValue = max;
			IsRelevance = isRelevance;
			Status = status;
			SortOption = sortOption;
		}
	}
}