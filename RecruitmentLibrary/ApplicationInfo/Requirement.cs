namespace RecruitmentLibrary.ApplicationInfo
{
    public class Requirement
    {// Клас із вимогами до кандидата
        public string City { get; set; }// Місто/село проживання
        public byte AgeMin { get; set; }// Мінімальний вік
        public byte AgeMax { get; set; }// Максимальний вік
        public int ExpMin { get; set; }// Мінімальний досвід роботи(в місяцях)
        public bool Diploma { get; set; }// Має диплом
        public bool NoChronicDiseases { get; set; }// Немає хронічних захворювань
        public bool DriverLicense { get; set; }// Є посвідчення водія
        public bool NoSmoker { get; set; }// Не курець
        public bool NoDrinkAlcohol { get; set; }// Не вживає алкоголь
        public bool BusinessTripOpportunity { get; set; }// Є можливості відряджень
        public bool? Student { get; set; }// Є студентом

        // Конструктори
        public Requirement()
        { }
        public Requirement(string city, byte ageMin, byte ageMax, int expMin,
            bool diploma, bool noChronicDiseases, bool driverLicense, bool noSmoker,
            bool noDrinkAlcohol, bool businessTripOpportunity, bool? student)
        {
            City = city;
            AgeMin = ageMin;
            AgeMax = ageMax;
            ExpMin = expMin;
            Diploma = diploma;
            NoChronicDiseases = noChronicDiseases;
            DriverLicense = driverLicense;
            NoSmoker = noSmoker;
            NoDrinkAlcohol = noDrinkAlcohol;
            BusinessTripOpportunity = businessTripOpportunity;
            Student = student;
        }

        public override string ToString()
        {
            string res = string.Empty;
            int number = 1;

            if (City != null)
                res += $"{number++}. Місце проживання: {City}.\n";
            if (AgeMin == AgeMax)
                res += $"{number++}. Вік: {AgeMin} р.\n";
            else
                res += $"{number++}. Вік: від {AgeMin} до {AgeMax}.\n";
            if (ExpMin != 0)
                res += $"{number++}. Мінімальний досвід роботи: {ExpMin} міс.\n";
            if (Diploma)
                res += $"{number++}. Наявність диплому.\n";
            if (NoChronicDiseases)
                res += $"{number++}. Відсутність хронічних захворювань.\n";
            if (DriverLicense)
                res += $"{number++}. Наявність посвідчення водія.\n";
            if (NoSmoker)
                res += $"{number++}. Кандидат НЕ повинен бути курцем.\n";
            if (NoDrinkAlcohol)
                res += $"{number++}. Кандидат НЕ повинен вживати алкогольні напої.\n";
            if (BusinessTripOpportunity)
                res += $"{number++}. Можливість відряджень.\n";

            if (Student != null && Student.Value)
                res += $"{number++}. Кандидат повинен бути студентом.\n";
            if (Student != null && !Student.Value)
                res += $"{number++}. Кандидат НЕ повинен студентом.\n";

            if (number == 2)
                res = res.Remove(0, 3);
            return res.TrimEnd('\n');
        }
    }
}