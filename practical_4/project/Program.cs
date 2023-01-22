//Ввод целого значения 
int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}
double PromptDbl(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToDouble(Console.ReadLine());
}

//Напишите программу, которая выводит первые заданные N элементов следующей последовательности:
//1 2 2 3 3 3 4 4 4 4 5 5 5 5 5 6 ... (1 встречается один раз, 2: два раза, и т.д.)
/*bool MyValidate(int n)
{
    bool res = (n > 0);
    if (!res)
    {
        System.Console.WriteLine($"Число {n} меньше либо равно нулю");
    }
    return res;
}*/

void ShowNumbers(int n)
{
    int m = 1;  //Выводимые числа, исходное присвоение
    int count = 0;
    while (true)
    {
        for (int j = 0; j < m; j++)     //Каждое m должно быть выведено m раз
        {
            System.Console.Write($"{m} ");    
            count++;
            if(count == n) return;
        }
        m++;
    }
}

int n = PromptInt("Введите целое число больше нуля");
if(n < 0){
    System.Console.WriteLine($"Число {n} меньше либо равно нулю");
}else{
    ShowNumbers(n);
}


/*
// Задача 1: Напишите программу, которая принимает на вход число (А) и выдаёт сумму чисел от 1 до А.
// 7 -> 28
// 4 -> 10
// 8 -> 36
int number = PromptInt("Введите число");

int SumNumbers(int numbers)
{
    int sum = 0;
    for(int i = 1; i <= number; i++){
        sum += i;
    }
    return sum;
    //System.Console.WriteLine($"Сумма чисел от 1 до {a}:  {sum}");
}

int SumNumbersGauss(int numbers)
{
    return (number+1)*number/2;
}

System.Console.WriteLine($"Сумма чисел от 1 до {number}:  {SumNumbers(number)}");
System.Console.WriteLine($"Сумма чисел от 1 до {number}:  {SumNumbersGauss(number)}");
*/

// Задача 1: Напишите программу, которая принимает на вход число и выдаёт количество цифр в числе.
// 456 -> 3
// 78 -> 2
// 89126 -> 5

/*
int n = PromptInt("Введите число");
int sum = 0;
while (n > 0)
{
    sum++;
    n = n / 10;
}
System.Console.WriteLine($"Сумма цифр числа {n}:  {sum}");
*/

/*
//Посчитать кол-во цифр в числе через функцию, в которой два параметра, 
//первый - само число, второй параметр - система счисления
int countDigits(int number, int numberBase)
{
    //проверить, чтобы numberBase > 1
    int sum = 0;
    while (number > 0)
    {
        sum++;
        number = number / numberBase;
    }
    return sum;
}
System.Console.WriteLine(countDigits(n, 2));
*/

// Задача 2: Напишите программу, которая принимает на вход число N и выдаёт произведение чисел от 1 до N.
// 4 -> 24 
// 5 -> 120
/*
int Factorial(int number)
{
    int product = 1;
    for(int i = 1; i <= number; i++){
        product *= i;
    }
    return product;
}
int n = PromptInt("Введите число");
System.Console.WriteLine($"Произведение чисел от 1 до {n}:  {Factorial(n)}");
*/

// Задача 3: Напишите программу, которая выводит массив из 8 элементов, 
//заполненный нулями и единицами в случайном порядке.
// [1,0,1,1,0,1,0,0]
/*
int size = PromptInt("Введите размер массива");
int[] array = new int[size];
Random random = new Random();
for (int i = 0; i < array.Length; i++)
{
    array[i] = random.Next(0, 2);
}
int[] CreateArray(int size_array)
{
    int[] array = new int[size_array];
    Random random = new Random();
    for (int i = 0; i < array.Length; i++)
    { 
        array[i] = random.Next(0, 2);
    }
    return array;
}

void ShowArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.Write($"{array[i]} ");
    }
}

//using code:
ShowArray(CreateArray(PromptInt("Введите размер массива")));
*/
