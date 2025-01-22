using Newtonsoft.Json;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class CandidateChangePasswordDTO
	{
		[JsonProperty]
		public int CandidateId { get; private set; }
		[JsonProperty]
		public string NewPassword { get; private set; }

		[JsonConstructor]
		public CandidateChangePasswordDTO(int candidateId, string newPassword)
		{
			CandidateId = candidateId;
			NewPassword = newPassword;
		}
	}
}