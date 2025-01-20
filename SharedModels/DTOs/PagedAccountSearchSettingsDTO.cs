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
		public PagedAccountSearchSettingsDTO(string login, FullSearcher searcher,
			int startIndex, int count)
			: base(login, searcher)
		{
			StartIndex = startIndex;
			Count = count;
		}
	}
}