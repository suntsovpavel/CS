using System;

namespace CheckClosureContour
{
    class Program
    {
        struct Cell
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
            public bool CheckBorders()
            {
                return (indexRow >= 0 && indexRow < rows &&
                        indexCol >= 0 && indexCol < columns);
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

        static int rows = 0, columns = 0;   //количество строк и столбцов массива pic

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
        static bool Step()
        {
            if (direction == 0) baseCell.indexRow--;         // шаг вверх
            else if (direction == 1) baseCell.indexCol++;    // шаг вправо
            else if (direction == 2) baseCell.indexRow++;    // шаг вниз
            else baseCell.indexCol--;                       // шаг влево
            return baseCell.CheckBorders();
        }

        //Возвращаем значение поля слева (с учетом direction) от поля обхода baseCell
        //В случае выхода за границы массива возвращаем -1
        static (int value, Cell next) getValueLeft(int[,] pic)
        {
            Cell next = new Cell();
            next.indexRow = baseCell.indexRow;
            if (direction == 1) next.indexRow--;
            else if (direction == 3) next.indexRow++;

            next.indexCol = baseCell.indexCol;
            if (direction == 0) next.indexCol--;
            else if (direction == 2) next.indexCol++;

            int value = next.CheckBorders() ? pic[next.indexRow, next.indexCol] : -1;
            return (value, next);
        }

        //Возвращаем значение поля впереди (с учетом direction) от поля обхода baseCell
        //В случае выхода за границы массива возвращаем -1
        static (int value, Cell next) getValueAhead(int[,] pic)
        {
            Cell next = new Cell();
            next.indexRow = baseCell.indexRow;
            if (direction == 0) next.indexRow--;
            else if (direction == 2) next.indexRow++;

            next.indexCol = baseCell.indexCol;
            if (direction == 3) next.indexCol--;
            else if (direction == 1) next.indexCol++;

            int value = next.CheckBorders() ? pic[next.indexRow, next.indexCol] : -1;
            return (value, next);
        }

        //Функция проверяет последние 3 узла списка 
        // Если замыкающий узел совпадает с пред-предпоследним (contour[contour.Count-3]), считаем, что обнеружен разрыв
        static bool CheckCutContour(List<Cell> contour)
        {
            return (contour.Count > 3 && contour.Last() == contour[contour.Count - 3]);
        }

        // Функция проверяет замкнутость контура и формирует список его узлов 
        //  Аргументы:
        // int[,] pic,     //массив, задающий контур
        // int startIndexRow, int startIndexCol:  //Координаты исходного поля; должно быть задано поле, примыкающее к контуру с наружней стороны 
        //  Результаты:
        // msg: сообщение об ошибке (либо о том, что контур не является замкнутым)
        // List<Cell> contour: массив узлов контура
        static (string msg, List<Cell> contour) CheckClosureContour(
            int[,] pic,     //массив, задающий контур
            int startIndexRow, int startIndexCol)  //Координаты исходного поля (должно примыкать к контуру с наружной стороны)
        {
            baseCell.indexRow = startIndexRow;
            baseCell.indexCol = startIndexCol;
            string msg = string.Empty;
            List<Cell> contour = new List<Cell>(100);            

            //В исходном поле обхода ищем направление, при котором элемент контура находится слева
            for (int i = 0; i < 4; i++)
            {
                (int value, Cell cell) = getValueLeft(pic);
                if (value == 1)
                {
                    contour.Add(cell.Clone());  
                    break;
                }
                TurnLeft();
            }
            if (contour.Count == 0)
            {
                msg = "неверно выбрано исходное поле";
            }
            else
            {                
                int countMoveAround = 0;    //счетчик поворотов влево и шагов вперед, сделанных подряд 
                //Основной цикл обхода контура и заполнения полей контура
                while (contour.Count == 1 || contour.Last() != contour[0])
                {
                    //Исходное состояние: замыкающее поле контура contour.Last() находится слева(с учетом direction) поля обхода baseCell  
                    //ПРоверяем поле впереди
                    (int value, Cell newCell) = getValueAhead(pic);
                    if (value == -1)
                    {
                        msg = "ошибка алгоритма, вызов getValueAhead в узле " + baseCell.PrintString();
                        break;
                    }
                    else if (value == 1)
                    {   //Впереди обнаружено новое поле контура. Делаем поворот вправо. Тем самым переходим в исходное состояние следующей итерации
                        contour.Add(newCell.Clone());
                        if (CheckCutContour(contour))
                        {
                            msg = "обнаружен разрыв контура в узле " + contour[contour.Count - 2].PrintString();
                            break;
                        }
                        TurnRight();
                        countMoveAround = 0;
                    }
                    else
                    {
                        //Переносим поле обхода вперед и проверяем поле слева    
                        if (!Step())
                        {
                            msg = "ошибка алгоритма, шаг вперед в положение " + baseCell.PrintString() + ", direction: " + direction.ToString();
                            break;
                        }
                        (value, newCell) = getValueLeft(pic);
                        if (value == -1)
                        {
                            msg = "ошибка алгоритма, вызов getValueLeft в узле " + baseCell.PrintString();
                            break;
                        }
                        else if (value == 1)
                        {    //Слева обнаружено новое поле контура. Переходим к следующей итерации
                            contour.Add(newCell.Clone());
                            if (CheckCutContour(contour))
                            {
                                msg = "обнаружен разрыв контура в узле " + contour[contour.Count - 2].PrintString();
                                break;
                            }
                            countMoveAround = 0;
                        }
                        else
                        {  //Делаем разворот влево и переносим поле обхода вперед. Тем самым переходим в исходное состояние следующей итерации
                            TurnLeft();
                            if (!Step())
                            {
                                msg = "ошибка алгоритма, шаг вперед в положение " + baseCell.PrintString() + ", direction: " + direction.ToString();
                                break;
                            }
                            countMoveAround++;
                            if (countMoveAround > 3)  //поворот влево и шаг вперед выполнен 4 раза подряд 
                            {
                                msg = "обнаружена отдельно стоящая единица " + contour.Last().PrintString();
                                break;
                            }
                        }
                    }
                }
            }
            return (msg, contour);
        }

        static void PrintContour(List<Cell> contour)
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
            (string msg, List<Cell> contour) = CheckClosureContour(pic, startIndexRow, startIndexCol);
            if (msg == string.Empty)
            {
                Console.WriteLine("Контур замкнут:");
                PrintContour(contour);
            }
            else
            {
                Console.WriteLine($"!!! {msg}");
            }
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
            rows = pic.GetLength(0);
            columns = pic.GetLength(1);

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
