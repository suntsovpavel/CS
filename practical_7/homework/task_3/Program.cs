﻿// Задача 3: Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

int[,] CreateMatrix(int m, int n)
{
    int[,] matrix = new int[m, n];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(0, 10);
        }
    }
    return matrix;
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

void PrintArray(
    double[] array,
    int numberRound = 5)    //количество цифр после запятой (округление))
{
    foreach (double item in array)
    {
        System.Console.Write($"{Math.Round(item, numberRound)}\t");
    }
    System.Console.WriteLine();
}

// Для столбца матрицы, заданного индексом index_column, возвращаем среднее арифметическое значений
// Проверку наличия столбца в матрице по индексу не выполняем, так как функция вызывается в цикле for (int i = 0; i < matrix.GetLength(1); i++)
double AverageColumn(
    int[,] matrix,
    int index_column)
{
    double sum = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sum += matrix[i, index_column];
    }
    return sum / matrix.GetLength(0);
}

// Формируем массив, последовательно составленный из средних арифметических по столбцам матрицы 
double[] GetAllAveragesColumn(int[,] matrix)
{
    double[] result = new double[matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        result[i] = AverageColumn(matrix, i);
    }
    return result;
}


//using code:
int m = PromptInt("Введите количество строк массива");
int n = PromptInt("Введите количество столбцов массива");
if (m < 1)
{
    System.Console.WriteLine($"Некорректное количество строк: {m}");
}
else if (n < 1)
{
    System.Console.WriteLine($"Некорректное количество столбцов: {n}");
}
else
{
    int[,] matrix = CreateMatrix(m, n);
    PrintMatrix(matrix);

    //Формируем массив, составленный из средних арифметических по столбцам матрицы:
    double[] averages = GetAllAveragesColumn(matrix);
    System.Console.WriteLine("Значения средних арифметических по столбцам матрицы:");
    PrintArray(averages);
}

