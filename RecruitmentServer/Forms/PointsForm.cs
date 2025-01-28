using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using RecruitmentServer.Models;
using SharedModels.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentServer.Forms
{
	internal partial class PointsForm : BaseForm, IThemeChange
	{
		private readonly Account _account;
		private readonly Point _point;
		private EducationDegreePoint[] _degreesPoints;

		internal PointsForm(Account account, Point point, bool isFormForView)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Бали", minimizeBox: false,
				maximizeBox: false);
			_account = account;
			_point = point;

			if (isFormForView)
			{
				buttonCreate.Visible = false;
				SetAllNumericUpDownEnabled(false);
				SetAllLabelsCursor(Cursors.Default);
			}
			if (point.Degrees != null)
				FillDegreesFromPoints(point);
		}
		private void PointsForm_Load(object sender, EventArgs e)
		{
			education_DegreeTableAdapter.Fill(recruitmentDBDataSet.Education_Degree);
			SetFormFields(_point);

			if (_degreesPoints == null)
				FillDegreesFromComboBox();

			comboBoxDegrees.SelectedIndex = 1;
			SetTheme(_account.Theme);
		}

		private void FillDegreesFromPoints(Point points)
			=> _degreesPoints = points.Degrees.ToArray();
		private void FillDegreesFromComboBox()
		{
			DataRowView item;
			_degreesPoints = new EducationDegreePoint[comboBoxDegrees.Items.Count];
			for (int i = 0; i < comboBoxDegrees.Items.Count; i++)
			{
				item = comboBoxDegrees.Items[i] as DataRowView;

				EducationDegreePoint pointDegree = new EducationDegreePoint(0, _point.Id,
					int.Parse(item[0].ToString()));
				_degreesPoints[i] = pointDegree;
			}
		}
		private void SetAllNumericUpDownEnabled(bool enabled)
		{
			foreach (Control control in this.Controls)
				if (control is NumericUpDown)
					control.Enabled = enabled;
		}
		private void SetAllLabelsCursor(Cursor cursor)
		{
			foreach (Control control in this.Controls)
				if (control is Label label)
					label.Cursor = cursor;
		}

		private void SetFormFields(Point points)
		{
			NUDAgeUnder18.Value = points.AgeUnder18;
			NUDAge18_30.Value = points.Age18_30;
			NUDAge30_50.Value = points.Age30_50;
			NUDAgeOver50.Value = points.AgeOver50;
			NUDExpNone.Value = points.ExpNone;
			NUDExpUnderYear.Value = points.ExpUnderYear;
			NUDExp1_3.Value = points.Exp1_3;
			NUDExpOver3.Value = points.ExpOver3;
			NUDDiploma.Value = points.Diploma;
			NUDNoChronicDiseases.Value = points.NoChronicDiseases;
			NUDDriverLicense.Value = points.DriverLicense;
			NUDNoSmoker.Value = points.NoSmoker;
			NUDNoDrinkAlcohol.Value = points.NoDrinkAlcohol;
			NUDBusinessTripOpportunity.Value = points.BusinessTripOpportunity;
		}

		#region Degrees event handlers
		private void NUDDegree_ValueChanged(object sender, EventArgs e)
		{
			int id = int.Parse(comboBoxDegrees.SelectedValue.ToString());
			int index = FindDegreeIndexById(id);

			if (index >= 0)
				_degreesPoints[index] = new EducationDegreePoint((int)NUDDegree.Value,
					_point.Id, id);
		}
		private void ComboBoxDegrees_SelectedIndexChanged(object sender, EventArgs e)
		{
			int id = int.Parse(comboBoxDegrees.SelectedValue.ToString());
			int index = FindDegreeIndexById(id);

			if (index >= 0)
				NUDDegree.Value = _degreesPoints[index].Points;
			else
				NUDDegree.Value = 0;
		}
		private int FindDegreeIndexById(int id)
		{
			for (int i = 0; i < _degreesPoints.Length; i++)
				if (_degreesPoints[i].EducationDegreeId == id)
					return i;

			return -1;
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
		#endregion

		#region Label focus event handlers
		private void LabelAgeUnder18_Click(object sender, EventArgs e)
			=> NUDAgeUnder18.Focus();
		private void LabelAge18_30_Click(object sender, EventArgs e)
			=> NUDAge18_30.Focus();
		private void LabelAge30_50_Click(object sender, EventArgs e)
			=> NUDAge30_50.Focus();
		private void LabelAgeOver50_Click(object sender, EventArgs e)
			=> NUDAgeOver50.Focus();
		private void LabelExpNone_Click(object sender, EventArgs e)
			=> NUDExpNone.Focus();
		private void LabelExpUnderYear_Click(object sender, EventArgs e)
			=> NUDExpUnderYear.Focus();
		private void LabelExp1_3_Click(object sender, EventArgs e)
			=> NUDExp1_3.Focus();

		private void LabelExpOver3_Click(object sender, EventArgs e)
			=> NUDExpOver3.Focus();
		private void LabelDiploma_Click(object sender, EventArgs e)
			=> NUDDiploma.Focus();
		private void LabelNoChronicDiseases_Click(object sender, EventArgs e)
			=> NUDNoChronicDiseases.Focus();
		private void LabelDriverLicense_Click(object sender, EventArgs e)
			=> NUDDriverLicense.Focus();
		private void LabelNoSmoker_Click(object sender, EventArgs e)
			=> NUDNoSmoker.Focus();
		private void LabelNoDrinkAlcohol_Click(object sender, EventArgs e)
			=> NUDNoDrinkAlcohol.Focus();
		private void LabelBusinessTripOpportunity_Click(object sender, EventArgs e)
			=> NUDBusinessTripOpportunity.Focus();
		#endregion

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			_point.Change((int)NUDAgeUnder18.Value, (int)NUDAge18_30.Value,
				(int)NUDAge30_50.Value, (int)NUDAgeOver50.Value, (int)NUDExpNone.Value,
				(int)NUDExpUnderYear.Value, (int)NUDExp1_3.Value, (int)NUDExpOver3.Value,
				(int)NUDDiploma.Value, (int)NUDNoChronicDiseases.Value,
				(int)NUDDriverLicense.Value, (int)NUDNoSmoker.Value,
				(int)NUDNoDrinkAlcohol.Value, (int)NUDBusinessTripOpportunity.Value,
				_degreesPoints);

			Close();
		}

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);
	}
}