use master
go

if exists(SELECT * FROM sys.databases WHERE name = 'RecruitmentDB')
begin
ALTER database RecruitmentDB set single_user with rollback immediate
DROP database RecruitmentDB
end
go

CREATE database RecruitmentDB-- Створюємо базу даних
go

use RecruitmentDB
go
--------------------

-- Створення ФУНКЦІЙ

CREATE FUNCTION GetAge(@birthday date)-- Функція вираховує вік
RETURNS tinyint-- Функція повертає число[0;255]
AS
begin
DECLARE @age tinyint
SET @age = DATEDIFF(YEAR, @birthday, GETDATE())-- Вік кандидата
- CASE-- Віднімаємо роки, а потім знаходимо вік більш точніше
WHEN (MONTH(@birthday) > MONTH(GETDATE())) OR 
(MONTH(@birthday) = MONTH(GETDATE()) AND DAY(@birthday) > DAY(GETDATE()))
	THEN 1
	ELSE 0
END

return @age
end
go


-- Створення ТАБЛИЦЬ
CREATE Table Application_Status-- 1. Статуси  заявки
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
status nvarchar(32) UNIQUE NOT NULL,-- Статус
);
go

CREATE Table Position-- 2. Посади
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
name nvarchar(64) NOT NULL,-- Назва
description nvarchar(MAX) NULL,-- Опис
);
go

CREATE Table Education_Form-- 3. Форми навчання
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
form nvarchar(32) UNIQUE NOT NULL,-- Форма
);
go

CREATE Table Education_Degree-- 4. Ступені освіти
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
degree nvarchar(32) UNIQUE NOT NULL,-- Ступінь
);
go

CREATE Table Health-- 5. Здоров'я
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
chronic_diseases nvarchar(256) NULL,-- Хронічні захворювання
smoker bit NOT NULL default 0,-- Курець?(Ні або Так)
drink_alcohol bit NOT NULL default 0,-- Вживає спиртні напої?(Ні або Так)
);
go

CREATE Table Business_Trip_Opportunity-- 6. Можливості відряджень
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
opportunity nvarchar(32) UNIQUE NOT NULL,-- Можливість
);
go

CREATE Table Family_Status-- 7. Сімейні стани
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
status nvarchar(32) UNIQUE NOT NULL,-- Стан
);
go

CREATE Table Interview_Status-- 8. Статуси співбесіди
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
status nvarchar(32) UNIQUE NOT NULL,-- Статус
);
go

CREATE Table Point-- 9. Бали
(-- Кількість балів може бути в такому інтервалі: [0;10]
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
age_under_18 int NOT NULL default 0 check (age_under_18 >= 0 AND age_under_18 <= 10),-- Вік: до 18
age_18_30 int NOT NULL default 0 check (age_18_30 >= 0 AND age_18_30 <= 10),-- Вік: від 18 до 30
age_30_50 int NOT NULL default 0 check (age_30_50 >= 0 AND age_30_50 <= 10),-- Вік: від 30 до 50
age_over_50 int NOT NULL default 0 check (age_over_50 >= 0 AND age_over_50 <= 10),-- Вік: більше 50
exp_none int NOT NULL default 0 check (exp_none >= 0 AND exp_none <= 10),-- Досвід роботи: немає
exp_under_year int NOT NULL default 0 check (exp_under_year >= 0 AND exp_under_year <= 10),-- Досвід роботи: менше року
exp_1_3 int NOT NULL default 0 check (exp_1_3 >= 0 AND exp_1_3 <= 10),-- Досвід роботи: від 1 до 3 років
exp_over_3 int NOT NULL default 0 check (exp_over_3 >= 0 AND exp_over_3 <= 10),-- Досвід роботи: більше 3 років
diploma int NOT NULL default 0 check (diploma >= 0 AND diploma <= 10),-- Має диплом
no_chronic_diseases int NOT NULL default 0 check (no_chronic_diseases >= 0 AND no_chronic_diseases <= 10),-- Немає хронічних захворювань
driver_license int NOT NULL default 0 check (driver_license >= 0 AND driver_license <= 10),-- Має посвідчення водія
no_smoker int NOT NULL default 0 check (no_smoker >= 0 AND no_smoker <= 10),-- Не курець
no_drink_alcohol int NOT NULL default 0 check (no_drink_alcohol >= 0 AND no_drink_alcohol <= 10),-- Не вживає алкоголь
business_trip_opportunity int NOT NULL default 0 check (business_trip_opportunity >= 0 AND business_trip_opportunity <= 10),-- Є можливість відряджень
);
go

CREATE Table EducationDegree_Point--10. СтупеніОсвіти_Бали(проміжна)
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
points int NOT NULL default 0 check (points >= 0 AND points <= 10),-- Кількість балів за ступінь освіти[0;10]
id_point int NOT NULL,-- Код таблиці з балами
id_education_degree int NOT NULL,--Код ступеня освіти
Foreign key(id_point) References Point(id) ON DELETE CASCADE,-- Зовнішні ключі
Foreign key(id_education_degree) References Education_Degree(id),
);
go

CREATE Table Requirement-- 11. Вимоги
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
city nvarchar(64) NULL,-- Місто/село проживання
age_min tinyint NOT NULL default 14 check(age_min >= 14),-- Мінімальний вік(більший або рівний 14)
age_max tinyint NOT NULL default 14 check(age_max >= 14),-- Максимальний вік
exp_min int NOT NULL default 0 check(exp_min >= 0),-- Мінімальний досвід роботи(в місяцях, більший або рівний 0)
diploma bit NOT NULL default 0,-- Має диплом
no_chronic_diseases bit NOT NULL default 0,-- Немає хронічних захворювань(Ні або Так)
driver_license bit NOT NULL default 0,-- Є посвідчення водія(Ні або Так)
no_smoker bit NOT NULL default 0,-- Не курець(Ні або Так)
no_drink_alcohol bit NOT NULL default 0,-- Не вживає алкоголь(Ні або Так)
business_trip_opportunity bit NOT NULL default 0,-- Є можливості відряджень(Ні або Так)
student bit NULL default 0,-- Є студентом
);-- Для всіх полів де може бути 'False' або 'True', окрім student, відповідь False означає те, що вимога не використовуватиметься, а у student - NULL
go

CREATE Table EducationDegree_Requirement-- 12. СтупеніОсвіти_Вимоги(проміжна)
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
id_requirement int NOT NULL,-- Код вимоги
id_education_degree int NOT NULL,--Код ступеня освіти
Foreign key(id_requirement) References Requirement(id) ON DELETE CASCADE,-- Зовнішні ключі
Foreign key(id_education_degree) References Education_Degree(id),
);
go

CREATE Table Vacancy-- 13. Вакансії
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
salary money NOT NULL default 0 check(salary >= 0),-- Зарплата(більше або дорівнює 0)
date_publication datetime2 NOT NULL,-- Дата і час публікації
info nvarchar(MAX) NULL,-- Інформація
relevance bit NOT NULL default 'True',-- Актуальність
id_point int UNIQUE NOT NULL,-- Код таблиці з балами
id_requirement int UNIQUE NOT NULL,-- Код вимоги
id_position int UNIQUE NOT NULL,-- Код посади
Foreign key(id_point) References Point(id) ON DELETE CASCADE,-- Зовнішні ключі
Foreign key(id_requirement) References Requirement(id) ON DELETE CASCADE,
Foreign key(id_position) References Position(id) ON DELETE CASCADE,
);
go

CREATE Table Questionnaire-- 14. Анкети
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
nationality nvarchar(64) NOT NULL,-- Громадянство
city nvarchar(64) NOT NULL,-- Місто/село проживання
children_amount int NOT NULL default 0 check(children_amount >= 0),-- Кількість дітей(більше або дорівнює 0)
experience int NOT NULL default 0 check(experience >= 0),-- Досвід роботи(в місяцях)(більший або рівний 0)
driver_license bit NOT NULL default 0,-- Є посвідчення водія(Ні або Так)
readiness int NOT NULL default 1 check(readiness >= 1 AND readiness <= 14),-- Готовність до роботи від 1 до 14 днів
additional_info nvarchar(MAX) NULL,-- Додаткова інформація
id_health int UNIQUE NOT NULL,-- Код здоров'я
id_family_status int NOT NULL,-- Код сімейного стану
id_business_trip_opportunity int NOT NULL,-- Код можливості відряджень
Foreign key(id_health) References Health(id) ON DELETE CASCADE,-- Зовнішні ключі
Foreign key(id_family_status) References Family_Status(id),
Foreign key(id_business_trip_opportunity) References Business_Trip_Opportunity(id),
);
go

CREATE Table Language-- 15. Мови
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
name nvarchar(64) NOT NULL,-- Мова
level int NOT NULL default 1 check(level >= 1 AND level <= 10),-- Рівень [1;10]
id_questionnaire int NOT NULL,-- Код анкети
Foreign key(id_questionnaire) References Questionnaire(id) ON DELETE CASCADE,-- Зовнішній ключ
);
go

CREATE Table Education-- 16. Освіти
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
name_institution nvarchar(128) NOT NULL,-- Назва закладу
specialty nvarchar(64) NOT NULL,-- Спеціальність
year_admission int NOT NULL default 1950 check(year_admission >= 1950),-- Рік вступу
date_end date NOT NULL default '1951-01-01' check(YEAR(date_end) >= 1951),-- Дата закінчення
id_questionnaire int NOT NULL,-- Код анкети
id_education_degree int NOT NULL,-- Код ступеня освіти
id_education_form int NOT NULL,-- Код форми навчання
Foreign key(id_questionnaire) References Questionnaire(id) ON DELETE CASCADE,-- Зовнішні ключі
Foreign key(id_education_degree) References Education_Degree(id),
Foreign key(id_education_form) References Education_Form(id),
);
go

CREATE Table Candidate-- 17. Кандидати
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
login nvarchar(16) UNIQUE NOT NULL, -- Логін
password nvarchar(16) NOT NULL check(len(password) >= 8),-- Пароль
surname nvarchar(64) NOT NULL,-- Прізвище
name nvarchar(64) NOT NULL,-- Ім'я
father_name nvarchar(64) NULL,-- По-батькові
phone nvarchar(13) UNIQUE NOT NULL default 'None' check(len(phone) >= 13),-- Номер телефону(мінімум 13 символів)
birthday date NOT NULL default '2024-01-01' check(birthday < GETDATE()),-- Дата народження(пізніше ніж в день створення кандидата)
email nvarchar(64) UNIQUE NOT NULL default 'None' check (email LIKE '%_@__%.__%'),-- E-mail [1;∞)@[2;∞).[2;∞), де запис [n;m) - кількість символів
id_questionnaire int UNIQUE NOT NULL,-- Код анкети
Foreign key(id_questionnaire) References Questionnaire(id) ON DELETE CASCADE,-- Зовнішній ключ
);
go

CREATE Table Application-- 18. Заявки
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
date_submission datetime2 NOT NULL,-- Дата і час подачі
scores int NOT NULL default 0,-- Кількість балів
additional_info NVARCHAR(MAX) NULL,-- Додаткова інформація від кандидата
reason_rejection nvarchar(MAX) NULL,-- Причина відмови
id_application_status int NOT NULL,-- Код статусу заявки
id_candidate int NOT NULL,-- Код кандидата
id_vacancy int NOT NULL,-- Код вакансії
Foreign key(id_application_status) References Application_Status(id),-- Зовнішні ключі
Foreign key(id_candidate) References Candidate(id) ON DELETE CASCADE,
Foreign key(id_vacancy) References Vacancy(id) ON DELETE CASCADE,
);
go

CREATE Table Interview-- 19. Співбесіди
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
date_event datetime2 NOT NULL,-- Дата і час проведення
id_application int UNIQUE NOT NULL,-- Код заявки
id_interview_status int NOT NULL,-- Код статусу співбесіди
Foreign key(id_application) References Application(id) ON DELETE CASCADE,-- Зовнішні ключі
Foreign key(id_interview_status) References Interview_Status(id),
);
go

CREATE Table Employee-- 20. Співробітники
(
id int NOT NULL IDENTITY(1,1) Primary Key,-- Код
surname nvarchar(64) NOT NULL,-- Прізвище
name nvarchar(64) NOT NULL,-- Ім'я
father_name nvarchar(64) NULL,-- По-батькові
position_name nvarchar(64) NOT NULL,-- Посада
city nvarchar(64) NOT NULL,-- Місто/село проживання
phone nvarchar(16) UNIQUE NOT NULL default 'None' check(len(phone) >= 13),-- Номер телефону(мінімум 13 символів)
birthday date NOT NULL default '2024-01-01' check(birthday < GETDATE()),-- Дата народження(пізніше ніж в день створення співробітника)
email nvarchar(64) UNIQUE NOT NULL default 'None' check (email LIKE '%_@__%.__%'),-- E-mail [1;∞)@[2;∞).[2;∞), де запис [n;m) - кількість символів
salary money NOT NULL default 0 check(salary >= 0),-- Зарплата(більше або дорівнює 0)
date_employment date NOT NULL, -- Дата працевлаштування
id_interview int UNIQUE NULL,-- Код співбесіди
Foreign key(id_interview) References Interview(id) ON DELETE CASCADE,-- Зовнішній ключ
);
go

-- Створення ПРЕДСТАВЛЕНЬ
if OBJECT_ID('View_Point','View') IS NOT NULL-- 1. Представлення для розрахунку балів заявок
DROP View View_Point
go
CREATE View View_Point
AS
SELECT Application.id AS id,Point.id as point_id,Questionnaire.id as questionnaire_id,birthday,experience, COUNT(Education.id) AS education_count,
chronic_diseases,Questionnaire.driver_license as has_driver_license,smoker,drink_alcohol,id_business_trip_opportunity,
age_under_18,age_18_30,age_30_50,age_over_50,exp_none,exp_under_year,exp_1_3,exp_over_3,diploma,no_chronic_diseases,
Point.driver_license,no_smoker,no_drink_alcohol,business_trip_opportunity
FROM Application
INNER JOIN Vacancy ON Application.id_vacancy = Vacancy.id
INNER JOIN Point ON Vacancy.id_point = Point.id
INNER JOIN Candidate ON Application.id_candidate = Candidate.id
INNER JOIN Questionnaire ON Candidate.id_questionnaire = Questionnaire.id
INNER JOIN Health ON Questionnaire.id_health = Health.id
LEFT JOIN Education ON Education.id_questionnaire = Questionnaire.id
GROUP BY
Application.id,Point.id,Questionnaire.id,birthday,experience,chronic_diseases,Questionnaire.driver_license,smoker,drink_alcohol,id_business_trip_opportunity,
age_under_18,age_18_30,age_30_50,age_over_50,exp_none,exp_under_year,exp_1_3,exp_over_3,diploma,no_chronic_diseases,
Point.driver_license,no_smoker,no_drink_alcohol,business_trip_opportunity
go

if OBJECT_ID('View_Requirement','View') IS NOT NULL-- 2. Представлення для вимог
DROP View View_Requirement
go
CREATE View View_Requirement
AS
SELECT Application.id AS id,Requirement.id AS requirement_id,Questionnaire.id AS questionnaire_id,
Questionnaire.city AS city_candidate, birthday,experience,COUNT(Education.id) AS education_count,chronic_diseases,
Questionnaire.driver_license as has_driver_license,smoker,drink_alcohol,id_business_trip_opportunity,
Requirement.city,age_min,age_max,exp_min,diploma,no_chronic_diseases,Requirement.driver_license,no_smoker,
no_drink_alcohol,business_trip_opportunity,student
FROM Application
INNER JOIN Vacancy ON Application.id_vacancy = Vacancy.id
INNER JOIN Requirement ON Vacancy.id_requirement = Requirement.id
INNER JOIN Candidate ON Application.id_candidate = Candidate.id
INNER JOIN Questionnaire ON Candidate.id_questionnaire = Questionnaire.id
INNER JOIN Health ON Questionnaire.id_health = Health.id
LEFT JOIN Education ON Education.id_questionnaire = Questionnaire.id
GROUP BY Application.id,Requirement.id,Questionnaire.id,Questionnaire.city, birthday,experience,chronic_diseases,
Questionnaire.driver_license,smoker,drink_alcohol,id_business_trip_opportunity,
Requirement.city,age_min,age_max,exp_min,diploma,no_chronic_diseases,Requirement.driver_license,no_smoker,
no_drink_alcohol,business_trip_opportunity,student
go

if OBJECT_ID('View_Education','View') IS NOT NULL-- 3. Представлення освіт
DROP View View_Education
go
CREATE View View_Education
AS
SELECT Education.id AS id,name_institution,specialty,year_admission,date_end,degree,form,id_questionnaire FROM Education
INNER JOIN Education_Form ON id_education_form = Education_Form.id
INNER JOIN Education_Degree ON id_education_degree = Education_Degree.id
go

if OBJECT_ID('View_Questionnaire','View') IS NOT NULL-- 4. Представлення анкет
DROP View View_Questionnaire
go
CREATE View View_Questionnaire
AS
SELECT Q.id as id,nationality,city,children_amount,experience,driver_license,readiness,additional_info,chronic_diseases,smoker,drink_alcohol,
Family_Status.status AS status,bto.opportunity,COUNT(DISTINCT Education.id) AS education_count,COUNT(DISTINCT Language.id) AS language_count
FROM Questionnaire Q
INNER JOIN Family_Status ON Q.id_family_status = Family_Status.id
INNER JOIN Business_Trip_Opportunity bto ON Q.id_business_trip_opportunity = bto.id
INNER JOIN Health ON Q.id_health = Health.id
LEFT JOIN Education ON Education.id_questionnaire = Q.id
LEFT JOIN Language ON Language.id_questionnaire = Q.id
GROUP BY Q.id ,nationality,city,children_amount,experience,driver_license,readiness,additional_info,
chronic_diseases,smoker,drink_alcohol,Family_Status.status,bto.opportunity
go

if OBJECT_ID('View_Application','View') IS NOT NULL-- 5. Представлення заявок
DROP View View_Application
go
CREATE View View_Application
AS
SELECT A.id AS id,date_submission,scores,Application_Status.status as status,additional_info,reason_rejection,
Position.name AS position_name,Position.description as position_description,id_candidate,id_vacancy
FROM Application A
INNER JOIN Application_Status ON A.id_application_status = Application_Status.id
INNER JOIN Vacancy ON A.id_vacancy = Vacancy.id
INNER JOIN Position ON Vacancy.id_position = Position.id
go

if OBJECT_ID('View_Vacancy','View') IS NOT NULL-- 6. Представлення вакансій
DROP View View_Vacancy
go
CREATE View View_Vacancy
AS
SELECT Vacancy.id AS id, Position.name as position_name, Position.description as position_description, salary,date_publication,
COUNT(Application.id) as application_count,info,relevance,id_point,id_requirement
FROM Vacancy
INNER JOIN Position ON Vacancy.id_position = Position.id
LEFT JOIN Application ON Application.id_vacancy = Vacancy.id
GROUP BY Vacancy.id, Position.name, Position.description, salary,date_publication,
info,relevance,id_point,id_requirement
go

if OBJECT_ID('View_Interview','View') IS NOT NULL-- 7. Представлення співбесід
DROP View View_Interview
go
CREATE View View_Interview
AS
SELECT Interview.id AS id,Position.name AS position_name,Position.description AS position_description,
date_event,Interview_Status.status as status, id_application
FROM Interview
INNER JOIN Interview_Status ON Interview.id_interview_status = Interview_Status.id
INNER JOIN Application ON Interview.id_application = Application.id
INNER JOIN Vacancy ON Application.id_vacancy = Vacancy.id
INNER JOIN Position ON Vacancy.id_position = Position.id
go

-- Створення ТРИГЕРІВ
CREATE TRIGGER Health_Update_Trigger-- 1. Здоров'я
ON Health
FOR UPDATE
AS
UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_candidate IN 
(SELECT Candidate.id FROM deleted
INNER JOIN Questionnaire ON deleted.id = Questionnaire.id_health
INNER JOIN Candidate ON Candidate.id_questionnaire = Questionnaire.id)
go

CREATE TRIGGER Language_Update_Trigger-- 2. Мови
ON Language
FOR UPDATE
AS
UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_candidate IN 
(SELECT Candidate.id FROM deleted
INNER JOIN Questionnaire ON deleted.id_questionnaire = Questionnaire.id
INNER JOIN Candidate ON Candidate.id_questionnaire = Questionnaire.id)
go

CREATE TRIGGER Education_Insert_Update_Trigger-- 3. Освіти
ON Education
FOR INSERT,UPDATE
AS

if EXISTS(SELECT id FROM Education WHERE year_admission > YEAR(date_end))
BEGIN-- Перевірка років початку та кінця навчання
raiserror('Рік початку навчання не може бути більшим, ніж рік закінчення!',16,10)
rollback transaction
END

UPDATE Application SET scores = 0-- Також змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_candidate IN 
(SELECT Candidate.id FROM deleted
INNER JOIN Questionnaire ON deleted.id_questionnaire = Questionnaire.id
INNER JOIN Candidate ON Candidate.id_questionnaire = Questionnaire.id)
go

CREATE TRIGGER Questionnaire_Update_Trigger-- 4. Анкети
ON Questionnaire
FOR UPDATE
AS
UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_candidate IN 
(SELECT Candidate.id FROM deleted
INNER JOIN Candidate ON Candidate.id_questionnaire = deleted.id)

-- Якщо змінили анкету, то і співробітник, якщо є, повинен змінитися
UPDATE Employee SET city = inserted.city
FROM inserted
INNER JOIN Candidate ON id_questionnaire = inserted.id
INNER JOIN Application ON id_candidate = Candidate.id
INNER JOIN Interview ON id_application = Application.id
INNER JOIN Employee ON id_interview = Interview.id
go

CREATE TRIGGER Candidate_Update_Trigger-- 5. Кандидати
ON Candidate
FOR UPDATE
AS
UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_candidate IN (SELECT id FROM deleted)

-- Якщо змінили кандидата, то і співробітник, якщо є, повинен змінитися
UPDATE Employee SET surname = inserted.surname, name = inserted.name, father_name = inserted.father_name, 
phone = inserted.phone, birthday = inserted.birthday, email = inserted.email
FROM inserted
INNER JOIN Application ON id_candidate = inserted.id
INNER JOIN Interview ON id_application = Application.id
INNER JOIN Employee ON id_interview = Interview.id
go

CREATE TRIGGER Employee_Insert_Update_Trigger-- 6. Співробітники
ON Employee
FOR INSERT,UPDATE
AS
if EXISTS(SELECT inserted.id FROM inserted 
INNER JOIN Interview ON inserted.id_interview = Interview.id
WHERE Interview.date_event > inserted.date_employment)
BEGIN-- Перевірка дати подачі заявки та дати проведення співбесіди
raiserror('Дата проведення співбесіди не може бути пізніше, ніж дата працевлаштування!',16,10)
rollback
END
go

CREATE TRIGGER Interview_Insert_Update_Trigger-- 7. Співбесіди
ON Interview
FOR INSERT,UPDATE
AS
if EXISTS(SELECT inserted.id FROM inserted 
INNER JOIN Application ON inserted.id_application = Application.id
WHERE Application.date_submission > inserted.date_event)
BEGIN-- Перевірка дати подачі заявки та дати проведення співбесіди
raiserror('Дата подачі заявки не може бути пізніше, ніж дата проведення співбесіди!',16,10)
rollback
END

DECLARE @id_interview_status_accept int = 3-- Код статусу співбесіди 'Прийнято'
if EXISTS(SELECT id FROM inserted WHERE id_interview_status = @id_interview_status_accept)
BEGIN-- Якщо статус співбесіди = 3, тобто кандидат прийнятий на роботу
    INSERT INTO Employee (surname, name, father_name, position_name, city, phone, birthday, email, salary, date_employment, id_interview)
    SELECT surname, Candidate.name, father_name,Position.name,city,phone,birthday,email,salary,DATEADD(DAY,readiness, GETDATE()),inserted.id
    FROM inserted-- Створюємо співробітника
    INNER JOIN Application ON id_application = Application.id
	INNER JOIN Vacancy ON id_vacancy = Vacancy.id
	INNER JOIN Position ON id_position = Position.id
    INNER JOIN Candidate ON id_candidate = Candidate.id
	INNER JOIN Questionnaire ON id_questionnaire = Questionnaire.id

END

UPDATE Vacancy SET relevance = 'False'-- Вказуємо що вакансія не актуальна
WHERE id = (SELECT Vacancy.id FROM inserted
INNER JOIN Application ON inserted.id_application = Application.id
INNER JOIN Vacancy ON id_vacancy = Vacancy.id
WHERE id_interview_status = @id_interview_status_accept)
go

CREATE TRIGGER Interview_Delete_Trigger--8. Співбесіди
ON Interview
FOR DELETE
AS-- Якщо видаляється співбесіда, то також видаляється і заявка
DELETE FROM Application WHERE id IN (SELECT id_application FROM deleted)
go

CREATE TRIGGER Employee_Delete_Trigger--9. Співробітники
ON Employee
FOR DELETE
AS-- Якщо видаляється співробітник, то також видаляється і співбесіда
DELETE FROM Interview WHERE id IN (SELECT id_interview FROM deleted)
go

CREATE TRIGGER Questionnaire_Delete_Trigger--10. Анкети
ON Questionnaire
FOR DELETE
AS-- Якщо видаляється анкета, то також видаляється і здоров'я
DELETE FROM Health WHERE id IN (SELECT id_health FROM deleted)
go

CREATE TRIGGER Candidate_Delete_Trigger--11. Кандидати
ON Candidate
FOR DELETE
AS-- Якщо видаляється кандидат, то також видаляється і анкета
DELETE FROM Questionnaire WHERE id IN (SELECT id_questionnaire FROM deleted)
go

CREATE TRIGGER Vacancy_Delete_Trigger--12. Вакансії
ON Vacancy
FOR DELETE
AS-- Якщо видаляється вакансія, то також видаляється: посада, вимоги і таблиця з балами
DELETE FROM Position WHERE id IN (SELECT id_point FROM deleted)
DELETE FROM Requirement WHERE id IN (SELECT id_requirement FROM deleted)
DELETE FROM Point WHERE id IN (SELECT id_point FROM deleted)
go

CREATE TRIGGER Application_Insert_Update_Trigger-- 13. Заявки
ON Application
AFTER INSERT,UPDATE
AS
DECLARE @id_no_business_trip_opportunity int = 3-- Код можливості відряджень: Ніколи
-- 1. Перевірка дати подачі заявки та дати публікації вакансії
DECLARE @id_application_status_rejected int = 3-- Код статусу заявки: Відхилена
if EXISTS(SELECT Application.id FROM Application
INNER JOIN Vacancy ON Application.id_vacancy = Vacancy.id
WHERE Application.date_submission < Vacancy.date_publication)
BEGIN
raiserror('Дата подачі заявки не може раніше, ніж дата публікації вакансії!',16,10)
rollback transaction
END

-- 2. Відхиляємо заявки, які не мають мінімальних вимог
UPDATE Application SET id_application_status = @id_application_status_rejected,
reason_rejection = 'Заявка не відповідає мінімальним вимогам.'
FROM Application
INNER JOIN View_Requirement ON Application.id = View_Requirement.id
WHERE Application.id IN (SELECT id FROM inserted)
AND (
city IS NOT NULL AND city_candidate != city-- Місто/село проживання
OR dbo.GetAge(birthday) < age_min-- Мінімальний вік
OR dbo.GetAge(birthday) > age_max-- Максимальний вік
OR experience < exp_min-- Мінімальний досвід роботи
OR diploma = 'True' AND education_count < 1-- Диплом
OR no_chronic_diseases = 'True' AND chronic_diseases IS NOT NULL-- Хронічні захворювання
OR driver_license = 'True' AND has_driver_license = 'False'-- Посвідчення водія
OR no_smoker = 'True' AND smoker = 'True'-- Курець
OR no_drink_alcohol = 'True' AND drink_alcohol = 'True'-- Вживає алкоголь
OR business_trip_opportunity = 'True' AND id_business_trip_opportunity = @id_no_business_trip_opportunity-- Не має можливостей відряджень
OR student = 'True' AND-- потрібен студент
(SELECT COUNT(Education.id) FROM Education
WHERE Education.id_questionnaire = View_Requirement.questionnaire_id AND
(YEAR(GETDATE()) < year_admission OR GETDATE() > date_end)) > 0
OR student = 'False' AND-- НЕ потрібен студент
(SELECT COUNT(Education.id) FROM Education
WHERE Education.id_questionnaire = View_Requirement.questionnaire_id AND
(YEAR(GETDATE()) >= year_admission AND GETDATE() <= date_end)) > 0
OR ((SELECT COUNT(edr.id) FROM EducationDegree_Requirement edr-- Ступені освіти
WHERE edr.id_requirement = View_Requirement.requirement_id) > 0-- Якщо є вимоги
AND (SELECT COUNT(edr.id) FROM EducationDegree_Requirement edr-- Та освіта не відповідає вимогам
INNER JOIN Education ON edr.id_education_degree = Education.id_education_degree
WHERE edr.id_requirement = View_Requirement.requirement_id AND Education.id_questionnaire = View_Requirement.questionnaire_id) = 0)
)

-- 3. Знаходимо кількість балів за таблицею Point
UPDATE Application
SET scores = 
(
CASE-- Вік
WHEN dbo.GetAge(birthday) < 18 THEN age_under_18
WHEN dbo.GetAge(birthday) >= 18 AND dbo.GetAge(birthday) < 30 THEN age_18_30
WHEN dbo.GetAge(birthday) >= 30 AND dbo.GetAge(birthday) < 50 THEN age_30_50
WHEN dbo.GetAge(birthday) >= 50 THEN age_over_50
ELSE 0 END
+ CASE-- Досвід роботи
WHEN experience = 0 THEN exp_none
WHEN experience > 0 AND experience < 12 THEN exp_under_year
WHEN experience >= 12 AND experience < 36 THEN exp_1_3
WHEN experience >= 36 THEN exp_over_3
ELSE 0 END
+ CASE-- Має диплом
WHEN education_count > 0 THEN diploma
ELSE 0 END
+ CASE-- Немає хронічних захворювань
WHEN chronic_diseases IS NULL THEN no_chronic_diseases
ELSE 0 END
+ CASE-- Має посвідчення водія
WHEN has_driver_license = 'True' THEN driver_license
ELSE 0 END
+ CASE-- Не курець
WHEN smoker = 'False' THEN no_smoker
ELSE 0 END
+ CASE-- Не вживає алкоголь
WHEN drink_alcohol = 'False' THEN no_drink_alcohol
ELSE 0 END
+ CASE-- Є можливості відряджень
WHEN id_business_trip_opportunity != 3 THEN business_trip_opportunity
ELSE 0 END
+COALESCE((SELECT MAX(points) FROM EducationDegree_Point edp
WHERE edp.id_point = View_Point.point_id AND edp.id_education_degree IN
(SELECT id_education_degree FROM Education WHERE id_questionnaire = View_Point.questionnaire_id)),0)
)
FROM Application
INNER JOIN View_Point ON Application.id = View_Point.id
WHERE Application.id IN (SELECT id FROM inserted);
go

CREATE TRIGGER Point_Update_Trigger-- 14. Бали
ON Point
AFTER UPDATE
AS
UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_vacancy IN 
(SELECT Vacancy.id FROM deleted
INNER JOIN Vacancy ON deleted.id = Vacancy.id_point)
go

CREATE TRIGGER Requirement_Insert_Update_Trigger-- 15. Вимоги
ON Requirement
AFTER INSERT,UPDATE
AS
if EXISTS(SELECT inserted.id FROM inserted 
WHERE inserted.age_min > inserted.age_max)
BEGIN-- Перевірка мінімального та максимального віку
raiserror('Мінімальний вік не може бути більше, ніж максимальний!',16,10)
rollback
END

UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_vacancy IN 
(SELECT Vacancy.id FROM deleted
INNER JOIN Vacancy ON deleted.id = Vacancy.id_requirement)
go

CREATE TRIGGER EducationDegreePoint_Insert_Update_Trigger-- 16. СтупеніОсвіти_Бали
ON EducationDegree_Point
AFTER INSERT,UPDATE
AS
UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_vacancy IN 
(SELECT Vacancy.id FROM inserted
INNER JOIN Point ON inserted.id_point = Point.id
INNER JOIN Vacancy ON Point.id = Vacancy.id_point)
go

CREATE TRIGGER EducationDegreePoint_Delete_Trigger-- 17. СтупеніОсвіти_Бали
ON EducationDegree_Point
AFTER DELETE
AS
UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_vacancy IN 
(SELECT Vacancy.id FROM deleted
INNER JOIN Point ON deleted.id_point = Point.id
INNER JOIN Vacancy ON Point.id = Vacancy.id_point)
go

CREATE TRIGGER EducationDegree_Requirement_Insert_Update_Trigger-- 18. СтупеніОсвіти_Вимоги
ON EducationDegree_Requirement
AFTER INSERT,UPDATE
AS
UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_vacancy IN 
(SELECT Vacancy.id FROM inserted
INNER JOIN Requirement ON inserted.id_requirement = Requirement.id
INNER JOIN Vacancy ON Requirement.id = Vacancy.id_requirement)
go

CREATE TRIGGER EducationDegree_Requirement_Delete_Trigger-- 19. СтупеніОсвіти_Вимоги
ON EducationDegree_Requirement
AFTER DELETE
AS
UPDATE Application SET scores = 0-- Змінюємо кількість балів на 0(для виклику тригера заявки)
WHERE id_vacancy IN 
(SELECT Vacancy.id FROM deleted
INNER JOIN Requirement ON deleted.id_requirement = Requirement.id
INNER JOIN Vacancy ON Requirement.id = Vacancy.id_requirement)
go


-- Заповнення ТАБЛИЦЬ
-- 1. Статуси  заявки
INSERT INTO Application_Status(status) values('В очікуванні')
INSERT INTO Application_Status(status) values('Прийнята')
INSERT INTO Application_Status(status) values('Відхилена')
go

-- 2. Посади
INSERT INTO Position(name,description) values('Маркетинг-менеджер','Планує та впроваджує маркетингові стратегії для підвищення усвідомленості бренду, залучення нових клієнтів та збільшення продажів. Відповідає за аналіз ринкових тенденцій, розробку рекламних кампаній та управління онлайн та офлайн маркетинговими ініціативами.')
INSERT INTO Position(name,description) values('Водій-міжнародник (дальнобійник)','Здійснює міжнародні вантажоперевезення: експорт, імпорт, а також перевезення вантажів по Європі')
INSERT INTO Position(name,description) values('Грузчик','Завантажує та розвантажує товари з транспортних засобів, розміщює вантажі на складі, пакує та розпаковує товари. Грузчик повинен бути фізично витривалим, уважним та відповідальним, здатним ефективно працювати в команді та дотримуватися стандартів безпеки під час обробки вантажів.')
INSERT INTO Position(name,description) values('C# Junior Розробник','Розробляє та вдосконалює програмний код, виправляє помилки, тестувує та впроваджує нові функцій. Вивчає кращі практики програмування, стандарти коду та долучається до розробки згідно з вимогами та специфікаціями проекту.')
go

-- 3. Форма навчання
INSERT INTO Education_Form(form) values('Денна')
INSERT INTO Education_Form(form) values('Заочна')
go

-- 4. Ступені освіти
INSERT INTO Education_Degree(degree) values('Молодший бакалавр')
INSERT INTO Education_Degree(degree) values('Бакалавр')
INSERT INTO Education_Degree(degree) values('Спеціаліст')
INSERT INTO Education_Degree(degree) values('Магістр')
INSERT INTO Education_Degree(degree) values('Доктор наук')
go

-- 5. Здоров'я
INSERT INTO Health(chronic_diseases,smoker,drink_alcohol) values(NULL, 'False', 'True')
INSERT INTO Health(chronic_diseases,smoker,drink_alcohol) values('Діабет типу 2', 'True', 'False')
INSERT INTO Health(chronic_diseases,smoker,drink_alcohol) values(NULL, 'False', 'False')
INSERT INTO Health(chronic_diseases,smoker,drink_alcohol) values(NULL, 'False', 'False')
INSERT INTO Health(chronic_diseases,smoker,drink_alcohol) values(NULL, 'False', 'True')
INSERT INTO Health(chronic_diseases,smoker,drink_alcohol) values('Остеохондроз', 'True', 'True')
INSERT INTO Health(chronic_diseases,smoker,drink_alcohol) values(NULL, 'False', 'True')
go

-- 6. Можливості відряджень
INSERT INTO Business_Trip_Opportunity(opportunity) values('Часто')
INSERT INTO Business_Trip_Opportunity(opportunity) values('Іноді')
INSERT INTO Business_Trip_Opportunity(opportunity) values('Ніколи')
go

-- 7. Сімейні стани
INSERT INTO Family_Status(status) values('Одружений(а)')
INSERT INTO Family_Status(status) values('Неодружений(а)')
INSERT INTO Family_Status(status) values('Розлучений(а)')
INSERT INTO Family_Status(status) values('Вдівець/вдова')
INSERT INTO Family_Status(status) values('Цивільний шлюб')
go

-- 8. Статуси співбесіди
INSERT INTO Interview_Status(status) values('Кандидат запрошений')
INSERT INTO Interview_Status(status) values('Кандидат чекає на рішення')
INSERT INTO Interview_Status(status) values('Прийнято')
INSERT INTO Interview_Status(status) values('Не прийнято')
go

-- 9. Бали
INSERT INTO Point(age_under_18,age_18_30,age_30_50,age_over_50,exp_none,exp_under_year,exp_1_3,exp_over_3,diploma,
no_chronic_diseases,driver_license,no_smoker,no_drink_alcohol,business_trip_opportunity) values(4,7,2,0,0,0,3,8,4,1,0,0,1,0)
INSERT INTO Point(age_under_18,age_18_30,age_30_50,age_over_50,exp_none,exp_under_year,exp_1_3,exp_over_3,diploma,
no_chronic_diseases,driver_license,no_smoker,no_drink_alcohol,business_trip_opportunity) values(1,6,5,2,0,3,5,5,2,2,10,0,5,7)
INSERT INTO Point(age_under_18,age_18_30,age_30_50,age_over_50,exp_none,exp_under_year,exp_1_3,exp_over_3,diploma
,no_chronic_diseases,driver_license,no_smoker,no_drink_alcohol,business_trip_opportunity) values(4,10,5,0,5,6,7,7,2,5,0,8,7,0)
INSERT INTO Point(age_under_18,age_18_30,age_30_50,age_over_50,exp_none,exp_under_year,exp_1_3,exp_over_3,diploma
,no_chronic_diseases,driver_license,no_smoker,no_drink_alcohol,business_trip_opportunity) values(6,8,4,3,0,5,8,8,5,2,0,1,2,1)
go

-- 10. СтупеніОсвіти_Бали(проміжна)
INSERT INTO EducationDegree_Point(points,id_point,id_education_degree) values(2,1,3)
INSERT INTO EducationDegree_Point(points,id_point,id_education_degree) values(4,1,4)
INSERT INTO EducationDegree_Point(points,id_point,id_education_degree) values(6,1,5)
INSERT INTO EducationDegree_Point(points,id_point,id_education_degree) values(5,2,3)
INSERT INTO EducationDegree_Point(points,id_point,id_education_degree) values(4,4,2)
INSERT INTO EducationDegree_Point(points,id_point,id_education_degree) values(4,4,3)
INSERT INTO EducationDegree_Point(points,id_point,id_education_degree) values(6,4,4)
INSERT INTO EducationDegree_Point(points,id_point,id_education_degree) values(6,4,5)
go

-- 11. Вимоги
INSERT INTO Requirement(city,age_min,age_max,exp_min,diploma,no_chronic_diseases,driver_license,no_smoker,
no_drink_alcohol,business_trip_opportunity,student) values('Харків',20,50,12,'True','False','False','True','False','False',NULL)
INSERT INTO Requirement(city,age_min,age_max,exp_min,diploma,no_chronic_diseases,driver_license,no_smoker,
no_drink_alcohol,business_trip_opportunity,student) values(NULL,27,65,6,'False','False','True','False','True','True','False')
INSERT INTO Requirement(city,age_min,age_max,exp_min,diploma,no_chronic_diseases,driver_license,no_smoker,
no_drink_alcohol,business_trip_opportunity,student) values(NULL,20,40,0,'True','True','False','True','False','False','True')
INSERT INTO Requirement(city,age_min,age_max,exp_min,diploma,no_chronic_diseases,driver_license,no_smoker,
no_drink_alcohol,business_trip_opportunity,student) values(NULL,14,30,0,'False','False','False','False','False','False',NULL)
go

-- 12. СтупеніОсвіти_Вимоги(проміжна)
INSERT INTO EducationDegree_Requirement(id_requirement,id_education_degree) values(1,3)
INSERT INTO EducationDegree_Requirement(id_requirement,id_education_degree) values(1,4)
INSERT INTO EducationDegree_Requirement(id_requirement,id_education_degree) values(1,5)
INSERT INTO EducationDegree_Requirement(id_requirement,id_education_degree) values(2,3)
INSERT INTO EducationDegree_Requirement(id_requirement,id_education_degree) values(4,2)
INSERT INTO EducationDegree_Requirement(id_requirement,id_education_degree) values(4,3)
INSERT INTO EducationDegree_Requirement(id_requirement,id_education_degree) values(4,4)
INSERT INTO EducationDegree_Requirement(id_requirement,id_education_degree) values(4,5)
go

-- 13. Вакансії
INSERT INTO Vacancy(salary,date_publication,info,id_point,id_requirement,id_position) values(18000,'2023-12-02 12:45:25','Маркетолог відповідає за аналіз ринкових тенденцій, розробку рекламних кампаній та управління онлайн та офлайн маркетинговими ініціативами.',1,1,1)
INSERT INTO Vacancy(salary,date_publication,info,id_point,id_requirement,id_position) values(22000,'2023-12-07 14:23:04',NULL,2,2,2)
INSERT INTO Vacancy(salary,date_publication,info,id_point,id_requirement,id_position) values(12000,'2023-11-17 12:27:47',NULL,3,3,3)
INSERT INTO Vacancy(salary,date_publication,info,id_point,id_requirement,id_position) values(17500,'2023-12-25 13:50:34','Ви будете розробляти код, виправляти помилки, вдосконалювати функціональність та співпрацювати з іншими відділами для забезпечення ефективної роботи програм. Після працевлаштування ви отримаєте гарну зарплатню, дружній колектив, а також можливість кар’єрного розвитку.',4,4,4)
go

-- 14. Анкети
INSERT INTO Questionnaire(nationality,city,children_amount,experience,driver_license,readiness,additional_info,
id_health,id_family_status,id_business_trip_opportunity) values('Україна','Харків',1,18,'False',3,NULL,1,1,3)
INSERT INTO Questionnaire(nationality,city,children_amount,experience,driver_license,readiness,additional_info,
id_health,id_family_status,id_business_trip_opportunity) values('Україна','Харків',2,32,'True',12,'Вимагаю регулярних вихідних, не менше 10 днів на місяць, для забезпечення збереження енергії та ефективності на робочому місці.',2,1,1)
INSERT INTO Questionnaire(nationality,city,children_amount,experience,driver_license,readiness,additional_info,
id_health,id_family_status,id_business_trip_opportunity) values('Україна','Пісочин',0,0,'False',3,'Готовий внести свій внесок в ваш колектив та забезпечити ефективну обробку вантажів, дотримуючись всіх норм та правил безпеки.',3,2,3)
INSERT INTO Questionnaire(nationality,city,children_amount,experience,driver_license,readiness,additional_info,
id_health,id_family_status,id_business_trip_opportunity) values('Україна','Мала Данилівка',0,9,'False',7,'Вивчала також Python, C++ та Java.',4,2,2)
INSERT INTO Questionnaire(nationality,city,children_amount,experience,driver_license,readiness,additional_info,
id_health,id_family_status,id_business_trip_opportunity) values('Україна','Дергачі',0,6,'False',1,'Є непогані навички володіння C#, розуміння ООП та знання SQL.',5,2,2)
INSERT INTO Questionnaire(nationality,city,children_amount,experience,driver_license,readiness,additional_info,
id_health,id_family_status,id_business_trip_opportunity) values('Україна','Харків',1,0,'False',4,NULL,6,1,3)
INSERT INTO Questionnaire(nationality,city,children_amount,experience,driver_license,readiness,additional_info,
id_health,id_family_status,id_business_trip_opportunity) values('Україна','Березівка',0,0,'True',6,NULL,7,2,3)
go

-- 15. Мови
INSERT INTO Language(name,level,id_questionnaire) values('Українська',9,1)
INSERT INTO Language(name,level,id_questionnaire) values('Російська',7,1)
INSERT INTO Language(name,level,id_questionnaire) values('Українська',8,2)
INSERT INTO Language(name,level,id_questionnaire) values('Англійська',5,2)
INSERT INTO Language(name,level,id_questionnaire) values('Російська',6,2)
INSERT INTO Language(name,level,id_questionnaire) values('Українська',8,3)
INSERT INTO Language(name,level,id_questionnaire) values('Українська',9,4)
INSERT INTO Language(name,level,id_questionnaire) values('Англійська',5,4)
INSERT INTO Language(name,level,id_questionnaire) values('Російська',7,4)
INSERT INTO Language(name,level,id_questionnaire) values('Українська',8,5)
INSERT INTO Language(name,level,id_questionnaire) values('Англійська',5,5)
INSERT INTO Language(name,level,id_questionnaire) values('Російська',7,5)
INSERT INTO Language(name,level,id_questionnaire) values('Українська',7,6)
INSERT INTO Language(name,level,id_questionnaire) values('Російська',5,6)
INSERT INTO Language(name,level,id_questionnaire) values('Українська',8,7)
INSERT INTO Language(name,level,id_questionnaire) values('Російська',7,7)
INSERT INTO Language(name,level,id_questionnaire) values('Англійська',5,7)
INSERT INTO Language(name,level,id_questionnaire) values('Німецька',2,7)
go

-- 16. Освіти
INSERT INTO Education(name_institution,specialty,year_admission,date_end,id_questionnaire,id_education_degree,id_education_form) values('ХНЕУ ім. С. Кузнеця','Маркетинг',2007,'2013-07-14',1,4,1)
INSERT INTO Education(name_institution,specialty,year_admission,date_end,id_questionnaire,id_education_degree,id_education_form) values('Харківський фаховий коледж транспортних технологій','Транспортний облік та експлуатація автомобільного транспорту',1996,'2001-06-24',2,3,2)
INSERT INTO Education(name_institution,specialty,year_admission,date_end,id_questionnaire,id_education_degree,id_education_form) values('НЮУ ім. Ярослава Мудрого','Менеджмент',2021,'2025-06-29',3,2,1)
INSERT INTO Education(name_institution,specialty,year_admission,date_end,id_questionnaire,id_education_degree,id_education_form) values('НТУ "ХПІ"','Кібербезпека',2017,'2021-07-11',4,2,2)
INSERT INTO Education(name_institution,specialty,year_admission,date_end,id_questionnaire,id_education_degree,id_education_form) values('НТУ "ХПІ"','Прикладна математика',2016,'2020-06-29',6,2,1)
INSERT INTO Education(name_institution,specialty,year_admission,date_end,id_questionnaire,id_education_degree,id_education_form) values('НТУ "ХПІ"','Прикладна математика',2020,'2022-01-12',6,4,2)
INSERT INTO Education(name_institution,specialty,year_admission,date_end,id_questionnaire,id_education_degree,id_education_form) values('ХНУРЕ','Комп’ютерні науки',2018,'2022-07-05',7,2,1)
go

-- 17. Кандидати
INSERT INTO Candidate(surname,name,father_name,login,password,phone,birthday,email,id_questionnaire) values('Петренко','Олена','Сергіївна','pTrnko23','hwWgo59s','+380661111111','1992-05-23','petrenko456@gmail.com',1)
INSERT INTO Candidate(surname,name,father_name,login,password,phone,birthday,email,id_questionnaire) values('Іваненко','Андрій','Володимирович','ivAneA79','dfNnbl21k','+380662222222','1979-09-17','ivanenko123@gmail.com',2)
INSERT INTO Candidate(surname,name,father_name,login,password,phone,birthday,email,id_questionnaire) values('Ковальов','Максим','Ігорович','ma_Kov2002','20aw-l24','+380953333333','2002-12-10','kovalm778@gmail.com',3)
INSERT INTO Candidate(surname,name,father_name,login,password,phone,birthday,email,id_questionnaire) values('Григоренко','Юлія','Олексіївна','2000_gRig','@pEpg5u8e','+380954444444','2000-04-09','hryhorenko321@gmail.com',4)
INSERT INTO Candidate(surname,name,father_name,login,password,phone,birthday,email,id_questionnaire) values('Ткаченко','Віталій','Васильович','tkA4_2003','abc3-@9gjg','+380685555555','2003-08-04','tkachenko654@gmail.com',5)
INSERT INTO Candidate(surname,name,father_name,login,password,phone,birthday,email,id_questionnaire) values('Шевченко','Сергій','Олександрович','shev4k99','@qwEr5Ty3','+380686666666','1999-03-22','shevchenko210@gmail.com',6)
INSERT INTO Candidate(surname,name,father_name,login,password,phone,birthday,email,id_questionnaire) values('Кравченко','Анастасія','Петрівна','nst2001','A.peg0bW2','+380687777777','2001-10-21','kravchenko543@gmail.com',7)
go

-- 18. Заявки
INSERT INTO Application(date_submission,additional_info,id_application_status,id_candidate,id_vacancy) values('2023-12-23 14:32:47',NULL,2,1,1)
INSERT INTO Application(date_submission,additional_info,id_application_status,id_candidate,id_vacancy) values('2023-12-25 07:22:55','У мене є великий стаж водіння.',2,2,2)
INSERT INTO Application(date_submission,additional_info,id_application_status,id_candidate,id_vacancy) values('2023-12-10 20:47:02',NULL,2,3,3)
INSERT INTO Application(date_submission,additional_info,id_application_status,id_candidate,id_vacancy) values('2024-01-03 15:44:15','Маю гарні навички комунікації.',2,4,4)
INSERT INTO Application(date_submission,additional_info,id_application_status,id_candidate,id_vacancy) values('2024-01-05 17:02:42',NULL,2,5,4)
INSERT INTO Application(date_submission,additional_info,id_application_status,id_candidate,id_vacancy) values('2023-12-28 12:06:23',NULL,3,6,4)
INSERT INTO Application(date_submission,additional_info,id_application_status,id_candidate,id_vacancy) values('2024-01-07 10:27:49',NULL,1,7,4)
go

-- 19. Співбесіди
INSERT INTO Interview(date_event,id_application,id_interview_status) values('2024-01-05 13:30:00',1,3)
INSERT INTO Interview(date_event,id_application,id_interview_status) values('2024-01-05 14:00:00',2,3)
INSERT INTO Interview(date_event,id_application,id_interview_status) values('2023-12-17 16:00:00',3,3)
INSERT INTO Interview(date_event,id_application,id_interview_status) values('2024-01-12 15:30:00',4,4)
go

-- 20. Співробітники(заповнюються автоматично тригером)

--------------------
ALTER database RecruitmentDB set multi_user
go