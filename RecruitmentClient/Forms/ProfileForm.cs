using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using RecruitmentClient.ClientUtilities;
using RecruitmentClient.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentClient.Forms
{
	internal partial class ProfileForm : BaseForm, IThemeChange
	{// Форма запису кандидата
		private readonly ClientAccount account;
		private readonly StartForm startForm;
		private readonly Candidate oldCandidate;
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		internal ProfileForm(ClientAccount a, StartForm startForm = null)
		{// Конструктор
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Профіль", Properties.Resources.profile, maximizeBox: false);
			account = a;// Передаємо посилання на акаунт
			if (account.candidate == null)
				account.candidate = new Candidate();
			else// Якщо вже був заповнений профіль, то записуємо його значення
				SetFormValues(account);

			this.startForm = startForm;
			if (this.startForm == null)// Якщо форма відкрита для зміни даних
				oldCandidate = new Candidate(account.candidate);// Зберігаємо дані кандидата
		}
		private void ProfileForm_Load(object sender, EventArgs e)
		{// Обробник події завантаження форми
			Icon = Properties.Resources.profile;
			textBoxSurname.Focus();
			dateTimePickerBirthday.MaxDate = DateTime.Today;
			buttonEventHandlers.SubscribeToHover(buttonQuestionnairе, buttonApply);
			SetTheme(account.Theme);
		}

		private void SetFormValues(ClientAccount a)
		{// Метод записує дані з класу Account в форму
			textBoxSurname.Text = a.candidate.Surname;
			textBoxName.Text = a.candidate.Name;
			textBoxFatherName.Text = a.candidate.FatherName;
			textBoxPhone1.Text = a.candidate.Phone.Substring(4, 3);
			textBoxPhone2.Text = a.candidate.Phone.Substring(7, 3);
			textBoxPhone3.Text = a.candidate.Phone.Substring(10, 3);
			dateTimePickerBirthday.Value = a.candidate.Birthday;
			textBoxEmail.Text = a.candidate.Email;
		}
		private bool CheckValidData()
		{// Метод перевіряє та показує які дані були введені не вірно
			bool isDataOk = true;
			SetDefaultLabels(account.Theme);
			// Прізвище
			Validator.CheckSymbols(labelSurname, textBoxSurname, account.Theme, ref isDataOk, ValidLanguage.UA, "’-");
			Validator.CheckMinLength(labelSurname, textBoxSurname, 2, account.Theme, ref isDataOk);
			// Ім’я
			Validator.CheckSymbols(labelName, textBoxName, account.Theme, ref isDataOk, ValidLanguage.UA, "’-");
			Validator.CheckMinLength(labelName, textBoxName, 2, account.Theme, ref isDataOk);
			// По-батькові
			Validator.CheckSymbols(labelFatherName, textBoxFatherName, account.Theme, ref isDataOk, ValidLanguage.UA, "’-");

			// Номер телефону
			Validator.CheckAllNumbers(labelPhone, textBoxPhone1, account.Theme, ref isDataOk);
			Validator.CheckAllNumbers(labelPhone, textBoxPhone2, account.Theme, ref isDataOk);
			Validator.CheckAllNumbers(labelPhone, textBoxPhone3, account.Theme, ref isDataOk);
			Validator.CheckMinLength(labelPhone, textBoxPhone1, 3, account.Theme, ref isDataOk);
			Validator.CheckMinLength(labelPhone, textBoxPhone2, 3, account.Theme, ref isDataOk);
			Validator.CheckMinLength(labelPhone, textBoxPhone3, 3, account.Theme, ref isDataOk);

			CheckValidEmail(ref isDataOk);// E-mail

			if (account.candidate.questionnaire == null)
			{// Анкета
				if (isDataOk)
				{
					buttonQuestionnairе.Focus();
					CustomMessageBox.Show("Дані були введені не вірно!\nАнкету також потрібно заповнити.",
						account.Theme, "Помилка введення", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
				isDataOk = false;
			}

			return isDataOk;
		}
		private void CheckValidEmail(ref bool isDataOk)
		{// Метод перевіряє на правильність E-mail
			string pattern = @"^.+@.{2,}\..{2,}$";
			string email = textBoxEmail.Text;
			if (!Regex.IsMatch(email, pattern))
				ValidationFeedbackManager.ShowWrongLabel(labelEmail, $"{labelEmail.Text} рядок не схожий на E-mail.\n" +
					$"Він повинен мати наступний вигляд: [1;∞)@[2;∞).[2;∞), де запис [n;m) - " +
					$"кількість символів.", account.Theme, ref isDataOk, textBoxEmail);

			if (email.Contains(Client.SEPARATOR.ToString()))
				ValidationFeedbackManager.ShowWrongLabel(labelEmail, $"E-mail не може мати такий символ: {Client.SEPARATOR}.",
					account.Theme, ref isDataOk, textBoxEmail);
		}
		private void SetDefaultLabels(Theme theme)
		{// Метод встановлює значення label-ів за замовчуванням
			ValidationFeedbackManager.SetDefaultLabels(theme, labelSurname, labelName,
				labelFatherName, labelPhone, labelEmail);
		}

		// Обробники подій
		private void TextBoxPhone_TextChanged(object sender, EventArgs e)
		{// Обробник події введення номеру телефону
		 // Коли ввели 3 символи перемикаємось далі
			if (sender is TextBox textBox && textBox.Text.Length == 3)
				ProcessTabKey(true);
		}
		private void ButtonQuestionnaire_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Анкета"
			QuestionnaireForm qf = new QuestionnaireForm(account, startForm);
			qf.Show();
			// Додаємо обробник події: коли закриється форма з анкетою,
			// то перша форма стане знову видимою
			qf.FormClosed += (s, args) => { Visible = true; };
			Visible = false;
		}
		private void ButtonApply_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Застосувати"
			if (CheckValidData())// Якщо дані правильно заповнені
				try
				{
					// Перевірка номеру телефону та E-mail та логіну на унікальність
					if (!ClientUnique.PhoneIsUnique(labelPhone, account.Login, $"{labelPhoneStart.Text}" +
						$"{textBoxPhone1.Text}{textBoxPhone2.Text}{textBoxPhone3.Text}", account.Theme)
					|| !ClientUnique.EmailIsUnique(labelEmail, account.Login, textBoxEmail.Text, account.Theme))
						return;

					// Встановлюємо значення кандидата
					account.candidate = new Candidate(textBoxSurname.Text, textBoxName.Text, textBoxFatherName.Text,
					$"{labelPhoneStart.Text}{textBoxPhone1.Text}{textBoxPhone2.Text}{textBoxPhone3.Text}",
					dateTimePickerBirthday.Value, textBoxEmail.Text, account.candidate.questionnaire);

					if (startForm != null)
					{// Якщо потрібно створити кандидата                        
						if (!ClientUnique.LoginIsUnique(new Label() { Text = "Логін" }, account.Login, account.Theme))
							return;

						if (startForm.NeedToRemember)// Запис в файл при потребі
							Serializator.Serialize(account, Program.SerializePath, Program.EncryptKey);
						OpenMainForm();
						Client.CreateCandidate(account);// Відправка даних на сервер
					}
					else
					{// Якщо потрібно змінити кандидата
						Client.ChangeCandidate(account.Login, oldCandidate, account.candidate);
						// Запис в файл при потребі
						if (Serializator.SerializationFileExists(Program.SerializePath))
							Serializator.Serialize(account, Program.SerializePath, Program.EncryptKey);
						Close();
					}
				}
				catch (System.Net.Sockets.SocketException)
				{
					CustomMessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
						"\nСпробуйте, будь ласка, пізніше.", account.Theme, "Помилка підключення",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
		}
		private void OpenMainForm()
		{// Метод відкриває головну форму
			MainForm mf = new MainForm(account);
			mf.Show();
			mf.FormClosed += (s, args) =>
			{// Обробник події закриття головної форми
				Close();
				startForm.Close();
			};
			Visible = false;
		}
		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);

		private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
		{// Обробник події: закриття форми
			buttonEventHandlers.UnsubscribeAll();
			if (startForm != null)
			{
				startForm.Visible = true;
				account.candidate = null;
			}
		}
	}
}