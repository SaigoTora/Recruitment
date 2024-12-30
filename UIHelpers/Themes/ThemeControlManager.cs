using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

using UIHelpers.Controls;
using UIHelpers.Forms;

namespace UIHelpers.Themes
{
	public class ThemeControlManager
	{
		public static readonly (Color White, Color Black) PanelBackColor =
			(Color.FromArgb(230, 230, 230), Color.FromArgb(45, 45, 45));

		private static readonly (Color White, Color Black) _inputBackColor =
			(Color.FromArgb(235, 235, 235), Color.FromArgb(50, 50, 50));
		private static readonly (Color White, Color Black) _inputBorderColor =
			(Color.FromArgb(80, 80, 80), Color.FromArgb(175, 175, 175));

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
				if (child.Controls.Count > 0)
					ChangeControlsTheme(child, theme);

				if (ChangeGuna2Control(theme, child))
					continue;
				if (ChangeWindowsFormsControl(theme, child))
					continue;
			}
		}

		#region Change control colors
		private static void ChangeInputControlsForeColor(Theme theme, params Control[] controls)
		{
			(Color White, Color Black) _inputBackColor =
				(Color.Black, Color.White);

			switch (theme)
			{
				case Theme.White:
					ChangeControlsForeColor(_inputBackColor.White, controls);
					break;
				case Theme.Black:
					ChangeControlsForeColor(_inputBackColor.Black, controls);
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		private static void ChangeInputControlsBackColor(Theme theme, params Control[] controls)
		{
			switch (theme)
			{
				case Theme.White:
					ChangeControlsBackColor(_inputBackColor.White, controls);
					break;
				case Theme.Black:
					ChangeControlsBackColor(_inputBackColor.Black, controls);
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		private static void ChangeInputControlsColor(Theme theme, params Control[] controls)
		{
			ChangeInputControlsBackColor(theme, controls);
			ChangeInputControlsForeColor(theme, controls);
		}

		private static void ChangeControlsForeColor(Color color, params Control[] controls)
		{
			for (int i = 0; i < controls.Length; i++)
				controls[i].ForeColor = color;
		}
		private static void ChangeControlsBackColor(Color color, params Control[] controls)
		{
			for (int i = 0; i < controls.Length; i++)
				controls[i].BackColor = color;
		}
		#endregion

		#region Windows forms controls
		private static bool ChangeWindowsFormsControl(Theme theme, Control control)
		{
			if (control is Label label)
			{ ChangeLabelsColor(theme, label); return true; }
			else if (control is CheckBox checkBox)
			{ ChangeInputControlsForeColor(theme, checkBox); return true; }
			else if (control is TextBox || control is ComboBox
				|| control is NumericUpDown || control is ListBox)
			{ ChangeInputControlsColor(theme, control); return true; }
			else if (control is RichTextBox richTextBox)
			{ ChangeRichTextBoxColor(theme, richTextBox); return true; }
			else if (control is FlowLayoutPanel flowLayoutPanel)
			{ ChangeFlowLayoutPanelColor(theme, flowLayoutPanel); return true; }
			else if (control is Panel panel)
			{
				if (panel.Name != CustomTitleBar.MAIN_PANEL_NAME)
					ChangePanelColor(theme, panel);
				return true;
			}
			return false;
		}

		public static void ChangeLabelsColor(Theme theme, params Label[] labels)
		{
			(Color White, Color Black) _labelForeColor =
				(Color.FromArgb(20, 20, 20), Color.FromArgb(235, 235, 235));

			switch (theme)
			{
				case Theme.White:
					ChangeControlsForeColor(_labelForeColor.White, labels);
					break;
				case Theme.Black:
					ChangeControlsForeColor(_labelForeColor.Black, labels);
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		private static void ChangeRichTextBoxColor(Theme theme, RichTextBox richTextBox)
		{
			if (richTextBox.ReadOnly)
			{
				ChangeInputControlsForeColor(theme, richTextBox);

				Control parent = richTextBox.Parent;// Going up the control hierarchy
													// while BackColor is Color.Transparent
				while (parent.BackColor == Color.Transparent)
					parent = parent.Parent;
				richTextBox.BackColor = parent.BackColor;
			}
			else
				ChangeInputControlsColor(theme, richTextBox);
		}

		private static void ChangeFlowLayoutPanelColor(Theme theme, FlowLayoutPanel panel)
		{
			(Color White, Color Black) _panelBackColor =
				(Color.FromArgb(213, 213, 213), Color.FromArgb(32, 32, 32));

			switch (theme)
			{
				case Theme.White:
					ChangeControlsBackColor(_panelBackColor.White, panel);
					break;
				case Theme.Black:
					ChangeControlsBackColor(_panelBackColor.Black, panel);
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		public static void ChangePanelColor(Theme theme, params Panel[] panels)
		{
			switch (theme)
			{
				case Theme.White:
					ChangeControlsBackColor(PanelBackColor.White, panels);
					break;
				case Theme.Black:
					ChangeControlsBackColor(PanelBackColor.Black, panels);
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		#endregion

		#region Guna2 controls
		private static bool ChangeGuna2Control(Theme theme, Control control)
		{
			if (control is Guna2CustomCheckBox guna2CheckBox)
			{ ChangeGuna2CheckBox(theme, guna2CheckBox); return true; }
			else if (control is Guna2ComboBox comboBox)
			{ ChangeGuna2ComboBox(theme, comboBox); return true; }
			else if (control is Guna2TextBox guna2TextBox)
			{ ChangeGuna2TextBox(theme, guna2TextBox); return true; }
			else if (control is Guna2DateTimePicker guna2DateTimePicker)
			{ ChangeGuna2DateTimePicker(theme, guna2DateTimePicker); return true; }
			else if (control is Guna2CustomRadioButton guna2RadioButton)
			{ ChangeGuna2CustomRadioButton(theme, guna2RadioButton); return true; }
			else if (control is Guna2GradientPanel guna2GradientPanel)
			{ ChangeGuna2GradientPanel(theme, guna2GradientPanel); return true; }

			return false;
		}

		private static void ChangeGuna2CheckBox(Theme theme, Guna2CustomCheckBox checkBox)
		{
			(Color White, Color Black) checkedBorderColor =
				(Color.Black, Color.White);
			ChangeInputControlsForeColor(theme, checkBox);

			switch (theme)
			{
				case Theme.White:
					checkBox.CheckedState.BorderColor = checkedBorderColor.White;
					checkBox.UncheckedState.BorderColor = _inputBorderColor.White;
					checkBox.UncheckedState.FillColor = _inputBackColor.White;
					break;
				case Theme.Black:
					checkBox.CheckedState.BorderColor = checkedBorderColor.Black;
					checkBox.UncheckedState.BorderColor = _inputBorderColor.Black;
					checkBox.UncheckedState.FillColor = _inputBackColor.Black;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
			checkBox.ShadowDecoration.Color = checkBox.UncheckedState.BorderColor;
		}
		private static void ChangeGuna2ComboBox(Theme theme, Guna2ComboBox comboBox)
		{
			(Color White, Color Black) hoverBorderColor =
				(Color.Black, Color.White);

			ChangeInputControlsForeColor(theme, comboBox);

			switch (theme)
			{
				case Theme.White:
					comboBox.FillColor = _inputBackColor.White;
					comboBox.BorderColor = _inputBorderColor.White;
					comboBox.HoverState.BorderColor = hoverBorderColor.White;
					break;
				case Theme.Black:
					comboBox.FillColor = _inputBackColor.Black;
					comboBox.BorderColor = _inputBorderColor.Black;
					comboBox.HoverState.BorderColor = hoverBorderColor.Black;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		private static void ChangeGuna2TextBox(Theme theme, Guna2TextBox textBox)
		{
			(Color White, Color Black) hoverBorderColor =
				(Color.Black, Color.White);

			ChangeInputControlsForeColor(theme, textBox);

			switch (theme)
			{
				case Theme.White:
					textBox.FillColor = _inputBackColor.White;
					textBox.BorderColor = _inputBorderColor.White;
					textBox.HoverState.BorderColor = hoverBorderColor.White;
					break;
				case Theme.Black:
					textBox.FillColor = _inputBackColor.Black;
					textBox.BorderColor = _inputBorderColor.Black;
					textBox.HoverState.BorderColor = hoverBorderColor.Black;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}

		private static void ChangeGuna2DateTimePicker(Theme theme,
			Guna2DateTimePicker dtPicker)
		{
			(Color White, Color Black) borderColor =
				(Color.Black, Color.White);

			ChangeInputControlsForeColor(theme, dtPicker);

			switch (theme)
			{
				case Theme.White:
					dtPicker.BorderColor = borderColor.White;
					dtPicker.FillColor = _inputBackColor.White;
					dtPicker.HoverState.FillColor = _inputBackColor.White;
					break;
				case Theme.Black:
					dtPicker.BorderColor = borderColor.Black;
					dtPicker.FillColor = _inputBackColor.Black;
					dtPicker.HoverState.FillColor = _inputBackColor.Black;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		private static void ChangeGuna2CustomRadioButton(Theme theme,
			Guna2CustomRadioButton radioButton)
		{
			(Color White, Color Black) checkedBorderColor =
				(Color.Black, Color.White);

			ChangeInputControlsForeColor(theme, radioButton);

			switch (theme)
			{
				case Theme.White:
					radioButton.CheckedState.BorderColor = checkedBorderColor.White;
					radioButton.UncheckedState.BorderColor = _inputBorderColor.White;
					break;
				case Theme.Black:
					radioButton.CheckedState.BorderColor = checkedBorderColor.Black;
					radioButton.UncheckedState.BorderColor = _inputBorderColor.Black;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
			radioButton.ShadowDecoration.Color = radioButton.UncheckedState.BorderColor;
			if (radioButton.CheckedState.FillColor == Color.Transparent)
				radioButton.CheckedState.FillColor = radioButton.Parent.BackColor;
			if (radioButton.UncheckedState.FillColor == Color.Transparent)
				radioButton.UncheckedState.FillColor = radioButton.Parent.BackColor;
		}
		private static void ChangeGuna2GradientPanel(Theme theme,
			Guna2GradientPanel gradientPanel)
		{
			switch (theme)
			{
				case Theme.White:
					gradientPanel.FillColor = PanelBackColor.White;
					gradientPanel.FillColor2 = PanelBackColor.White;
					break;
				case Theme.Black:
					gradientPanel.FillColor = PanelBackColor.Black;
					gradientPanel.FillColor2 = PanelBackColor.Black;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		#endregion
	}
}