using System;

namespace RecruitmentLibrary.ApplicationInfo
{
    public class Application
    {// Заявка
        public Position Position { get; private set; }// Посада
        public string Status { get; private set; }// Статус
        public DateTime DateSubmission { get; private set; }// Дата і час подачі
        public string ReasonRejection { get; private set; }// Причина відмови

        public Application(Position position, string status, DateTime dateSubmission, string reasonRejection)
        {// Конструктор
            Position = position;
            Status = status;
            DateSubmission = dateSubmission;
            ReasonRejection = reasonRejection;
        }
    }
}