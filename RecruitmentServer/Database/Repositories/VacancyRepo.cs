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

		internal int GetFilteredCount(FullSearcher searcher)
			=> ApplyFilters(searcher).Count;
		internal List<Vacancy> GetFiltered(int index, int count,
			FullSearcher searcher)
		{
			var vacancies = ApplyFilters(searcher);
			return vacancies.GetRange(index, Math.Min(vacancies.Count - index, count));
		}
		internal int GetFilteredCount(Candidate candidate,
			AccountSearchSettingsDTO accountSearch)
		{
			return ApplyFilters(accountSearch.Searcher)
				.Where(v => v.Relevance && v.Applications.All(a
					=> candidate.Login != a.Candidate.Login
					&& candidate.Password != a.Candidate.Password))
				.Count();
		}
		internal List<Vacancy> GetFiltered(Candidate candidate,
			PagedAccountSearchSettingsDTO pagedAccountSearch)
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

		private List<Vacancy> ApplyFilters(FullSearcher searcher)
		{
			var vacancies = GetAll();

			if (searcher == null)
				return vacancies.OrderByDescending(v => v.GetLocalDatePublication()).ToList();

			if (searcher.Position != null)
				vacancies = vacancies.
					Where(v => v.Position.Name.ToLower().
					Contains(searcher.Position.ToLower())).ToList();

			if (searcher.MinDate.HasValue)
				vacancies = vacancies.Where(v => v.GetLocalDatePublication() > searcher.MinDate)
					.ToList();

			if (searcher.MinValue.HasValue)
				vacancies = vacancies.
					Where(v => v.Applications.Count >= searcher.MinValue).ToList();

			if (searcher.MaxValue.HasValue)
				vacancies = vacancies.
					Where(v => v.Applications.Count <= searcher.MaxValue).ToList();

			if (searcher.IsRelevance.HasValue)
				vacancies = vacancies.
					Where(v => v.Relevance == searcher.IsRelevance).ToList();

			switch (searcher.SortOption)
			{
				case SortOption.Date:
					return vacancies.OrderByDescending(v => v.GetLocalDatePublication())
						.ToList();
				case SortOption.AlphabetPosition:
					return vacancies.OrderBy(v => v.Position.Name).ToList();
				case SortOption.NumberOfApplications:
					return vacancies.OrderByDescending(v => v.Applications.Count).ToList();
				default: return vacancies.ToList();
			}
		}
	}
}