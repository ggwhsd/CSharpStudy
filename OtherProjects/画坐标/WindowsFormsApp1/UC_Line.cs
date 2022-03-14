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
    public partial class UC_Line : UserControl
    {
        public UC_Line()
        {
            InitializeComponent();
        }

        public int A
        {
            get
            {
                return int.Parse(this.txtA.Text);
            }
        }

        public int B
        {
            get
            {
                return int.Parse(this.txtB.Text);
            }
        }

        public int C
        {
            get
            {
                return int.Parse(txtC.Text);
            }
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
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
            if (string.IsNullOrEmpty(this.txtA.Text.Trim()) || string.IsNullOrEmpty(this.txtB.Text.Trim()) || string.IsNullOrEmpty(this.txtC.Text.Trim()))
            {
                MessageBox.Show("直线方程参数不能为空");
                return false;
            }
            return true;
        }
    }
}
