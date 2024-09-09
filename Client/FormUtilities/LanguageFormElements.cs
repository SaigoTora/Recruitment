using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;
using RecruitmentLibrary.FormUtilities;

namespace RecruitmentUser.FormUtilities
{
    internal class LanguageFormElements
    {// Клас для зберігання елементів форми мов
        internal Panel PanelMain { get; private set; }
        internal Label LabelName { get; private set; }
        internal ComboBox ComboBoxName { get; private set; }
        internal NumericUpDown NUD_Level { get; private set; }

        internal LanguageFormElements(Panel panelMain, Label labelName,
            ComboBox comboBoxName, NumericUpDown nud_Level)
        {// Конструктор
            PanelMain = panelMain;
            LabelName = labelName;
            ComboBoxName = comboBoxName;
            NUD_Level = nud_Level;
        }
        internal void SetDefaultLabel(Theme theme)
        {// Метод встановлює значення label-у за замовчуванням
            Validator.SetDefaultLabels(theme, LabelName);
        }
    }
}