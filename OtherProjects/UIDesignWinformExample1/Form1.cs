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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static Form1 _obj;

        public static Form1 Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Form1();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { 
                return panel_pnlContainer; 
            }
            set { 
                panel_pnlContainer = value;
            }
        }

        public Button BackButton
        {
            get { 
                return btn_back; 
            }
            set { 
                btn_back = value; 
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btn_back.Visible = false;
            _obj = this;
            UCHome uc = new UCHome();
            uc.Dock = DockStyle.Fill;
            panel_pnlContainer.Controls.Add(uc);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            panel_pnlContainer.Controls["UCHome"].BringToFront();
            btn_back.Visible = false;

        }
    }
}
