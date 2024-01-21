using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }
        line l1 = new line(100, 100, 200, 200);
        Graphics g;
        private void button1_Click(object sender, EventArgs e)
        {

            l1.Draw(g);


            ////平移
            //g.TranslateTransform(100, 200);
            //for (int i = 0; i < 12; i++)
            //{
            //    g.RotateTransform(30);
            //    g.DrawLine(p, 0, 0, 100, 0);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //g.Clear(Color.Black);
            g.TranslateTransform(200, 200);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
                g.RotateTransform(10);
            l1.Draw(g);
             
           
        }
        private bool isSelect = false;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            double length = Math.Sqrt(Math.Pow(Math.Abs(l1.p2.X - l1.p1.X), 2) + Math.Pow(Math.Abs(l1.p2.Y - l1.p1.Y), 2));
            double d1 = Math.Sqrt(Math.Pow(Math.Abs(e.Location.X - l1.p1.X), 2) + Math.Pow(Math.Abs(e.Location.Y - l1.p1.Y), 2));
            double d2 = Math.Sqrt(Math.Pow(Math.Abs(l1.p2.X - e.Location.X), 2) + Math.Pow(Math.Abs(l1.p2.Y - e.Location.Y), 2));
            if (Math.Abs(d1 + d2 - length) < 1)
            {
                l1.DrawSelect(g);
                isSelect = true;
                selectStartPoint = new Point(e.X, e.Y);
            }
            else
            {
                if(isSelect) g.Clear(Color.White);
                isSelect = false;
                
                l1.Draw(g);
            }
        }
        private Point selectStartPoint;
        private Point currentMovePoint = new Point();
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelect)
            {
                    currentMovePoint.X = e.Location.X;
                    currentMovePoint.Y = e.Location.Y;
                double length = Math.Sqrt(Math.Pow(Math.Abs(currentMovePoint.X - selectStartPoint.X), 2) + Math.Pow(Math.Abs(currentMovePoint.Y - selectStartPoint.Y), 2));
                if (length > 1)
                {
                    selectStartPoint.X = currentMovePoint.X;
                    selectStartPoint.Y = currentMovePoint.Y;
                    l1.p2.X = currentMovePoint.X;
                    l1.p2.Y = currentMovePoint.Y;
                    g.Clear(Color.White);
                    l1.Draw(g);
                    l1.DrawSelect(g);
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            g.Clear(Color.White);
            isSelect = false;

            l1.Draw(g);
        }
    }
}
