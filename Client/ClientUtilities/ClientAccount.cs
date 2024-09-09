using System;
using RecruitmentLibrary.PersonInfo;

namespace RecruitmentUser.ClientUtilities
{
    [Serializable]
    public class ClientAccount
    {// Обліковий запис        
        [NonSerialized]
        public Candidate candidate;// Кандидат
        public Theme Theme;// Тема відображення форми
        public string Login { get; private set; }// Логін
        public string Password { get; private set; }// Пароль

        // Констуктор
        public ClientAccount() { }

        public void SetLoginPassword(string login, string password)
        {// Метод встановлює логін та пароль у користувача
            Login = login;
            Password = password;
        }
    }
}