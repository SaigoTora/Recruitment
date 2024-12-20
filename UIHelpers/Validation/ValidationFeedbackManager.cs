using System.Drawing;
using System.Windows.Forms;

using UIHelpers.Forms;
using UIHelpers.Themes;

namespace UIHelpers.Validation
{
	public static class ValidationFeedbackManager
	{
		private static readonly Color _errorColor = Color.Red;

		public static void HighlightInvalidLabel(Label label, string errorMessage, Theme theme,
			ref bool needToShowMB, Control focus = null, string caption = null)
		{// Highlights an incorrectly filled Label object and
		 // optionally displays a MessageBox with an error message.
			HighlightInvalidLabel(label);
			caption = caption ?? "Помилка введення";
			if (needToShowMB)
			{
				focus?.Focus();
				CustomMessageBox.Show("Дані були введені не вірно!\n" + errorMessage, theme,
					caption, CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				needToShowMB = false;
			}
		}

		public static void HighlightInvalidLabel(Label label)
		{
			label.ForeColor = _errorColor;
			label.Font = new Font(label.Font, FontStyle.Underline);
		}
		public static void ResetLabelsToDefault(Theme theme, params Label[] labels)
		{
			ThemeControlManager.ChangeLabelsColor(theme, labels);
			for (int i = 0; i < labels.Length; i++)
				labels[i].Font = new Font(labels[i].Font, FontStyle.Regular);
		}
	}
}