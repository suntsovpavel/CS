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

void PrintArray(int[] arr)
{
    //System.Console.WriteLine($"[");
    for (int i = 0; i < arr.Length; i++)
    {
        System.Console.Write($"{arr[i]}\t");
    }
    // System.Console.WriteLine($"]");
}


// Задача 1: Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.

void ChangeFirstLastString(int[,] matrix)
{
    //Временная строка
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        var temp = matrix[0, i];
        matrix[0, i] = matrix[matrix.GetLength(0) - 1, i];
        matrix[matrix.GetLength(0) - 1, i] = temp;
    }
}
/*
int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = CreateMatrix(m, n);
PrintArray(matrix);
ChangeFirstLastString(matrix);
System.Console.WriteLine("Преобразованный массив: ");
PrintArray(matrix);*/

// Задача 2: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. 
//В случае, если это невозможно, программа должна вывести сообщение для пользователя.
int[,] TransposeMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int[,] result = new int[columns, rows];
    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            result[i, j] = matrix[j, i];
        }
    }
    return result;
}
/*
int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = CreateMatrix(m, n);
PrintArray(matrix);
System.Console.WriteLine("Преобразованный массив: ");
PrintArray(TransposeMatrix(matrix)); */

/*
void FillArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = new Random().Next(1, 10);
        }
    }
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]}\t");
        }
        Console.WriteLine();
    }
}
void Change(int[,] arr)
{
    var temp = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j=i;j<arr.GetLength(1);j++)
        {
        temp = arr[i,j];
        arr[i,j] = arr[j,i];
        arr[j,i] = temp;    
        }
            }
}
int[,]massive = new int [5,5];
FillArray(massive);
PrintArray(massive);
System.Console.WriteLine();
Change(massive);
PrintArray(massive);*/


// Задача 3: Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, 
// сколько раз встречается элемент входных данных. Значения элементов массива 0..9
//Создаем массив freq, в котором значение будет равно количеству встреченных символов, равных индексу
//например,   freq[0] = 5  -> число 0 встретилось 5 раз

int[] freq(int[,] arr)
{
    int[] num = new int[10];
    // for (int i = 0; i < arr.GetLength(0); i++)
    // {
    //     for (int j = 0; j < arr.GetLength(1); j++)
    //     {
    //         /*for (int m = 0; m < num.Length; m++){
    //             if(arr[i,j] == m) num[m]++;
    //         }*/
    //         num[arr[i, j]]++;
    //     }
    // }
    foreach (int item in arr)
    {
        num[item]++;
    }
    return num;
}
/*
int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = CreateMatrix(m, n);
PrintMatrix(matrix);
System.Console.WriteLine("значение - сколько раз встречено в массиве:");
//PrintArray(freq(matrix));
int[] res_freq = freq(matrix);
for (int i = 0; i < res_freq.Length; i++)
{
    System.Console.WriteLine($"'{i}': {res_freq[i]}");
}*/

/*
void FillArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = new Random().Next(0, 10);
        }
    }
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int[] Freq(int[,] arr)
{
    int[] num = new int[10];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            num[arr[i,j]]++;
        }
    }
    return num;
}
int[,]massive = new int [5,5];
FillArray(massive);
PrintArray(massive);
var freqArr = Freq (massive);

for(int i=0; i < freqArr.Length; i ++)
{
    System.Console.WriteLine($"{i}- {freqArr[i]}");

}*/

// Задача 4: Задайте двумерный массив из целых чисел. 
//Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.

(int index_i, int index_j) SearchMin(int[,] arr)
{
    int min_i = 0, min_j = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] < arr[min_i, min_j])
            {
                min_i = i; min_j = j;
            }
        }
    }
    return (min_i, min_j);
}

int[,] ModifyArray(int[,] arr, int index_i, int index_j)
{
    int[,] result = new int[arr.GetLength(0) - 1, arr.GetLength(1) - 1];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            int i_result = i;
            int j_result = j;

            if (i_result != index_i && j_result != index_j)
            {
                if (i_result > index_i) i_result--;
                if (j_result > index_j) j_result--;

                result[i_result, j_result] = arr[i, j];
            }
        }
    }
    return result;
}

int m = PromptInt("Введите количество строк массива: ");
int n = PromptInt("Введите количество столбцов массива: ");
int[,] matrix = CreateMatrix(m, n);
PrintMatrix(matrix);
(int i_min, int j_min) = SearchMin(matrix);
System.Console.WriteLine($"i_min = {i_min}, j_min = {j_min}");
int[,] res = ModifyArray(matrix, i_min, j_min);
PrintMatrix(res);