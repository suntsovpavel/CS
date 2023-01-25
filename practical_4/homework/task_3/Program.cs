//Задача 3: Напишите программу, которая выводит массив из 8 элементов, заполненный случайными числами. 
//Оформите заполнение массива и вывод в виде функции (пригодится в следующих задачах).  
//Реализовать через функции. (* Доп сложность, “введите количество элементов массива”, 
//“Введите минимальный порог случайных значений”, “Введите максимальный порог случайных значений”)

//Ввод целого значения 
int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

//Возвращаем массив, заполненный случайным образом
int[] CreateRandomArray(int numberElements,    //количество элементов массива
                        int lowLimit,   //минимальный порог случайных значений
                        int upLimit)    //максимальный порог случайных значений
{
    int[] result = new int[numberElements];
    Random random = new Random();
    for (int i = 0; i < numberElements; i++)
    {
        result[i] = random.Next(lowLimit, upLimit + 1);
    }
    return result;
}

void ShowArray(int[] array)
{
    int length = array.Length;
    if (length == 0)
    {
        System.Console.WriteLine("Массив пуст");
        return;
    }
    System.Console.Write("Массив: [");
    for (int i = 0; i < length; i++)
    {
        System.Console.Write(array[i]);
        if (i < length - 1)
        {
            System.Console.Write(", ");
        }
    }
    System.Console.Write("]");
}

int len = PromptInt("Введите количество элементов массива");
if (len < 1)
{
    System.Console.WriteLine($"Введено некорректное количество элементов массива {len}");
}
else
{
    int lowLimit = PromptInt("Введите минимальный порог случайных значений (включительно)");
    int upLimit = PromptInt("Введите максимальный порог случайных значений (включительно)");
    if (lowLimit >= upLimit)
    {
        System.Console.WriteLine($"Задан некорректный диапазон случайных значений от {lowLimit} до {upLimit}");
    }
    else
    {
        ShowArray(CreateRandomArray(len, lowLimit, upLimit));
    }
}
