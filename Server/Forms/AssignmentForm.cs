using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using RecruitmentLibrary;
using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using ServerDB.DataModels;
using ServerDB.ServerUtilities;

namespace ServerDB.Forms
{
	internal partial class AssignmentForm : Form, IThemeChange
	{// Форма призначення заявок
		private readonly ServerAccount account;// Акаунт

		private List<int> vacancyIds = new List<int>();// Список кодів вакансій
		private List<int> candidateIds = new List<int>();// Список кодів кандидата
		private AssignmentItem[] allItems;

		private readonly List<AssignmentItem> resultItems = new List<AssignmentItem>();// Список результатів
		private readonly Action<EventArgs> refresh;// Перезавантаження головної форми
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		internal AssignmentForm(ServerAccount account, Action<EventArgs> refresh)
		{// Конструктор форми призначення
			InitializeComponent();

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
			buttonEventHandlers.SubscribeToHover(buttonApplication);
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
			for (int i = 0; i < resultItems.Count; i++)
			{
				FullVacancy vacancy = DataBase.GetVacancy(resultItems[i].IdVacancy);
				Candidate candidate = DataBase.GetCandidate(resultItems[i].IdCandidate);
				FullApplication application = DataBase.GetApplication(resultItems[i].IdVacancy,
					resultItems[i].IdCandidate);

				Creator creator = new Creator(panelAssignment, flpMain, i + 1, false);
				panels.Add(creator.MainPanel);

				creator.CreateLabel(labelCandidate);
				creator.CreateLabel(labelVacancy);
				creator.CreateLabel(labelScores, $"Балів: {resultItems[i].Scores}");

				Button buttonC = creator.CreateButton(buttonCandidate);
				Button buttonV = creator.CreateButton(buttonVacancy);
				Button buttonA = creator.CreateButton(buttonApplication);

				buttonC.Text = candidate.Surname;
				buttonV.Text = vacancy.Position.Name;

				AddEventCandidateButton_Click(buttonC, candidate);
				AddEventVacancyButton_Click(buttonV, vacancy);
				AddEventApplicationButton_Click(buttonA, application);

				buttonEventHandlers.SubscribeToHover(buttonC, buttonV, buttonA);
			}

			if (panels.Count <= 0)
				labelEmpty.Visible = true;
			else
				foreach (Panel panel in panels)// Вмикаємо видимість панелям
					panel.Visible = true;
		}
		private void AddEventCandidateButton_Click(Button button, Candidate candidate)
		{// Метод який підписується на подію натискання на кандидата
			button.Click += (s, args) =>
			{// Підписуємось на подію відкриття форми
				CandidateForm cf = new CandidateForm(candidate, account);
				cf.ShowDialog();
			};
		}
		private void AddEventVacancyButton_Click(Button button, FullVacancy vacancy)
		{// Метод який підписується на подію натискання на вакансію
			button.Click += (s, args) =>
			{// Підписуємось на подію відкриття форми
				VacancyForm vf = new VacancyForm(vacancy, account, (e) => { Close(); refresh(EventArgs.Empty); });
				vf.ShowDialog();
			};
		}
		private void AddEventApplicationButton_Click(Button button, FullApplication application)
		{// Метод який підписується на подію натискання на заявку
			button.Click += (s, args) =>
			{// Підписуємось на подію відкриття форми
				ApplicationForm af = new ApplicationForm(application, (e) => { button.Visible = false; refresh(EventArgs.Empty); }, account);
				af.ShowDialog();
			};
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelTitle, labelCandidate,
				labelVacancy, labelScores, labelEmpty);

			if (theme == Theme.White)// Якщо треба встановити світлу тему
			{
				BackColor = ColorChanger.BackColorThemeW;
				flpMain.BackColor = Color.FromArgb(213, 213, 213);
				panelAssignment.BackColor = Color.FromArgb(222, 222, 222);
			}
			else if (theme == Theme.Black)// Якщо треба встановити темну тему
			{
				BackColor = ColorChanger.BackColorThemeB;
				flpMain.BackColor = Color.FromArgb(32, 32, 32);
				panelAssignment.BackColor = Color.FromArgb(37, 37, 37);
			}
		}

		private void AssignmentForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}