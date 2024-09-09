using System;

namespace RecruitmentLibrary.PersonInfo
{
    public class Education
    {// Освіта
        public string NameInstitution { get; private set; }// Назва закладу
        public string Specialty { get; private set; }// Спеціальність
        public int YearAdmission { get; private set; }// Рік вступу
        public DateTime DateEnd { get; private set; }// Дата закінчення
        public int ID_EducationDegree { get; private set; }// Код ступеня освіти
        public int ID_EducationForm { get; private set; }// Код форми навчання

        // Конструктори
        public Education(string nameInstitution, string specialty, int yearAdmission,
            DateTime dateEnd, int id_EducationDegree, int id_EducationForm)
        {
            NameInstitution = nameInstitution;
            Specialty = specialty;
            YearAdmission = yearAdmission;
            DateEnd = dateEnd;
            ID_EducationDegree = id_EducationDegree;
            ID_EducationForm = id_EducationForm;
        }
        public Education(Education e)
        {// Створюємо копію освіти
            NameInstitution = e.NameInstitution;
            Specialty = e.Specialty;
            YearAdmission = e.YearAdmission;
            DateEnd = e.DateEnd;
            ID_EducationDegree = e.ID_EducationDegree;
            ID_EducationForm = e.ID_EducationForm;
        }
    }
}