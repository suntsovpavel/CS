﻿
//Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает последнюю цифру этого числа.
//456 -> 6
//782 -> 2
//918 -> 8

int inputInt(string msg)
{
    Console.WriteLine(msg);
    return Convert.ToInt32(Console.ReadLine());
}

/*int a = inputInt("Введите трехзначное число: ");

if (a > 99 && a < 1000)
{
    int b = a % 10;
    Console.WriteLine($"Последняя цифра числа {a}:  {b}");
}
else
{
    Console.WriteLine($"Введенное число {a}: не трехзначное");
}*/


//2. Напишите программу, которая выводит случайное чило из отрезка [10,99]
// и показывает наибольшую цифру этого числа

/*int a = new Random().Next(10, 100);

//Цифра первого разряда:
int a1 = a / 10;        //int a1 = a % 10;

//Цифра второго разряда:
int a2 = a % 10;        //int a2 = (a - a1) / 10;

int max = (a2 > a1) ? a2 : a1;

Console.WriteLine($"Наибольшая цифра числа {a}:  {max}");*/

//Напишите программу, которая принимает 2 числа и выводит, является ли второе число кратным первому
//Если второе число не кратно первому, программа выводит остаток от деления

/*int a = inputInt("Введите первое число: ");

int b = inputInt("Введите второе число: ");

if (b < a)
{
    Console.WriteLine($"Число {b} меньше числа {a}");
    return;
}

int c = b % a;

if (c == 0)
{
    Console.WriteLine($"Число {b} является кратным числу {a}");
}
else
{
    Console.WriteLine($"Число {b} не является кратным числу {a}, остаток от деления: {c}");
}*/

//Напишите программу, к-я проверяет число на кратность оновременно 7 и 23
int a = inputInt("Введите число: ");

if (a % 7 != 0)
{
    Console.WriteLine($"Число {a} не кратно числу 7");
}
else if (a % 23 != 0)
{
    Console.WriteLine($"Число {a} не кратно числу 23");
}
else
{
    Console.WriteLine($"Число {a} кратно и 7, и 23");
}