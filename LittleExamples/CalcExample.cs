using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI.LittleExamples
{
    public partial class CalcExample : Form
    {


        Double dblAcc;
        Double dblSec;
        bool blnClear, blnFrstOpen;
        String strOper;

        private void btn_Oper(object sender, EventArgs e)
        {
            Button tmp = (Button)sender;
            strOper = tmp.Text;
            if (blnFrstOpen)
                dblAcc = dblSec;
            else
                calc();
            blnFrstOpen = false;
            blnClear = true;
        }

        private void bDot_Click(object sender, EventArgs e)
        {
            if (blnClear)
                txtCalc.Text = "";
            Button b3 = sender as Button;
            txtCalc.Text += b3.Text;
            if (txtCalc.Text == ".")
                txtCalc.Text = "0.";
            dblSec = Convert.ToDouble(txtCalc.Text);
            blnClear = false;
        }

        private void bEqu_Click(object sender, EventArgs e)
        {
            calc();
        }

        private void calc()
        {
            switch (strOper)
            {
                case "+":
                    dblAcc += dblSec; //加号运算
                    break;
                case "-":
                    dblAcc -= dblSec; //减号运算
                    break;
                case "*":
                    dblAcc *= dblSec; //乘号运算
                    break;
                case "/":
                    dblAcc /= dblSec; //除号运算
                    break;
            }
            strOper = "="; //等号运算
            blnFrstOpen = true;
            txtCalc.Text = Convert.ToString(dblAcc);//将运算结果转换成字符类型,并输出
            dblSec = dblAcc;//将运算数A的值放入运算数B中,以便后面运算
        }

        private void bClr_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            dblAcc = 0;
            dblSec = 0;
            blnFrstOpen = true;
            txtCalc.Text = "";
            txtCalc.Focus();//设置焦点为txtCalc
        }

        public CalcExample()
        {
            InitializeComponent();
            dblAcc = 0;
            dblSec = 0;
            blnFrstOpen = true;
            blnClear = true;
            strOper = new string('=', 1);
        }
    }
}
