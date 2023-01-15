void FillArray(int[] collection)
{
    int length = collection.Length;
    int i = 0;
    while (i < length)
    {
        collection[i] = new Random().Next(1, 10);    //по идее 1 и 10 нужно втащить в аргументы...
        i++;
    }
}

void PrintArray(int[] col)
{
    int count = col.Length;
    int j = 0;
    while (j < count)
    {
        Console.WriteLine(col[j]);
        j++;
    }
}

int IndexOf(int[] collection, int find)
{
    int len = collection.Length;
    int i = 0;
    int find_pos = -1;
    while (i < len)
    {
        if(collection[i] == find){
            find_pos = i;
            break;    //если не поставить этот break, будем дальше идти по циклу, и в итоге будет возвращен индекс не первого, а последнего вхождения    
        }    
        i++;
    }
    return find_pos;
}

int[] array = new int[10];

FillArray(array);
PrintArray(array);
Console.WriteLine();

int pos = IndexOf(array, 444);
Console.WriteLine(pos);