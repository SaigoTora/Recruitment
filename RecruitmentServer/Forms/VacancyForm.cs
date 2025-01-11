using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

using RecruitmentLibrary.ApplicationInfo;
using RecruitmentServer.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentServer.Forms
{
	internal partial class VacancyForm : BaseForm, IThemeChange
	{
		private readonly Account _account;
		private FullVacancy _vacancy;
		private readonly FullRequirement _requirement = new FullRequirement();
		private Points _points = new Points();
		private readonly Action<EventArgs> _actionAfterChange;

		private VacancyForm()
		{
			InitializeComponent();
			customTitleBar = new CustomTitleBar(this, "Вакансія", minimizeBox: false,
				maximizeBox: false);
		}
		internal VacancyForm(Account account, Action<EventArgs> actionAfterChange)
			: this()
		{// Constructor for creating a vacancy
			_account = account;
			_actionAfterChange = actionAfterChange;

			ConfigureFormForVacancyCreation();
		}
		internal VacancyForm(Account account, FullVacancy vacancy,
			Action<EventArgs> actionAfterChange = null, bool isDeleteButtonVisible = true)
			: this()
		{// Constructor for viewing vacancies
			_account = account;
			_vacancy = vacancy;
			_actionAfterChange = actionAfterChange;

			ConfigureFormForVacancyViewing(vacancy, isDeleteButtonVisible);
		}
		private void VacancyForm_Load(object sender, EventArgs e)
		{
			SetTheme(_account.Theme);

			if (_vacancy != null && labelRelevance.Visible)
				labelRelevance.ForeColor = GetRelevanceColor(_vacancy.Relevance);
		}

		private void ConfigureFormForVacancyCreation()
		{
			const int DECREASE_FORM_HEIGHT = 70;

			Size = new System.Drawing.Size(Width, Height - DECREASE_FORM_HEIGHT);
			textBoxPosition.ReadOnly = false;
			textBoxSalary.ReadOnly = false;
			labelApplicationCount.Visible = false;
			labelDatePublication.Visible = false;
			labelRelevance.Visible = false;
			richTextBoxPositionDescription.ReadOnly = false;
			richTextBoxAdditionalInfo.ReadOnly = false;
			buttonCreate.Visible = true;

			textBoxPosition.TabStop = true;
			textBoxSalary.TabStop = true;
			richTextBoxPositionDescription.TabStop = true;
			richTextBoxAdditionalInfo.TabStop = true;
			textBoxPosition.Focus();

			ManageButtonForCreateEvents(true);
		}
		private void ConfigureFormForVacancyViewing(FullVacancy vacancy,
			bool isDeleteButtonVisible)
		{
			textBoxPosition.Text = vacancy.Position.Name;
			textBoxSalary.Text = vacancy.Salary.ToString();
			labelApplicationCount.Text = "Кількість заявок: " +
				vacancy.ApplicationCount.ToString();
			labelDatePublication.Text = "Дата публікації: " +
				vacancy.DatePublication.ToString("yyyy-MM-dd");
			string relevance = vacancy.Relevance ? "Актуальна" : "НЕ актуальна";
			labelRelevance.Text = relevance;
			richTextBoxPositionDescription.Text = vacancy.Position.Description;
			richTextBoxAdditionalInfo.Text = vacancy.Info;
			if (vacancy.Relevance && isDeleteButtonVisible)
				buttonDelete.Visible = true;

			textBoxPosition.BorderThickness = 0;
			textBoxSalary.BorderThickness = 0;
			ConfigureRichTextBoxForViewing(richTextBoxPositionDescription);
			ConfigureRichTextBoxForViewing(richTextBoxAdditionalInfo);
			ConfigureLabelsForViewing();

			ManageButtonForViewEvents(true);
		}
		private Color GetRelevanceColor(bool relevance)
		{
			(Color Yes, Color No) =
				(Color.FromArgb(0, 109, 91), Color.FromArgb(255, 185, 97));
			if (relevance)
				return Yes;
			else
				return No;
		}
		private void ConfigureRichTextBoxForViewing(Guna2TextBox richTextBox)
		{
			richTextBox.BorderThickness = 0;
			richTextBox.PlaceholderText = string.Empty;
		}
		private void ConfigureLabelsForViewing()
		{
			labelPosition.Cursor = Cursors.Default;
			labelSalaryTitle.Cursor = Cursors.Default;
			labelPositionDescriptionTitle.Cursor = Cursors.Default;
			labelAdditionalInfoTitle.Cursor = Cursors.Default;

			labelPosition.Click -= LabelPosition_Click;
			labelSalaryTitle.Click -= LabelSalaryTitle_Click;
			labelPositionDescriptionTitle.Click -= LabelPositionDescriptionTitle_Click;
			labelAdditionalInfoTitle.Click -= LabelAdditionalInfoTitle_Click;
		}
		private void ManageButtonForCreateEvents(bool subscribe)
		{
			if (subscribe)
			{
				buttonRequirement.Click += ButtonRequirementCreate_Click;
				buttonPoints.Click += ButtonPointsCreate_Click;
			}
			else
			{
				buttonRequirement.Click -= ButtonRequirementCreate_Click;
				buttonPoints.Click -= ButtonPointsCreate_Click;
			}
		}
		private void ManageButtonForViewEvents(bool subscribe)
		{
			if (subscribe)
			{
				buttonRequirement.Click += ButtonRequirementShow_Click;
				buttonPoints.Click += ButtonPointsShow_Click;
			}
			else
			{
				buttonRequirement.Click -= ButtonRequirementShow_Click;
				buttonPoints.Click -= ButtonPointsShow_Click;
			}
		}

		private void TextBoxSalary_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back
				&& e.KeyChar != ',')
				e.Handled = true;
		}

		#region Button event handlers
		private void ButtonRequirementShow_Click(object sender, EventArgs e)
		{
			string requirement = DataBase.GetRequirement(_vacancy.IdRequirement).ToString();
			string educationDegrees = DataBase.GetRequirementEducationDegree(
				_vacancy.IdRequirement);

			if (educationDegrees != null && educationDegrees != string.Empty)
			{
				if (requirement != string.Empty)
					requirement += "\n\n";
				requirement += $"Необхідно мати один із ступенів освіти: {educationDegrees}.";
			}
			if (requirement == string.Empty)
				requirement = "Вимог немає.";

			CustomMessageBox.Show(requirement, _account.Theme, "Вимоги",
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
		}
		private void ButtonRequirementCreate_Click(object sender, EventArgs e)
		{
			RequirementForm requirementForm = new RequirementForm(_account, _requirement);
			Visible = false;
			requirementForm.FormClosed += (s, args) => { Visible = true; };
			requirementForm.ShowDialog();
		}

		private void ButtonPointsShow_Click(object sender, EventArgs e)
		{
			_points = DataBase.GetPoints(_vacancy.IdPoint);

			PointsForm pointsForm = new PointsForm(_account, _points, true);
			Visible = false;
			pointsForm.FormClosed += (s, args) => { Visible = true; };
			pointsForm.ShowDialog();
		}
		private void ButtonPointsCreate_Click(object sender, EventArgs e)
		{
			PointsForm pointsForm = new PointsForm(_account, _points, false);
			Visible = false;
			pointsForm.FormClosed += (s, args) => { Visible = true; };
			pointsForm.ShowDialog();
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			if (CheckValidData())
			{
				int pointId = DataBase.CreatePoints(_points);
				int requirementId = DataBase.CreateRequirement(_requirement);
				Position position = new Position(textBoxPosition.Text,
					richTextBoxPositionDescription.Text);

				_vacancy = new FullVacancy(0, position, double.Parse(textBoxSalary.Text),
					DateTime.UtcNow, richTextBoxAdditionalInfo.Text, true, 0, pointId,
					requirementId);
				DataBase.CreateVacancy(_vacancy);

				_actionAfterChange(EventArgs.Empty);
				Close();
			}
		}
		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = CustomMessageBox.Show("Ви впевнені, що хочете видалити " +
				"цю вакансію?\nПри видаленні вакансії також будуть видалені всі заявки та " +
				"співбесіди, які пов'язані з цією вакансією", _account.Theme, "Видалення",
				CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Warning);

			if (result == DialogResult.Yes)
			{
				DataBase.DeleteVacancy(_vacancy.Id);
				_actionAfterChange(EventArgs.Empty);
				Close();
			}
		}

		private bool CheckValidData()
		{
			ValidationFeedbackManager.ResetLabelsToDefault(_account.Theme, labelPosition,
				labelSalaryTitle, labelPositionDescriptionTitle,
				labelAdditionalInfoTitle);

			Validator validator = new Validator();
			validator.CheckBannedChar(labelPosition, textBoxPosition.Text, Server.SEPARATOR,
				_account.Theme);
			validator.CheckMinLength(labelPosition, textBoxPosition, 3, _account.Theme);
			validator.CheckSymbols(labelSalaryTitle, textBoxSalary, _account.Theme,
				ValidLanguage.None, "0123456789,");
			validator.CheckMinLength(labelSalaryTitle, textBoxSalary, 1, _account.Theme);

			validator.CheckBannedChar(labelPositionDescriptionTitle,
				richTextBoxPositionDescription.Text, Server.SEPARATOR, _account.Theme);
			validator.CheckBannedChar(labelAdditionalInfoTitle,
				richTextBoxAdditionalInfo.Text, Server.SEPARATOR, _account.Theme);

			bool isDataValid = validator.IsDataValid;
			ValidateRequirements(ref isDataValid);
			ValidatePoints(ref isDataValid);

			return isDataValid;
		}
		private void ValidateRequirements(ref bool isDataValid)
		{
			if (_requirement.City == null)
			{// If the requirements are not filled in
				if (isDataValid)
				{
					buttonRequirement.Focus();
					CustomMessageBox.Show("Дані були введені не вірно!" +
						"\nВимоги також потрібно заповнити.",
						_account.Theme, "Помилка введення",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
				isDataValid = false;
			}
		}
		private void ValidatePoints(ref bool isDataValid)
		{
			if (_points.Degrees == null)
			{// If the points are not filled in
				if (isDataValid)
				{
					buttonPoints.Focus();
					CustomMessageBox.Show("Дані були введені не вірно!" +
						"\nБали також потрібно заповнити.",
						_account.Theme, "Помилка введення",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
				isDataValid = false;
			}
		}
		#endregion

		#region TextBox event handlers
		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SelectNextControl(ActiveControl, true, true, true, false);
			}
		}
		#endregion

		#region Label focus event handlers
		private void LabelPosition_Click(object sender, EventArgs e)
			=> textBoxPosition.Focus();
		private void LabelSalaryTitle_Click(object sender, EventArgs e)
			=> textBoxSalary.Focus();
		private void LabelPositionDescriptionTitle_Click(object sender, EventArgs e)
			=> richTextBoxPositionDescription.Focus();
		private void LabelAdditionalInfoTitle_Click(object sender, EventArgs e)
			=> richTextBoxAdditionalInfo.Focus();
		#endregion

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);

		private void VacancyForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ManageButtonForCreateEvents(false);
			ManageButtonForViewEvents(false);
		}
	}
}