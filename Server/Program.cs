using System;
using System.Globalization;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;
using ServerDB.Forms;
using ServerDB.ServerUtilities;

namespace ServerDB
{
    internal static class Program
    {
        // Шлях зберігання текстового файлу
        internal static string SerializePath = $"{Environment.CurrentDirectory}\\account_info.txt";
        internal static readonly string EncryptKey = "u7FhN3bDwY2cS5mR";// Ключ для шифрування
        /// <summary>
        /// Головна точка входу для програми.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServerAccount account = Serializator.Deserialize<ServerAccount>(SerializePath, EncryptKey) ?? new ServerAccount();
            Application.Run(new MainForm(account));
        }
    }
}
