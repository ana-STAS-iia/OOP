using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp42
{
    public class Model
    {
        public int a, b, c;
        public EventHandler observers;

        public Model()
        {
            Load();
        }
        public int A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                if (a < 0) a = 0;
                if (a > 100) a = 100;
                if (a > b) b = a;
                if (a > c) c = a;
                Update();
            }
        }
        public int B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                if (b < a) b = a;
                if (b > c) b = c;
                Update();
            }
        }
        public int C
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
                if (c < 0) c = 0;
                if (c > 100) c = 100;
                if (b > c) b = c;
                if (a > c) a = c;
                Update();
            }
        }

        public void Load()
        {
            a = Properties.Settings.Default.a;
            b = Properties.Settings.Default.b;
            c = Properties.Settings.Default.c;
        }
        public void Update()
        {
            Properties.Settings.Default.a = a;
            Properties.Settings.Default.b = b;
            Properties.Settings.Default.c = c;
            observers.Invoke(this, null);
           
        }
    };
}
