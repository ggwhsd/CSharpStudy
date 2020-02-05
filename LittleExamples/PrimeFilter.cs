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
    public partial class PrimeFilter : Form
    {
        public PrimeFilter()
        {
            InitializeComponent();
        }

        private void textBox_Number_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_Number.Text == "")
            {
                return;
            }

            int Number = 0;

            try
            {
                Number = Int32.Parse(this.textBox_Number.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

            int N = Number;
            bool[] a = new bool[N + 1];
            for (int i = 2; i <= N; i++)
            {
                a[i] = true;
            }
            //利用倍数关系来计算，如果是倍数，则不可能是素数，起始2倍，后续每次增加1倍
            for (int i = 2; i < N; i++)
            {
                for (int j = i * 2; j < N; j += i)
                {
                    a[j] = false;  
                }
            }
            StringBuilder str = new StringBuilder();
            for (int i = 2; i <= N; i++)
            {
                if (a[i])
                    str.Append(i + " ");
            }
            this.txtBox_results.Text = str.ToString();
        }
    }
}
