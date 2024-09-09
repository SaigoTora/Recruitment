namespace ServerDB.DataModels
{
    internal class Points
    {// Клас для зберігання інформації про бали
        internal int AgeUnder18 { get; private set; }// Вік: до 18
        internal int Age18_30 { get; private set; }// Вік: від 18 до 30
        internal int Age30_50 { get; private set; }// Вік: від 30 до 50
        internal int AgeOver50 { get; private set; }// Вік: більше 50
        internal int ExpNone { get; private set; }// Досвід роботи: немає
        internal int ExpUnderYear { get; private set; }// Досвід роботи: менше року
        internal int Exp1_3 { get; private set; }// Досвід роботи: від 1 до 3 років
        internal int ExpOver3 { get; private set; }// Досвід роботи: більше 3 років
        internal int Diploma { get; private set; }// Має диплом
        internal int NoChronicDiseases { get; private set; }// Немає хронічних захворювань
        internal int DriverLicense { get; private set; }// Має посвідчення водія
        internal int NoSmoker { get; private set; }// Не курець
        internal int NoDrinkAlcohol { get; private set; }// Не вживає алкоголь
        internal int BusinessTripOpportunity { get; private set; }// Є можливість відряджень
        internal PointDegree[] Degrees { get; set; }// Бали за певні ступені освіти

        internal Points() { }

        internal void Change(int ageUnder18, int age18_30, int age30_50, int ageOver50, int expNone, int expUnderYear, int exp1_3, int expOver3, int diploma, int noChronicDiseases, int driverLicense, int noSmoker, int noDrinkAlcohol, int businessTripOpportunity, PointDegree[] degrees)
        {// Метод, який змінює дані
            AgeUnder18 = ageUnder18;
            Age18_30 = age18_30;
            Age30_50 = age30_50;
            AgeOver50 = ageOver50;
            ExpNone = expNone;
            ExpUnderYear = expUnderYear;
            Exp1_3 = exp1_3;
            ExpOver3 = expOver3;
            Diploma = diploma;
            NoChronicDiseases = noChronicDiseases;
            DriverLicense = driverLicense;
            NoSmoker = noSmoker;
            NoDrinkAlcohol = noDrinkAlcohol;
            BusinessTripOpportunity = businessTripOpportunity;

            Degrees = new PointDegree[degrees.Length];
            for (int i = 0; i < degrees.Length; i++)
                Degrees[i] = degrees[i];
        }
    }
}