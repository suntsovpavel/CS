
int a1 = 12, b1 = 32, c1 = 43,
    a2 = 3, b2 = 34, c2 = 76,
    a3 = 56, b3 = 12, c3 = 62;

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
    Max(a1, b1, c1), 
    Max(a2, b2, c2), 
    Max(a3, b3, c3));
Console.WriteLine(max);