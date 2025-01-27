using Newtonsoft.Json;
using SharedModels.Models;
using System;

namespace SharedModels.DTOs
{
	[Serializable]
	public class QuestionnaireChangeDTO
	{
		[JsonProperty]
		public CandidateLoginDTO CandidateLogin { get; private set; }
		[JsonProperty]
		public Questionnaire Questionnaire { get; private set; }

		[JsonConstructor]
		public QuestionnaireChangeDTO(CandidateLoginDTO candidateLogin,
			Questionnaire questionnaire)
		{
			CandidateLogin = candidateLogin;
			Questionnaire = questionnaire;
		}
	}
}