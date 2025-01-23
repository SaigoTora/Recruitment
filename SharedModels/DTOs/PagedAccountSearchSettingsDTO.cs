using Newtonsoft.Json;
using SharedModels.Search;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class PagedAccountSearchSettingsDTO : AccountSearchSettingsDTO
	{
		[JsonProperty]
		public int StartIndex { get; set; }
		[JsonProperty]
		public int Count { get; set; }

		[JsonConstructor]
		public PagedAccountSearchSettingsDTO(int candidateId, FullSearcher searcher,
			int startIndex, int count)
			: base(candidateId, searcher)
		{
			StartIndex = startIndex;
			Count = count;
		}
	}
}