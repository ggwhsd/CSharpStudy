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

namespace HappyWpf.ControlExample
{
    /// <summary>
    /// StudyListBox.xaml 的交互逻辑
    /// </summary>
    public partial class StudyListBox : Window
    {
        public StudyListBox()
        {
            InitializeComponent();

            ColorList.Add(new Color() { Code = "#FF8C00" });
            ColorList.Add(new Color() { Code = "#FF7F50" });
            ColorList.Add(new Color() { Code = "#FF6EB4" });
            ColorList.Add(new Color() { Code = "#FF4500" });
            ColorList.Add(new Color() { Code = "#FF3030" });
            ColorList.Add(new Color() { Code = "#CD5B45" });

            cob.ItemsSource = ColorList;
            lib.ItemsSource = ColorList;


            ic.ItemsSource = ColorList;
        }

        private List<Color> ColorList = new List<Color>();

    }

    public class Color
    {
        public string Code { get; set; }
    }
}
