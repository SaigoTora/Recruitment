using Newtonsoft.Json;
using SharedModels.Search;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class PagedAccountSearchSettingsDTO<T> : AccountSearchSettingsDTO<T> where T : BaseSearcher
	{
		[JsonProperty]
		public int StartIndex { get; private set; }
		[JsonProperty]
		public int Count { get; private set; }

		[JsonConstructor]
		public PagedAccountSearchSettingsDTO(CandidateLoginDTO candidateLogin,
			T searcher, int startIndex, int count)
			: base(candidateLogin, searcher)
		{
			StartIndex = startIndex;
			Count = count;
		}
	}
}