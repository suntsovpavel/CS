//Задача 3: Напишите программу вычисления функции Аккермана с помощью рекурсии. 
//Даны два неотрицательных числа m и n. 
// m = 3, n = 2 -> A(m,n) = 29

int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

int Accerman(int m, int n)
{
    if (m == 0) return n + 1;
    if (n == 0) return Accerman(m - 1, 1);
    return Accerman(m - 1, Accerman(m, n - 1));
}


int m = PromptInt("Введите первое число");
int n = PromptInt("Введите второе число");
System.Console.Write($"Функция Аккермана для m = {m}, n = {n} равна  {Accerman(m, n)}");