int Factorial(int n)
{
    // 1! = 1
    // 0! = 1
    if (n == 1) return 1;
    else return n * Factorial(n - 1);
}
//Console.WriteLine(Factorial(3));        // 1 * 2 * 3 = 6

/*//Демонстрация переполнения типа (int):
for (int i = 1; i < 40; i++)
{
    Console.WriteLine($"{i}! = {Factorial(i)}");
}*/

//Для срвнения для типа double:
double FactorialDbl(int n)
{
    // 1! = 1
    // 0! = 1
    if (n == 1) return 1;
    else return n * FactorialDbl(n - 1);
}
for (int i = 1; i < 40; i++)
{
    Console.WriteLine($"{i}! = {FactorialDbl(i)}");
}