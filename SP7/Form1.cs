using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP7
{
    public partial class Form1 : Form
    {
        private object currobject = null;
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += new 
            MouseEventHandler(mouseEvent);
        }

        private void mouseEvent(object sender, MouseEventArgs e)
        {
            if (currobject != null)
            {
                Control control = currobject as Control;
                control.Location = new Point(Cursor.Position.X - control.Width / 2,
                    Cursor.Position.Y - control.Height / 2);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("Левая кнопка мышки");
            }
            else if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Правая кнопка мышки");
            }
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            label2.Text = "Мышь близко";
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = "Мышь уходит";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"X: {e.X}, Y: {e.Y}";
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            button1.Location = new Point(rnd.Next(20, 600), rnd.Next(20, 400));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currobject = sender;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.DoDragDrop(button3, DragDropEffects.Move);
            button3.Left += e.X - button3.Width / 2;
            button3.Top += e.Y - button3.Height / 2;
        }
    }
}
