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
    /// PathAndButton.xaml 的交互逻辑
    /// </summary>
    public partial class PathAndButton : Window
    {
        public PathAndButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            PathGeometry pg = path_data3.Data as PathGeometry;
            PathFigure pf = pg.Figures[0] as PathFigure;

            Console.WriteLine(((LineSegment)pf.Segments[0]).Point);
            LineSegment ls = (LineSegment)pf.Segments[0];
            ls.Point = new Point(ls.Point.X + 1, ls.Point.Y + 1);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Task.Run(async () => {
                bool isReturn = false;
                while (true)
                {
                    await Task.Delay(1000);
                    userControl1.Dispatcher.Invoke(() => { userControl1.Add(); if (userControl1.pBar.Value >= 99) { isReturn = true; } });
                    if (isReturn)
                        break;
                }
            });



        }
    }
}
