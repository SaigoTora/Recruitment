using System.Windows.Forms;

using RecruitmentClient.Models;
using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentClient.Utilities.FormUtilities
{
	internal class ClientUniqueChecker
	{
		internal static bool IsEmailUnique(Label label, string login, string email,
			Theme theme)
		{
			bool isEmailUnique = true;

			if (!Client.EmailIsUnique(login, email))
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"Такий e-mail вже зайнятий іншим користувачем.",
					theme, ref isEmailUnique);

			return isEmailUnique;
		}
		internal static bool IsPhoneNumberUnique(Label label, string login, string phone,
			Theme theme)
		{
			bool isPhoneUnique = true;

			if (!Client.PhoneIsUnique(login, phone))
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"Такий номер телефону вже зайнятий іншим користувачем.",
					theme, ref isPhoneUnique);

			return isPhoneUnique;
		}
		internal static bool IsLoginUnique(Label label, string login, Theme theme)
		{
			bool isLoginUnique = true;

			if (!Client.LoginIsUnique(login))
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"Такий логін вже зайнятий іншим користувачем.",
					theme, ref isLoginUnique);

			return isLoginUnique;
		}
	}
}