﻿// Задача 3: Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.
// 6 -> да
// 7 -> да
// 1 -> нет
System.Console.Write("Введите число, обозначающее день недели (от 1 до 7): ");
int a = Convert.ToInt32(Console.ReadLine());

if (a > 0 && a < 8)
{
    if (a < 6)
    {
        System.Console.WriteLine($"Введено число {a}; день недели выходной: нет");
    }
    else
    {
        System.Console.WriteLine($"Введено число {a}; день недели выходной: да");
    }
}
else
{
    System.Console.WriteLine($"Введено некорректное число {a}");
}
