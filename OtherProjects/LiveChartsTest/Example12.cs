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
    public partial class Example12 : Form
    {
        public Example12()
        {
            InitializeComponent();
        }

        private void Example12_Load(object sender, EventArgs e)
        {
            var values = new ChartValues<double>();

            var r = new Random();
            for (var i = 0; i < 100; i++)
            {
                values.Add(r.Next(0, 10));
            }

            cartesianChart1.Series.Add(new LineSeries
            {
                Values = values
            });

            cartesianChart1.AxisX.Add(new Axis
            {
                MinValue = 0,
                MaxValue = 25
            });
        }
        private void PreviousOnClick(object sender, EventArgs e)
        {
            cartesianChart1.AxisX[0].MinValue -= 25;
            cartesianChart1.AxisX[0].MaxValue -= 25;
        }

        private void NextOnClick(object sender, EventArgs e)
        {
            cartesianChart1.AxisX[0].MinValue += 25;
            cartesianChart1.AxisX[0].MaxValue += 25;
        }

        private void CustomZoomOnClick(object sender, EventArgs e)
        {
            cartesianChart1.AxisX[0].MinValue = 5;
            cartesianChart1.AxisX[0].MaxValue = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PreviousOnClick(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NextOnClick(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomZoomOnClick(sender, e);
        }
    }
}
