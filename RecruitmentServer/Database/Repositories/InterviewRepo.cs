using System;
using System.Collections.Generic;
using System.Linq;

using RecruitmentServer.Database.Repositories.Base;
using SharedModels.DTOs;
using SharedModels.Models;
using SharedModels.Search;

namespace RecruitmentServer.Database.Repositories
{
	internal class InterviewRepo : BaseRepo<Interview>
	{
		internal InterviewRepo(RecruitmentEntities context)
			: base(context)
		{ }

		internal int GetFilteredCount(InterviewSearcher searcher)
			=> ApplyFilters(searcher).Count;
		internal List<Interview> GetFiltered(int index, int count,
			InterviewSearcher searcher)
		{
			var interviews = ApplyFilters(searcher);
			return interviews.GetRange(index, Math.Min(interviews.Count - index, count));
		}
		internal int GetFilteredCount(Candidate candidate,
			AccountSearchSettingsDTO<InterviewSearcher> accountSearch)
		{
			return ApplyFilters(accountSearch.Searcher)
				.Where(i => candidate.Login == i.Application.Candidate.Login
					&& candidate.Password == i.Application.Candidate.Password)
				.Count();
		}
		internal List<Interview> GetFiltered(Candidate candidate,
			PagedAccountSearchSettingsDTO<InterviewSearcher> pagedAccountSearch)
		{
			var filteredList = ApplyFilters(pagedAccountSearch.Searcher)
				.Where(i => candidate.Login == i.Application.Candidate.Login
					&& candidate.Password == i.Application.Candidate.Password)
				.ToList();

			return filteredList.GetRange(pagedAccountSearch.StartIndex,
				Math.Min(filteredList.Count - pagedAccountSearch.StartIndex,
					pagedAccountSearch.Count));
		}

		#region Applying filters
		private List<Interview> ApplyFilters(InterviewSearcher searcher)
		{
			IEnumerable<Interview> interviews = GetAll();

			if (searcher == null)
				return interviews.OrderByDescending(i => i.GetLocalDateEvent()).ToList();

			interviews = ApplyBaseFilters(interviews, searcher);

			if (searcher.Status != null)
				interviews = interviews.
					Where(i => i.InterviewStatus.Status == searcher.Status);

			return ApplySorting(interviews, searcher.SortOption).ToList();
		}

		private IEnumerable<Interview> ApplyBaseFilters(IEnumerable<Interview> interviews,
			BaseSearcher baseSearcher)
		{
			if (baseSearcher.Position != null)
				interviews = interviews.
					Where(i => i.Application.Vacancy.Position.Name.ToLower().
					Contains(baseSearcher.Position.ToLower()));

			if (baseSearcher.MinDate.HasValue)
				interviews = interviews.
					Where(i => i.GetLocalDateEvent() > baseSearcher.MinDate);

			return interviews;
		}
		private IEnumerable<Interview> ApplySorting(IEnumerable<Interview> interviews,
			InterviewSortOption sortOption)
		{
			switch (sortOption)
			{
				case InterviewSortOption.Date:
					return interviews.OrderByDescending(i => i.GetLocalDateEvent());
				case InterviewSortOption.AlphabetPosition:
					return interviews.OrderBy(i => i.Application.Vacancy.Position.Name);
				default: return interviews;
			}
		}
		#endregion
	}
}