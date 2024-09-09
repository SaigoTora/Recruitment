using System;
using System.Windows.Forms;

using RecruitmentLibrary.ApplicationInfo;
using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using ServerDB.DataModels;
using ServerDB.ServerUtilities;

namespace ServerDB.Forms
{
	internal partial class VacancyForm : Form, IThemeChange
	{// Форма вакансії
		private const int DECREASE_FORM_HEIGHT = 130;
		private readonly FullRequirement requirement = new FullRequirement();// Вимоги
		private readonly ServerAccount account;// Акаунт
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		private FullVacancy vacancy;// Вакансія
		private Points points = new Points();// Бали
		private readonly Action<EventArgs> refresh;// Перезавантаження головної форми
		internal VacancyForm(ServerAccount account, Action<EventArgs> refresh)
		{// Конструктор форми створення вакансії
			InitializeComponent();

			// Зменшуємо розмір форми
			Size = new System.Drawing.Size(Width, Height - DECREASE_FORM_HEIGHT);
			this.refresh = refresh;// Встановлюємо значення для створення вакансії
			labelApplicationCount.Visible = false;
			labelRelevance.Visible = false;
			labelDatePublication.Visible = false;

			richTextBoxPosition.ReadOnly = false;
			richTextBoxSalary.ReadOnly = false;
			richTextBoxPositionDescription.ReadOnly = false;
			richTextBoxAdditionalInfo.ReadOnly = false;

			richTextBoxPosition.TabStop = true;
			richTextBoxSalary.TabStop = true;
			richTextBoxPositionDescription.TabStop = true;
			richTextBoxAdditionalInfo.TabStop = true;
			richTextBoxPosition.Focus();

			buttonRequirement.Click += ButtonRequirementCreate_Click;
			buttonPoints.Click += ButtonPointsCreate_Click;
			buttonEventHandlers.SubscribeToHover(buttonRequirement, buttonPoints, buttonCreate);

			this.account = account;
			SetTheme(account.Theme);
		}
		internal VacancyForm(FullVacancy vacancy, ServerAccount account, Action<EventArgs> refresh = null, bool isDeleteButtonVisible = true)
		{// Конструктор форми перегляду вакансії
			InitializeComponent();

			this.refresh = refresh;
			buttonCreate.Visible = false;// Встановлюємо значення для перегляду вакансії
			this.vacancy = vacancy;
			richTextBoxPosition.Text = vacancy.Position.Name;
			richTextBoxSalary.Text = vacancy.Salary.ToString();
			labelApplicationCount.Text = "Кількість заявок: " + vacancy.ApplicationCount.ToString();
			string relevance = vacancy.Relevance ? "Актуальна" : "НЕ актуальна";// Актуальність
																				// Якщо вакансія актуальна та можна включити видимість кнопки видалення
			if (vacancy.Relevance && isDeleteButtonVisible)
				buttonDelete.Visible = true;
			labelRelevance.Text = relevance;
			richTextBoxPositionDescription.Text = vacancy.Position.Description;
			richTextBoxAdditionalInfo.Text = vacancy.Info;
			labelDatePublication.Text = "Дата публікації: " + vacancy.DatePublication.ToString("yyyy-MM-dd");

			buttonRequirement.Click += ButtonRequirementShow_Click;
			buttonPoints.Click += ButtonPointsShow_Click;
			buttonEventHandlers.SubscribeToHover(buttonRequirement, buttonPoints, buttonCreate, buttonDelete);

			this.account = account;
			SetTheme(account.Theme);
			richTextBoxPosition.BackColor = BackColor;
			richTextBoxSalary.BackColor = BackColor;
		}

		private void ButtonRequirementShow_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Вимоги" для перегляду
		 // Отримуємо дані з БД
			string requirement = DataBase.GetRequirement(vacancy.IdRequirement).ToString();
			string educationDegrees = DataBase.GetRequirementEducationDegree(vacancy.IdRequirement);

			if (educationDegrees != null && educationDegrees != string.Empty)
			{// Якщо є вимоги до ступенів освіти
				if (requirement != string.Empty)// Якщо до цього був текст
					requirement += "\n\n";
				requirement += $"Необхідно мати один із ступенів освіти: {educationDegrees}.";
			}

			MessageBox.Show(requirement, "Вимоги", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		private void ButtonRequirementCreate_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку "Вимоги" для створення
			RequirementForm reqf = new RequirementForm(requirement, account);
			Visible = false;
			reqf.FormClosed += (s, args) =>
			{ Visible = true; };
			reqf.ShowDialog();
		}

		private void ButtonPointsShow_Click(object sender, EventArgs e)
		{// Обробник події зміни балів
			points = DataBase.GetPoints(vacancy.IdPoint);// Отримуємо дані з БД
			PointsForm pf = new PointsForm(points, true, account);
			Visible = false;
			pf.FormClosed += (s, args) =>
			{ Visible = true; };
			pf.ShowDialog();
		}
		private void ButtonPointsCreate_Click(object sender, EventArgs e)
		{// Обробник події створення балів
			PointsForm pf = new PointsForm(points, false, account);
			Visible = false;
			pf.FormClosed += (s, args) =>
			{ Visible = true; };
			pf.ShowDialog();
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку створення вакансії
			if (CheckValidData())
			{
				// Створюємо в БД бали, вимоги та вакансію
				int idPoint = DataBase.CreatePoints(points);
				int idRequirement = DataBase.CreateRequirement(requirement);

				Position position = new Position(richTextBoxPosition.Text, richTextBoxPositionDescription.Text);
				vacancy = new FullVacancy(0, position, double.Parse(richTextBoxSalary.Text),
					DateTime.UtcNow, richTextBoxAdditionalInfo.Text, true, 0, idPoint, idRequirement);
				DataBase.CreateVacancy(vacancy);

				refresh(EventArgs.Empty);// Перезавантажуємо головну форму
				Close();
			}
		}
		private bool CheckValidData()
		{// Метод перевіряє та показує які дані були введені не вірно
			bool isDataOk = true;
			Validator.SetDefaultLabels(account.Theme, labelSalaryTitle, labelPositionDescriptionTitle,
				labelAdditionalInfoTitle);// Встановлюємо значення label-ів за замовчуванням

			Label bufLabel = new Label { Text = "Посада" };
			Validator.CheckBannedChar(bufLabel, richTextBoxPosition.Text, Server.SEPARATOR, ref isDataOk);// Посада
			Validator.CheckMinLength(bufLabel, richTextBoxPosition, 3, ref isDataOk);
			Validator.CheckSymbols(labelSalaryTitle, richTextBoxSalary, ref isDataOk, ValidLanguage.None, "0123456789,");// Зарплата
			Validator.CheckMinLength(labelSalaryTitle, richTextBoxSalary, 1, ref isDataOk);
			Validator.CheckBannedChar(labelPositionDescriptionTitle, richTextBoxPositionDescription.Text, Server.SEPARATOR, ref isDataOk);// Опис
			Validator.CheckBannedChar(labelAdditionalInfoTitle, richTextBoxAdditionalInfo.Text, Server.SEPARATOR, ref isDataOk);// Додаткова інформація

			if (requirement.City == null)
			{// Якщо не заповнили вимоги
				if (isDataOk)
				{
					buttonRequirement.Focus();
					MessageBox.Show("Дані були введені не вірно!\nВимоги також потрібно заповнити.",
						"Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				isDataOk = false;
			}
			if (points.Degrees == null)
			{// Якщо не заповнили бали
				if (isDataOk)
				{
					buttonPoints.Focus();
					MessageBox.Show("Дані були введені не вірно!\nБали також потрібно заповнити.",
						"Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				isDataOk = false;
			}

			return isDataOk;
		}
		private void ButtonDelete_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку видалення вакансії
			DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цю вакансію?\n" +
				"При видаленні вакансії також будуть видалені всі заявки та співбесіди, які пов'язані з цією вакансією", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				DataBase.DeleteVacancy(vacancy.Id);
				refresh(EventArgs.Empty);
				Close();
			}
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelPosition, labelSalaryTitle,
				labelApplicationCount, labelRelevance, labelDatePublication,
				labelPositionDescriptionTitle, labelAdditionalInfoTitle);

			ColorChanger.ChangeInputControlsColor(theme, richTextBoxPosition, richTextBoxSalary,
				richTextBoxPositionDescription, richTextBoxAdditionalInfo);

			if (theme == Theme.White)// Якщо треба встановити світлу тему
				BackColor = ColorChanger.BackColorThemeW;
			else if (theme == Theme.Black)// Якщо треба встановити темну тему
				BackColor = ColorChanger.BackColorThemeB;
		}

		private void VacancyForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}