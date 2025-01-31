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

		#region Applying filters
		private List<Employee> ApplyFilters(EmployeeSearcher searcher)
		{
			IEnumerable<Employee> employees = GetAll();

			if (searcher == null)
				return employees.OrderByDescending(e => e.DateEmployment).ToList();

			employees = ApplyBaseFilters(employees, searcher);

			if (searcher.FullName != null)
				employees = employees.Where(e => e.GetFullName.ToLower().
					Contains(searcher.FullName.ToLower()));

			return ApplySorting(employees, searcher.SortOption).ToList();
		}

		private IEnumerable<Employee> ApplyBaseFilters(IEnumerable<Employee> employees,
			BaseSearcher baseSearcher)
		{
			if (baseSearcher.Position != null)
				employees = employees.
					Where(e => e.Interview.Application.Vacancy.Position.Name.ToLower().
						Contains(baseSearcher.Position.ToLower()));

			if (baseSearcher.MinDate.HasValue)
				employees = employees.
					Where(e => e.DateEmployment > baseSearcher.MinDate);

			return employees;
		}
		private IEnumerable<Employee> ApplySorting(IEnumerable<Employee> employees,
			EmployeeSortOption sortOption)
		{
			switch (sortOption)
			{
				case EmployeeSortOption.Date:
					return employees.OrderByDescending(e => e.DateEmployment);
				case EmployeeSortOption.AlphabetPosition:
					return employees.OrderBy(e => e.Interview.Application.Vacancy.Position.Name);
				case EmployeeSortOption.AlphabetName:
					return employees.OrderBy(e => e.GetFullName);
				default: return employees;
			}
		}
		#endregion
	}
}