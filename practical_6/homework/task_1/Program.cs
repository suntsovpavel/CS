// Задача 1: Пользователь вводит с клавиатуры M чисел. 
// Посчитайте, сколько чисел больше 0 ввёл пользователь.
int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return int.Parse(Console.ReadLine());     //Convert.ToInt32(Console.ReadLine());
}

void PrintArray(int[] array)
{
    System.Console.Write(array[0]);
    for (int i = 1; i < array.Length; i++)
    {
        System.Console.Write($", {array[i]}");
    }
    System.Console.WriteLine();
}

//Заполняем массив с клавиатуры
int[] FillArrayFromKeyboard(int num)
{
    int[] arr = new int[num];
    for (int i = 0; i < num; i++)
    {
        arr[i] = PromptInt("Введите число");
    }
    return arr;
}

//Возвращаем количество элементов в массиве, которые > 0
int CountPositiveNumbersOfArray(int[] arr)
{
    int count = 0;
    foreach(int element in arr){
        if(element > 0) count++;
    }
    return count;
}

//using code
int num = PromptInt("Введите количество вводимых чисел");
if (num < 1)
{
    System.Console.WriteLine($"Введено некорректное число {num}");
}
else
{
    int[] arr = FillArrayFromKeyboard(num);
    System.Console.WriteLine("Введены числа:");
    PrintArray(arr);
    System.Console.WriteLine($"Количество введенных чисел больше нуля: {CountPositiveNumbersOfArray(arr)}");
}