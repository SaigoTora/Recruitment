using System;

namespace RecruitmentLibrary.PersonInfo
{
    public class Candidate : Person
    {// Кандидат
        public Questionnaire questionnaire;// Анкета

        // Конструктори
        public Candidate() { }
        public Candidate(string surname, string name, string fatherName, string phone, DateTime birthday, string email, Questionnaire questionnaire) :
            base(surname, name, fatherName, phone, birthday, email)
        {
            this.questionnaire = questionnaire;
        }
        public Candidate(Candidate c) : base(c.Surname, c.Name, c.FatherName, c.Phone, c.Birthday, c.Email)
        {// Створюємо копію кандидата
            questionnaire = new Questionnaire(c.questionnaire);
        }
    }
}