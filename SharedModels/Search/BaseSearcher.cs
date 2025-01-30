using System;

namespace SharedModels.Search
{
	public class BaseSearcher
	{
		public string Position { get; private set; }
		public DateTime? MinDate { get; private set; }

		public BaseSearcher(string position, DateTime? minDate)
		{
			Position = position;
			MinDate = minDate;
		}
	}
}