using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using RecruitmentServer.Database;
using SharedModels.DTOs;
using SharedModels.Models;

namespace RecruitmentServer.Utilities.ServerUtilities
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
			_endpointHandlers.Add(
				ConfigurationManager.AppSettings["candidateChangePasswordUrl"],
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

			_endpointHandlers.Add(ConfigurationManager.AppSettings["staticDataUrl"],
				HandleStaticDataAsync);
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
			try
			{
				if (context.Request.RawUrl == "/favicon.ico")
				{// Ignore request for favicon.ico
					RespondWithStatus(context, HttpStatusCode.NotFound);
					return;
				}

				if (_endpointHandlers.TryGetValue(context.Request.RawUrl, out var handler))
					await handler(context);
				else
					RespondWithStatus(context, HttpStatusCode.NotFound);
			}
			finally
			{
				context.Response.Close();
			}
		}
		private void RespondWithStatus(HttpListenerContext context, HttpStatusCode statusCode)
		{
			context.Response.StatusCode = (int)statusCode;
			context.Response.Close();
		}


		#region Candidate
		private async Task HandleCandidateRegisterAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestWithUpdateAsync<Candidate>(context,
					c => DatabaseManager.CreateCandidate(c), HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		private async Task HandleCandidateLoginAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<CandidateLoginDTO, Candidate>(context,
					cl => DatabaseManager.GetCandidate(cl), HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		private async Task HandleCandidateChangePasswordAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				await HandleRequestWithoutResponseAsync<CandidateChangePasswordDTO>(context,
					ccpDTO => DatabaseManager.UpdateCandidatePassword(ccpDTO),
					HttpStatusCode.NoContent);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		private async Task HandleCandidateAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				await HandleRequestWithUpdateAsync<Candidate>(context,
					c => DatabaseManager.UpdateCandidate(c), HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		private async Task HandleQuestionnaireAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Put.Method)
			{
				await HandleRequestAndRespondAsync<QuestionnaireChangeDTO, Questionnaire>(context,
					q => DatabaseManager.UpdateQuestionnaire(q), HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}

		#region Check unique
		private async Task HandleCandidateLoginUniqueAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<StringDataUniqueDTO, bool>(context,
					sduDTO => DatabaseManager.CheckCandidateLoginUnique(sduDTO),
					HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		private async Task HandleCandidatePhoneUniqueAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<StringDataUniqueDTO, bool>(context,
					sduDTO => DatabaseManager.CheckCandidatePhoneUnique(sduDTO),
					HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		private async Task HandleCandidateEmailUniqueAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<StringDataUniqueDTO, bool>(context,
					sduDTO => DatabaseManager.CheckCandidateEmailUnique(sduDTO),
					HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		#endregion
		#endregion

		#region Vacancy
		private async Task HandleVacanciesCountAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<AccountSearchSettingsDTO, int>(context,
					acssDTO => DatabaseManager.GetVacanciesCount(acssDTO), HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		private async Task HandleVacanciesAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<PagedAccountSearchSettingsDTO, List<Vacancy>>(
					context, pacssDTO => DatabaseManager.GetVacancies(pacssDTO),
					HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		#endregion

		#region Application
		private async Task HandleApplicationCreateAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestWithoutResponseAsync<CreateApplicationDTO>(context,
					ca => DatabaseManager.CreateApplication(ca), HttpStatusCode.Created);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}

		private async Task HandleApplicationsCountAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<AccountSearchSettingsDTO, int>(context,
					acssDTO => DatabaseManager.GetApplicationsCount(acssDTO), HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		private async Task HandleApplicationsAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<PagedAccountSearchSettingsDTO,
					List<Application>>(context,
					pacssDTO => DatabaseManager.GetApplications(pacssDTO), HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		#endregion

		#region Interview
		private async Task HandleInterviewsCountAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<AccountSearchSettingsDTO, int>(context,
					acssDTO => DatabaseManager.GetInterviewsCount(acssDTO), HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		private async Task HandleInterviewsAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
			{
				await HandleRequestAndRespondAsync<PagedAccountSearchSettingsDTO, List<Interview>>(
					context, pacssDTO => DatabaseManager.GetInterviews(pacssDTO),
					HttpStatusCode.OK);
			}
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		#endregion

		#region Static data
		private async Task HandleStaticDataAsync(HttpListenerContext context)
		{
			if (context.Request.HttpMethod == HttpMethod.Get.Method)
				await RespondAsync(context, DatabaseManager.GetStaticData(),
					HttpStatusCode.OK);
			else
				RespondWithStatus(context, HttpStatusCode.MethodNotAllowed);
		}
		#endregion

		#region General methods
		private async Task HandleRequestAndRespondAsync<T1, T2>(HttpListenerContext context,
			Func<T1, T2> responseHandler, HttpStatusCode statusCode)
		{
			try
			{
				T1 request = await DeserializeFromRequestAsync<T1>(context);
				T2 responseObject = responseHandler(request);

				string response = JsonConvert.SerializeObject(responseObject,
					Formatting.Indented);
				await SendResponseToClientAsync(context, response, statusCode);
			}
			catch (Exception ex)
			{
				await HandleErrorAsync(context, ex, HttpStatusCode.BadRequest);
			}
		}
		private async Task HandleRequestWithUpdateAsync<T>(HttpListenerContext context,
			Func<T, T> responseHandler, HttpStatusCode statusCode)
		{
			try
			{
				T request = await DeserializeFromRequestAsync<T>(context);
				request = responseHandler(request);

				string response = JsonConvert.SerializeObject(request, Formatting.Indented);
				await SendResponseToClientAsync(context, response, statusCode);
			}
			catch (Exception ex)
			{
				await HandleErrorAsync(context, ex, HttpStatusCode.BadRequest);
			}
		}
		private async Task HandleRequestWithoutResponseAsync<T>(HttpListenerContext context,
			Action<T> responseHandler, HttpStatusCode statusCode)
		{
			try
			{
				T request = await DeserializeFromRequestAsync<T>(context);
				responseHandler(request);

				await SendResponseToClientAsync(context, string.Empty, statusCode);
			}
			catch (Exception ex)
			{
				await HandleErrorAsync(context, ex, HttpStatusCode.BadRequest);
			}
		}
		private async Task RespondAsync<T>(HttpListenerContext context, T responseObject,
			HttpStatusCode statusCode)
		{
			try
			{
				string response = JsonConvert.SerializeObject(responseObject, Formatting.Indented);
				await SendResponseToClientAsync(context, response, statusCode);
			}
			catch (Exception ex)
			{
				await HandleErrorAsync(context, ex, HttpStatusCode.InternalServerError);
			}
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
		private async Task HandleErrorAsync(HttpListenerContext context, Exception ex,
			HttpStatusCode statusCode)
		{
			var errorResponse = new
			{
				Message = "An error occurred",
				Details = ex.Message
			};

			if (ex.GetType() == typeof(UnauthorizedAccessException))
				statusCode = HttpStatusCode.Unauthorized;

			string errorJson = JsonConvert.SerializeObject(errorResponse, Formatting.Indented);
			await SendResponseToClientAsync(context, errorJson, statusCode);
		}
		private async Task SendResponseToClientAsync(HttpListenerContext context,
			string response, HttpStatusCode statusCode)
		{
			byte[] responseBytes = Encoding.UTF8.GetBytes(response);
			context.Response.StatusCode = (int)statusCode;
			context.Response.ContentLength64 = responseBytes.Length;

			await context.Response.OutputStream.WriteAsync(responseBytes, 0, responseBytes.Length);
		}
		#endregion

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