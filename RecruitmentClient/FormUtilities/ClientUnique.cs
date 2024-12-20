using System.Windows.Forms;

using RecruitmentClient.ClientUtilities;
using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentClient.FormUtilities
{
	internal class ClientUnique
	{// Клас для перевірки на унікальність
		internal static bool EmailIsUnique(Label label, string login, string email, Theme theme)
		{// Метод, який перевіряє унікальність е-mail
			bool isEmailUnique = true;
			if (!Client.EmailIsUnique(login, email))// Якщо унікальність відсутня
				ValidationFeedbackManager.HighlightInvalidLabel(label, $"Такий e-mail вже зайнятий іншим користувачем.", theme, ref isEmailUnique);

			return isEmailUnique;
		}
		internal static bool PhoneIsUnique(Label label, string login, string phone, Theme theme)
		{// Метод, який перевіряє унікальність номеру телефону
			bool isPhoneUnique = true;
			if (!Client.PhoneIsUnique(login, phone))// Якщо унікальність відсутня
				ValidationFeedbackManager.HighlightInvalidLabel(label, $"Такий номер телефону вже зайнятий іншим користувачем.", theme, ref isPhoneUnique);

			return isPhoneUnique;
		}
		internal static bool LoginIsUnique(Label label, string login, Theme theme)
		{// Метод, який перевіряє логін на унікальність
			bool isLoginUnique = true;
			if (!Client.LoginIsUnique(login))// Якщо логінів більше ніж допустимо
				ValidationFeedbackManager.HighlightInvalidLabel(label, $"Такий логін вже зайнятий іншим користувачем.", theme, ref isLoginUnique);

			return isLoginUnique;
		}
	}
}