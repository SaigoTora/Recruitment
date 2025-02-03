using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

using SharedModels.Models;
using SharedModels.Models.Base;

namespace RecruitmentServer.Database
{
	internal static class DatabaseInitializer
	{
		private static RecruitmentEntities _context;

		internal static void Initialize(RecruitmentEntities context)
		{
			_context = context;

			bool parseResult = bool.TryParse(ConfigurationManager.AppSettings["seedData"],
				out bool shouldSeedData);
			if (!parseResult)
				shouldSeedData = false;

			if (shouldSeedData)
			{
				ClearDatabase();
				SeedDatabase();
			}
		}

		private static void ClearDatabase()
		{
			var dbSetProperties = _context.GetType().GetProperties().
				Where(p => p.PropertyType.IsGenericType
				&& p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)
				&& p.PropertyType.GetGenericArguments()[0].IsSubclassOf(typeof(EntityBase)))
				.ToList();

			foreach (dynamic property in dbSetProperties)
			{
				var dbSet = property.GetValue(_context);
				dbSet.RemoveRange(dbSet);
				ResetIndex(dbSet);

				_context.SaveChanges();
			}
		}
		private static void ResetIndex(DbSet dbSet)
		{
			var entityType = dbSet.GetType().GetGenericArguments()[0];

			var tableAttributes = entityType.GetCustomAttributes(typeof(TableAttribute),
				false) as TableAttribute[];

			// If the attribute exists, we take its name, otherwise we use the class name
			var tableName = tableAttributes?.FirstOrDefault()?.Name ?? entityType.Name;
			// Reset autoincrement for table
			int value = GetCurrentIdentity(tableName) != 1
				? 0
				: 1;
			_context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT ('{tableName}', RESEED, " +
				$"{value})");
		}
		private static decimal GetCurrentIdentity(string tableName)
		{
			var query = $"SELECT IDENT_CURRENT('{tableName}')";

			var result = _context.Database.SqlQuery<decimal>(query).FirstOrDefault();
			return result;
		}

		#region Seed Database
		private static void SeedDatabase()
		{
			SeedStaticData();
			InsertPositions();
			InsertHealth();
			InsertPoints();
			InsertEducationDegreePoints();
			InsertRequirements();
			InsertEducationDegreeRequirements();
			InsertVacancies();
			InsertQuestionnaires();
			InsertLanguages();
			InsertEducations();
			InsertCandidates();
			InsertApplications();
			InsertInterviews();
		}

		#region Seed static data
		private static void SeedStaticData()
		{
			InsertApplicationStatuses();
			InsertEducationForms();
			InsertEducationDegrees();
			InsertBusinessTripOpportunities();
			InsertFamilyStatuses();
			InsertInterviewStatuses();
		}

		private static void InsertApplicationStatuses()
		{
			_context.ApplicationStatuses.AddRange(new List<ApplicationStatus>
			{
				new ApplicationStatus("В очікуванні"),
				new ApplicationStatus("Прийнята"),
				new ApplicationStatus("Відхилена")
			});

			_context.SaveChanges();
		}
		private static void InsertEducationForms()
		{
			_context.EducationForms.AddRange(new List<EducationForm>
			{
				new EducationForm("Денна"),
				new EducationForm("Заочна")
			});

			_context.SaveChanges();
		}
		private static void InsertEducationDegrees()
		{
			_context.EducationDegrees.AddRange(new List<EducationDegree>
			{
				new EducationDegree("Молодший бакалавр"),
				new EducationDegree("Бакалавр"),
				new EducationDegree("Спеціаліст"),
				new EducationDegree("Магістр"),
				new EducationDegree("Доктор філософії")
			});

			_context.SaveChanges();
		}
		private static void InsertBusinessTripOpportunities()
		{
			_context.BusinessTripOpportunities.AddRange(new List<BusinessTripOpportunity>
			{
				new BusinessTripOpportunity("Часто"),
				new BusinessTripOpportunity("Іноді"),
				new BusinessTripOpportunity("Ніколи")
			});

			_context.SaveChanges();
		}
		private static void InsertFamilyStatuses()
		{
			_context.FamilyStatuses.AddRange(new List<FamilyStatus>
			{
				new FamilyStatus("Одружений(а)"),
				new FamilyStatus("Неодружений(а)"),
				new FamilyStatus("Розлучений(а)"),
				new FamilyStatus("Вдівець/вдова"),
				new FamilyStatus("Цивільний шлюб")
			});

			_context.SaveChanges();
		}
		private static void InsertInterviewStatuses()
		{
			_context.InterviewStatuses.AddRange(new List<InterviewStatus>
			{
				new InterviewStatus("Кандидат запрошений"),
				new InterviewStatus("Кандидат чекає на рішення"),
				new InterviewStatus("Прийнято"),
				new InterviewStatus("Не прийнято"),
			});

			_context.SaveChanges();
		}
		#endregion

		#region Seed application data
		private static void InsertPositions()
		{
			_context.Positions.AddRange(new List<Position>
			{
				new Position("Маркетинг-менеджер", "Планує та впроваджує маркетингові стратегії " +
				"для підвищення усвідомленості бренду, залучення нових клієнтів та збільшення " +
				"продажів. Відповідає за аналіз ринкових тенденцій, розробку рекламних кампаній " +
				"та управління онлайн та офлайн маркетинговими ініціативами."),
				new Position("Водій-міжнародник (дальнобійник)", "Здійснює міжнародні " +
				"вантажоперевезення: експорт, імпорт, а також перевезення вантажів по Європі."),
				new Position("Грузчик", "Завантажує та розвантажує товари з транспортних " +
				"засобів, розміщює вантажі на складі, пакує та розпаковує товари. " +
				"Грузчик повинен бути фізично витривалим, уважним та відповідальним, " +
				"здатним ефективно працювати в команді та дотримуватися стандартів безпеки " +
				"під час обробки вантажів."),
				new Position("C# Junior Розробник", "Розробляє та вдосконалює програмний код, " +
				"виправляє помилки, тестувує та впроваджує нові функцій. Вивчає кращі практики " +
				"програмування, стандарти коду та долучається до розробки згідно з вимогами та " +
				"специфікаціями проекту.")
			});

			_context.SaveChanges();
		}
		private static void InsertPoints()
		{
			_context.Points.AddRange(new List<Point>
			{
				new Point(4, 7, 2, 0, 0, 0, 3, 8, 4, 1, 0, 0, 1, 0),
				new Point(1, 6, 5, 2, 0, 3, 5, 5, 2, 2, 10, 0, 5, 7),
				new Point(4, 10, 5, 0, 5, 6, 7, 7, 2, 5, 0, 8, 7, 0),
				new Point(6, 8, 4, 3, 0, 5, 8, 8, 5, 2, 0, 1, 2, 1),
			});

			_context.SaveChanges();
		}
		private static void InsertEducationDegreePoints()
		{
			_context.EducationDegreePoints.AddRange(new List<EducationDegreePoint>
			{
				new EducationDegreePoint(2, 1, 3),
				new EducationDegreePoint(4, 1, 4),
				new EducationDegreePoint(6, 1, 5),
				new EducationDegreePoint(5, 2, 3),
				new EducationDegreePoint(4, 4, 2),
				new EducationDegreePoint(4, 4, 3),
				new EducationDegreePoint(6, 4, 4),
				new EducationDegreePoint(6, 4, 5)
			});

			_context.SaveChanges();
		}
		private static void InsertRequirements()
		{
			_context.Requirements.AddRange(new List<Requirement>
			{
				new Requirement("Харків", 20, 50, 12, true, false, false, true, false, false,
				null),
				new Requirement(null, 27, 65, 6, false, false, true, false, true, true, false),
				new Requirement(null, 20, 40, 0, true, true, false, true, false, false, true),
				new Requirement(null, 14, 30, 0, false, false, false, false, false, false, null)
			});

			_context.SaveChanges();
		}
		private static void InsertEducationDegreeRequirements()
		{
			_context.EducationDegreeRequirements.AddRange(new List<EducationDegreeRequirement>
			{
				new EducationDegreeRequirement(1, 3),
				new EducationDegreeRequirement(1, 4),
				new EducationDegreeRequirement(1, 5),
				new EducationDegreeRequirement(2, 3),
				new EducationDegreeRequirement(4, 2),
				new EducationDegreeRequirement(4, 3),
				new EducationDegreeRequirement(4, 4),
				new EducationDegreeRequirement(4, 5)
			});

			_context.SaveChanges();
		}
		private static void InsertVacancies()
		{
			_context.Vacancies.AddRange(new List<Vacancy>
			{
				new Vacancy(18000, new DateTime(2023, 12, 02, 12, 45, 25), "Маркетолог " +
				"відповідає за аналіз ринкових тенденцій, розробку рекламних кампаній та " +
				"управління онлайн та офлайн маркетинговими ініціативами.",1,1,1),
				new Vacancy(22000, new DateTime(2023, 12, 07, 14, 23, 04), null, 2, 2, 2),
				new Vacancy(12000, new DateTime(2023, 11, 17, 12, 27, 47), null, 3, 3, 3),
				new Vacancy(17500, new DateTime(2023, 12, 25, 13, 50, 34), "Ви будете " +
				"розробляти код, виправляти помилки, вдосконалювати функціональність та " +
				"співпрацювати з іншими відділами для забезпечення ефективної роботи програм. " +
				"Після працевлаштування ви отримаєте гарну зарплатню, дружній колектив, а також " +
				"можливість кар'єрного розвитку.",4,4,4)
			});

			_context.SaveChanges();
		}
		private static void InsertApplications()
		{
			_context.Applications.AddRange(new List<Application>
			{
				new Application(new DateTime(2023, 12,23, 14, 32, 47), null, 2, 1, 1),
				new Application(new DateTime(2023, 12, 25, 07, 22, 55),
				"У мене є великий стаж водіння.", 2, 2, 2),
				new Application(new DateTime(2023, 12, 10, 20, 47, 02), null, 2, 3, 3),
				new Application(new DateTime(2024, 01, 03, 15, 44, 15),
				"Маю гарні навички комунікації.", 2, 4, 4),
				new Application(new DateTime(2024, 01, 05, 17, 02, 42), null, 2, 5, 4),
				new Application(new DateTime(2023, 12, 28, 12, 06, 23), null, 3, 6, 4),
				new Application(new DateTime(2024, 01, 07, 10, 27, 49), null, 1, 7, 4)
			});

			_context.SaveChanges();
			foreach (Application application in _context.Applications)
				_context.Entry(application).Reload();
		}
		private static void InsertInterviews()
		{
			_context.Interviews.AddRange(new List<Interview>
			{
				new Interview(new DateTime(2024, 01, 05, 13, 30, 00), 1, 3),
				new Interview(new DateTime(2024, 01, 05, 14, 00, 00), 2, 3),
				new Interview(new DateTime(2023, 12, 17, 16, 00, 00), 3, 3),
				new Interview(new DateTime(2024, 01, 12, 15, 30, 00), 4, 4)
			});

			_context.SaveChanges();
			foreach (Vacancy vacancy in _context.Vacancies)
				_context.Entry(vacancy).Reload();
		}
		#endregion

		#region Seed candidate data
		private static void InsertHealth()
		{
			_context.Health.AddRange(new List<Health>
			{
				new Health(null, false, true),
				new Health("Діабет типу 2", true, false),
				new Health(null, false, false),
				new Health(null, false, false),
				new Health(null, false, true),
				new Health("Остеохондроз", true, true),
				new Health(null, false, true)
			});

			_context.SaveChanges();
		}
		private static void InsertQuestionnaires()
		{
			_context.Questionnaires.AddRange(new List<Questionnaire>
			{
				new Questionnaire("Україна", "Харків", 1, 18, false, 3, null, 1, 1, 3),
				new Questionnaire("Україна", "Харків", 2, 32, true, 12, "Вимагаю регулярних " +
				"вихідних, не менше 10 днів на місяць, для забезпечення збереження енергії та " +
				"ефективності на робочому місці.", 2, 1, 1),
				new Questionnaire("Україна", "Пісочин", 0, 0, false, 3, "Готовий внести свій " +
				"внесок в ваш колектив та забезпечити ефективну обробку вантажів, дотримуючись " +
				"всіх норм та правил безпеки.", 3, 2, 3),
				new Questionnaire("Україна", "Мала Данилівка", 0, 9, false, 7, "Вивчала також " +
				"Python, C++ та Java.", 4, 2, 2),
				new Questionnaire("Україна", "Дергачі", 0, 6, false, 1, "Є непогані " +
				"навички володіння C#, розуміння ООП та знання SQL.", 5, 2, 2),
				new Questionnaire("Україна", "Харків", 1, 0, false, 4, null, 6, 1, 3),
				new Questionnaire("Україна", "Березівка", 0, 0, true, 6, null, 7, 2, 3)
			});

			_context.SaveChanges();
		}
		private static void InsertLanguages()
		{
			_context.Languages.AddRange(new List<Language>
			{
				new Language("Українська", 9, 1),
				new Language("Російська", 7, 1),
				new Language("Українська", 8, 2),
				new Language("Англійська", 5, 2),
				new Language("Російська", 6, 2),
				new Language("Українська", 8, 3),
				new Language("Українська", 9, 4),
				new Language("Англійська", 5, 4),
				new Language("Російська", 7, 4),
				new Language("Українська", 8, 5),
				new Language("Англійська", 5, 5),
				new Language("Російська", 7, 5),
				new Language("Українська", 7, 6),
				new Language("Російська", 5, 6),
				new Language("Українська", 8, 7),
				new Language("Російська", 7, 7),
				new Language("Англійська", 5, 7),
				new Language("Німецька", 2, 7)
			});

			_context.SaveChanges();
		}
		private static void InsertEducations()
		{
			_context.Educations.AddRange(new List<Education>
			{
				new Education("ХНЕУ ім. С. Кузнеця", "Маркетинг", 2007, new DateTime(2013, 07, 14),
				1, 4, 1),
				new Education("Харківський фаховий коледж транспортних технологій",
				"Транспортний облік та експлуатація автомобільного транспорту", 1996,
				new DateTime(2001, 06, 24), 2, 3, 2),
				new Education("НЮУ ім. Ярослава Мудрого", "Менеджмент", 2021,
				new DateTime(2025, 06, 29), 3, 2, 1),
				new Education("НТУ \"ХПІ\"", "Кібербезпека", 2017, new DateTime(2021, 07, 11),
				4, 2, 2),
				new Education("НТУ \"ХПІ\"", "Прикладна математика", 2016,
				new DateTime(2020, 06, 29), 6, 2, 1),
				new Education("НТУ \"ХПІ\"", "Прикладна математика", 2020,
				new DateTime(2022, 01, 12), 6, 4, 2),
				new Education("ХНУРЕ", "Комп'ютерні науки", 2018, new DateTime(2022, 07, 05),
				7, 2, 1)
			});

			_context.SaveChanges();
		}
		private static void InsertCandidates()
		{
			_context.Candidates.AddRange(new List<Candidate>
			{
				new Candidate("Петренко", "Олена", "Сергіївна", "pTrnko23", "hwWgo59s",
					"+380661111111", new DateTime(1992, 05, 23), "petrenko456@gmail.com", 1),
				new Candidate("Іваненко", "Андрій", "Володимирович", "ivAneA79", "dfNnbl21k",
					"+380662222222", new DateTime(1979, 09, 17), "ivanenko123@gmail.com", 2),
				new Candidate("Ковальов", "Максим", "Ігорович", "ma_Kov2002", "20aw-l24",
					"+380953333333", new DateTime(2002, 12,10), "kovalm778@gmail.com", 3),
				new Candidate("Григоренко", "Юлія", "Олексіївна", "2000_gRig", "@pEpg5u8e",
					"+380954444444", new DateTime(2000, 04, 09), "hryhorenko321@gmail.com", 4),
				new Candidate("Ткаченко", "Віталій", "Васильович", "tkA4_2003", "abc3-@9gjg",
					"+380685555555", new DateTime(2003, 08, 04), "tkachenko654@gmail.com", 5),
				new Candidate("Шевченко", "Сергій", "Олександрович", "shev4k99", "@qwEr5Ty3",
					"+380686666666", new DateTime(1999, 03, 22), "shevchenko210@gmail.com", 6),
				new Candidate("Кравченко", "Анастасія", "Петрівна", "nst2001", "A.peg0bW2",
					"+380687777777", new DateTime(2001, 10, 21), "kravchenko543@gmail.com", 7)
			});

			_context.SaveChanges();
		}
		#endregion
		#endregion
	}
}