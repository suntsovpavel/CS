System.Console.Clear();

int xa = 40, ya = 1, xb = 1, yb = 20, xc = 80, yc = yb;

System.Console.SetCursorPosition(xa, ya);
System.Console.WriteLine("+");
System.Console.SetCursorPosition(xb, yb);
System.Console.WriteLine("+");
System.Console.SetCursorPosition(xc, yc);
System.Console.WriteLine("+");

int x=xa, y=ya;
int cnt = 0;
while(cnt < 10000){
    int what = new Random().Next(0,3);  //0 1 2
    if(what == 0){
        x = (x+xa)/2;
        y = (y+ya)/2;
    }else if(what == 1){
        x = (x+xb)/2;
        y = (y+yb)/2;
    }else{      
        x = (x+xc)/2;
        y = (y+yc)/2;       
    }
    System.Console.SetCursorPosition(x, y);
    System.Console.WriteLine("+");
    cnt++;
}