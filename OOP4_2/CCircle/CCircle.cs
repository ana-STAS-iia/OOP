using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCircle
{
    class CCircle
    {
        int x, y, radius;
        bool isSelected = false; //выбран ли круг

        public CCircle(int X, int Y, int Radius)
        {
            x = X;
            y = Y;
            radius = Radius;
        }

        public bool isLiesOn(int X, int Y) //попали ли в область круга
        {
            return (Math.Pow(x - X, 2) + Math.Pow(y - Y, 2) <= radius * radius);
        }

        public bool isSelect() //выбран ли круг
        {
            return isSelected;
        }

        public void Select() //выделяю круг
        {
            isSelected = true;
        }

        public void Unselect() //снимаю выделение
        {
            isSelected = false;
        }

        public void Paint(Graphics g) //отрисовка
        {
            g.FillEllipse(Brushes.HotPink, x - radius, y - radius, 2 * radius, 2 * radius); //круг цвета HotPink, появляется там, где нажала мышкой

            Pen p = new Pen(Color.Pink); //если не выделен, то цвет окружности Pink
            p.Width = 2; //ширина окружности 2
            if (isSelected) p.Color = Color.Red; //если выделяю, то кружность красного цвета
            g.DrawEllipse(p, x - radius, y - radius, 2 * radius, 2 * radius); //рисую окружность
        }
    }
}
