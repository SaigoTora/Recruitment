using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using RecruitmentServer.Models.DataBase;
using SharedModels.DTOs;
using SharedModels.Models;

namespace RecruitmentServer.Models
{
	internal class Server
	{
		private const string FIREWALL_RULE_NAME_PREFIX = "Recruitment";

		private readonly HttpListener _httpListener;
		private readonly int _port;
		private readonly FirewallManager _firewallManager;

		internal Server(int port)
		{
			_httpListener = new HttpListener();
			_httpListener.Prefixes.Add($"http://+:{port}/");
			_port = port;
			_firewallManager = new FirewallManager($"{FIREWALL_RULE_NAME_PREFIX} {port}");
		}

		internal void Start()
		{
			_httpListener.Start();
			_firewallManager.AddFirewallRule(_port);

			Task.Run(() => HandleRequestsAsync());
		}
		private async Task HandleRequestsAsync()
		{
			while (_httpListener.IsListening)
			{
				var context = await _httpListener.GetContextAsync();
				_ = ProcessRequestAsync(context);
			}
		}

		private async Task ProcessRequestAsync(HttpListenerContext context)
		{
			if (context.Request.RawUrl == "/favicon.ico")
			{// Ignore request for favicon.ico
				context.Response.StatusCode = (int)HttpStatusCode.NotFound;
				context.Response.Close();
				return;
			}

			if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateIsLoginUniqueUrl"]))
				await HandleCandidateLoginUniqueRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateIsPhoneUniqueUrl"]))
				await HandleCandidatePhoneUniqueRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateIsEmailUniqueUrl"]))
				await HandleCandidateEmailUniqueRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateRegisterUrl"]))
				await HandleCandidateRegisterRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateLoginUrl"]))
				await HandleCandidateLoginRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateChangePasswordUrl"]))
				await HandleCandidateChangePasswordRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateUrl"]))
				await HandleCandidateRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["questionnaireUrl"]))
				await HandleQuestionnaireRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["vacanciesCountUrl"]))
				await HandleVacanciesCountRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["vacanciesUrl"]))
				await HandleVacanciesRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["applicationsCountUrl"]))
				await HandleApplicationsCountRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["applicationsCreateUrl"]))
				await HandleApplicationsCreateRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["applicationsUrl"]))
				await HandleApplicationsRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["interviewsCountUrl"]))
				await HandleInterviewsCountRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["interviewsUrl"]))
				await HandleInterviewsRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["familyStatusesUrl"]))
				await HandleFamilyStatusesRequestAsync(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["businessTripOpportunitiesUrl"]))
				await HandleBusinessTripOpportunitiesRequestAsync(context);

			context.Response.Close();
		}

		#region Candidate
		private async Task HandleCandidateRegisterRequestAsync(HttpListenerContext context)
		{
			Candidate candidate = null;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				candidate = await DeserializeFromRequestAsync<Candidate>(context);
				candidate = DatabaseManager.CreateCandidate(candidate);
			}

			string response = JsonConvert.SerializeObject(candidate, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleCandidateLoginRequestAsync(HttpListenerContext context)
		{
			Candidate candidate = null;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				CandidateLoginDTO candidateLogin =
					await DeserializeFromRequestAsync<CandidateLoginDTO>(context);
				candidate = DatabaseManager.GetCandidate(candidateLogin);
			}

			string response = JsonConvert.SerializeObject(candidate, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleCandidateChangePasswordRequestAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				CandidateChangePasswordDTO candidateChangePassword =
					await DeserializeFromRequestAsync<CandidateChangePasswordDTO>(context);
				DatabaseManager.UpdateCandidatePassword(candidateChangePassword);
			}

			await SendResponseToClientAsync(context, string.Empty);
		}
		private async Task HandleCandidateRequestAsync(HttpListenerContext context)
		{
			Candidate candidate = null;

			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				candidate = await DeserializeFromRequestAsync<Candidate>(context);
				candidate = DatabaseManager.UpdateCandidate(candidate.Id, candidate);
			}

			string response = JsonConvert.SerializeObject(candidate, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleQuestionnaireRequestAsync(HttpListenerContext context)
		{
			Questionnaire questionnaire = null;

			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				questionnaire = await DeserializeFromRequestAsync<Questionnaire>(context);
				questionnaire = DatabaseManager.UpdateQuestionnaire(questionnaire.Id,
					questionnaire);
			}

			string response = JsonConvert.SerializeObject(questionnaire, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}

		#region Check unique
		private async Task HandleCandidateLoginUniqueRequestAsync(HttpListenerContext context)
		{
			bool isUnique = false;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				StringDataUniqueDTO stringDataUnique =
					await DeserializeFromRequestAsync<StringDataUniqueDTO>(context);
				isUnique = DatabaseManager.CheckCandidateLoginUnique(stringDataUnique);
			}

			string response = JsonConvert.SerializeObject(isUnique, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleCandidatePhoneUniqueRequestAsync(HttpListenerContext context)
		{
			bool isUnique = false;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				StringDataUniqueDTO stringDataUnique =
					await DeserializeFromRequestAsync<StringDataUniqueDTO>(context);
				isUnique = DatabaseManager.CheckCandidatePhoneUnique(stringDataUnique);
			}

			string response = JsonConvert.SerializeObject(isUnique, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleCandidateEmailUniqueRequestAsync(HttpListenerContext context)
		{
			bool isUnique = false;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				StringDataUniqueDTO stringDataUnique =
					await DeserializeFromRequestAsync<StringDataUniqueDTO>(context);
				isUnique = DatabaseManager.CheckCandidateEmailUnique(stringDataUnique);
			}

			string response = JsonConvert.SerializeObject(isUnique, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		#endregion
		#endregion

		#region Vacancy
		private async Task HandleVacanciesCountRequestAsync(HttpListenerContext context)
		{
			int vacanciesCount = 0;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				AccountSearchSettingsDTO accountSearch =
					await DeserializeFromRequestAsync<AccountSearchSettingsDTO>(context);
				vacanciesCount = DatabaseManager.GetVacanciesCount(accountSearch);
			}

			string response = JsonConvert.SerializeObject(vacanciesCount, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleVacanciesRequestAsync(HttpListenerContext context)
		{
			List<Vacancy> vacancies = new List<Vacancy>();

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				PagedAccountSearchSettingsDTO pagedAccountSearch =
					await DeserializeFromRequestAsync<PagedAccountSearchSettingsDTO>(context);
				vacancies = DatabaseManager.GetVacancies(pagedAccountSearch);
			}

			string response = JsonConvert.SerializeObject(vacancies, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		#endregion

		#region Application
		private async Task HandleApplicationsCountRequestAsync(HttpListenerContext context)
		{
			int applicationsCount = 0;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				AccountSearchSettingsDTO accountSearch =
					await DeserializeFromRequestAsync<AccountSearchSettingsDTO>(context);
				applicationsCount = DatabaseManager.GetApplicationsCount(accountSearch);
			}

			string response = JsonConvert.SerializeObject(applicationsCount, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleApplicationsCreateRequestAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				Application application =
					await DeserializeFromRequestAsync<Application>(context);
				application.ChangeStatusId(1);
				DatabaseManager.CreateApplication(application);
			}

			await SendResponseToClientAsync(context, string.Empty);
		}
		private async Task HandleApplicationsRequestAsync(HttpListenerContext context)
		{
			List<Application> applications = new List<Application>();

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				PagedAccountSearchSettingsDTO pagedAccountSearch =
					await DeserializeFromRequestAsync<PagedAccountSearchSettingsDTO>(context);
				applications = DatabaseManager.GetApplications(pagedAccountSearch);
			}

			string response = JsonConvert.SerializeObject(applications, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		#endregion

		#region Interview
		private async Task HandleInterviewsCountRequestAsync(HttpListenerContext context)
		{
			int interviewsCount = 0;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				AccountSearchSettingsDTO accountSearch =
					await DeserializeFromRequestAsync<AccountSearchSettingsDTO>(context);
				interviewsCount = DatabaseManager.GetInterviewsCount(accountSearch);
			}

			string response = JsonConvert.SerializeObject(interviewsCount, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleInterviewsRequestAsync(HttpListenerContext context)
		{
			List<Interview> interviews = new List<Interview>();

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				PagedAccountSearchSettingsDTO pagedAccountSearch =
					await DeserializeFromRequestAsync<PagedAccountSearchSettingsDTO>(context);
				interviews = DatabaseManager.GetInterviews(pagedAccountSearch);
			}

			string response = JsonConvert.SerializeObject(interviews, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		#endregion

		private async Task HandleFamilyStatusesRequestAsync(HttpListenerContext context)
		{
			FamilyStatus[] familyStatuses = null;

			if (context.Request.HttpMethod == HttpMethod.Get.Method)
				familyStatuses = DatabaseManager.GetFamilyStatuses();

			string response = JsonConvert.SerializeObject(familyStatuses, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleBusinessTripOpportunitiesRequestAsync(HttpListenerContext context)
		{
			BusinessTripOpportunity[] businessTripOpportunities = null;

			if (context.Request.HttpMethod == HttpMethod.Get.Method)
				businessTripOpportunities = DatabaseManager.GetBusinessTripOpportunities();

			string response = JsonConvert.SerializeObject(businessTripOpportunities,
				Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}

		private async Task<T> DeserializeFromRequestAsync<T>(HttpListenerContext context)
		{
			T result = default;

			using (var reader = new StreamReader(context.Request.InputStream,
				context.Request.ContentEncoding))
			{
				string jsonData = await reader.ReadToEndAsync();
				result = JsonConvert.DeserializeObject<T>(jsonData);
			}

			return result;
		}
		private async Task SendResponseToClientAsync(HttpListenerContext context, string response)
		{
			byte[] responseBytes = Encoding.UTF8.GetBytes(response);
			context.Response.StatusCode = (int)HttpStatusCode.OK;
			context.Response.ContentLength64 = responseBytes.Length;

			await context.Response.OutputStream.WriteAsync(responseBytes, 0, responseBytes.Length);
		}

		internal void Stop()
		{
			if (_httpListener.IsListening)
			{
				_httpListener.Stop();
				_httpListener.Close();
				_firewallManager.RemoveFirewallRule();
			}
		}
	}
}