using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

using RecruitmentClient.Models;
using RecruitmentClient.Utilities.ClientUtilities;
using RecruitmentClient.Utilities.FormUtilities;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;
using SharedModels.Models;
using System.Linq;

namespace RecruitmentClient.Forms
{
	internal partial class QuestionnaireForm : BaseForm, IThemeChange
	{
		private const int MAX_LANGUAGE_COUNT = 10;
		private const int MAX_EDUCATION_COUNT = 5;
		private const string DEFAULT_NATIONALITY = "Україна";
		private const string DEFAULT_LANGUAGE = "Українська";

		private readonly int _defaultYearAdmission = DateTime.Today.Year - 4;

		private readonly Account _account;
		private readonly Questionnaire _oldQuestionnaire = null;
		private readonly bool _formOpenForChange = false;
		private readonly RadioButtonEventHandlers _radionButtonEventHandlers =
			new RadioButtonEventHandlers();

		private readonly List<LanguageFormElements> _languages =
			new List<LanguageFormElements>(MAX_LANGUAGE_COUNT);
		private readonly ControlCreator _languageCreator;
		private readonly List<EducationFormElements> _educations =
			new List<EducationFormElements>(MAX_EDUCATION_COUNT);
		private readonly ControlCreator _educationCreator;

		internal QuestionnaireForm(Account account, StartForm startForm)
		{
			customTitleBar = new CustomTitleBar(this, "Анкета",
				Properties.Resources.questionnaire, minimizeBox: false);
			IsResizable = true;
			InitializeComponent();

			_account = account;
			if (startForm == null)
			{
				_oldQuestionnaire = new Questionnaire(_account.candidate.Questionnaire);
				_formOpenForChange = true;
			}

			_languages.Add(new LanguageFormElements(panelLanguage, labelLanguage,
				comboBoxLanguage, labelLevel, numericUpDownLevel));
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

			if (_account.candidate.Questionnaire == null)
			{
				_account.candidate.Questionnaire = new Questionnaire();
				comboBoxNationality.SelectedIndex =
					comboBoxNationality.FindString(DEFAULT_NATIONALITY);
				comboBoxLanguage.SelectedIndex =
					comboBoxLanguage.FindString(DEFAULT_LANGUAGE);
				ButtonAddEducation_Click(new Object(), EventArgs.Empty);
			}
			else
				SetFormFields(_account.candidate.Questionnaire);

			_radionButtonEventHandlers.SubscribeToHoverShadow(radioButtonDriverLicenseNo,
				radioButtonDriverLicenseYes, radioButtonSmokerNo, radioButtonSmokerYes,
				radioButtonDrinkAlcoholNo, radioButtonDrinkAlcoholYes);
		}

		private void SetFormFields(Questionnaire q)
		{
			comboBoxNationality.SelectedIndex = comboBoxNationality.FindString(q.Nationality);
			textBoxCity.Text = q.City;
			comboBoxBusinessTripOpportunity.SelectedIndex = q.IdBusinessTripOpportunity - 1;

			numericUpDownExperience.Value = q.Experience;
			numericUpDownReadiness.Value = q.Readiness;
			SetRadioButtonState(radioButtonDriverLicenseYes,
				radioButtonDriverLicenseNo, q.DriverLicense);

			SetRadioButtonState(radioButtonSmokerYes,
				radioButtonSmokerNo, q.Health.Smoker);
			SetRadioButtonState(radioButtonDrinkAlcoholYes,
				radioButtonDrinkAlcoholNo, q.Health.DrinkAlcohol);
			richTextBoxChronicDiseases.Text = q.Health.ChronicDiseases;

			comboBoxFamilyStatus.SelectedIndex = q.IdFamilyStatus - 1;
			numericUpDownChildrenAmount.Value = q.ChildrenAmount;
			richTextBoxAdditionalInfo.Text = q.AdditionalInfo;

			SetLanguagesFields(q.Languages.ToArray());
			SetEducationsFields(q.Educations.ToArray());
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
		private void SetLanguagesFields(Language[] languages)
		{
			for (int i = 0; i < languages.Length; i++)
			{
				if (i != 0)
					ButtonAddLanguage_Click(buttonAddLanguage, EventArgs.Empty);
				_languages[i].ComboBoxName.SelectedIndex =
					comboBoxLanguage.FindString(languages[i].Name);
				_languages[i].NUDLevel.Value = languages[i].Level;
			}
		}
		private void SetEducationsFields(Education[] educations)
		{
			for (int i = 0; i < educations.Length; i++)
			{
				ButtonAddEducation_Click(buttonAddEducation, EventArgs.Empty);
				_educations[i].TextBoxNameInstitution.Text = educations[i].NameInstitution;
				_educations[i].TextBoxSpecialty.Text = educations[i].Specialty;
				_educations[i].NUD_YearAdmission.Value = educations[i].YearAdmission;
				_educations[i].DTP_DateEnd.Value = educations[i].DateEnd;
				_educations[i].CB_EducationDegree.SelectedIndex =
					educations[i].IdEducationDegree - 1;
				_educations[i].CB_EducationForm.SelectedIndex =
					educations[i].IdEducationForm - 1;
			}
		}
		private void SetComboBoxItems()
		{
			StaticDataFromDB.SetData();
			comboBoxFamilyStatus.Items.AddRange(StaticDataFromDB.FamilyStatuses);
			comboBoxBusinessTripOpportunity.Items.AddRange(
				StaticDataFromDB.BusinessTripOpportunities);
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

			_languageCreator.CreateMainPanel();

			_languageCreator.CreateLabel(labelLanguageNumber,
				(_languages.Count + 1).ToString());
			Label labelLang = _languageCreator.CreateLabel(labelLanguage);
			Label labelLvl = _languageCreator.CreateLabel(labelLevel);

			Guna2ComboBox comboBoxLang = _languageCreator.CreateComboBox(comboBoxLanguage,
				comboBoxLanguage.FindString(DEFAULT_LANGUAGE));
			NumericUpDown nudLevel = _languageCreator.CreateNumericUpDown(numericUpDownLevel);

			ManageComboBoxEvents(comboBoxLang, true);
			var language = new LanguageFormElements(_languageCreator.CurrentMainPanel,
				labelLang, comboBoxLang, labelLvl, nudLevel);
			_languages.Add(language);
			ManageLanguageFocusEvents(language, true);
			_languages[_languages.Count - 1].SetDefaultLabel(_account.Theme);
			_languageCreator.CurrentMainPanel.Focus();
		}
		private void ButtonRemoveLanguage_Click(object sender, EventArgs e)
		{
			if (_languages.Count > 1)
			{
				int index = _languages.Count - 1;

				ManageComboBoxEvents(_languages[index].ComboBoxName, false);
				ManageLanguageFocusEvents(_languages[index], false);
				_languages[index].PanelMain.Dispose();
				_languages.RemoveAt(index);

				_languages[index - 1].PanelMain.Focus();
			}
		}

		private void ManageLanguageFocusEvents(LanguageFormElements language, bool subscribe)
		{
			void LabelName_Click(object sender, EventArgs e)
				=> language.ComboBoxName.DroppedDown = true;
			void LabelLevel_Click(object sender, EventArgs e)
				=> language.NUDLevel.Focus();

			if (subscribe)
			{
				language.LabelName.Click += LabelName_Click;
				language.LabelLevel.Click += LabelLevel_Click;
			}
			else
			{
				language.LabelName.Click -= LabelName_Click;
				language.LabelLevel.Click -= LabelLevel_Click;
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
					labelNameInstitution, labelSpecialty, labelEducationDegree,
					labelYearAdmission, labelDateEnd,
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

				ManageComboBoxEvents(_educations[index].CB_EducationDegree, false);
				ManageComboBoxEvents(_educations[index].CB_EducationForm, false);
				ManageEducationFocusEvents(_educations[index], false);
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
			_educationCreator.CreateMainPanel();
			_educationCreator.CreateLabel(labelEducationNumber,
				(_educations.Count + 1).ToString());
			Label labelInstitution = _educationCreator.CreateLabel(labelNameInstitution,
				labelNameInstitution.Text);
			Label labelSpec = _educationCreator.CreateLabel(labelSpecialty,
				labelSpecialty.Text);
			Label labelAdmission = _educationCreator.CreateLabel(labelYearAdmission,
				labelYearAdmission.Text);
			Label labelEndDate = _educationCreator.CreateLabel(labelDateEnd,
				labelDateEnd.Text);
			Label labelDegree = _educationCreator.CreateLabel(labelEducationDegree, labelEducationDegree.Text);
			Label labelForm = _educationCreator.CreateLabel(labelEducationForm, labelEducationForm.Text);

			Guna2TextBox textBoxInstitution = _educationCreator.
				CreateTextBox(textBoxNameInstitution);
			Guna2TextBox textBoxSpec = _educationCreator.CreateTextBox(textBoxSpecialty);
			Guna2ComboBox comboBoxDegree = _educationCreator.
				CreateComboBox(comboBoxEducationDegree, 1);

			NumericUpDown nudAdmission = _educationCreator.CreateNumericUpDown(
				numericUpDownYearAdmission);
			nudAdmission.Value = _defaultYearAdmission;
			Guna2DateTimePicker dateEnd = _educationCreator.
				CreateDateTimePicker(dateTimePickerDateEnd, DateTime.Today);
			Guna2ComboBox comboBoxForm = _educationCreator.
				CreateComboBox(comboBoxEducationForm);


			ManageComboBoxEvents(comboBoxDegree, true);
			ManageComboBoxEvents(comboBoxForm, true);
			EducationFormElements education = new EducationFormElements(
				_educationCreator.CurrentMainPanel, labelInstitution, labelSpec,
				labelDegree, labelAdmission, labelEndDate, labelForm,
				textBoxInstitution, textBoxSpec, nudAdmission,
				dateEnd, comboBoxDegree, comboBoxForm);
			_educations.Add(education);
			ManageEducationFocusEvents(education, true);
			_educations[_educations.Count - 1].SetDefaultLabels(_account.Theme);

			_educationCreator.CurrentMainPanel.Focus();
		}
		private void ManageEducationFocusEvents(EducationFormElements education, bool subscribe)
		{
			void LabelNameInstitution_Click(object sender, EventArgs e)
				=> education.TextBoxNameInstitution.Focus();
			void LabelSpecialty_Click(object sender, EventArgs e)
				=> education.TextBoxSpecialty.Focus();
			void LabelEducationDegree_Click(object sender, EventArgs e)
				=> education.CB_EducationDegree.DroppedDown = true;
			void LabelYearAdmission_Click(object sender, EventArgs e)
				=> education.NUD_YearAdmission.Focus();
			void LabelDateEnd_Click(object sender, EventArgs e)
				=> education.DTP_DateEnd.PerformClick();
			void LabelEducationForm_Click(object sender, EventArgs e)
				=> education.CB_EducationForm.DroppedDown = true;


			if (subscribe)
			{
				education.LabelNameInstitution.Click += LabelNameInstitution_Click;
				education.LabelSpecialty.Click += LabelSpecialty_Click;
				education.LabelEducationDegree.Click += LabelEducationDegree_Click;
				education.LabelYearAdmission.Click += LabelYearAdmission_Click;
				education.LabelDateEnd.Click += LabelDateEnd_Click;
				education.LabelEducationForm.Click += LabelEducationForm_Click;
				education.TextBoxNameInstitution.KeyDown += TextBox_KeyDown;
				education.TextBoxSpecialty.KeyDown += TextBox_KeyDown;
			}
			else
			{
				education.LabelNameInstitution.Click -= LabelNameInstitution_Click;
				education.LabelSpecialty.Click -= LabelSpecialty_Click;
				education.LabelEducationDegree.Click -= LabelEducationDegree_Click;
				education.LabelYearAdmission.Click -= LabelYearAdmission_Click;
				education.LabelDateEnd.Click -= LabelDateEnd_Click;
				education.LabelEducationForm.Click -= LabelEducationForm_Click;
				education.TextBoxNameInstitution.KeyDown -= TextBox_KeyDown;
				education.TextBoxSpecialty.KeyDown -= TextBox_KeyDown;
			}
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
							_account.candidate.Questionnaire);
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

			_account.candidate.Questionnaire =
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
				languages.Add(new Language(_languages[i].ComboBoxName.SelectedItem.ToString(),
					(int)_languages[i].NUDLevel.Value));

			return languages;
		}
		private List<Education> ReadEducationsFromForm()
		{
			List<Education> educations = new List<Education>(MAX_EDUCATION_COUNT);
			for (int i = 0; i < _educations.Count; i++)
				educations.Add(new Education(_educations[i].TextBoxNameInstitution.Text,
					_educations[i].TextBoxSpecialty.Text,
					(int)_educations[i].NUD_YearAdmission.Value,
					_educations[i].DTP_DateEnd.Value,
					_educations[i].CB_EducationDegree.SelectedIndex + 1,
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

				isDataValid = isDataValid && validator.IsDataValid;
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
					if (_languages[i].ComboBoxName.SelectedIndex
						== _languages[j].ComboBoxName.SelectedIndex)
					{
						ValidationFeedbackManager.HighlightInvalidLabel(
							_languages[i].LabelName, "Список мов не може " +
							"зберігати дві однакові мови.",
							_account.Theme, ref isDataValid);
						ValidationFeedbackManager.HighlightInvalidLabel(
							_languages[j].LabelName);
						break;
					}
		}
		private void CheckUniqueEducations(ref bool isDataValid)
		{
			for (int i = 0; i < _educations.Count; i++)
				for (int j = i + 1; j < _educations.Count; j++)
					if (_educations[i].Equals(_educations[j]))
					{
						ValidationFeedbackManager.HighlightInvalidLabel(
							_educations[i].LabelNameInstitution,
							"Список освіт не може зберігати дві однакові освіти.",
							_account.Theme, ref isDataValid);
						ValidationFeedbackManager.HighlightInvalidLabel(
							_educations[j].LabelNameInstitution);
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
		private void LabelNationality_Click(object sender, EventArgs e)
			=> comboBoxNationality.DroppedDown = true;
		private void LabelCity_Click(object sender, EventArgs e)
			=> textBoxCity.Focus();
		private void LabelBusinessTripOpportunity_Click(object sender, EventArgs e)
			=> comboBoxBusinessTripOpportunity.DroppedDown = true;
		private void LabelExperience_Click(object sender, EventArgs e)
			=> numericUpDownExperience.Focus();
		private void LabelReadiness_Click(object sender, EventArgs e)
			=> numericUpDownReadiness.Focus();
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
		private void LabelChronicDiseases_Click(object sender, EventArgs e)
			=> richTextBoxChronicDiseases.Focus();
		private void LabelFamilyStatus_Click(object sender, EventArgs e)
			=> comboBoxFamilyStatus.DroppedDown = true;
		private void LabelChildrenAmount_Click(object sender, EventArgs e)
			=> numericUpDownChildrenAmount.Focus();

		private void LabelLanguage_Click(object sender, EventArgs e)
			=> comboBoxLanguage.DroppedDown = true;
		private void LabelLevel_Click(object sender, EventArgs e)
			=> numericUpDownLevel.Focus();
		private void LabelNameInstitution_Click(object sender, EventArgs e)
			=> textBoxNameInstitution.Focus();
		private void LabelSpecialty_Click(object sender, EventArgs e)
			=> textBoxSpecialty.Focus();
		private void LabelEducationDegree_Click(object sender, EventArgs e)
			=> comboBoxEducationDegree.DroppedDown = true;
		private void LabelYearAdmission_Click(object sender, EventArgs e)
			=> numericUpDownYearAdmission.Focus();
		private void LabelDateEnd_Click(object sender, EventArgs e)
			=> dateTimePickerDateEnd.PerformClick();
		private void LabelEducationForm_Click(object sender, EventArgs e)
			=> comboBoxEducationForm.DroppedDown = true;
		private void LabelAdditionalInfo_Click(object sender, EventArgs e)
			=> richTextBoxAdditionalInfo.Focus();
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

		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);
			panelMain.BackColor = BackColor;
			flpLanguages.BackColor = BackColor;
			flpEducations.BackColor = BackColor;
			panelDown.BackColor = BackColor;
		}

		private void QuestionnaireForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = CustomMessageBox.Show("Якщо Ви вийдете, " +
				"то дані не будуть збережені.\nЧи дійсно Ви хочете вийти?",
				_account.Theme, "Вихід", CustomMessageBoxButtons.YesNo,
				CustomMessageBoxIcon.Warning);

			if (result != DialogResult.Yes)
				e.Cancel = true;
			else if (_account.candidate.Questionnaire.City == null)
				_account.candidate.Questionnaire = null;
		}
		private void QuestionnaireForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			DisposeLanguages();
			DisposeEducations();

			_radionButtonEventHandlers.UnsubscribeAll();
		}
		private void DisposeLanguages()
		{
			foreach (LanguageFormElements language in _languages)
			{
				ManageComboBoxEvents(language.ComboBoxName, false);
				ManageLanguageFocusEvents(language, false);
			}

			_languageCreator.Dispose();
			_languages.Clear();
		}
		private void DisposeEducations()
		{
			foreach (EducationFormElements education in _educations)
			{
				ManageComboBoxEvents(education.CB_EducationDegree, false);
				ManageComboBoxEvents(education.CB_EducationForm, false);
				ManageEducationFocusEvents(education, false);
			}

			_educationCreator.Dispose();
			_educations.Clear();
		}
	}
}