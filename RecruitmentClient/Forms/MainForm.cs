using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecruitmentClient.Models;
using RecruitmentLibrary.Serialization;
using SharedModels.DTOs;
using SharedModels.Models;
using SharedModels.Search;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentClient.Forms
{
	internal enum PanelsInfo : byte
	{
		None,
		Vacancy,
		Application,
		Interview
	}

	internal partial class MainForm : BaseForm, IThemeChange
	{
		private const int COUNT_PANELS_ON_PAGE = 10;
		private const int DEFAULT_SEARCH_DATE = 5;
		private const int SCROLL_PADDING = 6;

		private readonly (Color Accepted, Color Waiting, Color Invited, Color Rejected)
			_statusColor = (Color.FromArgb(0, 109, 91), Color.FromArgb(255, 185, 97),
			Color.FromArgb(229, 158, 31), Color.FromArgb(191, 34, 51));

		private readonly Account _account;
		private FullSearcher _searcher;
		private ApplicationSearcher _applicationSearcher;
		private InterviewSearcher _interviewSearcher;
		private PanelsInfo _panelsInfo = PanelsInfo.None;

		private readonly ControlCreator _vacancyCreator, _applicationCreator,
			_interviewCreator;
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers =
			new PictureBoxEventHandlers();

		private readonly List<Guna2GradientPanel> _createdPanels =
			new List<Guna2GradientPanel>();
		private readonly Dictionary<Guna2GradientButton, Vacancy> _buttonVacancyMap =
			new Dictionary<Guna2GradientButton, Vacancy>();
		private readonly Dictionary<Guna2GradientButton, string> _buttonReasonRejectionMap =
			new Dictionary<Guna2GradientButton, string>();

		private int _totalItemsToDisplay;// Total number of panels required for display
		private int _currentComboBoxDateIndex;
		private readonly int _comboBoxSortCount;

		internal MainForm(Account account)
		{
			customTitleBar = new CustomTitleBar(this, "Головна", Properties.Resources.main);
			IsResizable = true;
			InitializeComponent();

			_account = account;
			_comboBoxSortCount = comboBoxSort.Items.Count;

			_vacancyCreator = new ControlCreator(panelVacancy, flpContent, false);
			_applicationCreator = new ControlCreator(panelApplication, flpContent, false);
			_interviewCreator = new ControlCreator(panelInterview, flpContent, false);

			flpContent.MouseWheel += FlpContent_MouseWheel;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			buttonProfile.Text = _account.Candidate.Name;

			pictureBoxExit.Visible = Serializator.SerializationFileExists
				(Program.SerializePath);
			SetDefaultSearchValues();

			SetTheme(_account.Theme);
			_labelEventHandlers.SubscribeToHoverUnderline(labelVacancy,
				labelApplication, labelInterview);
			_pictureBoxEventHandlers.SubscribeToHover(pictureBoxRefresh, pictureBoxDown,
				pictureBoxUp, pictureBoxExit, pictureBoxPasswordChange, pictureBoxTheme);
		}

		private void ButtonExit_Click(object sender, EventArgs e)
		{
			DialogResult result = CustomMessageBox.Show("Ви впевнені, що хочете " +
				"вийти з акаунту?\nЯкщо так, то ваш логін та пароль будуть забуті " +
				"на цьому ПК. Крім того, програма перезапуститься.", _account.Theme,
				"Вихід з акаунту",
				CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Warning);

			if (result == DialogResult.Yes)
			{
				Visible = false;
				Serializator.DeleteSerializationFile(Program.SerializePath);
				Process.Start(System.Windows.Forms.Application.ExecutablePath);
				System.Windows.Forms.Application.Exit();
			}
		}
		private void ButtonPasswordChange_Click(object sender, EventArgs e)
		{
			Enabled = false;
			StartForm sf = new StartForm(_account);
			sf.Show();

			sf.FormClosed += (s, args) =>
			{ Enabled = true; };
		}
		private void ButtonProfile_Click(object sender, EventArgs e)
		{
			Enabled = false;
			ProfileForm pf = new ProfileForm(_account);
			pf.Show();
			pf.FormClosed += (s, args) =>
			{
				buttonProfile.Text = _account.Candidate.Name;
				Enabled = true;
				panelUp.Focus();
			};
		}

		private void SelectLabel(EventArgs e)
		{
			if (_panelsInfo == PanelsInfo.Vacancy)
				LabelNavigation_Click(labelVacancy, e);
			else if (_panelsInfo == PanelsInfo.Application)
				LabelNavigation_Click(labelApplication, e);
			else if (_panelsInfo == PanelsInfo.Interview)
				LabelNavigation_Click(labelInterview, e);
		}
		private async void LabelNavigation_Click(object sender, EventArgs e)
		{
			if (!(sender is Label label)) return;

			ClearContentPanel();
			panelSearch.Visible = true;

			if (e != EventArgs.Empty)// If we are not searching
			{
				_searcher = null;
				_applicationSearcher = null;
				_interviewSearcher = null;
				SetDefaultSearchValues();
			}

			try
			{
				await CreateAndSetupFirstPanelsAsync(label);
			}
			catch (Exception ex) when (ex is TaskCanceledException
				|| ex is System.Net.Http.HttpRequestException)
			{ Program.HandleNetworkError(); }
			labelEmpty.Visible = _totalItemsToDisplay == 0;
		}
		private void ClearContentPanel()
		{
			_totalItemsToDisplay = 0;

			UnsubscribeFromButtonEvents();
			_vacancyCreator?.Dispose();
			_applicationCreator?.Dispose();
			_interviewCreator?.Dispose();
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
			foreach (Guna2GradientButton button in _buttonReasonRejectionMap.Keys)
				ManageReasonRejectionButtonEvent(button, false);

			_buttonVacancyMap?.Clear();
			_buttonReasonRejectionMap?.Clear();
		}
		private void SetDefaultSearchValues()
		{
			textBoxMinSalarySearch.Text = "";
			textBoxMaxSalarySearch.Text = "";
			textBoxPositionSearch.Text = "";
			comboBoxDate.SelectedIndex = DEFAULT_SEARCH_DATE;
			comboBoxSort.SelectedIndex = 0;
		}
		private void SetEnabledLabels(bool enabled, params Label[] labels)
		{
			foreach (Label label in labels)
				label.Enabled = enabled;
		}

		#region First creating panels
		private async Task CreateAndSetupFirstPanelsAsync(Label label)
		{
			if (label == labelVacancy)
			{
				await SetupVacanciesAsync();
				await CreateVacanciesAsync();
			}
			else if (label == labelApplication)
			{
				await SetupApplicationsAsync();
				await CreateApplicationsAsync();
			}
			else if (label == labelInterview)
			{
				await SetupInterviewsAsync();
				await CreateInterviewsAsync();
			}
		}
		private async Task SetupVacanciesAsync()
		{
			const string newSortingElement = "За зарплатою";

			SetSalarySearchVisible(true);
			if (_panelsInfo == PanelsInfo.Application || _panelsInfo == PanelsInfo.Interview)
				ChangePanelSearchHeight(true);
			SetActiveLabel(labelVacancy, labelApplication, labelInterview);

			if (_comboBoxSortCount > comboBoxSort.Items.Count)
				comboBoxSort.Items.Add(newSortingElement);

			_panelsInfo = PanelsInfo.Vacancy;
			AccountSearchSettingsDTO<FullSearcher> accountSearch
				= new AccountSearchSettingsDTO<FullSearcher>(_account.GetCandidateLogin(), _searcher);
			SetEnabledLabels(false, labelApplication, labelInterview);
			_totalItemsToDisplay = await Program.Client.GetFreeVacanciesCountAsync(accountSearch);
			SetEnabledLabels(true, labelApplication, labelInterview);
		}
		private async Task SetupApplicationsAsync()
		{
			SetSalarySearchVisible(false);
			if (_panelsInfo == PanelsInfo.None || _panelsInfo == PanelsInfo.Vacancy)
				ChangePanelSearchHeight(false);
			SetActiveLabel(labelApplication, labelVacancy, labelInterview);

			if (_comboBoxSortCount == comboBoxSort.Items.Count)
				comboBoxSort.Items.RemoveAt(comboBoxSort.Items.Count - 1);

			_panelsInfo = PanelsInfo.Application;
			AccountSearchSettingsDTO<ApplicationSearcher> accountSearch
				= new AccountSearchSettingsDTO<ApplicationSearcher>(_account.GetCandidateLogin(),
				_applicationSearcher);
			SetEnabledLabels(false, labelVacancy, labelInterview);
			_totalItemsToDisplay = await Program.Client.GetApplicationsCountAsync(accountSearch);
			SetEnabledLabels(true, labelVacancy, labelInterview);
		}
		private async Task SetupInterviewsAsync()
		{
			SetSalarySearchVisible(false);
			if (_panelsInfo == PanelsInfo.None || _panelsInfo == PanelsInfo.Vacancy)
				ChangePanelSearchHeight(false);
			SetActiveLabel(labelInterview, labelVacancy, labelApplication);

			if (_comboBoxSortCount == comboBoxSort.Items.Count)
				comboBoxSort.Items.RemoveAt(comboBoxSort.Items.Count - 1);

			_panelsInfo = PanelsInfo.Interview;
			AccountSearchSettingsDTO<InterviewSearcher> accountSearch
				= new AccountSearchSettingsDTO<InterviewSearcher>(_account.GetCandidateLogin(),
				_interviewSearcher);
			SetEnabledLabels(false, labelVacancy, labelApplication);
			_totalItemsToDisplay = await Program.Client.GetInterviewsCountAsync(accountSearch);
			SetEnabledLabels(true, labelVacancy, labelApplication);
		}

		private void SetSalarySearchVisible(bool visible)
		{
			labelSalarySearch.Visible = visible;
			textBoxMinSalarySearch.Visible = visible;
			labelSalarySearch2.Visible = visible;
			textBoxMaxSalarySearch.Visible = visible;
		}
		private void ChangePanelSearchHeight(bool expandPanel)
		{
			const int SEARCH_PANEL_ADJUSTMENT = 40;

			if (expandPanel)
				panelSearch.Size = new Size(panelSearch.Width, panelSearch.Height +
					SEARCH_PANEL_ADJUSTMENT);
			else
				panelSearch.Size = new Size(panelSearch.Width, panelSearch.Height -
					SEARCH_PANEL_ADJUSTMENT);
		}
		private void SetActiveLabel(Label labelShow, params Label[] labelsHide)
		{
			const int INCREASE_FONT_SIZE = 2;

			// Highlight one label
			labelShow.Enabled = false;

			float fontSize = labelShow.Font.Size;
			if (fontSize <= labelsHide[0].Font.Size)
				fontSize += INCREASE_FONT_SIZE;
			labelShow.Font = new Font(labelShow.Font.FontFamily, fontSize, labelShow.Font.Style);


			// Hide other labels
			for (int i = 0; i < labelsHide.Length; i++)
			{
				labelsHide[i].Enabled = true;

				fontSize = labelsHide[i].Font.Size;
				if (fontSize >= labelShow.Font.Size)
					fontSize -= INCREASE_FONT_SIZE;
				labelsHide[i].Font = new Font(labelsHide[i].Font.FontFamily, fontSize,
					labelsHide[i].Font.Style);
			}
		}
		#endregion

		#region Creating panels
		private async Task CreateVacanciesAsync()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;


			SetEnabledLabels(false, labelApplication, labelInterview);
			PagedAccountSearchSettingsDTO<FullSearcher> pagedAccountSearch =
				new PagedAccountSearchSettingsDTO<FullSearcher>(_account.GetCandidateLogin(),
				_searcher, _createdPanels.Count, COUNT_PANELS_ON_PAGE);
			List<Vacancy> vacancies = await Program.Client.GetFreeVacanciesAsync(
				pagedAccountSearch);
			Guna2GradientPanel[] panels = new Guna2GradientPanel[vacancies.Count];

			for (int i = 0; i < vacancies.Count; i++)
			{
				panels[i] = _vacancyCreator.CreateMainPanel();
				CreateVacancy(vacancies[i]);
			}

			SetEnabledLabels(true, labelApplication, labelInterview);
			ShowPanels(panels);
			_createdPanels.AddRange(panels);
		}
		private async Task CreateApplicationsAsync()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;

			SetEnabledLabels(false, labelVacancy, labelInterview);
			PagedAccountSearchSettingsDTO<ApplicationSearcher> pagedAccountSearch
				= new PagedAccountSearchSettingsDTO<ApplicationSearcher>(_account.GetCandidateLogin(),
				_applicationSearcher, _createdPanels.Count, COUNT_PANELS_ON_PAGE);
			List<SharedModels.Models.Application> applications =
				await Program.Client.GetApplicationsAsync(pagedAccountSearch);
			Guna2GradientPanel[] panels = new Guna2GradientPanel[applications.Count];

			for (int i = 0; i < applications.Count; i++)
			{
				panels[i] = _applicationCreator.CreateMainPanel();
				CreateApplication(applications[i]);
			}

			SetEnabledLabels(true, labelVacancy, labelInterview);
			ShowPanels(panels);
			_createdPanels.AddRange(panels);
		}
		private async Task CreateInterviewsAsync()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;

			SetEnabledLabels(false, labelVacancy, labelApplication);
			PagedAccountSearchSettingsDTO<InterviewSearcher> pagedAccountSearch
				= new PagedAccountSearchSettingsDTO<InterviewSearcher>(_account.GetCandidateLogin(),
				_interviewSearcher, _createdPanels.Count, COUNT_PANELS_ON_PAGE);
			List<Interview> interviews =
				await Program.Client.GetInterviewsAsync(pagedAccountSearch);
			Guna2GradientPanel[] panels = new Guna2GradientPanel[interviews.Count];

			for (int i = 0; i < interviews.Count; i++)
			{
				panels[i] = _interviewCreator.CreateMainPanel();
				CreateInterview(interviews[i]);
			}

			SetEnabledLabels(true, labelVacancy, labelApplication);
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
			const string CURRENCY = "грн.";
			const string DATE_PREFIX = "Опубліковано: ";

			_vacancyCreator.CreateLabel(labelPositionV, vacancy.Position.Name);
			Label labelDescription = _vacancyCreator.CreateLabel(labelPositionDescriptionV,
				vacancy.Position.Description);
			AdjustLabelLocation(labelDescription, panelVacancy);
			_vacancyCreator.CreateLabel(labelSalaryV, $"{vacancy.Salary:0.##}" +
				$" {CURRENCY}");
			Label labelDate = _vacancyCreator.CreateLabel(labelDatePublicationV, DATE_PREFIX +
				ConvertDateToString(vacancy.GetLocalDatePublication()));
			AdjustLabelLocation(labelDate, panelVacancy);

			Guna2GradientButton button = _vacancyCreator.CreateButton(buttonVacancy);
			_buttonVacancyMap.Add(button, vacancy);
			ManageVacancyButtonEvent(button, true);
		}
		private void CreateApplication(SharedModels.Models.Application application)
		{
			const string DATE_PREFIX = "Дата і час подачі: ";

			_applicationCreator.CreateLabel(labelPositionA, application.Vacancy.Position.Name);
			Label labelDate = _applicationCreator.CreateLabel(labelDateSubmissionA,
				DATE_PREFIX + ConvertDateToString(application.GetLocalDateSubmission()));
			AdjustLabelLocation(labelDate, panelVacancy);

			_applicationCreator.CreateLabel(labelStatusA, application.ApplicationStatus.Status);
			Guna2PictureBox picture = _applicationCreator.CreatePictureBox(
				pictureBoxApplicationStatus);
			picture.FillColor = GetApplicationStatusColor(application.ApplicationStatus.Status);

			string reason = application.ReasonRejection;
			if (!string.IsNullOrWhiteSpace(reason))
			{
				Guna2GradientButton button = _applicationCreator.CreateButton(
					buttonReasonRejectionA);
				_buttonReasonRejectionMap.Add(button, reason);
				ManageReasonRejectionButtonEvent(button, true);
			}
		}
		private void CreateInterview(Interview interview)
		{
			const string DATE_PREFIX = "Дата і час проведення: ";

			_interviewCreator.CreateLabel(labelPositionI,
				interview.Application.Vacancy.Position.Name);
			_interviewCreator.CreateLabel(labelStatusI, interview.InterviewStatus.Status);
			Label labelDate = _interviewCreator.CreateLabel(labelDateEventI, DATE_PREFIX +
				ConvertDateToString(interview.GetLocalDateEvent()));
			AdjustLabelLocation(labelDate, panelVacancy);

			Guna2PictureBox picture = _interviewCreator.CreatePictureBox(
				pictureBoxInterviewStatus);
			picture.FillColor = GetInterviewStatusColor(interview.InterviewStatus.Status);
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
		private void AdjustLabelLocation(Label labelDate, Guna2GradientPanel panelModel)
		{
			labelDate.Location = new System.Drawing.Point(labelDate.Location.X +
				(labelDate.Parent.Width - panelModel.Width), labelDate.Location.Y);
		}
		private Color GetApplicationStatusColor(string status)
		{
			if (status == "Прийнята")
				return _statusColor.Accepted;
			else if (status == "Відхилена")
				return _statusColor.Rejected;
			else if (status == "В очікуванні")
				return _statusColor.Waiting;

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

		#region  Button event handlers
		private void ManageVacancyButtonEvent(Guna2GradientButton button, bool subscribe)
		{
			if (subscribe)
				button.Click += ButtonVacancy_Click;
			else
				button.Click -= ButtonVacancy_Click;
		}
		private void ManageReasonRejectionButtonEvent(Guna2GradientButton button, bool subscribe)
		{
			if (subscribe)
				button.Click += ButtonReasonRejection_Click;
			else
				button.Click -= ButtonReasonRejection_Click;
		}


		private void ButtonVacancy_Click(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			Vacancy vacancy = _buttonVacancyMap[button];
			VacancyForm vacancyForm = new VacancyForm(_account, vacancy, SelectLabel);
			vacancyForm.ShowDialog();
		}
		private void ButtonReasonRejection_Click(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			string reasonRejection = _buttonReasonRejectionMap[button];
			CustomMessageBox.Show(reasonRejection, _account.Theme, "Причина відмови",
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
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
			int? minSalary = null, maxSalary = null;// Salary
			if (!string.IsNullOrWhiteSpace(textBoxMinSalarySearch.Text))
				minSalary = int.Parse(textBoxMinSalarySearch.Text);
			if (!string.IsNullOrWhiteSpace(textBoxMaxSalarySearch.Text))
				maxSalary = int.Parse(textBoxMaxSalarySearch.Text);
			if (minSalary != null && maxSalary != null && minSalary > maxSalary)
				CustomMessageBox.Show("Мінімальна зарплата не може бути більше максимальної!",
					_account.Theme, "Помилка пошуку", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Warning);

			string position = textBoxPositionSearch.Text;// Position

			SortOption sortOption = SortOption.Date;// Sorting
			if (comboBoxSort.SelectedIndex == 1)
				sortOption = SortOption.AlphabetPosition;
			else if (comboBoxSort.SelectedIndex == 2)
				sortOption = SortOption.Salary;

			_searcher = new FullSearcher(position, GetDateByComboBoxDate(),
				minSalary, maxSalary, null, null, sortOption);
			switch (_panelsInfo)
			{
				case PanelsInfo.None:
					break;
				case PanelsInfo.Vacancy:
					break;
				case PanelsInfo.Application:
					_applicationSearcher = new ApplicationSearcher(position, GetDateByComboBoxDate(),
						null, null, null, GetApplicationSortOption());
					break;
				case PanelsInfo.Interview:
					_interviewSearcher = new InterviewSearcher(position, GetDateByComboBoxDate(),
						null, GetInterviewSortOption());
					break;
				default:
					break;
			}
		}
		private ApplicationSortOption GetApplicationSortOption()
		{
			ApplicationSortOption sortOption = ApplicationSortOption.Date;

			if (comboBoxSort.SelectedIndex == 1)
				sortOption = ApplicationSortOption.AlphabetPosition;

			return sortOption;
		}
		private InterviewSortOption GetInterviewSortOption()
		{
			InterviewSortOption sortOption = InterviewSortOption.Date;

			if (comboBoxSort.SelectedIndex == 1)
				sortOption = InterviewSortOption.AlphabetPosition;

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
			ActiveControl = null;
			SetDefaultSearchValues();
			SelectLabel(e);
		}
		private void ButtonDown_Click(object sender, EventArgs e)
		{
			int newValue = Math.Min(flpContent.VerticalScroll.Value + GetCurrentPanelHeight() +
				SCROLL_PADDING, flpContent.VerticalScroll.Maximum);
			flpContent.AutoScrollPosition = new System.Drawing.Point(0, newValue);
			FlpContent_Scroll(sender, new ScrollEventArgs(ScrollEventType.SmallIncrement,
				newValue));
		}
		private void ButtonUp_Click(object sender, EventArgs e)
		{
			int newValue = Math.Max(flpContent.VerticalScroll.Value - GetCurrentPanelHeight() -
				SCROLL_PADDING, flpContent.VerticalScroll.Minimum);
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
		private void ComboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
		{
			int currentIndex = default;
			if (_searcher != null)
				currentIndex = (int)_searcher.SortOption;
			if (_applicationSearcher != null)
				currentIndex = (int)_applicationSearcher.SortOption;
			else if (_interviewSearcher != null)
				currentIndex = (int)_interviewSearcher.SortOption;

			ComboBoxSelectedIndexChanged(comboBoxSort, ref currentIndex);
		}
		private void ComboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
			=> ComboBoxSelectedIndexChanged(comboBoxDate, ref _currentComboBoxDateIndex,
				DEFAULT_SEARCH_DATE);
		private void ComboBoxSelectedIndexChanged(ComboBox comboBox, ref int currentIndex,
			int defaultIndex = 0)
		{
			if (_searcher == null && _applicationSearcher == null && _interviewSearcher == null)
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

		#region Salary
		private void LabelSalarySearch_Click(object sender, EventArgs e)
			=> textBoxMinSalarySearch.Focus();
		private void TextBoxSalarySearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
				e.Handled = true;
		}
		private void TextBoxSalarySearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SelectNextControl(ActiveControl, true, true, true, false);
			}
		}

		private void TextBoxMinSalarySearch_Leave(object sender, EventArgs e)
		{
			string searcherText = _searcher?.MinValue.ToString();
			if (_panelsInfo == PanelsInfo.Application)
				searcherText = _applicationSearcher?.MinPoints.ToString();
			TextBoxSearchLeave(textBoxMinSalarySearch.Text, searcherText);
		}
		private void TextBoxMaxSalarySearch_Leave(object sender, EventArgs e)
		{
			string searcherText = _searcher?.MaxValue.ToString();
			if (_panelsInfo == PanelsInfo.Application)
				searcherText = _applicationSearcher?.MaxPoints.ToString();
			TextBoxSearchLeave(textBoxMaxSalarySearch.Text, searcherText);
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
				Search();// The index is different from the previous one
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
			switch (_panelsInfo)
			{
				case PanelsInfo.None:
					break;
				case PanelsInfo.Vacancy:
					break;
				case PanelsInfo.Application:
					searcherText = _applicationSearcher?.Position;
					break;
				case PanelsInfo.Interview:
					searcherText = _interviewSearcher?.Position;
					break;
				default:
					break;
			}
			TextBoxSearchLeave(textBoxPositionSearch.Text, searcherText);
		}
		private void PictureBoxSearch_Click(object sender, EventArgs e)
			=> textBoxPositionSearch.Focus();
		#endregion
		#endregion

		#region Content panel event handlers
		private async void FlpContent_Scroll(object sender, ScrollEventArgs e)
		{
			if (flpContent.VerticalScroll.Value + flpContent.Height
				>= flpContent.VerticalScroll.Maximum)
			{// The end of the panel is reached vertically
				flpContent.VerticalScroll.Enabled = false;
				try
				{
					if (_panelsInfo == PanelsInfo.Vacancy)
						await CreateVacanciesAsync();
					else if (_panelsInfo == PanelsInfo.Application)
						await CreateApplicationsAsync();
					else if (_panelsInfo == PanelsInfo.Interview)
						await CreateInterviewsAsync();
				}
				catch (Exception ex) when (ex is TaskCanceledException
					|| ex is System.Net.Http.HttpRequestException)
				{ Program.HandleNetworkError(); }
				finally
				{ flpContent.VerticalScroll.Enabled = true; }
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
			if (Serializator.SerializationFileExists(Program.SerializePath))
				Serializator.Serialize(_account, Program.SerializePath, Program.EncryptKey);
		}

		public void SetTheme(Theme theme)
		{
			ThemeControlManager.ChangeFormTheme(this, theme);
			ThemeControlManager.ChangeLabelsColor(theme, labelEmpty, labelSalaryV,
				labelPositionDescriptionV, labelStatusA, labelStatusI,
				labelDatePublicationV, labelDateSubmissionA, labelDateEventI,
				labelPositionV, labelPositionA, labelPositionI);
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
						pictureBoxPasswordChange.Image = Properties.Resources.keyB;
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
						pictureBoxPasswordChange.Image = Properties.Resources.keyW;
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
				panelApplication, panelInterview);

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
				panelApplication, panelInterview);

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