using Newtonsoft.Json;
using SharedModels.Search;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class AccountSearchSettingsDTO
	{
		[JsonProperty]
		public string Login { get; set; }
		[JsonProperty]
		public FullSearcher Searcher { get; set; }

		[JsonConstructor]
		public AccountSearchSettingsDTO(string login, FullSearcher searcher)
		{
			Login = login;
			Searcher = searcher;
		}
	}
}