using System;
using System.Windows.Forms;

using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using ServerDB.DataModels;
using ServerDB.ServerUtilities;

namespace ServerDB.Forms
{
	internal partial class ApplicationForm : Form, IThemeChange
	{// Форма заявки
		private const int MIN_HOURS_WAIT_TO_EVENT = 12;// Через скільки годин можна буде запланувати співбесіду

		private readonly FullApplication application;// Заявка
		private readonly ServerAccount account;// Акаунт
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		private readonly Action<EventArgs> refresh;// Перезавантаження головної форми
		internal ApplicationForm(FullApplication application, Action<EventArgs> refresh, ServerAccount account)
		{// Конструктор форми створення вакансії
			InitializeComponent();
			application_StatusTableAdapter.Fill(recruitmentDBDataSet.Application_Status);

			this.application = application;
			this.refresh = refresh;
			Text = $"Заявка ({application.Status})";
			richTextBoxPosition.Text = application.Position.Name;
			labelScores.Text = "Балів: " + application.Scores;
			labelDatePublication.Text = "Дата і час подачі: " + application.DateSubmission.ToString("d MMMM yyyy HH:mm");

			// Додаткова інформація
			if (application.AdditionalInfo != null && application.AdditionalInfo.Length > 0)
				richTextBoxAdditionalInfo.Text = application.AdditionalInfo;

			if (application.ReasonRejection != null && application.ReasonRejection.Length > 0)
			{// Якщо є причина відмови
				buttonReasonRejection.Visible = true;
				buttonReasonRejection.Click += (sender, e) =>
				{
					MessageBox.Show(application.ReasonRejection, "Причина відмови",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				};
			}

			if (application.Status != "В очікуванні")
			{// Вимикаємо функцію зміну статусу, якщо статус НЕ "В очікуванні"
				labelStatus.Visible = false;
				comboBoxDecision.Visible = false;
				buttonApply.Visible = false;
			}

			this.account = account;
			SetTheme(account.Theme);
		}
		private void ApplicationForm_Load(object sender, EventArgs e)
		{// Обробник події завантаження форми
			if (comboBoxDecision.Visible)// Обираємо перший елемент, щоб він змінився
				ComboBoxDecision_SelectedIndexChanged(comboBoxDecision, EventArgs.Empty);
			dateTimePickerInterview.MinDate = DateTime.Now;
			dateTimePickerInterview.MaxDate = DateTime.Now.AddMonths(1);
			dateTimePickerInterview.Value = DateTime.Now.AddDays(7);
			numericUpDownHours.Value = DateTime.Now.Hour;
			numericUpDownMinutes.Value = DateTime.Now.Minute;
			buttonEventHandlers.SubscribeToHover(buttonVacancy, buttonCandidate, buttonApply, buttonReasonRejection);
		}

		private void ButtonApply_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Застосувати"
			if (comboBoxDecision.Text == "Відхилена")
			{// Перевірка причини відмови на заборонений символ
				bool isDataOk = true;
				Validator.CheckBannedChar(labelReason, richTextBoxReason.Text, Server.SEPARATOR, ref isDataOk);
				if (!isDataOk)
					return;
			}
			DateTime dateTime = new DateTime();
			if (comboBoxDecision.Text == "Прийнята")
			{// Перевірка дати співбесіди
				dateTime = new DateTime(dateTimePickerInterview.Value.Year,
						dateTimePickerInterview.Value.Month, dateTimePickerInterview.Value.Day,
						(int)numericUpDownHours.Value, (int)numericUpDownMinutes.Value, 0);
				if (DateTime.Now.AddHours(MIN_HOURS_WAIT_TO_EVENT) > dateTime)
				{
					MessageBox.Show("Ви не можете створити співбесіду в такий час.\n" +
						$"Проведення співбесіди не повинно відбуватися раніше,\nніж через {MIN_HOURS_WAIT_TO_EVENT} год. після прийняття заявки.",
				"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			DialogResult result = MessageBox.Show("Ви впевнені, що хочете змінити статус заявки?\nПісля цього змінити статус буде неможливо.",
				"Зміна статусу", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				int idStatus = int.Parse(comboBoxDecision.SelectedValue.ToString());
				DataBase.SetApplicationStatus(application.Id, idStatus, richTextBoxReason.Text);
				if (comboBoxDecision.Text == "Прийнята")
				{// Створення співбесіди
					DataBase.CreateInterview(application.Id, dateTime.ToUniversalTime());
					Candidate candidate = DataBase.GetCandidate(application.IdCandidate);
					MessageBox.Show($"Ви можете зв'язатися з кандидатом:\n\n" +
						$"Номер телефону: {candidate.Phone}\nE-mail: {candidate.Email}",
						"Контактна інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				refresh(EventArgs.Empty);// Перезавантажуємо головну форму
				Close();
			}
		}
		private void ComboBoxDecision_SelectedIndexChanged(object sender, EventArgs e)
		{// Обробник події для зміни статусу заявки в comboBoxDecision
			if (comboBoxDecision.Text == "В очікуванні")
				buttonApply.Visible = false;
			else
				buttonApply.Visible = true;

			if (comboBoxDecision.Text == "Відхилена")
			{
				labelReason.Visible = true;
				richTextBoxReason.Visible = true;
				richTextBoxReason.Focus();
			}
			else
			{
				richTextBoxReason.Text = string.Empty;
				labelReason.Visible = false;
				richTextBoxReason.Visible = false;
			}

			if (comboBoxDecision.Text == "Прийнята")
			{
				panelInterview.Visible = true;
				dateTimePickerInterview.Focus();
			}
			else
				panelInterview.Visible = false;
		}

		private void ButtonVacancy_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Вакансія"
			FullVacancy vacancy = DataBase.GetVacancy(application.IdVacancy);
			VacancyForm vf = new VacancyForm(vacancy, account, isDeleteButtonVisible: false);
			Visible = false;
			vf.FormClosed += (s, args) =>
			{ Visible = true; };
			vf.ShowDialog();
		}
		private void ButtonCandidate_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Кандидат"
			Candidate candidate = DataBase.GetCandidate(application.IdCandidate);
			CandidateForm cf = new CandidateForm(candidate, account);
			Visible = false;
			cf.FormClosed += (s, args) =>
			{ Visible = true; };
			cf.ShowDialog();
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelScores,
				labelDatePublication, labelAdditionalInfoTitle, labelStatus, labelReason,
				labelDate, labelHours, labelMinutes);

			ColorChanger.ChangeInputControlsColor(theme, comboBoxDecision, richTextBoxReason,
				richTextBoxAdditionalInfo, numericUpDownHours, numericUpDownMinutes);
			ColorChanger.ChangeInputControlsForeColor(theme,
				richTextBoxPosition);

			if (theme == Theme.White)// Якщо треба встановити світлу тему
				BackColor = ColorChanger.BackColorThemeW;
			else if (theme == Theme.Black)// Якщо треба встановити темну тему
				BackColor = ColorChanger.BackColorThemeB;

			richTextBoxPosition.BackColor = BackColor;
		}

		private void ApplicationForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}