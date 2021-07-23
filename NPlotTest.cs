using System;
using NPlot;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPlot.Bitmap;

namespace MarketRiskUI
{
    public partial class NPlotTest : Form
    {
        public NPlotTest()
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
            cp.BullishColor = Color.Red;
            cp.BearishColor = Color.Green;
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar3 = (TrackBar)sender;
            this.Opacity = (double)trackBar3.Value / trackBar1.Maximum;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myPlot.Clear();             //清空
            Grid mygrid = new Grid(); //加入网格 
            myPlot.Add(mygrid);

            int leng = 10;
            int[] p = new int[10] { 1,2,3,4,5,6,7,8,9,10};
            int[] X = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] strLabel = new string[leng];
            for (int i = 0; i < leng; i++)
                strLabel[i] = Convert.ToString(p[i])+" label";

            LabelPointPlot labp = new LabelPointPlot();
            labp.AbscissaData = X ;
            labp.OrdinateData = p;
            labp.TextData = strLabel;
            labp.LabelTextPosition = LabelPointPlot.LabelPositions.Above;
            labp.Marker = new Marker(Marker.MarkerType.Square, 8);
            labp.Marker.Color = Color.Blue;
            myPlot.Add(labp);

            myPlot.Refresh();
        }
        ///水平线，只有纵坐标，没有横坐标
        private void button7_Click(object sender, EventArgs e)
        {
           
            HorizontalLine line = new HorizontalLine(1.2);
            line.LengthScale = 0.3f; ///长度与mplot长度的比例
            this.myPlot.Add(line,-10);
        }
        ///垂直线:只有横坐标，没有纵坐标
        private void button8_Click(object sender, EventArgs e)
        {
            
            VerticalLine line2 = new VerticalLine(1.2);
            line2.LengthScale = 0.89f;
            this.myPlot.Add(line2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LinePlot lp3 = new LinePlot();
            int[] p = new int[10] { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3 };
            int[] X = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            lp3.OrdinateData = p;
            lp3.AbscissaData = X;
            lp3.Pen = new Pen(Color.Orange);
            lp3.Pen.Width = 2;
            lp3.Label = " 价格";
            this.myPlot.Add(lp3);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                LinearAxis linx = (LinearAxis)myPlot.XAxis1;
                linx.Label = "时间";
                linx.AxisColor = Color.Orange;
                linx.LabelColor = Color.Orange;
                linx.TickTextColor = Color.Orange;
                this.myPlot.XAxis1 = linx;
                LinearAxis liny = (LinearAxis)myPlot.YAxis1;
                liny.Label = "价格";
                liny.AxisColor = Color.Orange;
                liny.LabelColor = Color.Orange;
                liny.TickTextColor = Color.Orange;
                this.myPlot.YAxis1 = liny;
            }
            else
            {
                LinearAxis linx = (LinearAxis)myPlot.XAxis1;
                linx.Label = "时间";
                linx.AxisColor = Color.Blue;
                linx.LabelColor = Color.Blue;
                linx.TickTextColor = Color.Blue;
                this.myPlot.XAxis1 = linx;

                LinearAxis liny = (LinearAxis)myPlot.YAxis1;
                liny.Label = "价格";
                liny.AxisColor = Color.Blue;
                liny.LabelColor = Color.Blue;
                liny.TickTextColor = Color.Blue;
                this.myPlot.YAxis1 = liny;
               
            }
            myPlot.Refresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LinePlot lp2 = new LinePlot();
            int[] p2 = new int[10] { 2, 4, 6, 8, 7, 3, 2, 1, 3, 1 };
            int[] X = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            lp2.OrdinateData = p2;
            lp2.AbscissaData = X;
            lp2.Pen = new Pen(Color.Green);
            lp2.Pen.Width = 2;
            lp2.Label = "销售量";
            //添加到第二横纵坐标轴上
            // this.myPlot.Add(lp2, NPlot.PlotSurface2D.XAxisPosition.Top, NPlot.PlotSurface2D.YAxisPosition.Right);
            //添加到第一横纵坐标轴
            this.myPlot.Add(lp2, NPlot.PlotSurface2D.XAxisPosition.Bottom, NPlot.PlotSurface2D.YAxisPosition.Left);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                LinearAxis liny2 = (LinearAxis)myPlot.YAxis2;
                if (liny2 == null)
                    liny2 = new LinearAxis();
                liny2.WorldMax = 1.2;
                liny2.WorldMin = 0;
                liny2.Label = "销售量";
                liny2.AxisColor = Color.Green;
                liny2.LabelColor = Color.Green;
                liny2.TickTextColor = Color.Green;
                this.myPlot.YAxis2 = liny2;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.myPlot.Legend = new Legend();
            this.myPlot.Legend.AttachTo(NPlot.PlotSurface2D.XAxisPosition.Top, NPlot.PlotSurface2D.YAxisPosition.Right);
            this.myPlot.Legend.NumberItemsHorizontally = 2;
            this.myPlot.Legend.HorizontalEdgePlacement = Legend.Placement.Inside;
            this.myPlot.Legend.VerticalEdgePlacement = Legend.Placement.Inside;
            this.myPlot.Legend.YOffset = 5;
            this.myPlot.Legend.XOffset = -5;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            LabelAxis la1 = new LabelAxis(this.myPlot.XAxis1);
            string[] sX = new string[5] { "a","b","c","d","e"};
            for (int i = 0; i < 5; i++)
            {
                la1.AddLabel(sX[i].ToString(), i);
            }
            la1.Label = "时间";
            la1.TickTextFont = new Font("Courier New", 10);
            la1.TicksBetweenText = false;
            this.myPlot.XAxis1 = la1;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            // y axis
            LogAxis logay = new LogAxis(myPlot.YAxis1);
            logay.WorldMin = 1;
            logay.WorldMax = 10;
            logay.AxisColor = Color.Red;
            logay.LabelColor = Color.Red;
            logay.TickTextColor = Color.Red;
            logay.LargeTickStep = 1.0f;
            logay.Label = "x^2";
            this.myPlot.YAxis1 = logay;
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                LinePlot lp3 = new LinePlot();
                int[] p = new int[10] { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3 };
                int[] X = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                lp3.OrdinateData = p;
                lp3.AbscissaData = X;
                lp3.Pen = new Pen(Color.Orange);
                lp3.Pen.Width = 2;
                lp3.Label = " 价格";

                LinePlot lp4 = new LinePlot();
                int[] p2 = new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
              
                lp4.OrdinateData = p2;
                lp4.AbscissaData = X;
                lp4.Pen = new Pen(Color.Orange);
                lp4.Pen.Width = 2;
                lp4.Label = " 价格";


                fr = new FilledRegion(lp3, lp4);

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


        HorizontalLine lineH2 = null;
        VerticalLine lineV2 = null;
        private void myPlot_MouseMove(object sender, MouseEventArgs e)
        {
            if (myPlot.PhysicalYAxis1Cache == null || myPlot.PhysicalXAxis1Cache == null)
            {
                return;
            }
            ///////水平线//////////
            if (lineH2 == null)
            {
                lineH2 = new HorizontalLine(10);

                lineH2.LengthScale = 2.89f;
                lineH2.OrdinateValue = 2;
                this.myPlot.Add(lineH2, 10);
            }

            double Y = myPlot.PhysicalYAxis1Cache.PhysicalToWorld(e.Location, false);
            double X = myPlot.PhysicalXAxis1Cache.PhysicalToWorld(e.Location, false);
            toolTip1.SetToolTip(myPlot, X + "," + Y);

            toolTip1.AutoPopDelay = 10 * 1000;
            ///////垂直线///////////
            if (lineV2 == null)
            {
                lineV2 = new VerticalLine(10);
                lineV2.LengthScale = 0.89f;
                lineV2.AbscissaValue = 2;
                this.myPlot.Add(lineV2);
            }

            lineH2.OrdinateValue = Y;
            lineV2.AbscissaValue = X;
            myPlot.Refresh();
        }

      
    }
}
