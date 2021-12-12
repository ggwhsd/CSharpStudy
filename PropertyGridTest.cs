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
    public partial class PropertyGridTest : Form
    {
        public PropertyGridTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = button1;
        }
        Person p = new Person();
        private void button2_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = p;
        }
    }

    class Person
    {
        [Browsable(true), Description("身份识别"), Category("Layout")]
        public int ID { get; set; }
        [Browsable(true), Description("坐标"), Category("Layout")]
        public Point Location { get; set; }
    }
}
