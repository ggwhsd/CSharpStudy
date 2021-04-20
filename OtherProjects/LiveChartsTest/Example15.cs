using LiveCharts;
using LiveCharts.Events;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveChartsTest
{
    public partial class Example15 : Form
    {
        private   ChartValues<double> datas =  new ChartValues<double> { 4, 6, 5, 3, 5 };
        public Example15()
        {
            InitializeComponent();


            cartesianChart1.Series.Add(new LineSeries
            {
                Values = datas,
                Fill = System.Windows.Media.Brushes.Transparent,
                StrokeThickness = 4,
                PointGeometrySize = 25
            });

            var ax = new Axis();
            ax.RangeChanged += AxOnRangeChanged;

            cartesianChart1.AxisX.Add(ax);
        }

        private void ChartOnDataClick(object sender, LiveCharts.ChartPoint p)
        {
            var asPixels = cartesianChart1.Base.ConvertToPixels(p.AsPoint());
            richTextBox1.SelectionColor = Color.AliceBlue ;
            richTextBox1.Text += "[EVENT] You clicked(" + p.X + ", " + p.Y + ") in pixels(" +
                           asPixels.X + ", " + asPixels.Y + ")";
            
        }

        private void Chart_OnDataHover(object sender, LiveCharts.ChartPoint chartPoint)
        {
            richTextBox1.SelectionColor = Color.LightGreen;
            richTextBox1.Text += "on data Hover \r\n";
        }

        private void ChartOnUpdaterTick(object sender)
        {
            richTextBox1.SelectionColor = Color.Yellow;
            richTextBox1.Text += "on data UpdaterTick \r\n";
        }

        private void AxOnRangeChanged(RangeChangedEventArgs eventArgs)
        {
            
            richTextBox1.SelectionColor = Color.OrangeRed;
            richTextBox1.Text += "[EVENT] axis range changed \r\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datas.Add(10);
            //cartesianChart1.Refresh();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //可以移动坐标轴
            cartesianChart1.Zoom = ZoomingOptions.X;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            datas[1] = 1;
        }
    }
}
