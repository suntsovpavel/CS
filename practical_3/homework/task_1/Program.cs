//Задача 19
//Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
//14212 -> нет
//12821 -> да
//23432 -> да

//Ввод целого значения 
int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

//Эта функция принимает целое число n и заполняет массив digits его цифрами, от младшего разряда к старшему
// например, для n=16 будет выполнено: digits[0]=6, digits[1]=1
//Возвращаемое значение: количество цифр числа n 
int FillArrayDigits(int n, int[] digits, int size_digits)
{
    int count = 0;
    while (n > 0)
    {
        if (count == size_digits)
        {
            System.Console.WriteLine("!!! Переполнение digits !!!");
            return count;
        }
        digits[count++] = (n % 10);
        n /= 10;
    }   
    return count;
}

//using code:
int size_digits = 20;  
int[] digits = new int[size_digits];

int n = PromptInt("Введите целое число больше нуля");
if (n <= 0)
{
    System.Console.WriteLine($"Число {n} меньше либо равно 0");
    return;
}

//Заполняем массив digits цифрами числа n
//count: количество заполненных цифр
int count = FillArrayDigits(n, digits, size_digits);

//Контрольная печать digits
// for (int i=0; i<count; i++){
//     System.Console.WriteLine($"digits[{i}] = {digits[i]}");
// }

// Для того, чтобы определить, является ли число палиндромом, сравниваем цифры с начала и конца числа:
for (int i = 0; i < count / 2; i++)
{
    if (digits[i] != digits[count - 1 - i])
    {
        System.Console.WriteLine("Число {n} НЕ является палиндромом");
        return;
    }
}
System.Console.WriteLine($"Число {n} является палиндромом");
