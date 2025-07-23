using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class line
    {
        public Point p1;
        public Point p2;
        public line(int x, int y, int x2, int y2)
        {
            p1 = new Point(x, y);
            p2 = new Point(x2, y2);
        }
        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Blue, 3);
            g.DrawLine(p, p1.X, p1.Y, p2.X, p2.Y);
        }

        public void DrawSelect(Graphics g)
        {
            Pen p = new Pen(Color.Blue, 5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawEllipse(p, p1.X-1, p1.Y-1, 3, 3);
            g.DrawEllipse(p, p2.X-1, p2.Y-1, 3, 3);
        }

       

    }
}
