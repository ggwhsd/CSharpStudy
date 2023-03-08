using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDesignWinformExample1
{
    public partial class UCHome : UserControl
    {
        public UCHome()
        {
            InitializeComponent();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("UCNext"))
            {
                UCNext un = new UCNext();
                un.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(un);
            }
            Form1.Instance.PnlContainer.Controls["UCNext"].BringToFront();
            Form1.Instance.BackButton.Visible = true;

        }
    }
}
