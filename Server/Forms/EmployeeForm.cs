using System;
using System.Windows.Forms;

using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using ServerDB.ServerUtilities;

namespace ServerDB.Forms
{
	internal partial class EmployeeForm : Form, IThemeChange
	{// Форма співробітника
		private readonly Employee employee;// Співробітник
		private readonly Action<EventArgs> refresh;// Перезавантаження головної форми
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		internal EmployeeForm(Employee employee, Action<EventArgs> refresh, ServerAccount account)
		{// Конструктор форми
			InitializeComponent();
			this.employee = employee;
			this.refresh = refresh;

			labelFullName.Text = $"{employee.Surname.ToUpper()} {employee.Name} {employee.FatherName}";
			richTextBoxPosition.Text = employee.Position;
			richTextBoxSalary.Text = employee.Salary.ToString();
			labelCity.Text = "Місце проживання: " + employee.City.ToString();
			labelBirthday.Text = "Дата народження: " + employee.Birthday.ToString("yyyy-MM-dd");
			labelDateEmployment.Text = "Дата працевлаштування: " + employee.DateEmployment.ToString("yyyy-MM-dd");
			richTextBoxContact.Text = $"Номер телефону: {employee.Phone}\nE-mail: {employee.Email}";
			richTextBoxPosition.Focus();
			buttonEventHandlers.SubscribeToHover(buttonFire);

			SetTheme(account.Theme);
		}

		private void RichTextBoxSalary_TextChanged(object sender, EventArgs e)
		{// Обробник події зміни зарплатні
			if (richTextBoxSalary.Text != employee.Salary.ToString())
				buttonChangeSalary.Visible = true;
			else
				buttonChangeSalary.Visible = false;
		}
		private void ButtonChangeSalary_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Змінити зарплату" 
			DialogResult result = MessageBox.Show($"Ви впевнені що хочете змінити зарплату у цього\nспівробітника?", "Зміна зарплати",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			buttonChangeSalary.Visible = false;

			if (result == DialogResult.Yes)
			{
				try
				{// Змінюємо зарплату в БД та в об'єкта
					DataBase.ExecuteQuery($"UPDATE Employee SET salary = {richTextBoxSalary.Text.Replace(",", ".")} WHERE id = {employee.Id}");
					employee.ChangeSalary(double.Parse(richTextBoxSalary.Text));
				}
				catch
				{
					richTextBoxSalary.Text = employee.Salary.ToString();
					MessageBox.Show("Дані були введені не вірно!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			richTextBoxSalary.Text = employee.Salary.ToString();
		}

		private void RichTextBoxPosition_TextChanged(object sender, EventArgs e)
		{// Обробник події зміни посади
			if (richTextBoxPosition.Text != employee.Position)
				buttonChangePosition.Visible = true;
			else
				buttonChangePosition.Visible = false;

		}
		private void ButtonChangePosition_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Змінити посаду"
			if (richTextBoxPosition.Text.Contains(Server.SEPARATOR.ToString()))
			{// Якщо є заборонений символ
				MessageBox.Show("В посаді не може бути заборонений символ: ¤", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DialogResult result = MessageBox.Show($"Ви впевнені що хочете змінити посаду у цього\nспівробітника?", "Зміна посади",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			buttonChangePosition.Visible = false;

			if (result == DialogResult.Yes)
			{
				try
				{// Змінюємо посаду в БД та в об'єкта
					DataBase.ExecuteQuery($"UPDATE Employee SET position = '{richTextBoxPosition.Text}' WHERE id = {employee.Id}");
					employee.ChangePosition(richTextBoxPosition.Text);
				}
				catch
				{
					richTextBoxPosition.Text = employee.Position.ToString();
					MessageBox.Show("Дані були введені не вірно!", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			richTextBoxPosition.Text = employee.Position.ToString();

		}

		private void ButtonFire_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку звільнення
			DialogResult result = MessageBox.Show($"Ви впевнені що хочете ЗВІЛЬНИТИ цього співробітника?", "Звільнення",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				DataBase.ExecuteQuery($"DELETE FROM Employee WHERE id = {employee.Id}");
				refresh(EventArgs.Empty);
				Close();
			}
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelFullName,
					labelSalaryTitle, labelContact, labelCity, labelBirthday,
					labelDateEmployment);

			ColorChanger.ChangeInputControlsColor(theme, richTextBoxPosition, richTextBoxSalary, richTextBoxContact);
			if (theme == Theme.White)// Якщо треба встановити світлу тему
				BackColor = ColorChanger.BackColorThemeW;
			else if (theme == Theme.Black)// Якщо треба встановити темну тему
				BackColor = ColorChanger.BackColorThemeB;

			richTextBoxPosition.BackColor = BackColor;
			richTextBoxSalary.BackColor = BackColor;
		}

		private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}