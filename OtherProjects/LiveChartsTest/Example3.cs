using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace LiveChartsTest
{
    public partial class Example3 : Form
    {
        public Example3()
        {
            InitializeComponent();

            angularGauge1.Value = 160;
            angularGauge1.FromValue = 50;
            angularGauge1.ToValue = 250;
            angularGauge1.TicksForeground = System.Windows.Media.Brushes.White;
            angularGauge1.Base.Foreground = System.Windows.Media.Brushes.White;
            angularGauge1.Base.FontWeight = FontWeights.Bold;
            angularGauge1.Base.FontSize = 16;
            angularGauge1.SectionsInnerRadius = 0.5;

            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 50,
                ToValue = 200,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 200,
                ToValue = 250,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            angularGauge1.Value = (new Random()).NextDouble() * 250;
        }
    }
}
