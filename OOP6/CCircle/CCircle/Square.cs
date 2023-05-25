using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Figures
{
    public class Square : Figure
    {
        public Square(int _x, int _y, int _size, bool select, Color _color)
        {
            x = _x;
            y = _y;
            size = _size;
            isSelected = select;
            color = _color;
        }

        public override bool isLiesOn(int _x, int _y) //попали ли в область круга
        {
            return Math.Abs(x - _x) < size && Math.Abs(y - _y) < size;
        }

        public override void Paint(Graphics g) //отрисовка
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillRectangle(brush, x - size, y - size, 2 * size, 2 * size);

            Pen p = new Pen(color);
            p.Width = 3;
            if (isSelected)
            {
                p.Color = Color.RoyalBlue;
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            g.DrawRectangle(p, x - size, y - size, 2 * size, 2 * size);

        }
    }
}
