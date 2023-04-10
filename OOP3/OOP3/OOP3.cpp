#include <iostream>
#include <ctime>
using namespace std;

template<class T>
class mycontainer {
private:
    int size; //размер массива
    int capacity; //максимум
    T* data; //массив
    int beginShift; //буфер

    void grow() { //расширение 
        int begin = beginShift;
        T* new_data = new T[2 * capacity];
        capacity *= 2;
        beginShift = capacity / 4;
        for (int i = beginShift; i < beginShift + size; i++) {
            new_data[i] = data[begin++];
        }
        delete[]data;
        data = new_data;
    }

    void shrink() { //сжатие
        int begin = beginShift;
        T* data_sh = new T[capacity / 2];
        capacity /= 2;
        beginShift = capacity / 4;
        for (int i = beginShift; i < beginShift + size; i++) {
            data_sh[i] = data[begin++];
        }
        delete[]data;
        data = data_sh;
    }

    void tryRealloc() { //проверка нужно ли сжать или увеличить массив
        if (4 * size >= 3 * capacity) {
            grow();
        }
        else if (size > 32 && 8 * size <= capacity) {
            shrink();
        }
    }

public:
    mycontainer() : size(0), capacity(16), data(new T[16]) {} //конструктор по умолчанию

    mycontainer(int len) { //конструктор присваивания
        size = 0;
        capacity = len;
        beginShift = capacity / 4;
        data = new T[capacity];
    }

    ~mycontainer() { //деструктор
        size = capacity = 0;
        delete[]data;
    }

    int getSize() { //получаем размер
        return size;
    }

    T& back() { //конец массива
        if (size == 0) {
        }
        return data[beginShift + size - 1];
    }

    void push_back(T elem) { //вставить элемент в конец
        if (beginShift + size == capacity) {
            grow();
        }
        data[beginShift + size] = elem;
        size++;
        tryRealloc();
    }

    void push_front(T elem) { //вставить элемент в начало
        if (beginShift == 0) {
            grow();
        }
        data[--beginShift] = elem;
        size++;
        tryRealloc();
    }

    void insert(T elem, int index) { //вставить элемент по индексу
        if (index < 0 || index >= size + beginShift) {
            return;
        }
        if (beginShift + size == capacity) {
            grow();
        }
        for (int i = beginShift + size; i > beginShift + index; i--) {
            data[i] = data[i - 1];
        }
        data[beginShift + index] = elem;
        size++;
        tryRealloc();
    }

    void pop_back() { //удалить элемент в конце
        if (size == 0) {
            return;
        }
        size--;
        tryRealloc();
    }

    void pop_front() { //удалить элемент в начале
        if (size == 0) {
            return;
        }
        beginShift++;
        size--;
        tryRealloc();
    }

    T& getAt(int index) { //получить элемент
        if (index < 0 || index >= size) {
        }
        else {
            return data[index + beginShift];
        }
    }
};

int main() {
    srand(time(nullptr));
    mycontainer<int> v; //создаю контейнер

    int temp;
    int val;
    clock_t start = clock();
    for (int i = 0; i < 10000; i++) {
        temp = rand() % 6;
        switch (temp) {
        case 0: {
            if (v.getSize() != 0) {
                val = rand() % v.getSize();
                cout << v.getAt(val) << endl;
            }
            break;
        }
        case 1: {
            val = rand() % 1000;
            v.push_back(val);
            break;
        }
        case 2: {
            val = rand() % 1000;
            v.push_front(val);
            break;
        }
        case 3: {
            if (v.getSize() != 0) {
                val = rand() % 1000;
                int ind = rand() % v.getSize();
                v.insert(val, ind);
            }
            break;
        }
        case 4: {
            v.pop_back();
            break;
        }
        case 5: {
            v.pop_front();
            break;
        }
        default: break;
        }
    }
    cout << "\n" << v.getSize() << "\n";
    clock_t end = clock();
    double runTime = (double)(end - start) / CLOCKS_PER_SEC;
    cout << runTime;
}