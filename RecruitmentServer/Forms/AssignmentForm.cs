using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using RecruitmentLibrary;
using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using RecruitmentServer.DataModels;
using RecruitmentServer.ServerUtilities;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentServer.Forms
{
	internal partial class AssignmentForm : BaseForm, IThemeChange
	{// Форма призначення заявок
		private readonly ServerAccount account;// Акаунт

		private List<int> vacancyIds = new List<int>();// Список кодів вакансій
		private List<int> candidateIds = new List<int>();// Список кодів кандидата
		private AssignmentItem[] allItems;

		private readonly List<AssignmentItem> resultItems = new List<AssignmentItem>();// Список результатів
		private readonly Action<EventArgs> refresh;// Перезавантаження головної форми

		internal AssignmentForm(ServerAccount account, Action<EventArgs> refresh)
		{// Конструктор форми призначення
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Призначення", minimizeBox: false, maximizeBox: false);
			this.refresh = refresh;// Встановлюємо значення
			this.account = account;

			SetTheme(account.Theme);
		}
		private void AssignmentForm_Load(object sender, EventArgs e)
		{// Обробник події завантаження форми
			allItems = DataBase.GetAssignmentItems();// Беремо дані з БД

			int[,] matrix = ConvertAssignmentItemsToMatrix();
			int[] result = AssignmentSolver.HungarianAlgorithm(matrix, true);


			int idVacancy, idCandidate, scores;// Запис результатів в resultItems
			for (int i = 0; i < result.Length; i++)
			{
				if (result[i] == -1)
					continue;

				idVacancy = vacancyIds[result[i]];
				idCandidate = candidateIds[i];
				scores = FindScore(idVacancy, idCandidate);

				if (scores < 0)
					continue;

				resultItems.Add(new AssignmentItem(idVacancy, idCandidate, scores));
			}

			CreateFormResultItems();
		}

		private int[,] ConvertAssignmentItemsToMatrix()
		{// Метод, який повертає двовимірний масив(матрицю) цілих чисел
			vacancyIds = new List<int>();
			candidateIds = new List<int>();

			for (int i = 0; i < allItems.Length; i++)
			{// Записуємо всі коди заявок та вакансій
				vacancyIds.Add(allItems[i].IdVacancy);
				candidateIds.Add(allItems[i].IdCandidate);
			}

			vacancyIds = vacancyIds.Distinct().ToList();
			candidateIds = candidateIds.Distinct().ToList();// Видаляємо повторення

			// Знаходимо матрицю призначення
			int[,] matrix = new int[candidateIds.Count, vacancyIds.Count];
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
					matrix[i, j] = FindScore(vacancyIds[j], candidateIds[i]);

			return matrix;
		}
		private int FindScore(int idVacancy, int idCandidate)
		{// Метод, який повертає бали за кодом вакансії та кандидата
			for (int i = 0; i < allItems.Length; i++)
				if (allItems[i].IdVacancy == idVacancy
					&& allItems[i].IdCandidate == idCandidate)
					return allItems[i].Scores;

			return -1;
		}
		private void CreateFormResultItems()
		{// Метод створює на формі елементи з результуючими даними
			List<Panel> panels = new List<Panel>();
			ControlCreator creator = new ControlCreator(panelAssignment, flpMain, false);
			for (int i = 0; i < resultItems.Count; i++)
			{
				FullVacancy vacancy = DataBase.GetVacancy(resultItems[i].IdVacancy);
				Candidate candidate = DataBase.GetCandidate(resultItems[i].IdCandidate);
				FullApplication application = DataBase.GetApplication(resultItems[i].IdVacancy,
					resultItems[i].IdCandidate);

				panels.Add(creator.CreateMainPanel());

				creator.CreateLabel(labelCandidate);
				creator.CreateLabel(labelVacancy);
				creator.CreateLabel(labelScores, $"Балів: {resultItems[i].Scores}");

				Guna2GradientButton buttonC = creator.CreateButton(buttonCandidate);
				Guna2GradientButton buttonV = creator.CreateButton(buttonVacancy);
				Guna2GradientButton buttonA = creator.CreateButton(buttonApplication);

				buttonC.Text = candidate.Surname;
				buttonV.Text = vacancy.Position.Name;

				AddEventCandidateButton_Click(buttonC, candidate);
				AddEventVacancyButton_Click(buttonV, vacancy);
				AddEventApplicationButton_Click(buttonA, application);
			}

			if (panels.Count <= 0)
				labelEmpty.Visible = true;
			else
				foreach (Panel panel in panels)// Вмикаємо видимість панелям
					panel.Visible = true;
		}
		private void AddEventCandidateButton_Click(Guna2GradientButton button, Candidate candidate)
		{// Метод який підписується на подію натискання на кандидата
			button.Click += (s, args) =>
			{// Підписуємось на подію відкриття форми
				CandidateForm cf = new CandidateForm(candidate, account);
				cf.ShowDialog();
			};
		}
		private void AddEventVacancyButton_Click(Guna2GradientButton button, FullVacancy vacancy)
		{// Метод який підписується на подію натискання на вакансію
			button.Click += (s, args) =>
			{// Підписуємось на подію відкриття форми
				VacancyForm vf = new VacancyForm(vacancy, account, (e) => { Close(); refresh(EventArgs.Empty); });
				vf.ShowDialog();
			};
		}
		private void AddEventApplicationButton_Click(Guna2GradientButton button, FullApplication application)
		{// Метод який підписується на подію натискання на заявку
			button.Click += (s, args) =>
			{// Підписуємось на подію відкриття форми
				ApplicationForm af = new ApplicationForm(application, (e) => { button.Visible = false; refresh(EventArgs.Empty); }, account);
				af.ShowDialog();
			};
		}

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);

		private void AssignmentForm_FormClosed(object sender, FormClosedEventArgs e)
		{ }
	}
}