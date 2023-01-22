//=====Работа с текстом
// Дан текст. В тексте нужно все пробелы заменить чёрточками,
// маленькие буквы “к” заменить большими “К”,
// а большие “С” маленькими “с”.

//Прежде чем решать задачу, необходимо ответить себе на ряд вопросов:
// Что значит “Дан текст”?.
// Что значит “черточками”?
// Какого алфавита?
// Маленькие буквы “к” заменить большими “К”, а большие “С” заменить
// маленькими “с”.
// Ясна ли задача?

string text = "— Я думаю, — сказал князь, улыбаясь, — что,"
+ "ежели бы вас послали вместо нашего милого Винценгероде,"
+ "вы бы взяли приступом согласие прусского короля."
+ "Вы так красноречивы. Вы дадите мне чаю?";

/*
string Replase(string text, char oldValue, char newValue)
{
    string result = String.Empty;
    int length = text.Length;
    for (int i = 0; i < length; i++)
    {
        if (text[i] == oldValue)
        {
            result += $"{newValue}";
        }
        else
        {
            result += $"{text[i]}";
        }
    }
    return result;
}*/

// string modified = Replase(text, ' ', '|');
// Console.WriteLine(modified);
// modified = Replase(modified, 'к', 'К');
// Console.WriteLine(modified);


string Replase(string text, char[] oldValue, char[] newValue)
{
    //Здесь проверка соответствия длин массивов oldValue и newValue
    
    string result = String.Empty;
    int length = text.Length;
    for (int i = 0; i < length; i++)
    {
        bool found = false;
        for (int j = 0; j < oldValue.Length; j++)
        {
            if (text[i] == oldValue[j])
            {
                result += $"{newValue[j]}";
                found = true;
                break;
            }
        }
        if(!found){
            result += $"{text[i]}";
        }
    }
    return result;
}

char[] oldValue = {' ','к'};
char[] newValue = {'|','К'};
Console.WriteLine(Replase(text, oldValue, newValue));