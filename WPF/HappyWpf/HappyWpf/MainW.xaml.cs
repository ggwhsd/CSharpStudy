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
    /// MainW.xaml 的交互逻辑
    /// </summary>
    public partial class MainW : Window
    {
        public MainW()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PathAndButton pab = new PathAndButton();
            pab.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();
        }
    }
}
