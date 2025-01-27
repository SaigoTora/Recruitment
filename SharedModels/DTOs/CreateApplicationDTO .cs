using Newtonsoft.Json;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class CreateApplicationDTO
	{
		[JsonProperty]
		public CandidateLoginDTO CandidateLogin { get; private set; }
		[JsonProperty]
		public string AdditionalInfo { get; private set; }
		[JsonProperty]
		public int VacancyId { get; private set; }

		public CreateApplicationDTO(CandidateLoginDTO candidateLogin, string additionalInfo,
			int vacancyId)
		{
			CandidateLogin = candidateLogin;
			AdditionalInfo = additionalInfo;
			VacancyId = vacancyId;
		}
	}
}