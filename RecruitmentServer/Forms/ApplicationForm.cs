using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

using RecruitmentServer.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;
using SharedModels.Models;
using RecruitmentServer.Models.DataBase;

namespace RecruitmentServer.Forms
{
	internal partial class ApplicationForm : BaseForm, IThemeChange
	{
		private readonly Account _account;
		private readonly SharedModels.Models.Application _application;
		private readonly Action<EventArgs> _actionAfterChange;

		internal ApplicationForm(Account account, SharedModels.Models.Application application,
			Action<EventArgs> actionAfterChange)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, $"Заявка " +
				$"({application.ApplicationStatus.Status})",
				minimizeBox: false, maximizeBox: false);
			_account = account;
			_application = application;
			_actionAfterChange = actionAfterChange;
		}
		private void ApplicationForm_Load(object sender, EventArgs e)
		{
			application_StatusTableAdapter.Fill(recruitmentDBDataSet.Application_Status);
			SetFormFields(_application);
			SetTheme(_account.Theme);
		}

		private void SetFormFields(SharedModels.Models.Application application)
		{
			textBoxPosition.Text = application.Vacancy.Position.Name;
			labelScores.Text = "Балів: " + application.Scores;
			labelDatePublication.Text = "Дата і час подачі: " +
				application.DateSubmission.ToString("d MMMM yyyy HH:mm");

			if (application.AdditionalInfo != null && application.AdditionalInfo.Length > 0)
				richTextBoxAdditionalInfo.Text = application.AdditionalInfo;

			if (application.ReasonRejection != null
				&& application.ReasonRejection.Length > 0)
				buttonReasonRejection.Visible = true;

			if (application.ApplicationStatus.Status != "В очікуванні")
			{
				labelStatus.Visible = false;
				comboBoxDecision.Visible = false;
				buttonApply.Visible = false;
			}

			if (comboBoxDecision.Visible)// Select the first element to change it
				ComboBoxDecision_SelectedIndexChanged(comboBoxDecision, EventArgs.Empty);

			SetDefaultInterviewDateValues();
		}
		private void SetDefaultInterviewDateValues()
		{
			dateTimePickerInterview.MinDate = DateTime.Now;
			dateTimePickerInterview.MaxDate = DateTime.Now.AddMonths(1);
			dateTimePickerInterview.Value = DateTime.Now.AddDays(7);
			numericUpDownHours.Value = DateTime.Now.Hour;
			numericUpDownMinutes.Value = DateTime.Now.Minute;
		}

		#region Event handlers
		#region Buttons
		private void ButtonVacancy_Click(object sender, EventArgs e)
		{
			Vacancy vacancy = DatabaseManager.GetVacancy(_application.VacancyId);
			VacancyForm vacancyForm = new VacancyForm(_account, vacancy,
				isDeleteButtonVisible: false);
			Visible = false;
			vacancyForm.FormClosed += (s, args) => { Visible = true; };
			vacancyForm.ShowDialog();
		}
		private void ButtonCandidate_Click(object sender, EventArgs e)
		{
			Candidate candidate = DatabaseManager.GetCandidate(_application.CandidateId);
			CandidateForm candidateForm = new CandidateForm(_account, candidate);
			Visible = false;
			candidateForm.FormClosed += (s, args) => { Visible = true; };
			candidateForm.ShowDialog();
		}
		private void ButtonApply_Click(object sender, EventArgs e)
		{
			if (comboBoxDecision.Text == "Відхилена")
			{
				Validator validator = new Validator();
				validator.CheckBannedChar(labelReason, richTextBoxReason.Text,
					Server.SEPARATOR, _account.Theme);
				if (!validator.IsDataValid)
					return;
			}
			DateTime dateTime = new DateTime(dateTimePickerInterview.Value.Year,
				dateTimePickerInterview.Value.Month, dateTimePickerInterview.Value.Day,
				(int)numericUpDownHours.Value, (int)numericUpDownMinutes.Value, 0);
			if (comboBoxDecision.Text == "Прийнята")
			{
				bool isDateValid = CheckValidInterviewDate(dateTime);
				if (!isDateValid)
					return;
			}

			DialogResult result = CustomMessageBox.Show("Ви впевнені, що хочете змінити " +
				"статус заявки?\nПісля цього змінити статус буде неможливо.",
				_account.Theme, "Зміна статусу", CustomMessageBoxButtons.YesNo,
				CustomMessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				ChangeApplicationStatus(dateTime);
				_actionAfterChange(EventArgs.Empty);
				Close();
			}
		}
		private void ButtonReasonRejection_Click(object sender, EventArgs e)
		{
			CustomMessageBox.Show(_application.ReasonRejection, _account.Theme,
				"Причина відмови", CustomMessageBoxButtons.OK,
				CustomMessageBoxIcon.Information);
		}

		private bool CheckValidInterviewDate(DateTime dateTime)
		{
			const int MIN_HOURS_WARNING = 12;

			if (DateTime.Now >= dateTime)
			{
				CustomMessageBox.Show("Ви не можете встановити час, який раніше за поточний!",
					_account.Theme, "Помилка", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Error, 440);
				return false;
			}
			if (DateTime.Now.AddHours(MIN_HOURS_WARNING) > dateTime)
			{
				DialogResult result = CustomMessageBox.Show("Ви впевнені, що хочете " +
					"створити співбесіду на цей час?\nРекомендується проводити її " +
					$"не раніше, ніж через {MIN_HOURS_WARNING} годин після прийняття заявки.",
					_account.Theme, "Увага", CustomMessageBoxButtons.YesNo,
					CustomMessageBoxIcon.Warning, 430);

				if (result != DialogResult.Yes)
					return false;
			}
			return true;
		}
		private void ChangeApplicationStatus(DateTime dateTime)
		{
			int statusId = int.Parse(comboBoxDecision.SelectedValue.ToString());
			DatabaseManager.UpdateApplicationStatus(_application.Id, statusId,
				richTextBoxReason.Text);

			if (comboBoxDecision.Text == "Прийнята")
			{
				DatabaseManager.CreateInterview(_application.Id, dateTime.ToUniversalTime());
				Candidate candidate = DatabaseManager.GetCandidate(_application.CandidateId);

				CustomMessageBox.Show($"Ви можете зв'язатися з кандидатом:\n\n" +
					$"Номер телефону: {candidate.Phone}\nE-mail: {candidate.Email}",
					_account.Theme, "Контактна інформація", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Information);
			}
		}
		#endregion

		#region ComboBox
		private void ComboBoxDecision_SelectedIndexChanged(object sender, EventArgs e)
		{
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

		private void ComboBox_DropDown(object sender, EventArgs e)
		{
			if (sender is Guna2ComboBox comboBox)
			{
				comboBox.CustomizableEdges.BottomLeft = false;
				comboBox.CustomizableEdges.BottomRight = false;
			}
		}
		private void ComboBox_DropDownClosed(object sender, EventArgs e)
		{
			if (sender is Guna2ComboBox comboBox)
			{
				comboBox.CustomizableEdges.BottomLeft = true;
				comboBox.CustomizableEdges.BottomRight = true;
			}
		}
		#endregion

		#region Label focus event handlers
		private void LabelReason_Click(object sender, EventArgs e)
			=> richTextBoxReason.Focus();
		private void LabelDate_Click(object sender, EventArgs e)
			=> dateTimePickerInterview.PerformClick();
		private void LabelStatus_Click(object sender, EventArgs e)
			=> comboBoxDecision.DroppedDown = true;
		#endregion
		#endregion

		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);

			panelInterview.BackColor = BackColor;
		}
	}
}