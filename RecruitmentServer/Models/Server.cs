using Newtonsoft.Json;
using RecruitmentServer.Models.DataBase;
using SharedModels.DTOs;
using SharedModels.Models;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentServer.Models
{
	internal class Server
	{
		private const string FIREWALL_RULE_NAME_PREFIX = "Recruitment";
		internal const char SEPARATOR = '¤';

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

			Task.Run(() => HandleRequests());
		}
		private async Task HandleRequests()
		{
			while (_httpListener.IsListening)
			{
				var context = await _httpListener.GetContextAsync();
				_ = ProcessRequest(context);
			}
		}





		private async Task ProcessRequest(HttpListenerContext context)
		{
			if (context.Request.RawUrl == "/favicon.ico")
			{// Ignore request for favicon.ico
				context.Response.StatusCode = (int)HttpStatusCode.NotFound;
				context.Response.Close();
				return;
			}

			if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateIsLoginUniqueUrl"]))
				await HandleCandidateLoginUniqueRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateIsPhoneUniqueUrl"]))
				await HandleCandidatePhoneUniqueRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateIsEmailUniqueUrl"]))
				await HandleCandidateEmailUniqueRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateRegisterUrl"]))
				await HandleCandidateRegisterRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateLoginUrl"]))
				await HandleCandidateLoginRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateChangePasswordUrl"]))
				await HandleCandidateChangePasswordRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["candidateUrl"]))
				await HandleCandidateRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["questionnaireUrl"]))
				await HandleQuestionnaireRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["vacanciesCountUrl"]))
				await HandleVacanciesCountRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["vacanciesUrl"]))
				await HandleVacanciesRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["applicationsCountUrl"]))
				await HandleApplicationsCountRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["applicationsCreateUrl"]))
				await HandleApplicationsCreateRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["applicationsUrl"]))
				await HandleApplicationsRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["interviewsCountUrl"]))
				await HandleInterviewsCountRequest(context);
			else if (context.Request.RawUrl.Contains(
				ConfigurationManager.AppSettings["interviewsUrl"]))
				await HandleInterviewsRequest(context);

			context.Response.Close();
		}

		#region Candidate
		private async Task HandleCandidateRegisterRequest(HttpListenerContext context)
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
		private async Task HandleCandidateLoginRequest(HttpListenerContext context)
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
		private async Task HandleCandidateChangePasswordRequest(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				CandidateChangePasswordDTO candidateChangePassword =
					await DeserializeFromRequestAsync<CandidateChangePasswordDTO>(context);
				DatabaseManager.UpdateCandidatePassword(candidateChangePassword);
			}

			await SendResponseToClientAsync(context, string.Empty);
		}
		private async Task HandleCandidateRequest(HttpListenerContext context)
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
		private async Task HandleQuestionnaireRequest(HttpListenerContext context)
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
		private async Task HandleCandidateLoginUniqueRequest(HttpListenerContext context)
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
		private async Task HandleCandidatePhoneUniqueRequest(HttpListenerContext context)
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
		private async Task HandleCandidateEmailUniqueRequest(HttpListenerContext context)
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
		private async Task HandleVacanciesCountRequest(HttpListenerContext context)
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
		private async Task HandleVacanciesRequest(HttpListenerContext context)
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
		private async Task HandleApplicationsCountRequest(HttpListenerContext context)
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
		private async Task HandleApplicationsCreateRequest(HttpListenerContext context)
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
		private async Task HandleApplicationsRequest(HttpListenerContext context)
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
		private async Task HandleInterviewsCountRequest(HttpListenerContext context)
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
		private async Task HandleInterviewsRequest(HttpListenerContext context)
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