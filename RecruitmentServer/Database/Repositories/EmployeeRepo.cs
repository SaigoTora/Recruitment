using System;
using System.Collections.Generic;
using System.Linq;

using RecruitmentServer.Database.Repositories.Base;
using SharedModels.Models;
using SharedModels.Search;

namespace RecruitmentServer.Database.Repositories
{
	internal class EmployeeRepo : BaseRepo<Employee>
	{
		internal EmployeeRepo(RecruitmentEntities context)
			: base(context)
		{ }

		internal int GetFilteredCount(FullSearcher searcher)
			=> ApplyFilters(searcher).Count;
		internal List<Employee> GetFiltered(int index, int count,
			FullSearcher searcher)
		{
			var employees = ApplyFilters(searcher);
			return employees.GetRange(index, Math.Min(employees.Count - index, count));
		}

		private List<Employee> ApplyFilters(FullSearcher searcher)
		{
			var employees = GetAll();

			if (searcher == null)
				return employees.OrderByDescending(e => e.DateEmployment).ToList();

			if (searcher.Position != null)
				employees = employees.
					Where(e => e.Interview.Application.Vacancy.Position.Name.ToLower().
					Contains(searcher.Position.ToLower())).ToList();

			if (searcher.FullName != null)
				employees = employees.
					Where(e => e.GetFullName.ToLower().
					Contains(searcher.FullName.ToLower())).ToList();

			if (searcher.MinDate.HasValue)
				employees = employees.
					Where(e => e.DateEmployment > searcher.MinDate).ToList();

			switch (searcher.SortOption)
			{
				case SortOption.Date:
					return employees.OrderByDescending(e => e.DateEmployment).ToList();
				case SortOption.AlphabetPosition:
					return employees.
						OrderBy(e => e.Interview.Application.Vacancy.Position.Name).ToList();
				case SortOption.AlphabetName:
					return employees.OrderBy(e => e.GetFullName).ToList();
				default: return employees.ToList();
			}
		}
	}
}