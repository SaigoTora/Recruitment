using System;
using System.Collections.Generic;
using System.Linq;

using RecruitmentServer.Database.Repositories.Base;
using SharedModels.DTOs;
using SharedModels.Models;
using SharedModels.Search;

namespace RecruitmentServer.Database.Repositories
{
	internal class ApplicationRepo : BaseRepo<Application>
	{
		internal ApplicationRepo(RecruitmentEntities context)
			: base(context)
		{ }

		internal int GetFilteredCount(FullSearcher searcher)
			=> ApplyFilters(searcher).Count;
		internal List<Application> GetFiltered(int index, int count,
			FullSearcher searcher)
		{
			var applications = ApplyFilters(searcher);
			return applications.GetRange(index, Math.Min(applications.Count - index, count));
		}
		internal int GetFilteredCount(Candidate candidate,
			AccountSearchSettingsDTO<FullSearcher> accountSearch)
		{
			return ApplyFilters(accountSearch.Searcher)
			.Where(a => candidate.Login == a.Candidate.Login
				&& candidate.Password == a.Candidate.Password)
			.Count();
		}
		internal List<Application> GetFiltered(Candidate candidate,
			PagedAccountSearchSettingsDTO<FullSearcher> pagedAccountSearch)
		{
			var filteredList = ApplyFilters(pagedAccountSearch.Searcher)
				.Where(a => candidate.Login == a.Candidate.Login
					&& candidate.Password == a.Candidate.Password)
				.ToList();

			return filteredList.GetRange(pagedAccountSearch.StartIndex,
				Math.Min(filteredList.Count - pagedAccountSearch.StartIndex,
					pagedAccountSearch.Count));
		}

		private List<Application> ApplyFilters(FullSearcher searcher)
		{
			var applications = GetAll();

			if (searcher == null)
				return applications.OrderByDescending(a => a.GetLocalDateSubmission()).ToList();

			if (searcher.Position != null)
				applications = applications.
					Where(a => a.Vacancy.Position.Name.ToLower().
					Contains(searcher.Position.ToLower())).ToList();

			if (searcher.MinDate.HasValue)
				applications = applications.
					Where(a => a.GetLocalDateSubmission() > searcher.MinDate).ToList();

			if (searcher.MinValue.HasValue)
				applications = applications.
					Where(a => a.Scores >= searcher.MinValue).ToList();

			if (searcher.MaxValue.HasValue)
				applications = applications.
					Where(a => a.Scores <= searcher.MaxValue).ToList();

			if (searcher.Status != null)
				applications = applications.
					Where(a => a.ApplicationStatus.Status == searcher.Status).ToList();

			switch (searcher.SortOption)
			{
				case SortOption.Date:
					return applications.OrderByDescending(a => a.GetLocalDateSubmission())
						.ToList();
				case SortOption.AlphabetPosition:
					return applications.OrderBy(a => a.Vacancy.Position.Name).ToList();
				case SortOption.NumberOfPoints:
					return applications.OrderByDescending(a => a.Scores).ToList();
				default: return applications.ToList();
			}
		}
	}
}