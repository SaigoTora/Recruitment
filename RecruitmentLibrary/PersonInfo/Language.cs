namespace RecruitmentLibrary.PersonInfo
{
    public class Language
    {// Мова
        public string Name { get; private set; }// Мова
        public int Level { get; private set; }// Рівень

        // Конструктори
        public Language(string name, int level)
        {
            Name = name;
            Level = level;
        }
        public Language(Language l)
        {// Створюємо копію мови
            Name = l.Name;
            Level = l.Level;
        }
    }
}