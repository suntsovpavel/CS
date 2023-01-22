void Method21(string msg, int count)
{
    int i = 0;
    while (i < count)
    {
        System.Console.WriteLine(msg);
        i++;
    }
}

//Пример использования именованных аргументов:
Method21(msg: "Message", count: 4);
Method21(count: 3, msg: "Alternate"); //исходный порядок можно менять!