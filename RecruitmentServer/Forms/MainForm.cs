using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using RecruitmentServer.Models;
using SharedModels.Search;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using SharedModels.Models;
using RecruitmentLibrary.Serialization;
using RecruitmentServer.Models.DataBase;

namespace RecruitmentServer.Forms
{
	internal enum PanelsInfo : byte
	{
		None,
		Vacancy,
		Application,
		Interview,
		Employee
	}

	internal partial class MainForm : BaseForm, IThemeChange
	{
		private const int COUNT_ON_PAGE = 3;
		private const int DEFAULT_SEARCH_DATE = 5;
		private const int SCROLL_PADDING = 6;

		private readonly (Color Accepted, Color Waiting, Color Invited, Color Rejected)
			_statusColor = (Color.FromArgb(0, 109, 91), Color.FromArgb(255, 185, 97),
			Color.FromArgb(229, 158, 31), Color.FromArgb(191, 34, 51));

		private readonly Account _account;
		private FullSearcher _searcher;
		private PanelsInfo _panelsInfo = PanelsInfo.None;

		private readonly ControlCreator _vacancyCreator, _applicationCreator,
			_interviewCreator, _employeeCreator;
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers =
			new PictureBoxEventHandlers();

		private readonly List<Guna2GradientPanel> _createdPanels =
			new List<Guna2GradientPanel>();
		private readonly Dictionary<Guna2GradientButton, Vacancy> _buttonVacancyMap =
			new Dictionary<Guna2GradientButton, Vacancy>();
		private readonly Dictionary<Guna2GradientButton, SharedModels.Models.Application>
			_buttonApplicationMap = new Dictionary<Guna2GradientButton,
				SharedModels.Models.Application>();
		private readonly Dictionary<Guna2GradientButton, Interview> _buttonInterviewMap =
			new Dictionary<Guna2GradientButton, Interview>();
		private readonly Dictionary<Guna2GradientButton, Employee> _buttonEmployeeMap =
			new Dictionary<Guna2GradientButton, Employee>();

		private int _totalItemsToDisplay;// Total number of panels required for display
		private int _currentComboBoxDateIndex, _currentComboBoxStatusIndex,
		_currentComboBoxSortIndex;

		internal MainForm(Account account)
		{
			customTitleBar = new CustomTitleBar(this, "Головна", Properties.Resources.main);
			IsResizable = true;
			InitializeComponent();

			_account = account;
			_vacancyCreator = new ControlCreator(panelVacancy, flpContent, false);
			_applicationCreator = new ControlCreator(panelApplication, flpContent, false);
			_interviewCreator = new ControlCreator(panelInterview, flpContent, false);
			_employeeCreator = new ControlCreator(panelEmployee, flpContent, false);

			flpContent.MouseWheel += FlpContent_MouseWheel;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			SetDefaultSearchValues();
			_currentComboBoxDateIndex = comboBoxDate.SelectedIndex;
			_currentComboBoxStatusIndex = comboBoxStatus.SelectedIndex;
			_currentComboBoxSortIndex = comboBoxSort.SelectedIndex;

			_labelEventHandlers.SubscribeToHoverUnderline(labelVacancy, labelApplication,
				labelInterview, labelEmployee);
			_pictureBoxEventHandlers.SubscribeToHover(pictureBoxRefresh,
				pictureBoxDown, pictureBoxUp, pictureBoxTheme);
			SetTheme(_account.Theme);
		}

		private void ButtonAssignment_Click(object sender, EventArgs e)
		{
			AssignmentForm assignmentForm = new AssignmentForm(_account, SelectLabel);
			assignmentForm.ShowDialog();
		}
		private void ButtonAddVacancy_Click(object sender, EventArgs e)
		{
			VacancyForm vacancyForm = new VacancyForm(_account, SelectLabel);
			vacancyForm.ShowDialog();
		}

		private void SelectLabel(EventArgs e)
		{
			if (_panelsInfo == PanelsInfo.Vacancy)
				LabelNavigation_Click(labelVacancy, e);
			else if (_panelsInfo == PanelsInfo.Application)
				LabelNavigation_Click(labelApplication, e);
			else if (_panelsInfo == PanelsInfo.Interview)
				LabelNavigation_Click(labelInterview, e);
			else if (_panelsInfo == PanelsInfo.Employee)
				LabelNavigation_Click(labelEmployee, e);
		}
		private void LabelNavigation_Click(object sender, EventArgs e)
		{
			if (!(sender is Label label)) return;

			ClearContentPanel();
			panelSearch.Visible = true;

			if (e != EventArgs.Empty)// If we are not searching
			{
				_searcher = null;
				SetDefaultSearchValues();
			}

			CreateAndSetupFirstPanels(label);
			labelEmpty.Visible = _totalItemsToDisplay == 0;
		}
		private void ClearContentPanel()
		{
			_totalItemsToDisplay = 0;

			UnsubscribeFromButtonEvents();
			_vacancyCreator?.Dispose();
			_applicationCreator?.Dispose();
			_interviewCreator?.Dispose();
			_employeeCreator?.Dispose();
			foreach (Guna2GradientPanel panel in _createdPanels)
				panel.Dispose();
			_createdPanels.Clear();

			Controls.Add(labelEmpty);// Move labelEmpty so it doesn't get deleted
			flpContent.Controls.Clear();
			flpContent.Controls.Add(labelEmpty);// Return labelEmpty back
		}
		private void UnsubscribeFromButtonEvents()
		{
			foreach (Guna2GradientButton button in _buttonVacancyMap.Keys)
				ManageVacancyButtonEvent(button, false);
			foreach (Guna2GradientButton button in _buttonApplicationMap.Keys)
				ManageApplicationButtonEvent(button, false);
			foreach (Guna2GradientButton button in _buttonInterviewMap.Keys)
				ManageInterviewButtonEvent(button, false);
			foreach (Guna2GradientButton button in _buttonEmployeeMap.Keys)
				ManageEmployeeButtonEvent(button, false);

			_buttonVacancyMap?.Clear();
			_buttonApplicationMap?.Clear();
			_buttonInterviewMap?.Clear();
			_buttonEmployeeMap?.Clear();
		}
		private void SetDefaultSearchValues()
		{
			textBoxMin.Text = "";
			textBoxMax.Text = "";
			textBoxSearch.Text = "";
			comboBoxDate.SelectedIndex = DEFAULT_SEARCH_DATE;
			comboBoxSort.SelectedIndex = 0;
			comboBoxStatus.SelectedIndex = 0;
		}

		#region First creating panels
		private void CreateAndSetupFirstPanels(Label label)
		{
			if (label == labelVacancy)
			{
				SetupVacancies();
				CreateVacancies();
			}
			else if (label == labelApplication)
			{
				SetupApplications();
				CreateApplications();
			}
			else if (label == labelInterview)
			{
				SetupInterviews();
				CreateInterviews();
			}
			else if (label == labelEmployee)
			{
				SetupEmployees();
				CreateEmployees();
			}
		}

		private void SetupVacancies()
		{
			if (_panelsInfo != PanelsInfo.Vacancy)
				SetupVacanciesSearchPanel();// If there was another panel before this

			SetActiveLabel(labelVacancy, labelApplication, labelInterview, labelEmployee);
			_panelsInfo = PanelsInfo.Vacancy;
			_totalItemsToDisplay = DatabaseManager.GetVacanciesCount(_searcher);
		}
		private void SetupVacanciesSearchPanel()
		{
			RemoveSortItemsFromIndex(2);
			comboBoxSort.Items.Add("За кількістю заявок");

			labelMinMax.Text = "Кількість заявок: ";
			SetMinMaxSearchVisible(true);

			SetStatusSearch(false, true, "Всі", "НЕ актуальні", "Актуальні");
		}

		private void SetupApplications()
		{
			if (_panelsInfo != PanelsInfo.Application)
				SetupApplicationsSearchPanel();// If there was another panel before this

			SetActiveLabel(labelApplication, labelVacancy, labelInterview, labelEmployee);
			_panelsInfo = PanelsInfo.Application;
			_totalItemsToDisplay = DatabaseManager.GetApplicationsCount(_searcher);
		}
		private void SetupApplicationsSearchPanel()
		{
			RemoveSortItemsFromIndex(2);
			comboBoxSort.Items.Add("За кількістю балів");

			labelMinMax.Text = "Кількість балів: ";
			SetMinMaxSearchVisible(true);

			SetStatusSearch(true, true, "Всі", "Відхилена", "В очікуванні", "Прийнята");
		}

		private void SetupInterviews()
		{
			if (_panelsInfo != PanelsInfo.Interview)
				SetupInterviewsSearchPanel();// If there was another panel before this

			SetActiveLabel(labelInterview, labelVacancy, labelApplication, labelEmployee);
			_panelsInfo = PanelsInfo.Interview;
			_totalItemsToDisplay = DatabaseManager.GetInterviewsCount(_searcher);
		}
		private void SetupInterviewsSearchPanel()
		{
			RemoveSortItemsFromIndex(2);

			SetMinMaxSearchVisible(false);

			SetStatusSearch(true, true, "Всі", "Кандидат запрошений",
				"Кандидат чекає на рішення", "Прийнято", "Не прийнято");
		}

		private void SetupEmployees()
		{
			if (_panelsInfo != PanelsInfo.Employee)
				SetupEmployeesSearchPanel();// If there was another panel before this

			SetActiveLabel(labelEmployee, labelVacancy, labelApplication, labelInterview);
			_panelsInfo = PanelsInfo.Employee;
			_totalItemsToDisplay = DatabaseManager.GetEmployeesCount(_searcher);
		}
		private void SetupEmployeesSearchPanel()
		{
			RemoveSortItemsFromIndex(2);
			comboBoxSort.Items.Add("За алфавітом (ПІБ)");

			SetMinMaxSearchVisible(false);

			SetStatusSearch(false, true, "Пошук за посадою", "Пошук по ПІБ");
		}

		private void SetMinMaxSearchVisible(bool visible)
		{
			labelMinMax.Visible = visible;
			textBoxMin.Visible = visible;
			labelMinMax2.Visible = visible;
			textBoxMax.Visible = visible;
		}

		private void SetActiveLabel(Label labelShow, params Label[] labelsHide)
		{
			const int INCREASE_FONT_SIZE = 2;

			// Highlight one label
			float fontSize = labelShow.Font.Size;
			if (fontSize <= labelsHide[0].Font.Size)
				fontSize += INCREASE_FONT_SIZE;
			labelShow.Enabled = false;
			labelShow.Font = new Font(labelShow.Font.FontFamily, fontSize,
				labelShow.Font.Style);

			// Hide other labels
			for (int i = 0; i < labelsHide.Length; i++)
			{
				labelsHide[i].Enabled = true;

				fontSize = labelsHide[i].Font.Size;
				if (labelsHide[i].Font.Size >= labelShow.Font.Size)
					fontSize -= INCREASE_FONT_SIZE;
				labelsHide[i].Font = new Font(labelsHide[i].Font.FontFamily,
					fontSize, labelsHide[i].Font.Style);
			}
		}
		private void RemoveSortItemsFromIndex(int startIndex)
		{
			for (int i = startIndex; i < comboBoxSort.Items.Count; i++)
				comboBoxSort.Items.RemoveAt(i--);
		}
		private void SetStatusSearch(bool labelVisibility, bool comboBoxVisibility,
			params string[] statusItems)
		{
			labelStatus.Visible = labelVisibility;
			comboBoxStatus.Visible = comboBoxVisibility;

			int startIndexToClearStatusItems = 1;// Delete all elements except the first one
			for (int i = startIndexToClearStatusItems; i < comboBoxStatus.Items.Count; i++)
				comboBoxStatus.Items.RemoveAt(i--);

			for (int i = 0; i < statusItems.Length; i++)
			{
				if (comboBoxStatus.Items.Count > i)// Renaming
					comboBoxStatus.Items[i] = statusItems[i];
				else
					comboBoxStatus.Items.Add((statusItems[i]));
			}
		}
		#endregion

		#region Creating panels
		private void CreateVacancies()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;

			List<Vacancy> vacancies = DatabaseManager.GetVacancies(_createdPanels.Count,
				COUNT_ON_PAGE, _searcher);
			Guna2GradientPanel[] panels = new Guna2GradientPanel[vacancies.Count];

			for (int i = 0; i < vacancies.Count; i++)
			{
				panels[i] = _vacancyCreator.CreateMainPanel();
				CreateVacancy(vacancies[i]);
			}

			ShowPanels(panels);
			_createdPanels.AddRange(panels);
		}
		private void CreateApplications()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;

			List<SharedModels.Models.Application> applications = DatabaseManager.GetApplications(
				_createdPanels.Count, COUNT_ON_PAGE, _searcher);
			Guna2GradientPanel[] panels = new Guna2GradientPanel[applications.Count];

			for (int i = 0; i < applications.Count; i++)
			{
				panels[i] = _applicationCreator.CreateMainPanel();
				CreateApplication(applications[i]);
			}

			ShowPanels(panels);
			_createdPanels.AddRange(panels);
		}
		private void CreateInterviews()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;

			List<Interview> interviews = DatabaseManager.GetInterviews(_createdPanels.Count,
				COUNT_ON_PAGE, _searcher);
			Guna2GradientPanel[] panels = new Guna2GradientPanel[interviews.Count];

			for (int i = 0; i < interviews.Count; i++)
			{
				panels[i] = _interviewCreator.CreateMainPanel();
				CreateInterview(interviews[i]);
			}

			ShowPanels(panels);
			_createdPanels.AddRange(panels);
		}
		private void CreateEmployees()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;

			List<Employee> employees = DatabaseManager.GetEmployees(_createdPanels.Count,
				COUNT_ON_PAGE, _searcher);
			Guna2GradientPanel[] panels = new Guna2GradientPanel[employees.Count];

			for (int i = 0; i < employees.Count; i++)
			{
				panels[i] = _employeeCreator.CreateMainPanel();
				CreateEmployee(employees[i]);
			}

			ShowPanels(panels);
			_createdPanels.AddRange(panels);
		}
		private void ShowPanels(Guna2GradientPanel[] panels)
		{
			for (int i = 0; i < panels.Length; i++)
				panels[i].Visible = true;

			FlpContent_Resize(flpContent, EventArgs.Empty);
		}

		private void CreateVacancy(Vacancy vacancy)
		{
			const string DATE_PREFIX = "Опубліковано: ";
			const string COUNT_PREFIX = "Заявок: ";

			_vacancyCreator.CreateLabel(labelPositionV, vacancy.Position.Name);
			_vacancyCreator.CreateLabel(labelCountV, COUNT_PREFIX +
				vacancy.Applications.Count.ToString());
			_vacancyCreator.CreateLabel(labelDatePublicationV, DATE_PREFIX +
				ConvertDateToString(vacancy.GetLocalDatePublication()));

			string relevance = vacancy.Relevance ? "Актуальна" : "НЕ актуальна";
			_vacancyCreator.CreateLabel(labelRelevance, relevance);
			Guna2PictureBox picture = _vacancyCreator.CreatePictureBox(
				pictureBoxVacancyStatus);
			picture.FillColor = GetVacancyStatusColor(vacancy.Relevance);

			Guna2GradientButton button = _vacancyCreator.CreateButton(buttonVacancy);
			_buttonVacancyMap.Add(button, vacancy);
			ManageVacancyButtonEvent(button, true);
		}
		private void CreateApplication(SharedModels.Models.Application application)
		{
			const string DATE_PREFIX = "Дата і час подачі: ";
			const string SCORES_PREFIX = "Балів: ";

			_applicationCreator.CreateLabel(labelPositionA, application.Vacancy.Position.Name);
			_applicationCreator.CreateLabel(labelScores, SCORES_PREFIX +
				application.Scores.ToString());
			_applicationCreator.CreateLabel(labelDateSubmissionA, DATE_PREFIX +
				ConvertDateToString(application.GetLocalDateSubmission()));

			_applicationCreator.CreateLabel(labelStatusA, application.ApplicationStatus.Status);
			Guna2PictureBox picture = _applicationCreator.CreatePictureBox(
				pictureBoxApplicationStatus);
			picture.FillColor = GetApplicationStatusColor(application.ApplicationStatus.Status);

			Guna2GradientButton button = _applicationCreator.CreateButton(buttonApplication);
			_buttonApplicationMap.Add(button, application);
			ManageApplicationButtonEvent(button, true);
		}
		private void CreateInterview(Interview interview)
		{
			const string DATE_PREFIX = "Дата і час проведення: ";

			_interviewCreator.CreateLabel(labelPositionI,
				interview.Application.Vacancy.Position.Name);
			_interviewCreator.CreateLabel(labelDateEventI, DATE_PREFIX +
				ConvertDateToString(interview.GetLocalDateEvent()));

			_interviewCreator.CreateLabel(labelStatusI, interview?.InterviewStatus?.Status);
			Guna2PictureBox picture = _interviewCreator.CreatePictureBox(
				pictureBoxInterviewStatus);
			picture.FillColor = GetInterviewStatusColor(interview?.InterviewStatus?.Status);

			Guna2GradientButton button = _interviewCreator.CreateButton(buttonInterview);
			_buttonInterviewMap.Add(button, interview);
			ManageInterviewButtonEvent(button, true);
		}
		private void CreateEmployee(Employee employee)
		{
			const string DATE_PREFIX = "Дата працевлаштування: ";

			_employeeCreator.CreateLabel(labelPositionE, employee.PositionName);
			_employeeCreator.CreateLabel(labelFullName, $"{employee.Surname} {employee.Name}" +
				$" {employee.FatherName}");
			_employeeCreator.CreateLabel(labelDateEmploymentE, DATE_PREFIX +
				ConvertDateToString(employee.DateEmployment));

			Guna2GradientButton button = _employeeCreator.CreateButton(buttonEmployee);
			_buttonEmployeeMap.Add(button, employee);
			ManageEmployeeButtonEvent(button, true);
		}

		private string ConvertDateToString(DateTime date)
		{
			string result;

			if (date == DateTime.Today)
				result = "Сьогодні";
			else if (date.AddDays(1) == DateTime.Today)
				result = "Вчора";
			else if (date.AddDays(2) == DateTime.Today)
				result = "Два дні тому";
			else if (date.Year == DateTime.Today.Year)
				result = date.ToString("d MMMM");
			else
				result = date.ToString("d MMMM yyyy");

			result += $" {date:HH:mm}";
			return result;
		}
		private Color GetVacancyStatusColor(bool relevance)
		{
			if (relevance)
				return _statusColor.Accepted;
			else
				return _statusColor.Waiting;
		}
		private Color GetApplicationStatusColor(string status)
		{
			if (status == "Відхилена")
				return _statusColor.Rejected;
			else if (status == "В очікуванні")
				return _statusColor.Waiting;
			else if (status == "Прийнята")
				return _statusColor.Accepted;

			return Color.Transparent;
		}
		private Color GetInterviewStatusColor(string status)
		{
			if (status == "Прийнято")
				return _statusColor.Accepted;
			else if (status == "Не прийнято")
				return _statusColor.Rejected;
			else if (status == "Кандидат запрошений")
				return _statusColor.Invited;
			else if (status == "Кандидат чекає на рішення")
				return _statusColor.Waiting;

			return Color.Transparent;
		}

		#region Button event handlers
		private void ManageVacancyButtonEvent(Guna2GradientButton button, bool subscribe)
		{
			if (subscribe)
				button.Click += ButtonVacancy_Click;
			else
				button.Click -= ButtonVacancy_Click;
		}
		private void ManageApplicationButtonEvent(Guna2GradientButton button,
			bool subscribe)
		{
			if (subscribe)
				button.Click += ButtonApplication_Click;
			else
				button.Click -= ButtonApplication_Click;
		}
		private void ManageInterviewButtonEvent(Guna2GradientButton button, bool subscribe)
		{
			if (subscribe)
				button.Click += ButtonInterview_Click;
			else
				button.Click -= ButtonInterview_Click;
		}
		private void ManageEmployeeButtonEvent(Guna2GradientButton button, bool subscribe)
		{
			if (subscribe)
				button.Click += ButtonEmployee_Click;
			else
				button.Click -= ButtonEmployee_Click;
		}

		private void ButtonVacancy_Click(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			Vacancy vacancy = _buttonVacancyMap[button];
			VacancyForm vacancyForm = new VacancyForm(_account, vacancy, SelectLabel);
			vacancyForm.ShowDialog();
		}
		private void ButtonApplication_Click(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			SharedModels.Models.Application application = _buttonApplicationMap[button];
			ApplicationForm applicationForm = new ApplicationForm(_account,
				application, SelectLabel);
			applicationForm.ShowDialog();
		}
		private void ButtonInterview_Click(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			Interview interview = _buttonInterviewMap[button];
			InterviewForm interviewForm = new InterviewForm(_account, interview, SelectLabel);
			interviewForm.ShowDialog();
		}
		private void ButtonEmployee_Click(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			Employee employee = _buttonEmployeeMap[button];
			EmployeeForm employeeForm = new EmployeeForm(_account, employee, SelectLabel);
			employeeForm.ShowDialog();
		}
		#endregion
		#endregion

		#region Searcher
		private void Search()
		{
			SetSearcherValues();
			SelectLabel(EventArgs.Empty);
		}
		private void SetSearcherValues()
		{
			var (Min, Max) = GetMinMaxValues();
			bool? isRelevance = null;
			string status = null, position = null, fullName = null;

			if (_panelsInfo == PanelsInfo.Employee)
			{
				if (comboBoxStatus.SelectedIndex == 0)// Search by position
					position = textBoxSearch.Text;
				else// Search by full name
					fullName = textBoxSearch.Text;
			}
			else
			{
				if (_panelsInfo == PanelsInfo.Vacancy && comboBoxStatus.SelectedIndex != 0)
					isRelevance = comboBoxStatus.SelectedIndex == 2;
				if (!isRelevance.HasValue && comboBoxStatus.SelectedIndex != 0)
					status = comboBoxStatus.Items[comboBoxStatus.SelectedIndex].ToString();
				position = textBoxSearch.Text;// Position
			}

			_searcher = new FullSearcher(position, GetDateByComboBoxDate(), Min, Max,
				isRelevance, status, fullName, GetSortOption());
		}

		private (int? Min, int? Max) GetMinMaxValues()
		{
			int? min = null, max = null;// Minimum and maximum
			if (textBoxMin.Text != "")
				min = int.Parse(textBoxMin.Text);
			if (textBoxMax.Text != "")
				max = int.Parse(textBoxMax.Text);
			if (min != null && max != null && min > max)
				CustomMessageBox.Show("Мінімальне значення не може бути більше максимального!",
					_account.Theme, "Помилка пошуку",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Warning);

			return (min, max);
		}
		private SortOption GetSortOption()
		{
			SortOption sortOption = SortOption.Date;

			if (comboBoxSort.SelectedIndex == 1)
				sortOption = SortOption.AlphabetPosition;
			else if (comboBoxSort.SelectedIndex == 2)
			{
				if (_panelsInfo == PanelsInfo.Vacancy)
					sortOption = SortOption.NumberOfApplications;
				else if (_panelsInfo == PanelsInfo.Application)
					sortOption = SortOption.NumberOfPoints;
				else if (_panelsInfo == PanelsInfo.Employee)
					sortOption = SortOption.AlphabetName;
			}

			return sortOption;
		}
		private DateTime? GetDateByComboBoxDate()
		{// Method that returns a date or null depending on the comboBoxDate index
			DateTime currentDate = DateTime.Now;
			if (comboBoxDate.SelectedIndex == 0)// 3 days
				return currentDate.AddDays(-3);
			else if (comboBoxDate.SelectedIndex == 1)// 1 week
				return currentDate.AddDays(-7);
			else if (comboBoxDate.SelectedIndex == 2)// 1 month
				return currentDate.AddMonths(-1);
			else if (comboBoxDate.SelectedIndex == 3)// 3 months
				return currentDate.AddMonths(-3);
			else if (comboBoxDate.SelectedIndex == 4)// 1 year
				return currentDate.AddYears(-1);
			else
				return null;
		}
		#endregion

		#region Search event handlers
		#region Buttons
		private void PictureBoxRefresh_Click(object sender, EventArgs e)
		{
			SetDefaultSearchValues();
			SelectLabel(e);
		}
		private void ButtonDown_Click(object sender, EventArgs e)
		{
			int newValue = Math.Min(flpContent.VerticalScroll.Value + GetCurrentPanelHeight()
				+ SCROLL_PADDING, flpContent.VerticalScroll.Maximum);
			flpContent.AutoScrollPosition = new System.Drawing.Point(0, newValue);
			FlpContent_Scroll(sender, new ScrollEventArgs(ScrollEventType.SmallIncrement,
				newValue));
		}
		private void ButtonUp_Click(object sender, EventArgs e)
		{
			int newValue = Math.Max(flpContent.VerticalScroll.Value - GetCurrentPanelHeight()
				- SCROLL_PADDING, flpContent.VerticalScroll.Minimum);
			flpContent.AutoScrollPosition = new System.Drawing.Point(0, newValue);
		}

		private int GetCurrentPanelHeight()
		{
			if (_createdPanels != null && _createdPanels.Count > 0)
				return _createdPanels[0].Height;

			return 0;
		}
		#endregion

		#region ComboBoxes
		private void LabelStatus_Click(object sender, EventArgs e)
			=> comboBoxStatus.DroppedDown = true;
		private void ComboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
			=> ComboBoxSelectedIndexChanged(comboBoxSort, ref _currentComboBoxSortIndex);
		private void ComboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
			=> ComboBoxSelectedIndexChanged(comboBoxDate, ref _currentComboBoxDateIndex,
				DEFAULT_SEARCH_DATE);
		private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
			=> ComboBoxSelectedIndexChanged(comboBoxStatus, ref _currentComboBoxStatusIndex);
		private void ComboBoxSelectedIndexChanged(ComboBox comboBox, ref int currentIndex,
			int defaultIndex = 0)
		{
			if (_searcher == null)
			{// Index selected for the first time
				if (comboBox.SelectedIndex == defaultIndex)
					return;
				Search();
			}
			else if (currentIndex != comboBox.SelectedIndex)
				Search();// The index is different from the previous one
			currentIndex = comboBox.SelectedIndex;
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

		#region Minimum and maximum
		private void LabelMinMax_Click(object sender, EventArgs e)
			=> textBoxMin.Focus();
		private void TextBoxMin_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SelectNextControl(ActiveControl, true, true, true, false);
			}
		}
		private void TextBoxMinMaxSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
				e.Handled = true;
		}
		private void TextBoxMinSearch_Leave(object sender, EventArgs e)
		{
			string searcherText = _searcher?.MinValue.ToString();
			TextBoxSearchLeave(textBoxMin.Text, searcherText);
		}
		private void TextBoxMaxSearch_Leave(object sender, EventArgs e)
		{
			string searcherText = _searcher?.MaxValue.ToString();
			TextBoxSearchLeave(textBoxMax.Text, searcherText);
		}
		private void TextBoxSearchLeave(string text, string searcherText)
		{
			if (searcherText == null)
			{// Text entered for the first time
				if (text.Length == 0)// If nothing is entered
					return;
				Search();
			}
			else if (searcherText != text)
				Search();// The text is different from the previous one
		}

		#endregion

		#region Position
		private void TextBoxPositionSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				Search();
				panelUp.Focus();
			}
		}
		private void TextBoxPositionSearch_Leave(object sender, EventArgs e)
		{
			string searcherText = _searcher?.Position;
			TextBoxSearchLeave(textBoxSearch.Text, searcherText);
		}
		private void PictureBoxSearch_Click(object sender, EventArgs e)
			=> textBoxSearch.Focus();
		#endregion
		#endregion

		#region Content panel event handlers
		private void FlpContent_Scroll(object sender, ScrollEventArgs e)
		{
			if (flpContent.VerticalScroll.Value + flpContent.Height
				>= flpContent.VerticalScroll.Maximum)
			{// The end of the panel is reached vertically
				flpContent.VerticalScroll.Enabled = false;

				if (_panelsInfo == PanelsInfo.Vacancy)
					CreateVacancies();
				else if (_panelsInfo == PanelsInfo.Application)
					CreateApplications();
				else if (_panelsInfo == PanelsInfo.Interview)
					CreateInterviews();
				else if (_panelsInfo == PanelsInfo.Employee)
					CreateEmployees();

				flpContent.VerticalScroll.Enabled = true;
			}
		}
		private void FlpContent_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta < 0 && flpContent.VerticalScroll.Value > 0)
				FlpContent_Scroll(sender, EventArgs.Empty as ScrollEventArgs);
		}
		private void FlpContent_Resize(object sender, EventArgs e)
		{
			foreach (Control control in flpContent.Controls)
				if (control is Guna2GradientPanel)
					control.Width = flpContent.ClientSize.Width -
						control.Margin.Horizontal - SCROLL_PADDING;
		}
		#endregion

		#region Theme
		private void PictureBoxTheme_Click(object sender, EventArgs e)
		{
			switch (_account.Theme)
			{
				case Theme.White:
					_account.Theme = Theme.Black;
					break;
				case Theme.Black:
					_account.Theme = Theme.White;
					break;
				default:
					throw new InvalidOperationException($"Unknown theme: {_account.Theme}");
			}

			SetTheme(_account.Theme);
			Serializator.Serialize(_account, Program.SerializePath, Program.EncryptKey);
		}

		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);
			ThemeControlManager.ChangeLabelsColor(theme, labelEmpty, labelCountV, labelFullName,
				labelRelevance, labelScores, labelStatus, labelStatusA, labelStatusI,
				labelDatePublicationV, labelDateSubmissionA, labelDateEventI, labelDateEmploymentE,
				labelPositionV, labelPositionA, labelPositionI, labelPositionE);

			panelMain.BackColor = BackColor;
			panelUp.BackColor = BackColor;
			flpNavigation.BackColor = BackColor;
			panelSearch.BackColor = BackColor;
			flpContent.BackColor = BackColor;

			SetPicturesAndPanelsTheme(theme);
		}
		private void SetPicturesAndPanelsTheme(Theme theme)
		{
			switch (theme)
			{
				case Theme.White:
					{
						pictureBoxTheme.Image = Properties.Resources.sun;
						pictureBoxRefresh.Image = Properties.Resources.refreshB;
						pictureBoxDown.Image = Properties.Resources.arrowDownB;
						pictureBoxUp.Image = Properties.Resources.arrowUpB;
						pictureBoxSearch.Image = Properties.Resources.loupeB;
						pictureBoxLine.BackColor = Color.Black;
						SetWhitePanels();
						break;
					}
				case Theme.Black:
					{
						pictureBoxTheme.Image = Properties.Resources.moon;
						pictureBoxRefresh.Image = Properties.Resources.refreshW;
						pictureBoxDown.Image = Properties.Resources.arrowDownW;
						pictureBoxUp.Image = Properties.Resources.arrowUpW;
						pictureBoxSearch.Image = Properties.Resources.loupeW;
						pictureBoxLine.BackColor = Color.White;
						SetBlackPanels();
						break;
					}
				default:
					throw new InvalidOperationException($"Unknown theme: {theme}");
			}
		}
		private void SetWhitePanels()
		{
			ThemeControlManager.ChangeGuna2GradientPanel(Theme.White, panelVacancy,
				panelApplication, panelInterview, panelEmployee);

			foreach (Guna2GradientPanel panel in _createdPanels)
			{
				panel.FillColor = ThemeControlManager.PanelBackColor.White;
				panel.FillColor2 = ThemeControlManager.PanelBackColor.White;
				foreach (Control control in panel.Controls)
					if (control is Label label)
						ThemeControlManager.ChangeLabelsColor(Theme.White, label);
			}
		}
		private void SetBlackPanels()
		{
			ThemeControlManager.ChangeGuna2GradientPanel(Theme.Black, panelVacancy,
				panelApplication, panelInterview, panelEmployee);

			foreach (Guna2GradientPanel panel in _createdPanels)
			{
				panel.FillColor = ThemeControlManager.PanelBackColor.Black;
				panel.FillColor2 = ThemeControlManager.PanelBackColor.Black;
				foreach (Control control in panel.Controls)
					if (control is Label label)
						ThemeControlManager.ChangeLabelsColor(Theme.Black, label);
			}
		}
		#endregion

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			flpContent.MouseWheel -= FlpContent_MouseWheel;
			ClearContentPanel();

			_labelEventHandlers.UnsubscribeAll();
			_pictureBoxEventHandlers.UnsubscribeAll();
		}
	}
}