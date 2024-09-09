using System;

namespace RecruitmentLibrary.PersonInfo
{
    public class Employee : Person
    {// Співробітник
        public int Id { get; private set; }// Код
        public string Position { get; private set; }// Посада
        public string City { get; private set; }// Місце проживання
        public double Salary { get; private set; }// Зарплата
        public DateTime DateEmployment { get; private set; }// Дата працевлаштування

        public Employee(int id, string surname, string name, string fatherName, string phone, DateTime birthday, string email,
            string position, string city, double salary, DateTime dateEmployment) :
            base(surname, name, fatherName, phone, birthday, email)
        {// Конструктор
            Id = id;
            Position = position;
            City = city;
            Salary = salary;
            DateEmployment = dateEmployment;
        }

        public void ChangeSalary(double newSalary) => Salary = newSalary;
        public void ChangePosition(string newPosition) => Position = newPosition;
    }
}