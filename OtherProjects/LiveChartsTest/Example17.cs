using LiveCharts;
using LiveCharts.Defaults;
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
    public partial class Example17 : Form
    {
        public Example17()
        {
            InitializeComponent();
        }
        //用ObservableValue和直接用double，感觉没啥区别啊。
        private ChartValues<ObservableValue> series1= new ChartValues<ObservableValue>();

        private ChartValues<ObservableValue> series2 = new ChartValues<ObservableValue>();


        private void Example17_Load(object sender, EventArgs e)
        {
            int i = 60;
            while (i > 0)
            {
                series1.Add(new ObservableValue(0));
                series2.Add(new ObservableValue(0));
                i--;
            }
            cartesianChart1.Series.Add(new StepLineSeries
            {
                Values = series2
            });

            cartesianChart1.Series.Add(new StepLineSeries
            {
                Values = series1,
                AlternativeStroke = System.Windows.Media.Brushes.Transparent,
                StrokeThickness = 3,
                PointGeometry = null
            });
        }
        private Random r = new Random();
        int index = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            series1[index].Value =(r.Next() % 100);
            series2[index].Value =(r.Next() % 100);
        }
    }
}
