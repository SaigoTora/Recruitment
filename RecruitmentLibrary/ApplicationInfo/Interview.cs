using System;

namespace RecruitmentLibrary.ApplicationInfo
{
    public class Interview
    {// Співбесіда
        public Position Position { get; private set; }// Посада
        public string Status { get; private set; }// Статус
        public DateTime DateEvent { get; private set; }// Дата і час проведення

        public Interview(Position position, string status, DateTime dateEvent)
        {// Конструктор
            Position = position;
            Status = status;
            DateEvent = dateEvent;
        }

        public void ChangeDate(DateTime dateTime)
        {// Метод, який змінює дату проведення співбесіди
            DateEvent = dateTime;
        }
    }
}