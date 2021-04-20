using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace LiveChartsTest
{
    public partial class Example4 : Form
    {
        public Example4()
        {
            InitializeComponent();
        }

        private void Example4_Load(object sender, EventArgs e)
        {
            //360 mode enabled
            solidGauge1.Uses360Mode = true;
            solidGauge1.From = 0;
            solidGauge1.To = 100;
            solidGauge1.Value = 50;
            solidGauge1.LabelFormatter = (value) => string.Format("{0:f2}", value);

            //rotated 90° and has an inverted clockwise fill
            solidGauge2.Uses360Mode = true;
            solidGauge2.From = 0;
            solidGauge2.To = 100;
            solidGauge2.Value = 50;
            solidGauge2.Base.GaugeRenderTransform = new TransformGroup
            {
                Children = new TransformCollection
                {
                    new RotateTransform(90),
                    new ScaleTransform {ScaleX = -1}
                }
            };
            solidGauge2.LabelFormatter = (value) => string.Format("{0:f2}", value);

            solidGauge3.Uses360Mode = true;
            solidGauge3.From = 0;
            solidGauge3.To = 100;
            solidGauge3.Value = 20;
            solidGauge3.HighFontSize = 60;
            solidGauge3.Base.Foreground = System.Windows.Media.Brushes.White;
            solidGauge3.InnerRadius = 0;
            solidGauge3.GaugeBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(71, 128, 181));
            solidGauge3.LabelFormatter = (value) => string.Format("{0:f2}", value);
            //the next gauge interpolates from color white, to color black according
            //to the current value in the gauge
            solidGauge4.Uses360Mode = true;
            solidGauge4.From = 0;
            solidGauge4.To = 100;
            solidGauge4.Value = 50;
            solidGauge4.HighFontSize = 60;
            solidGauge4.Base.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(66, 66, 66));
            solidGauge4.FromColor = Colors.White;
            solidGauge4.ToColor = Colors.Black;
            solidGauge4.InnerRadius = 0;
            solidGauge4.Base.Background = System.Windows.Media.Brushes.Transparent;
            solidGauge4.LabelFormatter = (value) => string.Format("{0:f2}", value);
            //standard gauge
            solidGauge5.From = 0;
            solidGauge5.To = 100;
            solidGauge5.Value = 50;
            solidGauge5.LabelFormatter = (value) => string.Format("{0:f2}", value);
            //custom fill
            solidGauge6.From = 0;
            solidGauge6.To = 100;
            solidGauge6.Value = 50;
            solidGauge6.Base.LabelsVisibility = System.Windows.Visibility.Hidden;
            solidGauge6.Base.GaugeActiveFill = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Colors.Yellow, 0),
                    new GradientStop(Colors.Orange, .5),
                    new GradientStop(Colors.Red, 1)
                }
            };
            solidGauge6.LabelFormatter = (value) => string.Format("{0:f2}", value);
        }

        Random rand = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            solidGauge1.Value = (rand.NextDouble() * solidGauge1.To);
            solidGauge2.Value = (rand.NextDouble() * solidGauge2.To);
            solidGauge3.Value = (rand.NextDouble() * solidGauge3.To);
            solidGauge4.Value = (rand.NextDouble() * solidGauge4.To);
            solidGauge5.Value = (rand.NextDouble() * solidGauge5.To);
            solidGauge6.Value = (rand.NextDouble() * solidGauge6.To);
        }
    }
}
