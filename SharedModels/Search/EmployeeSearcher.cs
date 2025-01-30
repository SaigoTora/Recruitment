using System;

namespace SharedModels.Search
{
	public enum EmployeeSortOption : byte
	{
		Date,
		AlphabetPosition,
		AlphabetName,
	}

	public class EmployeeSearcher : BaseSearcher
	{
		public string FullName { get; private set; }
		public EmployeeSortOption SortOption { get; private set; }

		public EmployeeSearcher(string position, DateTime? minDate, string fullName,
			EmployeeSortOption sortOption)
			: base(position, minDate)
		{
			FullName = fullName;
			SortOption = sortOption;
		}
	}
}