using HappyWpf.Entity;
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
    /// StudyBinding.xaml 的交互逻辑
    /// </summary>
    public partial class StudyBinding : Window
    {
        public StudyBinding()
        {
            //创建数据源，这里是一个类对象
            person = new Person();

            person.Name = "已改，当前时间为" + DateTime.Now.ToString();
            InitializeComponent();
            //设置窗口的数据源绑定对象，这样在窗口中获取Name属性，则就是person的Name属性了。 这种方式只能单向绑定，即数据到UI。
            this.DataContext = person;


        }
        Person person;
        private void PersonNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(person?.Name);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            person.Name = "已改，当前时间为" + DateTime.Now.ToString();
            
        }
    }
}
