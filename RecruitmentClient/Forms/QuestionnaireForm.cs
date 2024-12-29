using System;
using System.Collections.Generic;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;
using RecruitmentClient.ClientUtilities;
using RecruitmentClient.FormUtilities;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;
using Guna.UI2.WinForms;
using System.Net.Sockets;

namespace RecruitmentClient.Forms
{
	internal partial class QuestionnaireForm : BaseForm, IThemeChange
	{
		private const int MAX_LANGUAGE_COUNT = 10;
		private const int MAX_EDUCATION_COUNT = 5;
		private const string DEFAULT_NATIONALITY = "Україна";
		private const string DEFAULT_LANGUAGE = "Українська";

		private readonly int _defaultYearAdmission = DateTime.Today.Year - 4;

		private readonly ClientAccount _account;
		private readonly Questionnaire _oldQuestionnaire = null;
		private readonly bool _formOpenForChange = false;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly RadioButtonEventHandlers _radionButtonEventHandlers =
			new RadioButtonEventHandlers();

		private readonly List<LanguageFormElements> _languages =
			new List<LanguageFormElements>(MAX_LANGUAGE_COUNT);
		private readonly ControlCreator _languageCreator;
		private readonly List<EducationFormElements> _educations =
			new List<EducationFormElements>(MAX_EDUCATION_COUNT);
		private readonly ControlCreator _educationCreator;

		internal QuestionnaireForm(ClientAccount account, StartForm startForm)
		{
			customTitleBar = new CustomTitleBar(this, "Анкета",
				Properties.Resources.questionnaire, minimizeBox: false);
			IsResizable = true;
			InitializeComponent();

			_account = account;
			if (startForm == null)
			{
				_oldQuestionnaire = new Questionnaire(_account.candidate.questionnaire);
				_formOpenForChange = true;
			}

			_languages.Add(new LanguageFormElements(panelLanguage, labelLanguage, comboBoxLanguage, numericUpDownLevel));
			_languageCreator = new ControlCreator(panelLanguage, flpLanguages);
			_educationCreator = new ControlCreator(panelEducation, flpEducations);
		}
		private void QuestionnaireForm_Load(object sender, EventArgs e)
		{
			SetTheme(_account.Theme);
			SetComboBoxItems();
			comboBoxFamilyStatus.SelectedIndex = 1;
			comboBoxBusinessTripOpportunity.SelectedIndex = 1;
			numericUpDownYearAdmission.Maximum = DateTime.Today.Year + 1;
			ResetEducationFields();
			comboBoxNationality.Focus();

			if (_account.candidate.questionnaire == null)
			{
				_account.candidate.questionnaire = new Questionnaire();
				comboBoxNationality.SelectedIndex =
					comboBoxNationality.FindString(DEFAULT_NATIONALITY);
				comboBoxLanguage.SelectedIndex =
					comboBoxLanguage.FindString(DEFAULT_LANGUAGE);
				ButtonAddEducation_Click(new Object(), EventArgs.Empty);
			}
			else
				SetFormFields(_account.candidate.questionnaire);

			_buttonEventHandlers.SubscribeToHover(buttonRemoveLanguage, buttonAddLanguage,
			buttonRemoveEducation, buttonAddEducation, buttonApply);
			_radionButtonEventHandlers.SubscribeToHoverShadow(radioButtonDriverLicenseNo,
				radioButtonDriverLicenseYes, radioButtonSmokerNo, radioButtonSmokerYes,
				radioButtonDrinkAlcoholNo, radioButtonDrinkAlcoholYes);
		}

		private void SetFormFields(Questionnaire q)
		{
			comboBoxNationality.SelectedIndex = comboBoxNationality.FindString(q.Nationality);
			textBoxCity.Text = q.City;
			comboBoxBusinessTripOpportunity.SelectedIndex = q.ID_BusinessTripOpportunity - 1;

			numericUpDownExperience.Value = q.Experience;
			numericUpDownReadiness.Value = q.Readiness;
			SetRadioButtonState(radioButtonDriverLicenseYes,
				radioButtonDriverLicenseNo, q.DriverLicense);

			SetRadioButtonState(radioButtonSmokerYes,
				radioButtonSmokerNo, q.CandidateHealth.Smoker);
			SetRadioButtonState(radioButtonDrinkAlcoholYes,
				radioButtonDrinkAlcoholNo, q.CandidateHealth.DrinkAlcohol);
			richTextBoxChronicDiseases.Text = q.CandidateHealth.ChronicDiseases;

			comboBoxFamilyStatus.SelectedIndex = q.ID_FamilyStatus - 1;
			numericUpDownChildrenAmount.Value = q.ChildrenAmount;
			richTextBoxAdditionalInfo.Text = q.AdditionalInfo;

			SetLanguagesFields(q.Languages);
			SetEducationsFields(q.Educations);
		}
		private void SetRadioButtonState(Guna2CustomRadioButton radioButtonYes,
			Guna2CustomRadioButton radioButtonNo, bool value)
		{
			if (value)
			{
				radioButtonYes.Checked = true;
				radioButtonNo.Checked = false;
			}
			else
			{
				radioButtonYes.Checked = false;
				radioButtonNo.Checked = true;
			}
		}
		private void SetLanguagesFields(List<Language> languages)
		{
			for (int i = 0; i < languages.Count; i++)
			{
				if (i != 0)
					ButtonAddLanguage_Click(buttonAddLanguage, EventArgs.Empty);
				_languages[i].ComboBoxName.SelectedIndex =
					comboBoxLanguage.FindString(languages[i].Name);
				_languages[i].NUDLevel.Value = languages[i].Level;
			}
		}
		private void SetEducationsFields(List<Education> educations)
		{
			for (int i = 0; i < educations.Count; i++)
			{
				ButtonAddEducation_Click(buttonAddEducation, EventArgs.Empty);
				_educations[i].TextBoxNameInstitution.Text = educations[i].NameInstitution;
				_educations[i].TextBoxSpecialty.Text = educations[i].Specialty;
				_educations[i].NUD_YearAdmission.Value = educations[i].YearAdmission;
				_educations[i].DTP_DateEnd.Value = educations[i].DateEnd;
				_educations[i].CB_EducationDegree.SelectedIndex =
					educations[i].ID_EducationDegree - 1;
				_educations[i].CB_EducationForm.SelectedIndex =
					educations[i].ID_EducationForm - 1;
			}
		}
		private void SetComboBoxItems()
		{
			StaticDataFromDB.SetData();
			comboBoxFamilyStatus.Items.AddRange(StaticDataFromDB.FamilyStatuses);
			comboBoxBusinessTripOpportunity.Items.AddRange(StaticDataFromDB.BusinessTripOpportunities);
		}
		private void ResetEducationFields()
		{
			textBoxNameInstitution.Text = "";
			textBoxSpecialty.Text = "";
			numericUpDownYearAdmission.Value = _defaultYearAdmission;
			dateTimePickerDateEnd.Value = DateTime.Today;
			dateTimePickerDateEnd.MaxDate = DateTime.Today.AddYears(10);
			comboBoxEducationDegree.SelectedIndex = 1;
			comboBoxEducationForm.SelectedIndex = 0;
		}

		private void ButtonLanguageHelp_Click(object sender, EventArgs e)
		{
			CustomMessageBox.Show("Рівень мови - це Ваш особистий рівень знань певної мови, "
			+ "він може приймати значення від 1 до 10.", _account.Theme, "Інформація",
			CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
		}

		#region Add and remove language
		private void ButtonAddLanguage_Click(object sender, EventArgs e)
		{
			if (_languages.Count + 1 > MAX_LANGUAGE_COUNT)
				return;

			_languageCreator.CreateMainPanelNEW();

			_languageCreator.CreateLabel(labelLanguageNumber,
				(_languages.Count + 1).ToString());
			Label labelLang = _languageCreator.CreateLabel(labelLanguage);
			_languageCreator.CreateLabel(labelLevel);

			Guna2ComboBox comboBoxLang = _languageCreator.CreateComboBox(comboBoxLanguage,
				comboBoxLanguage.FindString(DEFAULT_LANGUAGE));
			NumericUpDown nudLevel = _languageCreator.CreateNumericUpDown(numericUpDownLevel);

			ManageComboBoxEvents(comboBoxLang, true);
			_languages.Add(new LanguageFormElements(_languageCreator.MainPanelNEW,
				labelLang, comboBoxLang, nudLevel));
			_languages[_languages.Count - 1].SetDefaultLabel(_account.Theme);
			_languageCreator.MainPanelNEW.Focus();
		}
		private void ButtonRemoveLanguage_Click(object sender, EventArgs e)
		{
			if (_languages.Count > 1)
			{
				int index = _languages.Count - 1;

				_languages[index].PanelMain.Dispose();
				_languages.RemoveAt(index);

				_languages[index - 1].PanelMain.Focus();
			}
		}
		#endregion

		#region Add and remove education
		private void ButtonAddEducation_Click(object sender, EventArgs e)
		{
			if (_educations.Count + 1 > MAX_EDUCATION_COUNT)
				return;
			else if (_educations.Count == 0)
			{
				_educations.Add(new EducationFormElements(panelEducation,
					labelNameInstitution, labelSpecialty, labelYearAdmission,
					labelDateEnd, textBoxNameInstitution, textBoxSpecialty,
					numericUpDownYearAdmission, dateTimePickerDateEnd,
					comboBoxEducationDegree, comboBoxEducationForm));

				_educations[0].SetDefaultLabels(_account.Theme);
				panelEducation.Visible = true;
			}
			else
				CreateEducation();
		}
		private void ButtonRemoveEducation_Click(object sender, EventArgs e)
		{
			if (_educations.Count > 1)
			{
				int index = _educations.Count - 1;

				_educations[index].PanelMain.Dispose();
				_educations.RemoveAt(index);

				if (_educations.Count > 0)
					_educations[index - 1].PanelMain.Focus();
			}
			else if (_educations.Count == 1)
			{
				_educations.RemoveAt(_educations.Count - 1);

				ResetEducationFields();
				panelEducation.Visible = false;
			}
		}
		private void CreateEducation()
		{
			_educationCreator.CreateMainPanelNEW();
			_educationCreator.CreateLabel(labelEducationNumber,
				(_educations.Count + 1).ToString());
			Label labelInstitution = _educationCreator.CreateLabel(labelNameInstitution,
				labelNameInstitution.Text);
			Label labelSpec = _educationCreator.CreateLabel(labelSpecialty, labelSpecialty.Text);
			Label labelAdmission = _educationCreator.CreateLabel(labelYearAdmission,
				labelYearAdmission.Text);
			Label labelEndDate = _educationCreator.CreateLabel(labelDateEnd, labelDateEnd.Text);
			_educationCreator.CreateLabel(labelEducationDegree, labelEducationDegree.Text);
			_educationCreator.CreateLabel(labelEducationForm, labelEducationForm.Text);

			Guna2TextBox textBoxInstitution = _educationCreator.
				CreateTextBox(textBoxNameInstitution);
			Guna2TextBox textBoxSpec = _educationCreator.CreateTextBox(textBoxSpecialty);

			NumericUpDown nudAdmission = _educationCreator.CreateNumericUpDown(numericUpDownYearAdmission);
			nudAdmission.Value = _defaultYearAdmission;

			Guna2ComboBox comboBoxDegree = _educationCreator.
				CreateComboBox(comboBoxEducationDegree, 1);
			Guna2ComboBox comboBoxForm = _educationCreator.
				CreateComboBox(comboBoxEducationForm);

			Guna2DateTimePicker dateEnd = _educationCreator.
				CreateDateTimePicker(dateTimePickerDateEnd, DateTime.Today);

			ManageComboBoxEvents(comboBoxDegree, true);
			ManageComboBoxEvents(comboBoxForm, true);
			_educations.Add(new EducationFormElements(_educationCreator.MainPanelNEW,
				labelInstitution, labelSpec, labelAdmission, labelEndDate, textBoxInstitution, textBoxSpec, nudAdmission,
				dateEnd, comboBoxDegree, comboBoxForm));
			_educations[_educations.Count - 1].SetDefaultLabels(_account.Theme);

			_educationCreator.MainPanelNEW.Focus();
		}
		#endregion

		#region Form Validation and submission
		private void ButtonApply_Click(object sender, EventArgs e)
		{
			SetDefaultLabels();

			if (CheckValidData())
			{
				FillQuestionnaireWithFormData();
				if (_formOpenForChange)
				{
					try
					{
						Client.ChangeQuestionnaire(_account.Login, _oldQuestionnaire,
							_account.candidate.questionnaire);
					}
					catch (SocketException)
					{
						CustomMessageBox.Show("Спроба підключитись до серверу " +
							"завершилась не вдало.\nСпробуйте, будь ласка, пізніше.",
							_account.Theme, "Помилка підключення",
							CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
					}
				}

				FormClosing -= QuestionnaireForm_FormClosing;
				Close();
			}
		}
		private void SetDefaultLabels()
		{
			ValidationFeedbackManager.ResetLabelsToDefault(_account.Theme,
				labelNationality, labelCity);

			for (int i = 0; i < _languages.Count; i++)
				_languages[i].SetDefaultLabel(_account.Theme);
			for (int i = 0; i < _educations.Count; i++)
				_educations[i].SetDefaultLabels(_account.Theme);
		}

		private void FillQuestionnaireWithFormData()
		{
			List<Language> languages = ReadLanguagesFromForm();
			List<Education> educations = ReadEducationsFromForm();

			_account.candidate.questionnaire =
				new Questionnaire(comboBoxNationality.SelectedItem.ToString(),
				textBoxCity.Text, (int)numericUpDownChildrenAmount.Value,
				(int)numericUpDownExperience.Value, radioButtonDriverLicenseYes.Checked,
				(int)numericUpDownReadiness.Value, richTextBoxAdditionalInfo.Text,
				new Health(richTextBoxChronicDiseases.Text, radioButtonSmokerYes.Checked,
				radioButtonDrinkAlcoholYes.Checked), comboBoxFamilyStatus.SelectedIndex + 1,
				comboBoxBusinessTripOpportunity.SelectedIndex + 1, languages, educations);
		}
		private List<Language> ReadLanguagesFromForm()
		{
			List<Language> languages = new List<Language>(MAX_LANGUAGE_COUNT);
			for (int i = 0; i < _languages.Count; i++)
				languages.Add(new Language(_languages[i].ComboBoxName.SelectedItem.ToString(), (int)_languages[i].NUDLevel.Value));

			return languages;
		}
		private List<Education> ReadEducationsFromForm()
		{
			List<Education> educations = new List<Education>(MAX_EDUCATION_COUNT);
			for (int i = 0; i < _educations.Count; i++)// Зчитуємо освіти з форми
				educations.Add(new Education(_educations[i].TextBoxNameInstitution.Text, _educations[i].TextBoxSpecialty.Text,
					(int)_educations[i].NUD_YearAdmission.Value, _educations[i].DTP_DateEnd.Value, _educations[i].CB_EducationDegree.SelectedIndex + 1,
					_educations[i].CB_EducationForm.SelectedIndex + 1));

			return educations;
		}

		private bool CheckValidData()
		{
			Validator validator = new Validator();
			validator.CheckSymbols(labelCity, textBoxCity, _account.Theme,
				ValidLanguage.UA, "’- ");
			validator.CheckMinLength(labelCity, textBoxCity, 2, _account.Theme);
			validator.CheckSymbols(labelChronicDiseases, richTextBoxChronicDiseases,
				_account.Theme, ValidLanguage.UA, "’- 0123456789");
			validator.CheckBannedChar(labelAdditionalInfo, richTextBoxAdditionalInfo.Text,
				Client.SEPARATOR, _account.Theme);

			bool isDataValid = validator.IsDataValid;
			CheckValidEducations(ref isDataValid);
			CheckUniqueLanguages(ref isDataValid);
			CheckUniqueEducations(ref isDataValid);

			return isDataValid;
		}
		private void CheckValidEducations(ref bool isDataValid)
		{
			for (int i = 0; i < _educations.Count; i++)
			{
				Validator validator = new Validator();
				validator.CheckSymbols(_educations[i].LabelNameInstitution,
					_educations[i].TextBoxNameInstitution,
					_account.Theme, ValidLanguage.UA, "’.\"-№ 0123456789");
				validator.CheckMinLength(_educations[i].LabelNameInstitution,
					_educations[i].TextBoxNameInstitution, 2, _account.Theme);

				validator.CheckSymbols(_educations[i].LabelSpecialty,
					_educations[i].TextBoxSpecialty,
					_account.Theme, ValidLanguage.UA, "’- ");
				validator.CheckMinLength(_educations[i].LabelSpecialty,
					_educations[i].TextBoxSpecialty, 2, _account.Theme);

				isDataValid = validator.IsDataValid;
				CheckEducationDates(_educations[i], ref isDataValid);
			}
		}
		private void CheckEducationDates(EducationFormElements education,
			ref bool isDataValid)
		{
			if (education.NUD_YearAdmission.Value > education.DTP_DateEnd.Value.Year)
			{
				if (isDataValid)
					education.NUD_YearAdmission.Focus();

				ValidationFeedbackManager.HighlightInvalidLabel(education.LabelYearAdmission,
					"Рік початку навчання не може бути більшим, ніж рік закінчення!",
					_account.Theme, ref isDataValid);
				ValidationFeedbackManager.HighlightInvalidLabel(education.LabelDateEnd);
			}
		}
		private void CheckUniqueLanguages(ref bool isDataValid)
		{
			for (int i = 0; i < _languages.Count; i++)
				for (int j = i + 1; j < _languages.Count; j++)
					if (_languages[i].ComboBoxName.SelectedIndex == _languages[j].ComboBoxName.SelectedIndex)
					{
						ValidationFeedbackManager.HighlightInvalidLabel(_languages[i].LabelName, "Список мов не може зберігати дві однакові мови.",
							_account.Theme, ref isDataValid);
						ValidationFeedbackManager.HighlightInvalidLabel(_languages[j].LabelName);
						break;
					}
		}
		private void CheckUniqueEducations(ref bool isDataValid)
		{
			for (int i = 0; i < _educations.Count; i++)
				for (int j = i + 1; j < _educations.Count; j++)
					if (_educations[i].Equals(_educations[j]))
					{
						ValidationFeedbackManager.HighlightInvalidLabel(_educations[i].LabelNameInstitution,
							"Список освіт не може зберігати дві однакові освіти.", _account.Theme, ref isDataValid);
						ValidationFeedbackManager.HighlightInvalidLabel(_educations[j].LabelNameInstitution);
						break;
					}
		}
		#endregion

		private void ManageComboBoxEvents(ComboBox comboBox, bool subscribe)
		{
			if (subscribe)
			{
				comboBox.DropDown += ComboBox_DropDown;
				comboBox.DropDownClosed += ComboBox_DropDownClosed;
			}
			else
			{
				comboBox.DropDown -= ComboBox_DropDown;
				comboBox.DropDownClosed -= ComboBox_DropDownClosed;
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

		#region Label focus event handlers
		private void LabelDriverLicenseNo_Click(object sender, EventArgs e)
			=> radioButtonDriverLicenseNo.Checked = true;
		private void LabelDriverLicenseYes_Click(object sender, EventArgs e)
			=> radioButtonDriverLicenseYes.Checked = true;

		private void LabelSmokerNo_Click(object sender, EventArgs e)
			=> radioButtonSmokerNo.Checked = true;
		private void LabelSmokerYes_Click(object sender, EventArgs e)
			=> radioButtonSmokerYes.Checked = true;

		private void LabelDrinkAlcoholNo_Click(object sender, EventArgs e)
			=> radioButtonDrinkAlcoholNo.Checked = true;
		private void LabelDrinkAlcoholYes_Click(object sender, EventArgs e)
			=> radioButtonDrinkAlcoholYes.Checked = true;
		#endregion

		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);
			panelMain.BackColor = BackColor;
			flpLanguages.BackColor = BackColor;
			flpEducations.BackColor = BackColor;
		}

		private void QuestionnaireForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = CustomMessageBox.Show("Якщо Ви вийдете, " +
				"то дані не будуть збережені.\nЧи дійсно Ви хочете вийти?",
				_account.Theme, "Вихід", CustomMessageBoxButtons.YesNo,
				CustomMessageBoxIcon.Warning);

			if (result != DialogResult.Yes)
				e.Cancel = true;
			else if (_account.candidate.questionnaire.City == null)
				_account.candidate.questionnaire = null;
		}
		private void QuestionnaireForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			DisposeLanguages();
			DisposeEducations();

			_buttonEventHandlers.UnsubscribeAll();
			_radionButtonEventHandlers.UnsubscribeAll();
		}
		private void DisposeLanguages()
		{
			foreach (LanguageFormElements language in _languages)
				ManageComboBoxEvents(language.ComboBoxName, false);

			_languageCreator.Dispose();
			_languages.Clear();
		}
		private void DisposeEducations()
		{
			foreach (EducationFormElements education in _educations)
			{
				ManageComboBoxEvents(education.CB_EducationDegree, false);
				ManageComboBoxEvents(education.CB_EducationForm, false);
			}

			_educationCreator.Dispose();
			_educations.Clear();
		}
	}
}