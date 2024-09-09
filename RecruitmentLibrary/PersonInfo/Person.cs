using System;

namespace RecruitmentLibrary.PersonInfo
{
    public class Person
    {// Людина
        public string Surname { get; private set; }// Прізвище
        public string Name { get; private set; }// Ім’я
        public string FatherName { get; private set; }// По-батькові
        public string Phone { get; private set; }// Номер телефону
        public DateTime Birthday { get; private set; }// Дата народження
        public string Email { get; private set; }// E-mail

        // Конструктори
        public Person() { }
        public Person(string surname, string name, string fatherName, string phone, DateTime birthday, string email)
        {
            Surname = surname;
            Name = name;
            FatherName = fatherName;
            Phone = phone;
            Birthday = birthday;
            Email = email;
        }
    }
}