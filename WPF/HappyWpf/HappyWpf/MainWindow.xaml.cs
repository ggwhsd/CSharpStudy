using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HappyWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Human h = this.FindResource("human") as Human;
            if (h != null)
            {
                MessageBox.Show(h.Child.Name);
            }
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();
        }
    }
    [TypeConverterAttribute(typeof(nameToHumanConverter))]
    public class Human
    {
        public string Name { get; set; }
        public Human Child { get; set; }  //这种类型，只能通过重写TypeConverter和特性方式使用。

    }

    public class nameToHumanConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string name = value.ToString();
            Human child = new Human();
            child.Name = name;
            return child;
            
        }
    }
}
