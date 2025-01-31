using System;
using System.Collections.Generic;
using System.Linq;

using RecruitmentServer.Database.Repositories.Base;
using SharedModels.DTOs;
using SharedModels.Models;
using SharedModels.Search;

namespace RecruitmentServer.Database.Repositories
{
	internal class VacancyRepo : BaseRepo<Vacancy>
	{
		internal VacancyRepo(RecruitmentEntities context)
			: base(context)
		{ }

		internal int GetFilteredCount(VacancySearcher searcher)
			=> ApplyFilters(searcher).Count;
		internal List<Vacancy> GetFiltered(int index, int count,
			VacancySearcher searcher)
		{
			var vacancies = ApplyFilters(searcher);
			return vacancies.GetRange(index, Math.Min(vacancies.Count - index, count));
		}
		internal int GetFilteredCount(Candidate candidate,
			AccountSearchSettingsDTO<VacancySearcher> accountSearch)
		{
			return ApplyFilters(accountSearch.Searcher)
				.Where(v => v.Relevance && v.Applications.All(a
					=> candidate.Login != a.Candidate.Login
					&& candidate.Password != a.Candidate.Password))
				.Count();
		}
		internal List<Vacancy> GetFiltered(Candidate candidate,
			PagedAccountSearchSettingsDTO<VacancySearcher> pagedAccountSearch)
		{
			var filteredList = ApplyFilters(pagedAccountSearch.Searcher)
				.Where(v => v.Relevance && v.Applications.All(a
					=> candidate.Login != a.Candidate.Login
					&& candidate.Password != a.Candidate.Password))
				.ToList();

			return filteredList.GetRange(pagedAccountSearch.StartIndex,
				Math.Min(filteredList.Count - pagedAccountSearch.StartIndex,
					pagedAccountSearch.Count));
		}

		#region Applying filters
		private List<Vacancy> ApplyFilters(VacancySearcher searcher)
		{
			IEnumerable<Vacancy> vacancies = GetAll();

			if (searcher == null)
				return vacancies.OrderByDescending(v => v.GetLocalDatePublication()).ToList();

			vacancies = ApplyBaseFilters(vacancies, searcher);
			vacancies = FilterBySalary(vacancies, searcher.MinSalary,
				searcher.MaxSalary);
			vacancies = FilterByApplicationsCount(vacancies, searcher.MinApplicationsCount,
				searcher.MaxApplicationsCount);

			if (searcher.IsRelevance.HasValue)
				vacancies = vacancies.Where(v => v.Relevance == searcher.IsRelevance);

			return ApplySorting(vacancies, searcher.SortOption).ToList();
		}

		private IEnumerable<Vacancy> ApplyBaseFilters(IEnumerable<Vacancy> vacancies,
			BaseSearcher baseSearcher)
		{
			if (baseSearcher.Position != null)
				vacancies = vacancies.
					Where(v => v.Position.Name.ToLower().
					Contains(baseSearcher.Position.ToLower()));

			if (baseSearcher.MinDate.HasValue)
				vacancies = vacancies.Where(v => v.GetLocalDatePublication() > baseSearcher.MinDate);

			return vacancies;
		}
		private IEnumerable<Vacancy> FilterByApplicationsCount(IEnumerable<Vacancy> vacancies,
			int? min, int? max)
		{
			if (min.HasValue)
				vacancies = vacancies.Where(v => v.Applications.Count >= min);
			if (max.HasValue)
				vacancies = vacancies.Where(v => v.Applications.Count <= max);

			return vacancies;
		}
		private IEnumerable<Vacancy> FilterBySalary(IEnumerable<Vacancy> vacancies,
			int? min, int? max)
		{
			if (min.HasValue)
				vacancies = vacancies.Where(v => v.Salary >= min);
			if (max.HasValue)
				vacancies = vacancies.Where(v => v.Salary <= max);

			return vacancies;
		}
		private IEnumerable<Vacancy> ApplySorting(IEnumerable<Vacancy> vacancies,
			VacancySortOption sortOption)
		{
			switch (sortOption)
			{
				case VacancySortOption.Date:
					return vacancies.OrderByDescending(v => v.GetLocalDatePublication());
				case VacancySortOption.AlphabetPosition:
					return vacancies.OrderBy(v => v.Position.Name);
				case VacancySortOption.Salary:
					return vacancies.OrderByDescending(v => v.Salary);
				case VacancySortOption.NumberOfApplications:
					return vacancies.OrderByDescending(v => v.Applications.Count);
				default:
					return vacancies;
			}
		}
		#endregion
	}
}