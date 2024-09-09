namespace RecruitmentUser.ClientUtilities
{
    internal static class StaticDataFromDB
    {// Статичний клас, який зберігає статичну інформацію з БД
        internal static string[] FamilyStatuses { get; private set; }// Сімейні стани
        internal static string[] BusinessTripOpportunities { get; private set; }// Можливості відряджень

        internal static void SetData()
        {// Метод, який встановлює значення властивостям, якщо вони ще не встановленні
            if (FamilyStatuses == null && BusinessTripOpportunities == null)
            {
                FamilyStatuses = Client.GetFamilyStatuses();
                BusinessTripOpportunities = Client.GetBusinessTripOpportunities();
            }
        }
    }
}