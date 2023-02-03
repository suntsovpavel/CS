/* Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3*/

/*Console.Write("Введите цифры. !через запятую: ");
int[] numbers = StringToNum(Console.ReadLine());
PrintArray(numbers);
int sum = 0;
for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] > 0)
    {
        sum++;
    }
}
Console.WriteLine();
Console.WriteLine($"количество цифр больше 0 = {sum}");


int[] StringToNum(string input)
{
    int count = 1;
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == ",")
        {
            count++;
        }
    }

    int[] numbers = new int[count];
    int a = 0;

    for (int i = 0; i < input.Length; i++)
    {
        string temp = "";

        while (input[i] != ",")
        {
            if (i != input.Length - 1)
            {
                temp += input[i].ToString();
                i++;
            }
            else
            {
                temp += input[i].ToString();
                break;
            }
        }
        numbers[a] = Convert.ToInt32(temp);
        a++;
    }
    return numbers;
}*/

int Prompt(string message)
{
    Console.Write($"{message} > ");
    return Convert.ToInt32(Console.ReadLine());
}

void PrintArray(int[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i]);
        if(i < array.Length-1){
            Console.Write(", ");
        }
    }
    Console.WriteLine("]");
}

//!!!!! Не нужно вводить все числа в одной строке, это ненужная сложность !!!!!
// Лучше сделать ввод в цикле:
int count_numbers = Prompt("Задайте, сколько чисел будет введено: ");
if (count_numbers < 1)
{
    System.Console.WriteLine($"Введено некорректное число {count_numbers}");
}
else
{
    int[] numbers = new int[count_numbers];
    int sum = 0;
    for (int i = 0; i < count_numbers; i++)
    {
        numbers[i] = Prompt("Введите число:");
        if (numbers[i] > 0) sum++;
    }
    System.Console.Write($"Введены числа: ");
    PrintArray(numbers);
    System.Console.WriteLine($"Чисел больше нуля: {sum}");
}

