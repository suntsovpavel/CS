// Задача 1: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.
// 456 -> 5
// 782 -> 8
// 918 -> 1

System.Console.Write("Введите трехзначное число: ");
int a = Convert.ToInt32(Console.ReadLine());

if (a > 99 && a < 1000)
{
    int secondNumber = (a / 10) % 10;
    System.Console.WriteLine($"Вторая цифра числа {a}: {secondNumber}");
}
else
{
    System.Console.WriteLine($"Число {a}: не трехзначное!");
}