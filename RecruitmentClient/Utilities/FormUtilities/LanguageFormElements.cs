using Guna.UI2.WinForms;
using System.Windows.Forms;

using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentClient.Utilities.FormUtilities
{
	internal class LanguageFormElements
	{
		internal Guna2GradientPanel PanelMain { get; private set; }
		internal Label LabelName { get; private set; }
		internal Guna2ComboBox ComboBoxName { get; private set; }
		internal Label LabelLevel { get; private set; }
		internal NumericUpDown NUDLevel { get; private set; }

		internal LanguageFormElements(Guna2GradientPanel panelMain,
			Label labelName, Guna2ComboBox comboBoxName, Label labelLevel,
			NumericUpDown nudLevel)
		{
			PanelMain = panelMain;
			LabelName = labelName;
			ComboBoxName = comboBoxName;
			LabelLevel = labelLevel;
			NUDLevel = nudLevel;
		}

		internal void SetDefaultLabel(Theme theme)
			=> ValidationFeedbackManager.ResetLabelsToDefault(theme, LabelName, LabelLevel);
	}
}