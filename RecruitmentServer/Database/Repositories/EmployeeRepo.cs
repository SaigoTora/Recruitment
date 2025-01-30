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

		internal int GetFilteredCount(EmployeeSearcher searcher)
			=> ApplyFilters(searcher).Count;
		internal List<Employee> GetFiltered(int index, int count,
			EmployeeSearcher searcher)
		{
			var employees = ApplyFilters(searcher);
			return employees.GetRange(index, Math.Min(employees.Count - index, count));
		}

		private List<Employee> ApplyFilters(EmployeeSearcher searcher)
		{
			var employees = GetAll();

			if (searcher == null)
				return employees.OrderByDescending(e => e.DateEmployment).ToList();

			if (!string.IsNullOrEmpty(searcher.Position))
				employees = employees.
					Where(e => e.Interview.Application.Vacancy.Position.Name.ToLower().
						Contains(searcher.Position.ToLower())).ToList();

			if (!string.IsNullOrEmpty(searcher.FullName))
				employees = employees.
					Where(e => e.GetFullName.ToLower().
						Contains(searcher.FullName.ToLower())).ToList();

			if (searcher.MinDate.HasValue)
				employees = employees.
					Where(e => e.DateEmployment > searcher.MinDate).ToList();

			switch (searcher.SortOption)
			{
				case EmployeeSortOption.Date:
					return employees.OrderByDescending(e => e.DateEmployment).ToList();
				case EmployeeSortOption.AlphabetPosition:
					return employees
						.OrderBy(e => e.Interview.Application.Vacancy.Position.Name).ToList();
				case EmployeeSortOption.AlphabetName:
					return employees.OrderBy(e => e.GetFullName).ToList();

				default: return employees.ToList();
			}
		}
	}
}