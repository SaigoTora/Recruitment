using System;

namespace RecruitmentLibrary.ApplicationInfo
{
    public class Searcher
    {// Клас для зберігання інформації про пошук
        public string Position { get; private set; }// Посада
        public DateTime? MinDate { get; private set; }// Мінімальна дата

        public Searcher(string position, DateTime? minDate)
        {// Конструктор
            Position = position;
            MinDate = minDate;
        }
        public string GetFilter(string dateName)
        {// Метод повертає рядок для пошуку конкретних даних
            string result = string.Empty;
            if (Position != null && Position.Length != 0)// Посада
                result += $"AND position_name LIKE '%{Position}%' ";
            if (MinDate != null)// Дата
                result += $"AND {dateName} > '{MinDate:yyyy-MM-dd}' ";

            return result;
        }
    }
}