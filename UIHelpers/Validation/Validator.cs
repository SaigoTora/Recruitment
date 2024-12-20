using System.Collections.Generic;
using System.Windows.Forms;

using UIHelpers.Themes;

namespace UIHelpers.Validation
{
	public class Validator
	{
		public bool IsDataValid => _isDataValid;
		private bool _isDataValid = true;
		private readonly Dictionary<ValidLanguage, string> _languageCharacterSets = new Dictionary<ValidLanguage, string>();

		public Validator()
		{
			_languageCharacterSets.Add(ValidLanguage.None, string.Empty);
			_languageCharacterSets.Add(ValidLanguage.UA, "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ");
			_languageCharacterSets.Add(ValidLanguage.ENG, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
		}

		public void CheckBannedChar(Label label, string text, char banChar, Theme theme)
		{
			if (text.Contains(banChar.ToString()))
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"{label.Text.TrimEnd(':')} не може мати такий символ: {banChar}.",
					theme, ref _isDataValid);
		}
		public void CheckMinLength(Label label, Control focus, int minLength, Theme theme)
		{
			if (focus.Text.Length < minLength)
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"{label.Text} мінімальна кількість символів для цього поля: {minLength}.",
					theme, ref _isDataValid, focus);
		}
		public void CheckAllNumbers(Label label, Control focus, Theme theme)
		{// The data is not valid if not all characters are numbers
			if (!StringHaveAllDigit(focus.Text))
				ValidationFeedbackManager.HighlightInvalidLabel(label,
					$"{label.Text} рядок не може містити символи, які не є цифрою.",
					theme, ref _isDataValid, focus);
		}
		public void CheckSymbols(Label label, Control focus, Theme theme, ValidLanguage language, string allowedChars)
		{// The data is invalid if there is a character that is not a letter of the language
		 // AND is not a character from the allowedChars
			if (focus is TextBox textBox)
				textBox.Text = DeleteSpaces(textBox.Text);
			string text = focus.Text.ToUpper();

			// Forming an error line
			string errorMessage = string.Empty;
			if (language == ValidLanguage.None)
				errorMessage = $"{label.Text} рядок може мати тільки такі символи: ({allowedChars}).";
			if (language == ValidLanguage.UA)
				errorMessage = $"{label.Text} рядок може мати українські літери і такі символи: ({allowedChars}).";
			if (language == ValidLanguage.ENG)
				errorMessage = $"{label.Text} рядок може мати англійські літери і такі символи: ({allowedChars}).";

			// Getting a complete list of valid characters
			allowedChars += _languageCharacterSets[language];

			for (int i = 0; i < text.Length; i++)
				for (int j = 0; j < allowedChars.Length; j++)
					if (text[i] != allowedChars[j] && j == allowedChars.Length - 1)
					{// If the character is not in the allowed characters
						ValidationFeedbackManager.HighlightInvalidLabel(label,
							errorMessage, theme, ref _isDataValid, focus);
					}
					else if (text[i] == allowedChars[j])
						break;
		}
		public void CheckMinCountSymbols(Label label, Control focus, Theme theme, int count, string requiredChars, string errorMessage)
		{// The data is invalid if there are no requiredChars characters in the count number of characters.
			string text = focus.Text.ToUpper();
			int k = 0;

			// Calculating the number of characters needed
			for (int i = 0; i < text.Length; i++)
				for (int j = 0; j < requiredChars.Length; j++)
					if (text[i] == requiredChars[j])
					{
						k++;
						break;
					}

			if (k < count)// If the quantity is less than the allowed
				ValidationFeedbackManager.HighlightInvalidLabel(label, $"{label.Text}: {errorMessage}", theme, ref _isDataValid);
		}

		private bool StringHaveAllDigit(string s)
		{
			for (int i = 0; i < s.Length; i++)
				if (!char.IsDigit(s[i]))
					return false;
			return true;
		}
		private string DeleteSpaces(string s)
		{// Метод видаляє зайві пробіли
			string res = string.Empty;
			s = s.Trim(' ');

			for (int i = 0; i < s.Length; i++)
			{// Writing only one space instead of several
				res += s[i];
				if (s[i] == ' ')
					while (i + 1 < s.Length && s[i + 1] == ' ')
						i++;
			}

			return res;
		}
	}
}