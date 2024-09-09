using System;
using System.Windows.Forms;

using RecruitmentLibrary.ApplicationInfo;
using RecruitmentLibrary.PersonInfo;
using RecruitmentLibrary.FormUtilities;
using RecruitmentUser.ClientUtilities;

namespace RecruitmentUser.Forms
{
	internal partial class VacancyForm : Form, IThemeChange
	{
		private readonly int idVacancy;
		private readonly string login;
		private readonly Action<EventArgs> refresh;
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();
		internal VacancyForm(Vacancy vacancy, string login, Action<EventArgs> refresh, Theme theme)
		{// Конструктор форми
			InitializeComponent();
			idVacancy = vacancy.Id;
			this.login = login;
			this.refresh = refresh;
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
			Validator.CheckBannedChar(labelAdditionalTitle, richTextBoxClientAdditionalInfo.Text, Client.SEPARATOR, ref isDataOk);
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
				MessageBox.Show("Заявка була відправлена успішно!\nБудь ласка, регулярно переглядайте вкладки заявок та\nспівбесід.", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Net.Sockets.SocketException)
			{
				MessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
					"\nСпробуйте, будь ласка, відправити заявку пізніше.", "Помилка підключення",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelPosition,
					labelDatePublication, labelSalaryTitle, labelPositionDescriptionTitle,
					labelAdditionalInfoTitle, labelRequirementTitle, labelAdditionalTitle);

			ColorChanger.ChangeInputControlsBackColor(theme, richTextBoxClientAdditionalInfo);
			ColorChanger.ChangeInputControlsForeColor(theme, richTextBoxSalary, richTextBoxPositionDescription,
					 richTextBoxAdditionalInfo, richTextBoxRequirement, richTextBoxClientAdditionalInfo);

			if (theme == Theme.White)// Якщо треба встановити світлу тему
				BackColor = ColorChanger.BackColorThemeW;
			else if (theme == Theme.Black)// Якщо треба встановити темну тему
				BackColor = ColorChanger.BackColorThemeB;

			richTextBoxSalary.BackColor = BackColor;
			richTextBoxPositionDescription.BackColor = BackColor;
			richTextBoxAdditionalInfo.BackColor = BackColor;
			richTextBoxRequirement.BackColor = BackColor;
			richTextBoxClientAdditionalInfo.BackColor = BackColor;
		}

		private void VacancyForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}