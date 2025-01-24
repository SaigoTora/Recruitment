using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using SharedModels.DTOs;
using SharedModels.Models;

namespace RecruitmentClient.Models
{
	internal class Client
	{
		private const string HTTP_PREFIX = "http://";
		private const string MEDIA_TYPE = "application/json";

		private static readonly HttpClient httpClient;
		private readonly string _serverAddress;

		#region URLs
		private readonly string _candidateRegisterUrl
			= ConfigurationManager.AppSettings["candidateRegisterUrl"];
		private readonly string _candidateLoginUrl
			= ConfigurationManager.AppSettings["candidateLoginUrl"];
		private readonly string _candidateChangePasswordUrl
			= ConfigurationManager.AppSettings["candidateChangePasswordUrl"];
		private readonly string _candidateUrl
			= ConfigurationManager.AppSettings["candidateUrl"];
		private readonly string _questionnaireUrl
			= ConfigurationManager.AppSettings["questionnaireUrl"];
		private readonly string _candidateIsLoginUniqueUrl
			= ConfigurationManager.AppSettings["candidateIsLoginUniqueUrl"];
		private readonly string _candidateIsPhoneUniqueUrl
			= ConfigurationManager.AppSettings["candidateIsPhoneUniqueUrl"];
		private readonly string _candidateIsEmailUniqueUrl
			= ConfigurationManager.AppSettings["candidateIsEmailUniqueUrl"];

		private readonly string _vacanciesCountUrl
			= ConfigurationManager.AppSettings["vacanciesCountUrl"];
		private readonly string _vacanciesUrl
			= ConfigurationManager.AppSettings["vacanciesUrl"];

		private readonly string _applicationsCountUrl
			= ConfigurationManager.AppSettings["applicationsCountUrl"];
		private readonly string _applicationsCreateUrl
			= ConfigurationManager.AppSettings["applicationsCreateUrl"];
		private readonly string _applicationsUrl
			= ConfigurationManager.AppSettings["applicationsUrl"];

		private readonly string _interviewsCountUrl
			= ConfigurationManager.AppSettings["interviewsCountUrl"];
		private readonly string _interviewsUrl
			= ConfigurationManager.AppSettings["interviewsUrl"];

		private readonly string _familyStatusesUrl
			= ConfigurationManager.AppSettings["familyStatusesUrl"];
		private readonly string _businessTripOpportunitiesUrl
			= ConfigurationManager.AppSettings["businessTripOpportunitiesUrl"];
		#endregion

		internal const char SEPARATOR = '¤';
		private readonly List<string> _uniqueLogins = new List<string>();
		private readonly List<string> _uniquePhones = new List<string>();
		private readonly List<string> _uniqueEmails = new List<string>();

		internal Client(IPAddress IPaddress, int port)
			=> _serverAddress = $"{HTTP_PREFIX}{IPaddress}:{port}";
		static Client()
		{
			httpClient = new HttpClient()
			{
				Timeout = TimeSpan.FromSeconds(10)
			};
		}

		#region Candidate
		internal async Task<Candidate> PostCandidateRegisterAsync(
			Candidate candidate)
		{
			string jsonContent = JsonConvert.SerializeObject(candidate, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_candidateRegisterUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Candidate>(jsonResponse);
			}
		}
		internal async Task<Candidate> PostCandidateLoginAsync(CandidateLoginDTO candidateLogin)
		{
			string jsonContent = JsonConvert.SerializeObject(candidateLogin,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_candidateLoginUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Candidate>(jsonResponse);
			}
		}
		internal async Task PutCandidatePasswordAsync(
			CandidateChangePasswordDTO candidateChangePassword)
		{
			string jsonContent = JsonConvert.SerializeObject(candidateChangePassword,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PutAsync(_serverAddress +
					_candidateChangePasswordUrl, httpContent);
				response.EnsureSuccessStatusCode();
			}
		}
		internal async Task<Candidate> PutCandidateAsync(Candidate candidate)
		{
			string jsonContent = JsonConvert.SerializeObject(candidate, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PutAsync(_serverAddress +
					_candidateUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Candidate>(jsonResponse);
			}
		}
		internal async Task<Questionnaire> PutQuestionnaireAsync(Questionnaire questionnaire)
		{
			string jsonContent = JsonConvert.SerializeObject(questionnaire, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PutAsync(_serverAddress +
					_questionnaireUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Questionnaire>(jsonResponse);
			}
		}

		#region Check unique
		internal async Task<bool> CheckCandidateLoginUniqueAsync(
			StringDataUniqueDTO stringDataUnique)
		{
			if (_uniqueLogins.Contains(stringDataUnique.Data))
				return false;

			string jsonContent = JsonConvert.SerializeObject(stringDataUnique,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_candidateIsLoginUniqueUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				bool isUnique = JsonConvert.DeserializeObject<bool>(jsonResponse);

				if (!isUnique)
					_uniqueLogins.Add(stringDataUnique.Data);

				return isUnique;
			}
		}
		internal async Task<bool> CheckCandidatePhoneUniqueAsync(
			StringDataUniqueDTO stringDataUnique)
		{
			if (_uniquePhones.Contains(stringDataUnique.Data))
				return false;

			string jsonContent = JsonConvert.SerializeObject(stringDataUnique,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_candidateIsPhoneUniqueUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				bool isUnique = JsonConvert.DeserializeObject<bool>(jsonResponse);

				if (!isUnique)
					_uniquePhones.Add(stringDataUnique.Data);

				return isUnique;
			}
		}
		internal async Task<bool> CheckCandidateEmailUniqueAsync(
			StringDataUniqueDTO stringDataUnique)
		{
			if (_uniqueEmails.Contains(stringDataUnique.Data))
				return false;

			string jsonContent = JsonConvert.SerializeObject(stringDataUnique,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_candidateIsEmailUniqueUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				bool isUnique = JsonConvert.DeserializeObject<bool>(jsonResponse);

				if (!isUnique)
					_uniqueEmails.Add(stringDataUnique.Data);

				return isUnique;
			}
		}
		#endregion
		#endregion

		#region Vacancy
		internal async Task<int> PostFreeVacanciesCountAsync(
			AccountSearchSettingsDTO accountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(accountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_vacanciesCountUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<int>(jsonResponse);
			}
		}
		internal async Task<List<Vacancy>> PostFreeVacanciesAsync(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(pagedAccountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_vacanciesUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Vacancy>>(jsonResponse);
			}
		}
		#endregion

		#region Application
		internal async Task<int> PostApplicationsCountAsync(AccountSearchSettingsDTO accountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(accountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_applicationsCountUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<int>(jsonResponse);
			}
		}
		internal async Task PostApplicationsCreateAsync(Application application)
		{
			string jsonContent = JsonConvert.SerializeObject(application,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_applicationsCreateUrl, httpContent);
				response.EnsureSuccessStatusCode();
			}
		}
		internal async Task<List<Application>> PostApplicationsAsync(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(pagedAccountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_applicationsUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Application>>(jsonResponse);
			}
		}
		#endregion

		#region Interview
		internal async Task<int> PostInterviewsCountAsync(
			AccountSearchSettingsDTO accountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(accountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_interviewsCountUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<int>(jsonResponse);
			}
		}
		internal async Task<List<Interview>> PostInterviewsAsync(
			PagedAccountSearchSettingsDTO pagedAccountSearch)
		{
			string jsonContent = JsonConvert.SerializeObject(pagedAccountSearch,
				Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = await httpClient.PostAsync(_serverAddress +
					_interviewsUrl, httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Interview>>(jsonResponse);
			}
		}
		#endregion

		#region Static data
		internal async Task<FamilyStatus[]> GetFamilyStatusesAsync()
		{
			HttpResponseMessage response = await httpClient.GetAsync($"{_serverAddress}" +
				$"{_familyStatusesUrl}");
			response.EnsureSuccessStatusCode();

			string jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<FamilyStatus[]>(jsonResponse);
		}
		internal async Task<BusinessTripOpportunity[]> GetBusinessTripOpportunitiesAsync()
		{
			HttpResponseMessage response = await httpClient.GetAsync($"{_serverAddress}" +
				$"{_businessTripOpportunitiesUrl}");
			response.EnsureSuccessStatusCode();

			string jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<BusinessTripOpportunity[]>(jsonResponse);
		}
		#endregion
	}
}