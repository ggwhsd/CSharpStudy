using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HappyWpf
{
    /// <summary>
    /// StudyGraphic.xaml 的交互逻辑
    /// </summary>
    public partial class StudyGraphic : Window
    {
        public StudyGraphic()
        {
            InitializeComponent();
        }

        private void ClickableEllipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolidColorBrush scb = clickableEllipse.Fill as SolidColorBrush;
            if (scb.Color == Colors.Green)
                clickableEllipse.Fill = Brushes.Red;
            else
            {
                clickableEllipse.Fill = Brushes.Green;
            }

         

        }
    }
}
