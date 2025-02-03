using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using RecruitmentLibrary.Assignment;
using RecruitmentServer.Database;
using RecruitmentServer.Models;
using SharedModels.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentServer.Forms
{
	internal partial class AssignmentForm : BaseForm, IThemeChange
	{
		private readonly Account _account;
		private AssignmentItem[] _allItems;
		private List<int> _vacancyIds = new List<int>();
		private List<int> _candidateIds = new List<int>();

		private readonly ControlCreator _assignmentCreator;
		private readonly List<AssignmentItem> _resultItems = new List<AssignmentItem>();
		private readonly Action<EventArgs> _refreshMainForm;

		private readonly Dictionary<Guna2GradientButton, Candidate>
			_buttonCandidateMap = new Dictionary<Guna2GradientButton, Candidate>();
		private readonly Dictionary<Guna2GradientButton, SharedModels.Models.Application>
			_buttonApplicationMap = new Dictionary<Guna2GradientButton,
				SharedModels.Models.Application>();
		private readonly Dictionary<Guna2GradientButton, Vacancy>
			_buttonVacancyMap = new Dictionary<Guna2GradientButton, Vacancy>();

		internal AssignmentForm(Account account, Action<EventArgs> refreshMainForm)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Призначення", maximizeBox: false);
			_account = account;
			_refreshMainForm = refreshMainForm;
			_assignmentCreator = new ControlCreator(panelAssignment, flpContent, false);

		}
		private void AssignmentForm_Load(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			_allItems = DatabaseManager.GetAssignmentItems().ToArray();

			int[,] matrix = ConvertAssignmentItemsToMatrix();
			int[] results = AssignmentSolver.HungarianAlgorithm(matrix, true);
			SetResultItems(results);

			Cursor = Cursors.Default;
			CreateFormResultItems();
			SetTheme(_account.Theme);
		}

		private int[,] ConvertAssignmentItemsToMatrix()
		{
			_vacancyIds = new List<int>();
			_candidateIds = new List<int>();

			for (int i = 0; i < _allItems.Length; i++)
			{// Read all application and vacancy IDs
				_vacancyIds.Add(_allItems[i].VacancyId);
				_candidateIds.Add(_allItems[i].CandidateId);
			}

			_vacancyIds = _vacancyIds.Distinct().ToList();// Removing repetitions
			_candidateIds = _candidateIds.Distinct().ToList();

			// Obtaining the assignment matrix
			int[,] matrix = new int[_candidateIds.Count, _vacancyIds.Count];
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
					matrix[i, j] = GetScore(_vacancyIds[j], _candidateIds[i]);

			return matrix;
		}
		private int GetScore(int vacancyId, int candidateId)
		{// Method that returns scores by vacancy ID and candidate ID
			for (int i = 0; i < _allItems.Length; i++)
				if (_allItems[i].VacancyId == vacancyId
					&& _allItems[i].CandidateId == candidateId)
					return _allItems[i].Scores;

			return -1;
		}
		private void SetResultItems(int[] results)
		{// The method writes data from a one-dimensional array to _resultItems
			int vacancyId, candidateId, scores;
			for (int i = 0; i < results.Length; i++)
			{
				if (results[i] == -1)
					continue;

				vacancyId = _vacancyIds[results[i]];
				candidateId = _candidateIds[i];
				scores = GetScore(vacancyId, candidateId);

				if (scores < 0)
					continue;

				_resultItems.Add(new AssignmentItem(vacancyId, candidateId, scores));
			}
		}

		private void CreateFormResultItems()
		{
			List<Guna2GradientPanel> createdPanels = new List<Guna2GradientPanel>();
			for (int i = 0; i < _resultItems.Count; i++)
			{
				Vacancy vacancy = DatabaseManager.GetVacancy(_resultItems[i].VacancyId);
				Candidate candidate = DatabaseManager.GetCandidate(_resultItems[i].CandidateId);
				SharedModels.Models.Application application = DatabaseManager.GetApplication(
					_resultItems[i].VacancyId, _resultItems[i].CandidateId);

				createdPanels.Add(_assignmentCreator.CreateMainPanel());
				_assignmentCreator.CreateLabel(labelCandidate);
				_assignmentCreator.CreateLabel(labelVacancy);
				_assignmentCreator.CreateLabel(labelScores,
					$"Балів: {_resultItems[i].Scores}");

				Guna2GradientButton buttonC = _assignmentCreator.CreateButton(buttonCandidate);
				Guna2GradientButton buttonA = _assignmentCreator.CreateButton(
					buttonApplication);
				Guna2GradientButton buttonV = _assignmentCreator.CreateButton(buttonVacancy);

				buttonC.Text = candidate.Surname;
				buttonV.Text = vacancy.Position.Name;

				_buttonCandidateMap.Add(buttonC, candidate);
				_buttonApplicationMap.Add(buttonA, application);
				_buttonVacancyMap.Add(buttonV, vacancy);
				ManageButtonsEvents(buttonC, buttonA, buttonV, true);
			}

			if (createdPanels.Count <= 0)
				labelEmpty.Visible = true;
			else
				foreach (Guna2GradientPanel panel in createdPanels)
					panel.Visible = true;
		}

		#region Button event handlers
		private void ManageButtonsEvents(Guna2GradientButton buttonCandidate,
			Guna2GradientButton buttonApplication, Guna2GradientButton buttonVacancy,
			bool subscribe)
		{
			ManageCandidateButtonEvent(buttonCandidate, subscribe);
			ManageApplicationButtonEvent(buttonApplication, subscribe);
			ManageVacancyButtonEvent(buttonVacancy, subscribe);
		}
		private void ManageCandidateButtonEvent(Guna2GradientButton button, bool subscribe)
		{
			if (subscribe)
				button.Click += ButtonCandidate_Click;
			else
				button.Click -= ButtonCandidate_Click;
		}
		private void ManageApplicationButtonEvent(Guna2GradientButton button,
			bool subscribe)
		{
			if (subscribe)
				button.Click += ButtonApplication_Click;
			else
				button.Click -= ButtonApplication_Click;
		}
		private void ManageVacancyButtonEvent(Guna2GradientButton button, bool subscribe)
		{
			if (subscribe)
				button.Click += ButtonVacancy_Click;
			else
				button.Click -= ButtonVacancy_Click;
		}

		private void ButtonCandidate_Click(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			Candidate candidate = _buttonCandidateMap[button];
			CandidateForm candidateForm = new CandidateForm(_account, candidate);
			candidateForm.ShowDialog();
		}
		private void ButtonApplication_Click(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			SharedModels.Models.Application application = _buttonApplicationMap[button];
			ApplicationForm applicationForm = new ApplicationForm(_account, application,
				(args) =>
				{
					button.Visible = false;
					_refreshMainForm(EventArgs.Empty);
				});

			applicationForm.ShowDialog();
		}
		private void ButtonVacancy_Click(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			Vacancy vacancy = _buttonVacancyMap[button];

			VacancyForm vacancyForm = new VacancyForm(_account, vacancy,
				(args) =>
				{
					Close();
					_refreshMainForm(EventArgs.Empty);
				});

			vacancyForm.ShowDialog();
		}
		#endregion

		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);
			flpContent.BackColor = BackColor;
		}

		private void AssignmentForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			foreach (Guna2GradientButton button in _buttonCandidateMap.Keys)
				ManageCandidateButtonEvent(button, false);
			foreach (Guna2GradientButton button in _buttonApplicationMap.Keys)
				ManageApplicationButtonEvent(button, false);
			foreach (Guna2GradientButton button in _buttonVacancyMap.Keys)
				ManageVacancyButtonEvent(button, false);

			_buttonCandidateMap.Clear();
			_buttonApplicationMap.Clear();
			_buttonVacancyMap.Clear();

			_assignmentCreator.Dispose();
		}
	}
}