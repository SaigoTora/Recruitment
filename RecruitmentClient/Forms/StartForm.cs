using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecruitmentClient.Models;
using RecruitmentLibrary.Serialization;
using SharedModels.DTOs;
using SharedModels.Models;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentClient.Forms
{
	internal partial class StartForm : BaseForm, IThemeChange
	{// Login and registration form
		private const int OFFSET_LABEL_PASSWORD_X = 106;
		private const int OFFSET_FORM_REGISTRATION_HEIGHT = 80;

		internal bool NeedToRemember { get; private set; }

		private readonly Account _account = new Account();
		private readonly CheckBoxEventHandlers _checkBoxEventHandlers =
			new CheckBoxEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers =
			new PictureBoxEventHandlers();

		private bool _isPasswordVisible = false;
		private byte _countWrongLogin = 0;


		internal StartForm()
		{// Constructor for login or registration
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Вхід",
				Properties.Resources.login, maximizeBox: false);
		}
		internal StartForm(Account account)
		{// Constructor for password change
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Підтвердіть свій пароль",
				maximizeBox: false);
			_account = account;
			SetFormElementsForChangePassword();
		}
		private void StartForm_Load(object sender, EventArgs e)
		{
			_checkBoxEventHandlers.SubscribeToHoverShadow(checkBoxRememberMe);
			_labelEventHandlers.SubscribeToHoverUnderline(labelRegisterStart);
			_pictureBoxEventHandlers.SubscribeToHover(pictureBoxTheme);

			SetTheme(_account.Theme);
		}

		private void SetFormElementsForChangePassword()
		{
			Icon = Properties.Resources.profile;
			textBoxLogin.Text = _account.Candidate.Login;
			textBoxLogin.ReadOnly = true;
			textBoxLogin.BorderThickness = 0;
			ActiveControl = textBoxPassword;

			labelPassword.Text = "Старий пароль:";
			MoveElement(labelPassword, -OFFSET_LABEL_PASSWORD_X, 0);
			MoveInputFormElements(true);

			labelRememberMe.Visible = false;
			checkBoxRememberMe.Visible = false;
			labelRegisterStart.Visible = false;
			pictureBoxTheme.Visible = false;
			buttonLogin.Text = "Підтвердити";
			buttonLogin.Click -= ButtonLogin_Click;
			buttonLogin.Click += ButtonChangePassword_Click;
		}
		private void MoveElement(Control control, int x, int y)
			=> control.Location = new System.Drawing.Point(control.Location.X + x,
				control.Location.Y + y);

		#region Registration
		private void LabelRegisterStart_Click(object sender, EventArgs e)
		{
			Size = new Size(Size.Width, Size.Height + OFFSET_FORM_REGISTRATION_HEIGHT);
			SetDefaultFormInputElements();
			ToggleButtonsVisibility(true);
			MoveInputFormElements(true);

			customTitleBar.ChangeFormCaption("Реєстрація");
			labelPassword2.Visible = true;
			textBoxPassword2.Visible = true;

			textBoxLogin.Focus();
		}
		private void ButtonBack_Click(object sender, EventArgs e)
		{
			Size = new Size(Size.Width, Size.Height - OFFSET_FORM_REGISTRATION_HEIGHT);
			SetDefaultFormInputElements();
			SetDefaultLabels(_account.Theme);
			ToggleButtonsVisibility(false);
			MoveInputFormElements(false);

			customTitleBar.ChangeFormCaption("Вхід");
			labelPassword2.Visible = false;
			textBoxPassword2.Visible = false;
			textBoxPassword2.Text = string.Empty;
		}
		private async void ButtonRegisterContinue_Click(object sender, EventArgs e)
		{
			SetDefaultLabels(_account.Theme);

			if (CheckValidInputData())
				try
				{
					bool isLoginUnique = await Program.UniqueChecker.CheckLoginUniqueAsync(labelLogin,
						textBoxLogin.Text, _account.Theme);
					if (isLoginUnique)
					{
						_account.Candidate.ChangeLoginPassword(textBoxLogin.Text,
							textBoxPassword.Text);
						ProfileForm pf = new ProfileForm(_account, this);
						pf.Show();
						Visible = false;
					}
				}
				catch (SocketException)
				{
					CustomMessageBox.Show("Спроба підключитись до серверу " +
						"завершилась не вдало.\nСпробуйте пізніше.",
						_account.Theme, "Помилка підключення",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
		}

		private void SetDefaultFormInputElements()
		{
			textBoxLogin.Text = string.Empty;
			textBoxPassword.Text = string.Empty;
			textBoxPassword2.Text = string.Empty;
			checkBoxRememberMe.Checked = false;
		}
		private void SetDefaultLabels(Theme theme)
			=> ValidationFeedbackManager.ResetLabelsToDefault(theme,
				labelLogin, labelPassword, labelPassword2);
		private void ToggleButtonsVisibility(bool isRegistrationStart)
		{
			labelRegisterStart.Visible = !isRegistrationStart;
			buttonLogin.Visible = !isRegistrationStart;
			buttonBack.Visible = isRegistrationStart;
			buttonRegisterContinue.Visible = isRegistrationStart;
		}
		private void MoveInputFormElements(bool moveRight)
		{
			const int OFFSET_LOGIN_X = 110;
			const int OFFSET_REMEMBER_Y = 78;

			int k = 1;
			if (!moveRight)
				k = -1;

			MoveElement(labelRememberMe, OFFSET_LOGIN_X * k, OFFSET_REMEMBER_Y * k);
			MoveElement(checkBoxRememberMe, OFFSET_LOGIN_X * k, OFFSET_REMEMBER_Y * k);
			MoveElement(labelLogin, OFFSET_LOGIN_X * k, 0);
			MoveElement(labelPassword, OFFSET_LOGIN_X * k, 0);
			MoveElement(textBoxLogin, OFFSET_LOGIN_X * k, 0);
			MoveElement(textBoxPassword, OFFSET_LOGIN_X * k, 0);
			MoveElement(pictureBoxShowPwd, OFFSET_LOGIN_X * k, 0);
		}
		#endregion

		private bool CheckValidInputData()
		{
			Validator validator = new Validator();

			validator.CheckSymbols(labelLogin, textBoxLogin,
				_account.Theme, ValidLanguage.ENG, "._-0123456789");
			validator.CheckMinLength(labelLogin, textBoxLogin, 4, _account.Theme);

			validator.CheckSymbols(labelPassword, textBoxPassword,
				_account.Theme, ValidLanguage.ENG, "@-_.*0123456789");
			validator.CheckMinLength(labelPassword, textBoxPassword, 8, _account.Theme);
			validator.CheckMinCountSymbols(labelPassword, textBoxPassword,
				_account.Theme, 2, "0123456789", "Пароль повинен мати хоча б дві цифри.");
			validator.CheckMinCountSymbols(labelPassword, textBoxPassword,
				_account.Theme, 4, "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
				"Пароль повинен мати хоча б чотири англійські літери.");

			bool isDataValid = validator.IsDataValid;

			// Password confirmation check
			if (labelPassword2.Visible && textBoxPassword2.Visible
			&& textBoxPassword.Text != textBoxPassword2.Text)
				ValidationFeedbackManager.HighlightInvalidLabel(labelPassword2,
					$"Підтвердження пароля не вірне!", _account.Theme,
					ref isDataValid, textBoxPassword2);

			if (textBoxLogin.Text == textBoxPassword.Text)
			{
				ValidationFeedbackManager.HighlightInvalidLabel(labelLogin,
					"Логін не може співпадати з паролем.", _account.Theme, ref isDataValid);
				ValidationFeedbackManager.HighlightInvalidLabel(labelPassword);
			}

			return isDataValid;
		}

		#region Login
		private async void ButtonLogin_Click(object sender, EventArgs e)
		{
			buttonLogin.Enabled = false;
			SetDefaultLabels(_account.Theme);
			Validator validator = new Validator();

			validator.CheckBannedChar(labelLogin, textBoxLogin.Text,
				Client.SEPARATOR, _account.Theme);
			validator.CheckBannedChar(labelPassword,
				textBoxPassword.Text, Client.SEPARATOR, _account.Theme);

			if (!validator.IsDataValid)
			{
				buttonLogin.Enabled = true;
				return;
			}

			try
			{
				CandidateLoginDTO candidateLogin = new CandidateLoginDTO(textBoxLogin.Text,
					textBoxPassword.Text);
				Candidate candidate = await Program.Client.
					PostCandidateLoginAsync(candidateLogin);
				if (candidate == null)
				{
					buttonLogin.Enabled = true;
					HandleUserNotFound();
					return;
				}

				_account.Candidate = candidate;
				_account.Candidate.ChangeLoginPassword(candidateLogin.Login,
					candidateLogin.Password);
				if (NeedToRemember)
					Serializator.Serialize(_account, Program.SerializePath, Program.EncryptKey);

				OpenMainForm();
			}
			catch (SocketException)
			{
				CustomMessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
					"\nСпробуйте, будь ласка, пізніше.", _account.Theme, "Помилка підключення",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				buttonLogin.Enabled = true;
			}
		}

		private async Task BlockActionsAfterFailedAttempts()
		{
			const byte TIME_INACTIVITY = 15;

			buttonLogin.Enabled = false;
			labelRegisterStart.Enabled = false;

			string text = buttonLogin.Text;
			for (int i = TIME_INACTIVITY; i >= 1; i--)
			{
				buttonLogin.Text = $"{text}({i})";
				await Task.Delay(TimeSpan.FromSeconds(1));
			}
			buttonLogin.Text = text;

			buttonLogin.Enabled = true;
			labelRegisterStart.Enabled = true;
		}
		private void OpenMainForm()
		{
			MainForm mainForm = new MainForm(_account);
			mainForm.Show();
			mainForm.FormClosed += (s, args) => { Close(); };
			Visible = false;
			CustomMessageBox.Show($"Ви успішно увійшли до свого акаунту." +
				$"\nЛаскаво просимо!", _account.Theme, "Успіх",
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
		}
		private void HandleUserNotFound()
		{
			byte MAX_COUNT_WRONG_LOGIN = 3;

			string countMessage = string.Empty;
			_countWrongLogin++;
			if (_countWrongLogin >= MAX_COUNT_WRONG_LOGIN)
			{
				_ = BlockActionsAfterFailedAttempts();
				countMessage = $"\nВи перевищили ліміт уведення неправильних даних.";
				_countWrongLogin = 0;
			}

			CustomMessageBox.Show($"Логін та/або пароль введені не вірно! {countMessage}",
				_account.Theme, "Помилка", CustomMessageBoxButtons.OK,
				CustomMessageBoxIcon.Error);
		}
		#endregion

		#region Change password
		private async void ButtonChangePassword_Click(object sender, EventArgs e)
		{
			SetDefaultLabels(_account.Theme);

			if (!labelPassword2.Visible && !textBoxPassword2.Visible)
				CheckOldPassword();
			else if (CheckValidInputData())
				await CheckNewPasswordAsync();
		}
		private void CheckOldPassword()
		{
			if (_account.Candidate.Password != textBoxPassword.Text)
				CustomMessageBox.Show("Старий пароль введений не вірно!", _account.Theme,
					"Помилка", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			else
				SetUpFormToEnterNewPassword();
		}
		private async Task CheckNewPasswordAsync()
		{
			if (_account.Candidate.Password == textBoxPassword.Text)
				CustomMessageBox.Show("Новий пароль не може співпадати зі старим!",
					_account.Theme, "Помилка", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Error);
			else
			{
				DialogResult result = CustomMessageBox.Show("Ви впевнені, " +
					"що хочете змінити пароль?", _account.Theme, "Зміна паролю",
					CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Warning);
				if (result == DialogResult.Yes)
				{
					await ChangePasswordAsync();

					if (Serializator.SerializationFileExists(Program.SerializePath))
						Serializator.Serialize(_account, Program.SerializePath,
							Program.EncryptKey);

					Close();
				}
			}
		}

		private void SetUpFormToEnterNewPassword()
		{
			labelPassword2.Visible = true;
			textBoxPassword2.Visible = true;
			textBoxPassword.Text = "";
			labelPassword.Text = "Пароль:";
			MoveElement(labelPassword, OFFSET_LABEL_PASSWORD_X, 0);
			buttonLogin.Text = "Змінити";
			customTitleBar.ChangeFormCaption("Введіть новий пароль");

			textBoxPassword.Focus();
			CustomMessageBox.Show("Ви правильно ввели свій старий пароль!" +
				"\nТепер введіть новий пароль та підтвердіть його.",
				_account.Theme, "Підтверджено",
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
		}
		private async Task ChangePasswordAsync()
		{
			try
			{
				var candidateChangePassword = new CandidateChangePasswordDTO(_account.Candidate.Id,
					textBoxPassword.Text);
				await Program.Client.PutCandidatePasswordAsync(
					candidateChangePassword);
			}
			catch (SocketException)
			{
				CustomMessageBox.Show("Спроба підключитись до серверу " +
					"завершилась не вдало.\nСпробуйте, будь ласка, пізніше.",
					_account.Theme, "Помилка підключення",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}
			_account.Candidate.ChangeLoginPassword(_account.Candidate.Login, textBoxPassword.Text);
		}
		#endregion

		private void PictureBoxShowPwd_Click(object sender, EventArgs e)
		{
			SetPasswordVisibilityIcon(_account.Theme);

			_isPasswordVisible = !_isPasswordVisible;
			if (_isPasswordVisible)
				textBoxPassword.PasswordChar = '\0';
			else
				textBoxPassword.PasswordChar = '*';
		}
		private void SetPasswordVisibilityIcon(Theme theme)
		{
			switch (theme)
			{
				case Theme.White:
					{

						if (_isPasswordVisible)
							pictureBoxShowPwd.Image = Properties.Resources.eyeClB;
						else
							pictureBoxShowPwd.Image = Properties.Resources.eyeOpB;
						break;
					}
				case Theme.Black:
					{
						if (_isPasswordVisible)
							pictureBoxShowPwd.Image = Properties.Resources.eyeClW;
						else
							pictureBoxShowPwd.Image = Properties.Resources.eyeOpW;
						break;
					}
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}

		private void CheckBoxRememberMe_CheckedChanged(object sender, EventArgs e)
			=> NeedToRemember = checkBoxRememberMe.Checked;

		#region Label focus event handlers
		private void LabelLogin_Click(object sender, EventArgs e)
			=> textBoxLogin.Focus();
		private void LabelPassword_Click(object sender, EventArgs e)
			=> textBoxPassword.Focus();
		private void LabelPassword2_Click(object sender, EventArgs e)
			=> textBoxPassword2.Focus();
		private void LabelRememberMe_Click(object sender, EventArgs e)
			=> checkBoxRememberMe.Checked = !checkBoxRememberMe.Checked;
		#endregion

		#region TextBox event handlers
		private void TextBoxLogin_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				textBoxPassword.Focus();
			}
		}
		private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				if (textBoxPassword2.Visible)
					textBoxPassword2.Focus();
				else
					ClickNextButton();
			}
		}
		private void TextBoxPassword2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				ClickNextButton();
			}

		}
		private void ClickNextButton()
		{
			if (buttonLogin.Visible)
				buttonLogin.PerformClick();
			else if (buttonRegisterContinue.Visible)
				buttonRegisterContinue.PerformClick();
		}
		#endregion

		#region Theme
		private void PictureBoxTheme_Click(object sender, EventArgs e)
		{
			switch (_account.Theme)
			{
				case Theme.White:
					_account.Theme = Theme.Black;
					break;
				case Theme.Black:
					_account.Theme = Theme.White;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {_account.Theme}");
			}

			SetDefaultLabels(_account.Theme);
			SetTheme(_account.Theme);
		}
		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);
			SetPasswordTheme(theme);

			switch (theme)
			{
				case Theme.White:
					pictureBoxTheme.Image = Properties.Resources.sun;
					break;
				case Theme.Black:
					pictureBoxTheme.Image = Properties.Resources.moon;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		private void SetPasswordTheme(Theme theme)
		{
			switch (theme)
			{
				case Theme.White:
					{
						if (_isPasswordVisible)
							pictureBoxShowPwd.Image = Properties.Resources.eyeOpB;
						else
							pictureBoxShowPwd.Image = Properties.Resources.eyeClB;
						break;
					}
				case Theme.Black:
					{
						if (_isPasswordVisible)
							pictureBoxShowPwd.Image = Properties.Resources.eyeOpW;
						else
							pictureBoxShowPwd.Image = Properties.Resources.eyeClW;
						break;
					}
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		#endregion

		private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonLogin.Click -= ButtonChangePassword_Click;

			_checkBoxEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();
			_pictureBoxEventHandlers.UnsubscribeAll();
		}
	}
}