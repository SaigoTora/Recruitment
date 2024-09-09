using System;
using RecruitmentLibrary.ApplicationInfo;

namespace ServerDB.DataModels
{
    internal class FullVacancy : Vacancy
    {// Клас з повною інформацією про вакансію
        internal bool Relevance { get; private set; }// Актуальність
        internal int ApplicationCount { get; private set; }// Кількість заявок
        internal int IdPoint { get; private set; }// Код таблиці з балами
        internal int IdRequirement { get; private set; }// Код вимоги

        internal FullVacancy(int id, Position position, double salary, DateTime datePublication, string info,
            bool relevance, int applicationCount, int idPoint, int idRequirement) :
            base(id, position, salary, datePublication, info)
        {// Конструктор
            Relevance = relevance;
            ApplicationCount = applicationCount;
            IdPoint = idPoint;
            IdRequirement = idRequirement;
        }
    }
}