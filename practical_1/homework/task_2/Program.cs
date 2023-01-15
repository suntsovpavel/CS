// Напишите программу, которая принимает на вход три числа и выдает максимальное из этих чисел
System.Console.Write("Введите первое число: ");
int a = Convert.ToInt32(Console.ReadLine()); 

System.Console.Write("Введите второе число: ");
int b = Convert.ToInt32(Console.ReadLine()); 

System.Console.Write("Введите третье число: ");
int c = Convert.ToInt32(Console.ReadLine()); 

if(a < b){
    if(b < c){
        System.Console.WriteLine($"Наибольшее из чисел {a}, {b} и {c}: {c}");   
    }else{
        System.Console.WriteLine($"Наибольшее из чисел {a}, {b} и {c}: {b}");     
    }
}else{
    if(a < c){
        System.Console.WriteLine($"Наибольшее из чисел {a}, {b} и {c}: {c}");   
    }else{
        System.Console.WriteLine($"Наибольшее из чисел {a}, {b} и {c}: {a}");   
    }
}