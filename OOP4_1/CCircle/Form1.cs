using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCircle
{
    public partial class FormCircles : Form
    {
        
        bool isPressedCtrl = false; //нажат ли ctrl
        int selectedCircles = 1; //сколько выбрано кругов
        List<CCircle> circles = new List<CCircle>(); //контейнер кругов
        public FormCircles()
        {
            InitializeComponent();
        }

        private void pnlPaint_Paint(object sender, PaintEventArgs e) //отрисовка кругов
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < circles.Count(); i++)
            {
                circles[i].Paint(g);
            }
        }

        private void ProcessingCircleWithCtrl(CCircle circle) //обработка нажатия на круг, если ctrl зажат
        {
            if (circle.isSelect() && selectedCircles > 1) //если круг и так выделен и выделеенных кругов больше, чем 1, то снимаю с него выделение
            {
                circle.Unselect();
                selectedCircles--;
            }
            else if (circle.isSelect() && selectedCircles == 1) //если круг выделен и выделеенных кругов 1, то ничего не меняется
            {
            }
            else if (!circle.isSelect()) //если круг не выделен, то выделяю
            {
                circle.Select();
                selectedCircles++;
            }
        }

        private void pnlPaint_MouseDown(object sender, MouseEventArgs e) //обработка нажатия
        {
            bool isOnCircle = false; //попало ли на круг

            if (isPressedCtrl && isWorkingWithCtrl.Checked) //если чекбокс ctrl помечен и клавиша зажата
            {
                for (int i = circles.Count - 1; i > -1; i--) //прохожусь по контейнеру
                {
                    if (isMultipleSelection.Checked) //если могу выделять 2 объекта при их пересечении
                    {
                        if (circles[i].isLiesOn(e.X, e.Y))// если попала на круг
                        {
                            isOnCircle = true; //отмечаю, что попала
                            ProcessingCircleWithCtrl(circles[i]); //перехожу на обработчик нажатия с ctrl
                        }
                    }
                    else if (circles[i].isLiesOn(e.X, e.Y)) //если не могу выделять 2 объекта при их пересечении, но по кругу попала
                    {
                        isOnCircle = true; //отмечаю, что попала
                        ProcessingCircleWithCtrl(circles[i]); //перехожу на обработчик нажатия с ctrl
                        break; //выхожу из цикла
                    }
                }
            }
            else //если работаю без ctrl
            {
                selectedCircles = 0; //обнуляю количество выбранных кругов
                for (int i = circles.Count - 1; i > -1; i--) //прохожусь по контейнеру
                {
                    if (isMultipleSelection.Checked) //если могу выделять 2 объекта при их пересечении
                    {
                        if (circles[i].isLiesOn(e.X, e.Y)) //если попала по кругу
                        {
                            isOnCircle = true; //отмечаю, что попала
                            circles[i].Select(); //выделяю круг
                            selectedCircles++; //прибавляю к счетчику выбранных кругов 1
                        }
                        else
                            circles[i].Unselect(); //иначе снимаю с него выделение
                    }
                    else //если не могу выделять 2 объекта при их пересечении
                    {
                        if (circles[i].isLiesOn(e.X, e.Y) && !isOnCircle) // если попала по кругу
                        {
                            isOnCircle = true; //отмечаю, что попала
                            circles[i].Select(); //выделяю круг
                            selectedCircles++; //прибавляю к счетчику выбранных кругов 1
                        }
                        else
                            circles[i].Unselect(); //иначе снимаю выделение
                    }
                }
            }

            if (!isOnCircle) //если яне попала по кругу
            {
                circles.Add(new CCircle(e.X, e.Y, 20)); //то добавляю
                circles[circles.Count - 1].Select(); //выделяю его

                if (isPressedCtrl && isWorkingWithCtrl.Checked) selectedCircles++; //если работаю с ctrl, то прибавляю счетчик
                else selectedCircles = 1; //иначе выбранных кругов 1
            }

            pnlPaint.Invalidate();
        }

        private void FormCircles_KeyDown(object sender, KeyEventArgs e) //обработка нажатия клавиш
        {
            if (e.KeyCode == Keys.ControlKey) 
                isPressedCtrl = true; //нажала на ctrl, отмечаю что ctrl работает

            if (e.KeyCode == Keys.Delete) //если нажала клавишу Delete
            {
                for (int i = 0; i < circles.Count; i++) //прохожу по контейнеру
                    if (circles[i].isSelect()) //если круг выделен, то удаляю его
                        circles.RemoveAt(i--);

                if (circles.Count > 0) //если кругов больше 0
                {
                    circles[circles.Count - 1].Select(); //то выделяю последний оставшийся в контейнерее
                    selectedCircles = 1; //выбранных кругов 1
                }
                else
                    selectedCircles = 0; //иначе выбранных кругов нет
                
                pnlPaint.Invalidate();
            }
        }

        private void FormCircles_KeyUp(object sender, KeyEventArgs e) //отжатие клавиши ctrl
        {
            if (e.KeyCode == Keys.ControlKey)
                isPressedCtrl = false;
        }

    }
}

