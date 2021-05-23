using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UITest
{
    public partial class GDITimerRefresh : Form
    {
        public GDITimerRefresh()
        {
            InitializeComponent();

        }
        int i = 0;
        Pen myPen = new Pen(Color.DarkRed, 5);
        Pen myPen2 = new Pen(Color.DarkBlue, 5);
        Rectangle myR = new Rectangle(10,
    100,
    100,
    100);
        Rectangle myR2 = new Rectangle(10,
    250,
    100,
    100);
        //在form控件上绘画
        private void DrawTwoCircle()
        {
            i++;
            if (i > 360)
            {
                i = 0;
                myPen.Color = Color.DarkBlue == myPen.Color ? Color.DarkRed : Color.DarkBlue;
                if (myR.Height < 10)
                    return;
                myR.Height -= 10;
                myR.Width -= 10;

                myR2.Height -= 10;
                myR2.Width -= 10;
                myPen2.Color = Color.DarkBlue == myPen2.Color ? Color.DarkRed : Color.DarkBlue;
            }
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            //画圆弧
            g.DrawArc(myPen, myR, 90, 1 * i);

            //画圆弧
            g.DrawArc(myPen2, myR2, 90, 1 * i);
        }
        //在画板上绘画
        private void DrawImage()
        {
         
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawTwoCircle();
            

        }
        //在image画图板上绘画
        private Image drawInImage()
        {
            Bitmap image = new Bitmap(300, 500);
            Graphics g = Graphics.FromImage(image);

            //g.Clear(Color.Black);
            //使绘图质量最高，即消除锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            float startX = 50;
            float startY = 50;
            Rectangle rc = new Rectangle((int)startX - 5, (int)startY - 5, 300, 60);
            g.DrawRectangle(myPen, rc);//在画板上画矩形


            g.DrawLine(myPen, startX - 5, startY + 20, 200, startY + 20);//在画板上画直线

            g.DrawEllipse(myPen, startX - 5, startY - 5, 300, 60);//在画板上画椭圆 
            g.FillEllipse(new SolidBrush(Color.Green), rc);
            g.DrawString("如下报表数据", new Font("宋体", 12), new SolidBrush(myPen.Color), new PointF(startX + rc.Width / 2 - 50, startY + rc.Height / 2 - 6));
            g.Dispose();
            return image;
           
        }
        //并将图片保存
        private void 保存界面图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawInImage().Save("testGdi.jpg");

            

        }

        private void 自动画图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void pictureBox画图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)drawInImage();
           
        }

        private void 导入图片到pictureBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image image1 = Image.FromFile("testGdi.jpg");
            pictureBox1.Image = image1;
            Graphics g = this.CreateGraphics();
            //复制图像：实际上是重画图像
            g.DrawImage(image1, 20, 60, image1.Width , image1.Height );
            //复制图像：实际上是重画图像
            g.DrawImage(image1, 50, 100, image1.Width , image1.Height );
            
            g.Dispose();

        }

        private void 用图片填充某块区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            //用图片
            TextureBrush b2 = new TextureBrush(Image.FromFile("testGdi.jpg"));
            float startX = 50;
            float startY = 50;
            Rectangle rc = new Rectangle((int)startX - 5, (int)startY - 5, 300, 60);
            g.FillRectangle(b2, rc);

            //用渐变色
            //LinearGradientBrush b3 = new LinearGradientBrush(rc, Color.Yellow, Color.Black, LinearGradientMode.Horizontal);
            //g.FillRectangle(b3, rc);

            g.Dispose();
        }

        private void 截屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();//隐藏当前窗体
            Thread.Sleep(50);//让线程睡眠一段时间，窗体消失需要一点时间
            Snapshot ss = new Snapshot();
            Bitmap CatchBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);//新建一个和屏幕大小相同的图片       
            Graphics g = Graphics.FromImage(CatchBmp);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));//保存全屏图片。
            ss.BackgroundImage = CatchBmp;//将Catch窗体的背景设为全屏时的图片
            if (ss.ShowDialog() == DialogResult.OK)
            {//如果Catch窗体结束,就将剪贴板中的图片放到信息发送框中
                IDataObject iData = Clipboard.GetDataObject();
                DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    richTextBox1.Paste(myFormat);
                    Clipboard.Clear();//清除剪贴板中的对象
                }
                this.Show();//重新显示窗体
            }

        
        }

        private void 绘制圆角矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            GraphicsPath gp = new GraphicsPath();
            DrawRoundRect(gp, 15, 30, 100, 100, 10);
            g.DrawPath(new Pen(Color.Gray, 2), gp);
            g.FillPath(Brushes.SkyBlue, gp);
            gp.Dispose();
            g.Dispose();
        }

        private void DrawRoundRect(GraphicsPath gp, int X, int Y, int width, int height, int radius)
        {
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);

            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);

            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
        }

        private void 文本框重绘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = textBox1.CreateGraphics();
            
            GraphicsPath gp = new GraphicsPath();
            DrawRoundRect(gp, textBox1.Location.X, textBox1.Location.Y, textBox1.Width+10, textBox1.Height+10, 10);
            g.DrawPath(new Pen(Color.Gray, 2), gp);
            gp.Dispose();
            g.Dispose();
            
        }


        private void 画很多圈圈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cicles =100;
            Random r = new Random();
            ;
            int cols = 30;
            int i = 1;
            int rowIndex=0,colIndex = 0;
            while (i <= cicles)
            {

                if (colIndex == cols)
                {
                    colIndex = 0;
                    rowIndex++;
                }
                DrawCicile(colIndex*10+10, 100 + rowIndex * 20+ r.Next()%10, 10, Color.Blue, 2);
                colIndex++;

                i++;
            }
        }
        private void DrawCicile(int x,int y,int radius,Color penC,int penWidth)
        {
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            Pen pen = new Pen(penC, penWidth);
            Rectangle r = new Rectangle(x,
   y,
   radius,
   radius);
            //画圆弧
            g.DrawArc(pen, r, 90, 360);
            g.Dispose();
            pen.Dispose();
            
        }

        private void GDITimerRefresh_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
