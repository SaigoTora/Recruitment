using System.Drawing;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;

namespace RecruitmentLibrary.FormUtilities
{
    public static class ColorChanger
    {// Клас для зміни кольорів елементів форми
        public static readonly Color LabelColorThemeB = Color.FromArgb(235, 235, 235);// Колір тексту label-ів темної теми
        public static readonly Color LabelColorThemeW = Color.FromArgb(20, 20, 20);// Колір тексту label-ів світлої теми

        public static readonly Color BackColorThemeW = Color.FromArgb(220, 220, 220);// Колір фону світлої теми
        public static readonly Color BackColorThemeB = Color.FromArgb(35, 35, 35);// Колір фону темної теми

        private static readonly Color InputForeColorThemeW = Color.FromArgb(235, 235, 235);// Колір фону елементів введення світлої теми
        private static readonly Color InputForeColorThemeB = Color.FromArgb(50, 50, 50);// Колір фону елементів введення темної теми

        private static void ChangeControlsForeColor(Color color, Control[] controls)
        {// Метод змінює колір шрифту для всіх Control-ів
            for (int i = 0; i < controls.Length; i++)
            {
                if (controls[i] is Label && controls[i].ForeColor == Validator.ErrorColor)
                    continue;// Якщо колір помилки, то не змінюємо його
                controls[i].ForeColor = color;
            }
        }
        private static void ChangeControlsBackColor(Color color, Control[] controls)
        {// Метод змінює колір фону для всіх Control-ів
            for (int i = 0; i < controls.Length; i++)
                controls[i].BackColor = color;
        }

        public static void ChangeLabelsForeColor(Theme theme, params Label[] labels)
        {// Метод змінює колір тексту для Label-ів
            if (theme == Theme.White)
                ChangeControlsForeColor(LabelColorThemeW, labels);
            else if (theme == Theme.Black)
                ChangeControlsForeColor(LabelColorThemeB, labels);
        }
        public static void ChangeInputControlsColor(Theme theme, params Control[] controls)
        {// Метод змінює колір фону та тексту для елементів введення
            ChangeInputControlsBackColor(theme, controls);
            ChangeInputControlsForeColor(theme, controls);
        }
        public static void ChangeInputControlsBackColor(Theme theme, params Control[] controls)
        {// Метод змінює колір фону для елементів введення
            if (theme == Theme.White)
                ChangeControlsBackColor(InputForeColorThemeW, controls);
            else if (theme == Theme.Black)
                ChangeControlsBackColor(InputForeColorThemeB, controls);
        }
        public static void ChangeInputControlsForeColor(Theme theme, params Control[] controls)
        {// Метод змінює колір тексту для елементів введення
            if (theme == Theme.White)
                ChangeControlsForeColor(Color.Black, controls);
            else if (theme == Theme.Black)
                ChangeControlsForeColor(Color.White, controls);
        }
    }
}