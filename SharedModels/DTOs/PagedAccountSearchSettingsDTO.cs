using Newtonsoft.Json;
using SharedModels.Search;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class PagedAccountSearchSettingsDTO : AccountSearchSettingsDTO
	{
		[JsonProperty]
		public int StartIndex { get; private set; }
		[JsonProperty]
		public int Count { get; private set; }

		[JsonConstructor]
		public PagedAccountSearchSettingsDTO(CandidateLoginDTO candidateLogin,
			FullSearcher searcher, int startIndex, int count)
			: base(candidateLogin, searcher)
		{
			StartIndex = startIndex;
			Count = count;
		}
	}
}