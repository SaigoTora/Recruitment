using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;
using RecruitmentServer.Models;
using SharedModels.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentServer.Forms
{
	internal partial class CandidateForm : BaseForm, IThemeChange
	{
		private const int INCREASE_FORM_HEIGHT = 100;

		private readonly int _idBusinessTrip, _idFamilyStatus;
		private readonly Account _account;
		private readonly RecruitmentLibrary.PersonInfo.Candidate _candidate;
		private readonly ControlCreator _languageCreator;
		private readonly ControlCreator _educationCreator;

		internal CandidateForm(Account account, RecruitmentLibrary.PersonInfo.Candidate candidate)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Кандидат", minimizeBox: false,
				maximizeBox: false);
			_account = account;
			_candidate = candidate;
			_idBusinessTrip = _candidate.questionnaire.ID_BusinessTripOpportunity;
			_idFamilyStatus = _candidate.questionnaire.ID_FamilyStatus;

			_languageCreator = new ControlCreator(panelLanguage, flpLanguages);
			_educationCreator = new ControlCreator(panelEducation, flpEducations);
		}
		private void CandidateForm_Load(object sender, EventArgs e)
		{
			ShowStartInfo();
			SetTheme(_account.Theme);
		}

		private void ShowStartInfo()
		{
			labelFullName.Text = $"{_candidate.Surname.ToUpper()} {_candidate.Name} " +
				$"{_candidate.FatherName}";
			labelNationality.Text = "Громадянство: " + _candidate.questionnaire.Nationality;
			labelCity.Text = "Місце проживання: " + _candidate.questionnaire.City;
			labelBirthday.Text = "Дата народження: " +
				_candidate.Birthday.ToString("yyyy-MM-dd");
			richTextBoxContact.Text = $"Номер телефону: {_candidate.Phone}" +
				$"\nE-mail: {_candidate.Email}";

			richTextBoxAdditionalInfo.Text = _candidate.questionnaire.AdditionalInfo;
			if (string.IsNullOrWhiteSpace(_candidate.questionnaire.AdditionalInfo))
			{
				labelAdditionalInfoTitle.Visible = false;
				richTextBoxAdditionalInfo.Visible = false;
			}
		}

		private void ButtonMore_Click(object sender, EventArgs e)
		{
			ShowRemainingInfo();
			Size = new Size(Width, Height + INCREASE_FORM_HEIGHT);
			buttonMore.Visible = false;
			panelMore.Visible = true;

			panelMore.Focus();
		}
		private void ShowRemainingInfo()
		{
			labelExperience.Text = $"Досвід роботи: " +
				$"{_candidate.questionnaire.Experience} міс.";
			labelBusinessTrip.Text = "Можливість відряджень: " +
				DataBase.GetBusinessTrip(_idBusinessTrip);
			if (_candidate.questionnaire.DriverLicense)
				labelDriverLicense.Text = "Має посвідчення водія";
			else
				labelDriverLicense.Text = "НЕ має посвідчення водія";
			labelReadiness.Text = $"Готовність до роботи: " +
				$"{_candidate.questionnaire.Readiness} дн.";
			labelFamilyStatus.Text = "Сімейний стан: " +
				DataBase.GetFamilyStatus(_idFamilyStatus);
			labelChildrenAmount.Text = "Кількість дітей: " +
				_candidate.questionnaire.ChildrenAmount;

			ShowHealth(_candidate.questionnaire.CandidateHealth);
			CreateLanguages(_candidate.questionnaire.Languages);
			CreateEducations(_candidate.questionnaire.Educations);
		}
		private void ShowHealth(Health health)
		{
			if (health.Smoker)
				labelSmokerAlcohol.Text = "Є курцем, ";
			else
				labelSmokerAlcohol.Text = "НЕ є курцем, ";
			if (health.DrinkAlcohol)
				labelSmokerAlcohol.Text += "вживає алкоголь";
			else
				labelSmokerAlcohol.Text += "НЕ вживає алкоголь";
			if (!string.IsNullOrWhiteSpace(health.ChronicDiseases))
				richTextBoxChronicDiseases.Text = health.ChronicDiseases;
			else
			{
				labelChronicDiseases.Text = "Хронічних захворювань немає";
				richTextBoxChronicDiseases.Visible = false;
			}
		}
		private void CreateLanguages(List<Language> languages)
		{
			for (int i = 0; i < languages.Count; i++)
			{
				_languageCreator.CreateMainPanel();
				_languageCreator.CreateLabel(labelLanguageNumber, (i + 1).ToString());
				_languageCreator.CreateLabel(labelLanguage, "Мова: " + languages[i].Name);
				_languageCreator.CreateLabel(labelLevel, "Рівень знань: " +
					languages[i].Level);
			}
		}
		private void CreateEducations(List<Education> educations)
		{
			for (int i = 0; i < educations.Count; i++)
			{
				_educationCreator.CreateMainPanel();
				_educationCreator.CreateLabel(labelEducationNumber, (i + 1).ToString());
				_educationCreator.CreateLabel(labelNameInstitution, "Назва закладу: " +
					educations[i].NameInstitution);
				_educationCreator.CreateLabel(labelSpecialty, "Спецальність: " +
					educations[i].Specialty);
				_educationCreator.CreateLabel(labelEducationDegree, "Ступінь освіти: " +
					DataBase.GetEducationDegree(educations[i].IdEducationDegree));
				_educationCreator.CreateLabel(labelYearAdmission, "Рік вступу: " +
					educations[i].YearAdmission);
				_educationCreator.CreateLabel(labelDateEnd, "Дата закінчення: " +
					educations[i].DateEnd.ToString("yyyy-MM-dd"));
				_educationCreator.CreateLabel(labelEducationForm, "Форма навчання: " +
					DataBase.GetEducationForm(educations[i].IdEducationForm));
			}
		}

		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);
			panelMain.BackColor = BackColor;
			panelMore.BackColor = BackColor;
			flpLanguages.BackColor = BackColor;
			flpEducations.BackColor = BackColor;

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
			_languageCreator.Dispose();
			_educationCreator.Dispose();
		}
	}
}