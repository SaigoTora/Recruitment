using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecruitmentClient.Forms;
using RecruitmentClient.Models;
using RecruitmentClient.Utilities.ClientUtilities;
using RecruitmentClient.Utilities.FormUtilities;
using RecruitmentLibrary.Serialization;
using SharedModels.DTOs;
using SharedModels.Static;
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
		internal static StaticData StaticData;
		internal static readonly UniqueChecker UniqueChecker = new UniqueChecker();
		private static readonly int _port = int.Parse(ConfigurationManager.AppSettings["port"]);
		private static Account _account;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			_account = Serializator.Deserialize<Account>(SerializePath, EncryptKey);
			if (!FindServer())
				return;

			if (_account == null && Serializator.SerializationFileExists(SerializePath))
				HandleAccountFileError();
			else if (_account != null)
				PerformLogin();
			else
				Application.Run(new StartForm());
		}

		internal static void HandleNetworkError()
		{
			Theme theme = _account?.Theme ?? default;
			CustomMessageBox.Show("Спроба підключитись до серверу завершилась " +
				"не вдало.\nСпробуйте, будь ласка, запустити програму пізніше.",
				theme, "Помилка підключення",
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error, 440);

			Application.Exit();
		}
		private static void PerformLogin()
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				CandidateLoginDTO candidateLogin = new CandidateLoginDTO(
					_account.Candidate.Login, _account.Candidate.Password);
				_account.Candidate = null;
				Task.Run(async () =>
				{
					_account.Candidate =
						await Client.LoginCandidateAsync(candidateLogin);
				}).Wait();
				Application.Run(new MainForm(_account));
			}
			catch (AggregateException)
			{ HandleAccountFileError(); }
			catch (Exception ex) when (ex is TaskCanceledException
			|| ex is System.Net.Http.HttpRequestException)
			{ HandleNetworkError(); }
			finally
			{ Cursor.Current = Cursors.Default; }
		}
		private static bool FindServer()
		{
			Theme theme = _account == null ? default : _account.Theme;
			LocalNetworkScanner scanner = new LocalNetworkScanner(_port);
			List<IPAddress> address = null;
			Cursor.Current = Cursors.WaitCursor;
			Task.Run(async () =>
			{
				address = await scanner.ScanLocalNetworkAsync();
			}).Wait();
			Cursor.Current = Cursors.Default;

			if (address == null || address.Count <= 0)
			{
				HandleNetworkError();
				return false;
			}

			Client = new Client(address[0], _port);
			return true;
		}
		private static void HandleAccountFileError()
		{
			CustomMessageBox.Show("Файл із даними про ваш акаунт було змінено. " +
				"Будь ласка, повторно введіть свої дані для входу.",
				default, "Помилка входу", CustomMessageBoxButtons.OK,
				CustomMessageBoxIcon.Information);
			Serializator.DeleteSerializationFile(SerializePath);
			Application.Run(new StartForm());
		}
	}
}