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



            
            //仪表 指针
            Example3 e3 = new Example3();
            e3.Show();

            //仪表 扇形
            Example4 e4 = new Example4();
            e4.Show();

            //柱状图
            Example5 e5 = new Example5();
            e5.Show();

            //柱状图
            Example6 e6 = new Example6();
            e6.Show();

            //柱状图
            Example7 e7 = new Example7();
            e7.Show();

            //泡泡图（散点图）
            Example8 e8 = new Example8();
            e8.Show();

            //折线图，添加了点击事件
            Example9 e9 = new Example9();
            e9.Show();

            //动态变化的时序图表数据（折线图）
            Example10 e10 = new Example10();
            e10.Show();

            //折线图，多条折现，自定义格式
            Example11 e11 = new Example11();
            e11.Show();

            //折线图，支持移动按键和放大
            Example12 e12 = new Example12();
            e12.Show();
        }

        private void pieChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show(chartPoint.Y.ToString());
        }
    }
}
