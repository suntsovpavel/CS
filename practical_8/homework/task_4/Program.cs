// Задача 4: * Напишите программу, которая заполнит спирально квадратный массив
// Задача решена в общем случае прямоугольного массива

int PromptInt(string mess)
{
    System.Console.Write($"{mess} > ");
    return Convert.ToInt32(Console.ReadLine());
}

void PrintMatrix(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            System.Console.Write($"{matr[i, j]}\t");
        }
        System.Console.WriteLine();
    }
}

//возвращаем индексы следующего узла
(int indexRowNext, int indexColNext) NextPosition(
    int direction,  //направление движения: 0: вправо; 1: вниз; 2: влево; 3: вверх
    int indexRow,   //индексы текущего узла
    int indexCol)
{
    if (direction % 4 == 0) return (indexRow, indexCol + 1);  //движемся вправо
    if (direction % 4 == 1) return (indexRow + 1, indexCol); //движемся вниз
    if (direction % 4 == 2) return (indexRow, indexCol - 1);  //движемся влево
    return (indexRow - 1, indexCol);  // движемся вверх
}

int[,] FillArray(int rows, int columns)
{
    //Создаем массив и выполняем исходную инициализацию нулями
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = 0;
        }
    }

    int direction = 0; //направление движения по спирали: 0: вправо; 1: вниз; 2: влево; 3: вверх
    int value = 1; //исходное значение 
    int indexRow = 0, indexCol = 0;   //индексы исходного поля
    int saveIndexRow = 0, saveIndexCol = 0; //сохранки индексов для возврата в предыдущее положение

    //Цикл по заполнению элементов по спирали
    while (true)    //!!! выход через return !!!
    {
        //Цикл движения в определенном направлении
        while (indexRow >= 0
        && indexRow < rows
        && indexCol >= 0
        && indexCol < columns
        && matrix[indexRow, indexCol] == 0)   //Поле не заполнялось
        {
            matrix[indexRow, indexCol] = value;
            if (value == matrix.Length) return matrix;  //все поля заполнены
            value++;

            saveIndexRow = indexRow; saveIndexCol = indexCol;
            (indexRow, indexCol) = NextPosition(direction, indexRow, indexCol); 
        }
        //Возвращаемся на предыдущий шаг, меняем направление движения и делаем новый шаг
        indexRow = saveIndexRow; indexCol = saveIndexCol;
        direction++;
        (indexRow, indexCol) = NextPosition(direction, indexRow, indexCol); 
    }
}

//using code:
int m = PromptInt("Введите количество строк массива");
int n = PromptInt("Введите количество столбцов массива");
if (m < 1)
{
    System.Console.WriteLine($"Некорректное количество строк: {m}");
}
else if (n < 1)
{
    System.Console.WriteLine($"Некорректное количество столбцов: {n}");
}
else
{
    int[,] matrix = FillArray(m, n);
    PrintMatrix(matrix);
}