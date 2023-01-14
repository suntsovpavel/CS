/*System.Console.Write("Введте число: ");
String stringValue = Console.ReadLine();
int value = Convert.ToInt32(stringValue);

int result = value * value;

System.Console.WriteLine("Квадрат числа " + value + " равен " + result);
System.Console.WriteLine($"Квадрат числа {value} равен {result}");
*/

/*2. Напишите программу, которая на вход принимает два числа и проверяет, является ли второе число квадратом первого.
a = 5; b = 25 -> да 
a = 2 b = 10 -> нет 
a = 9; b = -3 -> нет 
a = -3 b = 9 -> да
System.Console.Write("Введите первое число: ");
String stringValue = Console.ReadLine() ?? ""; //Взять "", если Console.ReadLine() вернет NULL
int value = Convert.ToInt32(stringValue);

System.Console.Write("Введите второе число: ");
String stringValue2 = Console.ReadLine();
int value2 = Convert.ToInt32(stringValue2);

if(value*value == value2){
    System.Console.WriteLine($"Квадрат числа {value} равен числу {value2}");
}else{
    System.Console.WriteLine($"Квадрат числа {value} НЕ равен числу {value2}");
}*/

/*2. Напишите программу, которая будет выдавать название дня недели по заданному номеру.
	3 -> Среда 
5 -> Пятница
System.Console.Write("Введите номер дня недели: ");
int value = Convert.ToInt32(Console.ReadLine());

if(value==1){
    System.Console.WriteLine($"День недели для номера {value} - понедельник");    
}else if(value==2){
    System.Console.WriteLine($"День недели для номера {value} - вторник");    
}else if(value==3){
    System.Console.WriteLine($"День недели для номера {value} - среда");    
}else if(value==4){
    System.Console.WriteLine($"День недели для номера {value} - четверг");    
}else if(value==5){
    System.Console.WriteLine($"День недели для номера {value} - пятница");    
}else if(value==6){
    System.Console.WriteLine($"День недели для номера {value} - суббота");    
}else if(value==7){
    System.Console.WriteLine($"День недели для номера {value} - воскресенье");    
}else{
    System.Console.WriteLine($"Некорректный номер {value}");   
}
System.Console.Write("Введите номер дня недели: ");
int value = Convert.ToInt32(Console.ReadLine());

if(value < 8 && value > 0){
    string[] week = new string[]{"понедельник","вторник","среда",
    "четверг","пятница","суббота","воскресенье"};

    System.Console.WriteLine($"День недели для номера {value} - {week[value-1]}");
}else{
    System.Console.WriteLine($"Некорректный номер {value}");   
}*/

//4. Напишите программу, которая на вход принимает одно число (N), а на выходе показывает все целые числа в промежутке от -N до N.
//4 -> "-4, -3, -2, -1, 0, 1, 2, 3, 4" 
//2 -> " -2, -1, 0, 1, 2"
/*System.Console.Write("Введите число: ");
int value = Convert.ToInt32(Console.ReadLine());

int i = -value;
while (i <= value)
{
    System.Console.Write($"{i} ");
    i++;
}*/

//Модуль числа
/*System.Console.Write("Введите число: ");
int value = Convert.ToInt32(Console.ReadLine());

if(value<0){
    System.Console.Write($"Модуль числа {value}: {-value}");
}else{
    System.Console.Write($"Модуль числа {value}: {value}");
}
//System.Console.Write($"Модуль числа {value}: {Math.Abs(value)}");
*/

//Обратное число (1/x)
System.Console.Write("Введите число: ");
double x = Convert.ToDouble(Console.ReadLine());
if(Math.Abs(x) > 1E-7){
    System.Console.Write($"Обратное число для {x}: {1/x}");
}else{
    System.Console.Write($"Введено число {x}: ошибка деления на ноль");
}







