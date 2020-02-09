using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MarketRiskUI
{
    public partial class Parallel : Form
    {
        public Parallel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Action[] actions = { new Action(DoSometing), DoSometing };
            System.Threading.Tasks.Parallel.Invoke(actions);
            Console.WriteLine("主函数所在线程" + Thread.CurrentThread.ManagedThreadId);
        }
        void DoSometing()
        {
            Console.WriteLine("函数所在线程" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
