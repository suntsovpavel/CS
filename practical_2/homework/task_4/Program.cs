﻿//Задача 4 * : Напишите программу, которая выводит случайное трёхзначное число 
//и удаляет вторую цифру этого числа. Не использовать строки для расчета.
System.Console.Write("Введите трехзначное число: ");
int a = Convert.ToInt32(Console.ReadLine());

if (a > 99 && a < 1000)
{
    int result = (a / 100) * 10 + (a % 10);
    System.Console.WriteLine($"Число {a} с удаленной второй цифрой: {result}");
}
else
{
    System.Console.WriteLine($"Число {a}: не трехзначное!");
}

