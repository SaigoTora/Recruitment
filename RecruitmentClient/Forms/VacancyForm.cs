using System;
using System.Windows.Forms;

using RecruitmentClient.ClientUtilities;
using RecruitmentLibrary.ApplicationInfo;
using RecruitmentLibrary.FormUtilities;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentClient.Forms
{
	internal partial class VacancyForm : BaseForm, IThemeChange
	{
		private readonly int idVacancy;
		private readonly string login;
		private readonly Action<EventArgs> refresh;
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();
		private readonly Theme currentTheme;

		internal VacancyForm(Vacancy vacancy, string login, Action<EventArgs> refresh, Theme theme)
		{// Конструктор форми
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Вакансія", minimizeBox: false, maximizeBox: false);
			idVacancy = vacancy.Id;
			this.login = login;
			this.refresh = refresh;
			currentTheme = theme;
			labelPosition.Text = vacancy.Position.Name;
			richTextBoxSalary.Text = vacancy.Salary.ToString() + " грн.";
			richTextBoxPositionDescription.Text = vacancy.Position.Description;
			labelDatePublication.Text = "Дата публікації: " + vacancy.DatePublication.ToString("yyyy-MM-dd");
			richTextBoxAdditionalInfo.Text = vacancy.Info;

			richTextBoxRequirement.Text = string.Empty;// Вимоги
			richTextBoxRequirement.Text = Client.GetRequirement(idVacancy).ToString();
			string educationDegrees = Client.GetRequirementEducationDegree(idVacancy);
			if (educationDegrees != null)
			{// Якщо є вимоги до ступенів освіти
				if (richTextBoxRequirement.Text != string.Empty)// Якщо до цього був текст
					richTextBoxRequirement.Text += "\n\n";
				richTextBoxRequirement.Text += $"Необхідно мати один із ступенів освіти: {educationDegrees}.";
			}
			if (richTextBoxRequirement.Text == string.Empty)
			{
				labelRequirementTitle.Visible = false;
				richTextBoxRequirement.Visible = false;
			}
			if (vacancy.Info == null || vacancy.Info.Length <= 0)
			{
				labelAdditionalInfoTitle.Visible = false;
				richTextBoxAdditionalInfo.Visible = false;
			}
			if (vacancy.Position.Description == null || vacancy.Position.Description.Length <= 0)
			{
				labelPositionDescriptionTitle.Visible = false;
				richTextBoxPositionDescription.Visible = false;
			}

			buttonEventHandlers.SubscribeToHover(buttonSend);
			SetTheme(theme);
		}

		private void ButtonSend_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку створення заявки
			bool isDataOk = true;
			Validator.CheckBannedChar(labelAdditionalTitle, richTextBoxClientAdditionalInfo.Text,
				Client.SEPARATOR, currentTheme, ref isDataOk);
			if (!isDataOk)
			{
				richTextBoxClientAdditionalInfo.Focus();
				return;
			}
			try
			{
				Client.CreateApplication(login, richTextBoxClientAdditionalInfo.Text, idVacancy);
				refresh(EventArgs.Empty);
				Close();
				CustomMessageBox.Show("Заявка була відправлена успішно!\nБудь ласка, регулярно переглядайте вкладки заявок та\nспівбесід.",
					currentTheme, "Успішно", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
			}
			catch (System.Net.Sockets.SocketException)
			{
				CustomMessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
					"\nСпробуйте, будь ласка, відправити заявку пізніше.", currentTheme, "Помилка підключення",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}
		}

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);

		private void VacancyForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}