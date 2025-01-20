using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

using RecruitmentClient.Forms;
using RecruitmentClient.Models;
using RecruitmentLibrary.Serialization;
using SharedModels.DTOs;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentClient
{
	internal static class Program
	{
		internal static string SerializePath = $"{Environment.CurrentDirectory}\\" +
			$"{ConfigurationManager.AppSettings["serializePath"]}";
		internal static readonly string EncryptKey =
			ConfigurationManager.AppSettings["encryptKey"];
		internal static Client Client { get; private set; }
		private static readonly int _port = int.Parse(ConfigurationManager.AppSettings["port"]);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static async void Main()
		{
			CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Account account = Serializator.Deserialize<Account>(SerializePath, EncryptKey);
			if (!FindServer(account))
				return;

			if (account != null)
			{
				try
				{
					CandidateLoginDTO candidateLoginDTO = new CandidateLoginDTO(account.Login,
						account.Password);
					account.candidate = await Client.PostCandidateLoginAsync(candidateLoginDTO);
				}
				catch (SocketException)
				{
					CustomMessageBox.Show("Спроба підключитись до серверу завершилась " +
						"не вдало.\nСпробуйте, будь ласка, запустити програму пізніше.",
						account.Theme, "Помилка підключення",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
					return;
				}
				Application.Run(new MainForm(account));
			}
			else
				Application.Run(new StartForm());
		}

		private static bool FindServer(Account account)
		{
			Theme theme = account == null ? default : account.Theme;
			LocalNetworkScanner scanner = new LocalNetworkScanner(_port);
			List<IPAddress> address = scanner.ScanLocalNetworkAsync().Result;

			if (address == null || address.Count <= 0)
			{
				CustomMessageBox.Show("Спроба підключитись до серверу завершилась " +
					"не вдало.\nСпробуйте, будь ласка, запустити програму пізніше.",
					theme, "Помилка підключення",
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				return false;
			}

			Client = new Client(address[0], _port);
			return true;
		}
	}
}