//Задача 1: Задайте двумерный массив. Напишите программу, которая упорядочивает по убыванию элементы каждой строки двумерного массива.

int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

void PrintArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        System.Console.Write($"{arr[i]}\t");
    }
}

void PrintMatrix(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            System.Console.Write($"{matr[i, j]}\t");
        }
        System.Console.WriteLine();
    }
}

int[,] CreateMatrix(
    int rows,
    int columns,
    int minLimit = 0,
    int maxLimit = 10)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rnd.Next(minLimit, maxLimit);
        }
    }
    return matrix;
}

// В матрице matrix упорядочиваем элементы каждой строки по убыванию
// Используем алгоритм для упорядочивания одномерного массива, лекция 3
void DescendingSortingRowsMatrix(int[,] matrix)
{
    for (int k = 0; k < matrix.GetLength(0); k++)
    {
        for (int i = 0; i < matrix.GetLength(1) - 1; i++)
        {
            int maxPosition = i;
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[k, j] > matrix[k, maxPosition]) maxPosition = j;
            }
            int temp = matrix[k, i];
            matrix[k, i] = matrix[k, maxPosition];
            matrix[k, maxPosition] = temp;
        }
    }
}

//using code:
int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
if (m < 1) { System.Console.WriteLine($"Некорректное количество строк: {m}"); return; }
if (n < 1) { System.Console.WriteLine($"Некорректное количество столбцов: {n}"); return; }

int[,] matrix = CreateMatrix(rows : m, columns : n, minLimit : 0, maxLimit : 100);
PrintMatrix(matrix);

DescendingSortingRowsMatrix(matrix);
Console.WriteLine("Матрица со строками, упорядоченными по убыванию:");
PrintMatrix(matrix);