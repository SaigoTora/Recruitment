using System.Windows.Forms;

using RecruitmentLibrary.FormUtilities;
using RecruitmentUser.ClientUtilities;

namespace RecruitmentUser.FormUtilities
{
    internal class ClientUnique
    {// Клас для перевірки на унікальність
        internal static bool EmailIsUnique(Label label, string login, string email)
        {// Метод, який перевіряє унікальність е-mail
            bool isEmailUnique = true;
            if (!Client.EmailIsUnique(login, email))// Якщо унікальність відсутня
                Validator.ShowWrongLabel(label, $"Такий e-mail вже зайнятий іншим користувачем.", ref isEmailUnique);

            return isEmailUnique;
        }
        internal static bool PhoneIsUnique(Label label, string login, string phone)
        {// Метод, який перевіряє унікальність номеру телефону
            bool isPhoneUnique = true;
            if (!Client.PhoneIsUnique(login, phone))// Якщо унікальність відсутня
                Validator.ShowWrongLabel(label, $"Такий номер телефону вже зайнятий іншим користувачем.", ref isPhoneUnique);

            return isPhoneUnique;
        }
        internal static bool LoginIsUnique(Label label, string login)
        {// Метод, який перевіряє логін на унікальність
            bool isLoginUnique = true;
            if (!Client.LoginIsUnique(login))// Якщо логінів більше ніж допустимо
                Validator.ShowWrongLabel(label, $"Такий логін вже зайнятий іншим користувачем.", ref isLoginUnique);

            return isLoginUnique;
        }
    }
}