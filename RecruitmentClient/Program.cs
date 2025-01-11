using System;
using System.Configuration;
using System.Globalization;
using System.Net.Sockets;
using System.Windows.Forms;

using RecruitmentClient.Forms;
using RecruitmentClient.Models;
using RecruitmentLibrary.PersonInfo;
using UIHelpers.Forms;

namespace RecruitmentClient
{
	internal static class Program
	{
		internal static string SerializePath = $"{Environment.CurrentDirectory}\\" +
			$"{ConfigurationManager.AppSettings["serializePath"]}";
		internal static readonly string EncryptKey =
			ConfigurationManager.AppSettings["encryptKey"];

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Account account = Serializator.Deserialize<Account>(SerializePath, EncryptKey);
			if (account != null)
			{
				try
				{ account.candidate = Client.GetCandidate(account.Login, account.Password); }
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
	}
}