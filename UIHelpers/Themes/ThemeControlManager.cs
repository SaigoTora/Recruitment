using System;
using System.Drawing;
using System.Windows.Forms;

using UIHelpers.Forms;

namespace UIHelpers.Themes
{
	public class ThemeControlManager
	{
		public static void ChangeFormTheme(Form form, Theme theme)
		{
			if (form is BaseForm baseForm)
				baseForm.ChangeCustomTitleBarTheme(theme);

			ChangeFormBackColor(form, theme);
			ChangeControlsTheme(form, theme);
		}
		private static void ChangeFormBackColor(Form form, Theme theme)
		{
			(Color White, Color Black) _formBackColor =
				(Color.FromArgb(220, 220, 220), Color.FromArgb(35, 35, 35));

			switch (theme)
			{
				case Theme.White:
					form.BackColor = _formBackColor.White;
					break;
				case Theme.Black:
					form.BackColor = _formBackColor.Black;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		private static void ChangeControlsTheme(Control control, Theme theme)
		{
			foreach (Control child in control.Controls)
			{
				switch (child)
				{
					case Label label:
						ChangeLabelsColor(theme, label);
						break;
					case CheckBox checkBox:
						ChangeInputControlsForeColor(theme, checkBox);
						break;
					case TextBox _:
					case ComboBox _:
					case NumericUpDown _:
					case ListBox _:
						ChangeInputControlsColor(theme, child);
						break;
					case RichTextBox richTextBox:
						ChangeRichTextBoxColor(theme, richTextBox);
						break;
					default:
						break;
				}

				if (child.Controls.Count > 0)
					ChangeControlsTheme(child, theme);
			}
		}

		public static void ChangeLabelsColor(Theme theme, params Label[] labels)
		{
			(Color White, Color Black) _labelForeColor =
				(Color.FromArgb(235, 235, 235), Color.FromArgb(20, 20, 20));

			if (theme == Theme.White)
				ChangeControlsForeColor(_labelForeColor.White, labels);
			else if (theme == Theme.Black)
				ChangeControlsForeColor(_labelForeColor.Black, labels);
		}
		private static void ChangeRichTextBoxColor(Theme theme, RichTextBox richTextBox)
		{
			if (richTextBox.ReadOnly)
			{
				ChangeInputControlsForeColor(theme, richTextBox);

				Control parent = richTextBox.Parent;// Going up the control hierarchy while BackColor is Color.Transparent
				while (parent.BackColor == Color.Transparent)
					parent = parent.Parent;
				richTextBox.BackColor = parent.BackColor;
			}
			else
				ChangeInputControlsColor(theme, richTextBox);
		}
		private static void ChangeInputControlsColor(Theme theme, params Control[] controls)
		{
			ChangeInputControlsBackColor(theme, controls);
			ChangeInputControlsForeColor(theme, controls);
		}
		private static void ChangeInputControlsForeColor(Theme theme, params Control[] controls)
		{
			(Color White, Color Black) _inputBackColor =
				(Color.Black, Color.White);

			if (theme == Theme.White)
				ChangeControlsForeColor(_inputBackColor.White, controls);
			else if (theme == Theme.Black)
				ChangeControlsForeColor(_inputBackColor.Black, controls);
		}
		private static void ChangeInputControlsBackColor(Theme theme, params Control[] controls)
		{
			(Color White, Color Black) _inputForeColor =
				(Color.FromArgb(235, 235, 235), Color.FromArgb(50, 50, 50));

			if (theme == Theme.White)
				ChangeControlsBackColor(_inputForeColor.White, controls);
			else if (theme == Theme.Black)
				ChangeControlsBackColor(_inputForeColor.Black, controls);
		}

		private static void ChangeControlsForeColor(Color color, Control[] controls)
		{
			for (int i = 0; i < controls.Length; i++)
				controls[i].ForeColor = color;
		}
		private static void ChangeControlsBackColor(Color color, Control[] controls)
		{
			for (int i = 0; i < controls.Length; i++)
				controls[i].BackColor = color;
		}
	}
}