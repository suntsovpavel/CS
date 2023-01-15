int[] array = { 12, 32, 43, 3, 34, 76, 56, 12, 62 };

int n = array.Length;

//Число, которое будем искать в массиве array
int find = 34;

int index = 0;

while (index < n)
{
    if (array[index] == find)
    {
        Console.WriteLine($"Индекс искомого элемента: {index}");
        break;  //прерывание цикла
    }

    index++;
}
