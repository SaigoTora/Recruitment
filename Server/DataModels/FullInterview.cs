using System;
using RecruitmentLibrary.ApplicationInfo;

namespace ServerDB.DataModels
{
    internal class FullInterview : Interview
    {// Клас з повною інформацією про співбесіду
        internal int Id { get; private set; }// Код
        internal int IdApplication { get; private set; }// Код заявки

        internal FullInterview(int id, Position position, string status, DateTime dateEvent, int idApplication)
            : base(position, status, dateEvent)
        {// Конструктор
            Id = id;
            IdApplication = idApplication;
        }
    }
}