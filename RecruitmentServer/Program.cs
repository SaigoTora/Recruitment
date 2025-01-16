using System;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;

using RecruitmentLibrary.Serialization;
using RecruitmentServer.Forms;
using RecruitmentServer.Models;
using RecruitmentServer.Models.DataBase;

namespace RecruitmentServer
{
	internal static class Program
	{
		internal static string SerializePath = $"{Environment.CurrentDirectory}\\" +
			$"{ConfigurationManager.AppSettings["serializePath"]}";
		internal static readonly string EncryptKey =
			ConfigurationManager.AppSettings["encryptKey"];
		internal readonly static DatabaseManager DatabaseManager = new DatabaseManager();

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
			Application.Run(new MainForm(account));
			DatabaseManager?.Dispose();
		}
	}
}