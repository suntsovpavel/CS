/*int[,] pic = new int[,]
{
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
{0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
};

int i0 = 13, j0 = 13;

bool ChkInside(int i0, int j0)
{
    int j = j0;
    bool chk = false;
    while (j >= 0)  //по горизонтали вправо
    {
        chk= (pic[i0, j] == 1);        
        if(chk) break;        
        j--;
    }
    if (!chk) return false;

    j = j0;
    chk = false;
    while (j < pic.GetLength(1))    //по горизоантали влево
    {
        chk= (pic[i0, j] == 1);
        if(chk) break;       
        j++;
    }
    if (!chk) return false;

    int i = i0;
    chk = false;
    while (i >= 0)  //по вертикали вверх
    {
        chk= (pic[i, j0] == 1);
        if(chk) break; 
        i--;
    }
    if (!chk) return false;

    i = i0;
    chk = false;
    while (i < pic.GetLength(0))  //по вертикали вниз
    {
        chk= (pic[i, j0] == 1);
        if(chk) break; 
        i++;
    }
    return chk;
}

System.Console.WriteLine($"pic.GetLength(1) = {pic.GetLength(1)}");
System.Console.WriteLine($"pic.GetLength(0) = {pic.GetLength(0)}");
System.Console.WriteLine(ChkInside(3,3));*/


int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return int.Parse(Console.ReadLine());     //Convert.ToInt32(Console.ReadLine());
}

int[] GenerateArray(int len, int minLimit, int maxLimit)
{
    int[] array = new int[len];
    Random rnd = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = rnd.Next(minLimit, maxLimit + 1);
    }
    return array;
}

void PrintArray(int[] array)
{
    /*foreach (int item in array)
    {
        System.Console.Write($"{item}\t");
    }
    System.Console.WriteLine();*/
    System.Console.Write(array[0]);
    for (int i = 1; i < array.Length; i++)
    {
        System.Console.Write($", {array[i]}");
    }
    System.Console.WriteLine();
}

// массив с нечетным числом элементов: 2, 4, 3, 1, 6 => 12, 4, 3; 
// массив с четным числом элементов: 2, 4, 5, 6 => 12, 20
int[] MultiplicationPairs(int[] array)
{
    int[] resultArray;
    resultArray = new int[array.Length / 2 + array.Length % 2];
    resultArray[resultArray.Length - 1] = array[resultArray.Length - 1];
    for (int i = 0; i < array.Length / 2; i++)  //!!! в массиве с нечетным количеством элементов не трогаем центральный элемент
    {
        resultArray[i] = array[i] * array[array.Length - 1 - i];
    }
    return resultArray;
}

/*
int[] myArr = GenerateArray(PromptInt("Введите длину массива"), 1, 9);
PrintArray(myArr);
System.Console.WriteLine("Массив произведений пар: ");
int[] multiplic = MultiplicationPairs(myArr);
PrintArray(multiplic);*/


// Задача 1: Напишите программу, которая перевернёт одномерный массив 
//(последний элемент будет на первом месте, а первый - на последнем и т.д.)
// [1 2 3 4 5] -> [5 4 3 2 1]
// [6 7 3 6] -> [6 3 7 6]

void ReverseArray(int[] arr)
{
    for (int i = 0; i < arr.Length / 2; i++)
    {
        int tmp = arr[i];
        arr[i] = arr[arr.Length - 1 - i];
        arr[arr.Length - 1 - i] = tmp;
    }
}

//using code
/*int[] arr = GenerateArray(7, 0, 9);
PrintArray(arr);
ReverseArray(arr);
PrintArray(arr);*/

//Напишите программу, которая принимает на вход три числа и проверяет, 
//может ли существовать треугольник с сторонами такой длины.
//Проверки:
//a,b,c > 0
//a > (b+c), b > (a+c), c > (a+b)

bool ChkSidesOfTriangle(int a, int b, int c)
{
    return a > 0 && b > 0 && c > 0 &&
        (a < b + c) && (b < a + c) && (c < b + a);
}

//using code
/*int a = PromptInt("Введите длину стороны треугольника A");
int b = PromptInt("Введите длину стороны треугольника B");
int c = PromptInt("Введите длину стороны треугольника C");
if(ChkSidesOfTriangle(a,b,c))
    System.Console.WriteLine($"Треугольник со сторонами {a},{b},{c} существует");
else    
    System.Console.WriteLine($"Треугольник со сторонами {a},{b},{c} НЕ существует");
    */

// Задача 2: Напишите программу, которая будет преобразовывать десятичное число в двоичное.
// 45 -> 101101
// 3  -> 11
// 2  -> 10

int[] ToBinary(int num)
{
    int[] result = new int[10]; //!!! 
    int i = result.Length - 1;
    while (num > 0)
    {
        if (i == 0)
        {
            System.Console.WriteLine($"!!! Массив переполнен");
            return result;
        }
        result[i--] = num % 2;
        num /= 2;
    }
    return result;
}

//using code
//int a = PromptInt("Введите число");
//PrintArray(ToBinary(a));

// Задача 3: Не используя рекурсию, выведите первые N чисел Фибоначчи. Первые два числа Фибоначчи: 0 и 1.
// Если N = 5 -> 0 1 1 2 3
// Если N = 3 -> 0 1 1
// Если N = 7 -> 0 1 1 2 3 5 8

int[] Fibonacci(int number)
{
    int[] result = new int[number];
    result[0] = 0;
    result[1] = 1;
    if (number < 2) return result;
    for (int i = 2; i < number; i++)
    {
        result[i] = result[i - 1] + result[i - 2];
    }
    return result;
}

//using code
//int a = PromptInt("Введите число");
//PrintArray(Fibonacci(a));

// Задача 4: Напишите программу, которая будет создавать 
//копию заданного массива с помощью поэлементного копирования.
int[] CloneArray(int[] arr)
{
    int[] result = new int[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        result[i] = arr[i];        
    }
    return result;
}

//using code
/*int[] arr = GenerateArray(10, 0, 9);
int[] a2 = arr; //!!! a2 - ссылка на arr !!!
int[] a3 = CloneArray(arr);

PrintArray(arr);
arr[0] = 100;   //изменили arr
PrintArray(a2); // массив меняется вслед за arr
PrintArray(a3); // копия- не меняется !
*/