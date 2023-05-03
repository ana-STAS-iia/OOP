using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp42
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observers += new System.EventHandler(this.UpdateFromModel);
        }



        public void UpdateFromModel(object sender, EventArgs e)
        {
            textBoxA.Text = model.A.ToString();
            textBoxB.Text = model.B.ToString();
            textBoxC.Text = model.C.ToString();
            numericUpDownA.Value = model.A;
            numericUpDownB.Value = model.B;
            numericUpDownC.Value = model.C;
            trackBarA.Value = model.A;
            trackBarB.Value = model.B;
            trackBarC.Value = model.C;
        }

        private void textBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox_Input(sender);
        }

        private void textBox_Input(object sender)
        {
            TextBox send = (TextBox)sender;
            int num;
            bool success = int.TryParse(send.Text, out num);
            if (success)
            {
                switch (send.Name.Last())
                {
                    case 'A': model.A = num; break;
                    case 'B': model.B = num; break;
                    case 'C': model.C = num; break;
                    default: break;
                }
            }
            else
            {
                model.Update();
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown send = (NumericUpDown)sender;
            switch (send.Name.Last())
            {
                case 'A': model.A = (int)send.Value; break;
                case 'B': model.B = (int)send.Value; break;
                case 'C': model.C = (int)send.Value; break;
                default: break;
            }
        }
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar send = (TrackBar)sender;
            switch (send.Name.Last())
            {
                case 'A': model.A = send.Value; break;
                case 'B': model.B = send.Value; break;
                case 'C': model.C = send.Value; break;
                default: break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateFromModel(sender, e);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}

