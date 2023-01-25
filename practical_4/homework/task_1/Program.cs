// Задача 1: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

//Ввод целого значения 
int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

//Возвращаем num в степени exp
int MyExponent(int num, int exp)
{
    int result = num;
    while (exp > 1)
    {
        result *= num;
        exp--;
    }
    return result;
}


int n = PromptInt("Введите число (A)");
int exponent = PromptInt("Введите показатель степени (B)");

if (exponent < 1)
{
    System.Console.WriteLine($"Введен некорректный показатель степени {exponent}");
}
else
{
    System.Console.WriteLine($"{n} в степени {exponent} равно {MyExponent(n, exponent)}");
}