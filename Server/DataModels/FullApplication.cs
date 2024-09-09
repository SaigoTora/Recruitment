using System;

using RecruitmentLibrary.ApplicationInfo;

namespace ServerDB.DataModels
{
    internal class FullApplication : Application
    {// Клас з повною інформацією про заявку
        internal int Id { get; private set; }// Код заявки
        internal int Scores { get; private set; }// Кількість балів
        internal string AdditionalInfo { get; private set; }// Додаткова інформація від кандидата
        internal int IdCandidate { get; private set; }// Код кандидата
        internal int IdVacancy { get; private set; }// Код вакансії

        internal FullApplication(int id, Position position, string status, DateTime dateSubmission, string reasonRejection, int scores, string additionalInfo, int idCandidate, int idVacancy)
            : base(position, status, dateSubmission, reasonRejection)
        {// Конструктор
            Id = id;
            Scores = scores;
            AdditionalInfo = additionalInfo;
            IdCandidate = idCandidate;
            IdVacancy = idVacancy;
        }
    }
}