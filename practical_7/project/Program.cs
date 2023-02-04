int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}
double PromptDbl(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToDouble(Console.ReadLine());
}

// Задача 1: Задайте двумерный массив размером m×n, заполненный случайными целыми числами.
// m = 3, n = 4
// 1     4    8   19
// 5   -2  33   -2
// 77  3    8    1

void PrintArray(int[,] matr)
{
    //System.Console.WriteLine($"[");
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            System.Console.Write($"{matr[i, j]}\t");
        }
        System.Console.WriteLine();
    }
    // System.Console.WriteLine($"]");
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

/*
int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = CreateMatrix(m,n);
PrintArray(matrix);*/

// Задача 1: Задайте двумерный массив размера m на n, 
//каждый элемент в массиве находится по формуле: Aₘₙ = m+n. 
//Выведите полученный массив на экран.
// m = 3, n = 4.
// 0 1 2 3
// 1 2 3 4
// 2 3 4 5
/*
int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = new int[m, n];
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = i + j;
    }
}
PrintArray(matrix);*/

// Задача 2: Задайте двумерный массив. Найдите элементы, у которых обе позиции чётные, 
//и замените эти элементы на их квадраты.
// Например, изначально массив выглядел вот так:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
//Новый массив будет выглядеть вот так:
// 1   4  7  2
// 5  81  2  9
// 8   4  2  4
void ModifyArray(int[,] matrix)
{
    for (int i = 1; i < matrix.GetLength(0); i += 2)
    {
        for (int j = 1; j < matrix.GetLength(1); j += 2)
        {
            matrix[i, j] *= matrix[i, j];     //Math.Pow не канает, ибо return double
        }
    }
}

/*
int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = CreateMatrix(m, n);
System.Console.WriteLine("Массив до преобразования:");
PrintArray(matrix);
ModifyArray(matrix);
System.Console.WriteLine("Массив после преобразования:");
PrintArray(matrix);*/

// Задача 3: Задайте двумерный массив. Найдите сумму элементов главной диагонали.
// Например, задан массив:
// 1   4   7
// 5   9   2
// 8   4   2
// Сумма элементов главной диагонали: 1+9+2 = 12
int SumMainDiagonal(int[,] matrix)
{
    int upIndex = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
    int sum = 0;
    for (int i = 0; i < upIndex; i++)
    {
        sum += matrix[i, i];
    }
    return sum;
}

bool ValidateSquareMatrix(int[,] matrix)
{
    return matrix.GetLength(0) == matrix.GetLength(1);
}
/*
int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = CreateMatrix(m, n);
PrintArray(matrix);
System.Console.WriteLine($"Сумма элементов по главной диагонали: {SumMainDiagonal(matrix)}");*/


// Задача 4: Задайте двумерный массив. Введите элемент, и найдите первое его вхождение, выведите позиции по горизонтали и вертикали, или напишите, что такого элемента нет.
// Например, такой массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Введенный элемент 2, результат: [1, 4]
// Введенный элемент 6, результат: такого элемента нет.
void SearchElement(int[,] matrix, int value)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == value)
            {
                System.Console.WriteLine($"Элемент {value} найден, позиция: [{i + 1},{j + 1}]");
                return;
            }
        }
    }
    System.Console.WriteLine($"Элемент {value} НЕ найден");
}

(int i, int j) SearchElement2(int[,] matrix, int value)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == value) return (i, j);
        }
    }
    return (-1, -1);
}
/*
int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = CreateMatrix(m, n);
PrintArray(matrix);
//SearchElement(matrix, PromptInt("Введите искомое значение: "));

int num = PromptInt("Введите искомое значение: ");
(int i, int j) = SearchElement2(matrix, num);
if(i == -1){
    System.Console.WriteLine($"Элемент {num} НЕ найден");
}else{
    System.Console.WriteLine($"Элемент {num} найден, позиция: [{i + 1},{j + 1}]");
}*/


// Задача 5: Задайте двумерный массив. Найдите максимальный элемент массива 
// и среднее арифметическое всех элементов массива.
// Например, такой массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

int MaxElement(int[,] arr)
{
    //!!! Проверить, что размерности не нулевые
    int max = arr[0, 0];
    foreach (int item in arr)
    {
        if (max < item) max = item;
    }
    return max;
}

double AverageElements(int[,] array)
{
    double sum = 0;
    foreach (int item in array)
    {
        sum += item;
    }
    return sum / array.Length;
}

int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = CreateMatrix(m, n);
PrintArray(matrix);
System.Console.WriteLine($"Максимум = {MaxElement(matrix)}");
System.Console.WriteLine($"Среднее = {AverageElements(matrix)}");

//Обращение к элементу кортежа
//(int a, int b) s = (2, 3);
//System.Console.WriteLine(s.a);
