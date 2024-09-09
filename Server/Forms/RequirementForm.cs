using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using ServerDB.DataModels;
using ServerDB.ServerUtilities;

namespace ServerDB.Forms
{
	internal partial class RequirementForm : Form, IThemeChange
	{// Форма вакансій
		private readonly FullRequirement requirement;// Вимоги
		private readonly ServerAccount account;// Акаунт
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();
		internal RequirementForm(FullRequirement requirement, ServerAccount account)
		{// Конструктор форми створення вакансії
			InitializeComponent();
			education_DegreeTableAdapter.Fill(recruitmentDBDataSet.Education_Degree);

			this.requirement = requirement;
			if (requirement.City != null)
			{// Якщо вимоги були вказані, то заповнюємо елементи форми
				textBoxCity.Text = requirement.City;
				numericUpDownAgeMin.Value = requirement.AgeMin;
				numericUpDownAgeMax.Value = requirement.AgeMax;
				numericUpDownExpMin.Value = requirement.ExpMin;
				SelectDegrees();
				checkBoxNoChronicDiseasesYes.Checked = requirement.NoChronicDiseases;
				checkBoxDriverLicenseYes.Checked = requirement.DriverLicense;
				checkBoxNoSmokerYes.Checked = requirement.NoSmoker;
				checkBoxNoDrinkAlcoholYes.Checked = requirement.NoDrinkAlcohol;
				checkBoxBusinessTripYes.Checked = requirement.BusinessTripOpportunity;

				if (requirement.Student == null)// Студент
					checkBoxStudentNull.Checked = true;
				else if (requirement.Student.Value)
					checkBoxStudentYes.Checked = true;
				else
					checkBoxStudentNo.Checked = true;
			}
			else
			{// Якщо вимоги не були вказані
				checkBoxDiplomaAll.Checked = true;// Вибираємо всі ступені освіти
				numericUpDownAgeMax.Value = numericUpDownAgeMax.Maximum;
			}
			buttonEventHandlers.SubscribeToHover(buttonCreate);

			this.account = account;
			SetTheme(account.Theme);
		}
		private void SelectDegrees()
		{// Метод, який обирає потрібні ступені освіти
			DataRowView item;
			listBoxDegrees.SetSelected(0, false);// Знімаємо виділення для першого елемента
			for (int i = 0; i < requirement.IdDegrees.Count; i++)
				for (int j = 0; j < listBoxDegrees.Items.Count; j++)
				{
					item = listBoxDegrees.Items[j] as DataRowView;// Отримуємо елемент

					if (item != null && requirement.IdDegrees[i] == Convert.ToInt32(item["id"]))
					{
						listBoxDegrees.SetSelected(j, true);
						break;// Виходимо, якщо вибрали потрібний ступінь
					}
				}
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{// Обробник події створення вимоги
			if (CheckValidData())
			{
				bool? student = null;// Студент
				if (checkBoxStudentNo.Checked)
					student = false;
				else if (checkBoxStudentYes.Checked)
					student = true;

				List<int> degrees = new List<int>();// Ступені освіти
				foreach (DataRowView selectedItem in listBoxDegrees.SelectedItems)
					degrees.Add(int.Parse(selectedItem[0].ToString()));

				// Зміна даних та закриття форми
				requirement.Change(textBoxCity.Text, (byte)numericUpDownAgeMin.Value,
					(byte)numericUpDownAgeMax.Value, (int)numericUpDownExpMin.Value,
					checkBoxDiplomaAll.Checked, checkBoxNoChronicDiseasesYes.Checked,
					checkBoxDriverLicenseYes.Checked, checkBoxNoSmokerYes.Checked,
					checkBoxNoDrinkAlcoholYes.Checked, checkBoxBusinessTripYes.Checked, student, degrees);
				Close();
			}
		}
		private bool CheckValidData()
		{// Метод перевіряє та показує які дані були введені не вірно
			bool isDataOk = true;
			Validator.SetDefaultLabels(account.Theme, labelCity);

			Validator.CheckBannedChar(labelCity, textBoxCity.Text, Server.SEPARATOR, ref isDataOk);

			return isDataOk;
		}

		private void CheckBoxDiplomaAll_CheckedChanged(object sender, EventArgs e)
		{// Обробник події натискання на "Вибрати всі"
			listBoxDegrees.SelectedIndexChanged -= ListBoxDegrees_SelectedIndexChanged;
			for (int i = 0; i < listBoxDegrees.Items.Count; i++)// Обираємо всі ступені освіти
				listBoxDegrees.SetSelected(i, checkBoxDiplomaAll.Checked);
			listBoxDegrees.SelectedIndexChanged += ListBoxDegrees_SelectedIndexChanged;
		}
		private void ListBoxDegrees_SelectedIndexChanged(object sender, EventArgs e)
		{// Обробник події натискання на ступінь освіти
			bool allSelected = true;// Чи вибрані всі ступені
			for (int i = 0; i < listBoxDegrees.Items.Count; i++)
				if (!listBoxDegrees.GetSelected(i))
					allSelected = false;

			checkBoxDiplomaAll.CheckedChanged -= CheckBoxDiplomaAll_CheckedChanged;
			if (allSelected)// Якщо всі вибрані
				checkBoxDiplomaAll.Checked = true;
			else
				checkBoxDiplomaAll.Checked = false;
			checkBoxDiplomaAll.CheckedChanged += CheckBoxDiplomaAll_CheckedChanged;
		}

		private void CheckBoxChanger(CheckBox checkBox, CheckBox checkBoxNo, CheckBox checkBoxYes)
		{// Метод для зміни стану CheckBox-ів (Так/Ні)
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
		private void CheckBoxNoChronicDiseases_CheckedChanged(object sender, EventArgs e)
		{// Хронічні захворювання
			if (sender is CheckBox checkBox)
				CheckBoxChanger(checkBox, checkBoxNoChronicDiseasesNo, checkBoxNoChronicDiseasesYes);
		}
		private void CheckBoxDriverLicense_CheckedChanged(object sender, EventArgs e)
		{// Посвідчення водія
			if (sender is CheckBox checkBox)
				CheckBoxChanger(checkBox, checkBoxDriverLicenseNo, checkBoxDriverLicenseYes);
		}
		private void CheckBoxNoSmoker_CheckedChanged(object sender, EventArgs e)
		{// Курець
			if (sender is CheckBox checkBox)
				CheckBoxChanger(checkBox, checkBoxNoSmokerNo, checkBoxNoSmokerYes);
		}
		private void CheckBoxNoDrinkAlcohol_CheckedChanged(object sender, EventArgs e)
		{// Вживання алкоголю
			if (sender is CheckBox checkBox)
				CheckBoxChanger(checkBox, checkBoxNoDrinkAlcoholNo, checkBoxNoDrinkAlcoholYes);
		}
		private void CheckBoxBusinessTrip_CheckedChanged(object sender, EventArgs e)
		{// Можливість відряджень
			if (sender is CheckBox checkBox)
				CheckBoxChanger(checkBox, checkBoxBusinessTripNo, checkBoxBusinessTripYes);
		}
		private void CheckBoxStudent_CheckedChanged(object sender, EventArgs e)
		{// Студент
			if (!(sender is CheckBox checkBox))
				return;
			if (!checkBox.Checked)
				checkBox.Checked = true;

			// Відписуємось від обробників подій
			checkBoxStudentNo.CheckedChanged -= CheckBoxStudent_CheckedChanged;
			checkBoxStudentYes.CheckedChanged -= CheckBoxStudent_CheckedChanged;
			checkBoxStudentNull.CheckedChanged -= CheckBoxStudent_CheckedChanged;

			if (checkBox == checkBoxStudentNo)
			{// Якщо змінили чекбокс "Ні"
				checkBoxStudentYes.Checked = false;
				checkBoxStudentNull.Checked = false;
			}
			else if (checkBox == checkBoxStudentYes)
			{// Якщо змінили чекбокс "Так"
				checkBoxStudentNo.Checked = false;
				checkBoxStudentNull.Checked = false;
			}
			else if (checkBox == checkBoxStudentNull)
			{// Якщо змінили чекбокс "Все одно"
				checkBoxStudentNo.Checked = false;
				checkBoxStudentYes.Checked = false;
			}

			// Підписуємось назад на обробники подій
			checkBoxStudentNo.CheckedChanged += CheckBoxStudent_CheckedChanged;
			checkBoxStudentYes.CheckedChanged += CheckBoxStudent_CheckedChanged;
			checkBoxStudentNull.CheckedChanged += CheckBoxStudent_CheckedChanged;
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelCity, labelCityInfo,
				labelAgeMin, labelAgeMax, labelExpMin, labelEducationDegree,
				labelCandidateMustHave, labelNoChronicDiseases,
				labelDriverLicense, labelNoSmoker, labelNoDrinkAlcohol, labelBusinessTrip,
				labelStudent);

			ColorChanger.ChangeInputControlsColor(theme, textBoxCity, numericUpDownAgeMin,
				numericUpDownAgeMax, numericUpDownExpMin, listBoxDegrees);

			ColorChanger.ChangeInputControlsForeColor(theme, checkBoxDiplomaAll,
				checkBoxNoChronicDiseasesNo, checkBoxNoChronicDiseasesYes,
				checkBoxDriverLicenseNo, checkBoxDriverLicenseYes,
				checkBoxNoSmokerNo, checkBoxNoSmokerYes, checkBoxNoDrinkAlcoholNo,
				checkBoxNoDrinkAlcoholYes, checkBoxBusinessTripNo,
				checkBoxBusinessTripYes, checkBoxStudentNo, checkBoxStudentYes,
				checkBoxStudentNull);

			if (theme == Theme.White)// Якщо треба встановити світлу тему
				BackColor = ColorChanger.BackColorThemeW;
			else if (theme == Theme.Black)// Якщо треба встановити темну тему
				BackColor = ColorChanger.BackColorThemeB;
		}

		private void RequirementForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}