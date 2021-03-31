using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class TaskAsyncForm : Form
    {
        public TaskAsyncForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaskAsyncDemo t = new TaskAsyncDemo();
            t.TestOne();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaskAsyncDemo t = new TaskAsyncDemo();
            t.TestWithContinue();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TaskAsyncDemo t = new TaskAsyncDemo();
            t.TestWhen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaskAsyncDemo t = new TaskAsyncDemo();
            t.Testpallral();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TaskAsyncDemo t = new TaskAsyncDemo();
            t.Testpallral2();
        }
    }
}
