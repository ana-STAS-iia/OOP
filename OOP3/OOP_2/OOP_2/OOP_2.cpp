#include <iostream>
#include <conio.h>

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
};

void Point::Shift(int dx, int dy) { //реализация метода Shift вне класса
	x += dx;
	y += dy;
}

class SizePoint : public Point {
public:
	int size;
	SizePoint() : Point(), size(1) { //конструктор по умолчанию
		printf("SizePoint()\n");
	}
	SizePoint(int x, int y, int size) : Point(x, y), size(size) { //конструктор с параметрами
		printf("SizePoint(int x, int y, int size)\n");
	}
	SizePoint(const SizePoint& p) : Point(p), size(p.size) { //конструктор копирования
		printf("SizePoint(const SizePoint& p)\n");
	}
	~SizePoint() { //деструктор
		printf("%d, %d, size=%d\n", x, y, size);
		printf("~SizePoint()\n");
	}

	void Resize(int new_size) { //метод, меняет размер
		size = new_size;
	}
};

class Triangle { //класс хранит объект класса Point
public:
	Point pt1;
	Point pt2;
	Point pt3;

	Triangle() { //конструктор по умолчанию
		printf("Triangle()\n");
		pt1 = Point();
		pt2 = Point();
		pt3 = Point();
	}
	Triangle(int x1, int y1, int x2, int y2, int x3, int y3) { //конструктор с параметрами
		printf("Triangle(int x1, int y1, int x2, int y2, int x3, int y3)\n");
		pt1 = Point(x1, y1); 
		pt2 = Point(x2, y2);
		pt3 = Point(x3, y3);
	}
	Triangle(const Triangle& p) { //конструктор копирования
		printf("Triangle(const Point& p)\n");
		pt1 = Point(p.pt1);
		pt2 = Point(p.pt2);
		pt3 = Point(p.pt3);
	}
	~Triangle() { //деструктор
		printf("~Triangle()\n");
	}
};

class Segment { //класс хранит указатели на объект класса Point
public:
	Point* sp1;
	Point* sp2;

	Segment() { //конструктор по умолчанию
		printf("Segment()\n");
		sp1 = new Point();
		sp2 = new Point();
	}
	Segment(int x1, int y1, int x2, int y2) { //конструктор с параметрами
		printf("Segment(int x1, int y1, int x2, int y2)\n");
		sp1 = new Point(x1, y1);
		sp2 = new Point(x2, y2);
	}
	Segment(const Segment& p) { //конструктор копирования
		printf("Segment(const Point& p)\n");
		sp1 = new Point(*(p.sp1));
		sp2 = new Point(*(p.sp2));
	}
	~Segment() { //деструктор
		delete sp1;
		delete sp2;
		printf("~Segment()\n");
	}
};

class ColoredPoint : public Point { //класс-наследник, не имеющий конструкторов и деструкторов
public:
	int color;
};

int main() {
	setlocale(LC_ALL, "Russian");
	printf("Статические объекты: \n");
	{ //Статические объекты
		Point p2(3, 5);
		Point p3(p2);
		SizePoint s1(1, 1, 1);
		p3.Shift(4, 4);
		p2.Double();
		s1.Resize(5);

		ColoredPoint c1;
		c1.color = 4;
		c1.Shift(5, 5);
		printf("color = %d\n", c1.color);
	}
	
	printf("\n Динамические объекты: \n");
	Point* p = new Point(6, 6); //динамический объект
	p->Double();
	
	Point* k1 = new SizePoint(5, 7, 100); //никакая информация не обрезается, но возможна утечка памяти
	
	{
		Point k3 = SizePoint(6, 7, 100); //просто пример! информация обрезается
	}
	
	delete k1;
	delete p;

	printf("\n Классы с объектами класса Point и указателями: \n");
	{
		Triangle t1(1, 2, 3, 5, 7, 9);
	}
	Segment* s = new Segment(1, 2, 3, 4);

	delete s;

	return 0;
}
