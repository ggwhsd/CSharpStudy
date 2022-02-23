﻿using HappyWpf.ControlExample;
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

        private void btn_DockPanel_Click(object sender, RoutedEventArgs e)
        {
            StudyDockPanel sdp = new StudyDockPanel();
            sdp.Show();
        }

        private void btn_Canvas_Click(object sender, RoutedEventArgs e)
        {
            StudyCanvas sc = new StudyCanvas();
            sc.Show();
        }

        private void btn_Grid_Click(object sender, RoutedEventArgs e)
        {
            StudyGrid sg = new StudyGrid();
            sg.Show();
        }

        private void btn_StackPanel_Click(object sender, RoutedEventArgs e)
        {
            StudyStackpanel ssp = new StudyStackpanel();
            ssp.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            StudyWrapPanel swp = new StudyWrapPanel();
            swp.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            StudyBinding sb = new StudyBinding();
            sb.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            StudyGraphic sg = new StudyGraphic();
            sg.Show();
        }

        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {
            StudyImage si = new StudyImage();
            si.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            StudyView3D sv3D = new StudyView3D();
            sv3D.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            StudyAnimation sa = new StudyAnimation();
            sa.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            ControlExample.StudyGroupBox sgb = new ControlExample.StudyGroupBox();
            sgb.Show();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            StudyDataGrid sg = new StudyDataGrid();
            sg.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            StudyBinding1 sb1 = new StudyBinding1();
            sb1.Show();
        }
    }
}
