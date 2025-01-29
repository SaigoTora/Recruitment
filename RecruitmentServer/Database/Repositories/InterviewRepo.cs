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

		internal int GetFilteredCount(FullSearcher searcher)
			=> ApplyFilters(searcher).Count;
		internal List<Interview> GetFiltered(int index, int count,
			FullSearcher searcher)
		{
			var interviews = ApplyFilters(searcher);
			return interviews.GetRange(index, Math.Min(interviews.Count - index, count));
		}
		internal int GetFilteredCount(Candidate candidate,
			AccountSearchSettingsDTO accountSearch)
		{
			return ApplyFilters(accountSearch.Searcher)
				.Where(i => candidate.Login == i.Application.Candidate.Login
					&& candidate.Password == i.Application.Candidate.Password)
				.Count();
		}
		internal List<Interview> GetFiltered(Candidate candidate,
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			var filteredList = ApplyFilters(pagedAccountSearch.Searcher)
				.Where(i => candidate.Login == i.Application.Candidate.Login
					&& candidate.Password == i.Application.Candidate.Password)
				.ToList();

			return filteredList.GetRange(pagedAccountSearch.StartIndex,
				Math.Min(filteredList.Count - pagedAccountSearch.StartIndex,
					pagedAccountSearch.Count));
		}

		private List<Interview> ApplyFilters(FullSearcher searcher)
		{
			var interviews = GetAll();

			if (searcher == null)
				return interviews.OrderByDescending(i => i.GetLocalDateEvent()).ToList();

			if (searcher.Position != null)
				interviews = interviews.
					Where(i => i.Application.Vacancy.Position.Name.ToLower().
					Contains(searcher.Position.ToLower())).ToList();

			if (searcher.MinDate.HasValue)
				interviews = interviews.
					Where(i => i.GetLocalDateEvent() > searcher.MinDate).ToList();

			if (searcher.Status != null)
				interviews = interviews.
					Where(i => i.InterviewStatus.Status == searcher.Status).ToList();

			switch (searcher.SortOption)
			{
				case SortOption.Date:
					return interviews.OrderByDescending(i => i.GetLocalDateEvent()).ToList();
				case SortOption.AlphabetPosition:
					return interviews.OrderBy(i => i.Application.Vacancy.Position.Name)
						.ToList();
				default: return interviews.ToList();
			}
		}
	}
}