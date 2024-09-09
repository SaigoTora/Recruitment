using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using RecruitmentLibrary.PersonInfo;
using RecruitmentLibrary.FormUtilities;
using RecruitmentUser.ClientUtilities;
using RecruitmentUser.FormUtilities;

namespace RecruitmentUser.Forms
{
	internal partial class QuestionnaireForm : Form, IThemeChange
	{// Форма запису анкети
		private const int MAX_LANGUAGE_COUNT = 10;// Максимальна кількість мов та освіт
		private const int MAX_EDUCATION_COUNT = 5;
		private const string DEFAULT_NATIONALITY = "Україна";// Громадянство та мова за замовчуванням
		private const string DEFAULT_LANGUAGE = "Українська";

		// Рік вступу, який буде показано за замовчуванням
		private readonly int yearAdmissionValue = DateTime.Today.Year - 4;

		// Елементи форми мов та освіт
		private readonly List<LanguageFormElements> languages = new List<LanguageFormElements>(MAX_LANGUAGE_COUNT);
		private readonly List<EducationFormElements> educations = new List<EducationFormElements>(MAX_EDUCATION_COUNT);
		private readonly ClientAccount account;// Обліковий запис
		private readonly Questionnaire oldQuestionnaire = null;
		private readonly bool formOpenForChange = false;
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		internal QuestionnaireForm(ClientAccount a, StartForm startForm)
		{// Конструктор
			InitializeComponent();

			account = a;// Передаємо посилання на акаунт
			SetTheme(account.Theme);
			if (startForm == null)// Якщо форма відкрита для змін даних
			{
				oldQuestionnaire = new Questionnaire(account.candidate.questionnaire);
				formOpenForChange = true;
			}

			// Зчитуємо дані з БД та встановлюємо їх у Combobox-и
			StaticDataFromDB.SetData();
			comboBoxFamilyStatus.Items.AddRange(StaticDataFromDB.FamilyStatuses);
			comboBoxBusinessTripOpportunity.Items.AddRange(StaticDataFromDB.BusinessTripOpportunities);

			// Вибираємо початкові значення
			comboBoxFamilyStatus.SelectedIndex = 1;
			comboBoxBusinessTripOpportunity.SelectedIndex = 1;
			numericUpDownYearAdmission.Maximum = DateTime.Today.Year + 1;// Максимальний рік вступу може бути наступний рік
			SetDefaultValuesEducation();

			// Додаємо перші елементи мови
			languages.Add(new LanguageFormElements(panelLanguage, labelLanguage, comboBoxLanguage, numericUpDownLevel));

			if (a.candidate.questionnaire == null)
			{// Якщо анкета відкрита для створення
				a.candidate.questionnaire = new Questionnaire();
				comboBoxNationality.SelectedIndex = comboBoxNationality.FindString(DEFAULT_NATIONALITY);
				comboBoxLanguage.SelectedIndex = comboBoxLanguage.FindString(DEFAULT_LANGUAGE);
				ButtonAddEducation_Click(new Object(), EventArgs.Empty);
			}
			else// Якщо вже була заповнена анкета
				SetFormValues(a.candidate.questionnaire);
		}
		private void QuestionnaireForm_Load(object sender, EventArgs e)
		{// Обробник події завантаження форми
			Icon = Properties.Resources.questionnaire;
			comboBoxNationality.Focus();
			// Максимальна дата закінчення навчання
			dateTimePickerDateEnd.MaxDate = new DateTime(DateTime.Today.Year + 10, DateTime.Today.Month, DateTime.Today.Day);

			buttonEventHandlers.SubscribeToHover(buttonRemoveLanguage, buttonAddLanguage,
				buttonRemoveEducation, buttonAddEducation, buttonApply);
		}

		// Методи встановлення значень форми
		private void SetDefaultValuesEducation()
		{// Метод записує початкові значення для елементів освіти
			textBoxNameInstitution.Text = "";
			textBoxSpecialty.Text = "";
			numericUpDownYearAdmission.Value = yearAdmissionValue;
			dateTimePickerDateEnd.Value = DateTime.Today;
			comboBoxEducationDegree.SelectedIndex = 1;
			comboBoxEducationForm.SelectedIndex = 0;
		}
		private void SetFormValues(Questionnaire q)
		{// Метод записує дані з класу Questionnaire в форму
			comboBoxNationality.SelectedIndex = comboBoxNationality.FindString(q.Nationality);

			textBoxCity.Text = q.City;
			numericUpDownChildrenAmount.Value = q.ChildrenAmount;
			numericUpDownExperience.Value = q.Experience;
			if (q.DriverLicense) checkBoxDriverLicenseYes.Checked = true;
			numericUpDownReadiness.Value = q.Readiness;
			richTextBoxAdditionalInfo.Text = q.AdditionalInfo;
			richTextBoxChronicDiseases.Text = q.CandidateHealth.ChronicDiseases;
			if (q.CandidateHealth.Smoker) checkBoxSmokerYes.Checked = true;
			if (q.CandidateHealth.DrinkAlcohol) checkBoxDrinkAlcoholYes.Checked = true;
			comboBoxFamilyStatus.SelectedIndex = q.ID_FamilyStatus - 1;
			comboBoxBusinessTripOpportunity.SelectedIndex = q.ID_BusinessTripOpportunity - 1;

			for (int i = 0; i < q.Languages.Count; i++)
			{// Записуємо мови
				if (i != 0)
					ButtonAddLanguage_Click(buttonAddLanguage, EventArgs.Empty);
				languages[i].ComboBoxName.SelectedIndex = comboBoxLanguage.FindString(q.Languages[i].Name);
				languages[i].NUD_Level.Value = q.Languages[i].Level;
			}

			for (int i = 0; i < q.Educations.Count; i++)
			{// Записуємо освіти
				ButtonAddEducation_Click(buttonAddEducation, EventArgs.Empty);
				educations[i].TextBoxNameInstitution.Text = q.Educations[i].NameInstitution;
				educations[i].TextBoxSpecialty.Text = q.Educations[i].Specialty;
				educations[i].NUD_YearAdmission.Value = q.Educations[i].YearAdmission;
				educations[i].DTP_DateEnd.Value = q.Educations[i].DateEnd;
				educations[i].CB_EducationDegree.SelectedIndex = q.Educations[i].ID_EducationDegree - 1;
				educations[i].CB_EducationForm.SelectedIndex = q.Educations[i].ID_EducationForm - 1;
			}
		}
		private void SetDefaultLabels()
		{// Метод повертає всім label-ам початкові значення
			Validator.SetDefaultLabels(account.Theme, labelNationality, labelCity);
			// Мови
			for (int i = 0; i < languages.Count; i++)
				languages[i].SetDefaultLabel(account.Theme);
			// Освіти
			for (int i = 0; i < educations.Count; i++)
				educations[i].SetDefaultLabels(account.Theme);
		}

		// Кнопки для мов та освіт
		private void ButtonLanguageHelp_Click(object sender, EventArgs e)
		{// Виведення додаткової інформації для користувача
			MessageBox.Show("Рівень мови - це Ваш особистий рівень знань певної мови, він може приймати значення від 1 до 10.",
				"Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		private void ButtonAddLanguage_Click(object sender, EventArgs e)
		{// Додавання мови
			if (languages.Count + 1 > MAX_LANGUAGE_COUNT)// Не може бути більше ніж максимум мов
				return;

			Creator creator = new Creator(panelLanguage, flpLanguages, languages.Count + 1);

			// Створюємо об’єкти типу Label
			creator.CreateLabel(labelLanguageNumber, (languages.Count + 1).ToString());
			Label label = creator.CreateLabel(labelLanguage);
			creator.CreateLabel(labelLevel);

			// Створюємо об’єкти типу TextBox та NumericUpDown
			ComboBox comboBox = creator.CreateComboBox(comboBoxLanguage, comboBoxLanguage.FindString(DEFAULT_LANGUAGE));
			NumericUpDown nud = creator.CreateNumericUpDown(numericUpDownLevel);

			// Додаємо елементи в список
			languages.Add(new LanguageFormElements(creator.MainPanel, label, comboBox, nud));
			languages[languages.Count - 1].SetDefaultLabel(account.Theme);
			creator.MainPanel.Focus();
		}
		private void ButtonRemoveLanguage_Click(object sender, EventArgs e)
		{// Видалення мови
			if (languages.Count > 1)
			{// Якщо мов більше, ніж одна
				int index = languages.Count - 1;

				languages[index].PanelMain.Dispose();// Видаляємо з форми
				languages.RemoveAt(index);// Видаляємо зі списку

				languages[index - 1].PanelMain.Focus();
			}
		}
		private void ButtonAddEducation_Click(object sender, EventArgs e)
		{// Додавання освіти
			if (educations.Count + 1 > MAX_EDUCATION_COUNT)// Не може бути більше ніж максимум освіт
				return;
			else if (educations.Count == 0)
			{// Якщо додаємо першу освіту
			 // Додаємо елементи
				educations.Add(new EducationFormElements(panelEducation, labelNameInstitution,
					labelSpecialty, labelYearAdmission, labelDateEnd, textBoxNameInstitution,
					textBoxSpecialty, numericUpDownYearAdmission, dateTimePickerDateEnd,
					comboBoxEducationDegree, comboBoxEducationForm));

				// Встановлюємо значення label-ів за замовчуванням
				educations[0].SetDefaultLabels(account.Theme);
				panelEducation.Visible = true;// Показуємо першу панель
			}
			else
				CreateEducation();// Створюємо освіту
		}
		private void ButtonRemoveEducation_Click(object sender, EventArgs e)
		{// Видалення освіти
			if (educations.Count > 1)
			{// Якщо освіт більше, ніж одна
				int index = educations.Count - 1;

				educations[index].PanelMain.Dispose();// Видаляємо з форми
				educations.RemoveAt(index);// Видаляємо зі списку

				if (educations.Count > 0)
					educations[index - 1].PanelMain.Focus();
			}
			else if (educations.Count == 1)
			{// Якщо освіта одна
				educations.RemoveAt(educations.Count - 1);// Видаляємо зі списку

				SetDefaultValuesEducation();
				panelEducation.Visible = false;
			}
		}
		private void CreateEducation()
		{// Метод, який створює елементи форми освіти
			Creator creator = new Creator(panelEducation, flpEducations as Control, educations.Count + 1);

			creator.CreateLabel(labelEducationNumber, (educations.Count + 1).ToString());// Створюємо об’єкти label
			Label label1 = creator.CreateLabel(labelNameInstitution, labelNameInstitution.Text);
			Label label2 = creator.CreateLabel(labelSpecialty, labelSpecialty.Text);
			Label label3 = creator.CreateLabel(labelYearAdmission, labelYearAdmission.Text);
			Label label4 = creator.CreateLabel(labelDateEnd, labelDateEnd.Text);
			creator.CreateLabel(labelEducationDegree, labelEducationDegree.Text);
			creator.CreateLabel(labelEducationForm, labelEducationForm.Text);

			TextBox textBox1 = creator.CreateTextBox(textBoxNameInstitution);// Створюємо об’єкти типу TextBox
			TextBox textBox2 = creator.CreateTextBox(textBoxSpecialty);

			NumericUpDown nud = creator.CreateNumericUpDown(numericUpDownYearAdmission);// Створюємо об’єкт типу NumericUpDown
			nud.Value = yearAdmissionValue;

			ComboBox comboBox1 = creator.CreateComboBox(comboBoxEducationDegree, 1);// Створюємо об’єкти типу ComboBox
			ComboBox comboBox2 = creator.CreateComboBox(comboBoxEducationForm);

			DateTimePicker date = creator.CreateDateTimePicker(dateTimePickerDateEnd);

			// Додаємо елементи
			educations.Add(new EducationFormElements(creator.MainPanel, label1, label2, label3, label4,
				textBox1, textBox2, nud, date, comboBox1, comboBox2));
			educations[educations.Count - 1].SetDefaultLabels(account.Theme);

			creator.MainPanel.Focus();
		}

		private bool CheckValidData()
		{// Метод перевіряє та показує які дані були введені не вірно
			bool isDataOk = true;

			// Місто або село проживання
			Validator.CheckSymbols(labelCity, textBoxCity, ref isDataOk, ValidLanguage.UA, "’- ");
			Validator.CheckMinLength(labelCity, textBoxCity, 2, ref isDataOk);
			// Хронічні захворювання
			Validator.CheckSymbols(labelChronicDiseases, richTextBoxChronicDiseases, ref isDataOk, ValidLanguage.UA, "’- 0123456789");

			CheckValidEducations(ref isDataOk);
			Validator.CheckBannedChar(labelAdditionalInfo, richTextBoxAdditionalInfo.Text, Client.SEPARATOR, ref isDataOk);

			// Унікальність мов
			for (int i = 0; i < languages.Count; i++)
				for (int j = i + 1; j < languages.Count; j++)
					if (languages[i].ComboBoxName.SelectedIndex == languages[j].ComboBoxName.SelectedIndex)
					{
						Validator.ShowWrongLabel(languages[i].LabelName, "Список мов не може зберігати дві однакові мови.", ref isDataOk);
						Validator.ShowWrongLabel(languages[j].LabelName);
						break;
					}

			// Унікальність освіт
			for (int i = 0; i < educations.Count; i++)
				for (int j = i + 1; j < educations.Count; j++)
					if (educations[i].Equals(educations[j]))
					{
						Validator.ShowWrongLabel(educations[i].LabelNameInstitution, "Список освіт не може зберігати дві однакові освіти.", ref isDataOk);
						Validator.ShowWrongLabel(educations[j].LabelNameInstitution);
						break;
					}

			return isDataOk;
		}
		private void CheckValidEducations(ref bool isDataOk)
		{// Метод перевіряє та показує які освіти були введені не вірно
			for (int i = 0; i < educations.Count; i++)
			{// Назви закладів, спеціальності та перевірка дат
				Validator.CheckSymbols(educations[i].LabelNameInstitution, educations[i].TextBoxNameInstitution, ref isDataOk,
					ValidLanguage.UA, "’.\"-№ 0123456789");
				Validator.CheckMinLength(educations[i].LabelNameInstitution, educations[i].TextBoxNameInstitution, 2, ref isDataOk);

				Validator.CheckSymbols(educations[i].LabelSpecialty, educations[i].TextBoxSpecialty, ref isDataOk,
					ValidLanguage.UA, "’- ");
				Validator.CheckMinLength(educations[i].LabelSpecialty, educations[i].TextBoxSpecialty, 2, ref isDataOk);

				if (educations[i].NUD_YearAdmission.Value > educations[i].DTP_DateEnd.Value.Year)
				{// Перевірка дати вступу та дати закінчення навчання
					if (isDataOk)
						educations[i].NUD_YearAdmission.Focus();

					Validator.ShowWrongLabel(educations[i].LabelYearAdmission, "Рік початку навчання не може бути більшим, ніж рік закінчення!", ref isDataOk);
					Validator.ShowWrongLabel(educations[i].LabelDateEnd);
				}
			}
		}
		private void AssignQuestionnaire()
		{// Метод встановлює значення анкети
		 // Мови
			List<Language> listL = new List<Language>(MAX_LANGUAGE_COUNT);
			for (int i = 0; i < languages.Count; i++)// Зчитуємо мови з форми
				listL.Add(new Language(languages[i].ComboBoxName.SelectedItem.ToString(), (int)languages[i].NUD_Level.Value));

			// Освіти
			List<Education> listE = new List<Education>(MAX_EDUCATION_COUNT);
			for (int i = 0; i < educations.Count; i++)// Зчитуємо освіти з форми
				listE.Add(new Education(educations[i].TextBoxNameInstitution.Text, educations[i].TextBoxSpecialty.Text,
					(int)educations[i].NUD_YearAdmission.Value, educations[i].DTP_DateEnd.Value, educations[i].CB_EducationDegree.SelectedIndex + 1,
					educations[i].CB_EducationForm.SelectedIndex + 1));

			// Створюємо анкету
			account.candidate.questionnaire = new Questionnaire(comboBoxNationality.SelectedItem.ToString(),
				textBoxCity.Text, (int)numericUpDownChildrenAmount.Value, (int)numericUpDownExperience.Value,
				checkBoxDriverLicenseYes.Checked, (int)numericUpDownReadiness.Value, richTextBoxAdditionalInfo.Text,
				new Health(richTextBoxChronicDiseases.Text, checkBoxSmokerYes.Checked, checkBoxDrinkAlcoholYes.Checked),
				comboBoxFamilyStatus.SelectedIndex + 1, comboBoxBusinessTripOpportunity.SelectedIndex + 1, listL, listE);
		}
		private void CheckBoxChanger(CheckBox checkBox, CheckBox checkBoxNo, CheckBox checkBoxYes)
		{// Метод для зміни стану CheckBox-ів(Так/Ні)
			if (checkBox == checkBoxNo)// Якщо змінили чекбокс "Ні"
			{
				if (checkBox.Checked) checkBoxYes.Checked = false;
				else checkBoxYes.Checked = true;
			}
			else if (checkBox == checkBoxYes)// Якщо змінили чекбокс "Так"
			{
				if (checkBox.Checked) checkBoxNo.Checked = false;
				else checkBoxNo.Checked = true;
			}
		}

		// Інші обробники подій
		private void CheckBoxDriverLicense_CheckedChanged(object sender, EventArgs e)
		{// Обробник події: чи є посвідчення водія?
			if (sender is CheckBox checkBox)
				CheckBoxChanger(checkBox, checkBoxDriverLicenseNo, checkBoxDriverLicenseYes);
		}
		private void CheckBoxSmoker_CheckedChanged(object sender, EventArgs e)
		{// Обробник події: чи курець?
			if (sender is CheckBox checkBox)
				CheckBoxChanger(checkBox, checkBoxSmokerNo, checkBoxSmokerYes);
		}
		private void CheckBoxDrinkAlcohol_CheckedChanged(object sender, EventArgs e)
		{// Обробник події: чи вживає алкогольні напої?
			if (sender is CheckBox checkBox)
				CheckBoxChanger(checkBox, checkBoxDrinkAlcoholNo, checkBoxDrinkAlcoholYes);
		}
		private void ButtonApply_Click(object sender, EventArgs e)
		{// Обробник події: підтвердження анкети
			SetDefaultLabels();
			if (CheckValidData())
			{// Якщо дані правильно заповнені
				AssignQuestionnaire();
				if (formOpenForChange)// Змінюємо дані при потребі
				{
					try
					{
						Client.ChangeQuestionnaire(account.Login, oldQuestionnaire,
							account.candidate.questionnaire);
					}
					catch (System.Net.Sockets.SocketException)
					{
						MessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
							"\nСпробуйте, будь ласка, пізніше.", "Помилка підключення",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

				FormClosing -= QuestionnaireForm_FormClosing;// Відписуємось від обробника події
				Close();
			}
		}
		private void QuestionnaireForm_FormClosing(object sender, FormClosingEventArgs e)
		{// Обробник події: закриття форми
		 // Чи дійсно користувач хоче вийти?
			DialogResult result = MessageBox.Show("Якщо Ви вийдете, то дані не будуть збережені.\nЧи дійсно Ви хочете вийти?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.No)// Якщо користувач НЕ хоче виходити
				e.Cancel = true;
			else if (account.candidate.questionnaire.City == null)
				account.candidate.questionnaire = null;
		}
		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelNationality, labelCity,
					labelChildrenAmount, labelExperience, labelReadiness, labelDriverLicense,
					labelFamilyStatus, labelBusinessTripOpportunity, labelChronicDiseases,
					labelChronicDiseasesInfo, labelSmoker, labelDrinkAlcohol,
					 labelLanguageNumber, labelLanguage, labelLevel, labelEducation, labelEducationNumber,
					 labelNameInstitution, labelSpecialty, labelEducationDegree,
					 labelYearAdmission, labelDateEnd, labelEducationForm, labelAdditionalInfo);

			ColorChanger.ChangeInputControlsColor(theme, textBoxCity,
					numericUpDownChildrenAmount, numericUpDownExperience, numericUpDownReadiness,
					 richTextBoxChronicDiseases, numericUpDownLevel, textBoxNameInstitution,
					 textBoxSpecialty, numericUpDownYearAdmission, richTextBoxAdditionalInfo,
					 comboBoxNationality, comboBoxFamilyStatus, comboBoxBusinessTripOpportunity,
					 comboBoxLanguage, comboBoxEducationDegree, comboBoxEducationForm);

			ColorChanger.ChangeInputControlsForeColor(theme,
					checkBoxDriverLicenseNo, checkBoxDriverLicenseYes, checkBoxSmokerNo,
					checkBoxSmokerYes, checkBoxDrinkAlcoholNo, checkBoxDrinkAlcoholYes,
					buttonLanguageHelp);

			if (theme == Theme.White)
			{// Якщо треба встановити світлу тему
				BackColor = ColorChanger.BackColorThemeW;
				flpLanguages.BackColor = Color.FromArgb(213, 213, 213);
				flpEducations.BackColor = Color.FromArgb(213, 213, 213);
				panelLanguage.BackColor = Color.FromArgb(230, 230, 230);
				panelEducation.BackColor = Color.FromArgb(230, 230, 230);
			}
			else if (theme == Theme.Black)
			{// Якщо треба встановити темну тему
				BackColor = ColorChanger.BackColorThemeB;
				flpLanguages.BackColor = Color.FromArgb(32, 32, 32);
				flpEducations.BackColor = Color.FromArgb(32, 32, 32);
				panelLanguage.BackColor = Color.FromArgb(40, 40, 40);
				panelEducation.BackColor = Color.FromArgb(40, 40, 40);
			}
		}

		private void QuestionnaireForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}