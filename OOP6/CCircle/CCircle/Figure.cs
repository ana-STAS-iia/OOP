using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public abstract class Figure
    {
        internal int x, y, size;
        internal bool isSelected;
        internal Color color;

        public virtual void Move(int _x, int _y, int rightBorder, int bottomBorder)
        {
            x += _x; y += _y;
            CorrectPosition(rightBorder, bottomBorder);
        }

        public void CorrectPosition(int rightBorder, int bottomBorder)
        {
            if (x + size > rightBorder)
            {
                x = rightBorder - size;
            }
            else if (x - size < 0)
            {
                x = size;
            }

            if (y + size > bottomBorder)
            {
                y = bottomBorder - size;
            }
            else if (y - size < 0)
            {
                y = size;
            }
        }
        public abstract bool isLiesOn(int _x, int _y);
        public void Select()
        {
            isSelected = true;
        }
        public void Unselect()
        {
            isSelected = false;
        }
        public bool isSelect()
        {
            return isSelected;
        } 

        public virtual void ChangeSize(int dSize, int rightBorder, int bottomBorder)
        {
            size += dSize;

            bool isTooLarge = false;
            if (size < 5 || size * 2 > rightBorder || size * 2 > bottomBorder)
            {
                isTooLarge = true;
            }

            if (isTooLarge)
            {
                ChangeSize(-dSize, rightBorder, bottomBorder);
            }

            CorrectPosition(rightBorder, bottomBorder);
        }
        public virtual void ChangeColor(Color _color)
        {
            color = _color;
        }
        public abstract void Paint(Graphics g);
    }
}