using System;
using System.Data;
using System.Windows.Forms;

using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using ServerDB.DataModels;
using ServerDB.ServerUtilities;

namespace ServerDB.Forms
{
	internal partial class PointsForm : Form, IThemeChange
	{// Форма балів
		private readonly Points points;// Об'єкт, який зберігає інформацію про кількість балів
		private PointDegree[] degrees;// Масив, який зберігає інформацію про кількість балів для ступенів освіти
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();
		internal PointsForm(Points points, bool isForView, ServerAccount account)
		{// Конструктор форми
			InitializeComponent();

			this.points = points;

			if (isForView)// Якщо форма відкрита для перегляду
			{// То зміна даних забороняється
				buttonCreate.Visible = false;
				NUDAgeUnder18.Enabled = false;
				NUDAge18_30.Enabled = false;
				NUDAge30_50.Enabled = false;
				NUDAgeOver50.Enabled = false;
				NUDExpNone.Enabled = false;
				NUDExpUnderYear.Enabled = false;
				NUDExp1_3.Enabled = false;
				NUDExpOver3.Enabled = false;
				NUDDiploma.Enabled = false;
				NUDNoChronicDiseases.Enabled = false;
				NUDDriverLicense.Enabled = false;
				NUDNoSmoker.Enabled = false;
				NUDNoDrinkAlcohol.Enabled = false;
				NUDBusinessTripOpportunity.Enabled = false;
				NUDDegree.Enabled = false;
			}
			if (points.Degrees != null)
			{// Заповнюємо масив degrees
				degrees = new PointDegree[points.Degrees.Length];
				for (int i = 0; i < points.Degrees.Length; i++)
					degrees[i] = points.Degrees[i];
			}
			SetTheme(account.Theme);
		}
		private void PointsForm_Load(object sender, EventArgs e)
		{// Обробник події завантаження форми
			education_DegreeTableAdapter.Fill(recruitmentDBDataSet.Education_Degree);

			// Зчитуємо дані з points
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
			buttonEventHandlers.SubscribeToHover(buttonCreate);

			if (degrees == null)
			{// Заповнюємо масив degrees
				DataRowView item;
				degrees = new PointDegree[comboBoxDegrees.Items.Count];
				for (int i = 0; i < comboBoxDegrees.Items.Count; i++)
				{// Цикл по елементам comboBoxDegrees
					item = comboBoxDegrees.Items[i] as DataRowView;// Отримуємо елемент

					PointDegree pd = new PointDegree(int.Parse(item[0].ToString()), 0);
					degrees[i] = pd;
				}
			}
			else// Обираємо перший елемент, щоб він змінився
				ComboBoxDegrees_SelectedIndexChanged(comboBoxDegrees, EventArgs.Empty);
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку створення вакансії
			points.Change((int)NUDAgeUnder18.Value, (int)NUDAge18_30.Value,
				(int)NUDAge30_50.Value, (int)NUDAgeOver50.Value, (int)NUDExpNone.Value,
				(int)NUDExpUnderYear.Value, (int)NUDExp1_3.Value, (int)NUDExpOver3.Value,
				(int)NUDDiploma.Value, (int)NUDNoChronicDiseases.Value,
				(int)NUDDriverLicense.Value, (int)NUDNoSmoker.Value,
				(int)NUDNoDrinkAlcohol.Value, (int)NUDBusinessTripOpportunity.Value, degrees);

			Close();
		}

		private int GetIndexDegreeById(int id)
		{// Метод знаходить індекс degrees за його Id
			for (int i = 0; i < degrees.Length; i++)
				if (degrees[i].IdDegree == id)
					return i;

			return -1;// Якщо не було знайдено
		}
		private void NUDDegree_ValueChanged(object sender, EventArgs e)
		{// Обробник події зміни кількості балів для ступеня освіти
			int id = int.Parse(comboBoxDegrees.SelectedValue.ToString());
			int index = GetIndexDegreeById(id);
			if (index >= 0)
				degrees[index] = new PointDegree(id, (int)NUDDegree.Value);
		}
		private void ComboBoxDegrees_SelectedIndexChanged(object sender, EventArgs e)
		{// Обробник події для зміни ступеня освіти
			int id = int.Parse(comboBoxDegrees.SelectedValue.ToString());
			int index = GetIndexDegreeById(id);
			if (index >= 0)
				NUDDegree.Value = degrees[index].Point;
			else
				NUDDegree.Value = 0;
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelAgeUnder18,
				labelAge18_30, labelAge30_50, labelAgeOver50, labelExpNone, labelExpUnderYear,
				labelExp1_3, labelExpOver3, labelDiploma, labelNoChronicDiseases, labelDriverLicense,
				labelNoSmoker, labelNoDrinkAlcohol, labelBusinessTripOpportunity);

			ColorChanger.ChangeInputControlsColor(theme, NUDAgeUnder18,
				NUDAge18_30, NUDAge30_50, NUDAgeOver50, NUDExpNone, NUDExpUnderYear,
				NUDExp1_3, NUDExpOver3, NUDDiploma, NUDNoChronicDiseases, NUDDriverLicense,
				NUDNoSmoker, NUDNoDrinkAlcohol, NUDBusinessTripOpportunity, NUDDegree, comboBoxDegrees);
			if (theme == Theme.White)// Якщо треба встановити світлу тему
				BackColor = ColorChanger.BackColorThemeW;
			else if (theme == Theme.Black)// Якщо треба встановити темну тему
				BackColor = ColorChanger.BackColorThemeB;
		}

		private void PointsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}