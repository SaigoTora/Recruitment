namespace ServerDB.DataModels
{
    internal class AssignmentItem
    {// Клас для вирішення задачі про призначення
        internal int IdVacancy { get; private set; }// Код вакансії
        internal int IdCandidate { get; private set; }// Код кандидата
        internal int Scores { get; private set; }// Кількість балів

        public AssignmentItem(int idVacancy, int idCandidate, int scores)
        {// Конструктор
            IdVacancy = idVacancy;
            IdCandidate = idCandidate;
            Scores = scores;
        }
    }
}