//Ввод целого значения 
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

// Задача 1: Задайте массив из 12 элементов, заполненный случайными числами из промежутка [-9, 9]. Найдите сумму отрицательных и положительных элементов массива.
// Например, в массиве [3,9,-8,1,0,-7,2,-1,8,-3,-1,6] сумма положительных чисел равна 29, сумма отрицательных равна -20.
/*int[] GenerateArray(int len = 5)
{
    int[] array = new int[len];
    Random rnd = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = rnd.Next(-9, 10);
    }
    return array;
}*/

int[] GenerateArray(int len, int minLimit, int maxLimit)
{
    int[] array = new int[len];
    Random rnd = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = rnd.Next(minLimit, maxLimit + 1);
    }
    return array;
}

void PrintArray(int[] array)
{
    foreach (int item in array)
    {
        System.Console.Write($"{item}\t");
    }
    System.Console.WriteLine();
}

//using code:
//int[] arr = GenerateArray(12);
//PrintArray(arr);

int SumSign(int[] arr, bool positive = true)
{
    int sign = positive ? 1 : -1;
    int sum = 0;
    foreach (int one in arr)
    {
        if (one * sign > 0)
            sum += one;
    }
    return sum;
}
//using code:
//System.Console.WriteLine($"Сумма положительных элементов массива {SumSign(arr)}");
//System.Console.WriteLine($"Сумма отрицательных {SumSign(arr, false)}");

// Задача ..: Напишите программу замены элементов массива: положительные элементы замените на соответствующие отрицательные, и наоборот.
// [-4, -8, 8, 2] -> [4, 8, -8, -2] 
//Функция преобразует сам массив:
void InvertArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = -arr[i];
    }
}

/*int[] arr = GenerateArray(5);
PrintArray(arr);
InvertArray(arr);
PrintArray(arr);*/

// Задача 2: Задайте массив. Напишите программу, которая определяет, присутствует ли заданное число в массиве.
// 4; массив [6, 7, 19, 345, 3] -> нет
// 3; массив [6, 7, 19, 345, 3] -> да

bool FindElement(int[] arr, int number)
{
    foreach (int element in arr)
    {
        if (number == element) return true;
    }
    return false;
}

/*int num = PromptInt("Введите число:");
int[] arr = GenerateArray();
PrintArray(arr);
//System.Console.WriteLine($"Имеется ли число {num} в массиве: {FindElement(arr, num)}");
if(FindElement(arr, num)){
    System.Console.WriteLine($"Число {num} имеется в массиве");    
}else{
    System.Console.WriteLine($"Число {num} НЕ имеется в массиве");    
}*/

// Задача 3: Задайте одномерный массив из 10 случайных чисел в диапазоне от 1 до 200. 
//Найдите количество  двузначных элементов массива. 
// Пример для массива из 5, а не 10 элементов. В своём решении сделайте для 10
// [5, 18, 123, 6, 2] -> 1
// [1, 2, 3, 6, 2] -> 0
// [10, 11, 12, 13, 14] -> 5

int NumberTwelve(int[] arr)
{
    int count = 0;
    foreach (int one in arr)
    {
        if (Math.Abs(one) > 9 && Math.Abs(one) < 100)
        {
            count++;
        }
    }
    return count;
}
// int[] arr = GenerateArray(10, 1, 200);
// PrintArray(arr);
// System.Console.WriteLine($"Количество двузначных элементов массива: {NumberTwelve(arr)}");

// Задача 4: Найдите произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д. Результат запишите в новом массиве.
// [1 2 3 4 5] -> 5 8 3
// [6 7 3 6] -> 36 21










