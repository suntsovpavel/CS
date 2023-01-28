// Задача 2: Задайте одномерный массив, заполненный случайными числами. 
// Найдите сумму элементов, стоящих на нечётных позициях.

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

int SumElementsUnevenIndexes(int[] arr)
{
    int sum = 0;
    int index = 1;
    while (index < arr.Length)
    {
        sum += arr[index];
        index += 2;
    }
    return sum;
}

//using code
int[] arr = GenerateArray(10, 0, 99); //num elements; minLimit; maxLimit

PrintArray(arr);

System.Console.WriteLine($"Сумма элементов с нечетным индексом в массиве: {SumElementsUnevenIndexes(arr)}");
