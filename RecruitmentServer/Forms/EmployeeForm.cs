using System;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;
using RecruitmentServer.ServerUtilities;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentServer.Forms
{
	internal partial class EmployeeForm : BaseForm, IThemeChange
	{
		private readonly ServerAccount _account;
		private readonly Employee _employee;
		private readonly Action<EventArgs> _actionUpdateOrDelete;

		internal EmployeeForm(ServerAccount account, Employee employee,
			Action<EventArgs> actionAfterFire)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Співробітник", minimizeBox: false,
				maximizeBox: false);
			_account = account;
			_employee = employee;
			_actionUpdateOrDelete = actionAfterFire;
		}
		private void EmployeeForm_Load(object sender, EventArgs e)
		{
			SetFormFields(_employee);
			SetTheme(_account.Theme);
		}

		private void SetFormFields(Employee employee)
		{
			labelFullName.Text = $"{employee.Surname.ToUpper()} {employee.Name} " +
				$"{employee.FatherName}";
			textBoxPosition.Text = employee.Position;
			textBoxSalary.Text = employee.Salary.ToString();
			labelCity.Text = "Місце проживання: " + employee.City.ToString();
			labelBirthday.Text = "Дата народження: " +
				employee.Birthday.ToString("yyyy-MM-dd");
			labelDateEmployment.Text = "Дата працевлаштування: " +
				employee.DateEmployment.ToString("yyyy-MM-dd");
			richTextBoxContact.Text = $"Номер телефону: {employee.Phone}" +
				$"\nE-mail: {employee.Email}";
		}

		#region TextBox event handlers
		private void TextBoxSalary_TextChanged(object sender, EventArgs e)
		{
			if (textBoxSalary.Text != _employee.Salary.ToString())
				buttonChangeSalary.Visible = true;
			else
				buttonChangeSalary.Visible = false;
		}
		private void TextBoxPosition_TextChanged(object sender, EventArgs e)
		{
			if (textBoxPosition.Text != _employee.Position)
				buttonChangePosition.Visible = true;
			else
				buttonChangePosition.Visible = false;
		}
		private void TextBoxSalary_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back
				&& e.KeyChar != ',')
				e.Handled = true;
		}
		#endregion

		#region Button event handlers
		private void ButtonChangePosition_Click(object sender, EventArgs e)
		{
			if (textBoxPosition.Text.Contains(Server.SEPARATOR.ToString()))
			{
				CustomMessageBox.Show("В посаді не може бути заборонений символ: ¤",
					_account.Theme, "Помилка введення", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Error);
				return;
			}

			DialogResult result = CustomMessageBox.Show($"Ви впевнені, що " +
				$"хочете змінити посаду?", _account.Theme, "Зміна посади",
				CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Question);
			buttonChangePosition.Visible = false;

			if (result == DialogResult.Yes)
			{
				try
				{
					DataBase.UpdateEmployeePosition(textBoxPosition.Text, _employee.Id);
					_employee.ChangePosition(textBoxPosition.Text);
					_actionUpdateOrDelete(EventArgs.Empty);
				}
				catch
				{
					CustomMessageBox.Show("Дані були введені не вірно!",
						_account.Theme, "Помилка введення",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
			}
			textBoxPosition.Text = _employee.Position.ToString();
		}
		private void ButtonChangeSalary_Click(object sender, EventArgs e)
		{
			DialogResult result = CustomMessageBox.Show($"Ви впевнені, що " +
				$"хочете змінити зарплату?", _account.Theme, "Зміна зарплати",
				CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Question);
			buttonChangeSalary.Visible = false;

			if (result == DialogResult.Yes)
			{
				try
				{
					DataBase.UpdateEmployeeSalary(double.Parse(textBoxSalary.Text),
						_employee.Id);
					_employee.ChangeSalary(double.Parse(textBoxSalary.Text));
					_actionUpdateOrDelete(EventArgs.Empty);
				}
				catch
				{
					CustomMessageBox.Show("Дані були введені не вірно!", _account.Theme,
						"Помилка", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
			}
			textBoxSalary.Text = _employee.Salary.ToString();
		}
		#endregion

		private void ButtonFire_Click(object sender, EventArgs e)
		{
			DialogResult result = CustomMessageBox.Show($"Ви впевнені, " +
				$"що хочете звільнити цього співробітника?",
				_account.Theme, "Звільнення", CustomMessageBoxButtons.YesNo,
				CustomMessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				DataBase.DeleteEmployee(_employee.Id);
				_actionUpdateOrDelete(EventArgs.Empty);
				Close();
			}
		}

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);
	}
}