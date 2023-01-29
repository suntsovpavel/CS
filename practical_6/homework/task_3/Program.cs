// Задача 5: * Найдите максимальное значение в матрице по каждой строке, 
// получите сумму этих максимумов. Затем найдите минимальное значение по каждой колонке,
// получите сумму этих минимумов. Затем из первой суммы (с максимумами) вычтите вторую сумму(с минимумами)
// 1 2 3
// 3 4 5
// 3+5=8, 1+2+3=6, 8-6=2

int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return int.Parse(Console.ReadLine());     //Convert.ToInt32(Console.ReadLine());
}

//Формируем матрицу заданного размера и заполняем случайными числами
int[,] GenerateMatrix(int numRows, int numColumns, int minLimit, int maxLimit)
{
    int[,] matrix = new int[numRows, numColumns];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(minLimit, maxLimit + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write($"{matrix[i, j]} ");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

//Ищем в строке матрицы максимальное значение
int MaxValueInRowMatrix(int[,] matrix, int indexRow)
{
    if (indexRow < 0 || indexRow >= matrix.GetLength(0))
    {
        System.Console.WriteLine($"!!! задан индекс {indexRow} вне допустимого диапазона [0,{matrix.GetLength(0)})");
        return 0;   //условно возвращаем 0, если индекс вне допустимого диапазона    
    }
    if (matrix.GetLength(1) == 0)
    {
        System.Console.WriteLine($"!!! длина строки матрицы равна нулю");
        return 0;  //длина строки равна нулю, условно возвращаем 0
    }

    int max = matrix[indexRow, 0];
    for (int j = 1; j < matrix.GetLength(1); j++)   //от 1, так как уже присвоено max = matrix[indexRow, 0];
    {
        if (matrix[indexRow, j] > max) max = matrix[indexRow, j];
    }
    return max;
}

//Ищем в столбце матрицы минимальное значение
int MinValueInColumnMatrix(int[,] matrix, int indexColumn)
{
    if (indexColumn < 0 || indexColumn >= matrix.GetLength(1))
    {
        System.Console.WriteLine($"!!! задан индекс {indexColumn} вне допустимого диапазона [0,{matrix.GetLength(1)})");
        return 0;   //условно возвращаем 0, если индекс вне допустимого диапазона    
    }
    if (matrix.GetLength(0) == 0)
    {
        System.Console.WriteLine($"!!! длина столбца матрицы равна нулю");
        return 0;  //длина столбца равна нулю, условно возвращаем 0
    }

    int min = matrix[0, indexColumn];
    for (int j = 1; j < matrix.GetLength(0); j++)   //от 1, так как уже присвоено min = matrix[0, indexColumn];
    {
        if (matrix[j, indexColumn] < min) min = matrix[j, indexColumn];
    }
    return min;
}

//using code
int numRows = PromptInt("Введите количество строк матрицы");
int numColumns = PromptInt("Введите количество столбцов матрицы");
int[,] matrix = GenerateMatrix(numRows, numColumns, 0, 9);
PrintMatrix(matrix);

//Суммируем максимумы по строкам:
int sumMax = 0;
for (int j = 0; j < matrix.GetLength(0); j++)
{
    sumMax += MaxValueInRowMatrix(matrix, j);
}
System.Console.WriteLine($"Сумма максимумов по строкам: {sumMax}");

// Суммируем минимумы по столбцам:
int sumMin = 0;
for (int j = 0; j < matrix.GetLength(1); j++)
{
    sumMin += MinValueInColumnMatrix(matrix, j);
    //System.Console.WriteLine($"min[{j}] = {MinValueInColumnMatrix(matrix, j)}");
}
System.Console.WriteLine($"Сумма минимумов по столбцам: {sumMin}");

System.Console.WriteLine($"Разность суммы максимумов и минимумов: {sumMax - sumMin}");