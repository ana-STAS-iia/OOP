using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Container
{
    internal class Container<T> 
    {
        internal int size; //размер массива
        internal int capacity; //максимум
        internal T[] data; //массив
        internal int beginShift; //буфер

        public void grow()
        { //расширение 
            int begin = beginShift;
            T[] new_data = new T[2 * capacity];
            capacity *= 2;
            beginShift = capacity / 4;
            for (int i = beginShift; i < beginShift + size; i++)
            {
                new_data[i] = data[begin++];
            }
            data = new_data;
        }

        public void shrink()
        { //сжатие
            int begin = beginShift;
            T[] data_sh = new T[capacity / 2];
            capacity /= 2;
            beginShift = capacity / 4;
            for (int i = beginShift; i < beginShift + size; i++)
            {
                data_sh[i] = data[begin++];
            }
            data = data_sh;
        }

        public void tryRealloc()
        { //проверка нужно ли сжать или увеличить массив
            if (4 * size >= 3 * capacity)
            {
                grow();
            }
            else if (size > 32 && 8 * size <= capacity)
            {
                shrink();
            }
        }


        public Container()
        {
            size = 0;
            capacity = 16;
            data = new T[16]; //конструктор по умолчанию
        }

        public Container(int len)
        { //конструктор присваивания
            size = 0;
            capacity = len;
            beginShift = capacity / 4;
            data = new T[capacity];
        }

        ~Container()
        { //деструктор
            size = capacity = 0;
        }

        public int getSize()
        { //получаем размер
            return size;
        }

        public T back()
        { //конец массива
            if (size == 0)
            {
            }
            return data[beginShift + size - 1];
        }

        public void push_back(T elem)
        { //вставить элемент в конец
            if (beginShift + size == capacity)
            {
                grow();
            }
            data[beginShift + size] = elem;
            size++;
            tryRealloc();
        }

        public void push_front(T elem)
        { //вставить элемент в начало
            if (beginShift == 0)
            {
                grow();
            }
            data[--beginShift] = elem;
            size++;
            tryRealloc();
        }

        public void insert(T elem, int index)
        { //вставить элемент по индексу
            if (index < 0 || index >= size + beginShift)
            {
                return;
            }
            if (beginShift + size == capacity)
            {
                grow();
            }
            for (int i = beginShift + size; i > beginShift + index; i--)
            {
                data[i] = data[i - 1];
            }
            data[beginShift + index] = elem;
            size++;
            tryRealloc();
        }

        public void pop_back()
        { //удалить элемент в конце
            if (size == 0)
            {
                return;
            }
            size--;
            tryRealloc();
        }

        public void pop_front()
        { //удалить элемент в начале
            if (size == 0)
            {
                return;
            }
            beginShift++;
            size--;
            tryRealloc();
        }

        public void removeAt(int index)
        { //удалить элемент в начале
            if (size == 0)
            {
                return;
            }
            for (int i = index; i < size; i++)
            {
                data[i] = data[i + 1];
            }
            size--;
            tryRealloc();
        }

        public T getAt(int index)
        { //получить элемент
            if (index < 0 || index >= size)
            {
                return default(T);
            }
            else
            {
                return data[index + beginShift];
            }
        }
    };
}

