using System;
using System.Globalization;
using System.Net.Sockets;
using System.Windows.Forms;

using RecruitmentClient.ClientUtilities;
using RecruitmentClient.Forms;
using RecruitmentLibrary.PersonInfo;
using UIHelpers.Forms;

namespace RecruitmentClient
{
	internal static class Program
	{
		// Шлях зберігання текстового файлу
		internal static string SerializePath = $"{Environment.CurrentDirectory}\\account_info.txt";
		internal static readonly string EncryptKey = "kE7rQ1wA5pU3jM8o";// Ключ для шифрування
		/// <summary>
		/// Головна точка входу для програми.
		/// </summary>
		[STAThread]
		static void Main()
		{
			CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			ClientAccount account = Serializator.Deserialize<ClientAccount>(SerializePath, EncryptKey);
			if (account != null)// Якщо дані вже у пам’яті
			{
				try
				{ account.candidate = Client.GetCandidate(account.Login, account.Password); }
				catch (SocketException)
				{
					CustomMessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
						"\nСпробуйте, будь ласка, запустити програму пізніше.", account.Theme, "Помилка підключення",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
					return;
				}
				Application.Run(new MainForm(account));
			}
			else// Якщо дані ще не були запам’ятовані
				Application.Run(new StartForm());
		}
	}
}