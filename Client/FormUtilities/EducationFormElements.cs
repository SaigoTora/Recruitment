using System.Collections.Generic;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;
using RecruitmentLibrary.FormUtilities;

namespace RecruitmentUser.FormUtilities
{
    internal class EducationFormElements
    {// Клас для зберігання елементів форми освіти
        internal Panel PanelMain { get; private set; }

        internal Label LabelNameInstitution { get; private set; }
        internal Label LabelSpecialty { get; private set; }
        internal Label LabelYearAdmission { get; private set; }
        internal Label LabelDateEnd { get; private set; }

        internal TextBox TextBoxNameInstitution { get; private set; }
        internal TextBox TextBoxSpecialty { get; private set; }

        internal NumericUpDown NUD_YearAdmission { get; private set; }
        internal DateTimePicker DTP_DateEnd { get; private set; }
        internal ComboBox CB_EducationDegree { get; private set; }
        internal ComboBox CB_EducationForm { get; private set; }

        internal EducationFormElements(Panel panelMain, Label labelNameInstitution,
            Label labelSpecialty, Label labelYearAdmission, Label labelDateEnd,
            TextBox textBoxNameInstitution, TextBox textBoxSpecialty,
            NumericUpDown nud_YearAdmission, DateTimePicker dtp_DateEnd,
            ComboBox cb_EducationDegree, ComboBox cb_EducationForm)
        {// Конструктор
            PanelMain = panelMain;
            LabelNameInstitution = labelNameInstitution;
            LabelSpecialty = labelSpecialty;
            LabelYearAdmission = labelYearAdmission;
            LabelDateEnd = labelDateEnd;
            TextBoxNameInstitution = textBoxNameInstitution;
            TextBoxSpecialty = textBoxSpecialty;
            NUD_YearAdmission = nud_YearAdmission;
            DTP_DateEnd = dtp_DateEnd;
            CB_EducationDegree = cb_EducationDegree;
            CB_EducationForm = cb_EducationForm;

        }
        internal void SetDefaultLabels(Theme theme)
        {// Метод встановлює значення label-ів за замовчуванням
            Validator.SetDefaultLabels(theme, LabelNameInstitution,
                LabelSpecialty, LabelYearAdmission, LabelDateEnd);
        }

        public override bool Equals(object obj)
        {// Метод, який визначає чи рівен obj поточному екземпляру
            if (obj == null || GetType() != obj.GetType())
                return false;

            EducationFormElements other = (EducationFormElements)obj;

            // Порівнюємо значення об'єктів на рівність
            if (TextBoxNameInstitution.Text != other.TextBoxNameInstitution.Text
                        || TextBoxSpecialty.Text != other.TextBoxSpecialty.Text
                        || NUD_YearAdmission.Value != other.NUD_YearAdmission.Value
                        || DTP_DateEnd.Value.Date != other.DTP_DateEnd.Value.Date
                        || CB_EducationDegree.SelectedIndex != other.CB_EducationDegree.SelectedIndex
                        || CB_EducationForm.SelectedIndex != other.CB_EducationForm.SelectedIndex)
                return false;

            return true;
        }

        public override int GetHashCode()
        {// Хеш-функція за замовчуванням
            int hashCode = 1049417743;
            hashCode = hashCode * -1521134295 + EqualityComparer<Panel>.Default.GetHashCode(PanelMain);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(LabelNameInstitution);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(LabelSpecialty);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(LabelYearAdmission);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(LabelDateEnd);
            hashCode = hashCode * -1521134295 + EqualityComparer<TextBox>.Default.GetHashCode(TextBoxNameInstitution);
            hashCode = hashCode * -1521134295 + EqualityComparer<TextBox>.Default.GetHashCode(TextBoxSpecialty);
            hashCode = hashCode * -1521134295 + EqualityComparer<NumericUpDown>.Default.GetHashCode(NUD_YearAdmission);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimePicker>.Default.GetHashCode(DTP_DateEnd);
            hashCode = hashCode * -1521134295 + EqualityComparer<ComboBox>.Default.GetHashCode(CB_EducationDegree);
            hashCode = hashCode * -1521134295 + EqualityComparer<ComboBox>.Default.GetHashCode(CB_EducationForm);
            return hashCode;
        }
    }
}