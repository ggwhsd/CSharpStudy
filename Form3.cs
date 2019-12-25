using System;
using NPlot;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.myPlot.Clear();
            ////////网格//////////
            Grid mygrid = new Grid();
            mygrid.HorizontalGridType = Grid.GridType.Fine;
            mygrid.VerticalGridType = Grid.GridType.Fine;
            this.myPlot.Add(mygrid);
            ///////水平线//////////
            HorizontalLine line = new HorizontalLine(10);
            line.LengthScale = 2.89f;
            //line.OrdinateValue = 2;
            this.myPlot.Add(line, 10);
            ///////垂直线///////////
            VerticalLine line2 = new VerticalLine(10);
            line2.LengthScale = 0.89f;
            this.myPlot.Add(line2);


            ///////蜡烛图///////////
            int[] opens = { 1, 2, 1, 2, 1, 3 };
            double[] closes = { 2, 2, 2, 1, 2, 1 };
            float[] lows = { 1, 1, 1, 1, 1, 1 };
            System.Int64[] highs = { 3, 2, 3, 3, 3, 4 };
            int[] times = { 0, 1, 2, 3, 4, 5 };
            CandlePlot cp = new CandlePlot();
            cp.CloseData = closes;
            cp.OpenData = opens;
            cp.LowData = lows;
            cp.HighData = highs;
            cp.AbscissaData = times;
            this.myPlot.Add(cp);

            this.myPlot.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myPlot.Clear();             //清空
            Grid mygrid = new Grid(); //加入网格 
            myPlot.Add(mygrid);

           Marker m = new Marker(Marker.MarkerType.FilledCircle, 6, new Pen(Color.Blue, 2.0F));//点状图的类型，实心圆点
            //Marker m = new Marker(Marker.MarkerType.Cross1, 6, new Pen(Color.Blue, 2.0F));//点状图的类型,叉形
           PointPlot pp = new PointPlot(m);
            int[] a = new int[] { 0, 1 };
            pp.OrdinateData = a;
            StartStep b = new StartStep(-500.0, 10.0);//根据第一个数，可以得到相差10的两个数
            pp.AbscissaData = b;
            pp.Label = "Random";
            myPlot.Add(pp);

            myPlot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            myPlot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            myPlot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));

            myPlot.XAxis1.IncreaseRange(0.1);
            myPlot.YAxis1.IncreaseRange(0.1); //缩小到合适大小
            myPlot.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myPlot.Clear();
            StepPlot sp1 = new StepPlot();
            sp1.OrdinateData = new int[] { 0, 1, 2 };
            sp1.AbscissaData = new int[] { 4, 5, 6 };
            sp1.Label = "高度";
            sp1.Pen.Width = 2;
            sp1.Pen.Color = Color.Blue;
            myPlot.Add(sp1);
            myPlot.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myPlot.Clear();
            HistogramPlot hp3 = new HistogramPlot();
            hp3.AbscissaData = new int[] { 0, 1, 2 };
            hp3.OrdinateData = new int[] { 4, 5, 6 };
            hp3.BaseWidth = 0.6f;
            hp3.RectangleBrush = RectangleBrushes.Vertical.FaintBlueFade;//纵向渐变
            hp3.Filled = true;
            hp3.Label = "一月";
            HistogramPlot hp4 = new HistogramPlot();
            hp4.AbscissaData = new int[] { 0, 1, 2 };
            hp4.OrdinateData = new int[] { 7, 81, 9 };
            hp4.Label = "二月";
            hp4.RectangleBrush = RectangleBrushes.Horizontal.FaintGreenFade;//横向渐变
            hp4.Filled = true;
            hp4.StackedTo(hp3);
            myPlot.Add(hp3);
            myPlot.Add(hp4);
            myPlot.Refresh();
        }
        private int timesNext = 6;
        CandlePlot cp_button5;
        private void button5_Click(object sender, EventArgs e)
        {
            ///////蜡烛图///////////
            Random rand = new Random();
            
            int[] opens = { rand.Next(1, 10), rand.Next(1, 10) };
            double[] closes = { rand.Next(1, 10), rand.Next(1, 10) };
            float[] lows = { 1, 1 };
            System.Int64[] highs = { rand.Next(10, 13), rand.Next(10, 13) };
            int[] times = { timesNext++, timesNext++ };
            if (cp_button5 == null)
            {

                

                cp_button5 = new CandlePlot();
                cp_button5.CloseData = closes;
                cp_button5.OpenData = opens;
                cp_button5.LowData = lows;
                cp_button5.HighData = highs;
                cp_button5.AbscissaData = times;
                this.myPlot.Add(cp_button5);
            }
            else
            {
                cp_button5.CloseData = closes;
                cp_button5.OpenData = opens;
                cp_button5.LowData = lows;
                cp_button5.HighData = highs;
                cp_button5.AbscissaData = times;
            }
            
            this.myPlot.Refresh();
        }
        NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag hdrag = new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                myPlot.AddInteraction(hdrag);
            }
            else
            {
                myPlot.RemoveInteraction(hdrag);
                
            }
        }
        NPlot.Windows.PlotSurface2D.Interactions.AxisDrag adray = new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true);
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                myPlot.AddInteraction(adray);
            }
            else
            {
                myPlot.RemoveInteraction(adray);

            }
            
           
        }
        NPlot.Windows.PlotSurface2D.Interactions.MouseWheelZoom mwZoom = new NPlot.Windows.PlotSurface2D.Interactions.MouseWheelZoom();
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                myPlot.AddInteraction(mwZoom);
            }
            else
            {
                myPlot.RemoveInteraction(mwZoom);

            }
            
        }
        NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag vdrag = new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag();
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                myPlot.AddInteraction(vdrag);
            }
            else
            {
                myPlot.RemoveInteraction(vdrag);

            }
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                myPlot.XAxis1.Label="x 横坐标";
                myPlot.XAxis1.LabelColor = Color.Blue;
                myPlot.XAxis1.IncreaseRange(0.1);
            }
            else
            {
                myPlot.XAxis1.Label = "";
                myPlot.XAxis1.LabelColor = Color.Blue;
                myPlot.XAxis1.IncreaseRange(0.1);

            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                myPlot.YAxis1.Label = "x 横坐标";
                myPlot.YAxis1.LabelColor = Color.Blue;
                myPlot.YAxis1.IncreaseRange(0.1);
            }
            else
            {
                myPlot.YAxis1.Label = "";
                myPlot.YAxis1.LabelColor = Color.Blue;
                myPlot.YAxis1.IncreaseRange(0.1);

            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                myPlot.PlotBackColor = Color.Blue;
               
            }
            else
            {
                myPlot.PlotBackColor = Color.Yellow;

            }
        }

        private void 改变颜色为黄色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myPlot.PlotBackColor = Color.Yellow;
        }
        ArrowItem a = null;
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                a = new ArrowItem(new PointD(2, 4), 360 - (30 - 90), "Arrow");
                //a.HeadOffset = 5;
                a.ArrowColor = Color.Red;
                a.TextColor = Color.Purple;
                this.myPlot.Add(a);
            }
            else
            {
                if (a != null)
                {
                    this.myPlot.Remove(a,false);
                }
            }
            myPlot.Refresh();
        }
        FilledRegion fr = null;
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                fr = new FilledRegion(new VerticalLine(1.2), new VerticalLine(2.4));
               
                fr.Brush = Brushes.BlanchedAlmond;
                this.myPlot.Add(fr);
            }
            else
            {
                if (fr != null)
                {
                    this.myPlot.Remove(fr, false);
                }
            }
            myPlot.Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            myPlot.XAxis1.IncreaseRange( (double)trackBar1.Value / trackBar1.Maximum);
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            myPlot.XAxis1.IncreaseRange(-1*(double)trackBar1.Value / trackBar1.Maximum);
        }
    }
}
