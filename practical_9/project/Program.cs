//Задача 1: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от 1 до N при помощи рекурсии.
//N = 5 -> "1, 2, 3, 4, 5"
//N = 6 -> "1, 2, 3, 4, 5, 6"

//так выводит от N до 1:
/*void ShowNumbers(int number)
{
    if(number == 0){
        return;
    }
    System.Console.Write(number + " ");
    ShowNumbers(number-1);
}*/

//а так выводит от 1 до N:
/*void ShowNumbers(int number)
{
    if(number == 0){
        return;
    }    
    ShowNumbers(number-1);
    System.Console.Write(number + " ");
}

ShowNumbers(5);*/

//Задача 2: Задайте значения M и N. Напишите программу, которая рекурсивно выведет все натуральные числа в промежутке от M до N.
//M = 1; N = 5 -> "1, 2, 3, 4, 5"
//M = 4; N = 8 -> "4, 5, 6, 7, 8"

/*void ShowNumbers(int start, int finish)
{
    if(start > finish){
        return;
    }    
    System.Console.Write(start + " ");
    ShowNumbers(start + 1, finish);    
}
ShowNumbers(2, 6);*/

//Задача 3: Напишите программу, которая будет принимать на вход число и возвращать сумму его цифр. Использовать рекурсию.
//453 -> 12
//45 -> 9

/*int SumNumbers(int number)
{
    if(number == 0){
        return 0;
    }
    return SumNumbers(number / 10) + number % 10;
}
System.Console.WriteLine(SumNumbers(2345)); */

//Задача 4: Напишите программу, которая на вход принимает два числа A и B, 
// и возводит число А в целую степень B с помощью рекурсии.
//A = 3; B = 5 -> 243 (3⁵)
//A = 2; B = 3 -> 8
/*int PowerNumber(int number, int power)
{
    if(power == 0){
        return 1;
    }
    return PowerNumber(number, power-1) * number;
}
System.Console.WriteLine(PowerNumber(10, -1)); */

//Задача 5: Определите, является ли число степенью двойки:
//N = 16 -> "Является степень двойки"
//N = 12 -> “Не является степенью двойки”
/*bool Validate(int num)
{
    if(num == 1) return true;   // 1 = степень двойки
    if(num % 2 == 1) return false; //нечетные числа отпадают сразу
    return Validate(num / 2);
}
System.Console.WriteLine(Validate(1));    */

//Задача 6: Проверка на простое число: 
//N = 13 -> "Это простое число"
//N = 12 -> “Это не простое число”
bool Validate(int n, int divider)
{
    if (divider == 1)
    {
        return true;
    }
    return (n % divider != 0) && Validate(n, divider - 1);
}

bool OverValidate(int n)
{
    //!!! Требуется задать 2-й аргумент на единицу меньше первого !!!!
    return Validate(n, n - 1);
}

//System.Console.WriteLine(Validate(63, 62));
System.Console.WriteLine(OverValidate(63));
