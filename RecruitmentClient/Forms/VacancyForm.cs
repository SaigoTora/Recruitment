using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecruitmentClient.Models;
using SharedModels.DTOs;
using SharedModels.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

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

			if (!string.IsNullOrEmpty(educationDegrees))
			{
				if (_requirements != string.Empty)
					_requirements += "\n\n";
				_requirements += $"Необхідно мати один " +
					$"із рівнів освіти: {educationDegrees}.";
			}
			if (_requirements == string.Empty)
				_requirements = "Вимоги відсутні.";
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
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
		}
		private async void ButtonSend_Click(object sender, EventArgs e)
		{
			richTextBoxClientAdditionalInfo.Text =
				richTextBoxClientAdditionalInfo.Text.Trim(' ', '\r', '\n');

			try
			{
				richTextBoxClientAdditionalInfo.ReadOnly = true;
				buttonRequirements.Enabled = false;
				buttonSend.Enabled = false;
				CreateApplicationDTO createApplication = new CreateApplicationDTO(
					_account.GetCandidateLogin(), richTextBoxClientAdditionalInfo.Text,
					_vacancy.Id);
				await Program.Client.CreateApplicationAsync(createApplication);
				_refresh(EventArgs.Empty);
				Close();
				CustomMessageBox.Show("Заявка була відправлена успішно!\n" +
					"Будь ласка, регулярно переглядайте вкладки заявок та співбесід.",
					_account.Theme, "Успішно", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Information, 500);
			}
			catch (Exception ex) when (ex is TaskCanceledException
				|| ex is System.Net.Http.HttpRequestException)
			{ Program.HandleNetworkError(); }
			finally
			{
				richTextBoxClientAdditionalInfo.ReadOnly = false;
				buttonRequirements.Enabled = true;
				buttonSend.Enabled = true;
			}
		}

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);
	}
}