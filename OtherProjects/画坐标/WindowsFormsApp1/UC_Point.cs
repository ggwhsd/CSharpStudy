using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UC_Point : UserControl
    {
        public UC_Point()
        {
            InitializeComponent();
        }

        public float X
        {
            get
            {
                return float.Parse(this.txtPointX.Text);
            }
        }

        public float Y
        {
            get
            {
                return float.Parse(this.txtPointY.Text);
            }
        }

        private void txtPointX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }
        }

        private void txtPointY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(this.txtPointX.Text.Trim()) || string.IsNullOrEmpty(this.txtPointY.Text.Trim()))
            {
                MessageBox.Show("坐标参数不能为空");
                return false;
            }
            return true;
        }
    }
}
