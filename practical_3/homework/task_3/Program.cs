//Задача 23
//Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
//3 -> 1, 8, 27
//5 -> 1, 8, 27, 64, 125
int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

int n = PromptInt("Введите целое число больше единицы");
if(n < 1){
    System.Console.WriteLine($"Введенное число {n} меньше единицы!");
    return;
}

int i = 1;
System.Console.Write($"Ряд кубов целых чисел от 1 до {n}:  ");
while (i <= n)
{
    System.Console.Write(Math.Pow(i, 3));
    if(i < n){
        System.Console.Write(", ");
    }
    i++;
}

