// Задача 3: Задайте массив вещественных чисел. 
// Найдите разницу между максимальным и минимальным элементами массива.

double[] GenerateArrayDouble(int num, double minLimit, double maxLimit)
{
    double[] array = new double[num];
    Random rnd = new Random();
    double delta = maxLimit - minLimit;
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = minLimit + delta * rnd.NextDouble();
    }
    return array;
}

void PrintArray(double[] array)
{
    foreach (double item in array)
    {
        System.Console.Write($"{item}\t");
    }
    System.Console.WriteLine();
}

double minElementOfArray(double[] arr)
{
    if (arr.Length == 0) return 0;   //для пустого массива условно возвращаем 0 
    double min = arr[0];
    foreach (double element in arr)
    {
        if (min > element) min = element;
    }
    return min;
}
double maxElementOfArray(double[] arr)
{
    if (arr.Length == 0) return 0;   //для пустого массива условно возвращаем 0 
    double max = arr[0];
    foreach (double element in arr)
    {
        if (max < element) max = element;
    }
    return max;
}

//using code
double[] arr = GenerateArrayDouble(10, 0, 10);  //num elements, minLimit, maxLimit

PrintArray(arr);

double min = minElementOfArray(arr);
System.Console.WriteLine($"Минимальный элемент в массиве: {min}");

double max = maxElementOfArray(arr);
System.Console.WriteLine($"Максимальный элемент в массиве: {max}");

System.Console.WriteLine($"Разность между максимальным и минимальным: {max - min}");