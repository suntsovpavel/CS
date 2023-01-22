/*
//Возвращаем строку text, повторенную cnt раз (конкатенация)
string Method4(int cnt, string text)
{
    int i = 0;
    string res = string.Empty;
    while (i < cnt)
    {
        res += text;
        i++;
    }
    return res;
}
System.Console.WriteLine(Method4(5, "xyz_"));
*/

//То же с использованием оператора цикла for
string Method4(int cnt, string text)
{
    string res = string.Empty;
    for (int i = 0; i < cnt; i++)
    {
        res += text;
    }
    return res;
}
System.Console.WriteLine(Method4(5, "xyz_"));