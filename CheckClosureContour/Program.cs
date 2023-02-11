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
            public static bool operator == (Cell a, Cell b)
            {
                return (a.indexRow == b.indexRow && a.indexCol == b.indexCol);    
            }
            public static bool operator != (Cell a, Cell b){ return !(a == b); }

            public Cell Clone(){
                return new Cell(indexRow, indexCol);
            }
    
            // проверяем невыход за границы rows, columns
            public bool CheckBorders(){
                return (indexRow >= 0 && indexRow < rows && 
                        indexCol >= 0 && indexCol < columns);
            }

            public string PrintString(){
                return '(' + indexRow.ToString() + ',' + indexCol.ToString() + ')';
            }

            public void PrintConsole(){
                Console.Write($"({indexRow},{indexCol})");
            }            
        } 
        
        static Cell baseCell = new Cell();   //поле обхода контура (текущее)
        static int direction = 0;       //направление в поле обхода контура: 0: вверх, 1: вправо, 2: вниз, 3:влево

        static int rows = 0, columns = 0;   //количество строк и столбцов массива pic

        //меняем направление в поле обхода
        static void TurnLeft(){
            direction--; if(direction < 0) direction += 4;
        }
        static void TurnRight(){
            direction++; if(direction > 3) direction -= 4;
        }
       
        //Делаем шаг вперед: переносим поле обхода baseCell в направлении direction
        static bool Step(){
            if(direction == 0) baseCell.indexRow--;         // шаг вверх
            else if(direction == 1) baseCell.indexCol++;    // шаг вправо
            else if(direction == 2) baseCell.indexRow++;    // шаг вниз
            else baseCell.indexCol--;                       // шаг влево
            return baseCell.CheckBorders();
        }

        struct IntFlag 
        {
            public bool flag;
            public int value;
            public Cell cell;
            public IntFlag(bool flag_, int value_, Cell cell_){
                flag = flag_;
                value = value_;
                cell = cell_;
            }
        }

        //Возвращаем значение поля слева (с учетом direction) от поля обхода baseCell
        static IntFlag getValueLeft(int[,] pic)
        {            
            Cell next = new Cell();
            next.indexRow = baseCell.indexRow;
            if(direction == 1) next.indexRow--;
            else if(direction == 3) next.indexRow++;   

            next.indexCol = baseCell.indexCol;
            if(direction == 0) next.indexCol--;
            else if(direction == 2) next.indexCol++;
            
            bool flag = next.CheckBorders();
            int value = flag ? pic[next.indexRow, next.indexCol] : 0;
            return new IntFlag(flag, value, next);
        }

        //Возвращаем значение поля впереди (с учетом direction) от поля обхода baseCell
        static IntFlag getValueAhead(int[,] pic)
        {        
            Cell next = new Cell();
            next.indexRow = baseCell.indexRow;
            if(direction == 0) next.indexRow--;
            else if(direction == 2) next.indexRow++;   

            next.indexCol = baseCell.indexCol;
            if(direction == 3) next.indexCol--;
            else if(direction == 1) next.indexCol++;

            bool flag = next.CheckBorders();
            int value = flag ? pic[next.indexRow, next.indexCol] : 0;
            return new IntFlag(flag, value, next);
        }
        
        struct Result{
            public bool flag;
            public string msg;
            public Cell[] contour;    //!!! заменить на List
            public int countNodes;
            public Result(bool flag_, string msg_, Cell[] contour_, int countNodes_){
                flag = flag_;
                msg = msg_;
                contour = contour_;
                countNodes = countNodes_;
            }
        }
        // Считаем, что если замыкающее поле контура contour[countNodes-1] совпадает с пред-предпоследним contour[countNodes-3], 
        //  то в предпоследнем поле contour[countNodes-2] имеется разрыв
        static bool CheckCutContour(Cell[] contour, int countNodes)
        {
            return (countNodes > 3 && contour[countNodes-1] == contour[countNodes-3]);
        }

        static Result CheckClosureContour(
            int[,] pic,     //массив, задающий контур
            int indexRow, int indexCol)  //Координаты исходного поля (должно примыкать к контуру с наружной стороны)
        {
            baseCell.indexRow = indexRow;
            baseCell.indexCol = indexCol;
            Cell[] contour = new Cell[1000];
            int countNodes = 0;
            
            //В исходном поле обхода ищем направление, при котором элемент контура находится слева
            int count=0;
            while(true){
                IntFlag res = getValueLeft(pic);
                //Console.Write($"flag: {res.flag}, value: {res.value}, indexes: "); res.cell.PrintConsole(); Console.WriteLine();
                if(res.flag && res.value == 1){
                    contour[countNodes++] = res.cell.Clone();
                    break;
                }
                TurnLeft(); 
                if(count > 3) return new Result(false, "неверно выбрано исходное поле обхода", contour, countNodes);
                count++;     
            }

            //Основной цикл обхода контура и заполнения списка полей
            int countMoveAround = 0;    //счетчик поворотов влево и шагов вперед, сделанных подряд 
            while(countNodes == 1 || contour[countNodes-1] != contour[0])
            {
                //Исходное состояние: замыкающее поле контура contour[countNodes-1] находится слева(с учетом direction) от поля обхода baseCell  
                //ПРоверяем поле впереди
                IntFlag res = getValueAhead(pic);
                if(!res.flag) return new Result(false, 
                    "ошибка алгоритма, вызов getValueAhead в узле " + baseCell.PrintString(), 
                    contour, countNodes);

                if(res.value == 1){   //Впереди обнаружено новое поле контура. Делаем поворот вправо. Тем самым переходим в исходное состояние следующей итерации
                    contour[countNodes++] = res.cell.Clone();    
                    if(CheckCutContour(contour, countNodes)) return new Result(false, 
                        "обнаружен разрыв контура в узле " + contour[countNodes-2].PrintString(), 
                        contour, countNodes);   
                    TurnRight();   
                    countMoveAround = 0; 
                }else{
                    //Переносим поле обхода вперед и проверяем поле слева    
                    if(!Step()) return new Result(false, 
                            "ошибка алгоритма, шаг вперед в положение " + baseCell.PrintString() + ", direction: " + direction.ToString(), 
                            contour, countNodes); 
                    res = getValueLeft(pic);
                    if(!res.flag) return new Result(false, 
                        "ошибка алгоритма, вызов getValueLeft в узле " + baseCell.PrintString(), 
                        contour, countNodes);

                    if(res.value == 1){    //Слева обнаружено новое поле контура. Переходим к следующей итерации
                        contour[countNodes++] = res.cell.Clone();    
                        if(CheckCutContour(contour, countNodes)) return new Result(false, 
                            "обнаружен разрыв контура в узле " + contour[countNodes-2].PrintString(), 
                            contour, countNodes);  
                        countMoveAround = 0;
                    }else{  //Делаем разворот влево и переносим поле обхода вперед. Тем самым переходим в исходное состояние следующей итерации
                        TurnLeft();     
                        if(!Step()) return new Result(false, 
                            "ошибка алгоритма, шаг вперед в положение " + baseCell.PrintString() + ", direction: " + direction.ToString(), 
                            contour, countNodes);  
                        countMoveAround++;
                        if(countMoveAround > 3)  //поворот влево и шаг вперед выполнен 4 раза подряд 
                            return new Result(false, 
                            "обнаружена отдельно стоящая единица " + contour[countNodes-1].PrintString(), 
                            contour, countNodes);  
                    }                                                   
                }
            }                        
            return new Result(true, string.Empty, contour, countNodes);
        }

        static void PrintContour(Cell[] contour, int countNodes)
        {
                for(int i=0; i<countNodes; i++){
                    Console.Write(contour[i].PrintString());
                    if(i<countNodes-1) Console.Write(", ");
                }
                Console.WriteLine();
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
            rows = 23;     //pic.getLength(0);
            columns = 25;      //pic.getLength(1);

            //!!! Исходное поле обхода должно быть задано снаружи контура и примыкать к нему сверху, справа, слева или снизу
            
            Console.WriteLine("Проверяем неразрывность контура, исходное поле (15, 1):");
            Result res = CheckClosureContour(pic, 15, 1);            
            if(res.flag){
                Console.WriteLine("Контур замкнут:"); 
                PrintContour(res.contour, res.countNodes);               
            }else{                
                Console.WriteLine($"!!! {res.msg}");                    
            }

            Console.WriteLine("То же, с другим исходным полем (4, 15):");
            res = CheckClosureContour(pic, 4, 15);            
            if(res.flag){
                Console.WriteLine("Контур замкнут:"); 
                PrintContour(res.contour, res.countNodes);               
            }else{                
                Console.WriteLine($"!!! {res.msg}");                    
            }

            //Разрываем контур и повторяем проверку:
            pic[14,2] = 0;
            Console.WriteLine("Изменяем массив: pic[14,2] = 0:");
            res = CheckClosureContour(pic, 4, 15);            
            if(res.flag){
                Console.WriteLine("Контур замкнут:"); 
                PrintContour(res.contour, res.countNodes);               
            }else{                
                Console.WriteLine($"!!! {res.msg}");                    
            }
        }
    }
}
