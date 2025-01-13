using System;
using System.Net.Sockets;
using System.Windows.Forms;

using RecruitmentClient.Models;
using SharedModels.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentClient.Forms
{
	internal partial class VacancyForm : BaseForm, IThemeChange
	{
		private readonly VacancyDbView _vacancy;
		private readonly string _login;
		private readonly Action<EventArgs> _refresh;
		private readonly Theme _currentTheme;

		private string _requirements;

		internal VacancyForm(Account account, VacancyDbView vacancy,
			string login, Action<EventArgs> refresh)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Вакансія", minimizeBox: false,
				maximizeBox: false);
			_vacancy = vacancy;
			_login = login;
			_refresh = refresh;
			_currentTheme = account.Theme;
		}
		private void VacancyForm_Load(object sender, EventArgs e)
		{
			richTextBoxPosition.Text = _vacancy.PositionName;
			richTextBoxSalary.Text = $"{_vacancy.Salary:0.##}" + " грн.";
			labelDatePublication.Text = "Дата публікації: " +
				_vacancy.DatePublication.ToString("yyyy-MM-dd");

			SetupInformation(_vacancy.PositionDescription, labelPositionDescriptionTitle,
				richTextBoxPositionDescription);
			SetupInformation(_vacancy.Info,
				labelAdditionalInfoTitle, richTextBoxAdditionalInfo);
			SetupRequirements();

			SetTheme(_currentTheme);
		}

		private void SetupRequirements()
		{
			_requirements = string.Empty;
			_requirements = Client.GetRequirement(_vacancy.Id).ToString();
			string educationDegrees = Client.GetRequirementEducationDegree(_vacancy.Id);
			if (educationDegrees != null)
			{
				if (_requirements != string.Empty)
					_requirements += "\n\n";
				_requirements += $"Необхідно мати один " +
					$"із ступенів освіти: {educationDegrees}.";
			}
			buttonRequirements.Visible = _requirements != string.Empty;
		}
		private void SetupInformation(string text,
			Label labelTitle, RichTextBox richTextBox)
		{
			if (_vacancy.Info == null || _vacancy.Info.Length <= 0)
			{
				labelTitle.Visible = false;
				richTextBox.Visible = false;
			}
			else
				richTextBox.Text = text;
		}

		private void LabelClientAdditionalInfoTitle_Click(object sender, EventArgs e)
			=> richTextBoxClientAdditionalInfo.Focus();
		private void ButtonRequirements_Click(object sender, EventArgs e)
		{
			CustomMessageBox.Show(_requirements, _currentTheme, "Вимоги",
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information, 550);
		}
		private void ButtonSend_Click(object sender, EventArgs e)
		{
			richTextBoxClientAdditionalInfo.Text =
				richTextBoxClientAdditionalInfo.Text.Trim(' ', '\r', '\n');

			Validator validator = new Validator();
			validator.CheckBannedChar(labelClientAdditionalInfoTitle,
				richTextBoxClientAdditionalInfo.Text, Client.SEPARATOR, _currentTheme);
			if (!validator.IsDataValid)
			{
				richTextBoxClientAdditionalInfo.Focus();
				return;
			}
			try
			{
				Client.CreateApplication(_login,
					richTextBoxClientAdditionalInfo.Text, _vacancy.Id);
				_refresh(EventArgs.Empty);
				Close();
				CustomMessageBox.Show("Заявка була відправлена успішно!\n" +
					"Будь ласка, регулярно переглядайте вкладки заявок та співбесід.",
					_currentTheme, "Успішно", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Information);
			}
			catch (SocketException)
			{
				CustomMessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
					"\nСпробуйте, будь ласка, відправити заявку пізніше.",
					_currentTheme, "Помилка підключення",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}
		}

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);

	}
}