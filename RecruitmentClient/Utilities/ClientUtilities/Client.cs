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
using SharedModels.Static;
using SharedModels.Search;

namespace RecruitmentClient.Utilities.ClientUtilities
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

		private readonly string _applicationsCreateUrl
			= ConfigurationManager.AppSettings["applicationsCreateUrl"];
		private readonly string _applicationsCountUrl
			= ConfigurationManager.AppSettings["applicationsCountUrl"];
		private readonly string _applicationsUrl
			= ConfigurationManager.AppSettings["applicationsUrl"];

		private readonly string _interviewsCountUrl
			= ConfigurationManager.AppSettings["interviewsCountUrl"];
		private readonly string _interviewsUrl
			= ConfigurationManager.AppSettings["interviewsUrl"];
		private readonly string _employeesUrl
			= ConfigurationManager.AppSettings["employeesUrl"];

		private readonly string _staticDataUrl
			= ConfigurationManager.AppSettings["staticDataUrl"];
		#endregion

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
		internal async Task<Candidate> CreateCandidateAsync(Candidate candidate)
		{
			return await SendAndReceiveDataAsync<Candidate>(candidate, HttpMethod.Post,
				_candidateRegisterUrl);
		}
		internal async Task<Candidate> LoginCandidateAsync(CandidateLoginDTO candidateLogin)
		{
			return await SendAndReceiveDataAsync<Candidate>(candidateLogin, HttpMethod.Post,
				_candidateLoginUrl);
		}

		internal async Task UpdateCandidatePasswordAsync(
			CandidateChangePasswordDTO candidateChangePassword)
		{
			await SendDataAsync(candidateChangePassword, HttpMethod.Put,
			_candidateChangePasswordUrl);
		}
		internal async Task<Candidate> UpdateCandidateAsync(Candidate candidate)
		{
			return await SendAndReceiveDataAsync<Candidate>(candidate, HttpMethod.Put,
				_candidateUrl);
		}
		internal async Task<Questionnaire> UpdateQuestionnaireAsync(
			QuestionnaireChangeDTO questionnaireChange)
		{
			return await SendAndReceiveDataAsync<Questionnaire>(questionnaireChange,
				HttpMethod.Put, _questionnaireUrl);
		}

		#region Check unique
		internal async Task<bool> CheckCandidateLoginUniqueAsync(
			StringDataUniqueDTO stringDataUnique)
		{
			if (_uniqueLogins.Contains(stringDataUnique.Data))
				return false;

			bool isUnique = await SendAndReceiveDataAsync<bool>(stringDataUnique, HttpMethod.Post,
				_candidateIsLoginUniqueUrl);

			if (!isUnique)
				_uniqueLogins.Add(stringDataUnique.Data);

			return isUnique;
		}
		internal async Task<bool> CheckCandidatePhoneUniqueAsync(
			StringDataUniqueDTO stringDataUnique)
		{
			if (_uniquePhones.Contains(stringDataUnique.Data))
				return false;

			bool isUnique = await SendAndReceiveDataAsync<bool>(stringDataUnique, HttpMethod.Post,
				_candidateIsPhoneUniqueUrl);

			if (!isUnique)
				_uniquePhones.Add(stringDataUnique.Data);

			return isUnique;
		}
		internal async Task<bool> CheckCandidateEmailUniqueAsync(
			StringDataUniqueDTO stringDataUnique)
		{
			if (_uniqueEmails.Contains(stringDataUnique.Data))
				return false;

			bool isUnique = await SendAndReceiveDataAsync<bool>(stringDataUnique, HttpMethod.Post,
				_candidateIsEmailUniqueUrl);

			if (!isUnique)
				_uniqueEmails.Add(stringDataUnique.Data);

			return isUnique;
		}
		#endregion
		#endregion

		#region Vacancy
		internal async Task<int> GetFreeVacanciesCountAsync(
			AccountSearchSettingsDTO<VacancySearcher> accountSearch)
		{
			return await SendAndReceiveDataAsync<int>(accountSearch, HttpMethod.Post,
				_vacanciesCountUrl);
		}
		internal async Task<List<Vacancy>> GetFreeVacanciesAsync(
			PagedAccountSearchSettingsDTO<VacancySearcher> pagedAccountSearch)
		{
			return await SendAndReceiveDataAsync<List<Vacancy>>(pagedAccountSearch,
				HttpMethod.Post, _vacanciesUrl);
		}
		#endregion

		#region Application
		internal async Task CreateApplicationAsync(CreateApplicationDTO createApplication)
			=> await SendDataAsync(createApplication, HttpMethod.Post, _applicationsCreateUrl);

		internal async Task<int> GetApplicationsCountAsync(
			AccountSearchSettingsDTO<ApplicationSearcher> accountSearch)
		{
			return await SendAndReceiveDataAsync<int>(accountSearch, HttpMethod.Post,
				_applicationsCountUrl);
		}
		internal async Task<List<Application>> GetApplicationsAsync(
			PagedAccountSearchSettingsDTO<ApplicationSearcher> pagedAccountSearch)
		{
			return await SendAndReceiveDataAsync<List<Application>>(pagedAccountSearch,
				HttpMethod.Post, _applicationsUrl);
		}
		#endregion

		#region Interview
		internal async Task<int> GetInterviewsCountAsync(
			AccountSearchSettingsDTO<InterviewSearcher> accountSearch)
		{
			return await SendAndReceiveDataAsync<int>(accountSearch, HttpMethod.Post,
				_interviewsCountUrl);
		}
		internal async Task<List<Interview>> GetInterviewsAsync(
			PagedAccountSearchSettingsDTO<InterviewSearcher> pagedAccountSearch)
		{
			return await SendAndReceiveDataAsync<List<Interview>>(pagedAccountSearch,
				HttpMethod.Post, _interviewsUrl);
		}
		#endregion

		#region Employee
		internal async Task<List<Employee>> GetEmployeesAsync(CandidateLoginDTO candidateLogin)
		{
			return await SendAndReceiveDataAsync<List<Employee>>(candidateLogin,
				HttpMethod.Post, _employeesUrl);
		}
		#endregion

		#region Static data
		internal async Task<StaticData> GetStaticDataAsync()
			=> await ReceiveDataAsync<StaticData>(_staticDataUrl);
		#endregion

		#region General methods
		private async Task<T> SendAndReceiveDataAsync<T>(object value, HttpMethod httpMethod,
			string endpoint)
		{
			string jsonContent = JsonConvert.SerializeObject(value, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = null;
				if (httpMethod == HttpMethod.Post)
					response = await httpClient.PostAsync(_serverAddress +
						endpoint, httpContent);
				else if (httpMethod == HttpMethod.Put)
					response = await httpClient.PutAsync(_serverAddress +
						endpoint, httpContent);
				else
				{
					throw new NotSupportedException($"HTTP method '{httpMethod}' " +
						$"is not supported in {nameof(SendAndReceiveDataAsync)}.");
				}
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(jsonResponse);
			}
		}
		private async Task SendDataAsync(object value, HttpMethod httpMethod,
			string endpoint)
		{
			string jsonContent = JsonConvert.SerializeObject(value, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, MEDIA_TYPE))
			{
				HttpResponseMessage response = null;
				if (httpMethod == HttpMethod.Post)
					response = await httpClient.PostAsync(_serverAddress +
						endpoint, httpContent);
				else if (httpMethod == HttpMethod.Put)
					response = await httpClient.PutAsync(_serverAddress +
						endpoint, httpContent);
				else
				{
					throw new NotSupportedException($"HTTP method '{httpMethod}' " +
						$"is not supported in {nameof(SendDataAsync)}.");
				}
				response.EnsureSuccessStatusCode();
			}
		}
		private async Task<T> ReceiveDataAsync<T>(string endpoint)
		{
			HttpResponseMessage response = await httpClient.GetAsync(_serverAddress +
				endpoint);
			response.EnsureSuccessStatusCode();

			string jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(jsonResponse);
		}
		#endregion
	}
}