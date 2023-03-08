using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // 设置曲线的样式
            Series series = chart1.Series[0];
            // 画样条曲线（Spline）
            series.ChartType = SeriesChartType.Spline;
            // 线宽2个像素
            series.BorderWidth = 2;
            // 线的颜色：红色
            series.Color = System.Drawing.Color.Red;
            // 图示上的文字
            series.LegendText = "演示曲线";

            // 准备数据
            float[] values = { 95, 30, 20, 23, 60, 87, 42, 77, 92, 51, 29 };

            // 在chart中显示数据
            int x = 0;
            series.Points.Clear();
            foreach (float v in values)
            {
                series.Points.AddXY(x, v);
                x++;
            }

            Series series2 = chart1.Series[1];
           // series2.BorderWidth = 2;
            series2.Color = Color.Blue;
            series2.LegendText = "演示点";
            float[] values2 = { 95, 66,20, 23, 32, 87, 42, 77, 92, 51 };
            x = 0;
            series2.Points.Clear();
            foreach (float v in values2)
            {
                series2.Points.AddXY(x, v);
                x++;
            }


            // 设置显示范围
            ChartArea chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 10;
            chartArea.AxisY.Minimum = 0d;
            chartArea.AxisY.Maximum = 100d;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 设置曲线的样式
            Series series = chart1.Series[0];
            // 画样条曲线（Spline）
            series.ChartType = SeriesChartType.Column;
            // 线宽2个像素
            series.BorderWidth = 2;
            // 线的颜色：红色
            series.Color = System.Drawing.Color.Red;
            // 图示上的文字
            series.LegendText = "演示曲线";

            // 准备数据
            float[] values = { 95, 30, 20, 23, 60, 87, 42, 77, 92, 51, 29 };

            // 在chart中显示数据
            int x = 0;
            series.Points.Clear();
            foreach (float v in values)
            {
                series.Points.AddXY(x, v);
                x++;
            }

            

            // 设置显示范围
            ChartArea chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 10;
            chartArea.AxisY.Minimum = 0d;
            chartArea.AxisY.Maximum = 100d;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Series series = chart1.Series[0];
            //时间轴
            series.XValueType = ChartValueType.DateTime;



            // 设置显示范围
            ChartArea chartArea = chart1.ChartAreas[0];
            
            
            chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.None;
            chartArea.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea.AxisX.ScrollBar.Size = 20;
            //缩放图
            chartArea.AxisX.ScaleView.MinSizeType = DateTimeIntervalType.Seconds;
            chartArea.AxisX.ScaleView.SizeType = DateTimeIntervalType.Seconds;
            chartArea.AxisX.ScaleView.Size = 20;
            chartArea.AxisX.ScaleView.MinSize = 15;
            chartArea.AxisX.ScaleView.SmallScrollMinSize = 1;
            chartArea.AxisX.ScaleView.SmallScrollMinSizeType = DateTimeIntervalType.Seconds;

            chartArea.AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chartArea.AxisX.Interval = DateTime.Parse("00:00:05").Second;
            chartArea.AxisX.TitleAlignment = StringAlignment.Near;
            
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisX.MajorGrid.LineWidth = 1;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightSlateGray;

            chartArea.AxisX.LabelStyle.Format = "MMdd HH:mm:ss";

           
            chartArea.AxisY.Minimum = 0d;
            chartArea.AxisY.Maximum = 100d;
            chartArea.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightSlateGray;


           
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.Color = System.Drawing.Color.Red;
            series.LegendText = "演示曲线";

            // 准备数据
           
            Random r = new Random();
            int value=r.Next(1, 100);

            // 在chart中显示数据
            DateTime x = DateTime.Parse(DateTime.Now.ToLongTimeString());
            series.Points.Clear();
            int valueCount = 100000;
            while(valueCount>0)
            {
                valueCount--;
                value = r.Next(1, 100);
                series.Points.AddXY(x, value);
                x = x + TimeSpan.FromSeconds(1);
            }
            
            chartArea.AxisX.Minimum = DateTime.Parse(DateTime.Now.AddMinutes(-1).ToLongTimeString()).ToOADate();
            //chartArea.AxisX.Maximum = DateTime.Parse(DateTime.Now.AddMinutes(1).ToLongTimeString()).ToOADate();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].IsValueShownAsLabel = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].SmartLabelStyle.Enabled = checkBox1.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Series series = chart1.Series[0];
            DateTime x = DateTime.Parse(DateTime.Now.ToLongTimeString());
            var v = DateTime.Now.Ticks % 100;
            series.Points.AddXY(x, v);
            chart1.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Enabled = !timer1.Enabled;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (chart1.ChartAreas[0].AxisX.ScaleView.Size >= 0.5)
            {
                //放大，数字越小，越放大
                chart1.ChartAreas[0].AxisX.ScaleView.Size = chart1.ChartAreas[0].AxisX.ScaleView.Size * 0.5;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (chart1.ChartAreas[0].AxisX.ScaleView.Size <= 10000)
            {
                
                chart1.ChartAreas[0].AxisX.ScaleView.Size = chart1.ChartAreas[0].AxisX.ScaleView.Size * 2;
            }
        }

        private void chart1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                e.Text = string.Format("x:{0};y:{1:F3} ", dp.XValue, dp.YValues[0]);

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Annotations[0].Height = 20;
            chart1.Annotations[0].Width = 5;
            chart1.Annotations[0].X = 3;
            chart1.Annotations[0].Y = 50;
            //chart1.Annotations[0].AnchorDataPoint = chart1.Series[0].Points[1];
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 设置曲线的样式
            Series series = chart1.Series[0];
            series.ChartType = SeriesChartType.Candlestick;
            series.BorderWidth = 2;
            series.Color = System.Drawing.Color.Red;
            series.LegendText = "演示曲线";

            // 准备数据
            float[] values = { 95, 30, 20, 23, 60, 87, 42, 77, 92, 51, 29 };

            // 在chart中显示数据
            int x = 0;
            series.Points.Clear();
            foreach (float v in values)
            {
                DataPoint dp = new DataPoint(x, new double[] { 10, 60, 30, 40 });
                series.Points.Add(dp);
                x++;
            }

        }
    }
}
