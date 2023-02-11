//Задайте значения M и N. Напишите программу, которая выведет все чётные натуральные числа в промежутке от M до N с помощью рекурсии.
//M = 1; N = 5 -> "2, 4"
//M = 4; N = 8 -> "4, 6, 8"

int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

void ShowNumbers(int start, int finish)
{
    if (start % 2 == 1) start++;
    if (start > finish)
    {
        return;
    }
    System.Console.Write(start + " ");
    ShowNumbers(start + 2, finish);
}

int m = PromptInt("Введите первое число");
int n = PromptInt("Введите второе число");
System.Console.Write($"Четные натуральные числа от {m} до {n}:   ");
ShowNumbers(m, n);