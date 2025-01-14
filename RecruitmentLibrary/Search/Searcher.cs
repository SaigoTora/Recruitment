using System;

namespace RecruitmentLibrary.Search
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

		public string GetFilter(string dateName)
		{
			string result = string.Empty;
			if (Position != null && Position.Length != 0)
				result += $"AND position_name LIKE '%{Position}%' ";
			if (MinDate != null)
				result += $"AND {dateName} > '{MinDate:yyyy-MM-dd}' ";

			return result;
		}
	}
}