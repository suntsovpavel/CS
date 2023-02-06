//Задача 2: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.

// возвращаем flag=true, если элемент с заданными индексами имеется
(int value, bool flag) getElement(
    int[,] arr,
    int index_i,
    int index_j)
{
    if (index_i < 0
    || index_i >= arr.GetLength(0)
    || index_j < 0
    || index_j >= arr.GetLength(1))
    {
        return (0, false);
    }
    else
    {
        return (arr[index_i, index_j], true);
    }
}

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

//using code:
//Пусть задан массив размером 4 на 5:
int[,] matrix = CreateMatrix(4, 5);
PrintMatrix(matrix);

int index_i = PromptInt("Введите индекс строки в массиве");
int index_j = PromptInt("Введите индекс столбца в массиве");

(int value, bool flag) = getElement(matrix, index_i, index_j);
if (flag)
{
    System.Console.WriteLine($"Элемент найден, array[{index_i}, {index_j}] = {matrix[index_i, index_j]}");
}
else
{
    System.Console.WriteLine($"Элемента с индексами [{index_i}, {index_j}] в массиве нет");
}