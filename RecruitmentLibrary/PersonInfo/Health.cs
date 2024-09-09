namespace RecruitmentLibrary.PersonInfo
{
    public class Health
    {// Здоров’я
        public string ChronicDiseases { get; private set; }// Хронічні захворювання
        public bool Smoker { get; private set; }// Курець?
        public bool DrinkAlcohol { get; private set; }// Вживає спиртні напої?

        // Конструктори
        public Health(string chronicDiseases, bool smoker, bool drinkAlcohol)
        {
            ChronicDiseases = chronicDiseases;
            Smoker = smoker;
            DrinkAlcohol = drinkAlcohol;
        }
        public Health(Health h)
        {// Створюємо копію здоров’я
            ChronicDiseases = h.ChronicDiseases;
            Smoker = h.Smoker;
            DrinkAlcohol = h.DrinkAlcohol;
        }
    }
}