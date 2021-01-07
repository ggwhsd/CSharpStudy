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
    public partial class GDI_line : Form
    {
        public GDI_line()
        {
            InitializeComponent();
        }
        private bool initial = true, startDraw;
        List<Point> pList = new List<Point>();

        private void GDI_line_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && startDraw)
            {
                pList.Add(e.Location);
                this.Refresh();
            }
        }

        private void GDI_line_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startDraw = false;

            }
        }
        Color[] list = new Color[6] { Color.Red, Color.Blue, Color.Yellow, Color.Green, Color.Gold, Color.Gray };
        private void GDI_line_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                initial = false;
                startDraw = true;
                pList.Add(e.Location);
                this.Refresh();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (initial)
            {
                return;
            }
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (pList.Count >= 2)
            {
                if (pList.Count > 6000)
                {
                    pList.RemoveRange(0, 30);
                }
                //Pen p = new Pen(list[(new Random()).Next(6)], 1)
                using (Pen p = new Pen(Color.Blue, 5))
                {
                    p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    p.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                    g.DrawCurve(p, pList.ToArray());
                }
            }
        }


    }
}
