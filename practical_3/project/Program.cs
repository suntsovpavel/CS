
//!!! В С# принято соглашение: имена переменных с маенькой буквы, имена функций - с большой

/*//Ввод целого значения 
int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}*/

/*
//1. Напишите программу, которая принимает на вход координаты точки (X и Y), причём X ≠ 0 или Y ≠ 0 и выдаёт номер четверти плоскости, в которой находится эта точка.
bool ValidateCoords(int xCoord, int yCoord)
{
    if (xCoord == 0 || yCoord == 0)
    {
        System.Console.WriteLine("Точка лежит хотя бы на одной из осей");
        return false;
    }
    return true;
}

int GetQuorter(int xCoord, int yCoord)
{
    if (xCoord > 0 && yCoord > 0)
    {
        return 1;
    }
    if (xCoord > 0 && yCoord < 0)
    {
        return 4;
    }
    if (xCoord < 0 && yCoord > 0)
    {
        return 2;
    }
    //else //if (xCoord < 0 && yCoord < 0)
    //{
    return 3;
    //}
}

//using code:
int x = PromptInt("Введите X: ");
int y = PromptInt("Введите Y: ");
if (ValidateCoords(x, y))
{
    int quort = GetQuorter(x, y);
    System.Console.WriteLine($"Номер четверти {quort}");
}*/

/*
//Задача 2: Напишите программу, которая по заданному номеру четверти, показывает диапазон возможных координат точек в этой четверти (x и y)
//На вход подаем число от 1 до 4 включительно
string GetQuorterStr(int quorter)
{
    if (quorter == 1)
    {
        return "x > 0; y > 0";
    }
    else if (quorter == 2)
    {
        return "x < 0; y > 0";
    }
    else if (quorter == 3)
    {
        return "x < 0; y < 0";
    }
    else if (quorter == 4)
    {
        return "x < 0; y > 0";
    }
    else
    {
        return "Введен некорректный номер четверти: " + quorter;
    }
}

//using code:
int quorter = PromptInt("Введите номер четверти (от 1 до 4): ");
string mess = GetQuorterStr(quorter);
System.Console.WriteLine($"Результат GetQuorterStr для четверти {quorter}:  {mess}");
*/

/*
//Задача 3: Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 2D пространстве.
int x1 = PromptInt("Введите координату x первой точки");
int y1 = PromptInt("Введите координату y первой точки");
int x2 = PromptInt("Введите координату x второй точки");
int y2 = PromptInt("Введите координату y второй точки");

double Distance(int x1, int x2, int y1, int y2)
{
    return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
}

//double result = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
//using:
System.Console.WriteLine($"Distance: {Distance(x1,x2,y1,y2)}");
*/

/*
//Задача 4: Напишите программу, которая принимает на вход число (N) и выдаёт таблицу квадратов чисел от 1 до N.
//5 -> 1, 4, 9, 16, 25.
//2 -> 1,4
int N = PromptInt("Введите целое число больше единицы");

int i = 1;
System.Console.Write($"Ряд квадратов целых чисел от 1 до {N}:  ");
while (i <= N)
{
    System.Console.Write($"{Math.Pow(i, 2)} ");
    i++;
}
*/

//Задача 5*: Напишите программу, которая генерирует последовательность случайных чисел из 10 элементов 
//в диапазоне от 1 до 10, и подсчитывает, сколько сгенерировалось чисел больше 5.
int count = 0;
for (int i = 0; i < 10; i++)
{
    int random_int = new Random().Next(1, 11);
    System.Console.WriteLine($"Сгенерировано число {random_int}");
    if(random_int > 5){
        count++;
    }
}
System.Console.WriteLine($"Сгенерировано чисел больше 5:  {count}");

