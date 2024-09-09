namespace RecruitmentLibrary.ApplicationInfo
{
    public class Position
    {// Посада
        public string Name { get; private set; }// Посада
        public string Description { get; private set; }// Опис посади

        public Position(string name, string description)
        {// Конструктор
            Name = name;
            Description = description;
        }
    }
}