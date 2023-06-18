
class Program {

    public class Point {    
        public int x, y;
        public Point(int _x=0, int _y=0){ x=_x; y=_y; }
    }

    public class Figure {
        Point[]? data = null;

        public bool isInit(){ return data != null; }

        public Figure(){}
        public Figure(Point[] points){
            init(points);
        }
        public void init(Point[] points){            
            if (isInit()){
                Console.WriteLine("!!! warning, object already initialized");    
                return; 
            }
            data = new Point[points.Length];                      
            for(int i=0; i<points.Length; i++){
                data[i] = points[i];
            }    
        }

        public void Print(){
            if (!isInit()) return;
            for(int i=0; i<data.Length; i++){
                Console.Write($"({data[i].x},{data[i].y})");    
                if(i<data.Length-1) Console.Write(",");
            }
            Console.WriteLine();
        }
    }

    public static void Main (string[] args) {
        //а) треугольник
        Figure triangle = new Figure(new Point[] {new Point(0,0), new Point(0,1), new Point(1,0)});            
        Console.Write("triangle: "); triangle.Print();

        //б) треугольник с отложенной инициализацией списком узлов:
        Figure triangle2 = new Figure();            
        triangle2.init(new Point[] {new Point(0,0), new Point(0,1), new Point(1,0)});
        Console.Write("second triangle: "); triangle2.Print();   
        
        //в) пентагон
        Figure pentagon =  new Figure(new Point[] {new Point(0,0), new Point(0,1), new Point(1,0), new Point(-1,0), new Point(0,-1)});            
        Console.Write("pentagon: "); pentagon.Print();
    }
}



