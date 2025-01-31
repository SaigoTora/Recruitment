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

		internal int GetFilteredCount(ApplicationSearcher searcher)
			=> ApplyFilters(searcher).Count;
		internal List<Application> GetFiltered(int index, int count,
			ApplicationSearcher searcher)
		{
			var applications = ApplyFilters(searcher);
			return applications.GetRange(index, Math.Min(applications.Count - index, count));
		}
		internal int GetFilteredCount(Candidate candidate,
			AccountSearchSettingsDTO<ApplicationSearcher> accountSearch)
		{
			return ApplyFilters(accountSearch.Searcher)
			.Where(a => candidate.Login == a.Candidate.Login
				&& candidate.Password == a.Candidate.Password)
			.Count();
		}
		internal List<Application> GetFiltered(Candidate candidate,
			PagedAccountSearchSettingsDTO<ApplicationSearcher> pagedAccountSearch)
		{
			var filteredList = ApplyFilters(pagedAccountSearch.Searcher)
				.Where(a => candidate.Login == a.Candidate.Login
					&& candidate.Password == a.Candidate.Password)
				.ToList();

			return filteredList.GetRange(pagedAccountSearch.StartIndex,
				Math.Min(filteredList.Count - pagedAccountSearch.StartIndex,
					pagedAccountSearch.Count));
		}

		#region Applying filters
		private List<Application> ApplyFilters(ApplicationSearcher searcher)
		{
			IEnumerable<Application> applications = GetAll();

			if (searcher == null)
				return applications.OrderByDescending(a => a.GetLocalDateSubmission()).ToList();

			applications = ApplyBaseFilters(applications, searcher);
			applications = FilterByPoints(applications, searcher.MinPoints, searcher.MaxPoints);

			if (searcher.Status != null)
				applications = applications.Where(a => a.ApplicationStatus.Status == searcher.Status);

			return ApplySorting(applications, searcher.SortOption).ToList();
		}

		private IEnumerable<Application> ApplyBaseFilters(IEnumerable<Application> applications,
			BaseSearcher baseSearcher)
		{
			if (baseSearcher.Position != null)
				applications = applications.
					Where(a => a.Vacancy.Position.Name.ToLower().
					Contains(baseSearcher.Position.ToLower()));

			if (baseSearcher.MinDate.HasValue)
				applications = applications.
					Where(a => a.GetLocalDateSubmission() > baseSearcher.MinDate);

			return applications;
		}
		private IEnumerable<Application> FilterByPoints(IEnumerable<Application> applications,
			int? min, int? max)
		{
			if (min.HasValue)
				applications = applications.
					Where(a => a.Scores >= min);

			if (max.HasValue)
				applications = applications.
					Where(a => a.Scores <= max);

			return applications;
		}
		private IEnumerable<Application> ApplySorting(IEnumerable<Application> applications,
			ApplicationSortOption sortOption)
		{
			switch (sortOption)
			{
				case ApplicationSortOption.Date:
					return applications.OrderByDescending(a => a.GetLocalDateSubmission());
				case ApplicationSortOption.AlphabetPosition:
					return applications.OrderBy(a => a.Vacancy.Position.Name);
				case ApplicationSortOption.NumberOfPoints:
					return applications.OrderByDescending(a => a.Scores);
				default: return applications;
			}
		}
		#endregion
	}
}