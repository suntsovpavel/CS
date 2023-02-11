//Задача 2: Задайте значения M и N. Напишите программу, 
// которая найдёт сумму натуральных элементов в промежутке от M до N с помощью рекурсии.
//M = 1; N = 15 -> 120
//M = 4; N = 8 -> 30

int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

int SumNumbers(int start, int finish)
{
    if (start > finish)
    {
        return 0;
    }
    return start + SumNumbers(start + 1, finish);
}

int m = PromptInt("Введите первое число");
int n = PromptInt("Введите второе число");
System.Console.Write($"Сумма чисел от {m} до {n}:  {SumNumbers(m, n)}");
