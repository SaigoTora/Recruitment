using Guna.UI2.WinForms;
using System;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using RecruitmentClient.Models;
using RecruitmentClient.Utilities.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;
using SharedModels.Models;

namespace RecruitmentClient.Forms
{
	internal partial class ProfileForm : BaseForm, IThemeChange
	{
		private readonly Account _account;
		private readonly StartForm _startForm;
		private readonly Candidate _oldCandidate;

		internal ProfileForm(Account account)
		{// Constructor for changing data
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Профіль",
				Properties.Resources.profile, maximizeBox: false);
			_account = account;
			if (_account.candidate == null)
				_account.candidate = new Candidate();
			else
			{
				_oldCandidate = new Candidate(_account.candidate);
				SetFormData(_account);
			}
		}
		internal ProfileForm(Account account, StartForm startForm)
			: this(account)
		{// Constructor for creation
			_startForm = startForm;
		}
		private void ProfileForm_Load(object sender, EventArgs e)
		{
			const int MIN_AGE = 14;

			textBoxSurname.Focus();
			dateTimePickerBirthday.MaxDate = DateTime.Today.AddYears(-MIN_AGE);

			SetTheme(_account.Theme);
		}

		private void SetFormData(Account account)
		{
			textBoxSurname.Text = account.candidate.Surname;
			textBoxName.Text = account.candidate.Name;
			textBoxFatherName.Text = account.candidate.FatherName;

			textBoxPhone1.Text = account.candidate.Phone.Substring(4, 3);
			textBoxPhone2.Text = account.candidate.Phone.Substring(7, 3);
			textBoxPhone3.Text = account.candidate.Phone.Substring(10, 3);

			dateTimePickerBirthday.Value = account.candidate.Birthday;
			textBoxEmail.Text = account.candidate.Email;
		}

		private void SetDefaultLabels(Theme theme)
		{
			ValidationFeedbackManager.ResetLabelsToDefault(theme, labelSurname,
				labelName, labelFatherName, labelPhone, labelEmail);
		}
		private bool CheckUniquePhoneAndEmail()
		{
			return (ClientUniqueChecker.IsPhoneNumberUnique(labelPhone, _account.Login,
						$"{labelPhoneStart.Text}{textBoxPhone1.Text}{textBoxPhone2.Text}" +
						$"{textBoxPhone3.Text}", _account.Theme)
						&& ClientUniqueChecker.IsEmailUnique(labelEmail, _account.Login,
						textBoxEmail.Text, _account.Theme));
		}
		private bool CheckValidData()
		{
			SetDefaultLabels(_account.Theme);

			Validator validator = new Validator();
			validator.CheckSymbols(labelSurname, textBoxSurname,
				_account.Theme, ValidLanguage.UA, "’-");
			validator.CheckMinLength(labelSurname, textBoxSurname, 2, _account.Theme);
			validator.CheckSymbols(labelName, textBoxName, _account.Theme,
				ValidLanguage.UA, "’-");
			validator.CheckMinLength(labelName, textBoxName, 2, _account.Theme);
			validator.CheckSymbols(labelFatherName, textBoxFatherName,
				_account.Theme, ValidLanguage.UA, "’-");

			// Phone number
			validator.CheckAllNumbers(labelPhone, textBoxPhone1, _account.Theme);
			validator.CheckAllNumbers(labelPhone, textBoxPhone2, _account.Theme);
			validator.CheckAllNumbers(labelPhone, textBoxPhone3, _account.Theme);
			validator.CheckMinLength(labelPhone, textBoxPhone1, 3, _account.Theme);
			validator.CheckMinLength(labelPhone, textBoxPhone2, 3, _account.Theme);
			validator.CheckMinLength(labelPhone, textBoxPhone3, 3, _account.Theme);

			bool isDataValid = validator.IsDataValid;
			CheckValidEmail(ref isDataValid);
			CheckValidQuestionnairе(ref isDataValid);

			return isDataValid;
		}
		private void CheckValidEmail(ref bool isDataValid)
		{
			string pattern = @"^.+@.{2,}\..{2,}$";
			string email = textBoxEmail.Text;

			if (!Regex.IsMatch(email, pattern))
				ValidationFeedbackManager.HighlightInvalidLabel(labelEmail,
					$"{labelEmail.Text} рядок не схожий на E-mail.\n" +
					$"Він повинен мати наступний вигляд: [1;∞)@[2;∞).[2;∞), " +
					$"де запис [n;m) - кількість символів.", _account.Theme,
					ref isDataValid, textBoxEmail);

			if (email.Contains(Client.SEPARATOR.ToString()))
				ValidationFeedbackManager.HighlightInvalidLabel(labelEmail,
					$"E-mail не може мати такий символ: {Client.SEPARATOR}.",
					_account.Theme, ref isDataValid, textBoxEmail);
		}
		private void CheckValidQuestionnairе(ref bool isDataValid)
		{
			if (_account.candidate.Questionnaire == null)
			{
				if (isDataValid)
				{
					buttonQuestionnairе.Focus();
					CustomMessageBox.Show("Дані були введені не вірно!" +
						"\nАнкету також потрібно заповнити.",
						_account.Theme, "Помилка введення",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
				isDataValid = false;
			}
		}

		#region Label focus event handlers
		private void LabelSurname_Click(object sender, EventArgs e)
			=> textBoxSurname.Focus();
		private void LabelName_Click(object sender, EventArgs e)
			=> textBoxName.Focus();
		private void LabelFatherName_Click(object sender, EventArgs e)
			=> textBoxFatherName.Focus();
		private void LabelPhone_Click(object sender, EventArgs e)
			=> textBoxPhone1.Focus();
		private void LabelBirthday_Click(object sender, EventArgs e)
			=> dateTimePickerBirthday.PerformClick();
		private void LabelEmail_Click(object sender, EventArgs e)
			=> textBoxEmail.Focus();
		#endregion

		private void TextBoxPhone_TextChanged(object sender, EventArgs e)
		{
			if (sender is Guna2TextBox textBox
				&& textBox.Text.Length == textBox.MaxLength)
				ProcessTabKey(true);
		}
		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SelectNextControl(ActiveControl, true, true, true, false);
			}
		}
		private void TextBoxEmail_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				buttonApply.PerformClick();
			}
		}
		private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
				e.Handled = true;
		}

		private void ButtonQuestionnaire_Click(object sender, EventArgs e)
		{
			QuestionnaireForm qf = new QuestionnaireForm(_account, _startForm);
			qf.Show();
			qf.FormClosed += (s, args) => { Visible = true; };
			Visible = false;
		}

		private void ButtonApply_Click(object sender, EventArgs e)
		{
			if (CheckValidData())
				try
				{
					if (CheckUniquePhoneAndEmail() == false)
						return;

					_account.candidate = new Candidate(textBoxSurname.Text,
						textBoxName.Text, textBoxFatherName.Text,
						$"{labelPhoneStart.Text}{textBoxPhone1.Text}" +
						$"{textBoxPhone2.Text}{textBoxPhone3.Text}",
						dateTimePickerBirthday.Value, textBoxEmail.Text,
						_account.candidate.Questionnaire);

					if (_startForm != null)
						CreateCandidate();
					else
						UpdateCandidate();
				}
				catch (SocketException)
				{
					CustomMessageBox.Show("Спроба підключитись до серверу " +
						"завершилась не вдало.\nСпробуйте, будь ласка, пізніше.",
						_account.Theme, "Помилка підключення",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
		}
		private void CreateCandidate()
		{
			if (!ClientUniqueChecker.IsLoginUnique(new Label() { Text = "Логін" },
				_account.Login, _account.Theme))
				return;

			Client.CreateCandidate(_account);
			if (_startForm.NeedToRemember)
				Serializator.Serialize(_account,
					Program.SerializePath, Program.EncryptKey);

			OpenMainForm();
		}
		private void OpenMainForm()
		{
			MainForm mainForm = new MainForm(_account);
			mainForm.Show();
			mainForm.FormClosed += (s, args) =>
			{
				Close();
				_startForm.Close();
			};
			Visible = false;
		}
		private void UpdateCandidate()
		{
			Client.ChangeCandidate(_account.Login, _oldCandidate, _account.candidate);
			if (Serializator.SerializationFileExists(Program.SerializePath))
				Serializator.Serialize(_account, Program.SerializePath, Program.EncryptKey);

			Close();
		}

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);

		private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_startForm != null)
			{
				_startForm.Visible = true;
				_account.candidate = null;
			}
		}
	}
}