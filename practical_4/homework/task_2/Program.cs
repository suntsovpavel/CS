// Задача 2: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

//Ввод целого значения 
int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

//Возвращаем сумму цифр числа
int SumDigits(int num)
{
    int sum = 0;
    while (num > 0)
    {
        sum += (num % 10);
        num /= 10;
    }
    return sum;
}

int num = PromptInt("Введите целое положительное число");
if (num < 0)
{
    System.Console.WriteLine($"Введено некорректное число {num}");
}
else
{
    System.Console.WriteLine($"Сумма цифр числа {num} равна {SumDigits(num)}");
}
