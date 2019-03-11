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
    }
}
