using Newtonsoft.Json;
using SharedModels.Search;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class AccountSearchSettingsDTO
	{
		[JsonProperty]
		public int CandidateId { get; private set; }
		[JsonProperty]
		public FullSearcher Searcher { get; private set; }

		[JsonConstructor]
		public AccountSearchSettingsDTO(int candidateId, FullSearcher searcher)
		{
			CandidateId = candidateId;
			Searcher = searcher;
		}
	}
}