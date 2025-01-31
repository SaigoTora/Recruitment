using System;

namespace SharedModels.Search
{
	public enum InterviewSortOption : byte
	{
		Date,
		AlphabetPosition,
	}

	public class InterviewSearcher : BaseSearcher
	{
		public string Status { get; private set; }
		public InterviewSortOption SortOption { get; private set; }

		public InterviewSearcher(string position, DateTime? minDate, string status,
			InterviewSortOption sortOption)
			: base(position, minDate)
		{
			Status = status;
			SortOption = sortOption;
		}
	}
}