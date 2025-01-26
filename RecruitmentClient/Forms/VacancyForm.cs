using System;
using System.Linq;
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
		private readonly Account _account;
		private readonly Vacancy _vacancy;
		private readonly Action<EventArgs> _refresh;

		private string _requirements;

		internal VacancyForm(Account account, Vacancy vacancy, Action<EventArgs> refresh)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Вакансія", minimizeBox: false,
				maximizeBox: false);

			_account = account;
			_vacancy = vacancy;
			_refresh = refresh;
		}
		private void VacancyForm_Load(object sender, EventArgs e)
		{
			richTextBoxPosition.Text = _vacancy.Position.Name;
			richTextBoxSalary.Text = $"{_vacancy.Salary:0.##}" + " грн.";
			labelDatePublication.Text = "Дата публікації: " +
				_vacancy.GetLocalDatePublication().ToString("yyyy-MM-dd");

			SetupInformation(_vacancy.Position.Description, labelPositionDescriptionTitle,
				richTextBoxPositionDescription);
			SetupInformation(_vacancy.Info,
				labelAdditionalInfoTitle, richTextBoxAdditionalInfo);
			SetupRequirements();

			SetTheme(_account.Theme);
		}

		private void SetupRequirements()
		{
			_requirements = string.Empty;
			_requirements = _vacancy.Requirement.ToString();
			string educationDegrees = string.Join(", ",
				_vacancy.Requirement.EducationDegreeRequirements.Select(
					edr => edr.EducationDegree.Degree.ToLower()));

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
			CustomMessageBox.Show(_requirements, _account.Theme, "Вимоги",
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information, 550);
		}
		private async void ButtonSend_Click(object sender, EventArgs e)
		{
			richTextBoxClientAdditionalInfo.Text =
				richTextBoxClientAdditionalInfo.Text.Trim(' ', '\r', '\n');

			try
			{
				SharedModels.Models.Application application = new SharedModels.Models.Application(
					DateTime.UtcNow, richTextBoxClientAdditionalInfo.Text, default,
					_account.Candidate.Id, _vacancy.Id);
				await Program.Client.CreateApplicationAsync(application);
				_refresh(EventArgs.Empty);
				Close();
				CustomMessageBox.Show("Заявка була відправлена успішно!\n" +
					"Будь ласка, регулярно переглядайте вкладки заявок та співбесід.",
					_account.Theme, "Успішно", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Information);
			}
			catch (SocketException)
			{
				CustomMessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
					"\nСпробуйте, будь ласка, відправити заявку пізніше.",
					_account.Theme, "Помилка підключення",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}
		}

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);
	}
}