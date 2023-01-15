// Напишите программу, которая принимает на вход число и выдает, является ли число четным (делится на 2 ьез остатка)
System.Console.Write("Введите число: ");
int a = Convert.ToInt32(Console.ReadLine()); 

if(a % 2 == 0){
    System.Console.WriteLine($"Число {a}: четное");   
}else{
    System.Console.WriteLine($"Число {a}: нечетное");   
}