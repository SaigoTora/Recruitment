using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

using UIHelpers.Forms;
using UIHelpers.Themes;

namespace UIHelpers.Controls
{
	public class CustomTitleBar : IDisposable
	{
		internal const string MAIN_PANEL_NAME = "panelCustomTitleBar";
		private const string MOVE_PARENT_CONTROL_DOWN_TAG = "needToMoveParentDown";
		private const string FIXED_CONTROL_POSITION_TAG = "fixedPosition";
		private const int DEFAULT_PANEL_HEIGHT = 35;

		#region Colors
		private static readonly (Color WhiteTheme, Color BlackTheme) _defaultPanelColor =
			(Color.FromArgb(235, 235, 235), Color.FromArgb(30, 30, 30));
		private static readonly (Color WhiteTheme, Color BlackTheme) _pressedPanelColor =
			(Color.FromArgb(227, 227, 227), Color.FromArgb(28, 28, 28));
		private static readonly (Color WhiteTheme, Color BlackTheme) _defaultButtonColor =
			(Color.Black, Color.FromArgb(200, 200, 200));
		private static readonly (Color WhiteTheme, Color BlackTheme) _defaultNameColor =
			(Color.Black, Color.White);
		private static readonly Color _hoverButtonExitColor = Color.FromArgb(232, 17, 35);
		#endregion
		private Theme _currentTheme;
		private static readonly Font _formNameFont = new Font("Segoe UI", 10F);
		private readonly (bool Minimize, bool Maximize) _scalingForm;
		private readonly bool _canFormBeClosed;
		private readonly BaseForm _form;
		public Panel MainPanel { get; private set; } = new Panel();
		private readonly Label _labelCaption;
		private (IconButton Minimize, IconButton Maximize, IconButton Close) _button;

		private int _formBorderRadius;
		private bool _isFormDragging;
		private Point _dragCursorPoint, _dragFormPoint;

		public CustomTitleBar(BaseForm form, string formName, System.Drawing.Icon icon = null,
			bool minimizeBox = true, bool maximizeBox = true, bool canFormBeClosed = true)
		{
			_scalingForm.Minimize = minimizeBox;
			_scalingForm.Maximize = maximizeBox;
			_canFormBeClosed = canFormBeClosed;
			InitializeComponents();

			if (!string.IsNullOrWhiteSpace(formName))
			{
				form.Text = formName;
				_labelCaption = CreateFormCaption(formName);
				MainPanel.Controls.Add(_labelCaption);
			}
			if (icon != null)
			{
				MainPanel.Controls.Add(CreateFormIcon(icon));
				form.Icon = icon;
			}

			_form = form;
			_form.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
			_form.Load += Form_Load;
			_form.Controls.Add(MainPanel);
		}

		#region Initialization
		private void Form_Load(object sender, EventArgs e)
		{
			_formBorderRadius = _form.guna2BorderlessForm.BorderRadius;
			if (_form.WindowState == FormWindowState.Maximized)
				_form.guna2BorderlessForm.BorderRadius = 0;

			MoveFormElementsDown(_form);
			_form.Height += DEFAULT_PANEL_HEIGHT;
		}

		private void InitializeComponents()
		{
			InitializeMainPanel();

			if (_scalingForm.Minimize)
			{
				_button.Minimize = CreateIconButton(IconChar.WindowMinimize);
				_button.Minimize.Click += ButtonMinimize_Click;
				MainPanel.Controls.Add(_button.Minimize);
			}

			if (_scalingForm.Maximize)
			{
				_button.Maximize = CreateIconButton(IconChar.WindowRestore);
				_button.Maximize.Click += ButtonMaximize_Click;
				MainPanel.Controls.Add(_button.Maximize);
			}

			if (_canFormBeClosed)
			{
				_button.Close = CreateIconButton(IconChar.TimesCircle);
				_button.Close.Click += ButtonClose_Click;
				_button.Close.MouseEnter += ButtonClose_MouseEnter;
				_button.Close.MouseLeave += ButtonClose_MouseLeave;
				MainPanel.Controls.Add(_button.Close);
			}
		}
		private void InitializeMainPanel()
		{
			const int LEFT_PADDING = 6;

			MainPanel.Name = MAIN_PANEL_NAME;
			MainPanel.BackColor = _defaultPanelColor.WhiteTheme;
			MainPanel.Dock = DockStyle.Top;
			MainPanel.Size = new Size(0, DEFAULT_PANEL_HEIGHT);
			MainPanel.Padding = new Padding(LEFT_PADDING, 0, 0, 0);

			ToggleEventHandlers(MainPanel, true);
		}
		private void MoveFormElementsDown(Control control)
		{
			Point movedLocation = new Point(control.Location.X, control.Location.Y +
				DEFAULT_PANEL_HEIGHT);
			if (control.Tag != null && control.Tag.ToString().Contains(FIXED_CONTROL_POSITION_TAG))
				movedLocation = new Point(control.Location.X, control.Location.Y);

			if (control.HasChildren && !(control is NumericUpDown)
				&& !(control is Guna2TextBox) && !(control is Guna2CheckBox))
			{
				foreach (Control item in control.Controls)
					MoveFormElementsDown(item);

				if (control.Tag != null && control.Tag.ToString().ToLower().
					Contains(MOVE_PARENT_CONTROL_DOWN_TAG.ToLower()))
					control.Location = movedLocation;
			}

			else if (!control.Anchor.HasFlag(AnchorStyles.Bottom))
				control.Location = movedLocation;
		}

		private IconButton CreateIconButton(IconChar iconChar)
		{
			const int PADDING = 15;
			const int SIZE = 25;

			IconButton iconButton = new IconButton
			{
				Anchor = AnchorStyles.Top | AnchorStyles.Right,
				Dock = DockStyle.Right,
				Size = new Size(DEFAULT_PANEL_HEIGHT + PADDING, 0),
				IconSize = SIZE,
				IconColor = _defaultButtonColor.WhiteTheme,
				FlatStyle = FlatStyle.Flat,
				Cursor = Cursors.Hand,
				TabStop = false,
				IconChar = iconChar
			};
			iconButton.FlatAppearance.BorderSize = 0;

			return iconButton;
		}
		private PictureBox CreateFormIcon(System.Drawing.Icon icon)
		{
			const int SIZE = 27;

			PictureBox iconPictureBox = new PictureBox()
			{
				Anchor = AnchorStyles.Top | AnchorStyles.Left,
				Dock = DockStyle.Left,
				Size = new Size(SIZE, 0),
				Image = icon.ToBitmap(),
				SizeMode = PictureBoxSizeMode.Zoom,
			};

			ToggleEventHandlers(iconPictureBox, true);

			return iconPictureBox;
		}
		private Label CreateFormCaption(string name)
		{
			const int MAX_NAME_LENGTH = 80;

			if (name.Length > MAX_NAME_LENGTH)
				name = name.Substring(0, MAX_NAME_LENGTH) + "...";
			Label labelName = new Label()
			{
				Anchor = AnchorStyles.Top | AnchorStyles.Left,
				Dock = DockStyle.Fill,
				ForeColor = _defaultNameColor.WhiteTheme,
				Text = name,
				TextAlign = ContentAlignment.MiddleLeft,
				Font = _formNameFont,
			};

			ToggleEventHandlers(labelName, true);

			return labelName;
		}
		#endregion

		#region Theme
		public void ChangeTheme(Theme theme)
		{
			_currentTheme = theme;
			switch (theme)
			{
				case Theme.White:
					SetWhiteTitleBar();
					break;
				case Theme.Black:
					SetBlackTitleBar();
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}

		private void SetWhiteTitleBar()
		{
			if (MainPanel != null)
				MainPanel.BackColor = _defaultPanelColor.WhiteTheme;
			if (_button.Minimize != null)
				_button.Minimize.IconColor = _defaultButtonColor.WhiteTheme;
			if (_button.Maximize != null)
				_button.Maximize.IconColor = _defaultButtonColor.WhiteTheme;
			if (_button.Close != null)
				_button.Close.IconColor = _defaultButtonColor.WhiteTheme;
			if (_labelCaption != null)
				_labelCaption.ForeColor = _defaultNameColor.WhiteTheme;
		}
		private void SetBlackTitleBar()
		{
			if (MainPanel != null)
				MainPanel.BackColor = _defaultPanelColor.BlackTheme;
			if (_button.Minimize != null)
				_button.Minimize.IconColor = _defaultButtonColor.BlackTheme;
			if (_button.Maximize != null)
				_button.Maximize.IconColor = _defaultButtonColor.BlackTheme;
			if (_button.Close != null)
				_button.Close.IconColor = _defaultButtonColor.BlackTheme;
			if (_labelCaption != null)
				_labelCaption.ForeColor = _defaultNameColor.BlackTheme;
		}
		#endregion
		public void ChangeFormCaption(string newCaption) => _labelCaption.Text = newCaption;
		public void Dispose()
		{
			_form.Load -= Form_Load;
			ToggleEventHandlers(MainPanel, false);
			foreach (Control control in MainPanel.Controls)
			{
				if (control is IconButton iconButton)
				{
					iconButton.Click -= ButtonMinimize_Click;
					iconButton.Click -= ButtonMaximize_Click;
					iconButton.Click -= ButtonClose_Click;
				}
				else if (control is PictureBox pictureBox)
					ToggleEventHandlers(pictureBox, false);
				else if (control is Label label)
					ToggleEventHandlers(label, false);
			}
			if (_button.Close != null)
			{
				_button.Close.MouseEnter -= ButtonClose_MouseEnter;
				_button.Close.MouseLeave -= ButtonClose_MouseLeave;
			}
			MainPanel.Dispose();
		}

		private void ToggleWindowState()
		{
			if (_form.WindowState == FormWindowState.Maximized)
			{
				_form.guna2BorderlessForm.BorderRadius = _formBorderRadius;
				_form.WindowState = FormWindowState.Normal;
				_form.StartPosition = FormStartPosition.CenterScreen;
			}
			else
			{
				_form.guna2BorderlessForm.BorderRadius = 0;
				_form.WindowState = FormWindowState.Maximized;
			}
		}
		private void ToggleEventHandlers(Control control, bool subscribe)
		{
			if (subscribe)
			{
				control.DoubleClick += Control_DoubleClick;
				control.MouseDown += Control_MouseDown;
				control.MouseUp += Control_MouseUp;
				control.MouseMove += Control_MouseMove;
			}
			else
			{
				control.DoubleClick -= Control_DoubleClick;
				control.MouseDown -= Control_MouseDown;
				control.MouseUp -= Control_MouseUp;
				control.MouseMove -= Control_MouseMove;
			}
		}

		#region Event handlers
		private void ButtonMaximize_Click(object sender, EventArgs e)
		{
			_form.ActiveControl = null;
			ToggleWindowState();
		}
		private void ButtonMinimize_Click(object sender, EventArgs e)
		{
			_form.ActiveControl = null;
			_form.WindowState = FormWindowState.Minimized;
		}

		private void ButtonClose_MouseEnter(object sender, EventArgs e)
		{
			if (sender is IconButton button)
				button.BackColor = _hoverButtonExitColor;
		}
		private void ButtonClose_MouseLeave(object sender, EventArgs e)
		{
			if (sender is IconButton button)
				button.BackColor = Color.Transparent;
		}
		private void ButtonClose_Click(object sender, EventArgs e)
			=> _form.Close();

		private void Control_DoubleClick(object sender, EventArgs e)
		{ if (_scalingForm.Maximize) ToggleWindowState(); }
		private void Control_MouseDown(object sender, MouseEventArgs e)
		{
			if (_form.WindowState == FormWindowState.Maximized)
			{
				ToggleWindowState();
				int screenWidth = Screen.PrimaryScreen.Bounds.Width;

				// Transfer the cursor coordinate from the screen range to the form range
				int offsetX = (int)(Cursor.Position.X / (double)screenWidth * _form.Width);
				_form.Location = new Point(Cursor.Position.X - offsetX, Cursor.Position.Y);
			}

			_isFormDragging = true;
			_dragCursorPoint = Cursor.Position;
			_dragFormPoint = _form.Location;

			switch (_currentTheme)
			{
				case Theme.White:
					MainPanel.BackColor = _pressedPanelColor.WhiteTheme;
					break;
				case Theme.Black:
					MainPanel.BackColor = _pressedPanelColor.BlackTheme;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {_currentTheme}");
			}
		}
		private void Control_MouseUp(object sender, EventArgs e)
		{
			_isFormDragging = false;
			switch (_currentTheme)
			{
				case Theme.White:
					MainPanel.BackColor = _defaultPanelColor.WhiteTheme;
					break;
				case Theme.Black:
					MainPanel.BackColor = _defaultPanelColor.BlackTheme;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {_currentTheme}");
			}
		}
		private void Control_MouseMove(object sender, EventArgs e)
		{
			if (_isFormDragging)
			{
				Point difference = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
				_form.Location = Point.Add(_dragFormPoint, new Size(difference));
			}
		}
		#endregion
	}
}