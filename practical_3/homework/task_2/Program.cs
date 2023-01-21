//Задача 21
//Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
//A (3,6,8); B (2,1,-7), -> 15.84
//A (7,-5, 0); B (1,-1,9) -> 11.53

//Ввод целого значения 
int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

int x1 = PromptInt("Введите координату x первой точки");
int y1 = PromptInt("Введите координату y первой точки");
int z1 = PromptInt("Введите координату z первой точки");
int x2 = PromptInt("Введите координату x второй точки");
int y2 = PromptInt("Введите координату y второй точки");
int z2 = PromptInt("Введите координату z второй точки");

double result = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
System.Console.WriteLine($"Расстояние между точками: {result}");
