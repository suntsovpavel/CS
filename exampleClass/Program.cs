
class Program {

    public class Point {    
        public int x, y;
        public Point(int _x=0, int _y=0){ x=_x; y=_y; }
    }

    public class Figure {
        Point[]? data = null;
        public Figure(int size=0){ 
            if(size > 0) data = new Point [size]; 
        }
        public Figure(int size, Point[] points){
            if(size > 0) data = new Point [size]; 
            setData(points);
        }

        public void setData(Point[] points){            
            if (data == null)data = new Point [points.Length]; 

            if(points.Length != data.Length) Console.WriteLine($"!!! size Point[] points not match size data,={points.Length},{data.Length}");
            
            for(int i=0; i<points.Length; i++){
                data[i] = points[i];
            }    
        }

        public void Print(){
            if (data == null) return;
            for(int i=0; i<data.Length; i++){
                Console.Write($"({data[i].x},{data[i].y})");    
                if(i<data.Length-1) Console.Write(",");
            }
            Console.WriteLine();
        }
    }

    public static void Main (string[] args) {
        //а) треугольник
        Figure triangle = new Figure(3, new Point[] {new Point(0,0), new Point(0,1), new Point(1,0)});            
        Console.Write("triangle: "); triangle.Print();

        //с отложенной инициализацией списком узлов:
        Figure triangle2 = new Figure(3);            
        triangle2.setData(new Point[] {new Point(0,0), new Point(0,1), new Point(1,0)});
        Console.Write("second triangle: "); triangle2.Print();   
        //пентагон
        Figure pentagon =  new Figure(5, new Point[] {new Point(0,0), new Point(0,1), new Point(1,0), new Point(-1,0), new Point(0,-1)});            
        Console.Write("pentagon: "); pentagon.Print();
    }
}



