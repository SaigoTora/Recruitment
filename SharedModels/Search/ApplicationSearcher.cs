using System;

namespace SharedModels.Search
{
	public enum ApplicationSortOption : byte
	{
		Date,
		AlphabetPosition,
		NumberOfPoints,
	}

	public class ApplicationSearcher : BaseSearcher
	{
		public int? MinPoints { get; private set; }
		public int? MaxPoints { get; private set; }
		public string Status { get; private set; }
		public ApplicationSortOption SortOption { get; private set; }

		public ApplicationSearcher(string position, DateTime? minDate, int? minPoints, int? maxPoints,
			string status, ApplicationSortOption sortOption)
			: base(position, minDate)
		{
			MinPoints = minPoints;
			MaxPoints = maxPoints;
			Status = status;
			SortOption = sortOption;
		}
	}
}