using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace MarketRiskUI
{
   
    public partial class GDI : Form
    {
        public GDI()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        /**
         * 绘图水平线
         * 绘图垂直线
         * 绘画矩形
         * 
         */
        int i = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            if (isDot)
                blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            else
                blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            blackPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            blackPen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;
            
            Point point1 = new Point(10, 50);
            Point point2 = new Point(100, 50);
            Graphics g = this.CreateGraphics();
            g.DrawLine(blackPen,point1,point2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Pen myPen = new Pen(Color.Black, 3);
            graphics.DrawLine(myPen, 150, 30,150, 100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen myPen = new Pen(Color.Blue, 8);
            g.DrawRectangle(myPen, 10, 10, 150, 100);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Graphics g = this.CreateGraphics();
            Pen myPen = new Pen(Color.DarkOrange, 5);
            g.DrawEllipse(myPen, ((Button)sender).Left-10, ((Button)sender).Top-10, ((Button)sender).Width+15, ((Button)sender).Height+15);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            i++;
            Graphics g = this.CreateGraphics();
            Pen myPen = null;
            if (i>12)
               myPen = new Pen(Color.DarkRed, 5);
            else
               myPen = new Pen(Color.DarkGreen, 5);
            Rectangle myR = new Rectangle(((Button)sender).Left, ((Button)sender).Top - ((Button)sender).Width/2 + ((Button)sender).Height / 2, ((Button)sender).Width, ((Button)sender).Width);
            g.DrawArc(myPen, myR, 90, 30*i);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Image image = Image.FromFile(@"./hp_firefox.ico");
            g.DrawImage(image, ((Button)sender).Left, ((Button)sender).Top - ((Button)sender).Width / 2 + ((Button)sender).Height / 2, ((Button)sender).Width, ((Button)sender).Width);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen myPen = new Pen(Color.Blue, 8);
            g.DrawPie(myPen, ((Button)sender).Left, ((Button)sender).Top - ((Button)sender).Width / 2 + ((Button)sender).Height / 2, ((Button)sender).Width, ((Button)sender).Width,30,60);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen myPen = new Pen(Color.Blue, 2);
            Point p1 = new Point(Convert.ToInt32(textBox1.Text.Trim()), Convert.ToInt32(textBox2.Text.Trim()));
            Point p2 = new Point(Convert.ToInt32(textBox3.Text.Trim()), Convert.ToInt32(textBox4.Text.Trim()));
            Point p3 = new Point(Convert.ToInt32(textBox5.Text.Trim()), Convert.ToInt32(textBox6.Text.Trim()));
            Point p4 = new Point(Convert.ToInt32(textBox7.Text.Trim()), Convert.ToInt32(textBox8.Text.Trim()));

            g.DrawBezier(myPen,p1, p2,p3,p4);
         


            Pen blackPen = new Pen(Color.Black, 3);
            g.DrawLine(blackPen, p2, p3);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen myPen = new Pen(Color.Blue, 2);
            Point p1 = new Point(Convert.ToInt32(textBox1.Text.Trim()), Convert.ToInt32(textBox2.Text.Trim()));
            Point p2 = new Point(Convert.ToInt32(textBox3.Text.Trim()), Convert.ToInt32(textBox4.Text.Trim()));
            Point p3 = new Point(Convert.ToInt32(textBox5.Text.Trim()), Convert.ToInt32(textBox6.Text.Trim()));
            Point p4 = new Point(Convert.ToInt32(textBox7.Text.Trim()), Convert.ToInt32(textBox8.Text.Trim()));
            Point[] points = { p1,p2,p3,p4 };
            g.DrawPolygon(myPen,points);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Font myFont = new Font("华文行楷", 20);
            SolidBrush myB = new SolidBrush(Color.Blue);
            g.DrawString("hhh",myFont, myB,20,30);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string[] month = new string[12] { "1 ", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            float[] d = new float[12] { 20, 60, 10.8f, 15.6f, 30, 70.9f, 50.3f, 30.7f, 70, 50.4f, 30.8f, 20 };
            Bitmap bMap = new Bitmap(500,500);
            Graphics gph = Graphics.FromImage(bMap);
            gph.Clear(Color.White);

            PointF cPt = new PointF(40,420);
            PointF[] xPt = new PointF[3] { new PointF(cPt.Y + 15, cPt.Y), new PointF(cPt.Y, cPt.Y - 8), new PointF(cPt.Y, cPt.Y + 8) };
            PointF[] yPt = new PointF[3] { new PointF(cPt.X, cPt.X-15), new PointF(cPt.X - 8, cPt.X ), new PointF(cPt.X + 8, cPt.X) };
            gph.DrawString("某工厂某产品生产图标", new Font("宋体",14),Brushes.Black,new PointF(cPt.X+60,cPt.X));

            gph.DrawLine(Pens.Black,cPt.X,cPt.Y,cPt.Y,cPt.Y);
            gph.DrawPolygon(Pens.Black,xPt);
            gph.FillPolygon(new SolidBrush(Color.Black),xPt);
            gph.DrawString("月份", new Font("宋体", 12), Brushes.Black, new PointF(cPt.Y + 10, cPt.Y+10));

            gph.DrawLine(Pens.Black, cPt.X, cPt.Y, cPt.X, cPt.X);
            gph.DrawPolygon(Pens.Black, yPt);
            gph.FillPolygon(new SolidBrush(Color.Black), yPt);
            gph.DrawString("单位", new Font("宋体", 12), Brushes.Black, new PointF(0,7));

            for (int i = 1; i <= 12; i++)
            {
                if (i < 11)
                {
                    gph.DrawString((i*10).ToString(),new Font("宋体",11),Brushes.Black,new PointF(cPt.X -30,cPt.Y-i*30-60));
                    gph.DrawLine(Pens.Black,cPt.X-3,cPt.Y-i*30,cPt.X,cPt.Y-i*30);
                }
                gph.DrawString(month[i-1],new Font("宋体",11),Brushes.Black,new PointF(cPt.X+i*30-5,cPt.Y+5));
                gph.DrawEllipse(Pens.Black,cPt.X+i*30-1.5f,cPt.Y-d[i-1]*3-1.5f,3,3);
                gph.FillEllipse(new SolidBrush(Color.Black),cPt.X+i*30-1.5f,cPt.Y-d[i-1]*3-1.5f,3,3);
                gph.DrawString(d[i-1].ToString(),new Font("宋体",11),Brushes.Black,new PointF(cPt.X+i*30,cPt.Y-d[i-1]*3));
                if (i > 1)
                    gph.DrawLine(Pens.Red, cPt.X + (i - 1) * 30, cPt.Y - d[i - 2] * 3, cPt.X + i * 30, cPt.Y - d[i - 1] * 3);

            }


            pictureBox1.Image = bMap;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point();
            p.X = e.X;
            p.Y = e.Y;

           
          
            
            if (Math.Abs(e.X) < 5)
                this.Cursor = Cursors.VSplit;
            else if (e.Y < 5 && e.Y>0)
                this.Cursor = Cursors.HSplit;
            else
                this.Cursor = Cursors.Default;


            Bitmap bit = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics gra = Graphics.FromImage(bit);
          
            Font myFont = new Font("华文行楷", 9);
            SolidBrush myB = new SolidBrush(Color.Blue);
          
            gra.DrawString("" + p.ToString(), myFont, myB, 10, 30);

            pictureBox2.Image = bit;
            pictureBox2.Location = new Point(pictureBox1.Location.X+e.Location.X,pictureBox1.Location.Y + e.Location.Y);


        }

        private void button12_Click(object sender, EventArgs e)
        {
          
       
        }
        private Point[] lineSPoint = new Point[100];
        private Point[] lineDPoint= new Point[100];
        private void button12_Click_1(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gra = Graphics.FromImage(bit);
            for (int i = 1; i < pictureBox1.Height / 50; i++)
            {
                Point source = new Point(0, i * 100);
                Point dest = new Point(pictureBox1.Width, i * 100);
                gra.DrawLine(Pens.Red, source ,dest);
                lineSPoint[i-1]=(source);
                lineDPoint[i-1]=(dest);
                Font myFont = new Font("华文行楷", 20);
                SolidBrush myB = new SolidBrush(Color.Blue);
                gra.DrawString("线条高度:"+i*50, myFont, myB, 0, i * 50);
            }
            pictureBox1.Image = bit;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Cursor == Cursors.HSplit)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 10);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gra = Graphics.FromImage(bit);
            int i = 0;

            for(;i<lineSPoint.Length;i++)
            {
                Point source = lineSPoint[i];
                Point dest = lineDPoint[i];
                gra.DrawLine(Pens.Transparent, source, dest);
            }
            pictureBox1.Image = bit;
        }
        private bool isDot = false;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                if (rb.Text == "虚线")
                {
                    isDot = true;
                }
                else
                {
                    isDot = false;
                }
            }
            else
            {

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();



            Point point = new Point(10, 10);

            Rectangle rect = new Rectangle(10, 10, 20, 150);

            Point off = new Point(30, 0);





            Brush brush;



            brush = Brushes.Azure;

            rect.Offset(off); g.FillRectangle(brush, rect);

            brush = SystemBrushes.Desktop;

            rect.Offset(off); g.FillRectangle(brush, rect);

            brush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));

            rect.Offset(off); g.FillRectangle(brush, rect);



            Image bm = Bitmap.FromFile(@"./hp_firefox.ico");

            brush = new TextureBrush(bm);

            rect.Offset(off); g.FillRectangle(brush, rect);


            brush = new HatchBrush(

                HatchStyle.Vertical,

                Color.ForestGreen,

                Color.Honeydew);

            rect.Offset(off); g.FillRectangle(brush, rect);



            brush = new LinearGradientBrush(

                new PointF(50, 50), new PointF(200, 200),

                Color.Red, Color.Yellow);

            rect.Offset(off); g.FillRectangle(brush, rect);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();


            PointF[] cur1 = new PointF[150];

            for (int i = 0; i < cur1.Length; i++)

            {

                double x = (double)i / 5;

                double y = Math.Sin(x) * 3 + Math.Cos(3 * x);

                cur1[i] = new PointF((float)i, (float)(y * 10 + 100));

            }

            g.DrawLines(Pens.Blue, cur1);



            PointF[] cur2 = new PointF[100];

            for (int i = 0; i < cur2.Length; i++)

            {

                double theta = Math.PI / 50 * i;

                double r = Math.Cos(theta * 16);

                cur2[i] = new PointF(

                    (float)(r * Math.Cos(theta) * 50 + 230),

                    (float)(r * Math.Sin(theta) * 50 + 100));

            }

            g.DrawLines(Pens.Blue, cur2);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //画轮廓，可以写字，也可以画其他形状
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);

            gp.AddString(

                "字体轮廓",

                new FontFamily("方正舒体"),

                (int)FontStyle.Regular,

                100,

                new PointF(10, 20),

                new StringFormat());



            Brush brush = new LinearGradientBrush(

                    new PointF(0, 0), new PointF(Width, Height),

                    Color.Yellow, Color.Blue);


            Graphics gdi = this.CreateGraphics();
            gdi.DrawPath(Pens.Black, gp);  //空心文字

            gdi.FillPath(brush, gp);  //实心文字
        }
    }
}
