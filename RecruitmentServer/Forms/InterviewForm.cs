using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;
using RecruitmentServer.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentServer.Forms
{
	internal partial class InterviewForm : BaseForm, IThemeChange
	{
		private readonly (Color ChangeDate, Color Back) _buttonFillColor =
			(Color.FromArgb(225, 200, 30), Color.FromArgb(190, 60, 50));
		private readonly (Color ChangeDate, Color Back) _buttonFillColor2 =
			(Color.FromArgb(255, 210, 60), Color.FromArgb(160, 40, 40));
		private readonly (Color ChangeDate, Color Back) _buttonHoverFillColor =
			(Color.FromArgb(245, 215, 80), Color.FromArgb(255, 100, 90));
		private readonly (Color ChangeDate, Color Back) _buttonHoverFillColor2 =
			(Color.FromArgb(255, 235, 100), Color.FromArgb(220, 70, 70));


		private readonly Account _account;
		private readonly FullInterview _interview;
		private readonly Action<EventArgs> _actionAfterChange;

		internal InterviewForm(Account account, FullInterview interview,
			Action<EventArgs> actionAfterChange)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, $"Співбесіда ({interview.Status})",
				minimizeBox: false, maximizeBox: false);

			_interview = interview;
			_actionAfterChange = actionAfterChange;
			_account = account;
		}
		private void InterviewForm_Load(object sender, EventArgs e)
		{
			interview_StatusTableAdapter.Fill(recruitmentDBDataSet.Interview_Status);
			SetFormFields(_interview);
			SetTheme(_account.Theme);
		}
		private void SetFormFields(FullInterview interview)
		{
			textBoxPosition.Text = interview.Position.Name;
			labelDateEvent.Text = "Дата і час проведення співбесіди: " +
				interview.DateEvent.ToString("d MMMM yyyy HH:mm");

			if (interview.Status == "Прийнято" || interview.Status == "Не прийнято")
			{
				labelStatus.Visible = false;
				comboBoxDecision.Visible = false;
			}
			if (interview.Status == "Прийнято")
				buttonEmployee.Visible = true;
			if (interview.Status == "Кандидат запрошений")
				buttonChangeDate.Visible = true;

			dateTimePickerInterview.MinDate = DateTime.Now;
			dateTimePickerInterview.MaxDate = DateTime.Now.AddMonths(1);
			if (_interview.Status == "Кандидат чекає на рішення")
				comboBoxDecision.SelectedIndex = 1;
		}

		#region Event handlers
		#region Buttons
		private void ButtonApplication_Click(object sender, EventArgs e)
		{
			FullApplication application = DataBase.GetApplication(_interview.IdApplication);
			ApplicationForm applicationForm = new ApplicationForm(_account, application, null);
			Visible = false;
			applicationForm.FormClosed += (s, args) => { Visible = true; };
			applicationForm.ShowDialog();
		}
		private void ButtonEmployee_Click(object sender, EventArgs e)
		{
			Employee employee = DataBase.GetEmployee(_interview.Id);
			EmployeeForm employeeForm = new EmployeeForm(_account, employee, (args) =>
			{ Close(); _actionAfterChange(EventArgs.Empty); });
			Visible = false;
			employeeForm.FormClosed += (s, args) => { Visible = true; };
			employeeForm.ShowDialog();
		}
		private void ButtonChangeDate_Click(object sender, EventArgs e)
		{
			Size = new Size(Width, Height + panelDate.Height);
			comboBoxDecision.Enabled = false;
			panelDate.Visible = true;
			dateTimePickerInterview.Value = _interview.DateEvent;
			numericUpDownHours.Value = _interview.DateEvent.Hour;
			numericUpDownMinutes.Value = _interview.DateEvent.Minute;
			buttonChangeApply.Visible = true;

			buttonChangeDate.Text = "Назад";
			buttonChangeDate.FillColor = _buttonFillColor.Back;
			buttonChangeDate.FillColor2 = _buttonFillColor2.Back;
			buttonChangeDate.HoverState.FillColor = _buttonHoverFillColor.Back;
			buttonChangeDate.HoverState.FillColor2 = _buttonHoverFillColor2.Back;
			buttonChangeDate.Click -= ButtonChangeDate_Click;
			buttonChangeDate.Click += ButtonChangeDateBack_Click;
		}
		private void ButtonChangeDateBack_Click(object sender, EventArgs e)
		{
			Size = new Size(Width, Height - panelDate.Height);
			comboBoxDecision.Enabled = true;
			panelDate.Visible = false;
			buttonChangeApply.Visible = false;

			buttonChangeDate.Text = "Змінити дату";
			buttonChangeDate.FillColor = _buttonFillColor.ChangeDate;
			buttonChangeDate.FillColor2 = _buttonFillColor2.ChangeDate;
			buttonChangeDate.HoverState.FillColor = _buttonHoverFillColor.ChangeDate;
			buttonChangeDate.HoverState.FillColor2 = _buttonHoverFillColor2.ChangeDate;
			buttonChangeDate.Click -= ButtonChangeDateBack_Click;
			buttonChangeDate.Click += ButtonChangeDate_Click;
		}
		private void ButtonChangeApply_Click(object sender, EventArgs e)
		{
			DateTime dateTime = new DateTime(dateTimePickerInterview.Value.Year,
				dateTimePickerInterview.Value.Month, dateTimePickerInterview.Value.Day,
				(int)numericUpDownHours.Value, (int)numericUpDownMinutes.Value, 0);

			if (DateTime.Now >= dateTime)
			{
				CustomMessageBox.Show("Ви не можете встановити час, який раніше за поточний!",
					_account.Theme, "Помилка", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Error, 440);
				return;
			}
			if (_interview.DateEvent >= dateTime)
			{
				DialogResult result = CustomMessageBox.Show("Ви впевнені, що хочете змінити " +
					"дату та час співбесіди? Рекомендується не встановлювати їх на раніше, " +
					"ніж було попередньо.", _account.Theme, "Увага",
					CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Warning);

				if (result != DialogResult.Yes)
					return;
			}

			_interview.ChangeDate(dateTime);
			DataBase.ChangeInterviewDateEvent(_interview.Id, dateTime.ToUniversalTime());
			ButtonChangeDateBack_Click(sender, e);
			labelDateEvent.Text = "Дата і час проведення співбесіди: " +
				_interview.DateEvent.ToString("d MMMM yyyy HH:mm");
			_actionAfterChange(EventArgs.Empty);
		}
		private void ButtonApply_Click(object sender, EventArgs e)
		{
			DialogResult result;
			if (DateTime.Now < _interview.DateEvent)
			{
				result = CustomMessageBox.Show("Ви впевнені, що хочете " +
					"змінити статус?\nЗ кандидатом ще не було проведено співбесіди!",
					_account.Theme, "Увага", CustomMessageBoxButtons.YesNo,
					CustomMessageBoxIcon.Warning, 430);
				if (result != DialogResult.Yes)
					return;
			}

			string message = string.Empty;
			if (comboBoxDecision.Text == "Прийнято" || comboBoxDecision.Text == "Не прийнято")
				message = "Після цього змінити статус буде неможливо.";

			result = CustomMessageBox.Show($"Ви впевнені, що хочете " +
				$"змінити статус співбесіди?\n{message}",
				_account.Theme, "Зміна статусу", CustomMessageBoxButtons.YesNo,
				CustomMessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int idStatus = int.Parse(comboBoxDecision.SelectedValue.ToString());
				DataBase.SetInterviewStatus(_interview.Id, idStatus);
				_actionAfterChange(EventArgs.Empty);
				Close();
			}
		}
		#endregion

		#region ComboBox
		private void ComboBoxDecision_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_interview.Status == "Кандидат запрошений")
			{
				if (comboBoxDecision.Text != "Кандидат запрошений")
				{
					buttonApply.Visible = true;
					buttonChangeDate.Visible = false;
				}
				else
				{
					buttonApply.Visible = false;
					buttonChangeDate.Visible = true;
				}
			}
			else if (_interview.Status == "Кандидат чекає на рішення")
			{
				if (comboBoxDecision.Text == "Прийнято"
					|| comboBoxDecision.Text == "Не прийнято")
					buttonApply.Visible = true;
				else
					buttonApply.Visible = false;
			}
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
		private void LabelStatus_Click(object sender, EventArgs e)
			=> comboBoxDecision.DroppedDown = true;
		private void LabelDate_Click(object sender, EventArgs e)
			=> dateTimePickerInterview.PerformClick();
		#endregion
		#endregion

		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);

			panelDate.BackColor = BackColor;
		}

		private void InterviewForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonChangeDate.Click -= ButtonChangeDateBack_Click;
			buttonChangeDate.Click -= ButtonChangeDate_Click;
		}
	}
}