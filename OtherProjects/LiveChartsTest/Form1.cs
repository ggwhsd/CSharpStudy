using LiveCharts;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pieChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show(chartPoint.Y.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //仪表 指针
            Example3 e3 = new Example3();
            e3.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //仪表 扇形
            Example4 e4 = new Example4();
            e4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //柱状图
            Example5 e5 = new Example5();
            e5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //柱状图
            Example6 e6 = new Example6();
            e6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //柱状图
            Example7 e7 = new Example7();
            e7.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //泡泡图（散点图）
            Example8 e8 = new Example8();
            e8.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //折线图
            Example9 e9 = new Example9();
            e9.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            //动态变化的时序图表数据（折线图）
            //自定义类成员与X、Y也可以进行映射配置。
            Example10 e10 = new Example10();
            e10.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //折线图，多条折现，自定义格式
            Example11 e11 = new Example11();
            e11.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //折线图，支持移动按键和放大
            Example12 e12 = new Example12();
            e12.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //一般一张图都是显示相同横坐标，不同纵坐标，点数相同。  这里是显示不同序列的不同个数的点，一条直线，一些柱状。
            Example13 e13 = new Example13();
            e13.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //可以自由控制显示哪个折线。
            Example14 e14 = new Example14();
            e14.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //使用图中的各种事件触发
            Example15 e15 = new Example15();
            e15.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //金融ohlc线，蜡烛图
            Example16 e16 = new Example16();
            e16.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //stepLine，可以用于金融中的tick数据。
            Example17 e17 = new Example17();
            e17.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pie图
            Func<ChartPoint, string> labelPoint = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "SHFE",
                    Values = new ChartValues<double> {3},
                    PushOut = 15,  //突出显示程度
                    DataLabels = false,  //在图上不显示数据标签
                    LabelPoint = labelPoint   //标签显示格式
                },
                new PieSeries
                {
                    Title = "INE",
                    Values = new ChartValues<double> {4},
                    PushOut = 5,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "DCE",
                    Values = new ChartValues<double> {5},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "CFFEX",
                    Values = new ChartValues<double> {6},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pieChart2.InnerRadius = 60;
            pieChart2.LegendLocation = LegendLocation.Right;

            pieChart2.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Chrome",
                    Values = new ChartValues<double> {8},
                    PushOut = 5,
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Mozilla",
                    Values = new ChartValues<double> {6},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Opera",
                    Values = new ChartValues<double> {10},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Explorer",
                    Values = new ChartValues<double> {4},
                    DataLabels = true
                }
            };
        }

    }
}
