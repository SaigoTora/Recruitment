using Newtonsoft.Json;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class StringDataUniqueDTO
	{
		[JsonProperty]
		public int CandidateId { get; set; }
		[JsonProperty]
		public string Data { get; set; }

		[JsonConstructor]
		public StringDataUniqueDTO(int candidateId, string data)
		{
			CandidateId = candidateId;
			Data = data;
		}
	}
}