using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using SharedModels.DTOs;
using SharedModels.Models;
using SharedModels.Search;

namespace RecruitmentClient.Models
{
	internal class Client
	{
		private const string HTTP_PREFIX = "http://";
		private const string MEDIA_TYPE = "application/json";

		private static readonly HttpClient httpClient;
		private readonly string _serverAddress;

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
		internal async Task<Candidate> PostCandidateLoginAsync(CandidateLoginDTO candidateLoginDTO)
		{
			string jsonContent = JsonConvert.SerializeObject(candidateLoginDTO,
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














		internal const char SEPARATOR = '¤';// Роздільник

		internal static string[] GetFamilyStatuses() // Сімейні стани
		{
			return new string[] { "Одружений(а)","Неодружений(а)","Розлучений(а)",
				"Вдівець/вдова","Цивільний шлюб"};
			//return SendToServerAndGetResult("SELECT status FROM Family_Status ORDER BY id");
		}
		internal static string[] GetBusinessTripOpportunities() // Можливості відряджень
		{
			return new string[] { "Часто", "Іноді", "Ніколи" };
			//return SendToServerAndGetResult("SELECT opportunity FROM Business_Trip_Opportunity ORDER BY id");
		}

		// Методи для перевірки унікальності
		private static bool CandidateDataIsUnique(string login, string dbField, string value)
		{// Метод, який перевіряє значення поля кандидата на унікальність
		 //string message = $"SELECT COUNT(id) FROM Candidate WHERE {dbField} = '{value}'";
		 //if (login != null)// Якщо логін вказаний
		 //	message += $" AND login != '{login}'";

			//string[] arr = SendToServerAndGetResult(message);
			//if (Int32.Parse(arr[0]) > 0)// Якщо унікальність відсутня
			//	return false;
			return true;

		}
		internal static bool EmailIsUnique(string login, string email) => CandidateDataIsUnique(login, "email", email);
		internal static bool PhoneIsUnique(string login, string phone) => CandidateDataIsUnique(login, "phone", phone);
		internal static bool LoginIsUnique(string login) => CandidateDataIsUnique(null, "login", login);
	}
}