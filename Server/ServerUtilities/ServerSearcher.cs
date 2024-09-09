using System;
using RecruitmentLibrary.ApplicationInfo;

namespace ServerDB.ServerUtilities
{
    internal enum ServerSortOption : byte
    {// Перелік параметрів сортування
        Date,// За датою
        AlphabetPosition,// За алфавітом посади
        AlphabetName,// За алфавітом ПІБ
        NumberOfApplications,// За кількістю заявок
        NumberOfPoints,// За кількістю балів
    }
    internal class ServerSearcher : Searcher
    {
        internal int? Min { get; private set; }// Мінімальна кількість (заявок у вакансії або балів у заявки)
        internal int? Max { get; private set; }// Максимальна кількість (заявок у вакансії або балів у заявки)
        internal bool? IsRelevance { get; private set; }// Чи актуальна (вакансія)
        internal string Status { get; private set; }// Статус (заявок або співбесід)
        internal string FullName { get; private set; }// ПІБ (співробітників)
        internal ServerSortOption SortOption { get; private set; }// Параметр сортування

        internal ServerSearcher(string position, DateTime? minDate, int? min, int? max,
            bool? isRelevance, string status, string fullName, ServerSortOption sortOption)
            : base(position, minDate)
        {// Конструктор
            Min = min;
            Max = max;
            IsRelevance = isRelevance;
            Status = status;
            FullName = fullName;
            SortOption = sortOption;
        }

        internal string GetFilter(string dateName, string minMaxName)
        {// Метод повертає рядок для пошуку конкретних даних
            string result = "1 = 1 " + GetFilter(dateName);

            if (Min != null)// Мінімум
                result += $"AND {minMaxName} >= {Min} ";
            if (Max != null)// Максимум
                result += $"AND {minMaxName} <= {Max} ";
            if (IsRelevance != null)// Актуальність
                result += $"AND relevance = '{IsRelevance}' ";
            if (Status != null && Status.Length > 0)
                result += $"AND  status = '{Status}' ";
            if (FullName != null && FullName.Length > 0)
                result += $"AND surname LIKE '%{FullName}%' OR" +
                    $" name LIKE '%{FullName}%' OR father_name LIKE '%{FullName}%' ";

            return result.TrimEnd(' ');
        }
        internal string GetSort(string dateName)
        {// Метод команду для сортування даних
            string result = "ORDER BY ";
            if (SortOption == ServerSortOption.Date)
                result += $"{dateName} DESC";
            else if (SortOption == ServerSortOption.AlphabetPosition)
                result += $"position_name ASC";
            else if (SortOption == ServerSortOption.AlphabetName)
                result += $"surname,name,father_name ASC";
            else if (SortOption == ServerSortOption.NumberOfApplications)
                result += "application_count DESC";
            else if (SortOption == ServerSortOption.NumberOfPoints)
                result += "scores DESC";
            else
                result = string.Empty;

            return result;
        }
    }
}