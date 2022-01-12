using Microsoft.Edge.SeleniumTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsSelenium3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("PATH");
            if(path.Contains("edgedriver")==false)
                Environment.SetEnvironmentVariable("PATH", path + @"A:\edgedriver_win64");
            var options = new EdgeOptions();
            options.UseChromium = true;
            
            var driver = new EdgeDriver(options);
            
        }
    }
}
