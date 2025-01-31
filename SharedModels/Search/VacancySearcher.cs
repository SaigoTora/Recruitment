using System;

namespace SharedModels.Search
{
	public enum VacancySortOption : byte
	{
		Date,
		AlphabetPosition,
		Salary,
		NumberOfApplications,
	}

	public class VacancySearcher : BaseSearcher
	{
		public int? MinSalary { get; private set; }
		public int? MaxSalary { get; private set; }
		public int? MinApplicationsCount { get; private set; }
		public int? MaxApplicationsCount { get; private set; }
		public bool? IsRelevance { get; private set; }
		public VacancySortOption SortOption { get; private set; }

		public VacancySearcher(string position, DateTime? minDate, int? minSalary, int? maxSalary,
			int? minApplicationsCount, int? maxApplicationsCount, bool? isRelevance,
			VacancySortOption sortOption)
			: base(position, minDate)
		{
			MinSalary = minSalary;
			MaxSalary = maxSalary;
			MinApplicationsCount = minApplicationsCount;
			MaxApplicationsCount = maxApplicationsCount;
			IsRelevance = isRelevance;
			SortOption = sortOption;
		}
	}
}