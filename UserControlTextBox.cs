using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace UItest
{
    public partial class UserControlTextBox : UserControl
    {
        public UserControlTextBox()
        {
            InitializeComponent();
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            
            GraphicsPath gp = new GraphicsPath();
            DrawRoundRect(gp, textBox1.Location.X-10, textBox1.Location.Y-10, textBox1.Width+20, textBox1.Height+20, 10);
            g.DrawPath(new Pen(Color.White, 2), gp);
            gp.Dispose();
            g.Dispose();
        }
        private void DrawRoundRect(GraphicsPath gp, int X, int Y, int width, int height, int radius)
        {
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);

            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);

            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
        }

        private void textBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Color c = Color.FromName(textBox1.Text);
                
                    this.BackColor = c;

                    textBox1.BackColor = this.BackColor;
                
            }
            catch(Exception err)
            {
                textBox1.BackColor = Color.White;
            }
        }
    }
}
