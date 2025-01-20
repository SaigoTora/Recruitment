using Newtonsoft.Json;
using RecruitmentServer.Models.DataBase;
using SharedModels.DTOs;
using SharedModels.Models;
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
				ConfigurationManager.AppSettings["candidateLoginUrl"]))
				await HandleCandidateLoginRequest(context);
			//else if (context.Request.RawUrl.Contains(ConfigurationManager.AppSettings["gameLobbyUrl"]))
			//	await HandleLobbyRequest(context, clientIPAddress);
			//else if (context.Request.RawUrl.Contains(ConfigurationManager.AppSettings["gameUrl"]))
			//	await HandleGameRequest(context, clientIPAddress);

			context.Response.Close();
		}
		private async Task HandleCandidateLoginRequest(HttpListenerContext context)
		{
			Candidate candidate = null;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
				candidate = await HandlePostCandidateLoginRequest(context);

			string response = JsonConvert.SerializeObject(candidate, Formatting.Indented);
			await SendResponseToClient(context, response);
		}
		private async Task<Candidate> HandlePostCandidateLoginRequest(HttpListenerContext context)
		{
			CandidateLoginDTO candidateLoginDTO = null;

			using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
			{
				string jsonData = await reader.ReadToEndAsync();
				candidateLoginDTO = JsonConvert.DeserializeObject<CandidateLoginDTO>(jsonData);
			}

			Candidate candidate = DatabaseManager.GetCandidate(candidateLoginDTO.Login,
				candidateLoginDTO.Password);
			return candidate;
		}









		private async Task SendResponseToClient(HttpListenerContext context, string response)
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