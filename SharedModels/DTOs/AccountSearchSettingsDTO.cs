using Newtonsoft.Json;
using SharedModels.Search;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class AccountSearchSettingsDTO<T> where T : BaseSearcher
	{
		[JsonProperty]
		public CandidateLoginDTO CandidateLogin { get; private set; }
		[JsonProperty]
		public T Searcher { get; private set; }

		[JsonConstructor]
		public AccountSearchSettingsDTO(CandidateLoginDTO candidateLogin, T searcher)
		{
			CandidateLogin = candidateLogin;
			Searcher = searcher;
		}
	}
}