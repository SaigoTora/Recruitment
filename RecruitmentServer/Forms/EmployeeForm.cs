using System;
using System.Windows.Forms;

using RecruitmentServer.Models;
using SharedModels.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentServer.Forms
{
	internal partial class EmployeeForm : BaseForm, IThemeChange
	{
		private readonly Account _account;
		private readonly Employee _employee;
		private readonly Action<EventArgs> _actionAfterChange;

		internal EmployeeForm(Account account, Employee employee,
			Action<EventArgs> actionAfterChange)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Співробітник", minimizeBox: false,
				maximizeBox: false);
			_account = account;
			_employee = employee;
			_actionAfterChange = actionAfterChange;
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
			textBoxPosition.Text = employee.PositionName;
			textBoxSalary.Text = $"{employee.Salary:0.##}";
			labelCity.Text = "Місце проживання: " + employee.City.ToString();
			labelBirthday.Text = "Дата народження: " +
				employee.Birthday.ToString("yyyy-MM-dd");
			labelDateEmployment.Text = "Дата працевлаштування: " +
				employee.DateEmployment.ToString("yyyy-MM-dd");
			richTextBoxContact.Text = $"Номер телефону: {employee.Phone}" +
				$"\nE-mail: {employee.Email}";
		}

		#region Label focus event handlers
		private void LabelSalaryTitle_Click(object sender, EventArgs e)
			=> textBoxSalary.Focus();
		#endregion

		#region TextBox event handlers
		private void TextBoxPosition_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				if (buttonChangePosition.Visible)
					buttonChangePosition.PerformClick();
				else
					textBoxSalary.Focus();
			}
		}
		private void TextBoxSalary_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				if (buttonChangeSalary.Visible)
					buttonChangeSalary.PerformClick();
				else
					textBoxPosition.Focus();
			}
		}
		private void TextBoxSalary_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back
				&& e.KeyChar != ',')
				e.Handled = true;
		}

		private void TextBoxSalary_TextChanged(object sender, EventArgs e)
		{
			if (textBoxSalary.Text != $"{_employee.Salary:0.##}")
				buttonChangeSalary.Visible = true;
			else
				buttonChangeSalary.Visible = false;
		}
		private void TextBoxPosition_TextChanged(object sender, EventArgs e)
		{
			if (textBoxPosition.Text != _employee.PositionName)
				buttonChangePosition.Visible = true;
			else
				buttonChangePosition.Visible = false;
		}
		#endregion

		#region Button event handlers
		private void ButtonChangePosition_Click(object sender, EventArgs e)
		{
			if (CheckValidPosition())
			{
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
						_actionAfterChange(EventArgs.Empty);
					}
					catch
					{
						CustomMessageBox.Show("Дані були введені не вірно!",
							_account.Theme, "Помилка введення",
							CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
					}
				}
			}
			textBoxPosition.Text = _employee.PositionName.ToString();
		}
		private void ButtonChangeSalary_Click(object sender, EventArgs e)
		{
			if (CheckValidSalary())
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
						_employee.ChangeSalary(decimal.Parse(textBoxSalary.Text));
						_actionAfterChange(EventArgs.Empty);
					}
					catch
					{
						CustomMessageBox.Show("Дані були введені не вірно!",
							_account.Theme, "Помилка",
							CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
					}
				}
			}
			textBoxSalary.Text = $"{_employee.Salary:0.##}";
		}

		private bool CheckValidPosition()
		{
			Validator validator = new Validator();
			Label labelPosition = new Label() { Text = "Посада" };
			validator.CheckBannedChar(labelPosition, textBoxPosition.Text,
				Server.SEPARATOR, _account.Theme);
			validator.CheckMinLength(labelPosition, textBoxPosition, 3, _account.Theme);

			return validator.IsDataValid;
		}
		private bool CheckValidSalary()
		{
			ValidationFeedbackManager.ResetLabelsToDefault(_account.Theme,
				labelSalaryTitle);

			Validator validator = new Validator();
			validator.CheckSymbols(labelSalaryTitle, textBoxSalary, _account.Theme,
				ValidLanguage.None, "0123456789,");
			validator.CheckMinLength(labelSalaryTitle, textBoxSalary, 1, _account.Theme);

			return validator.IsDataValid;
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
				_actionAfterChange(EventArgs.Empty);
				Close();
			}
		}

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);
	}
}