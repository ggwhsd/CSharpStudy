﻿using System;
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
    /// StudyDataGrid.xaml 的交互逻辑
    /// </summary>
    public partial class StudyDataGrid : Window
    {
        private gridViewModelmain gvm;
        public StudyDataGrid()
        {
            gvm= new gridViewModelmain();
            gvm.Query();
            InitializeComponent();
            this.DataContext = gvm;
        }
    }
}
