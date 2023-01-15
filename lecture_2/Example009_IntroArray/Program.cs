
int[] array = { 12, 32, 43, 3, 34, 76, 56, 12, 62 };

//Присваивание элементу масива по индексу:
//array[0] = 14;
//Console.WriteLine(array[0]);

// Эта функция возвращает максимальное из 3-х чисел
int Max(int arg1, int arg2, int arg3)
{
    int res = arg1;
    if (arg2 > res) res = arg2;
    if (arg3 > res) res = arg3;
    return res;
}

// int max1 = Max(a1, b1, c1);
// int max2 = Max(a2, b2, c2);
// int max3 = Max(a3, b3, c3);
// int max = Max(max1, max2, max3);

int max = Max(
    Max(array[0], array[1], array[2]),
    Max(array[3], array[4], array[5]),
    Max(array[6], array[7], array[8]));
Console.WriteLine(max);