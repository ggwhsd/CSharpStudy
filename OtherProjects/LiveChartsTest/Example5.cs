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
    public partial class Example5 : Form
    {
        public Example5()
        {
            InitializeComponent();
        }

        private void Example5_Load(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new StackedRowSeries
                {
                    Values = new ChartValues<double> {4, 5, 6, 8},
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString()
                },
                new StackedRowSeries
                {
                    Values = new ChartValues<double> {2, 5, 6, 7},
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString()
                }
            };

            //adding series updates and animates the chart
            cartesianChart1.Series.Add(new LiveCharts.Wpf.StackedRowSeries
            {
                Values = new ChartValues<double> { 6, 2, 7 },
                StackMode = StackMode.Percentage,
                DataLabels = true,
                LabelPoint = p => p.X.ToString()
            });

            //adding values also updates and animates
            cartesianChart1.Series[2].Values.Add(4d);

            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Browser",
                Labels = new[] { "Chrome", "Mozilla", "Opera", "IE" }
            });
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                LabelFormatter = val => val.ToString("P")
            });

            var tooltip = new LiveCharts.Wpf.DefaultTooltip { SelectionMode = TooltipSelectionMode.SharedYValues };

            cartesianChart1.DataTooltip = tooltip;
        }
    }
}
