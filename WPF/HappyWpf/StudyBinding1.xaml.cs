using HappyWpf.Entity;
using HappyWpf.MyViewModelBase;
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
    /// StudyBinding1.xaml 的交互逻辑
    /// </summary>
    public partial class StudyBinding1 : Window
    {
        
        public StudyBinding1()
        {
            data = new Bind1ModelView();
            InitializeComponent();

            this.DataContext = data;
        }
        private Bind1ModelView data;

       


        
    }
}
