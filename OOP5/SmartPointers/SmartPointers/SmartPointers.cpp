#include <iostream>
#include <conio.h>

using namespace std;

class Point {
public:
	int x, y;
	Point() { //конструктор по умолчанию
		printf("Point()\n");
		x = 0;
		y = 0;
	}
	Point(int x, int y) { //конструктор с параметрами
		printf("Point(int x, int y)\n");
		this->x = x;
		this->y = y;
	}
	Point(const Point& p) { //конструктор копирования
		printf("Point(const Point& p)\n");
		x = p.x;
		y = p.y;
	}
	~Point() { //деструктор
		printf("%d, %d\n", x, y);
		printf("~Point()\n");
	}

	void Double() { //метод, возводит координаты в квадрат
		x = x * x;
		y = y * y;
	}

	void Shift(int dx, int dy); //метод, сдвигает координаты

	void Draw() {
		cout << x << ' ' << y << '\n';
	}
};

void Point::Shift(int dx, int dy) { //реализация метода Shift вне класса
	x += dx;
	y += dy;
}

void print(shared_ptr<Point> p) {
	p->Draw();
}

void print(Point* p) {
	p->Draw();
}

int main() {
	unique_ptr<Point> p = make_unique<Point>(2, 2);
	p->Double();
	print(p.get());

	shared_ptr<Point> sp1 = make_shared<Point>(3, 4);
	shared_ptr<Point> sp2 = sp1;
	print(sp2);
	sp2->Shift(1, 1);
	print(sp1);
}