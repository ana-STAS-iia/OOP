using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Figures
{
    public class Circle : Figure
    {

        public Circle(int _x, int _y, int _size, bool select, Color _color)
        {
            x = _x;
            y = _y;
            size = _size;
            isSelected = select;
            color = _color;
        }

        public override bool isLiesOn(int X, int Y) //попали ли в область круга
        {
            return (Math.Pow(x - X, 2) + Math.Pow(y - Y, 2) <= size * size);
        }

        public override void Paint(Graphics g) //отрисовка
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillEllipse(brush, x - size, y - size, 2 * size, 2 * size); //круг цвета HotPink, появляется там, где нажала мышкой

            Pen p = new Pen(color);
            p.Width = 3;
            if (isSelected)
            {
                p.Color = Color.RoyalBlue;
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            g.DrawEllipse(p, x - size, y - size, 2 * size, 2 * size);
        }
    }
}
