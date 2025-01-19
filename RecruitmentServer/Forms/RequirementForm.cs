using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using RecruitmentServer.Models;
using SharedModels.Models;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;

namespace RecruitmentServer.Forms
{
	internal partial class RequirementForm : BaseForm, IThemeChange
	{
		private readonly Account _account;
		private readonly Requirement _requirement;
		private readonly CheckBoxEventHandlers _checkBoxEventHandlers =
			new CheckBoxEventHandlers();
		private readonly RadioButtonEventHandlers _radionButtonEventHandlers =
			new RadioButtonEventHandlers();

		internal RequirementForm(Account account, Requirement requirement)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Вимоги", minimizeBox: false,
				maximizeBox: false);
			_account = account;
			_requirement = requirement;
		}
		private void RequirementForm_Load(object sender, EventArgs e)
		{
			education_DegreeTableAdapter.Fill(recruitmentDBDataSet.Education_Degree);
			if (_requirement.City != null)// If the requirements were specified
				SetFormFields(_requirement);
			else
			{
				listBoxDegrees.SelectedItems.Clear();
				numericUpDownAgeMax.Value = numericUpDownAgeMax.Maximum;
			}

			_checkBoxEventHandlers.SubscribeToHoverShadow(checkBoxDiplomaAll);
			_radionButtonEventHandlers.SubscribeToHoverShadow(radioButtonNoChronicDiseasesNo,
				radioButtonNoChronicDiseasesYes, radioButtonDriverLicenseNo,
				radioButtonDriverLicenseYes, radioButtonNoSmokerNo, radioButtonNoSmokerYes,
				radioButtonNoDrinkAlcoholNo, radioButtonNoDrinkAlcoholYes,
				radioButtonBusinessTripNo, radioButtonBusinessTripYes,
				radioButtonStudentNo, radioButtonStudentYes, radioButtonStudentNull
				);
			SetTheme(_account.Theme);
		}

		private void SetFormFields(Requirement requirement)
		{
			textBoxCity.Text = requirement.City;
			numericUpDownAgeMin.Value = requirement.AgeMin;
			numericUpDownAgeMax.Value = requirement.AgeMax;
			numericUpDownExpMin.Value = requirement.ExpMin;
			SelectDegrees();
			radioButtonNoChronicDiseasesYes.Checked = requirement.NoChronicDiseases;
			radioButtonDriverLicenseYes.Checked = requirement.DriverLicense;
			radioButtonNoSmokerYes.Checked = requirement.NoSmoker;
			radioButtonNoDrinkAlcoholYes.Checked = requirement.NoDrinkAlcohol;
			radioButtonBusinessTripYes.Checked = requirement.BusinessTripOpportunity;

			if (requirement.Student == null)
				radioButtonStudentNull.Checked = true;
			else if (requirement.Student.Value)
				radioButtonStudentYes.Checked = true;
			else
				radioButtonStudentNo.Checked = true;
		}
		private void SelectDegrees()
		{
			DataRowView item;
			listBoxDegrees.SetSelected(0, false);// Deselect the first element
			foreach (var degreeReq in _requirement.EducationDegreeRequirements)
				for (int j = 0; j < listBoxDegrees.Items.Count; j++)
				{
					item = listBoxDegrees.Items[j] as DataRowView;

					if (item != null && degreeReq.EducationDegreeId
						== Convert.ToInt32(item["id"]))
					{
						listBoxDegrees.SetSelected(j, true);
						break;
					}
				}
		}

		private void ListBoxDegrees_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool allSelected = true;
			for (int i = 0; i < listBoxDegrees.Items.Count; i++)
				if (!listBoxDegrees.GetSelected(i))
					allSelected = false;

			checkBoxDiplomaAll.CheckedChanged -= CheckBoxDiplomaAll_CheckedChanged;
			if (allSelected)
				checkBoxDiplomaAll.Checked = true;
			else
				checkBoxDiplomaAll.Checked = false;
			checkBoxDiplomaAll.CheckedChanged += CheckBoxDiplomaAll_CheckedChanged;
		}
		private void CheckBoxDiplomaAll_CheckedChanged(object sender, EventArgs e)
		{
			listBoxDegrees.SelectedIndexChanged -= ListBoxDegrees_SelectedIndexChanged;
			for (int i = 0; i < listBoxDegrees.Items.Count; i++)
				listBoxDegrees.SetSelected(i, checkBoxDiplomaAll.Checked);
			listBoxDegrees.SelectedIndexChanged += ListBoxDegrees_SelectedIndexChanged;
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			if (CheckValidData())
			{
				bool? student = null;
				if (radioButtonStudentNo.Checked)
					student = false;
				else if (radioButtonStudentYes.Checked)
					student = true;

				var degreeReqs = new List<EducationDegreeRequirement>();
				foreach (DataRowView selectedItem in listBoxDegrees.SelectedItems)
					degreeReqs.Add(new EducationDegreeRequirement(_requirement.Id,
						int.Parse(selectedItem[0].ToString())));

				_requirement.Change(textBoxCity.Text, (byte)numericUpDownAgeMin.Value,
					(byte)numericUpDownAgeMax.Value, (int)numericUpDownExpMin.Value,
					checkBoxDiplomaAll.Checked, radioButtonNoChronicDiseasesYes.Checked,
					radioButtonDriverLicenseYes.Checked, radioButtonNoSmokerYes.Checked,
					radioButtonNoDrinkAlcoholYes.Checked, radioButtonBusinessTripYes.Checked,
					student, degreeReqs);
				Close();
			}
		}
		private bool CheckValidData()
		{
			ValidationFeedbackManager.ResetLabelsToDefault(_account.Theme, labelCity,
				labelAge);

			Validator validator = new Validator();
			validator.CheckBannedChar(labelCity, textBoxCity.Text, Server.SEPARATOR,
				_account.Theme);

			bool isDataValid = validator.IsDataValid;
			if (numericUpDownAgeMin.Value > numericUpDownAgeMax.Value)
			{
				ValidationFeedbackManager.HighlightInvalidLabel(labelAge, "Мінімальний вік "
					+ "не може перевищувати максимальний!", _account.Theme, ref isDataValid);
			}

			return isDataValid;
		}

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
		private void LabelCity_Click(object sender, EventArgs e)
			=> textBoxCity.Focus();
		private void LabelAgeMin_Click(object sender, EventArgs e)
			=> numericUpDownAgeMin.Focus();
		private void LabelAgeMax_Click(object sender, EventArgs e)
			=> numericUpDownAgeMax.Focus();
		private void LabelExpMin_Click(object sender, EventArgs e)
			=> numericUpDownExpMin.Focus();
		private void LabelEducationDegree_Click(object sender, EventArgs e)
			=> listBoxDegrees.Focus();
		private void LabelDiplomaAll_Click(object sender, EventArgs e)
			=> checkBoxDiplomaAll.Checked = !checkBoxDiplomaAll.Checked;

		private void LabelNoChronicDiseasesNo_Click(object sender, EventArgs e)
			=> radioButtonNoChronicDiseasesNo.Checked = true;
		private void LabelNoChronicDiseasesYes_Click(object sender, EventArgs e)
			=> radioButtonNoChronicDiseasesYes.Checked = true;

		private void LabelDriverLicenseNo_Click(object sender, EventArgs e)
			=> radioButtonDriverLicenseNo.Checked = true;
		private void LabelDriverLicenseYes_Click(object sender, EventArgs e)
			=> radioButtonDriverLicenseYes.Checked = true;

		private void LabelNoSmokerNo_Click(object sender, EventArgs e)
			=> radioButtonNoSmokerNo.Checked = true;
		private void LabelNoSmokerYes_Click(object sender, EventArgs e)
			=> radioButtonNoSmokerYes.Checked = true;

		private void LabelNoDrinkAlcoholNo_Click(object sender, EventArgs e)
			=> radioButtonNoDrinkAlcoholNo.Checked = true;
		private void LabelNoDrinkAlcoholYes_Click(object sender, EventArgs e)
			=> radioButtonNoDrinkAlcoholYes.Checked = true;

		private void LabelBusinessTripNo_Click(object sender, EventArgs e)
			=> radioButtonBusinessTripNo.Checked = true;
		private void LabelBusinessTripYes_Click(object sender, EventArgs e)
			=> radioButtonBusinessTripYes.Checked = true;

		private void LabelStudentNo_Click(object sender, EventArgs e)
			=> radioButtonStudentNo.Checked = true;
		private void LabelStudentYes_Click(object sender, EventArgs e)
			=> radioButtonStudentYes.Checked = true;
		private void LabelStudentNull_Click(object sender, EventArgs e)
			=> radioButtonStudentNull.Checked = true;
		#endregion

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);

		private void RequirementForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_checkBoxEventHandlers.UnsubscribeAll();
			_radionButtonEventHandlers.UnsubscribeAll();
		}
	}
}