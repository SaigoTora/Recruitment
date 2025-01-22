using Newtonsoft.Json;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class CandidateLoginDTO
	{
		[JsonProperty]
		public string Login { get; private set; }
		[JsonProperty]
		public string Password { get; private set; }

		[JsonConstructor]
		public CandidateLoginDTO(string login, string password)
		{
			Login = login;
			Password = password;
		}
	}
}