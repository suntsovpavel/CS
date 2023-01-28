// Задача 1: Задайте массив, заполненный случайными положительными трёхзначными числами. 
// Напишите программу, которая покажет количество чётных чисел в массиве.

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

int CountEvenElements(int[] arr)
{
    int count=0;
    foreach(int element in arr){
        if(element % 2 == 0){
            count++;
        }
    }
    return count;
}

//using code
//Создаем массив из 10 элементов, заполненный 3-хзначными числами
int[] arr = GenerateArray(10, 100, 999);

PrintArray(arr);

System.Console.WriteLine($"Количество четных элементов в массиве: {CountEvenElements(arr)}");
