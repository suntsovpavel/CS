
const double speed_dog = 5, speed_man1 = 1, speed_man2 = 1.5;
const double eps = 10; // минимальное расстояние между друзьями, когда они еще не встретились
double L = 10000; 
int friend = 2; //1: собака бежит от 1-го к 2-му, 2: собака бежит от 2-го к 1-му

const double speed_closing_friends = speed_man1 + speed_man2;   // Скорость сближения друзей

int count = 0;
while (L > eps){
    //Скорость сближения собаки и одного из друзей
    double speed_closing_dog_man = (friend == 1 ? speed_man2 : speed_man1) + speed_dog;

    //Время до встречи собаки и одного из друзей
    double time = L / speed_closing_dog_man;

    L -= time * speed_closing_friends;

    friend = (friend == 1) ? 2 : 1;
    count++;
}

System.Console.WriteLine($"Собака пробежит между друзьями {count} раз до того, как они встретятся");