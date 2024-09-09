using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using RecruitmentLibrary;
using RecruitmentLibrary.FormUtilities;
using RecruitmentLibrary.PersonInfo;
using ServerDB.DataModels;
using ServerDB.ServerUtilities;

namespace ServerDB.Forms
{
	internal enum PanelsInfo : byte
	{// Перелік, який вказує інформацію панелей
		None,
		Vacancy,
		Application,
		Interview,
		Employee
	}

	internal partial class MainForm : Form, IThemeChange
	{
		private const int COUNT_ON_PAGE = 10;// Кількість завантажуваних панелей
		private const int DEFAULT_SEARCH_DATE = 5;// Значення дати пошуку за замовчуванням

		private readonly ServerAccount account;// Акаунт
		private readonly Color colorGreen = Color.FromArgb(0, 109, 91);// Кольори для pictureBox-ів у заявках
		private readonly Color colorYellow1 = Color.FromArgb(255, 185, 97);
		private readonly Color colorYellow2 = Color.FromArgb(229, 158, 31);
		private readonly Color colorRed = Color.FromArgb(191, 34, 51);

		private PanelsInfo panelsInfo = PanelsInfo.None;// Змінна, яка зберігає інформацію про вид панелей
		private readonly List<Panel> createdPanels = new List<Panel>();// Панелі які були створені в процесі роботи
		private readonly PictureBoxEventHandlers pictureBoxEventHandlers = new PictureBoxEventHandlers();
		private readonly ButtonEventHandlers buttonEventHandlers = new ButtonEventHandlers();

		private int countPanels;// Загальна кількість панелей необхідних для відображення
		private int currentPanelHeight;// Висота поточної панелі
		private int currentOffset;// Кількість вже згенерованих панелей
		private int currentDateIndex;// Індекс поточної вибраної дати в пошуку
		private int currentStatusIndex;// Індекс поточного вибраного статусу
		private int currentSortIndex;// Індекс поточного вибраного параметру сортування

		private ServerSearcher searcher;// Змінна, яка зберігає інформацію про пошук

		internal MainForm(ServerAccount account)
		{// Конструктор
			_ = Server.StartAsync();
			InitializeComponent();
			this.account = account;

			flpMain.MouseWheel += FlpMain_MouseWheel;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{// Обробник події завантаження форми
			SetDefaultSearchValues();

			pictureBoxEventHandlers.SubscribeToHover(pictureBoxRefresh,
				pictureBoxDown, pictureBoxUp, pictureBoxTheme);
			buttonEventHandlers.SubscribeToHover(buttonAssignment, buttonAddVacancy);
			SetTheme(account.Theme);
		}

		private void ClearMainPanel()
		{// Метод очищає головну панель
			countPanels = 0;
			currentOffset = 0;

			createdPanels.Clear();// Очищаємо список
			Controls.Add(labelEmpty);// Переносимо label, щоб він не видалився
			flpMain.Controls.Clear();// Видаляємо елементи з панелі
			flpMain.Controls.Add(labelEmpty);// Повертаємо label назад
		}
		private void SetDefaultSearchValues()
		{// Метод встановлює пошуковим елементам початкові значення
			textBoxMin.Text = "";
			textBoxMax.Text = "";
			textBoxSearch.Text = "";
			comboBoxDate.SelectedIndex = DEFAULT_SEARCH_DATE;
			comboBoxSort.SelectedIndex = 0;
			comboBoxStatus.SelectedIndex = 0;
		}

		// Методи для відображення інформації в головній панелі
		private void PictureBoxRefresh_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку оновлення даних
			SetDefaultSearchValues();
			SelectLabel(e);
		}
		private void ButtonAssignment_Click(object sender, EventArgs e)
		{// Обробник події натискання на кнопку призначення кандидатів
			AssignmentForm af = new AssignmentForm(account, SelectLabel);
			af.ShowDialog();
		}
		private void SelectLabel(EventArgs e)
		{// Метод викликає обробник події з певними аргументами
			if (panelsInfo == PanelsInfo.Vacancy)
				LabelVAIE_Click(labelVacancy, e);
			else if (panelsInfo == PanelsInfo.Application)
				LabelVAIE_Click(labelApplication, e);
			else if (panelsInfo == PanelsInfo.Interview)
				LabelVAIE_Click(labelInterview, e);
			else if (panelsInfo == PanelsInfo.Employee)
				LabelVAIE_Click(labelEmployee, e);
		}
		private void LabelVAIE_Click(object sender, EventArgs e)
		{// Обробник події натискання на такі label-и: вакансії, заявки, співбесіди та співробітники
			if (!(sender is Label label)) return;

			ClearMainPanel();// Налаштовуємо панель
			panelSearch.Visible = true;

			if (e != EventArgs.Empty)// Якщо НЕ шукаємо
			{
				searcher = null;
				SetDefaultSearchValues();
			}

			// Створюємо перші панелі
			if (label == labelVacancy) CreateFirstVacancies();
			else if (label == labelApplication) CreateFirstApplications();
			else if (label == labelInterview) CreateFirstInterviews();
			else if (label == labelEmployee) CreateFirstEmployee();

			ShowEmptyLabel(countPanels == 0);// Якщо пусто - true, інакше - false
		}

		private void CreateFirstVacancies()
		{// Метод, який створює перші вакансії
			panelMinMax.Visible = true;
			labelMinMax.Text = "Кількість заявок: ";

			if (panelsInfo != PanelsInfo.Vacancy)
			{// Якщо до цього була інша панель
				labelStatus.Visible = false;
				comboBoxStatus.Visible = true;
				for (int i = 1; i < comboBoxStatus.Items.Count; i++)
					comboBoxStatus.Items.RemoveAt(i--);// Видаляємо всі елементи, окрім першого
				comboBoxStatus.Items[0] = "Всі";
				comboBoxStatus.Items.Add("НЕ актуальні");
				comboBoxStatus.Items.Add("Актуальні");

				for (int i = 2; i < comboBoxSort.Items.Count; i++)
					comboBoxSort.Items.RemoveAt(i--);// Видаляємо всі елементи, окрім перших двох
				comboBoxSort.Items.Add("За кількістю заявок");
			}

			SetLabels(labelVacancy, labelApplication, labelInterview, labelEmployee);
			currentPanelHeight = panelVacancy.Size.Height;

			panelsInfo = PanelsInfo.Vacancy;
			countPanels = DataBase.GetCountVacancies(searcher);
			CreateVacancies();
		}
		private void CreateFirstApplications()
		{// Метод, який створює перші заявки
			panelMinMax.Visible = true;
			labelMinMax.Text = "Кількість балів: ";

			if (panelsInfo != PanelsInfo.Application)
			{// Якщо до цього була інша панель
				labelStatus.Visible = true;
				comboBoxStatus.Visible = true;
				for (int i = 1; i < comboBoxStatus.Items.Count; i++)
					comboBoxStatus.Items.RemoveAt(i--);// Видаляємо всі елементи, окрім першого
				comboBoxStatus.Items[0] = "Всі";
				comboBoxStatus.Items.Add("Відхилена");
				comboBoxStatus.Items.Add("В очікуванні");
				comboBoxStatus.Items.Add("Прийнята");

				for (int i = 2; i < comboBoxSort.Items.Count; i++)
					comboBoxSort.Items.RemoveAt(i--);// Видаляємо всі елементи, окрім перших двох
				comboBoxSort.Items.Add("За кількістю балів");
			}

			SetLabels(labelApplication, labelVacancy, labelInterview, labelEmployee);
			currentPanelHeight = panelApplication.Size.Height;

			panelsInfo = PanelsInfo.Application;
			countPanels = DataBase.GetCountApplications(searcher);
			CreateApplications();
		}
		private void CreateFirstInterviews()
		{// Метод, який створює перші співбесіди
			panelMinMax.Visible = false;

			if (panelsInfo != PanelsInfo.Interview)
			{// Якщо до цього була інша панель
				labelStatus.Visible = true;
				comboBoxStatus.Visible = true;
				for (int i = 1; i < comboBoxStatus.Items.Count; i++)
					comboBoxStatus.Items.RemoveAt(i--);// Видаляємо всі елементи, окрім першого
				comboBoxStatus.Items[0] = "Всі";
				comboBoxStatus.Items.Add("Кандидат запрошений");
				comboBoxStatus.Items.Add("Кандидат чекає на рішення");
				comboBoxStatus.Items.Add("Прийнято");
				comboBoxStatus.Items.Add("Не прийнято");

				for (int i = 2; i < comboBoxSort.Items.Count; i++)
					comboBoxSort.Items.RemoveAt(i--);// Видаляємо всі елементи, окрім перших двох
			}

			SetLabels(labelInterview, labelVacancy, labelApplication, labelEmployee);
			currentPanelHeight = panelInterview.Size.Height;

			panelsInfo = PanelsInfo.Interview;
			countPanels = DataBase.GetCountInterviews(searcher);
			CreateInterviews();
		}
		private void CreateFirstEmployee()
		{// Метод, який створює перших співробітників
			panelMinMax.Visible = false;
			if (panelsInfo != PanelsInfo.Employee)
			{// Якщо до цього була інша панель
				labelStatus.Visible = false;
				comboBoxStatus.Visible = true;
				for (int i = 1; i < comboBoxStatus.Items.Count; i++)
					comboBoxStatus.Items.RemoveAt(i--);// Видаляємо всі елементи, окрім першого
				comboBoxStatus.Items[0] = "Пошук за посадою";
				comboBoxStatus.Items.Add("Пошук по ПІБ");

				for (int i = 2; i < comboBoxSort.Items.Count; i++)
					comboBoxSort.Items.RemoveAt(i--);// Видаляємо всі елементи, окрім перших двох
				comboBoxSort.Items.Add("За алфавітом (ПІБ)");
			}

			SetLabels(labelEmployee, labelVacancy, labelApplication, labelInterview);
			currentPanelHeight = panelEmployee.Size.Height;

			panelsInfo = PanelsInfo.Employee;
			countPanels = DataBase.GetCountEmployees(searcher);
			CreateEmployees();
		}

		private void CreateVacancies()
		{// Метод, який створює на формі вакансії
			if (currentOffset >= countPanels)
				return;// Якщо не потрібно генерувати панелі

			// Отримуємо вакансії від БД
			List<FullVacancy> vacancies = DataBase.GetVacancies(currentOffset, COUNT_ON_PAGE, searcher);
			currentOffset += vacancies.Count;

			Panel[] panels = new Panel[vacancies.Count];
			for (int i = 0; i < vacancies.Count; i++)
			{// Створення вакансій
				Creator creator = new Creator(panelVacancy, flpMain, i + 1, false);
				panels[i] = creator.MainPanel;

				CreateVacancy(vacancies[i], creator);
			}
			ShowPanels(panels);
			createdPanels.AddRange(panels);
		}
		private void CreateApplications()
		{// Метод, який створює на формі заявки
			if (currentOffset >= countPanels)
				return;// Якщо не потрібно генерувати панелі

			// Отримуємо заявки від БД
			List<FullApplication> applications = DataBase.GetApplications(currentOffset, COUNT_ON_PAGE, searcher);
			currentOffset += applications.Count;

			Panel[] panels = new Panel[applications.Count];
			for (int i = 0; i < applications.Count; i++)
			{// Створення заявок
				Creator creator = new Creator(panelApplication, flpMain, i + 1, false);
				panels[i] = creator.MainPanel;

				CreateApplication(applications[i], creator);
			}
			ShowPanels(panels);
			createdPanels.AddRange(panels);
		}
		private void CreateInterviews()
		{// Метод, який створює на формі співбесіди
			if (currentOffset >= countPanels)
				return;// Якщо не потрібно генерувати панелі

			// Отримуємо співбесіди від БД
			List<FullInterview> interviews = DataBase.GetInterviews(currentOffset, COUNT_ON_PAGE, searcher);
			currentOffset += interviews.Count;

			Panel[] panels = new Panel[interviews.Count];
			for (int i = 0; i < interviews.Count; i++)
			{// Створення співбесід
				Creator creator = new Creator(panelInterview, flpMain, i + 1, false);
				panels[i] = creator.MainPanel;

				CreateInterview(interviews[i], creator);
			}
			ShowPanels(panels);
			createdPanels.AddRange(panels);
		}
		private void CreateEmployees()
		{// Метод, який створює на формі співробітників
			if (currentOffset >= countPanels)
				return;// Якщо не потрібно генерувати панелі

			// Отримуємо співробітників від БД
			List<Employee> employees = DataBase.GetEmployees(currentOffset, COUNT_ON_PAGE, searcher);
			currentOffset += employees.Count;

			Panel[] panels = new Panel[employees.Count];
			for (int i = 0; i < employees.Count; i++)
			{// Створення співробітників
				Creator creator = new Creator(panelEmployee, flpMain, i + 1, false);
				panels[i] = creator.MainPanel;

				CreateEmployee(employees[i], creator);
			}
			ShowPanels(panels);
			createdPanels.AddRange(panels);
		}

		private void CreateVacancy(FullVacancy vacancy, Creator creator)
		{// Метод, який створює одну вакансію
			creator.CreateLabel(labelPositionV, vacancy.Position.Name);
			creator.CreateLabel(labelCountV, "Заявок: " + vacancy.ApplicationCount.ToString());

			string relevance = vacancy.Relevance ? "Актуальна" : "НЕ актуальна";// Актуальність
			creator.CreateLabel(labelRelevance, relevance);
			creator.CreateLabel(labelDatePublicationV, "Опубліковано: " + GetStringDate(vacancy.DatePublication));
			PictureBox picture = creator.CreatePictureBox(pictureBoxVacancy);
			if (relevance == "Актуальна")// Колір актуальності вакансії
				picture.BackColor = colorGreen;
			else if (relevance == "НЕ актуальна")
				picture.BackColor = colorYellow1;
			else
				picture.BackColor = Color.Transparent;

			// Підписання кнопки на обробники подій
			Button button = creator.CreateButton(buttonVacancy);
			AddEventVacancyButton_Click(button, vacancy);
			buttonEventHandlers.SubscribeToHover(button);
		}
		private void CreateApplication(FullApplication application, Creator creator)
		{// Метод, який створює одну заявку
			creator.CreateLabel(labelPositionA, application.Position.Name);
			creator.CreateLabel(labelScores, "Балів: " + application.Scores.ToString());

			Label label = creator.CreateLabel(labelStatusA, application.Status);// Статус
			PictureBox picture = creator.CreatePictureBox(pictureBoxApplication);
			if (label.Text == "Відхилена")// Колір статусу
				picture.BackColor = colorRed;
			else if (label.Text == "В очікуванні")
				picture.BackColor = colorYellow1;
			else if (label.Text == "Прийнята")
				picture.BackColor = colorGreen;
			else
				picture.BackColor = Color.Transparent;

			creator.CreateLabel(labelDateSubmissionA, "Дата і час подачі: " + GetStringDate(application.DateSubmission));

			// Підписання кнопки на обробники подій
			Button button = creator.CreateButton(buttonApplication);
			AddEventApplicationButton_Click(button, application);
			buttonEventHandlers.SubscribeToHover(button);
		}
		private void CreateInterview(FullInterview interview, Creator creator)
		{// Метод, який створює одну співбесіду
			creator.CreateLabel(labelPositionI, interview.Position.Name);
			Label labelStatus = creator.CreateLabel(labelStatusI, interview.Status);
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

			creator.CreateLabel(labelDateEventI, "Дата і час проведення: " + GetStringDate(interview.DateEvent));
			Button button = creator.CreateButton(buttonInterview);
			AddEventInterviewButton_Click(button, interview);
			buttonEventHandlers.SubscribeToHover(button);
		}
		private void CreateEmployee(Employee employee, Creator creator)
		{// Метод, який створює одного співробітника
			creator.CreateLabel(labelPositionE, employee.Position);
			creator.CreateLabel(labelFullName, $"{employee.Surname} {employee.Name} {employee.FatherName}");
			creator.CreateLabel(labelDateEmploymentE, "Дата працевлаштування: " + GetStringDate(employee.DateEmployment));
			Button button = creator.CreateButton(buttonEmployee);
			AddEventEmployeeButton_Click(button, employee);
			buttonEventHandlers.SubscribeToHover(button);
		}

		private void AddEventVacancyButton_Click(Button button, FullVacancy vacancy)
		{// Метод який підписується на подію натискання на вакансію
			button.Click += (s, args) =>
			{// Підписуємось на подію відкриття форми
				VacancyForm vf = new VacancyForm(vacancy, account, SelectLabel);
				vf.ShowDialog();
			};
		}
		private void AddEventApplicationButton_Click(Button button, FullApplication application)
		{// Метод який підписується на подію натискання на заявку
			button.Click += (s, args) =>
			{// Підписуємось на подію відкриття форми
				ApplicationForm af = new ApplicationForm(application, SelectLabel, account);
				af.ShowDialog();
			};
		}
		private void AddEventInterviewButton_Click(Button button, FullInterview interview)
		{// Метод який підписується на подію натискання на співбесіду
			button.Click += (s, args) =>
			{// Підписуємось на подію відкриття форми
				InterviewForm inf = new InterviewForm(interview, SelectLabel, account);
				inf.ShowDialog();
			};
		}
		private void AddEventEmployeeButton_Click(Button button, Employee employee)
		{// Метод який підписується на подію натискання на співробітника
			button.Click += (s, args) =>
				{// Підписуємось на подію відкриття форми
					EmployeeForm ef = new EmployeeForm(employee, SelectLabel, account);
					ef.ShowDialog();
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

			if (panelsInfo != PanelsInfo.Employee)
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
			int? min = null, max = null;// Мінімум та максимум
			if (textBoxMin.Text != "")
				min = Int32.Parse(textBoxMin.Text);
			if (textBoxMax.Text != "")
				max = Int32.Parse(textBoxMax.Text);
			if (min != null && max != null && min > max)
				MessageBox.Show("Мінімальне значення не може бути більше максимального!",
					"Помилка пошуку", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			bool? isRelevance = null;// Актуальність
			string status = null;// Статус
			string position = null;// Посада
			string fullName = null;// ПІБ
			if (panelsInfo == PanelsInfo.Employee)
			{// Якщо панель співробітника
				if (comboBoxStatus.SelectedIndex == 0)// Пошук за посадою
					position = textBoxSearch.Text;
				else// Пошук по ПІБ
					fullName = textBoxSearch.Text;
			}
			else
			{
				if (panelsInfo == PanelsInfo.Vacancy)
				{// Якщо панель вакансії
					if (comboBoxStatus.SelectedIndex == 1)
						isRelevance = false;
					else if (comboBoxStatus.SelectedIndex == 2)
						isRelevance = true;
				}

				if (!isRelevance.HasValue && comboBoxStatus.SelectedIndex != 0)
					status = comboBoxStatus.Items[comboBoxStatus.SelectedIndex].ToString();

				bool needToShowMB = true;
				position = textBoxSearch.Text;// Посада
				Validator.CheckBannedChar(new Label() { Text = "Посада" },
					position, Server.SEPARATOR, ref needToShowMB);
			}

			ServerSortOption sortOption = ServerSortOption.Date;// Сортування
			if (comboBoxSort.SelectedIndex == 1)
				sortOption = ServerSortOption.AlphabetPosition;
			else if (comboBoxSort.SelectedIndex == 2)
			{
				if (panelsInfo == PanelsInfo.Vacancy)
					sortOption = ServerSortOption.NumberOfApplications;
				else if (panelsInfo == PanelsInfo.Application)
					sortOption = ServerSortOption.NumberOfPoints;
				else if (panelsInfo == PanelsInfo.Employee)
					sortOption = ServerSortOption.AlphabetName;
			}

			// Створюємо значення властивостей пошуку
			searcher = new ServerSearcher(position, GetFindDate(), min, max, isRelevance, status, fullName, sortOption);
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
		private void TextBoxMinMaxSearch_KeyPress(object sender, KeyPressEventArgs e)
		{// Обробник події вводу пошуку по мінімуму та максимуму
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
				e.Handled = true;// Якщо не цифра та Backspace, то відміняємо введення
		}
		private void ButtonAddVacancy_Click(object sender, EventArgs e)
		{// Метод який створює нову вакансію
			VacancyForm vf = new VacancyForm(account, SelectLabel);
			vf.ShowDialog();
		}

		private void PanelMain_Scroll(object sender, ScrollEventArgs e)
		{// Обробник події прокрутки панелі 
			if (flpMain.VerticalScroll.Value + flpMain.Height >= flpMain.VerticalScroll.Maximum)
			{// Чи досягнуто кінець панелі по вертикалі
				flpMain.VerticalScroll.Enabled = false;

				if (panelsInfo == PanelsInfo.Vacancy)
					CreateVacancies();
				else if (panelsInfo == PanelsInfo.Application)
					CreateApplications();
				else if (panelsInfo == PanelsInfo.Interview)
					CreateInterviews();
				else if (panelsInfo == PanelsInfo.Employee)
					CreateEmployees();

				flpMain.VerticalScroll.Enabled = true;
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
			TextBoxSearchLeave(textBoxSearch.Text, searcherText);
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
		private void TextBoxMinSearch_Leave(object sender, EventArgs e)
		{// Зміна пошуку мінімального значення
			string searcherText = searcher?.Min.ToString();
			TextBoxSearchLeave(textBoxMin.Text, searcherText);
		}
		private void TextBoxMaxSearch_Leave(object sender, EventArgs e)
		{// Зміна пошуку максимального значення
			string searcherText = searcher?.Max.ToString();
			TextBoxSearchLeave(textBoxMax.Text, searcherText);
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
			{// Індекс вибрано вперше
				if (comboBoxSort.SelectedIndex == 0)
					return;
				Search();
			}
			else if (currentSortIndex != comboBoxSort.SelectedIndex)
				Search();// Індекс відрізняється від попереднього
			currentSortIndex = comboBoxDate.SelectedIndex;
		}
		private void ComboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
		{// Зміна дати пошуку
			if (searcher == null)
			{// Індекс вибрано вперше
				if (comboBoxDate.SelectedIndex == DEFAULT_SEARCH_DATE)
					return;
				Search();
			}
			else if (currentDateIndex != comboBoxDate.SelectedIndex)
				Search();// Індекс відрізняється від попереднього
			currentDateIndex = comboBoxDate.SelectedIndex;
		}
		private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
		{// Зміна статусу
			if (searcher == null)
			{// Індекс вибрано вперше
				if (comboBoxStatus.SelectedIndex == 0)
					return;
				Search();
			}
			else if (currentStatusIndex != comboBoxStatus.SelectedIndex)
				Search();// Індекс відрізняється від попереднього
			currentStatusIndex = comboBoxStatus.SelectedIndex;
		}
		private void PictureBoxSearch_Click(object sender, EventArgs e)
		{ textBoxSearch.Focus(); }
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
			Serializator.Serialize(account, Program.SerializePath, Program.EncryptKey);
		}

		public void SetTheme(Theme theme)
		{// Метод задає формі потрібну тему
			ColorChanger.ChangeLabelsForeColor(theme, labelMinMax,
					labelMinMax2, labelEmpty, labelCountV, labelFullName,
					labelRelevance, labelScores, labelStatus, labelStatusA, labelStatusI,
				labelDatePublicationV, labelDateSubmissionA, labelDateEventI, labelDateEmploymentE);
			ColorChanger.ChangeInputControlsColor(theme, textBoxSearch, textBoxMin, textBoxMax,
				comboBoxSort, comboBoxDate, comboBoxStatus);
			ColorChanger.ChangeInputControlsForeColor(theme, panelSearch, labelVacancy, labelApplication, labelInterview,
				labelEmployee, labelPositionV, labelPositionA, labelPositionI, labelPositionE);

			if (theme == Theme.White)
			{// Якщо треба встановити світлу тему
				pictureBoxTheme.Image = Properties.Resources.sun;
				BackColor = Color.FromArgb(220, 220, 220);
				flpMain.BackColor = Color.FromArgb(213, 213, 213);
				pictureBoxLine.BackColor = Color.Black;

				SetWhitePanels();

				pictureBoxRefresh.Image = Properties.Resources.refreshB;
				pictureBoxDown.Image = Properties.Resources.arrowDownB;
				pictureBoxUp.Image = Properties.Resources.arrowUpB;
				pictureBoxSearch.Image = Properties.Resources.loupeB;

			}
			else if (theme == Theme.Black)
			{// Якщо треба встановити темну тему
				pictureBoxTheme.Image = Properties.Resources.moon;
				BackColor = Color.FromArgb(35, 35, 35);
				flpMain.BackColor = Color.FromArgb(32, 32, 32);
				pictureBoxLine.BackColor = Color.White;

				SetBlackPanels();

				pictureBoxRefresh.Image = Properties.Resources.refreshW;
				pictureBoxDown.Image = Properties.Resources.arrowDownW;
				pictureBoxUp.Image = Properties.Resources.arrowUpW;
				pictureBoxSearch.Image = Properties.Resources.loupeW;
			}
		}
		private void SetWhitePanels()
		{// Метод встановлює темну тему для панелей: вакансій, заявок, співбесід та співробітників
			const byte COLOR = 222;

			panelVacancy.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelApplication.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelInterview.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelEmployee.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);


			foreach (Panel panel in createdPanels)
			{
				panel.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
				foreach (Control control in panel.Controls)
					if (control is Label)
						control.ForeColor = ColorChanger.LabelColorThemeW;
			}
		}
		private void SetBlackPanels()
		{// Метод встановлює темну тему для панелей: вакансій, заявок, співбесід та співробітників
			const byte COLOR = 37;

			panelVacancy.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelApplication.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelInterview.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);
			panelEmployee.BackColor = Color.FromArgb(COLOR, COLOR, COLOR);

			foreach (Panel panel in createdPanels)
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
			Server.Stop();
		}
	}
}