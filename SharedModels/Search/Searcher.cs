using System;

namespace SharedModels.Search
{
	public class Searcher
	{
		public string Position { get; private set; }
		public DateTime? MinDate { get; private set; }

		public Searcher(string position, DateTime? minDate)
		{
			Position = position;
			MinDate = minDate;
		}
	}
}