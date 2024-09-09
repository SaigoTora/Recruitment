using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;
using RecruitmentLibrary.FormUtilities;
using RecruitmentUser.ClientUtilities;
using RecruitmentUser.FormUtilities;

namespace RecruitmentUser.Forms
{
	internal partial class StartForm : Form, IThemeChange
	{// Форма входу та реєстрації
		private const int OFFSET_PASSWORD_X = 106;// Відступи для елементів форми
		private const int OFFSET_REMEMBER_Y = 78;
		private const int OFFSET_LOGIN_X = 110;
		private const int OFFSET_SIZE_Y = 80;
		private const byte MAX_COUNT_WRONG_LOGIN = 3;
		private const byte TIME_INACTIVITY = 15;

		private readonly ClientAccount account = new ClientAccount();
		private readonly PictureBoxEventHandlers pictureBoxEventHandlers = new PictureBoxEventHandlers();
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		private bool isPasswordVisible = false;
		private byte countWrongLogin = 0;

		internal bool NeedToRemember { get; private set; }// Чи потрібно запам’ятовувати користувача

		// Констуктори
		internal StartForm()
		{// Конструктор першого запуску
			InitializeComponent();
		}
		internal StartForm(ClientAccount a) : this()
		{// Конструктор зміни паролю запуску
			if (a != null)
			{// Якщо форма відкрита для зміни паролю
				account = a;
				SetFormElementsChangePassword();
			}
		}
		private void StartForm_Load(object sender, EventArgs e)
		{
			Icon = Properties.Resources.login;
			pictureBoxEventHandlers.SubscribeToHover(pictureBoxShowPwd, pictureBoxTheme);
			buttonEventHandlers.SubscribeToHover(buttonLogin, buttonRegister2, buttonBack);
			SetTheme(account.Theme);
		}

		private void SetFormElementsChangePassword()
		{// Метод змінює елементи форми коли користувач змінює пароль
			textBoxLogin.Text = account.Login;
			textBoxLogin.Enabled = false;

			labelPassword.Text = "Старий пароль:";
			OffsetElement(labelPassword, -OFFSET_PASSWORD_X, 0);
			SetOffsetsAfterClick(true);

			checkBoxRememberMe.Visible = false;

			Text = "Підтвердіть свій пароль";
			labelRegister1.Visible = false;
			buttonLogin.Text = "Підтвердити";
			pictureBoxTheme.Visible = false;
			ShowIcon = false;
			buttonLogin.Click -= ButtonLogin_Click;
			buttonLogin.Click += ButtonChangePassword_Click;
		}
		private bool CheckValidData()
		{// Метод перевіряє та показує які дані були введені не вірно
			bool isDataOk = true;

			// Логін
			Validator.CheckSymbols(labelLogin, textBoxLogin, ref isDataOk, ValidLanguage.ENG, "._-0123456789");
			Validator.CheckMinLength(labelLogin, textBoxLogin, 4, ref isDataOk);
			// Пароль
			Validator.CheckSymbols(labelPassword, textBoxPassword, ref isDataOk, ValidLanguage.ENG, "@-_.*0123456789");
			Validator.CheckMinLength(labelPassword, textBoxPassword, 8, ref isDataOk);
			Validator.CheckMinCountSymbols(labelPassword, textBoxPassword, ref isDataOk, 2,
				"0123456789", "Пароль повинен мати хоча б дві цифри.");
			Validator.CheckMinCountSymbols(labelPassword, textBoxPassword, ref isDataOk, 4,
				"ABCDEFGHIJKLMNOPQRSTUVWXYZ", "Пароль повинен мати хоча б чотири літери.");

			// Перевірка підтвердження паролю, якщо підтвердження видиме
			if (labelPassword2.Visible && textBoxPassword2.Visible
			&& textBoxPassword.Text != textBoxPassword2.Text)
				Validator.ShowWrongLabel(labelPassword2,
					$"Підтвердження пароля не вірне!", ref isDataOk, textBoxPassword2);
			// Якщо логін та пароль співпадає
			if (textBoxLogin.Text == textBoxPassword.Text)
			{
				Validator.ShowWrongLabel(labelLogin, "Логін не може співпадати з паролем.", ref isDataOk);
				Validator.ShowWrongLabel(labelPassword);
			}

			return isDataOk;
		}
		private void SetDefaultLabels(Theme theme)
		{// Метод встановлює значення label-ів за замовчуванням
			Validator.SetDefaultLabels(theme, labelLogin, labelPassword, labelPassword2);
		}
		private void OffsetElement(Control control, int x, int y)// Метод переміщує елемент
		{ control.Location = new Point(control.Location.X + x, control.Location.Y + y); }

		private void ButtonRegister2_Click(object sender, EventArgs e)
		{// Обробник події: натискання на кнопку реєстрації
			SetDefaultLabels(account.Theme);
			if (CheckValidData())
			{// Якщо дані введено вірно
				try
				{
					if (ClientUnique.LoginIsUnique(labelLogin, textBoxLogin.Text))
					{// Якщо ввели повторно пароль, а також логін унікальний
						account.SetLoginPassword(textBoxLogin.Text, textBoxPassword.Text);
						ProfileForm pf = new ProfileForm(account, this);
						pf.Show();
						Visible = false;
					}
				}
				catch (System.Net.Sockets.SocketException)
				{
					MessageBox.Show("Спроба підключитись до серверу завершилась не вдало.\nСпробуйте пізніше.", "Помилка підключення",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void ButtonLogin_Click(object sender, EventArgs e)
		{// Обробник події: натискання на кнопку входу
			SetDefaultLabels(account.Theme);
			bool isDataOk = true;// Якщо логін або пароль має заборонений символ, то виходимо
			Validator.CheckBannedChar(labelLogin, textBoxLogin.Text, Client.SEPARATOR, ref isDataOk);
			Validator.CheckBannedChar(labelPassword, textBoxPassword.Text, Client.SEPARATOR, ref isDataOk);
			if (!isDataOk)
				return;

			try
			{
				Candidate candidate = Client.GetCandidate(textBoxLogin.Text, textBoxPassword.Text);
				account.SetLoginPassword(textBoxLogin.Text, textBoxPassword.Text);
				account.candidate = candidate;
				if (NeedToRemember)
					Serializator.Serialize(account, Program.SerializePath, Program.EncryptKey);

				// Відкриваємо головну форму
				MainForm mainForm = new MainForm(account);
				mainForm.Show();
				mainForm.FormClosed += (s, args) => { Close(); };
				Visible = false;

				MessageBox.Show($"Ви успішно увійшли до свого акаунту.\nЛаскаво просимо!", "Успіх",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (ArgumentException ae)
			{
				string msg = string.Empty;
				countWrongLogin++;
				if (countWrongLogin >= MAX_COUNT_WRONG_LOGIN)
				{
					_ = InactivityAsync();
					msg = $"\nВи перевищили ліміт уведення неправильних даних.";
					countWrongLogin = 0;
				}

				MessageBox.Show($"{ae.Message} {msg}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (System.Net.Sockets.SocketException)
			{
				MessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
					"\nСпробуйте, будь ласка, пізніше.", "Помилка підключення",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private async Task InactivityAsync()
		{// Метод, який блокує певні дії користувача на TIME_INACTIVITY секунд
			buttonLogin.Enabled = false;
			labelRegister1.Enabled = false;

			string text = buttonLogin.Text;
			for (int i = TIME_INACTIVITY; i >= 1; i--)
			{
				buttonLogin.Text = $"{text}({i})";
				await Task.Delay(1000);
			}
			buttonLogin.Text = text;

			buttonLogin.Enabled = true;
			labelRegister1.Enabled = true;
		}
		private void LabelRegister1_Click(object sender, EventArgs e)
		{// Обробник події: натискання на label створення акаунту
			Size = new Size(Size.Width, Size.Height + OFFSET_SIZE_Y);
			ClearFormElements();
			SetButtonsVisible(true);
			SetOffsetsAfterClick(true);

			Text = "Реєстрація";
			labelPassword2.Visible = true;
			textBoxPassword2.Visible = true;

			textBoxLogin.Focus();
		}
		private void ButtonBack_Click(object sender, EventArgs e)
		{// Обробник події: натискання на кнопку "Назад"
			Size = new Size(Size.Width, Size.Height - OFFSET_SIZE_Y);
			ClearFormElements();
			SetDefaultLabels(account.Theme);
			SetButtonsVisible(false);
			SetOffsetsAfterClick(false);

			Text = "Вхід";
			labelPassword2.Visible = false;
			textBoxPassword2.Visible = false;
			textBoxPassword2.Text = string.Empty;
		}
		private void ClearFormElements()
		{// Метод очищає дані у елементах форми
			textBoxLogin.Text = string.Empty;
			textBoxPassword.Text = string.Empty;
			textBoxPassword2.Text = string.Empty;
			checkBoxRememberMe.Checked = false;
		}
		private void SetButtonsVisible(bool isCreateButton)
		{// Допоміжний метод який вмикає та вимикає видимість певних кнопок
			labelRegister1.Visible = !isCreateButton;
			buttonLogin.Visible = !isCreateButton;
			buttonBack.Visible = isCreateButton;
			buttonRegister2.Visible = isCreateButton;
		}
		private void SetOffsetsAfterClick(bool isCreateButton)
		{// Допоміжний метод переміщує елементи
			int k = 1;
			if (!isCreateButton)
				k = -1;

			OffsetElement(checkBoxRememberMe, OFFSET_LOGIN_X * k, OFFSET_REMEMBER_Y * k);
			OffsetElement(labelLogin, OFFSET_LOGIN_X * k, 0);
			OffsetElement(labelPassword, OFFSET_LOGIN_X * k, 0);
			OffsetElement(textBoxLogin, OFFSET_LOGIN_X * k, 0);
			OffsetElement(textBoxPassword, OFFSET_LOGIN_X * k, 0);
			OffsetElement(pictureBoxShowPwd, OFFSET_LOGIN_X * k, 0);
		}

		private void ButtonChangePassword_Click(object sender, EventArgs e)
		{// Обробник події: натискання на кнопку зміни паролю
			SetDefaultLabels(account.Theme);

			if (!labelPassword2.Visible && !textBoxPassword2.Visible)
				CheckOldPassword();
			else if (CheckValidData())
				CheckNewPassword();
		}
		private void CheckOldPassword()
		{// Перевірка введення старого паролю
			if (account.Password != textBoxPassword.Text)// Ввели НЕ вірно
				MessageBox.Show("Старий пароль введений не вірно!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			else
			{// Ввели вірно
				labelPassword2.Visible = true;
				textBoxPassword2.Visible = true;
				textBoxPassword.Text = "";
				labelPassword.Text = "Пароль:";
				labelPassword.Location = new Point(labelPassword.Location.X +
				OFFSET_PASSWORD_X, labelPassword.Location.Y);
				buttonLogin.Text = "Змінити";
				Text = "Введіть новий пароль";

				textBoxPassword.Focus();
				MessageBox.Show("Ви правильно ввели свій старий пароль!\nТепер введіть новий пароль та підтвердіть його.", "Підтверджено", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			}

		}
		private void CheckNewPassword()
		{// Перевірка введення нового паролю
			if (account.Password == textBoxPassword.Text)// Ввели НЕ вірно
				MessageBox.Show("Новий пароль не може співпадати зі старим!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			else
			{// Ввели вірно
				DialogResult result = MessageBox.Show("Ви впевнені, що хочете змінити пароль?", "Зміна паролю",
				MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
				if (result == DialogResult.Yes)
				{
					try
					{ Client.ChangePassword(account.Login, account.Password, textBoxPassword.Text); }
					catch (System.Net.Sockets.SocketException)
					{
						MessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
							"\nСпробуйте, будь ласка, пізніше.", "Помилка підключення",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					account.SetLoginPassword(account.Login, textBoxPassword.Text);

					// Серіалізуємо при потребі
					if (Serializator.SerializationFileExists(Program.SerializePath))
						Serializator.Serialize(account, Program.SerializePath, Program.EncryptKey);

					Close();
				}
			}
		}

		private void CheckBoxRememberMe_CheckedChanged(object sender, EventArgs e)
		{ NeedToRemember = checkBoxRememberMe.Checked; }


		// Обробники подій для візуальних ефектів
		private void LabelRegister1_MouseEnter(object sender, EventArgs e)
		{ labelRegister1.Font = new Font(labelRegister1.Font, FontStyle.Underline); }
		private void LabelRegister1_MouseLeave(object sender, EventArgs e)
		{ labelRegister1.Font = new Font(labelRegister1.Font, FontStyle.Regular); }

		private void PictureBoxShowPwd_Click(object sender, EventArgs e)
		{// Обробник події зміни видимості паролю
			if (isPasswordVisible)
			{
				textBoxPassword.PasswordChar = '*';
				if (account.Theme == Theme.White)
					pictureBoxShowPwd.Image = Properties.Resources.eyeClB;
				else if (account.Theme == Theme.Black)
					pictureBoxShowPwd.Image = Properties.Resources.eyeClW;
			}
			else
			{
				textBoxPassword.PasswordChar = '\0';
				if (account.Theme == Theme.White)
					pictureBoxShowPwd.Image = Properties.Resources.eyeOpB;
				else if (account.Theme == Theme.Black)
					pictureBoxShowPwd.Image = Properties.Resources.eyeOpW;
			}
			isPasswordVisible = !isPasswordVisible;
		}
		private void PictureBoxTheme_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку зміни теми
			if (account.Theme == Theme.White)// Якщо тема була світлою
				account.Theme = Theme.Black;
			else if (account.Theme == Theme.Black)// Якщо тема була темною
				account.Theme = Theme.White;

			SetTheme(account.Theme);
		}
		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelLogin, labelPassword, labelPassword2, labelRegister1);
			ColorChanger.ChangeInputControlsColor(theme, textBoxLogin, textBoxPassword, textBoxPassword2);
			ColorChanger.ChangeInputControlsForeColor(theme, checkBoxRememberMe);
			if (theme == Theme.White)
			{// Якщо треба встановити світлу тему
				pictureBoxTheme.Image = Properties.Resources.sun;
				BackColor = ColorChanger.BackColorThemeW;

				if (isPasswordVisible)
					pictureBoxShowPwd.Image = Properties.Resources.eyeOpB;
				else
					pictureBoxShowPwd.Image = Properties.Resources.eyeClB;
			}
			else if (theme == Theme.Black)
			{// Якщо треба встановити темну тему
				pictureBoxTheme.Image = Properties.Resources.moon;
				BackColor = ColorChanger.BackColorThemeB;

				if (isPasswordVisible)
					pictureBoxShowPwd.Image = Properties.Resources.eyeOpW;
				else
					pictureBoxShowPwd.Image = Properties.Resources.eyeClW;
			}
		}

		private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			pictureBoxEventHandlers.UnsubscribeAll();
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}