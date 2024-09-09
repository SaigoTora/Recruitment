using System.Drawing;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;

namespace RecruitmentLibrary.FormUtilities
{
    public static class Validator
    {// Статичний клас для перевірки даних та виділення label-ів
        public static readonly Color ErrorColor = Color.Red;
        private static bool StringHaveAllDigit(string s)
        {// Метод, який перевіряє рядок на те, що всі символи - цифри
            for (int i = 0; i < s.Length; i++)
                if (!char.IsDigit(s[i]))
                    return false;
            return true;
        }
        private static string SelectLanguageChars(ValidLanguage language)
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
        private static string DeleteSpaces(string s)
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

        public static void CheckBannedChar(Label label, string text, char banChar, ref bool needToShowMB)
        {// Метод перевіряє текст на заборонений для вводу символ
            if (text.Contains(banChar.ToString()))
                ShowWrongLabel(label, $"{label.Text.TrimEnd(':')} не може мати такий символ: {banChar}.", ref needToShowMB);
        }
        public static void CheckMinLength(Label label, Control focus, int minLength, ref bool needToShowMB)
        {// Метод, який виділяє label, якщо кількість символів менше ніж minLength
            if (focus.Text.Length < minLength)
                ShowWrongLabel(label, $"{label.Text} мінімальна кількість символів для цього поля: {minLength}.",
                    ref needToShowMB, focus);
        }
        public static void CheckAllNumbers(Label label, Control focus, ref bool needToShowMB)
        {// Метод, який виділяє label, якщо не всі символи - цифри
            if (!StringHaveAllDigit(focus.Text))
                ShowWrongLabel(label, $"{label.Text} рядок не може містити символи, які не є цифрою.",
                    ref needToShowMB, focus);
        }
        public static void CheckSymbols(Label label, Control focus, ref bool needToShowMB, ValidLanguage language, string exceptChars)
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
                        ShowWrongLabel(label, errorMessage, ref needToShowMB, focus);
                    }
                    else if (text[i] == exceptChars[j])
                        break;
        }
        public static void CheckMinCountSymbols(Label label, Control focus, ref bool needToShowMB, int count, string expectChars, string errorMessage)
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
                ShowWrongLabel(label, $"{label.Text}: {errorMessage}", ref needToShowMB);
        }
        public static void ShowWrongLabel(Label label, string errorMessage, ref bool needToShowMB, Control focus = null, string caption = null)
        {// Метод виділяє неправильно заповнений об’єкт типу Label та показує, за потребою, MessageBox
            ShowWrongLabel(label);
            caption = caption ?? "Помилка введення";
            if (needToShowMB)
            {
                focus?.Focus();
                MessageBox.Show("Дані були введені не вірно!\n" + errorMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                needToShowMB = false;
            }
        }

        public static void ShowWrongLabel(Label label)
        {// Метод виділяє неправильно заповнений об’єкт типу Label
            label.ForeColor = ErrorColor;
            label.Font = new Font(label.Font, FontStyle.Underline);
        }
        public static void SetDefaultLabels(Theme theme, params Label[] labels)
        {// Метод встановлює значення label-у за замовчуванням
            for (int i = 0; i < labels.Length; i++)
            {
                if (theme == Theme.White)
                    labels[i].ForeColor = ColorChanger.LabelColorThemeW;
                else if (theme == Theme.Black)
                    labels[i].ForeColor = ColorChanger.LabelColorThemeB;
                labels[i].Font = new Font(labels[i].Font, FontStyle.Regular);

            }
        }
    }
}