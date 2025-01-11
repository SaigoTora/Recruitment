using Guna.UI2.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;

using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentClient.Utilities.FormUtilities
{
	internal class EducationFormElements
	{
		internal Guna2GradientPanel PanelMain { get; private set; }

		internal Label LabelNameInstitution { get; private set; }
		internal Label LabelSpecialty { get; private set; }
		internal Label LabelEducationDegree { get; private set; }
		internal Label LabelYearAdmission { get; private set; }
		internal Label LabelDateEnd { get; private set; }
		internal Label LabelEducationForm { get; private set; }

		internal Guna2TextBox TextBoxNameInstitution { get; private set; }
		internal Guna2TextBox TextBoxSpecialty { get; private set; }

		internal NumericUpDown NUD_YearAdmission { get; private set; }
		internal Guna2DateTimePicker DTP_DateEnd { get; private set; }
		internal Guna2ComboBox CB_EducationDegree { get; private set; }
		internal Guna2ComboBox CB_EducationForm { get; private set; }

		internal EducationFormElements(Guna2GradientPanel panelMain,
			Label labelNameInstitution, Label labelSpecialty, Label labelEducationDegree,
			Label labelYearAdmission, Label labelDateEnd, Label labelEducationForm,
			Guna2TextBox textBoxNameInstitution, Guna2TextBox textBoxSpecialty,
			NumericUpDown nud_YearAdmission, Guna2DateTimePicker dtp_DateEnd,
			Guna2ComboBox cb_EducationDegree, Guna2ComboBox cb_EducationForm)
		{
			PanelMain = panelMain;
			LabelNameInstitution = labelNameInstitution;
			LabelSpecialty = labelSpecialty;
			LabelEducationDegree = labelEducationDegree;
			LabelYearAdmission = labelYearAdmission;
			LabelDateEnd = labelDateEnd;
			LabelEducationForm = labelEducationForm;

			TextBoxNameInstitution = textBoxNameInstitution;
			TextBoxSpecialty = textBoxSpecialty;
			NUD_YearAdmission = nud_YearAdmission;
			DTP_DateEnd = dtp_DateEnd;
			CB_EducationDegree = cb_EducationDegree;
			CB_EducationForm = cb_EducationForm;
		}

		internal void SetDefaultLabels(Theme theme)
		{
			ValidationFeedbackManager.ResetLabelsToDefault(theme, LabelNameInstitution,
				LabelSpecialty, LabelEducationDegree, LabelYearAdmission, LabelDateEnd,
				LabelEducationForm);
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;

			EducationFormElements other = (EducationFormElements)obj;

			if (TextBoxNameInstitution.Text != other.TextBoxNameInstitution.Text
						|| TextBoxSpecialty.Text != other.TextBoxSpecialty.Text
						|| NUD_YearAdmission.Value != other.NUD_YearAdmission.Value
						|| DTP_DateEnd.Value.Date != other.DTP_DateEnd.Value.Date
						|| CB_EducationDegree.SelectedIndex !=
						other.CB_EducationDegree.SelectedIndex
						|| CB_EducationForm.SelectedIndex !=
						other.CB_EducationForm.SelectedIndex)
				return false;

			return true;
		}
		public override int GetHashCode()
		{
			int hashCode = -321895089;
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Guna2GradientPanel>.Default.GetHashCode(PanelMain);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Label>.Default.GetHashCode(LabelNameInstitution);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Label>.Default.GetHashCode(LabelSpecialty);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Label>.Default.GetHashCode(LabelEducationDegree);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Label>.Default.GetHashCode(LabelYearAdmission);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Label>.Default.GetHashCode(LabelDateEnd);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Label>.Default.GetHashCode(LabelEducationForm);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Guna2TextBox>.Default.GetHashCode(TextBoxNameInstitution);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Guna2TextBox>.Default.GetHashCode(TextBoxSpecialty);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<NumericUpDown>.Default.GetHashCode(NUD_YearAdmission);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Guna2DateTimePicker>.Default.GetHashCode(DTP_DateEnd);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Guna2ComboBox>.Default.GetHashCode(CB_EducationDegree);
			hashCode = hashCode * -1521134295 +
				EqualityComparer<Guna2ComboBox>.Default.GetHashCode(CB_EducationForm);
			return hashCode;
		}
	}
}