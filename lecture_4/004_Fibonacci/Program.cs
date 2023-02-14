/*
int Fibonacci(int n)
{
    if (n == 1 || n == 2) return 1;
    else return Fibonacci(n - 1) + Fibonacci(n - 2);
}
for (int i = 1; i < 10; i++)
{
    Console.WriteLine(Fibonacci(i));
}*/

/*double Fibonacci(int n)
{
    if (n == 1 || n == 2) return 1;
    else return Fibonacci(n - 1) + Fibonacci(n - 2);
}
for (int i = 1; i < 43; i++)
{
    Console.WriteLine($"f({i}) = {Fibonacci(i)}");
}*/

// Используем массив хранения результатов
double[] array = new double[1000];
double Fibonacci(int n)  //целое от 1 и более
{
    bool withinBorders = n > 0 && n <= array.Length;
    if (withinBorders && array[n - 1] > 0) return array[n - 1];
    double result = (n < 3) ? 1 : Fibonacci(n - 1) + Fibonacci(n - 2);
    if (withinBorders) array[n - 1] = result;
    return result;
}

for (int i = 1; i < 1000; i++)
{
    System.Console.WriteLine($"Fibonacci({i}) = {Fibonacci(i)}");
}

