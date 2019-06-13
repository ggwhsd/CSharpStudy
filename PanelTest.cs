using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class PanelTest : Form
    {
        public PanelTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Location = new Point(panel1.Location.X + 100, panel1.Location.Y + 100);
        }

        Point mouseButton;
        bool leftFlag;//标签是否为左键
        int i = 0;
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {


                //mouseOff = new Point(-e.X, -e.Y); //得到鼠标相对于按钮控件的位置，mouseOff此时的偏移量实际上时按钮的左上角位置;
                mouseButton = ((Button)sender).Location;
                mouseButton.Offset(-e.X, -e.Y); //按钮时相对于窗口程序的位置，而鼠标时相对于按钮的位置，所以要减去，以便后面直接可以加上鼠标的移动位置
                textBox2.AppendText( "屏幕坐标"+ Form.MousePosition+"\r\n");
                textBox2.AppendText(((Button)sender).Name + "被鼠标左键按下了" + "\r\n");
                textBox2.AppendText(((Button)sender).Name + " 鼠标坐标" + e.X +","+e.Y+ "\r\n");
                textBox2.AppendText(((Button)sender).Name + " 自身坐标" + ((Button)sender).Location.ToString() +"\r\n");
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        Point mouseSet;
        private void button2_MouseMove(object sender, MouseEventArgs e)
        {

            if (leftFlag&& e.Button == MouseButtons.Left)
            {
                textBox2.AppendText(((Button)sender).Name + "被鼠标左键按下并移动了" + i++ + "\r\n");
                //Point mouseSet = Control.MousePosition;
                mouseSet = e.Location;
                textBox2.AppendText(((Button)sender).Name + " 鼠标坐标" + e.Location + "\r\n");

                mouseSet.Offset(mouseButton.X, mouseButton.Y);  //设置移动后的位置
                
            }
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                ((Button)sender).Location = mouseSet;
                leftFlag = false;//释放鼠标后标注为false;
            }
        }
    }
}
