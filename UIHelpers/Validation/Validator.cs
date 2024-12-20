using System.Windows.Forms;

using UIHelpers.Themes;

namespace UIHelpers.Validation
{
	public class Validator
	{
		public bool IsDataValid => _isDataValid;
		private bool _isDataValid = true;

		public void CheckBannedChar(Label label, string text, char banChar, Theme theme)
		{// Метод перевіряє текст на заборонений для вводу символ
			if (text.Contains(banChar.ToString()))
				ValidationFeedbackManager.ShowWrongLabel(label,
					$"{label.Text.TrimEnd(':')} не може мати такий символ: {banChar}.",
					theme, ref _isDataValid);
		}
		public void CheckMinLength(Label label, Control focus, int minLength, Theme theme)
		{// Метод, який виділяє label, якщо кількість символів менше ніж minLength
			if (focus.Text.Length < minLength)
				ValidationFeedbackManager.ShowWrongLabel(label,
					$"{label.Text} мінімальна кількість символів для цього поля: {minLength}.",
					theme, ref _isDataValid, focus);
		}
		public void CheckAllNumbers(Label label, Control focus, Theme theme)
		{// Метод, який виділяє label, якщо не всі символи - цифри
			if (!StringHaveAllDigit(focus.Text))
				ValidationFeedbackManager.ShowWrongLabel(label,
					$"{label.Text} рядок не може містити символи, які не є цифрою.",
					theme, ref _isDataValid, focus);
		}
		public void CheckSymbols(Label label, Control focus, Theme theme, ValidLanguage language, string exceptChars)
		{// Метод, який виділяє label, якщо є символ який не є літерою певної мови та не є символом з масиву exceptChars
			if (focus is TextBox textBox)// Якщо не пароль, то видаляємо пробіли
				textBox.Text = DeleteSpaces(textBox.Text);
			string text = focus.Text.ToUpper();

			// Формуємо рядок помилки
			string errorMessage = string.Empty;
			if (language == ValidLanguage.None)
				errorMessage = $"{label.Text} рядок може мати тільки такі символи: ({exceptChars}).";
			if (language == ValidLanguage.UA)
				errorMessage = $"{label.Text} рядок може мати українські літери і такі символи: ({exceptChars}).";
			if (language == ValidLanguage.ENG)
				errorMessage = $"{label.Text} рядок може мати англійські літери і такі символи: ({exceptChars}).";

			// Отримуємо повний список допустимих символів
			exceptChars += SelectLanguageChars(language);

			for (int i = 0; i < text.Length; i++)
				for (int j = 0; j < exceptChars.Length; j++)
					if (text[i] != exceptChars[j] && j == exceptChars.Length - 1)
					{// Якщо символа немає в дозволених символах
						ValidationFeedbackManager.ShowWrongLabel(label,
							errorMessage, theme, ref _isDataValid, focus);
					}
					else if (text[i] == exceptChars[j])
						break;
		}
		public void CheckMinCountSymbols(Label label, Control focus, Theme theme, int count, string expectChars, string errorMessage)
		{// Метод, який виділяє label, коли немає символів з expectChars у кількості count символів
			string text = focus.Text.ToUpper();
			int k = 0;// Лічильник

			// Підрахунок кількості потрібних символів
			for (int i = 0; i < text.Length; i++)
				for (int j = 0; j < expectChars.Length; j++)
					if (text[i] == expectChars[j])
					{
						k++;
						break;
					}

			if (k < count)// Якщо кількість менша за дозволену
				ValidationFeedbackManager.ShowWrongLabel(label, $"{label.Text}: {errorMessage}", theme, ref _isDataValid);
		}

		private bool StringHaveAllDigit(string s)
		{// Метод, який перевіряє рядок на те, що всі символи - цифри
			for (int i = 0; i < s.Length; i++)
				if (!char.IsDigit(s[i]))
					return false;
			return true;
		}
		private string SelectLanguageChars(ValidLanguage language)
		{// Метод, який видає символи за заданою мовою
			switch (language)
			{
				case ValidLanguage.None:
					return string.Empty;
				case ValidLanguage.UA:
					return "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
				case ValidLanguage.ENG:
					return "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				default: break;
			}
			return string.Empty;
		}
		private string DeleteSpaces(string s)
		{// Метод видаляє зайві пробіли
			string res = string.Empty;
			s = s.Trim(' ');// Видаляє пробіли з початку та кінця рядка

			for (int i = 0; i < s.Length; i++)
			{// Запис тільки одного пробілу замість кількох
				res += s[i];
				if (s[i] == ' ')
					while (i + 1 < s.Length && s[i + 1] == ' ')
						i++;
			}

			return res;
		}
	}
}