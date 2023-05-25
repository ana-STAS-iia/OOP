#include <iostream>
using namespace std;

class Base {

public:
	Base() {
		cout << "Base()\n";
	}

	Base(Base* obj) {
		cout << "Base(Base* obj)\n";
	}

	Base(Base& obj) {
		cout << "Base(Base& obj)\n";
	}

	~Base() {
		cout << "~Base()\n";
	}
};

class Desc: public Base {

public:
	Desc() {
		cout << "Desc()\n";
	}

	Desc(Desc* obj) {
		cout << "Desc(Desc* obj)\n";
	}

	Desc(Desc& obj) {
		cout << "Desc(Desc& obj)\n";
	}

	~Desc() {
		cout << "~Desc()\n";
	}
};

Base func1() { //много копирования
	cout << "\nBase func1()\n";
	Base tmp; //создаю
	return tmp; //копируется
}

Base* func2() { //остается указатель на мусор 
	cout << "Base* func2()\n";
	Base tmp;
	return &tmp;
}

Base& func3() { //возвращаю объект, который сразу удаляется
	cout << "Base& func3()\n";
	Base tmp;
	return tmp;
}

Base func4() { //утечка памяти, нет delete
	cout << "\nBase func4()\n";
	Base* tmp = new Base();
	return *tmp; //разименнование
}

Base* func5() { //главное не забыть удалить указатель вне функции
	cout << "Base* func5()\n";
	Base* tmp = new Base();
	return tmp;
}

Base& func6() { //не удаляется указатель, но его можно удалить вне
	cout << "Base& func6()\n";
	Base* tmp = new Base();
	return *tmp;
}

void f1(Base  obj) { //копируется
	cout << "\nf1(Base obj)\n";
}
void f2(Base* obj) { //нужно где-то удалить
	cout << "f2(Base* obj)\n";
}
void f3(Base& obj) { //просто не копируется
	cout << "f3(Base& obj)\n";
}

int main() {

	Base* b = new Base();
	Desc* d = new Desc();

	cout << "\nInput Base to functions:\n";
	f1(*b);
	f2(b);
	f3(*b);

	cout << "\nInput Desc to functions:\n";
	f1(*d);
	f2(d);
	f3(*d);

	delete d;
	delete b;
	
	{
		Base b1;
		Base* b2;

		cout << "\nOutput objects from functions:\n";
		b1 = func1();
		b2 = func2();
		b1 = func3();
		b1 = func4();
		b2 = func5();
		b1 = func6();
	}

	return 0;
}
