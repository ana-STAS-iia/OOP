using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Figures
{
    public class Triangle: Figure
    {
        Point[] points = new Point[3];

        public Triangle(int _x, int _y, int _size, bool select, Color _color)
        {
            x = _x;
            y = _y;
            size = _size;
            calculatePoints();

            isSelected = select;
            color = _color;
        }

        private void calculatePoints()
        {
            points[0].X = x;
            points[0].Y = y - size;
            points[1].X = x + size;
            points[1].Y = y + size;
            points[2].X = x - size;
            points[2].Y = y + size;
        }
        public override void Move(int _x, int _y, int rightBorder, int bottomBorder)
        {
            base.Move(_x, _y, rightBorder, bottomBorder);
            calculatePoints();
        }

        public override void ChangeSize(int dSize, int rightBorder, int bottomBorder)
        {
            base.ChangeSize(dSize, rightBorder, bottomBorder);
            calculatePoints();
        }
        public override bool isLiesOn(int _x, int _y) //попали ли в область круга
        {
            int a = (points[0].X - _x) * (points[1].Y - points[0].Y) - (points[1].X - points[0].X) * (points[0].Y - _y);
            int b = (points[1].X - _x) * (points[2].Y - points[1].Y) - (points[2].X - points[1].X) * (points[1].Y - _y);
            int c = (points[2].X - _x) * (points[0].Y - points[2].Y) - (points[0].X - points[2].X) * (points[2].Y - _y);
            return (a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0);
        }

        public override void Paint(Graphics g) //отрисовка
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillPolygon(brush, points);

            Pen p = new Pen(color);
            p.Width = 3;
            if (isSelected)
            {
                p.Color = Color.RoyalBlue;
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            g.DrawPolygon(p, points);
        }
    }
}
