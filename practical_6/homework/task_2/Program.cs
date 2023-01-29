// Задача 2. Напишите программу, которая найдёт точку пересечения двух прямых, 
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; 
// значения b1, k1, b2 и k2 задаются пользователем.

const double eps = 1E-7;    //используется в сравнении k1 и k2

double PromptDbl(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToDouble(Console.ReadLine());
}

//Хотел сделать функцию, но непонятно, как вернуть множество результатов: 
//  флаг (есть ли точка пересечения) и координаты x, y точки пересечения
//Можно было бы создать класс и вернуть объект класса, но мы этого не проходили

double k1 = PromptDbl("Введите k1");
double b1 = PromptDbl("Введите b1");
double k2 = PromptDbl("Введите k2");
double b2 = PromptDbl("Введите b2");

//Точка пересечения имеется только тогда, когда k1 и k2 различны
if (Math.Abs(k1 - k2) > eps)
{
    double x_cross = (b2-b1)/(k1-k2);
    double y_cross = (k1*(b2-b1))/(k1-k2)+b1;
    System.Console.WriteLine($"Координаты точки пересечения прямых: x = {x_cross}, y = {y_cross}");
}
else
{
    System.Console.WriteLine("Прямые не пересекаются: угловые коэффициенты k1 и k2 равны");
}