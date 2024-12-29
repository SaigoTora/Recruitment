using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UIHelpers.Controls
{
	public class ControlCreator
	{
		public Panel MainPanel { get; private set; }
		public Guna2GradientPanel MainPanelNEW { get; private set; }

		private readonly Control _parent;
		private readonly bool _visible;
		private readonly List<Panel> _createdPanels = new List<Panel>();
		private int _number = 0;// Number for the control name

		public ControlCreator(Panel panel, Control parent, bool visible = true)
		{
			MainPanel = panel;
			_visible = visible;
			_parent = parent;
		}
		public ControlCreator(Guna2GradientPanel panel, Control parent, bool visible = true)
		{
			MainPanelNEW = panel;
			_visible = visible;
			_parent = parent;
		}

		private T CreateControl<T>(T sample) where T : Control, new()
		{
			T control = new T()
			{
				Name = sample.Name + _number,
				Location = sample.Location,
				Size = sample.Size,
				BackColor = sample.BackColor,
				ForeColor = sample.ForeColor,
				Font = sample.Font,
				Cursor = sample.Cursor,
				Anchor = sample.Anchor,
				Tag = sample.Tag
			};
			MainPanel?.Controls.Add(control);
			MainPanelNEW?.Controls.Add(control);

			return control;
		}

		public Panel CreateMainPanel()
		{
			_number++;
			Control parent = MainPanel.Parent;

			MainPanel = CreateControl(MainPanel);
			MainPanel.Visible = _visible;

			_parent.Controls.Add(MainPanel);
			_createdPanels.Add(MainPanel);

			return MainPanel;
		}
		public Panel CreateMainPanelNEW()
		{
			_number++;
			Control parent = MainPanelNEW.Parent;

			MainPanelNEW = CreatePanel(MainPanelNEW);

			_parent.Controls.Add(MainPanelNEW);
			_createdPanels.Add(MainPanelNEW);

			return MainPanel;
		}
		private Guna2GradientPanel CreatePanel(Guna2GradientPanel sample)
		{
			Guna2GradientPanel panel = CreateControl(sample);
			panel.Visible = _visible;
			panel.BorderRadius = MainPanelNEW.BorderRadius;
			panel.BorderStyle = MainPanelNEW.BorderStyle;
			panel.BorderColor = MainPanelNEW.BorderColor;
			panel.FillColor = MainPanelNEW.FillColor;
			panel.FillColor2 = MainPanelNEW.FillColor2;

			return panel;
		}
		public Label CreateLabel(Label sample, string text = null)
		{
			Label label = CreateControl(sample);
			label.AutoSize = sample.AutoSize;
			label.TextAlign = sample.TextAlign;
			label.AutoEllipsis = sample.AutoEllipsis;
			if (text == null) label.Text = sample.Text;
			else label.Text = text;

			return label;
		}
		public Guna2TextBox CreateTextBox(Guna2TextBox sample, string text = "")
		{
			Guna2TextBox textBox = CreateControl(sample);
			textBox.Text = text;
			textBox.MaxLength = sample.MaxLength;
			textBox.Animated = sample.Animated;
			textBox.AutoScroll = sample.AutoScroll;
			textBox.BorderColor = sample.BorderColor;
			textBox.BorderRadius = sample.BorderRadius;
			textBox.BorderThickness = sample.BorderThickness;
			textBox.DisabledState = sample.DisabledState;
			textBox.FocusedState = sample.FocusedState;
			textBox.HoverState = sample.HoverState;
			textBox.Margin = sample.Margin;
			textBox.PasswordChar = sample.PasswordChar;
			textBox.PlaceholderForeColor = sample.PlaceholderForeColor;
			textBox.PlaceholderText = sample.PlaceholderText;
			textBox.ScrollBars = sample.ScrollBars;
			textBox.SelectedText = sample.SelectedText;
			textBox.TextOffset = sample.TextOffset;
			textBox.Multiline = sample.Multiline;
			textBox.FillColor = sample.FillColor;

			textBox.Size = sample.Size;
			textBox.Location = sample.Location;

			return textBox;
		}
		public Guna2GradientButton CreateButton(Guna2GradientButton sample)
		{
			Guna2GradientButton button = CreateControl(sample);
			button.Animated = sample.Animated;
			button.PressedColor = sample.PressedColor;
			button.PressedDepth = sample.PressedDepth;
			button.BorderColor = sample.BorderColor;
			button.BorderRadius = sample.BorderRadius;
			button.BorderThickness = sample.BorderThickness;
			button.FillColor = sample.FillColor;
			button.FillColor2 = sample.FillColor2;
			button.GradientMode = sample.GradientMode;
			button.HoverState = sample.HoverState;
			button.Text = sample.Text;

			return button;
		}

		public NumericUpDown CreateNumericUpDown(NumericUpDown sample)
		{
			NumericUpDown nud = CreateControl(sample);
			nud.TextAlign = sample.TextAlign;
			nud.Minimum = sample.Minimum;
			nud.Maximum = sample.Maximum;

			return nud;
		}
		public Guna2ComboBox CreateComboBox(Guna2ComboBox sample, int selectedIndex = 0)
		{
			Guna2ComboBox comboBox = CreateControl(sample);
			foreach (string item in sample.Items)// Adding combobox elements
				comboBox.Items.Add(item);

			comboBox.Animated = sample.Animated;
			comboBox.BorderColor = sample.BorderColor;
			comboBox.BorderRadius = sample.BorderRadius;
			comboBox.BorderThickness = sample.BorderThickness;
			comboBox.DrawMode = sample.DrawMode;
			comboBox.TextAlign = sample.TextAlign;
			comboBox.FillColor = sample.FillColor;
			comboBox.FocusedColor = sample.FocusedColor;
			comboBox.FocusedState.BorderColor = sample.FocusedState.BorderColor;
			comboBox.ItemHeight = sample.ItemHeight;
			comboBox.ItemsAppearance.SelectedBackColor =
				sample.ItemsAppearance.SelectedBackColor;
			comboBox.HoverState.BorderColor = sample.HoverState.BorderColor;
			comboBox.MaxLength = sample.MaxLength;
			comboBox.SelectedIndex = selectedIndex;
			comboBox.DropDownStyle = sample.DropDownStyle;
			comboBox.IntegralHeight = sample.IntegralHeight;
			comboBox.MaxDropDownItems = sample.MaxDropDownItems;

			return comboBox;
		}
		public Guna2DateTimePicker CreateDateTimePicker(Guna2DateTimePicker sample,
			DateTime? date = null)
		{
			Guna2DateTimePicker dtp = CreateControl(sample);
			dtp.MinDate = sample.MinDate;
			dtp.MaxDate = sample.MaxDate;
			dtp.BorderColor = sample.BorderColor;
			dtp.BorderRadius = sample.BorderRadius;
			dtp.BorderThickness = sample.BorderThickness;
			dtp.CheckedState = sample.CheckedState;
			dtp.HoverState = sample.HoverState;
			dtp.Checked = sample.Checked;
			dtp.FillColor = sample.FillColor;
			dtp.Format = sample.Format;
			dtp.RightToLeft = sample.RightToLeft;
			dtp.TextAlign = sample.TextAlign;

			if (date.HasValue)
				dtp.Value = date.Value;
			else
				dtp.Value = sample.Value;

			return dtp;
		}
		public PictureBox CreatePictureBox(PictureBox sample)
		{
			PictureBox pictureBox = CreateControl(sample);
			pictureBox.Image = sample.Image;

			return pictureBox;
		}

		public void Dispose()
		{
			foreach (Panel panel in _createdPanels)
				panel.Dispose();
		}
	}
}