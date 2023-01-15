// Напишите программу, которая на вход принимает 2 числа и выдает, какое большее, а какое меньшее
System.Console.Write("Введите первое число: ");
int a = Convert.ToInt32(Console.ReadLine()); 

System.Console.Write("Введите второе число: ");
int b = Convert.ToInt32(Console.ReadLine()); 

if(a < b){
    System.Console.WriteLine($"Большее число: {b}, меньшее: {a}");   
}else if(a == b){
    System.Console.WriteLine($"Оба числа равны: {a}");   
}else{
    System.Console.WriteLine($"Большее число: {a}, меньшее: {b}");   
} 
