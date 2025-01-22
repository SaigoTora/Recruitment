using System.Threading.Tasks;
using System.Windows.Forms;

using SharedModels.DTOs;
using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentClient.Utilities.FormUtilities
{
	internal class UniqueChecker
	{
		internal async Task<bool> CheckLoginUniqueAsync(Label label, string login, Theme theme)
		{
			StringDataUniqueDTO stringDataUnique = new StringDataUniqueDTO(default, login);
			bool isLoginUnique = await Program.Client.CheckCandidateLoginUniqueAsync(
				stringDataUnique);

			if (!isLoginUnique)
			{
				bool needToShowMB = true;
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"Такий логін вже зайнятий іншим користувачем.",
					theme, ref needToShowMB);
			}

			return isLoginUnique;
		}
		internal async Task<bool> CheckPhoneUniqueAsync(Label label, int candidateId, string phone,
			Theme theme)
		{
			StringDataUniqueDTO stringDataUnique = new StringDataUniqueDTO(candidateId, phone);
			bool isPhoneUnique = await Program.Client.CheckCandidatePhoneUniqueAsync(
				stringDataUnique);

			if (!isPhoneUnique)
			{
				bool needToShowMB = true;
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"Такий номер телефону вже зайнятий іншим користувачем.",
					theme, ref needToShowMB);
			}

			return isPhoneUnique;
		}
		internal async Task<bool> CheckEmailUniqueAsync(Label label, int candidateId, string email,
			Theme theme)
		{
			StringDataUniqueDTO stringDataUnique = new StringDataUniqueDTO(candidateId, email);
			bool isEmailUnique = await Program.Client.CheckCandidateEmailUniqueAsync(
				stringDataUnique);

			if (!isEmailUnique)
			{
				bool needToShowMB = true;
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"Такий e-mail вже зайнятий іншим користувачем.",
					theme, ref needToShowMB);
			}

			return isEmailUnique;
		}
	}
}