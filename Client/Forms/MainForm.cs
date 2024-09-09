using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using RecruitmentLibrary.ApplicationInfo;
using RecruitmentLibrary.PersonInfo;
using RecruitmentLibrary.FormUtilities;
using RecruitmentUser.ClientUtilities;

namespace RecruitmentUser.Forms
{
	internal enum PanelsInfo : byte
	{// Перелік, який вказує інформацію панелей
		None,
		Vacancy,
		Application,
		Interview
	}

	internal partial class MainForm : Form, IThemeChange
	{
		private const int COUNT_ON_PAGE = 10;// Кількість завантажуваних панелей
		private const int DEFAULT_SEARCH_DATE = 5;// Значення дати пошуку за замовчуванням
		private const int PANEL_SEARCH_OFFSET = 59;// Значення для зміни розміру панелі

		private readonly ClientAccount account;// Обліковий запис
		private readonly Color colorGreen = Color.FromArgb(0, 109, 91);// Кольори для pictureBox-ів у заявках та співбесідах
		private readonly Color colorYellow1 = Color.FromArgb(255, 185, 97);
		private readonly Color colorYellow2 = Color.FromArgb(229, 158, 31);
		private readonly Color colorRed = Color.FromArgb(191, 34, 51);
		private readonly int comboBoxSortCount;// Кількість елементів у comboBoxSort
		private readonly PictureBoxEventHandlers pictureBoxEventHandlers = new PictureBoxEventHandlers();
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		private PanelsInfo panelsInfo = PanelsInfo.None;// Змінна, яка зберігає інформацію про вид панелей
		private readonly List<Panel> panelsVAI = new List<Panel>();// Панелі вакансій або заявок або співбесід
		private int countPanels;// Загальна кількість панелей необхідних для відображення
		private int currentPanelHeight;// Висота поточної панелі
		private int currentOffset;// Кількість вже згенерованих панелей
		private int currentDateIndex;// Індекс поточної вибраної дати в пошуку
		private ClientSearcher searcher;// Змінна, яка зберігає інформацію про пошук

		internal MainForm(ClientAccount a)
		{// Конструктор
			InitializeComponent();

			account = a;
			comboBoxSortCount = comboBoxSort.Items.Count;
			flpMain.MouseWheel += FlpMain_MouseWheel;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{// Обробник події завантаження форми
			Icon = Properties.Resources.main;
			buttonProfile.Text = account.candidate.Name;

			pictureBoxExit.Visible = Serializator.SerializationFileExists(Program.SerializePath);
			SetDefaultSearchValues();

			SetTheme(account.Theme);
			pictureBoxEventHandlers.SubscribeToHover(pictureBoxRefresh, pictureBoxDown, pictureBoxUp,
				pictureBoxExit, pictureBoxPasswordChange, pictureBoxTheme);
		}

		private void ClearMainPanel()
		{// Метод очищає головну панель
			countPanels = 0;
			currentOffset = 0;

			panelsVAI.Clear();// Очищаємо список
			Controls.Add(labelEmpty);// Переносимо label, щоб він не видалився
			flpMain.Controls.Clear();// Видаляємо елементи з панелі
			flpMain.Controls.Add(labelEmpty);//Повертаємо його назад
		}
		private void SetDefaultSearchValues()
		{// Метод встановлює пошуковим елементам початкові значення
			textBoxMinSalarySearch.Text = "";
			textBoxMaxSalarySearch.Text = "";
			textBoxPositionSearch.Text = "";
			comboBoxDate.SelectedIndex = DEFAULT_SEARCH_DATE;
			comboBoxSort.SelectedIndex = 0;
		}

		private void ButtonProfile_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку профілю
			Enabled = false;
			ProfileForm pf = new ProfileForm(account);
			pf.Show();
			pf.FormClosed += (s, args) =>
			{// Коли закриється форма профілю, то змінюється кнопка
				buttonProfile.Text = account.candidate.Name;
				Enabled = true;
				panelUp.Focus();
			};
		}
		private void ButtonPasswordChange_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку зміну паролю
			Enabled = false;
			StartForm sf = new StartForm(account);
			sf.Show();

			// Коли закриється форма зміни паролю
			sf.FormClosed += (s, args) =>
			{ Enabled = true; };
		}
		private void ButtonExit_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку виходу з акаунту
			DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти з акаунту?" +
				"\nЯкщо так, то ваш логін та пароль будуть забуті на цьому    ПК. Крім того," +
				" програма закриється, і для її подальшого     використання потрібно буде" +
				" її знову запустити.", "Вихід з акаунту",
				MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

			if (result == DialogResult.Yes)
			{// Якщо користувач дійсно хоче вийти
				Serializator.DeleteSerializationFile(Program.SerializePath);
				Close();
			}
		}

		// Методи для відображення інформації в головній панелі
		private void PictureBoxRefresh_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку оновлення даних
			SetDefaultSearchValues();
			SelectLabel(e);
		}
		private void SelectLabel(EventArgs e)
		{// Метод викликає обробник події з певними аргументами
			if (panelsInfo == PanelsInfo.Vacancy)
				LabelVAI_Click(labelVacancy, e);
			else if (panelsInfo == PanelsInfo.Application)
				LabelVAI_Click(labelApplication, e);
			else if (panelsInfo == PanelsInfo.Interview)
				LabelVAI_Click(labelInterview, e);
		}
		private void LabelVAI_Click(object sender, EventArgs e)
		{// Обробник події натискання на такі label-и: вакансії, заявки та співбесіди
			if (!(sender is Label label)) return;

			ClearMainPanel();// Налаштовуємо панель
			panelSearch.Visible = true;

			if (e != EventArgs.Empty)// Якщо НЕ шукаємо
			{
				searcher = null;
				SetDefaultSearchValues();
			}

			try
			{
				// Створюємо перші панелі
				if (label == labelVacancy) CreateFirstVacancies();
				else if (label == labelApplication) CreateFirstApplications();
				else if (label == labelInterview) CreateFirstInterviews();
			}
			catch (System.Net.Sockets.SocketException)
			{
				MessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
					"\nСпробуйте, будь ласка, пізніше.", "Помилка підключення",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			ShowEmptyLabel(countPanels == 0);// Якщо пусто - true, інакше - false
		}

		private void CreateFirstVacancies()
		{// Метод, який створює перші вакансії
			panelSalarySearch.Visible = true;
			if (panelsInfo == PanelsInfo.Application || panelsInfo == PanelsInfo.Interview)
				panelSearch.Size = new Size(panelSearch.Width, panelSearch.Height + PANEL_SEARCH_OFFSET);
			SetLabels(labelVacancy, labelApplication, labelInterview);
			currentPanelHeight = panelVacancy.Size.Height;
			if (comboBoxSortCount > comboBoxSort.Items.Count)
				comboBoxSort.Items.Add("За зарплатою");// Додаємо пункт сортування

			panelsInfo = PanelsInfo.Vacancy;
			countPanels = Client.GetCountVacancies(account.Login, searcher);
			CreateVacancies();
		}
		private void CreateFirstApplications()
		{// Метод, який створює перші заявки
			panelSalarySearch.Visible = false;
			if (panelsInfo == PanelsInfo.None || panelsInfo == PanelsInfo.Vacancy)
				panelSearch.Size = new Size(panelSearch.Width, panelSearch.Height - PANEL_SEARCH_OFFSET);
			SetLabels(labelApplication, labelVacancy, labelInterview);
			currentPanelHeight = panelApplication.Size.Height;
			if (comboBoxSortCount == comboBoxSort.Items.Count)// Видаляємо пункт сортування
				comboBoxSort.Items.RemoveAt(comboBoxSort.Items.Count - 1);

			panelsInfo = PanelsInfo.Application;
			countPanels = Client.GetCountApplications(account.Login, searcher);
			CreateApplications();
		}
		private void CreateFirstInterviews()
		{// Метод, який створює перші співбесіди
			panelSalarySearch.Visible = false;
			if (panelsInfo == PanelsInfo.None || panelsInfo == PanelsInfo.Vacancy)
				panelSearch.Size = new Size(panelSearch.Width, panelSearch.Height - PANEL_SEARCH_OFFSET);
			SetLabels(labelInterview, labelVacancy, labelApplication);
			currentPanelHeight = panelInterview.Size.Height;
			if (comboBoxSortCount == comboBoxSort.Items.Count)// Видаляємо пункт сортування
				comboBoxSort.Items.RemoveAt(comboBoxSort.Items.Count - 1);

			panelsInfo = PanelsInfo.Interview;
			countPanels = Client.GetCountInterviews(account.Login, searcher);
			CreateInterviews();
		}

		private void CreateVacancies()
		{// Метод, який створює на формі вакансії
			if (currentOffset >= countPanels)
				return;// Якщо не потрібно генерувати панелі

			// Отримуємо вакансії від серверу
			List<Vacancy> vacancies = Client.GetFreeVacancies(account.Login, currentOffset, COUNT_ON_PAGE, searcher);
			currentOffset += vacancies.Count;

			Panel[] panels = new Panel[vacancies.Count];
			for (int i = 0; i < vacancies.Count; i++)
			{// Створення вакансій
				Creator creator = new Creator(panelVacancy, flpMain, i + 1, false);
				panels[i] = creator.MainPanel;

				CreateVacancy(vacancies[i], creator);
			}
			ShowPanels(panels);
			panelsVAI.AddRange(panels);
		}
		private void CreateApplications()
		{// Метод, який створює на формі заявки
			if (currentOffset >= countPanels)
				return;// Якщо не потрібно генерувати панелі

			// Отримуємо заявки від серверу
			List<RecruitmentLibrary.ApplicationInfo.Application> applications = Client.GetApplications(account.Login, currentOffset, COUNT_ON_PAGE, searcher);
			currentOffset += applications.Count;

			Panel[] panels = new Panel[applications.Count];
			for (int i = 0; i < applications.Count; i++)
			{// Створення заявок
				Creator creator = new Creator(panelApplication, flpMain, i + 1, false);
				panels[i] = creator.MainPanel;

				CreateApplication(applications[i], creator);
			}
			ShowPanels(panels);
			panelsVAI.AddRange(panels);
		}
		private void CreateInterviews()
		{// Метод, який створює на формі співбесіди
			if (currentOffset >= countPanels)
				return;// Якщо не потрібно генерувати панелі

			// Отримуємо співбесіди від серверу
			List<Interview> interviews = Client.GetInterviews(account.Login, currentOffset, COUNT_ON_PAGE, searcher);
			currentOffset += interviews.Count;

			Panel[] panels = new Panel[interviews.Count];
			for (int i = 0; i < interviews.Count; i++)
			{// Створення співбесід
				Creator creator = new Creator(panelInterview, flpMain, i + 1, false);
				panels[i] = creator.MainPanel;

				CreateInterview(interviews[i], creator);
			}
			ShowPanels(panels);
			panelsVAI.AddRange(panels);
		}

		private void CreateVacancy(Vacancy vacancy, Creator creator)
		{// Метод, який створює одну вакансію
			creator.CreateLabel(labelPositionV, vacancy.Position.Name);
			creator.CreateLabel(labelPositionDescriptionV, vacancy.Position.Description);
			creator.CreateLabel(labelSalaryV, vacancy.Salary.ToString() + " грн.");
			creator.CreateLabel(labelDatePublicationV, "Опубліковано: " + GetStringDate(vacancy.DatePublication));

			// Підписання кнопки на обробники подій
			Button button = creator.CreateButton(buttonVacancy);
			AddEventVacancyButton_Click(button, vacancy);
			buttonEventHandlers.SubscribeToHover(button);
		}
		private void CreateApplication(RecruitmentLibrary.ApplicationInfo.Application application, Creator creator)
		{// Метод, який створює одну заявку
			creator.CreateLabel(labelPositionA, application.Position.Name);
			Label labelStatus = creator.CreateLabel(labelStatusA, application.Status);
			creator.CreateLabel(labelDateSubmissionA, "Дата і час подачі: " + GetStringDate(application.DateSubmission));
			PictureBox picture = creator.CreatePictureBox(pictureBoxApplication);

			// Вибор кольору статусу
			if (labelStatus.Text == "Прийнята")
				picture.BackColor = colorGreen;
			else if (labelStatus.Text == "Відхилена")
				picture.BackColor = colorRed;
			else if (labelStatus.Text == "В очікуванні")
				picture.BackColor = colorYellow1;
			else
				picture.BackColor = Color.Transparent;

			// Підписання кнопки на обробники подій
			string reason = application.ReasonRejection;
			if (reason != null && reason.Length > 0)
			{
				Button button = creator.CreateButton(buttonReasonRejectionA);
				button.Click += (s, args) =>
				{
					MessageBox.Show(reason, "Причина відмови",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				};
				buttonEventHandlers.SubscribeToHover(button);
			}
		}
		private void CreateInterview(Interview interview, Creator creator)
		{// Метод, який створює одну співбесіду
			creator.CreateLabel(labelPositionI, interview.Position.Name);
			Label labelStatus = creator.CreateLabel(labelStatusI, interview.Status);
			creator.CreateLabel(labelDateEventI, "Дата і час проведення: " + GetStringDate(interview.DateEvent));
			PictureBox picture = creator.CreatePictureBox(pictureBoxInterview);

			// Вибор кольору статусу
			if (labelStatus.Text == "Прийнято")
				picture.BackColor = colorGreen;
			else if (labelStatus.Text == "Не прийнято")
				picture.BackColor = colorRed;
			else if (labelStatus.Text == "Кандидат запрошений")
				picture.BackColor = colorYellow2;
			else if (labelStatus.Text == "Кандидат чекає на рішення")
				picture.BackColor = colorYellow1;
			else
				picture.BackColor = Color.Transparent;
		}

		private void AddEventVacancyButton_Click(Button button, Vacancy vacancy)
		{// Метод який підписується на подію натискання на кнопку
			button.Click += (s, args) =>
				{// Підписуємось на подію відкриття форми
					try
					{
						VacancyForm vf = new VacancyForm(vacancy, account.Login, SelectLabel, account.Theme);
						vf.ShowDialog();
					}
					catch (System.Net.Sockets.SocketException)
					{
						MessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
							"\nСпробуйте, будь ласка, пізніше.", "Помилка підключення",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				};
		}

		private string GetStringDate(DateTime date)
		{// Метод, який перетворює дату в рядок
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
		private void ShowPanels(Panel[] panels)
		{// Метод, який показує масив панелей
			for (int i = 0; i < panels.Length; i++)
				panels[i].Visible = true;
			FlpMain_Resize(flpMain, EventArgs.Empty);
		}
		private void SetLabels(Label labelShow, params Label[] labelsHide)
		{// Метод, який виділяє один label, та приховує інші
			const int INCREASE_SIZE = 2;// Розмір збільшення шрифту

			// Виділяємо
			float fontSize = labelShow.Font.Size;
			if (fontSize <= labelsHide[0].Font.Size)
				fontSize += INCREASE_SIZE;
			labelShow.Enabled = false;
			labelShow.Font = new Font(labelShow.Font.FontFamily, fontSize, labelShow.Font.Style);

			for (int i = 0; i < labelsHide.Length; i++)
			{// Приховуємо
				labelsHide[i].Enabled = true;

				fontSize = labelsHide[i].Font.Size;
				if (labelsHide[i].Font.Size >= labelShow.Font.Size)
					fontSize -= INCREASE_SIZE;
				labelsHide[i].Font = new Font(labelsHide[i].Font.FontFamily, fontSize, labelsHide[i].Font.Style);
			}
		}
		private void ShowEmptyLabel(bool isDataEmpty)// Метод приховує або показує
			=> labelEmpty.Visible = isDataEmpty;// повідомлення, що немає даних

		// Методи для пошуку інформації
		private void Search()
		{// Метод вибирає за пошуком
			SetSearcher();
			SelectLabel(EventArgs.Empty);
		}
		private void SetSearcher()
		{// Метод встановлює значення властивостей searcher
			int? minSalary = null, maxSalary = null;// Мін. та макс. зарплатня
			if (textBoxMinSalarySearch.Text != "")
				minSalary = Int32.Parse(textBoxMinSalarySearch.Text);
			if (textBoxMaxSalarySearch.Text != "")
				maxSalary = Int32.Parse(textBoxMaxSalarySearch.Text);
			if (minSalary != null && maxSalary != null && minSalary > maxSalary)
				MessageBox.Show("Мінімальна зарплата не може бути більше максимальної!",
					"Помилка пошуку", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			bool needToShowMB = true;
			string position = textBoxPositionSearch.Text;// Посада
			Validator.CheckBannedChar(new Label() { Text = "Посада" },
				position, Client.SEPARATOR, ref needToShowMB);

			ClientSortOption sortOption = ClientSortOption.Date;// Сортування
			if (comboBoxSort.SelectedIndex == 1)
				sortOption = ClientSortOption.Alphabet;
			else if (comboBoxSort.SelectedIndex == 2)
				sortOption = ClientSortOption.Salary;

			// Створюємо значення властивостей пошуку
			searcher = new ClientSearcher(position, GetFindDate(), minSalary, maxSalary, sortOption);
		}
		private DateTime? GetFindDate()
		{// Метод який повертає дату або null в залежності індексу comboBoxDate
			DateTime currentDate = DateTime.Now;
			if (comboBoxDate.SelectedIndex == 0)//За останні три дні
				return currentDate.AddDays(-3);
			else if (comboBoxDate.SelectedIndex == 1)//За останні тиждень
				return currentDate.AddDays(-7);
			else if (comboBoxDate.SelectedIndex == 2)//За останній місяць
				return currentDate.AddMonths(-1);
			else if (comboBoxDate.SelectedIndex == 3)//За останні три місяці
				return currentDate.AddMonths(-3);
			else if (comboBoxDate.SelectedIndex == 4)//За останній рік
				return currentDate.AddYears(-1);
			else
				return null;
		}

		// Інші обробники подій
		private void TextBoxSalarySearch_KeyPress(object sender, KeyPressEventArgs e)
		{// Обробник події вводу пошуку по зарплатні
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
				e.Handled = true;// Якщо не цифра та Backspace, то відміняємо введення
		}

		private void PanelMain_Scroll(object sender, ScrollEventArgs e)
		{// Обробник події прокрутки панелі 
			if (flpMain.VerticalScroll.Value + flpMain.Height >= flpMain.VerticalScroll.Maximum)
			{// Чи досягнуто кінець панелі по вертикалі
				flpMain.VerticalScroll.Enabled = false;
				try
				{
					if (panelsInfo == PanelsInfo.Vacancy)
						CreateVacancies();
					else if (panelsInfo == PanelsInfo.Application)
						CreateApplications();
					else if (panelsInfo == PanelsInfo.Interview)
						CreateInterviews();
				}
				catch (System.Net.Sockets.SocketException)
				{
					MessageBox.Show("Спроба підключитись до серверу завершилась не вдало." +
						"\nСпробуйте, будь ласка, пізніше.", "Помилка підключення",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{ flpMain.VerticalScroll.Enabled = true; }
			}
		}
		private void FlpMain_MouseWheel(object sender, MouseEventArgs e)
		{// Обробник події прокрутки колеса миші користувачем
			if (e.Delta < 0 && flpMain.VerticalScroll.Value > 0)
				PanelMain_Scroll(sender, EventArgs.Empty as ScrollEventArgs);
		}

		private void ButtonUp_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку, яка піднімається на одну панель
			int newValue = Math.Max(flpMain.VerticalScroll.Value - currentPanelHeight - 6, flpMain.VerticalScroll.Minimum);
			flpMain.AutoScrollPosition = new Point(0, newValue);
		}
		private void ButtonDown_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку, яка опускається на одну панель
			int newValue = Math.Min(flpMain.VerticalScroll.Value + currentPanelHeight + 6, flpMain.VerticalScroll.Maximum);
			flpMain.AutoScrollPosition = new Point(0, newValue);
			PanelMain_Scroll(sender, new ScrollEventArgs(ScrollEventType.SmallIncrement, newValue));
		}

		private void TextBoxPositionSearch_Leave(object sender, EventArgs e)
		{// Зміна пошуку посади
			string searcherText = searcher?.Position;
			TextBoxSearchLeave(textBoxPositionSearch.Text, searcherText);
		}
		private void TextBoxPositionSearch_KeyDown(object sender, KeyEventArgs e)
		{// Обробник події вводу пошуку позиції
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				Search();
				panelUp.Focus();
			}
		}
		private void TextBoxMinSalarySearch_Leave(object sender, EventArgs e)
		{// Зміна пошуку мінімальної зарплати
			string searcherText = searcher?.MinSalary.ToString();
			TextBoxSearchLeave(textBoxMinSalarySearch.Text, searcherText);
		}
		private void TextBoxMaxSalarySearch_Leave(object sender, EventArgs e)
		{// Зміна пошуку максимальної зарплати
			string searcherText = searcher?.MaxSalary.ToString();
			TextBoxSearchLeave(textBoxMaxSalarySearch.Text, searcherText);
		}
		private void TextBoxSearchLeave(string text, string searcherText)
		{// Метод який робить пошук після зміни textBox-у
			if (searcherText == null)
			{// Текст введено вперше
				if (text.Length == 0)// Якщо нічого не введено
					return;
				Search();
			}
			else if (searcherText != text)
				Search();// Текст відрізняється від попереднього
		}

		private void ComboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
		{// Зміна сортування
			if (searcher == null)
			{
				if (comboBoxSort.SelectedIndex == 0)
					return;
				Search();
			}
			else if ((byte)searcher.SortOption != comboBoxSort.SelectedIndex)
				Search();// Індекс відрізняється від попереднього
		}
		private void ComboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
		{// Зміна дати пошуку
			if (searcher == null)
			{
				if (comboBoxDate.SelectedIndex == DEFAULT_SEARCH_DATE)
					return;
				Search();
			}
			else if (currentDateIndex != comboBoxDate.SelectedIndex)
				Search();// Індекс відрізняється від попереднього
			currentDateIndex = comboBoxDate.SelectedIndex;
		}

		private void PictureBoxSearch_Click(object sender, EventArgs e)
		{ textBoxPositionSearch.Focus(); }
		private void FlpMain_Resize(object sender, EventArgs e)
		{// Обробник події зміни розміру панелі
			foreach (Control control in flpMain.Controls)
				if (control is Panel)
					control.Width = flpMain.ClientSize.Width - control.Margin.Horizontal - 6;
		}

		private void PictureBoxTheme_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку зміни теми
			if (account.Theme == Theme.White)// Якщо тема була світлою
				account.Theme = Theme.Black;
			else if (account.Theme == Theme.Black)// Якщо тема була темною
				account.Theme = Theme.White;

			SetTheme(account.Theme);
			if (Serializator.SerializationFileExists(Program.SerializePath))
				Serializator.Serialize(account, Program.SerializePath, Program.EncryptKey);
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelSalarySearch,
					labelSalarySearch2, labelEmpty, labelSalaryV,
					labelPositionDescriptionV, labelStatusA, labelStatusI,
				labelDatePublicationV, labelDateSubmissionA, labelDateEventI);
			ColorChanger.ChangeInputControlsColor(theme, textBoxPositionSearch,
				textBoxMinSalarySearch, textBoxMaxSalarySearch, comboBoxSort, comboBoxDate);
			ColorChanger.ChangeInputControlsForeColor(theme, panelSearch, labelVacancy,
				labelApplication, labelInterview, labelPositionV, labelPositionA, labelPositionI);

			if (theme == Theme.White)
			{// Якщо треба встановити світлу тему
				pictureBoxTheme.Image = Properties.Resources.sun;
				BackColor = ColorChanger.BackColorThemeW;
				flpMain.BackColor = Color.FromArgb(213, 213, 213);
				pictureBoxLine.BackColor = Color.Black;

				SetWhitePanels();

				pictureBoxPasswordChange.Image = Properties.Resources.keyB;
				pictureBoxRefresh.Image = Properties.Resources.refreshB;
				pictureBoxDown.Image = Properties.Resources.arrowDownB;
				pictureBoxUp.Image = Properties.Resources.arrowUpB;
				pictureBoxSearch.Image = Properties.Resources.loupeB;

			}
			else if (theme == Theme.Black)
			{// Якщо треба встановити темну тему
				pictureBoxTheme.Image = Properties.Resources.moon;
				BackColor = ColorChanger.BackColorThemeB;
				flpMain.BackColor = Color.FromArgb(32, 32, 32);
				pictureBoxLine.BackColor = Color.White;

				SetBlackPanels();

				pictureBoxPasswordChange.Image = Properties.Resources.keyW;
				pictureBoxRefresh.Image = Properties.Resources.refreshW;
				pictureBoxDown.Image = Properties.Resources.arrowDownW;
				pictureBoxUp.Image = Properties.Resources.arrowUpW;
				pictureBoxSearch.Image = Properties.Resources.loupeW;
			}
		}
		private void SetWhitePanels()
		{// Метод встановлює світлу тему для панелей: вакансій, заявок та співбесід
			const byte COLOR = 222;

			panelVacancy.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelApplication.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelInterview.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);

			foreach (Panel panel in panelsVAI)
			{
				panel.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
				foreach (Control control in panel.Controls)
					if (control is Label)
						control.ForeColor = ColorChanger.LabelColorThemeW;
			}
		}
		private void SetBlackPanels()
		{// Метод встановлює темну тему для панелей: вакансій, заявок та співбесід
			const byte COLOR = 37;

			panelVacancy.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelApplication.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelInterview.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);

			foreach (Panel panel in panelsVAI)
			{
				panel.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
				foreach (Control control in panel.Controls)
					if (control is Label)
						control.ForeColor = ColorChanger.LabelColorThemeB;
			}
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			pictureBoxEventHandlers.UnsubscribeAll();
			buttonEventHandlers.UnsubscribeAll();
		}
	}
}