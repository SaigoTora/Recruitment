using Newtonsoft.Json;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class StringDataUniqueDTO
	{
		[JsonProperty]
		public int CandidateId { get; private set; }
		[JsonProperty]
		public string Data { get; private set; }

		[JsonConstructor]
		public StringDataUniqueDTO(int candidateId, string data)
		{
			CandidateId = candidateId;
			Data = data;
		}
	}
}