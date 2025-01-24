using Newtonsoft.Json;
using System;
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
		private readonly Dictionary<string, Func<HttpListenerContext, Task>> _endpointHandlers
			= new Dictionary<string, Func<HttpListenerContext, Task>>();

		internal Server(int port)
		{
			_httpListener = new HttpListener();
			_httpListener.Prefixes.Add($"http://+:{port}/");
			_port = port;
			_firewallManager = new FirewallManager($"{FIREWALL_RULE_NAME_PREFIX} {port}");
			InitializeEndpoints();
		}

		internal void InitializeEndpoints()
		{
			_endpointHandlers.Add(ConfigurationManager.AppSettings["candidateRegisterUrl"],
				HandleCandidateRegisterAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["candidateLoginUrl"],
				HandleCandidateLoginAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["candidateChangePasswordUrl"],
				HandleCandidateChangePasswordAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["candidateUrl"],
				HandleCandidateAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["questionnaireUrl"],
				HandleQuestionnaireAsync);

			_endpointHandlers.Add(ConfigurationManager.AppSettings["candidateIsLoginUniqueUrl"],
				HandleCandidateLoginUniqueAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["candidateIsPhoneUniqueUrl"],
				HandleCandidatePhoneUniqueAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["candidateIsEmailUniqueUrl"],
				HandleCandidateEmailUniqueAsync);

			_endpointHandlers.Add(ConfigurationManager.AppSettings["vacanciesCountUrl"],
				HandleVacanciesCountAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["vacanciesUrl"],
				HandleVacanciesAsync);


			_endpointHandlers.Add(ConfigurationManager.AppSettings["applicationsCreateUrl"],
				HandleApplicationCreateAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["applicationsCountUrl"],
				HandleApplicationsCountAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["applicationsUrl"],
				HandleApplicationsAsync);

			_endpointHandlers.Add(ConfigurationManager.AppSettings["interviewsCountUrl"],
				HandleInterviewsCountAsync);

			_endpointHandlers.Add(ConfigurationManager.AppSettings["interviewsUrl"],
				HandleInterviewsAsync);

			_endpointHandlers.Add(ConfigurationManager.AppSettings["familyStatusesUrl"],
				HandleFamilyStatusesAsync);
			_endpointHandlers.Add(ConfigurationManager.AppSettings["businessTripOpportunitiesUrl"],
				HandleBusinessTripOpportunitiesAsync);
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

			await _endpointHandlers[context.Request.RawUrl](context);
			context.Response.Close();
		}

		#region Candidate
		private async Task HandleCandidateRegisterAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestWithUpdateAsync<Candidate>(context,
					c => DatabaseManager.CreateCandidate(c));
			}
		}
		private async Task HandleCandidateLoginAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<CandidateLoginDTO, Candidate>(context,
					cl => DatabaseManager.GetCandidate(cl));
			}
		}
		private async Task HandleCandidateChangePasswordAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				await HandleRequestWithoutResponseAsync<CandidateChangePasswordDTO>(context,
					ccpDTO => DatabaseManager.UpdateCandidatePassword(ccpDTO));
			}
		}
		private async Task HandleCandidateAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				await HandleRequestWithUpdateAsync<Candidate>(context,
					c => DatabaseManager.UpdateCandidate(c.Id, c));
			}
		}
		private async Task HandleQuestionnaireAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				await HandleRequestWithUpdateAsync<Questionnaire>(context,
					q => DatabaseManager.UpdateQuestionnaire(q.Id, q));
			}
		}

		#region Check unique
		private async Task HandleCandidateLoginUniqueAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<StringDataUniqueDTO, bool>(context,
					sduDTO => DatabaseManager.CheckCandidateLoginUnique(sduDTO));
			}
		}
		private async Task HandleCandidatePhoneUniqueAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<StringDataUniqueDTO, bool>(context,
					sduDTO => DatabaseManager.CheckCandidatePhoneUnique(sduDTO));
			}
		}
		private async Task HandleCandidateEmailUniqueAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<StringDataUniqueDTO, bool>(context,
					sduDTO => DatabaseManager.CheckCandidateEmailUnique(sduDTO));
			}
		}
		#endregion
		#endregion

		#region Vacancy
		private async Task HandleVacanciesCountAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<AccountSearchSettingsDTO, int>(context,
					acssDTO => DatabaseManager.GetVacanciesCount(acssDTO));
			}
		}
		private async Task HandleVacanciesAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<PagedAccountSearchSettingsDTO, List<Vacancy>>(context,
					pacssDTO => DatabaseManager.GetVacancies(pacssDTO));
			}
		}
		#endregion

		#region Application
		private async Task HandleApplicationCreateAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestWithoutResponseAsync<Application>(context, a =>
				{
					a.ChangeStatusId(1);
					DatabaseManager.CreateApplication(a);
				});
			}
		}

		private async Task HandleApplicationsCountAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<AccountSearchSettingsDTO, int>(context,
					acssDTO => DatabaseManager.GetApplicationsCount(acssDTO));
			}
		}
		private async Task HandleApplicationsAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<PagedAccountSearchSettingsDTO, List<Application>>(
					context, pacssDTO => DatabaseManager.GetApplications(pacssDTO));
			}
		}
		#endregion

		#region Interview
		private async Task HandleInterviewsCountAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<AccountSearchSettingsDTO, int>(context,
					acssDTO => DatabaseManager.GetInterviewsCount(acssDTO));
			}
		}
		private async Task HandleInterviewsAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<PagedAccountSearchSettingsDTO, List<Interview>>(
					context, pacssDTO => DatabaseManager.GetInterviews(pacssDTO));
			}
		}
		#endregion

		#region Static data
		private async Task HandleFamilyStatusesAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Get.Method)
				await RespondAsync(context, DatabaseManager.GetFamilyStatuses());
		}
		private async Task HandleBusinessTripOpportunitiesAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Get.Method)
				await RespondAsync(context, DatabaseManager.GetBusinessTripOpportunities());
		}
		#endregion

		#region General methods
		private async Task HandleRequestAndRespondAsync<T1, T2>(HttpListenerContext context,
			Func<T1, T2> responseHandler)
		{
			T1 request = await DeserializeFromRequestAsync<T1>(context);
			T2 responseObject = responseHandler(request);

			string response = JsonConvert.SerializeObject(responseObject, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleRequestWithUpdateAsync<T>(HttpListenerContext context,
			Func<T, T> responseHandler)
		{
			T request = await DeserializeFromRequestAsync<T>(context);
			request = responseHandler(request);

			string response = JsonConvert.SerializeObject(request, Formatting.Indented);
			await SendResponseToClientAsync(context, response);
		}
		private async Task HandleRequestWithoutResponseAsync<T>(HttpListenerContext context,
			Action<T> responseHandler)
		{
			T request = await DeserializeFromRequestAsync<T>(context);
			responseHandler(request);

			await SendResponseToClientAsync(context, string.Empty);
		}
		private async Task RespondAsync<T>(HttpListenerContext context, T responseObject)
		{
			string response = JsonConvert.SerializeObject(responseObject, Formatting.Indented);
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