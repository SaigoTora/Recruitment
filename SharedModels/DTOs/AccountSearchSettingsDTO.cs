using Newtonsoft.Json;
using SharedModels.Search;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class AccountSearchSettingsDTO
	{
		[JsonProperty]
		public int CandidateId { get; set; }
		[JsonProperty]
		public FullSearcher Searcher { get; set; }

		[JsonConstructor]
		public AccountSearchSettingsDTO(int candidateId, FullSearcher searcher)
		{
			CandidateId = candidateId;
			Searcher = searcher;
		}
	}
}