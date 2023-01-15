// Напишите программу, которая принимает на вход число N, а на выходе показывает все четные числа от 1 до N
System.Console.Write("Введите число: ");
int N = Convert.ToInt32(Console.ReadLine());

if(N < 1){
    System.Console.WriteLine($"Введенное число {N} меньше единицы");
}else{
    int i = 1;
    System.Console.Write($"Четные числа от 1 до {N}: ");
    while(i <= N){
        if(i % 2 == 0){
            System.Console.Write($"{i} ");   
        }    
        i++;
    }
}


