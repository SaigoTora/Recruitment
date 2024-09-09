using System;

namespace RecruitmentLibrary.ApplicationInfo
{
    public class Vacancy
    {// Вакансія
        public int Id { get; private set; }// Код вакансії
        public Position Position { get; private set; }// Посада
        public double Salary { get; private set; }// Зарплата
        public DateTime DatePublication { get; private set; }// Дата і час публікації
        public string Info { get; private set; }// Додаткова інформація

        public Vacancy(int id, Position position, double salary, DateTime datePublication, string info)
        {// Конструктор
            Id = id;
            Position = position;
            Salary = salary;
            DatePublication = datePublication;
            Info = info;
        }
    }
}