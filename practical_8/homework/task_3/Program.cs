// Задача 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
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

int[,] ProductMatrix(int[,] matrixA, int[,] matrixB)
{  
    int[,] result = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int i = 0; i < matrixA.GetLength(0); i++)
    {
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            //Перемножаем строку матрицы А на столбец матрицы В
            result[i, j] = 0;
            for (int k = 0; k < matrixA.GetLength(1); k++)
            {
                result[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }
    return result;
}

//using code:
int mA = PromptInt("Введите количество строк матрицы А");
if (mA < 1) { System.Console.WriteLine($"Некорректное количество строк матрицы А: {mA}"); return; }
int nA = PromptInt("Введите количество столбцов матрицы B");
if (nA < 1) { System.Console.WriteLine($"Некорректное количество столбцов матрицы А: {nA}"); return; }

int mB = PromptInt("Введите количество строк матрицы B");
if (mB < 1) { System.Console.WriteLine($"Некорректное количество строк матрицы B: {mB}"); return; }
int nB = PromptInt("Введите количество столбцов матрицы B");
if (nB < 1) { System.Console.WriteLine($"Некорректное количество столбцов матрицы B: {nB}"); return; }

//число столбцов matrixA должно равняться числу строк matrixB
if (nA != mB) { System.Console.WriteLine($"Количество строк матрицы B ({mB}) не равно количеству столбцов матрицы A ({nA})"); return; }
int[,] matrixA = CreateMatrix(rows: mA, columns: nA);
Console.WriteLine("Матрица А:");
PrintMatrix(matrixA);

int[,] matrixB = CreateMatrix(rows: mB, columns: nB);
Console.WriteLine("Матрица B:");
PrintMatrix(matrixB);

Console.WriteLine("Результат перемножения матрицы А на матрицу B:");
PrintMatrix(ProductMatrix(matrixA, matrixB));
