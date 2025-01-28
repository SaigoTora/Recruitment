using System.Windows.Forms;

using RecruitmentLibrary.Validation;
using UIHelpers.Themes;

namespace UIHelpers.Validation
{
	public class UIValidator
	{
		public bool IsDataValid => _isDataValid;
		private bool _isDataValid = true;

		public void CheckMinLength(Label label, Control focus, int minLength, Theme theme)
		{
			if (focus.Text.Length < minLength)
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"{label.Text} мінімальна кількість символів для цього поля: {minLength}.",
					theme, ref _isDataValid, focus);
		}
		public void CheckAllNumbers(Label label, Control focus, Theme theme)
		{// The data is not valid if not all characters are numbers
			if (!Validator.CheckAllNumbers(focus.Text))
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"{label.Text} рядок не може містити символи, які не є цифрою.",
					theme, ref _isDataValid, focus);
		}
		public void CheckSymbols(Label label, Control focus, Theme theme, ValidLanguage language,
			string allowedChars)
		{// The data is invalid if there is a character that is not a letter of the language
		 // AND is not a character from the allowedChars
			if (focus is TextBox textBox)
				textBox.Text = Validator.DeleteSpaces(textBox.Text);

			// Forming an error line
			string errorMessage = string.Empty;
			if (language == ValidLanguage.None)
				errorMessage = $"{label.Text} рядок може мати тільки такі символи: ({allowedChars}).";
			if (language == ValidLanguage.Ukrainian)
				errorMessage = $"{label.Text} рядок може мати українські літери і такі символи: " +
					$"({allowedChars}).";
			if (language == ValidLanguage.English)
				errorMessage = $"{label.Text} рядок може мати англійські літери і такі символи: " +
					$"({allowedChars}).";

			if (!Validator.CheckSymbols(focus.Text, language, allowedChars))
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					errorMessage, theme, ref _isDataValid, focus);
		}
		public void CheckMinCountSymbols(Label label, Control focus, Theme theme, int count,
			string requiredChars, string errorMessage)
		{// The data is invalid if there are no requiredChars characters in the count
		 // number of characters.
			if (!Validator.CheckMinCountSymbols(focus.Text, count, requiredChars))
				ValidationFeedbackManager.HighlightInvalidLabel(label, $"{label.Text}: " +
					$"{errorMessage}", theme, ref _isDataValid);
		}
	}
}