using System;
using RecruitmentLibrary.ApplicationInfo;

namespace RecruitmentUser.ClientUtilities
{
    internal enum ClientSortOption : byte
    {// Перелік параметрів сортування
        Date,// За датою
        Alphabet,// За алфавітом
        Salary// За зарплатою
    }
    internal class ClientSearcher : Searcher
    {// Клас для зберігання інформації про пошук у клієнта
        internal int? MinSalary { get; private set; }// Мінімальна зарплата
        internal int? MaxSalary { get; private set; }// Максимальна зарплата
        internal ClientSortOption SortOption { get; private set; }// Параметр сортування

        internal ClientSearcher(string position, DateTime? minDate, int? minSalary, int? maxSalary, ClientSortOption sortOption) :
            base(position, minDate)
        {// Конструктор
            MinSalary = minSalary;
            MaxSalary = maxSalary;
            SortOption = sortOption;
        }

        internal new string GetFilter(string dateName)
        {// Метод повертає рядок для пошуку конкретних даних
            string result = base.GetFilter(dateName);

            if (MinSalary != null)// Мін. зарплата
                result += $"AND salary >= {MinSalary} ";
            if (MaxSalary != null)// Макс. зарплата
                result += $"AND salary <= {MaxSalary} ";

            return result.TrimEnd(' ');
        }
        internal string GetSort(string dateName)
        {// Метод команду для сортування даних
            string result = "ORDER BY ";
            if (SortOption == ClientSortOption.Date)
                result += $"{dateName} DESC";
            else if (SortOption == ClientSortOption.Alphabet)
                result += "position_name ASC";
            else if (SortOption == ClientSortOption.Salary)
                result += "salary DESC";
            else
                result = string.Empty;

            return result;
        }
    }
}