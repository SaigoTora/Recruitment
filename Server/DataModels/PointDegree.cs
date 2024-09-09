namespace ServerDB.DataModels
{
    internal class PointDegree
    {// Клас, який зберігає інформацію про ступінь освіти та кількість балів за цей ступінь
        internal int IdDegree { get; private set; }// Код ступеня освіти
        internal int Point { get; private set; }// Кількість балів
        internal PointDegree(int idDegree, int point)
        {// Коснтруктор
            IdDegree = idDegree;
            Point = point;
        }
    }
}