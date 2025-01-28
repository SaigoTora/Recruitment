using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Security.Principal;
using System.Windows.Forms;

using RecruitmentLibrary.Serialization;
using RecruitmentServer.Forms;
using RecruitmentServer.Models;
using RecruitmentServer.DataBase;
using RecruitmentServer.Utilities.ServerUtilities;
using UIHelpers.Forms;

namespace RecruitmentServer
{
	internal static class Program
	{
		internal static string SerializePath = $"{Environment.CurrentDirectory}\\" +
			$"{ConfigurationManager.AppSettings["serializePath"]}";
		internal static readonly string EncryptKey =
			ConfigurationManager.AppSettings["encryptKey"];
		internal static Server Server { get; private set; }
		private static readonly int _port = int.Parse(ConfigurationManager.AppSettings["port"]);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Account account = Serializator.Deserialize<Account>(SerializePath, EncryptKey)
				?? new Account();

			if (!IsRunningAsAdministrator())
				RestartAsAdmin(account);
			Server = new Server(_port);
			Server.Start();
			Application.Run(new MainForm(account));

			Server.Stop();
			DatabaseManager.Dispose();
		}

		private static bool IsRunningAsAdministrator()
		{
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}
		private static void RestartAsAdmin(Account account)
		{
			try
			{
				var startInfo = new ProcessStartInfo($"{Process.GetCurrentProcess().ProcessName}.exe")
				{ Verb = "runas" };
				Process.Start(startInfo);
				Environment.Exit(0);
			}
			catch (System.ComponentModel.Win32Exception)
			{
				CustomMessageBox.Show("Без запуску програми від імені адміністратора ви " +
					"не зможете запустити програму.", account.Theme, "Error",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}
		}
	}
}