using System.Collections.Generic;

namespace RecruitmentLibrary.Validation
{
	public static class Validator
	{
		private static readonly Dictionary<ValidLanguage, string> _languageCharacterSets
			= new Dictionary<ValidLanguage, string>();

		static Validator()
		{
			_languageCharacterSets.Add(ValidLanguage.None, string.Empty);
			_languageCharacterSets.Add(ValidLanguage.Ukrainian,
				"АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ");
			_languageCharacterSets.Add(ValidLanguage.English, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
		}

		public static string GetAllowedCharactersForLanguage(ValidLanguage language)
			=> _languageCharacterSets[language];
		public static bool CheckAllNumbers(string text)
		{// The data is not valid if not all characters are numbers
			if (!StringHaveAllDigit(text))
				return false;

			return true;
		}
		public static bool CheckSymbols(string text, ValidLanguage language,
			string allowedChars)
		{// The data is invalid if there is a character that is not a letter of the language
		 // AND is not a character from the allowedChars
			text = text.ToUpper();

			// Getting a complete list of valid characters
			allowedChars += _languageCharacterSets[language];
			allowedChars = allowedChars.ToUpper();

			for (int i = 0; i < text.Length; i++)
				for (int j = 0; j < allowedChars.Length; j++)
					if (text[i] != allowedChars[j] && j == allowedChars.Length - 1)
					{// If the character is not in the allowed characters
						return false;
					}
					else if (text[i] == allowedChars[j])
						break;

			return true;
		}
		public static bool CheckMinCountSymbols(string text, int count, string requiredChars)
		{// The data is invalid if there are no requiredChars characters in the count
		 // number of characters.
			text = text.ToUpper();
			requiredChars = requiredChars.ToUpper();
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
				return false;

			return true;
		}
		public static string DeleteSpaces(string s)
		{
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

		private static bool StringHaveAllDigit(string s)
		{
			for (int i = 0; i < s.Length; i++)
				if (!char.IsDigit(s[i]))
					return false;
			return true;
		}
	}
}