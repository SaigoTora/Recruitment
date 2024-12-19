using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using RecruitmentServer.ServerUtilities;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentServer.Forms
{
	internal partial class CandidateForm : BaseForm, IThemeChange
	{// Форма кандидата
		private const int INCREASE_FORM_HEIGHT = 100;
		private readonly int idBusinessTrip, idFamilyStatus;
		private readonly ControlCreator languageCreator;
		private readonly ControlCreator educationCreator;

		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		internal CandidateForm(Candidate candidate, ServerAccount account)
		{// Конструктор форми кандидата
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Кандидат", minimizeBox: false, maximizeBox: false);
			labelFullName.Text = $"{candidate.Surname.ToUpper()} {candidate.Name} {candidate.FatherName}";
			labelNationality.Text = "Громадянство: " + candidate.questionnaire.Nationality;
			labelCity.Text = "Місце проживання: " + candidate.questionnaire.City;
			labelBirthday.Text = "Дата народження: " + candidate.Birthday.ToString("yyyy-MM-dd");
			richTextBoxContact.Text = $"Номер телефону: {candidate.Phone}\nE-mail: {candidate.Email}";

			richTextBoxAdditionalInfo.Text = candidate.questionnaire.AdditionalInfo;// Додаткова інформація
			if (candidate.questionnaire.AdditionalInfo == null || candidate.questionnaire.AdditionalInfo.Length < 0)
			{
				labelAdditionalInfoTitle.Visible = false;
				richTextBoxAdditionalInfo.Visible = false;
			}

			labelExperience.Text = $"Досвід роботи: {candidate.questionnaire.Experience} міс.";
			labelReadiness.Text = $"Готовність до роботи: {candidate.questionnaire.Readiness} дн.";
			if (candidate.questionnaire.DriverLicense)
				labelDriverLicense.Text = "Має посвідчення водія";
			else
				labelDriverLicense.Text = "НЕ має посвідчення водія";
			labelChildrenAmount.Text = "Кількість дітей: " + candidate.questionnaire.ChildrenAmount;
			idBusinessTrip = candidate.questionnaire.ID_BusinessTripOpportunity;
			idFamilyStatus = candidate.questionnaire.ID_FamilyStatus;
			CreateHealth(candidate.questionnaire.CandidateHealth);

			SetTheme(account.Theme);

			languageCreator = new ControlCreator(panelLanguage, flpLanguages);
			educationCreator = new ControlCreator(panelEducation, flpEducations);
			CreateLanguages(candidate.questionnaire.Languages);
			CreateEducations(candidate.questionnaire.Educations);
			buttonEventHandlers.SubscribeToHover(buttonMore);
		}
		internal void CreateHealth(Health health)
		{// Метод створює інформацію про ЗДОРОВ'Я на формі
			if (health.Smoker)
				labelSmokerAlcohol.Text = "Є курцем, ";
			else
				labelSmokerAlcohol.Text = "НЕ є курцем, ";
			if (health.DrinkAlcohol)
				labelSmokerAlcohol.Text += "вживає алкоголь";
			else
				labelSmokerAlcohol.Text += "НЕ вживає алкоголь";
			if (health.ChronicDiseases != null && health.ChronicDiseases.Length > 0)
				richTextBoxChronicDiseases.Text = health.ChronicDiseases;
		}
		internal void CreateLanguages(List<Language> languages)
		{// Метод створює інформацію про МОВИ на формі

			ControlCreator creator = new ControlCreator(panelLanguage, flpLanguages);
			for (int i = 0; i < languages.Count; i++)
			{
				languageCreator.CreateMainPanel();
				languageCreator.CreateLabel(labelLanguageNumber, (i + 1).ToString());
				languageCreator.CreateLabel(labelLanguage, "Мова: " + languages[i].Name);
				languageCreator.CreateLabel(labelLevel, "Рівень знань: " + languages[i].Level);
			}
		}
		internal void CreateEducations(List<Education> educations)
		{// Метод створює інформацію про ОСВІТИ на формі
			ControlCreator creator = new ControlCreator(panelEducation, flpEducations);
			for (int i = 0; i < educations.Count; i++)
			{
				educationCreator.CreateMainPanel();
				educationCreator.CreateLabel(labelEducationNumber, (i + 1).ToString());
				educationCreator.CreateLabel(labelNameInstitution, "Назва закладу: " + educations[i].NameInstitution);
				educationCreator.CreateLabel(labelSpecialty, "Спецальність: " + educations[i].Specialty);
				educationCreator.CreateLabel(labelEducationDegree, "Ступінь освіти: " +
					DataBase.GetEducationDegree(educations[i].ID_EducationDegree));
				educationCreator.CreateLabel(labelYearAdmission, "Рік вступу: " + educations[i].YearAdmission);
				educationCreator.CreateLabel(labelDateEnd, "Дата закінчення: " + educations[i].DateEnd.ToString("yyyy-MM-dd"));
				educationCreator.CreateLabel(labelEducationForm, "Форма навчання: " +
					DataBase.GetEducationForm(educations[i].ID_EducationForm));
			}
		}

		private void ButtonMore_Click(object sender, System.EventArgs e)
		{// Обробник події натискання на кнопку "Більше"
			Size = new Size(Width, Height + INCREASE_FORM_HEIGHT);
			buttonMore.Visible = false;
			panelMore.Visible = true;
			labelBusinessTrip.Text = "Можливість відряджень: " + DataBase.GetBusinessTrip(idBusinessTrip);
			labelFamilyStatus.Text = "Сімейний стан: " + DataBase.GetFamilyStatus(idFamilyStatus);

			panelMore.Focus();
		}

		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);

			switch (theme)
			{
				case Theme.White:
					pictureBoxLine.BackColor = Color.Black;
					break;
				case Theme.Black:
					pictureBoxLine.BackColor = Color.White;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}

		private void CandidateForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			languageCreator.Dispose();
			educationCreator.Dispose();
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}