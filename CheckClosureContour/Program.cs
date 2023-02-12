using System;

namespace CheckClosureContour
{
    class Program
    {
        class Cell
        {
            public int indexRow;       //индекс строки в массиве
            public int indexCol;    //индекс столбца в массиве
            public Cell(int indexRow_ = 0, int indexCol_ = 0)
            {
                indexRow = indexRow_;
                indexCol = indexCol_;
            }
            public static bool operator ==(Cell a, Cell b)
            {
                return (a.indexRow == b.indexRow && a.indexCol == b.indexCol);
            }
            public static bool operator !=(Cell a, Cell b) { return !(a == b); }

            public Cell Clone()
            {
                return new Cell(indexRow, indexCol);
            }

            // проверяем невыход за границы rows, columns
            public bool CheckBorders(int[,] pic)
            {
                return (indexRow >= 0 && indexRow < pic.GetLength(0) &&
                        indexCol >= 0 && indexCol < pic.GetLength(1));
            }

            public string PrintString()
            {
                return '(' + indexRow.ToString() + ',' + indexCol.ToString() + ')';
            }

            public void PrintConsole()
            {
                Console.Write($"({indexRow},{indexCol})");
            }
        }

        static Cell baseCell = new Cell();   //поле обхода контура (текущее)
        static int direction = 0;       //направление в поле обхода контура: 0: вверх, 1: вправо, 2: вниз, 3:влево

        static List<Cell> contour = new List<Cell>(100);

        //меняем направление в поле обхода
        static void TurnLeft()
        {
            direction--; if (direction < 0) direction += 4;
        }
        static void TurnRight()
        {
            direction++; if (direction > 3) direction -= 4;
        }

        //Делаем шаг вперед: переносим поле обхода baseCell в направлении direction
        static bool Step(int[,] pic)
        {
            if (direction == 0) baseCell.indexRow--;         // шаг вверх
            else if (direction == 1) baseCell.indexCol++;    // шаг вправо
            else if (direction == 2) baseCell.indexRow++;    // шаг вниз
            else baseCell.indexCol--;                       // шаг влево
            return baseCell.CheckBorders(pic);
        }

        //Возвращаем значение поля слева (с учетом direction) от поля обхода baseCell
        //В случае выхода за границы массива возвращаем -1
        static (int value, Cell next) GetValueLeft(int[,] pic)
        {
            Cell next = new Cell();
            next.indexRow = baseCell.indexRow;
            if (direction == 1) next.indexRow--;
            else if (direction == 3) next.indexRow++;

            next.indexCol = baseCell.indexCol;
            if (direction == 0) next.indexCol--;
            else if (direction == 2) next.indexCol++;

            int value = next.CheckBorders(pic) ? pic[next.indexRow, next.indexCol] : -1;
            return (value, next);
        }

        //Возвращаем значение поля впереди (с учетом direction) от поля обхода baseCell
        //В случае выхода за границы массива возвращаем -1
        static (int value, Cell next) GetValueAhead(int[,] pic)
        {
            Cell next = new Cell();
            next.indexRow = baseCell.indexRow;
            if (direction == 0) next.indexRow--;
            else if (direction == 2) next.indexRow++;

            next.indexCol = baseCell.indexCol;
            if (direction == 3) next.indexCol--;
            else if (direction == 1) next.indexCol++;

            int value = next.CheckBorders(pic) ? pic[next.indexRow, next.indexCol] : -1;
            return (value, next);
        }

        //Функция проверяет последние 3 узла списка 
        // Если замыкающий узел совпадает с пред-предпоследним (contour[contour.Count-3]), считаем, что обнеружен разрыв
        static bool CheckCutContour()
        {
            return (contour.Count > 3 && contour.Last() == contour[contour.Count - 3]);
        }

        //Проверяем корректность задания исходного поля обхода
        // Возвращаемая строка: сообщение об ошибке. Если все ок, возвращаем string.Empty
        static string CheckStartCell(int[,] pic, int startIndexRow, int startIndexCol)
        {
            string msg = string.Empty;
            baseCell.indexRow = startIndexRow;
            baseCell.indexCol = startIndexCol;

            if (!baseCell.CheckBorders(pic))
            {
                return "заданы индексы вне границ массива " + baseCell.PrintString();
            }
            if (pic[startIndexRow, startIndexCol] == 1)
            {
                return "заданы индексы элемента контура " + baseCell.PrintString();
            }
            return FindDirectionStart(pic);
        }

        //В исходном поле обхода ищем направление, при котором элемент контура находится слева
        // Возвращаемая строка: сообщение об ошибке (подходящий элемент контура не найден по всем направлениям)
        // Если все ок, возвращаем string.Empty
        static string FindDirectionStart(int[,] pic)
        {
            contour.Clear();
            for (int i = 0; i < 4; i++)
            {
                (int value, Cell cell) = GetValueLeft(pic);
                if (value == 1)
                {
                    contour.Add(cell.Clone());
                    return string.Empty;
                }
                TurnLeft();
            }
            return "Исходное поле не примыкает к контуру: " + baseCell.PrintString();
        }

        // Функция заполняет список узлов контура и проверяет его на замкнутость
        // Возвращаемая строка: сообщение об ошибке либо о том, что контур не замкнут.
        // Если все ок, возвращаем string.Empty
        static string FillContour(int[,] pic)
        {
            int countMoveAround = 0;    //счетчик поворотов влево и шагов вперед, сделанных подряд 

            //Основной цикл обхода контура и заполнения полей контура
            while (contour.Count == 1 || contour.Last() != contour[0])
            {
                //Исходное состояние: замыкающее поле контура contour.Last() находится слева(с учетом direction) поля обхода baseCell  
                //ПРоверяем поле впереди
                (int value, Cell newCell) = GetValueAhead(pic);
                if (value == -1) return "ошибка алгоритма, вызов GetValueAhead в узле " + baseCell.PrintString();
                else if (value == 1)
                {   //Впереди обнаружено новое поле контура. Делаем поворот вправо. Тем самым переходим в исходное состояние следующей итерации
                    contour.Add(newCell.Clone());
                    if (CheckCutContour()) return "обнаружен разрыв контура в узле " + contour[contour.Count - 2].PrintString();
                    TurnRight();
                    countMoveAround = 0;
                }
                else
                {
                    //Переносим поле обхода вперед и проверяем поле слева    
                    if (!Step(pic)) return "ошибка алгоритма, шаг вперед в положение " + baseCell.PrintString() + ", direction: " + direction.ToString();

                    (value, newCell) = GetValueLeft(pic);
                    if (value == -1){
                         return "ошибка алгоритма, вызов GetValueLeft в узле " + baseCell.PrintString();
                    }                    
                    else if (value == 1)     //Слева обнаружено новое поле контура. Переходим к следующей итерации
                    {   
                        contour.Add(newCell.Clone());
                        if (CheckCutContour()) return "обнаружен разрыв контура в узле " + contour[contour.Count - 2].PrintString();
                        countMoveAround = 0;
                    }
                    else
                    {  //Делаем разворот влево и переносим поле обхода вперед. Тем самым переходим в исходное состояние следующей итерации
                        TurnLeft();
                        if (!Step(pic)) return "ошибка алгоритма, шаг вперед в положение " + baseCell.PrintString() + ", direction: " + direction.ToString();
                        countMoveAround++;
                        if (countMoveAround > 3)  //поворот влево и шаг вперед выполнен 4 раза подряд                         
                            return "обнаружена отдельно стоящая единица " + contour.Last().PrintString();
                    }
                }
            }
            return string.Empty;
        }

        static void PrintContour()
        {
            for (int i = 0; i < contour.Count; i++)
            {
                Console.Write(contour[i].PrintString());
                if (i < contour.Count - 1) Console.Write(", ");
            }
            Console.WriteLine();
        }

        static void Starter(int[,] pic, int startIndexRow, int startIndexCol)
        {
            string msg = CheckStartCell(pic, startIndexRow, startIndexCol);
            if(msg != string.Empty){ Console.WriteLine($"!!! {msg}"); return; }

            msg = FillContour(pic);    
            if(msg != string.Empty){ Console.WriteLine($"!!! {msg}"); return; }

            Console.WriteLine("Контур замкнут:"); 
            PrintContour();
        }

        static void Main(string[] args)
        {
            int[,] pic = new int[,] {
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

            //Координаты исходного поля должны быть заданы в поле, примыкающем к контуру с наружней стороны
            Console.WriteLine("Проверяем неразрывность контура, исходное поле (15, 1):");
            Starter(pic, 15, 1);

            Console.WriteLine("То же, с другим исходным полем (4, 15):");
            Starter(pic, 4, 15);

            //Разрываем контур и повторяем проверку:
            pic[14, 2] = 0;
            Console.WriteLine("Изменяем массив: pic[14,2] = 0:");
            Starter(pic, 4, 15);
        }
    }
}
