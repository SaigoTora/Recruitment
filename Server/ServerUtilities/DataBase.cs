using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using RecruitmentLibrary.ApplicationInfo;
using RecruitmentLibrary.PersonInfo;
using ServerDB.DataModels;

namespace ServerDB.ServerUtilities
{
    internal static class DataBase
    {
        // Рядок підключення
        private const string CONNECT_STR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RecruitmentDB.mdf;Integrated Security=True";
        internal static void ExecuteQuery(string commandStr)
        {// Метод, який виконує запит до БД
            SqlConnection connection = new SqlConnection(CONNECT_STR);
            connection.Open();// Відкриваємо підключення до БД
            SqlCommand command = new SqlCommand(commandStr, connection);
            command.ExecuteNonQuery();// Запускаємо команду
            connection.Close();// Закриваємо підключення
        }
        internal static DataTable ExecuteReturnQuery(string commandStr)
        {// Метод, який виконує запит до БД та повертає таблицю
            SqlConnection connection = new SqlConnection(CONNECT_STR);
            connection.Open();// Відкриваємо підключення до БД
            SqlCommand command = new SqlCommand(commandStr, connection);
            SqlDataReader reader = command.ExecuteReader();// Запускаємо команду
            DataTable table = new DataTable();
            table.Load(reader);
            connection.Close();// Закриваємо підключення
            return table;
        }


        // Методи для створення даних
        internal static void CreateVacancy(FullVacancy vacancy)
        {// Створення вакансії
            // Створюємо посаду
            string description = "NULL";// Опис посади
            if (vacancy.Position.Description != null && vacancy.Position.Description.Length > 0)
                description = $"'{vacancy.Position.Description}'";
            ExecuteQuery($"INSERT INTO Position(name,description) values('{vacancy.Position.Name}',{description})");

            // Створюємо вакансію
            DataTable dt = ExecuteReturnQuery($"SELECT TOP 1 id FROM Position ORDER BY id DESC");
            int idPosition = GetIntItem(dt, 0, 0);

            string salary = vacancy.Salary.ToString();// Зарплата
            salary = salary.Replace(',', '.');
            string info = "NULL";// Інформація
            if (vacancy.Info != null && vacancy.Info.Length > 0)
                info = $"'{vacancy.Info}'";
            ExecuteQuery($"INSERT INTO Vacancy(salary,date_publication,info,id_point,id_requirement,id_position) " +
                $"values({salary},'{vacancy.DatePublication:yyyy-MM-dd HH:mm:ss}',{info},{vacancy.IdPoint},{vacancy.IdRequirement},{idPosition})");
        }
        internal static int CreateRequirement(FullRequirement requirement)
        {// Метод створює вимоги та повертає id
            string city = "NULL";
            if (requirement.City != null && requirement.City.Length > 0)
                city = $"'{requirement.City}'";

            string student;
            if (requirement.Student == null)
                student = "NULL";
            else if (requirement.Student == true)
                student = "'True'";
            else
                student = "'False'";

            // Створення вимог
            ExecuteQuery($"INSERT INTO Requirement(city,age_min,age_max,exp_min,diploma,no_chronic_diseases,driver_license,no_smoker," +
                $"no_drink_alcohol,business_trip_opportunity,student) " +
                $"values({city},{requirement.AgeMin},{requirement.AgeMax},{requirement.ExpMin}," +
                $"'{requirement.Diploma}','{requirement.NoChronicDiseases}','{requirement.DriverLicense}','{requirement.NoSmoker}'," +
                $"'{requirement.NoDrinkAlcohol}','{requirement.BusinessTripOpportunity}',{student})");

            // Створення вимог до ступенів освіти
            DataTable dt = ExecuteReturnQuery($"SELECT TOP 1 id FROM Requirement ORDER BY id DESC");
            int idRequirement = GetIntItem(dt, 0, 0);
            string command = string.Empty;
            for (int i = 0; i < requirement.IdDegrees.Count; i++)
                command += $"INSERT INTO EducationDegree_Requirement(id_requirement,id_education_degree) " +
                $"values({idRequirement},{requirement.IdDegrees[i]}) ";
            if (command != string.Empty)
                ExecuteQuery(command);

            return idRequirement;
        }
        internal static int CreatePoints(Points points)
        {// Метод створює бали та повертає id
            // Створення балів
            ExecuteQuery($"INSERT INTO Point(age_under_18,age_18_30,age_30_50,age_over_50,exp_none,exp_under_year,exp_1_3,exp_over_3,diploma," +
                $"no_chronic_diseases,driver_license,no_smoker,no_drink_alcohol,business_trip_opportunity) " +
                $"values({points.AgeUnder18},{points.Age18_30},{points.Age30_50},{points.AgeOver50},{points.ExpNone}," +
                $"{points.ExpUnderYear},{points.Exp1_3},{points.ExpOver3},{points.Diploma},{points.NoChronicDiseases}," +
                $"{points.DriverLicense},{points.NoSmoker},{points.NoDrinkAlcohol},{points.BusinessTripOpportunity})");

            // Створення кількість балів до ступенів освіти
            DataTable dt = ExecuteReturnQuery($"SELECT TOP 1 id FROM Point ORDER BY id DESC");
            int idPoints = GetIntItem(dt, 0, 0);
            string command = string.Empty;

            if (points.Degrees != null)
            {
                for (int i = 0; i < points.Degrees.Length; i++)
                    if (points.Degrees[i].Point != 0)
                        command += $"INSERT INTO EducationDegree_Point(points,id_point,id_education_degree) " +
                            $"values({points.Degrees[i].Point},{idPoints},{points.Degrees[i].IdDegree}) ";
                if (command != string.Empty)
                    ExecuteQuery(command);
            }

            return idPoints;
        }
        internal static void CreateInterview(int idApplication, DateTime dateTime)
        {// Метод створює співбесіду
            ExecuteQuery($"INSERT INTO Interview(date_event,id_application,id_interview_status) " +
                $"values('{dateTime:yyyy-MM-dd} {dateTime:HH:mm:ss}',{idApplication},1)");
        }

        // Методи для отримання даних
        private static string GetItem(DataTable dataTable, int row, int column)
        => dataTable.Rows[row].ItemArray[column].ToString();
        private static int GetIntItem(DataTable dataTable, int row, int column)
    => int.Parse(GetItem(dataTable, row, column));
        private static DateTime GetDateTimeItem(DataTable dataTable, int row, int column)
=> DateTime.Parse(GetItem(dataTable, row, column)).ToLocalTime();
        private static DateTime GetDateItem(DataTable dataTable, int row, int column)
=> DateTime.Parse(GetItem(dataTable, row, column));
        private static bool GetBoolItem(DataTable dataTable, int row, int column)
=> bool.Parse(GetItem(dataTable, row, column));

        internal static int GetCountVacancies(ServerSearcher searcher)
        {// Метод повертає кількість вакансій
            string condition = string.Empty;
            if (searcher != null)
                condition = $" WHERE {searcher.GetFilter("date_publication", "application_count")}";
            DataTable dt = ExecuteReturnQuery($"SELECT COUNT(id) as id FROM View_Vacancy{condition}");

            return GetIntItem(dt, 0, 0);
        }
        internal static List<FullVacancy> GetVacancies(int offset, int amount, ServerSearcher searcher)
        {// Метод, який повертає список вакансій
            List<FullVacancy> vacancies = new List<FullVacancy>();
            string condition = string.Empty, orderBy;
            if (searcher != null)
            {
                condition = $"WHERE {searcher.GetFilter("date_publication", "application_count")} ";
                orderBy = searcher.GetSort("date_publication");
            }
            else
            { orderBy = "ORDER BY date_publication DESC"; }

            DataTable dt = ExecuteReturnQuery($"SELECT id,position_name,position_description,salary,date_publication,info,relevance,application_count,id_point,id_requirement " + $"FROM View_Vacancy {condition}{orderBy} " +
                $"OFFSET {offset} ROWS FETCH NEXT {amount} ROWS ONLY");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Записуємо елемент
                vacancies.Add(new FullVacancy(GetIntItem(dt, i, 0),
                    new Position(GetItem(dt, i, 1), GetItem(dt, i, 2)),
                    double.Parse(GetItem(dt, i, 3)), GetDateTimeItem(dt, i, 4), GetItem(dt, i, 5),
                    GetBoolItem(dt, i, 6), GetIntItem(dt, i, 7), GetIntItem(dt, i, 8),
                    GetIntItem(dt, i, 9)));
            }

            return vacancies;
        }
        internal static FullVacancy GetVacancy(int idVacancy)
        {// Метод, який повертає вакансію за кодом
            DataTable dt = ExecuteReturnQuery($"SELECT id,position_name,position_description,salary,date_publication,info,relevance,application_count,id_point,id_requirement " + $"FROM View_Vacancy WHERE id = {idVacancy}");

            // Записуємо елемент
            FullVacancy vacancy = new FullVacancy(GetIntItem(dt, 0, 0),
                new Position(GetItem(dt, 0, 1), GetItem(dt, 0, 2)),
                double.Parse(GetItem(dt, 0, 3)), GetDateTimeItem(dt, 0, 4), GetItem(dt, 0, 5),
                GetBoolItem(dt, 0, 6), GetIntItem(dt, 0, 7), GetIntItem(dt, 0, 8),
                GetIntItem(dt, 0, 9));

            return vacancy;
        }

        internal static int GetCountApplications(ServerSearcher searcher)
        {// Метод повертає кількість заявок
            string condition = string.Empty;
            if (searcher != null)
                condition = $" WHERE {searcher.GetFilter("date_submission", "scores")}";
            DataTable dt = ExecuteReturnQuery($"SELECT COUNT(id) as id FROM View_Application{condition}");

            return GetIntItem(dt, 0, 0);
        }
        internal static List<FullApplication> GetApplications(int offset, int amount, ServerSearcher searcher)
        {// Метод, який повертає список заявок
            List<FullApplication> applications = new List<FullApplication>();
            string condition = string.Empty, orderBy;
            if (searcher != null)
            {
                condition = $"WHERE {searcher.GetFilter("date_submission", "scores")} ";
                orderBy = searcher.GetSort("date_submission");
            }
            else
            { orderBy = "ORDER BY date_submission DESC"; }

            DataTable dt = ExecuteReturnQuery($"SELECT id,position_name,position_description,status," +
                $"date_submission,reason_rejection,scores,additional_info,id_candidate,id_vacancy " +
                $"FROM View_Application {condition}{orderBy} " +
                $"OFFSET {offset} ROWS FETCH NEXT {amount} ROWS ONLY");

            Position position;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                position = new Position(GetItem(dt, i, 1), GetItem(dt, i, 2));
                // Записуємо елемент
                applications.Add(new FullApplication(GetIntItem(dt, i, 0), position, GetItem(dt, i, 3),
                    GetDateTimeItem(dt, i, 4), GetItem(dt, i, 5), GetIntItem(dt, i, 6),
                    GetItem(dt, i, 7), GetIntItem(dt, i, 8), GetIntItem(dt, i, 9)));
            }

            return applications;
        }
        internal static FullApplication GetApplication(int idApplication)
        {// Метод, який повертає заявку за кодом
            DataTable dt = ExecuteReturnQuery($"SELECT id,position_name,position_description,status," +
    $"date_submission,reason_rejection,scores,additional_info,id_candidate,id_vacancy " +
    $"FROM View_Application WHERE id = {idApplication}");

            Position position = new Position(GetItem(dt, 0, 1), GetItem(dt, 0, 2));

            FullApplication application = new FullApplication(GetIntItem(dt, 0, 0), position, GetItem(dt, 0, 3),
                GetDateTimeItem(dt, 0, 4), GetItem(dt, 0, 5), GetIntItem(dt, 0, 6),
                GetItem(dt, 0, 7), GetIntItem(dt, 0, 8), GetIntItem(dt, 0, 9));

            return application;
        }
        internal static FullApplication GetApplication(int idVacancy, int idCandidate)
        {// Метод, який повертає заявку за кодом вакансії та кандидата
            DataTable dt = ExecuteReturnQuery($"SELECT id,position_name,position_description,status," +
    $"date_submission,reason_rejection,scores,additional_info,id_candidate,id_vacancy " +
    $"FROM View_Application WHERE id_vacancy = {idVacancy} AND id_candidate = {idCandidate}");

            Position position = new Position(GetItem(dt, 0, 1), GetItem(dt, 0, 2));

            FullApplication application = new FullApplication(GetIntItem(dt, 0, 0), position, GetItem(dt, 0, 3),
                GetDateTimeItem(dt, 0, 4), GetItem(dt, 0, 5), GetIntItem(dt, 0, 6),
                GetItem(dt, 0, 7), GetIntItem(dt, 0, 8), GetIntItem(dt, 0, 9));

            return application;
        }

        internal static Candidate GetCandidate(int idCandidate)
        {// Метод, який повертає кандидата за кодом
            DataTable dt = ExecuteReturnQuery($"SELECT surname,name,father_name,phone,birthday,email, " +
            $"nationality,city,children_amount,experience,driver_license,readiness,additional_info, " +
            $"chronic_diseases,smoker,drink_alcohol, " +
            $"id_family_status,id_business_trip_opportunity " +
            $"FROM Candidate " +
            $"INNER JOIN Questionnaire ON Questionnaire.id = Candidate.id_questionnaire " +
            $"INNER JOIN Health ON Health.id = Questionnaire.id_health " +
            $"WHERE Candidate.id = {idCandidate}");


            Health h = new Health(GetItem(dt, 0, 13), GetBoolItem(dt, 0, 14), GetBoolItem(dt, 0, 15));
            Questionnaire q = new Questionnaire(GetItem(dt, 0, 6), GetItem(dt, 0, 7),// Анкета
                GetIntItem(dt, 0, 8), GetIntItem(dt, 0, 9), GetBoolItem(dt, 0, 10),
                GetIntItem(dt, 0, 11), GetItem(dt, 0, 12), h,
                GetIntItem(dt, 0, 16), GetIntItem(dt, 0, 17),
                GetLanguages(idCandidate), GetEducations(idCandidate));

            return new Candidate(GetItem(dt, 0, 0), GetItem(dt, 0, 1), GetItem(dt, 0, 2), GetItem(dt, 0, 3), GetDateItem(dt, 0, 4), GetItem(dt, 0, 5), q);
        }
        internal static List<Language> GetLanguages(int idCandidate)
        {// Метод повертає список мов кандидата
            DataTable dt = ExecuteReturnQuery($"SELECT name,level " +
                $"FROM Language " +
                $"WHERE Language.id_questionnaire = " +
                $"(SELECT id FROM Questionnaire " +
                $"WHERE Questionnaire.id = " +
                $"(SELECT id_questionnaire FROM Candidate " +
                $"WHERE Candidate.id = {idCandidate}))");

            List<Language> languages = new List<Language>();
            for (int i = 0; i < dt.Rows.Count; i++)
                languages.Add(new Language(GetItem(dt, i, 0), GetIntItem(dt, i, 1)));

            return languages;
        }
        internal static List<Education> GetEducations(int idCandidate)
        {// Метод повертає список освіт кандидата
            DataTable dt = ExecuteReturnQuery($"SELECT name_institution,specialty,year_admission,date_end, " +
                $"id_education_degree,id_education_form " +
                $"FROM Education WHERE Education.id_questionnaire = " +
                $"(SELECT id FROM Questionnaire " +
                $"WHERE Questionnaire.id = " +
                $"(SELECT id_questionnaire FROM Candidate " +
                $"WHERE Candidate.id = {idCandidate}))");

            List<Education> educations = new List<Education>();

            for (int i = 0; i < dt.Rows.Count; i++)
                educations.Add(new Education(GetItem(dt, i, 0), GetItem(dt, i, 1),
                    GetIntItem(dt, i, 2), GetDateItem(dt, i, 3),
                    GetIntItem(dt, i, 4), GetIntItem(dt, i, 5)));

            return educations;

        }

        internal static Requirement GetRequirement(int idRequirement)
        {// Метод, який повертає вимоги
            DataTable dt = ExecuteReturnQuery($"SELECT city,age_min,age_max," +
                $"exp_min,diploma,no_chronic_diseases,driver_license,no_smoker," +
                $"no_drink_alcohol,business_trip_opportunity,student" +
                $" FROM Requirement WHERE Requirement.id = {idRequirement}");

            string city = GetItem(dt, 0, 0) == string.Empty ? null : GetItem(dt, 0, 0);
            bool? student;// Знаходимо вимогу "student"
            if (GetItem(dt, 0, 10) == "")
                student = null;
            else
                student = GetBoolItem(dt, 0, 10);


            Requirement requirement = new Requirement(city, byte.Parse(GetItem(dt, 0, 1)),
                byte.Parse(GetItem(dt, 0, 2)), GetIntItem(dt, 0, 3), GetBoolItem(dt, 0, 4), GetBoolItem(dt, 0, 5),
                GetBoolItem(dt, 0, 6), GetBoolItem(dt, 0, 7), GetBoolItem(dt, 0, 8),
                GetBoolItem(dt, 0, 9), student);

            return requirement;
        }
        internal static string GetRequirementEducationDegree(int idRequirement)
        {// Метод, який повертає вимоги до ступенів освіт
            DataTable dt = ExecuteReturnQuery($"SELECT degree FROM Education_Degree " +
                $"WHERE id IN (SELECT id_education_degree " +
                $"FROM EducationDegree_Requirement WHERE id_requirement = {idRequirement})");

            string s = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
                s += $"{GetItem(dt, i, 0)}, ";

            return s.TrimEnd(' ').TrimEnd(',').ToLower();

        }
        internal static Points GetPoints(int idPoint)
        {// Метод, який повертає бали
            DataTable dt = ExecuteReturnQuery($"SELECT id_education_degree,points FROM EducationDegree_Point " +
                $"WHERE id_point = {idPoint}");
            PointDegree[] degrees = new PointDegree[dt.Rows.Count];
            for (int i = 0; i < degrees.Length; i++)
                degrees[i] = new PointDegree(GetIntItem(dt, i, 0), GetIntItem(dt, i, 1));


            dt = ExecuteReturnQuery($"SELECT age_under_18,age_18_30,age_30_50,age_over_50," +
                $"exp_none,exp_under_year,exp_1_3,exp_over_3,diploma,no_chronic_diseases,driver_license," +
                $"no_smoker,no_drink_alcohol,business_trip_opportunity FROM Point WHERE id = {idPoint}");

            Points points = new Points();
            points.Change(GetIntItem(dt, 0, 0), GetIntItem(dt, 0, 1), GetIntItem(dt, 0, 2), GetIntItem(dt, 0, 3),
                GetIntItem(dt, 0, 4), GetIntItem(dt, 0, 5), GetIntItem(dt, 0, 6), GetIntItem(dt, 0, 7),
                GetIntItem(dt, 0, 8), GetIntItem(dt, 0, 9), GetIntItem(dt, 0, 10), GetIntItem(dt, 0, 11),
                GetIntItem(dt, 0, 12), GetIntItem(dt, 0, 13), degrees);

            return points;
        }

        internal static int GetCountInterviews(ServerSearcher searcher)
        {// Метод повертає кількість співбесід
            string condition = string.Empty;
            if (searcher != null)
                condition = $" WHERE {searcher.GetFilter("date_event", string.Empty)}";
            DataTable dt = ExecuteReturnQuery($"SELECT COUNT(id) as id FROM View_Interview{condition}");

            return GetIntItem(dt, 0, 0);
        }
        internal static List<FullInterview> GetInterviews(int offset, int amount, ServerSearcher searcher)
        {// Метод, який повертає список співбесід
            List<FullInterview> interviews = new List<FullInterview>();
            string condition = string.Empty, orderBy;
            if (searcher != null)
            {
                condition = $"WHERE {searcher.GetFilter("date_event", string.Empty)} ";
                orderBy = searcher.GetSort("date_event");
            }
            else
            { orderBy = "ORDER BY date_event DESC"; }

            DataTable dt = ExecuteReturnQuery($"SELECT id,position_name,position_description," +
                $"status,date_event,id_application " +
                $"FROM View_Interview {condition}{orderBy} " +
                $"OFFSET {offset} ROWS FETCH NEXT {amount} ROWS ONLY");

            Position position;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                position = new Position(GetItem(dt, i, 1), GetItem(dt, i, 2));
                // Записуємо елемент
                interviews.Add(new FullInterview(GetIntItem(dt, i, 0), position, GetItem(dt, i, 3),
                    GetDateTimeItem(dt, i, 4), GetIntItem(dt, i, 5)));
            }

            return interviews;
        }

        internal static int GetCountEmployees(ServerSearcher searcher)
        {// Метод повертає кількість співробітників
            string condition = string.Empty;
            if (searcher != null)
                condition = $" WHERE {searcher.GetFilter("date_employment", string.Empty)}";
            DataTable dt = ExecuteReturnQuery($"SELECT COUNT(id) as id FROM Employee{condition}");

            return GetIntItem(dt, 0, 0);
        }
        internal static List<Employee> GetEmployees(int offset, int amount, ServerSearcher searcher)
        {// Метод, який повертає список співробітників
            List<Employee> employees = new List<Employee>();
            string condition = string.Empty, orderBy;
            if (searcher != null)
            {
                condition = $"WHERE {searcher.GetFilter("date_employment", string.Empty)} ";
                orderBy = searcher.GetSort("date_employment");
            }
            else
            { orderBy = "ORDER BY date_employment DESC"; }

            DataTable dt = ExecuteReturnQuery($"SELECT id, surname, name, father_name,phone," +
                $"birthday,email,position_name,city,salary,date_employment " +
                $"FROM Employee {condition}{orderBy} " +
                $"OFFSET {offset} ROWS FETCH NEXT {amount} ROWS ONLY");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Записуємо елемент
                employees.Add(new Employee(GetIntItem(dt, i, 0), GetItem(dt, i, 1), GetItem(dt, i, 2), GetItem(dt, i, 3),
                    GetItem(dt, i, 4), GetDateItem(dt, i, 5), GetItem(dt, i, 6), GetItem(dt, i, 7),
                    GetItem(dt, i, 8), Double.Parse(GetItem(dt, i, 9)), GetDateItem(dt, i, 10)));
            }

            return employees;
        }
        internal static Employee GetEmployee(int idInterview)
        {// Метод, який повертає співробітника за кодом
            DataTable dt = ExecuteReturnQuery($"SELECT id, surname, name, father_name,phone," +
    $"birthday,email,position_name,city,salary,date_employment " +
    $"FROM Employee WHERE id_interview = {idInterview}");

            Employee employee = new Employee(GetIntItem(dt, 0, 0), GetItem(dt, 0, 1), GetItem(dt, 0, 2), GetItem(dt, 0, 3),
                    GetItem(dt, 0, 4), GetDateItem(dt, 0, 5), GetItem(dt, 0, 6), GetItem(dt, 0, 7),
                    GetItem(dt, 0, 8), Double.Parse(GetItem(dt, 0, 9)), GetDateItem(dt, 0, 10));

            return employee;
        }

        internal static string GetBusinessTrip(int idBusinessTrip)
        {// Метод повертає можливість відряджень за кодом
            DataTable dt = ExecuteReturnQuery($"SELECT opportunity " +
                $"FROM Business_Trip_Opportunity WHERE id = {idBusinessTrip}");
            return GetItem(dt, 0, 0);
        }
        internal static string GetFamilyStatus(int idFamilyStatus)
        {// Метод повертає сімейний стан за кодом
            DataTable dt = ExecuteReturnQuery($"SELECT status " +
                $"FROM Family_Status WHERE id = {idFamilyStatus}");
            return GetItem(dt, 0, 0);
        }
        internal static string GetEducationDegree(int idEducationDegree)
        {// Метод повертає ступінь освіти за кодом
            DataTable dt = ExecuteReturnQuery($"SELECT degree " +
                $"FROM Education_Degree WHERE id = {idEducationDegree}");
            return GetItem(dt, 0, 0);
        }
        internal static string GetEducationForm(int idEducationForm)
        {// Метод повертає форму навчання за кодом
            DataTable dt = ExecuteReturnQuery($"SELECT form " +
                $"FROM Education_Form WHERE id = {idEducationForm}");
            return GetItem(dt, 0, 0);
        }

        internal static AssignmentItem[] GetAssignmentItems()
        {// Метод повертає масив призначення
            // НЕ беремо ті заявки, в вакансіях яких є хоча б одна співбесіда
            // зі статусом "Кандидат запрошений" або "Кандидат чекає на рішення"
            DataTable dt = ExecuteReturnQuery("SELECT Vacancy.id, View_Application.id_candidate, scores " +
                "FROM Vacancy " +
                "INNER JOIN View_Application ON View_Application.id_vacancy = Vacancy.id " +
                "WHERE relevance = 'True' AND View_Application.status = 'В очікуванні' " +
                "AND (SELECT COUNT(View_Interview.id) " +
                "FROM View_Interview " +
                "INNER JOIN Application ON Application.id = View_Interview.id_application " +
                "WHERE Application.id_vacancy = Vacancy.id " +
                "AND (View_Interview.status = 'Кандидат запрошений' OR View_Interview.status = 'Кандидат чекає на рішення')) <= 0 " +
                "ORDER BY Vacancy.id, View_Application.id");

            AssignmentItem[] array = new AssignmentItem[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                array[i] = new AssignmentItem(GetIntItem(dt, i, 0), GetIntItem(dt, i, 1), GetIntItem(dt, i, 2));

            return array;
        }

        // Методи для зміни даних
        internal static void SetApplicationStatus(int idApplication, int idStatus, string reasonRejection)
        {// Метод встановлює статус заявці
            if (reasonRejection == null || reasonRejection.Length < 0)
                reasonRejection = "NULL";
            else
                reasonRejection = $"'{reasonRejection}'";

            ExecuteQuery($"UPDATE Application SET id_application_status = {idStatus}, reason_rejection = {reasonRejection} " +
                $"WHERE Application.id = {idApplication}");
        }
        internal static void SetInterviewStatus(int idInterview, int idStatus)
        {// Метод встановлює статус співбесіді
            ExecuteQuery($"UPDATE Interview SET id_interview_status = {idStatus} " +
                $"WHERE id = {idInterview}");
        }
        internal static void ChangeInterviewDateEvent(int idInterview, DateTime dateTime)
        {// Метод, який змінює дату співбесіди
            ExecuteQuery($"UPDATE Interview SET date_event = " +
                $"'{dateTime:yyyy-MM-dd} {dateTime:HH:mm:ss}' WHERE id = {idInterview}");
        }

        // Методи для видалення даних
        internal static void DeleteVacancy(int idVacancy)
        { ExecuteQuery($"DELETE FROM Vacancy WHERE id = {idVacancy}"); }
    }
}