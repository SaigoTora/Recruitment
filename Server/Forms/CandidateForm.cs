using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using ServerDB.ServerUtilities;

namespace ServerDB.Forms
{
	internal partial class CandidateForm : Form, IThemeChange
	{// Форма кандидата
		private const int INCREASE_FORM_HEIGHT = 100;
		private readonly int idBusinessTrip, idFamilyStatus;
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();
		internal CandidateForm(Candidate candidate, ServerAccount account)
		{// Конструктор форми кандидата
			InitializeComponent();

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
			for (int i = 0; i < languages.Count; i++)
			{
				Creator creator = new Creator(panelLanguage, flpLanguages, i + 1);
				creator.CreateLabel(labelLanguageNumber, (i + 1).ToString());
				creator.CreateLabel(labelLanguage, "Мова: " + languages[i].Name);
				creator.CreateLabel(labelLevel, "Рівень знань: " + languages[i].Level);
			}
		}
		internal void CreateEducations(List<Education> educations)
		{// Метод створює інформацію про ОСВІТИ на формі
			for (int i = 0; i < educations.Count; i++)
			{
				Creator creator = new Creator(panelEducation, flpEducations, i + 1);
				creator.CreateLabel(labelEducationNumber, (i + 1).ToString());
				creator.CreateLabel(labelNameInstitution, "Назва закладу: " + educations[i].NameInstitution);
				creator.CreateLabel(labelSpecialty, "Спецальність: " + educations[i].Specialty);
				creator.CreateLabel(labelEducationDegree, "Ступінь освіти: " +
					DataBase.GetEducationDegree(educations[i].ID_EducationDegree));
				creator.CreateLabel(labelYearAdmission, "Рік вступу: " + educations[i].YearAdmission);
				creator.CreateLabel(labelDateEnd, "Дата закінчення: " + educations[i].DateEnd.ToString("yyyy-MM-dd"));
				creator.CreateLabel(labelEducationForm, "Форма навчання: " +
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
		}

		private void CandidateForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelFullName,
				labelNationality, labelCity, labelBirthday, labelContact,
				labelAdditionalInfoTitle, labelExperience, labelReadiness,
				labelDriverLicense, labelChildrenAmount, labelBusinessTrip,
				labelFamilyStatus, labelHealth, labelSmokerAlcohol,
				labelChronicDiseases, labelLanguageTitle, labelLanguageNumber,
				labelLanguage, labelLevel, labelLanguageHelp, labelEducationTitle, labelEducationNumber,
				labelNameInstitution, labelSpecialty, labelEducationDegree, labelYearAdmission,
				labelDateEnd, labelEducationForm);

			ColorChanger.ChangeInputControlsColor(theme, richTextBoxContact,
				 richTextBoxAdditionalInfo, richTextBoxChronicDiseases);

			if (theme == Theme.White)
			{// Якщо треба встановити світлу тему
				BackColor = ColorChanger.BackColorThemeW;
				pictureBoxLine.BackColor = Color.Black;
				flpLanguages.BackColor = Color.FromArgb(213, 213, 213);
				flpEducations.BackColor = Color.FromArgb(213, 213, 213);
				panelLanguage.BackColor = Color.FromArgb(230, 230, 230);
				panelEducation.BackColor = Color.FromArgb(230, 230, 230);
			}
			else if (theme == Theme.Black)
			{// Якщо треба встановити темну тему
				BackColor = ColorChanger.BackColorThemeB;
				pictureBoxLine.BackColor = Color.White;
				flpLanguages.BackColor = Color.FromArgb(32, 32, 32);
				flpEducations.BackColor = Color.FromArgb(32, 32, 32);
				panelLanguage.BackColor = Color.FromArgb(40, 40, 40);
				panelEducation.BackColor = Color.FromArgb(40, 40, 40);
			}
		}
	}
}