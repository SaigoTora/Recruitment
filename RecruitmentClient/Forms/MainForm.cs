using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using RecruitmentClient.ClientUtilities;
using RecruitmentLibrary.ApplicationInfo;
using RecruitmentLibrary.PersonInfo;
using UIHelpers.ControlEventHandlers;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;
using UIHelpers.Validation;
using System.Diagnostics;
using System.Net.Sockets;

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

		private readonly ClientAccount _account;
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers =
			new PictureBoxEventHandlers();
		private readonly int _comboBoxSortCount;

		private ClientSearcher _searcher;
		private PanelsInfo _panelsInfo = PanelsInfo.None;
		private readonly List<Guna2GradientPanel> _createdPanels = new List<Guna2GradientPanel>();
		private int _totalItemsToDisplay;// Total number of panels required for display
		private int _currentComboBoxDateIndex;

		internal MainForm(ClientAccount account)
		{
			customTitleBar = new CustomTitleBar(this, "Головна", Properties.Resources.main);
			IsResizable = true;
			InitializeComponent();

			_account = account;
			_comboBoxSortCount = comboBoxSort.Items.Count;
			flpContent.MouseWheel += FlpContent_MouseWheel;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			buttonProfile.Text = _account.candidate.Name;

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
				Environment.Exit(0);
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
				buttonProfile.Text = _account.candidate.Name;
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

			try
			{
				CreateAndSetupFirstPanels(label);
			}
			catch (SocketException)
			{
				CustomMessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
					"\nСпробуйте, будь ласка, пізніше.", _account.Theme, "Помилка підключення",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}
			labelEmpty.Visible = _totalItemsToDisplay == 0;
		}
		private void ClearContentPanel()
		{
			_totalItemsToDisplay = 0;

			foreach (Guna2GradientPanel panel in _createdPanels)
				panel.Dispose();
			_createdPanels.Clear();

			Controls.Add(labelEmpty);// Move labelEmpty so it doesn't get deleted
			flpContent.Controls.Clear();
			flpContent.Controls.Add(labelEmpty);//Return labelEmpty back
		}
		private void SetDefaultSearchValues()
		{
			textBoxMinSalarySearch.Text = "";
			textBoxMaxSalarySearch.Text = "";
			textBoxPositionSearch.Text = "";
			comboBoxDate.SelectedIndex = DEFAULT_SEARCH_DATE;
			comboBoxSort.SelectedIndex = 0;
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
		}
		private void SetupVacancies()
		{
			const string newSortingElement = "За зарплатою";

			SetSalarySearchVisible(true);
			if (_panelsInfo == PanelsInfo.Application || _panelsInfo == PanelsInfo.Interview)
				ChangePanelSearchHeight(true);
			SetLabels(labelVacancy, labelApplication, labelInterview);

			if (_comboBoxSortCount > comboBoxSort.Items.Count)
				comboBoxSort.Items.Add(newSortingElement);

			_panelsInfo = PanelsInfo.Vacancy;
			_totalItemsToDisplay = Client.GetCountVacancies(_account.Login, _searcher);
		}
		private void SetupApplications()
		{
			SetSalarySearchVisible(false);
			if (_panelsInfo == PanelsInfo.None || _panelsInfo == PanelsInfo.Vacancy)
				ChangePanelSearchHeight(false);
			SetLabels(labelApplication, labelVacancy, labelInterview);

			if (_comboBoxSortCount == comboBoxSort.Items.Count)
				comboBoxSort.Items.RemoveAt(comboBoxSort.Items.Count - 1);

			_panelsInfo = PanelsInfo.Application;
			_totalItemsToDisplay = Client.GetCountApplications(_account.Login, _searcher);
		}
		private void SetupInterviews()
		{
			SetSalarySearchVisible(false);
			if (_panelsInfo == PanelsInfo.None || _panelsInfo == PanelsInfo.Vacancy)
				ChangePanelSearchHeight(false);
			SetLabels(labelInterview, labelVacancy, labelApplication);

			if (_comboBoxSortCount == comboBoxSort.Items.Count)
				comboBoxSort.Items.RemoveAt(comboBoxSort.Items.Count - 1);

			_panelsInfo = PanelsInfo.Interview;
			_totalItemsToDisplay = Client.GetCountInterviews(_account.Login, _searcher);
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
		private void SetLabels(Label labelShow, params Label[] labelsHide)
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
		private void CreateVacancies()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;

			List<Vacancy> vacancies = Client.GetFreeVacancies(_account.Login,
				_createdPanels.Count, COUNT_PANELS_ON_PAGE, _searcher);

			Guna2GradientPanel[] panels = new Guna2GradientPanel[vacancies.Count];
			ControlCreator creator = new ControlCreator(panelVacancy, flpContent);

			for (int i = 0; i < vacancies.Count; i++)
			{
				panels[i] = creator.CreateMainPanelNEW();
				CreateVacancy(vacancies[i], creator);
			}

			ShowPanels(panels);
			_createdPanels.AddRange(panels);
		}
		private void CreateApplications()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;

			List<RecruitmentLibrary.ApplicationInfo.Application> applications =
				Client.GetApplications(_account.Login, _createdPanels.Count,
				COUNT_PANELS_ON_PAGE, _searcher);

			Guna2GradientPanel[] panels = new Guna2GradientPanel[applications.Count];
			ControlCreator creator = new ControlCreator(panelApplication, flpContent);

			for (int i = 0; i < applications.Count; i++)
			{
				panels[i] = creator.CreateMainPanelNEW();
				CreateApplication(applications[i], creator);
			}

			ShowPanels(panels);
			_createdPanels.AddRange(panels);
		}
		private void CreateInterviews()
		{
			if (_createdPanels.Count >= _totalItemsToDisplay)
				return;

			List<Interview> interviews = Client.GetInterviews(_account.Login,
				_createdPanels.Count, COUNT_PANELS_ON_PAGE, _searcher);

			Guna2GradientPanel[] panels = new Guna2GradientPanel[interviews.Count];
			ControlCreator creator = new ControlCreator(panelInterview, flpContent);

			for (int i = 0; i < interviews.Count; i++)
			{
				panels[i] = creator.CreateMainPanelNEW();
				CreateInterview(interviews[i], creator);
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

		private void CreateVacancy(Vacancy vacancy, ControlCreator creator)
		{
			const string CURRENCY = "грн.";
			const string DATE_PREFIX = "Опубліковано: ";

			creator.CreateLabel(labelPositionV, vacancy.Position.Name);
			Label labelDescription = creator.CreateLabel(labelPositionDescriptionV, vacancy.Position.Description);
			AdjustLabelLocation(labelDescription, panelVacancy);
			creator.CreateLabel(labelSalaryV, vacancy.Salary.ToString() + $" {CURRENCY}");
			Label labelDate = creator.CreateLabel(labelDatePublicationV, DATE_PREFIX +
				ConvertDateToString(vacancy.DatePublication));
			AdjustLabelLocation(labelDate, panelVacancy);

			Guna2GradientButton button = creator.CreateButton(buttonVacancy);
			AddEventVacancyButton_Click(button, vacancy);
		}
		private void CreateApplication(RecruitmentLibrary.ApplicationInfo.Application application,
			ControlCreator creator)
		{
			const string DATE_PREFIX = "Дата і час подачі: ";

			creator.CreateLabel(labelPositionA, application.Position.Name);
			creator.CreateLabel(labelStatusA, application.Status);
			Label labelDate = creator.CreateLabel(labelDateSubmissionA, DATE_PREFIX +
				ConvertDateToString(application.DateSubmission));
			AdjustLabelLocation(labelDate, panelVacancy);

			Guna2PictureBox picture = creator.CreatePictureBox(pictureBoxApplicationStatus);
			picture.FillColor = GetApplicationStatusColor(application.Status);

			string reason = application.ReasonRejection;
			if (!string.IsNullOrWhiteSpace(reason))
			{
				Guna2GradientButton button = creator.CreateButton(buttonReasonRejectionA);
				button.Click += (s, args) =>
				{
					CustomMessageBox.Show(reason, _account.Theme, "Причина відмови",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
				};
			}
		}
		private void CreateInterview(Interview interview, ControlCreator creator)
		{
			const string DATE_PREFIX = "Дата і час проведення: ";

			creator.CreateLabel(labelPositionI, interview.Position.Name);
			creator.CreateLabel(labelStatusI, interview.Status);
			Label labelDate = creator.CreateLabel(labelDateEventI, DATE_PREFIX + ConvertDateToString(interview.DateEvent));
			AdjustLabelLocation(labelDate, panelVacancy);

			Guna2PictureBox picture = creator.CreatePictureBox(pictureBoxInterviewStatus);
			picture.FillColor = GetInterviewStatusColor(interview.Status);
		}

		private string ConvertDateToString(DateTime date)
		{
			string result;

			if (date.Day == DateTime.Today.Day)
				result = "Сьогодні";
			else if (date.AddDays(1).Day == DateTime.Today.Day)
				result = "Вчора";
			else if (date.AddDays(2).Day == DateTime.Today.Day)
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
			labelDate.Location = new Point(labelDate.Location.X + (labelDate.Parent.Width - panelModel.Width),
				labelDate.Location.Y);
		}
		private void AddEventVacancyButton_Click(Guna2GradientButton button, Vacancy vacancy)
		{
			button.Click += (s, args) =>
				{
					try
					{
						VacancyForm vacancyForm = new VacancyForm(_account, vacancy,
							_account.Login, SelectLabel);
						vacancyForm.ShowDialog();
					}
					catch (SocketException)
					{
						CustomMessageBox.Show("Спроба підключитись до серверу завершилась не вдало."
							+ "\nСпробуйте, будь ласка, пізніше.",
							_account.Theme, "Помилка підключення",
							CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
					}
				};
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
				minSalary = Int32.Parse(textBoxMinSalarySearch.Text);
			if (!string.IsNullOrWhiteSpace(textBoxMaxSalarySearch.Text))
				maxSalary = Int32.Parse(textBoxMaxSalarySearch.Text);
			if (minSalary != null && maxSalary != null && minSalary > maxSalary)
				CustomMessageBox.Show("Мінімальна зарплата не може бути більше максимальної!",
					_account.Theme, "Помилка пошуку", CustomMessageBoxButtons.OK,
					CustomMessageBoxIcon.Warning);

			string position = textBoxPositionSearch.Text;// Position
			Validator validator = new Validator();
			validator.CheckBannedChar(new Label() { Text = "Посада" },
				position, Client.SEPARATOR, _account.Theme);

			ClientSortOption sortOption = ClientSortOption.Date;// Sorting
			if (comboBoxSort.SelectedIndex == 1)
				sortOption = ClientSortOption.Alphabet;
			else if (comboBoxSort.SelectedIndex == 2)
				sortOption = ClientSortOption.Salary;

			_searcher = new ClientSearcher(position, GetDateByComboBoxDate(),
				minSalary, maxSalary, sortOption);
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
			int newValue = Math.Min(flpContent.VerticalScroll.Value + GetCurrentPanelHeight() +
				SCROLL_PADDING, flpContent.VerticalScroll.Maximum);
			flpContent.AutoScrollPosition = new Point(0, newValue);
			FlpContent_Scroll(sender, new ScrollEventArgs(ScrollEventType.SmallIncrement,
				newValue));
		}
		private void ButtonUp_Click(object sender, EventArgs e)
		{
			int newValue = Math.Max(flpContent.VerticalScroll.Value - GetCurrentPanelHeight() -
				SCROLL_PADDING, flpContent.VerticalScroll.Minimum);
			flpContent.AutoScrollPosition = new Point(0, newValue);
		}
		private int GetCurrentPanelHeight()
		{
			if (_createdPanels != null && _createdPanels.Count > 0)
				return _createdPanels[0].Height;

			return 0;
		}
		#endregion

		private void ComboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_searcher == null)
			{
				if (comboBoxSort.SelectedIndex == 0)
					return;
				Search();
			}
			else if ((byte)_searcher.SortOption != comboBoxSort.SelectedIndex)
				Search();// The index is different from the previous one
		}
		private void ComboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_searcher == null)
			{
				if (comboBoxDate.SelectedIndex == DEFAULT_SEARCH_DATE)
					return;
				Search();
			}
			else if (_currentComboBoxDateIndex != comboBoxDate.SelectedIndex)
				Search();// The index is different from the previous one
			_currentComboBoxDateIndex = comboBoxDate.SelectedIndex;
		}

		#region Salary
		private void TextBoxSalarySearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
				e.Handled = true;
		}
		private void TextBoxMinSalarySearch_Leave(object sender, EventArgs e)
		{
			string searcherText = _searcher?.MinSalary.ToString();
			TextBoxSearchLeave(textBoxMinSalarySearch.Text, searcherText);
		}
		private void TextBoxMaxSalarySearch_Leave(object sender, EventArgs e)
		{
			string searcherText = _searcher?.MaxSalary.ToString();
			TextBoxSearchLeave(textBoxMaxSalarySearch.Text, searcherText);
		}
		private void TextBoxSearchLeave(string text, string searcherText)
		{
			if (searcherText == null)
			{
				if (text.Length == 0)
					return;
				Search();
			}
			else if (searcherText != text)
				Search();// The index is different from the previous one
		}
		#endregion

		#region Position
		private void TextBoxPositionSearch_Leave(object sender, EventArgs e)
		{
			string searcherText = _searcher?.Position;
			TextBoxSearchLeave(textBoxPositionSearch.Text, searcherText);
		}
		private void TextBoxPositionSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				Search();
				panelUp.Focus();
			}
		}
		private void PictureBoxSearch_Click(object sender, EventArgs e)
		{ textBoxPositionSearch.Focus(); }
		#endregion
		#endregion

		#region Content panel event handlers
		private void FlpContent_Scroll(object sender, ScrollEventArgs e)
		{
			if (flpContent.VerticalScroll.Value + flpContent.Height
				>= flpContent.VerticalScroll.Maximum)
			{// The end of the panel is reached vertically
				flpContent.VerticalScroll.Enabled = false;
				try
				{
					if (_panelsInfo == PanelsInfo.Vacancy)
						CreateVacancies();
					else if (_panelsInfo == PanelsInfo.Application)
						CreateApplications();
					else if (_panelsInfo == PanelsInfo.Interview)
						CreateInterviews();
				}
				catch (SocketException)
				{
					CustomMessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
						"\nСпробуйте, будь ласка, пізніше.", _account.Theme, "Помилка підключення",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				}
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