using Guna.UI2.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UIHelpers.Controls
{
	public class ControlCreator
	{
		public Panel MainPanel { get; private set; }

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

			return control;
		}

		public Panel CreateMainPanel()
		{
			_number++;

			MainPanel = CreateControl(MainPanel);
			MainPanel.Visible = _visible;
			_parent.Controls.Add(MainPanel);
			_createdPanels.Add(MainPanel);

			return MainPanel;
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
		public TextBox CreateTextBox(TextBox sample)
		{
			TextBox textBox = CreateControl(sample);
			textBox.MaxLength = sample.MaxLength;

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
			nud.Minimum = sample.Minimum;
			nud.Maximum = sample.Maximum;

			return nud;
		}
		public ComboBox CreateComboBox(ComboBox sample, int selectedIndex = 0)
		{
			ComboBox comboBox = CreateControl(sample);
			foreach (string item in sample.Items)// Adding combobox elements
				comboBox.Items.Add(item);

			comboBox.SelectedIndex = selectedIndex;
			comboBox.DropDownStyle = sample.DropDownStyle;
			comboBox.IntegralHeight = sample.IntegralHeight;
			comboBox.MaxDropDownItems = sample.MaxDropDownItems;

			return comboBox;
		}
		public DateTimePicker CreateDateTimePicker(DateTimePicker sample)
		{
			DateTimePicker dtp = CreateControl(sample);
			dtp.CalendarFont = sample.CalendarFont;
			dtp.MinDate = sample.MinDate;
			dtp.MaxDate = sample.MaxDate;
			dtp.DropDownAlign = sample.DropDownAlign;

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