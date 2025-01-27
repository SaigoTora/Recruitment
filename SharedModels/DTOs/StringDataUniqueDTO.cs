using Newtonsoft.Json;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class StringDataUniqueDTO
	{
		[JsonProperty]
		public CandidateLoginDTO CandidateLogin { get; private set; }
		[JsonProperty]
		public string Data { get; private set; }

		[JsonConstructor]
		public StringDataUniqueDTO(CandidateLoginDTO candidateLogin, string data)
		{
			CandidateLogin = candidateLogin;
			Data = data;
		}
	}
}