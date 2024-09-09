using System;
using System.Windows.Forms;

using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using ServerDB.DataModels;
using ServerDB.ServerUtilities;

namespace ServerDB.Forms
{
	internal partial class InterviewForm : Form, IThemeChange
	{// Форма співбесіди
		private const int INCREMENT_HEIGHT = 150;

		private readonly ServerAccount account;// Акаунт
		private readonly FullInterview interview;// Співбесіда
		private readonly Action<EventArgs> refresh;// Перезавантаження головної форми
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		internal InterviewForm(FullInterview interview, Action<EventArgs> refresh, ServerAccount account)
		{// Конструктор форми співбесіди
			InitializeComponent();
			Text = $"Співбесіда ({interview.Status})";
			richTextBoxPosition.Text = interview.Position.Name;
			labelDateEvent.Text = "Дата і час проведення співбесіди: " + interview.DateEvent.ToString("d MMMM yyyy HH:mm");

			if (interview.Status == "Прийнято" || interview.Status == "Не прийнято")
			{// Для прийнятих та не прийнятих співбесід змінювати статус неможливо
				labelStatus.Visible = false;
				comboBoxDecision.Visible = false;
			}
			if (interview.Status == "Прийнято")// Якщо прийнято, тоді є співробітник
				buttonEmployee.Visible = true;
			if (interview.Status == "Кандидат запрошений")// Якщо кандидат запрошений
				buttonChangeDate.Visible = true;// тоді можна змінити дату проведення співбесіди

			this.interview = interview;
			this.refresh = refresh;
			this.account = account;
			SetTheme(account.Theme);
		}
		private void ApplicationForm_Load(object sender, EventArgs e)
		{// Обробник події завантаження форми
			interview_StatusTableAdapter.Fill(recruitmentDBDataSet.Interview_Status);
			dateTimePickerInterview.MinDate = DateTime.Now;
			dateTimePickerInterview.MaxDate = DateTime.Now.AddMonths(1);
			if (interview.Status == "Кандидат чекає на рішення")// Обираємо потрібний елемент
				comboBoxDecision.SelectedIndex = 1;
			buttonEventHandlers.SubscribeToHover(buttonApplication,
				buttonEmployee, buttonApply, buttonChangeDate, buttonChangeApply);
		}

		private void ButtonApply_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Застосувати"
			if (DateTime.Now < interview.DateEvent)
			{
				MessageBox.Show("З кандидатом ще не було проведено співбесіди!",
						"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string message = string.Empty;
			if (comboBoxDecision.Text == "Прийнято" || comboBoxDecision.Text == "Не прийнято")
				message = "Після цього змінити статус буде неможливо.";

			DialogResult result = MessageBox.Show($"Ви впевнені, що хочете змінити статус співбесіди?\n{message}",
				"Зміна статусу", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (result == DialogResult.Yes)
			{
				int idStatus = int.Parse(comboBoxDecision.SelectedValue.ToString());
				DataBase.SetInterviewStatus(interview.Id, idStatus);
				refresh(EventArgs.Empty);// Перезавантажуємо головну форму
				Close();
			}
		}
		private void ComboBoxDecision_SelectedIndexChanged(object sender, EventArgs e)
		{// Обробник події для зміни статусу заявки в comboBoxDecision
			if (interview.Status == "Кандидат запрошений")
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
			else if (interview.Status == "Кандидат чекає на рішення")
			{
				if (comboBoxDecision.Text == "Прийнято" || comboBoxDecision.Text == "Не прийнято")
					buttonApply.Visible = true;
				else
					buttonApply.Visible = false;
			}
		}

		private void ButtonApplication_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Заявка"
			FullApplication application = DataBase.GetApplication(interview.IdApplication);
			ApplicationForm af = new ApplicationForm(application, null, account);
			Visible = false;
			af.FormClosed += (s, args) =>
			{ Visible = true; };
			af.ShowDialog();
		}
		private void ButtonEmployee_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Співробітник"
			Employee employee = DataBase.GetEmployee(interview.Id);
			EmployeeForm ef = new EmployeeForm(employee, (args) => { Close(); refresh(EventArgs.Empty); }, account);
			Visible = false;
			ef.FormClosed += (s, args) =>
			{ Visible = true; };
			ef.ShowDialog();
		}

		private void ButtonChangeDate_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Змінити дату"
			comboBoxDecision.Enabled = false;
			Size = new System.Drawing.Size(Width, Height + INCREMENT_HEIGHT);
			dateTimePickerInterview.Value = interview.DateEvent;
			numericUpDownHours.Value = interview.DateEvent.Hour;
			numericUpDownMinutes.Value = interview.DateEvent.Minute;
			panelDate.Visible = true;
			buttonChangeApply.Visible = true;

			buttonChangeDate.Text = "Назад";
			buttonChangeDate.Click -= ButtonChangeDate_Click;
			buttonChangeDate.Click += ButtonChangeDateBack_Click;
		}
		private void ButtonChangeDateBack_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Назад"
			comboBoxDecision.Enabled = true;
			Size = new System.Drawing.Size(Width, Height - INCREMENT_HEIGHT);
			panelDate.Visible = false;
			buttonChangeApply.Visible = false;

			buttonChangeDate.Text = "Змінити дату";
			buttonChangeDate.Click -= ButtonChangeDateBack_Click;
			buttonChangeDate.Click += ButtonChangeDate_Click;
		}
		private void ButtonChangeApply_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Змінити"
			DateTime dateTime = new DateTime(dateTimePickerInterview.Value.Year,
		dateTimePickerInterview.Value.Month, dateTimePickerInterview.Value.Day,
		(int)numericUpDownHours.Value, (int)numericUpDownMinutes.Value, 0);
			if (interview.DateEvent >= dateTime)
			{
				MessageBox.Show("Ви не можете створити співбесіду в такий час.\n" +
					$"Ви можете перенести дату співбесіди лише на ту дату,\nяка відбудеться після дати попередньої співбесіди.",
			"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			interview.ChangeDate(dateTime);
			DataBase.ChangeInterviewDateEvent(interview.Id, dateTime.ToUniversalTime());
			ButtonChangeDateBack_Click(sender, e);
			labelDateEvent.Text = "Дата і час проведення співбесіди: " + interview.DateEvent.ToString("d MMMM yyyy HH:mm");
			refresh(EventArgs.Empty);
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelDateEvent,
				labelStatus, labelDate, labelHours, labelMinutes);

			ColorChanger.ChangeInputControlsColor(theme, comboBoxDecision,
				numericUpDownHours, numericUpDownMinutes);
			ColorChanger.ChangeInputControlsForeColor(theme, richTextBoxPosition);

			if (theme == Theme.White)// Якщо треба встановити світлу тему
				BackColor = ColorChanger.BackColorThemeW;
			else if (theme == Theme.Black)// Якщо треба встановити темну тему
				BackColor = ColorChanger.BackColorThemeB;

			richTextBoxPosition.BackColor = BackColor;
		}

		private void InterviewForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}