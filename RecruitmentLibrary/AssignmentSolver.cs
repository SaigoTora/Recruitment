using System;

namespace RecruitmentLibrary
{
    public class AssignmentSolver
    {// Клас який вирішує задачу про призначення
        private readonly struct Location
        {// Допоміжна структура
            internal readonly int row;// Рядок
            internal readonly int column;// Стовпець

            internal Location(int row, int column)
            {// Конструктор
                this.row = row;
                this.column = column;
            }
        }
        public static int[] HungarianAlgorithm(int[,] costs, bool findMax)
        {// Метод, який вирішує задачу про призначення угорським алгоритмом
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            int n = costs.GetLength(0);// Початкові розміри матриці:
            int m = costs.GetLength(1);// кількість рядків та кількість стовпців
            if (costs.GetLength(0) != costs.GetLength(1))
                costs = CreateSquareMatrix(costs);// Перетворення матрциці на квадратну

            if (findMax)
            {// Якщо задача вирішується на максимум
                for (int i = 0; i < costs.GetLength(0); i++)
                {
                    int max = costs[i, 0];// Максимальне значення матриці
                    for (int j = 0; j < costs.GetLength(1); j++)
                        max = Math.Max(max, costs[i, j]);

                    for (int j = 0; j < costs.GetLength(1); j++)
                        costs[i, j] = max - costs[i, j];
                }
            }

            int height = costs.GetLength(0);// Кількість рядків та стовпців
            int width = costs.GetLength(1);

            for (int i = 0; i < height; i++)
            {// Редукція по рядках
                int min = int.MaxValue;// Мінімальне значення в поточному рядку
                for (int j = 0; j < width; j++)
                    min = Math.Min(min, costs[i, j]);

                for (int j = 0; j < width; j++)
                    costs[i, j] -= min;
            }
            for (int i = 0; i < width; i++)
            {// Редукція по стовпцях
                int min = int.MaxValue;// Мінімальне значення в поточному стовпці
                for (int j = 0; j < height; j++)
                    min = Math.Min(min, costs[j, i]);

                for (int j = 0; j < height; j++)
                    costs[j, i] -= min;
            }

            byte[,] masks = new byte[height, width];
            bool[] rowsCovered = new bool[height];
            bool[] colsCovered = new bool[width];

            // Отримуємо маску, де позначаємо цифрою 1 ті елементи, які є нулем
            // у початковій матриці та не мають на перетині 0, які були розглянуті
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (costs[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
                    {
                        masks[i, j] = 1;
                        rowsCovered[i] = true;
                        colsCovered[j] = true;
                    }

            ClearCovers(rowsCovered, colsCovered);

            Location[] path = new Location[width * height];
            Location pathStart = default;
            int step = 1;

            while (step != -1)
            {
                if (step == 1)
                    step = RunStep1(masks, colsCovered);
                if (step == 2)
                    step = RunStep2(costs, masks, rowsCovered, colsCovered, ref pathStart);
                if (step == 3)
                    step = RunStep3(masks, rowsCovered, colsCovered, path, pathStart);
                if (step == 4)
                    step = RunStep4(costs, rowsCovered, colsCovered);
            }

            // Приводимо матрицю-маску до потрібного розміру
            byte[,] newMasks = new byte[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    newMasks[i, j] = masks[i, j];

            // Результуючий масив, де індекс - робітник, а значення - задача
            int[] agentsTasks = new int[newMasks.GetLength(0)];

            for (int i = 0; i < newMasks.GetLength(0); i++)
                for (int j = 0; j < newMasks.GetLength(1); j++)
                {
                    if (newMasks[i, j] == 1)
                    {
                        agentsTasks[i] = j;
                        break;
                    }
                    else if (j == newMasks.GetLength(1) - 1)
                        agentsTasks[i] = -1;// Якщо робітнику не вистачило задачі
                }

            return agentsTasks;
        }

        private static int[,] CreateSquareMatrix(int[,] matrix)
        {// Метод перетворює матрицю на квадратну
            if (matrix.GetLength(0) == matrix.GetLength(1))
                return matrix;// Якщо матриця квадратна

            int maxLength = Math.Max(matrix.GetLength(0), matrix.GetLength(1));
            int[,] buf = new int[maxLength, maxLength];
            int max = matrix[0, 0];// Максимальне значення матриці

            for (int i = 0; i < matrix.GetLength(0); i++)// Записуємо в массив існуючі елементи
                for (int j = 0; j < matrix.GetLength(1); j++)// та знаходимо максимальний
                {
                    buf[i, j] = matrix[i, j];
                    max = Math.Max(max, matrix[i, j]);
                }

            if (matrix.GetLength(0) > matrix.GetLength(1))
            {// Якщо рядків більше, ніж стовпців
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = matrix.GetLength(1); j < matrix.GetLength(0); j++)
                        buf[i, j] = max;
            }
            else
            {// Якщо стовпців більше, ніж рядків
                for (int i = matrix.GetLength(0); i < matrix.GetLength(1); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        buf[i, j] = max;
            }
            return buf;
        }
        private static int RunStep1(byte[,] masks, bool[] colsCovered)
        {// Метод, який заповнює масив colsCovered та повертає число наступного кроку(2 або -1)
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            // Помічаємо дані в colsCovered
            for (int i = 0; i < masks.GetLength(0); i++)
                for (int j = 0; j < masks.GetLength(1); j++)
                    if (masks[i, j] == 1)
                        colsCovered[j] = true;

            // Знаходимо кількість закреслених стовпців
            int colsCoveredCount = 0;
            for (int j = 0; j < colsCovered.Length; j++)
                if (colsCovered[j])
                    colsCoveredCount++;

            // Якщо закреслено всі стовпці, то це останній крок в циклі
            if (colsCoveredCount == colsCovered.Length)
                return -1;

            return 2;// Інакше переходимо до кроку 2
        }
        private static int RunStep2(int[,] costs, byte[,] masks, bool[] rowsCovered, bool[] colsCovered, ref Location pathStart)
        {// Метод, який змінює масиви colsCovered та rowsCovered, а також повертає число наступного кроку(4 або 3)
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            while (true)
            {
                Location location = FindZero(costs, rowsCovered, colsCovered);
                if (location.row == -1)// Якщо не було знайдено не закреслений нуль
                    return 4;// Переходимо до кроку 4

                masks[location.row, location.column] = 2;

                int indexCol = FindIndexInRow(masks, location.row);
                if (indexCol != -1)
                {// Якщо індекс був знайдений
                    rowsCovered[location.row] = true;
                    colsCovered[indexCol] = false;
                }
                else
                {
                    pathStart = location;
                    return 3;// Переходимо до кроку 3
                }
            }
        }
        private static int RunStep3(byte[,] masks, bool[] rowsCovered, bool[] colsCovered, Location[] path, Location pathStart)
        {// Метод, який змінює масив path, а також повертає число наступного кроку(1)
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            int pathIndex = 0;
            path[0] = pathStart;

            while (true)
            {
                int row = FindIndexInColumn(masks, path[pathIndex].column);
                if (row == -1)
                    break;

                pathIndex++;
                path[pathIndex] = new Location(row, path[pathIndex - 1].column);

                int col = FindPrimeInRow(masks, path[pathIndex].row);

                pathIndex++;
                path[pathIndex] = new Location(path[pathIndex - 1].row, col);
            }

            ConvertPath(masks, path, pathIndex + 1);
            ClearCovers(rowsCovered, colsCovered);
            ClearPrimes(masks);

            return 1;// Переходимо до кроку 1
        }
        private static int RunStep4(int[,] costs, bool[] rowsCovered, bool[] colsCovered)
        {// Метод, який змінює дані в costs та повертає число наступного кроку(2)
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            int minValue = FindMinimum(costs, rowsCovered, colsCovered);

            // Додаємо або віднімаємо мінімум в залежності від закреслення
            for (int i = 0; i < costs.GetLength(0); i++)
                for (int j = 0; j < costs.GetLength(1); j++)
                {
                    if (rowsCovered[i])
                        costs[i, j] += minValue;
                    if (!colsCovered[j])
                        costs[i, j] -= minValue;
                }

            return 2;// Переходимо до кроку 2
        }

        private static int FindMinimum(int[,] costs, bool[] rowsCovered, bool[] colsCovered)
        {// Метод, який знаходить мінімальне значення серед НЕ викреслених елементів
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            int minValue = int.MaxValue;

            for (int i = 0; i < costs.GetLength(0); i++)
                for (int j = 0; j < costs.GetLength(1); j++)
                    if (!rowsCovered[i] && !colsCovered[j])
                        minValue = Math.Min(minValue, costs[i, j]);

            return minValue;
        }
        private static int FindIndexInRow(byte[,] masks, int row)
        {// Метод повертає індекс стовпця, якщо в певному рядку є одиниця
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            for (int j = 0; j < masks.GetLength(1); j++)
                if (masks[row, j] == 1)
                    return j;

            return -1;// Якщо не було знайдено
        }
        private static int FindIndexInColumn(byte[,] masks, int col)
        {// Метод повертає індекс рядка, якщо у певному стовпці є одиниця
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            for (int i = 0; i < masks.GetLength(0); i++)
                if (masks[i, col] == 1)
                    return i;

            return -1;// Якщо не було знайдено
        }
        private static int FindPrimeInRow(byte[,] masks, int row)
        {// Метод повертає індекс стовпця, якщо в певному рядку є двійка
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            for (int j = 0; j < masks.GetLength(1); j++)
                if (masks[row, j] == 2)
                    return j;

            return -1;// Якщо не було знайдено
        }
        private static Location FindZero(int[,] costs, bool[] rowsCovered, bool[] colsCovered)
        {// Метод повертає позицію першого не закресленого нуля
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            for (int i = 0; i < costs.GetLength(0); i++)
                for (int j = 0; j < costs.GetLength(1); j++)
                    if (costs[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
                        return new Location(i, j);

            // Якщо нуля не було знайдено
            return new Location(-1, -1);
        }
        private static void ConvertPath(byte[,] masks, Location[] path, int pathLength)
        {// Метод, який змінює дані в матриці masks
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (path == null)
                throw new ArgumentNullException(nameof(path));

            int row, column;
            for (int i = 0; i < pathLength; i++)
            {
                row = path[i].row;
                column = path[i].column;

                if (masks[row, column] == 1)
                    masks[row, column] = 0;

                else if (masks[row, column] == 2)
                    masks[row, column] = 1;
            }
        }
        private static void ClearPrimes(byte[,] masks)
        {// Метод, який записує 0 для елементів зі значенням 2
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            for (var i = 0; i < masks.GetLength(0); i++)
                for (var j = 0; j < masks.GetLength(1); j++)
                    if (masks[i, j] == 2)
                        masks[i, j] = 0;
        }
        private static void ClearCovers(bool[] rowsCovered, bool[] colsCovered)
        {// Метод, який записує false для булевих масивів
            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            if (rowsCovered.Length == colsCovered.Length)
                for (int i = 0; i < rowsCovered.Length; i++)
                {// Якщо їх довжина однакова
                    rowsCovered[i] = false;
                    colsCovered[i] = false;
                }
            else
            {// Якщо їх довжина різна
                for (int i = 0; i < rowsCovered.Length; i++)
                    rowsCovered[i] = false;
                for (int i = 0; i < colsCovered.Length; i++)
                    colsCovered[i] = false;
            }
        }
    }
}