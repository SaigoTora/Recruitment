using Newtonsoft.Json;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class CandidateChangePasswordDTO
	{
		[JsonProperty]
		public CandidateLoginDTO CandidateLogin { get; private set; }
		[JsonProperty]
		public string NewPassword { get; private set; }

		[JsonConstructor]
		public CandidateChangePasswordDTO(CandidateLoginDTO candidateLogin, string newPassword)
		{
			CandidateLogin = candidateLogin;
			NewPassword = newPassword;
		}
	}
}