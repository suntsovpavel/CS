﻿// Задача 2: Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.
// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6
System.Console.Write("Введите число: ");
int a = Convert.ToInt32(Console.ReadLine());

if (a > 99)
{
    int tmpa = a;

    //Обрезаем цифры справа до тех пор, пока число не станет трехзначным
    while (tmpa > 999)
    {
        tmpa = tmpa / 10;
    }
    System.Console.WriteLine($"Третья цифра числа {a}: {tmpa % 10}");
}
else
{
    System.Console.WriteLine($"Число {a}: третьей цифры нет");
}
