﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Equation;

namespace WindowsFormsApp1
{
    public partial class AxisControl : UserControl
    {
        public AxisControl()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private Graphics g;

        private Axis _AxisX = new Axis() { XName = "x轴" };
        /// <summary>
        /// X轴
        /// </summary>
        public Axis AxisX { get { return this._AxisX; } }

        private Axis _AxisY = new Axis() { XName = "y轴" };
        /// <summary>
        /// Y轴
        /// </summary>
        public Axis AxisY { get { return this._AxisY; } }


        /// <summary>
        /// 边界留空白
        /// </summary>
        private int bound = 10;

        public int Bound
        {
            get { return bound; }
            set { bound = value; }
        }

        /// <summary>
        /// 表示单位，30个像素表示1
        /// </summary>
        private int unit = 30;

        public int Unit
        {
            get { return unit; }
            set { unit = value;  }
        }

        /// <summary>
        /// 文本字体
        /// </summary>
        private Font t_Font = new Font("Arial", 10F);

        /// <summary>
        /// 中心点
        /// </summary>
        private PointF center;

        private int index = 0;

        /// <summary>
        /// 线的宽度
        /// </summary>
        private int lineWidth = 2;

        /// <summary>
        /// 计算绘制坐标轴的点
        /// </summary>
        private void InitInfo()
        {
            //绘制坐标轴
            var width = this.Width * 1.0f;
            var height = this.Height * 1.0f;
            center = new PointF(width / 2, height / 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            InitInfo();
            //获取画图
            Graphics g = e.Graphics;
            var width = this.Width * 1.0f;
            var height = this.Height * 1.0f;
            //创建画笔
            Pen pen = new Pen(Color.Black);
            //计算横坐标轴的左右两点
            var left = new PointF(bound, center.Y);
            var right = new PointF(width - bound, center.Y);
            //计算纵坐标轴的左右两点
            var bottom = new PointF(center.X, height - bound);
            var top = new PointF(center.X, bound);
            //中心点为0
            g.DrawString("0", t_Font, Brushes.Black, new PointF(center.X + bound / 2, center.Y + bound / 2));
            //画X轴,X轴的箭头
            g.DrawLine(pen, left, right);
            //箭头上半部分
            g.DrawLine(pen, new PointF(right.X - bound / 2, right.Y - bound / 2), right);
            //箭头下半部分
            g.DrawLine(pen, new PointF(right.X - bound / 2, right.Y + bound / 2), right);
            //绘制x轴的说明
            var xName = string.IsNullOrEmpty(this._AxisX.XName) ? "x" : this._AxisX.XName;
            g.DrawString(xName, t_Font, Brushes.Black, new PointF(right.X - (xName.Length) *bound, right.Y + 2 * bound));

            //绘制X轴的刻度
            var xMax = Math.Floor((right.X - left.X) / (2 * unit));
            this._AxisX.Max = int.Parse(xMax.ToString());

            int keDuDisplay = 30 / unit;
            for (var i = 0; i < xMax; i++)
            {
                //正刻度，刻度线的高度为2
                g.DrawLine(pen, new PointF(center.X + (i + 1) * unit, center.Y), new PointF(center.X + (i + 1) * unit, center.Y - 2));
                if(i%keDuDisplay==keDuDisplay-1)
                    g.DrawString((i + 1).ToString(), t_Font, Brushes.Black, new PointF(center.X + (i + 1) * unit, center.Y + 2));
                //负刻度，刻度线的高度为2
                g.DrawLine(pen, new PointF(center.X - (i + 1) * unit, center.Y), new PointF(center.X - (i + 1) * unit, center.Y - 2));
                if (i % keDuDisplay == keDuDisplay - 1)
                    g.DrawString("-" + (i + 1).ToString(), t_Font, Brushes.Black, new PointF(center.X - (i + 1) * unit, center.Y + 2));
            }
            //画Y轴，Y轴的箭头
            g.DrawLine(pen, bottom, top);
            g.DrawLine(pen, new PointF(top.X - bound / 2, top.Y + bound / 2), top);
            g.DrawLine(pen, new PointF(top.X + bound / 2, top.Y + bound / 2), top);
            var yName = string.IsNullOrEmpty(_AxisY.XName) ? "y" : _AxisY.XName;
            g.DrawString(AxisY.XName, t_Font, Brushes.Black, new PointF(top.X + 2 * bound, top.Y - bound));
            //绘制Y轴的刻度
            var yMax = Math.Floor((bottom.Y - top.Y) / (2 * unit));//
            this._AxisY.Max = int.Parse(yMax.ToString());
            for (var i = 0; i < yMax; i++)
            {
                //正刻度
                g.DrawLine(pen, new PointF(center.X, center.Y - (i + 1) * unit), new PointF(center.X + 2, center.Y - (i + 1) * unit));
                if (i % keDuDisplay == keDuDisplay - 1)
                    g.DrawString((i + 1).ToString(), t_Font, Brushes.Black, new PointF(center.X + 2, center.Y - (i + 1) * unit));
                //负刻度
                g.DrawLine(pen, new PointF(center.X, center.Y + (i + 1) * unit), new PointF(center.X + 2, center.Y + (i + 1) * unit));
                if (i % keDuDisplay == keDuDisplay - 1)
                    g.DrawString("-" + (i + 1).ToString(), t_Font, Brushes.Black, new PointF(center.X + 2, center.Y + (i + 1) * unit));
            }
        }

        /// <summary>
        /// 清除已经画上去的线条
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            this.Refresh();//重新刷新界面，清除已经画上去的线条
            index = 0;
            return true;
        }

        /// <summary>
        /// 判断点是否在坐标轴范围内
        /// </summary>
        /// <returns></returns>
        public bool CheckPointIsValid(PointF point)
        {
            bool flagX = false;
            bool flagY = false;
            if (point.X <= this._AxisX.Max && point.X >= 0 - this._AxisX.Max)
            {
                flagX = true;
            }
            if (point.Y <= this._AxisY.Max && point.Y >= 0 - this._AxisY.Max)
            {
                flagY = true;
            }
            return flagX && flagY;
        }
        /// <summary>
        /// 转换刻度到像素
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public PointF ConvertScaleToPixls(PointF s)
        {
            return new PointF(center.X + s.X * unit, center.Y - s.Y * unit);
        }
        public List<PointF> ConvertScaleToPixls(List<PointF> lstScale)
        {
            List<PointF> lstPixls = new List<PointF>();
            if (lstScale != null && lstScale.Count > 0)
            {
                var p = lstScale.Select(s => new PointF(center.X + s.X * unit, center.Y - s.Y * unit));
                lstPixls = p.ToList();
            }
            return lstPixls;
        }


        private List<PointF> exist_points = new List<PointF>();
        /// <summary>
        /// 生成点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool GeneratePoint(PointF point)
        {

            

            Graphics g = this.CreateGraphics();
            PointF p = ConvertScaleToPixls(point);

            exist_points.Add(p);

            g.FillEllipse(Brushes.Red, p.X, p.Y, 4, 4);
            g.DrawString(string.Format("P{0}", index), t_Font, Brushes.Black, new PointF(p.X + 4, p.Y - 4));
            this.label1.Text += string.Format("P{0}:({1},{2}) ; ", index, point.X, point.Y);
            index++;
            return true;
        }

        /// <summary>
        /// 生成点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool GeneratePointSimple(List<PointF> points, Brush rush)
        {

            using (Graphics g = this.CreateGraphics()) {
                
                foreach (var point in points)
                {
                    PointF p = ConvertScaleToPixls(point);

                    g.FillEllipse(rush, p.X, p.Y, 4, 4);
                }
                return true;
            }
        }


        private Bitmap map1;
        private Graphics g1;
        /// <summary>
        /// 生成点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool GeneratePointSimpleHighEffective(List<PointF> points, Brush rush)
        {
            
            using (Graphics g = this.CreateGraphics())
            {
                if (map1 == null)
                {
                    map1 = new Bitmap(this.Width, this.Height);
                    g1 = Graphics.FromImage(map1);
                }
                else
                {
                    if (map1.Width == this.Width && map1.Height == this.Height)
                    {

                    }
                    else
                    {
                        map1 = new Bitmap(this.Width, this.Height);
                        g1 = Graphics.FromImage(map1);
                    }
                }
                

                foreach (var point in points)
                {
                    PointF p = ConvertScaleToPixls(point);

                    g1.FillEllipse(rush, p.X, p.Y, 4, 4);
                }
                g.DrawImage(map1, 0, 0);
                return true;
            }
        }


        /// <summary>
        /// 判断直线方程是否在坐标轴范围内
        /// </summary>
        /// <param name="linear"></param>
        /// <returns></returns>
        public bool CheckLineIsValid(LinearEquation linear)
        {
            bool flagX = false;
            bool flagY = false;
            var y = linear.GetValueFromX(0f);

            //判断y坐标的值有没有越界
            if (y == float.MaxValue)
            {
                //表示是垂直于x轴的直线
                var x0 = -linear.C * 1.0f / linear.A;
                if (x0 >= 0 - this._AxisX.Max && x0 < this._AxisX.Max)
                {
                    flagY = true;
                }
                else
                {
                    flagY = false;
                }

            }
            else
            {
                if (y <= this._AxisY.Max && y >= 0 - this._AxisY.Max)
                {
                    flagY = true;
                }
                else
                {
                    flagY = false;
                }
            }
            //判断x坐标的值
            var x = linear.GetValueFromY(0f);
            if (x == float.MaxValue)
            {
                var y0 = -linear.C * 1.0f / linear.B;

                if (y0 <= this._AxisY.Max && y0 >= 0 - this._AxisY.Max)
                {
                    flagX = true;
                }
                else
                {
                    flagX = false;
                }
            }
            else
            {
                if (x <= this._AxisX.Max && x >= 0 - this._AxisX.Max)
                {
                    flagX = true;
                }
                else
                {
                    flagX = false;
                }
            }

            return flagX && flagY;//只有x,y都满足条件，才是有效的
        }

        public List<PointF> GetLinerPointsFromLinearEquation(LinearEquation linear)
        {
            var x1 = this._AxisX.Max;
            var y2 = this._AxisY.Max;
            var x3 = 0 - this._AxisX.Max;
            var y4 = 0 - this._AxisY.Max;

            List<PointF> lstTmp = new List<PointF>();
            int x = 0;
            while (x < x1)
            {
                lstTmp.Add( new PointF(x,linear.GetValueFromX(x)));
                x+=1;
            }
            return lstTmp;
        }
        public List<PointF> GetAllPointsFromAxis()
        {
            var x1 = this._AxisX.Max;
            var y2 = this._AxisY.Max;
            var x3 = 0 - this._AxisX.Max;
            var y4 = 0 - this._AxisY.Max;

            List<PointF> lstTmp = new List<PointF>();
            int x = 0;
            int y = 0;
            while (x < x1)
            {
                while (y < y2)
                {
                    lstTmp.Add(new PointF(x, y));
                    y+=1;
                }
                y = 0;
                x += 1;
            }
            return lstTmp;
        }

        public bool GenerateLinear(LinearEquation linear)
        {

            Color lineColor = Color.Blue;//线条的颜色
            Graphics g = this.CreateGraphics();
            //分别获取两个端点的值，连成线即可
            var x1 = this._AxisX.Max;
            var y2 = this._AxisY.Max;
            var x3 = 0 - this._AxisX.Max;
            var y4 = 0 - this._AxisY.Max;
            var y1 = linear.GetValueFromX(x1);
            var x2 = linear.GetValueFromY(y2);
            var y3 = linear.GetValueFromX(x3);
            var x4 = linear.GetValueFromY(y4);
            var point1 = new PointF(x1, y1);
            var point2 = new PointF(x2, y2);
            var point3 = new PointF(x3, y3);
            var point4 = new PointF(x4, y4);
            List<PointF> lstTmp = new List<PointF>() { point1, point2, point3, point4 };
            List<PointF> lstPoint = new List<PointF>();
            foreach (PointF point in lstTmp)
            {
                //判断点是否合理
                if (CheckPointIsValid(point))
                {
                    lstPoint.Add(point);
                }
            }
            if (lstPoint.Count() < 2)
            {
                //如果点的个数小于2，不能绘制直线
                return false;
            }
            //将刻度点，转换成像素点
            List<PointF> lstPixlsPoint = ConvertScaleToPixls(lstPoint);
            g.DrawLine(new Pen(lineColor, lineWidth), lstPixlsPoint[0], lstPixlsPoint[1]);
            g.DrawString(string.Format("L{0}", index), t_Font, Brushes.Black, new PointF(lstPixlsPoint[1].X + 2, lstPixlsPoint[1].Y - 2));
            this.label1.Text += string.Format("L{0}:{1}x+{2}y+{3}=0 ; ", index, linear.A, linear.B, linear.C);
            index++;
            return true;
        }


        /// <summary>
        /// 检查抛物线方程是否有效
        /// </summary>
        /// <param name="parabolic"></param>
        /// <returns></returns>
        public bool CheckParabolicIsValid(ParabolicEquation parabolic)
        {
            List<PointF> lstPoint = GetPointFromEquation(parabolic);
            if (lstPoint.Count > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 从抛物线方程中取点值
        /// </summary>
        /// <param name="parabolic"></param>
        /// <returns></returns>
        public List<PointF> GetPointFromEquation(ParabolicEquation parabolic)
        {
            List<PointF> lstPoint = new List<PointF>();
            //从坐标轴最小值开始，隔0.5 取一个
            int j = 0;
            for (float i = 0 - this._AxisX.Max; i <= this._AxisX.Max; i = i + 0.5f)
            {
                PointF p = new PointF(i, parabolic.GetValueFromX(i));
                //再判断点是否在坐标轴内
                if (CheckPointIsValid(p) && (j == 0 || lstPoint[j - 1].X == i - 0.5f))
                {
                    lstPoint.Add(p);//抛物线内的点应该是连续的
                    j++;
                }
            }
            return lstPoint;
        }

        public bool GenerateParabolic(ParabolicEquation parabolic)
        {
            List<PointF> lstPoint = GetPointFromEquation(parabolic);
            //将刻度点，转换成像素点
            List<PointF> lstPixlsPoint = ConvertScaleToPixls(lstPoint);
            Color lineColor = Color.SeaGreen;//线条的颜色
            Graphics g = this.CreateGraphics();
            g.DrawCurve(new Pen(lineColor, lineWidth), lstPixlsPoint.ToArray());
            g.DrawString(string.Format("P{0}", index), t_Font, Brushes.Black, new PointF(lstPixlsPoint[1].X + 2, lstPixlsPoint[1].Y - 2));
            this.label1.Text += string.Format("P{0}:y={1}x2+{2}x+{3} ; ", index, parabolic.A, parabolic.B, parabolic.C);
            index++;
            return true;
        }

        /// <summary>
        /// 绘画多边形
        /// </summary>
        /// <param name="lstPoints"></param>
        /// <returns></returns>
        public bool GeneratePolygon(List<PointF> lstPoints, bool isOriginal = true)
        {

            Color lineColor = Color.Red;//线条的颜色
            if (isOriginal)
            {
                lineColor = Color.Red;
            }
            else
            {
                lineColor = Color.Blue;
            }

            Graphics g = this.CreateGraphics();
            //画点
            foreach (var p in lstPoints)
            {
                this.GeneratePoint(p);
            }
            //将刻度点，转换成像素点
            List<PointF> lstPixlsPoint = ConvertScaleToPixls(lstPoints);
            //绘制多边形
            g.DrawPolygon(new Pen(lineColor, 2), lstPixlsPoint.ToArray());
            return true;
        }


        /// <summary>
        /// 放大多边形
        /// </summary>
        /// <param name="lstPoints">多边形的多个原始坐标点</param>
        /// <param name="center">用0</param>
        /// <param name="distance">放大多少</param>
        /// <returns></returns>
        public bool GenerateExpandPolygon(List<PointF> lstPoints, PointF center, float distance)
        {
            //1.求多边形对应的外扩平行斜线
            List<LinearEquation> lstLines = new List<LinearEquation>();
            int len = lstPoints.Count();
            for (int i = 0; i < len; i++)
            {
                var p0 = lstPoints[i];//第i个元素
                var p1 = lstPoints[(i + 1) % len];//第i+1个元素
                LinearEquation linearEquation = new LinearEquation();
                if (p0.X == p1.X)
                {
                    //垂直于x轴，没有斜率
                    linearEquation.A = 1;
                    linearEquation.B = 0;
                    if (p0.X > center.X)
                    {
                        linearEquation.C = -(p0.X + distance);
                    }
                    else
                    {
                        linearEquation.C = -(p0.X - distance);
                    }

                }
                else if (p0.Y == p1.Y)
                {
                    //垂直于y轴，斜率为0
                    linearEquation.A = 0;
                    linearEquation.B = 1;
                    if (p0.Y > center.Y)
                    {
                        linearEquation.C = -(p0.Y + distance);
                    }
                    else
                    {
                        linearEquation.C = -(p0.Y - distance);
                    }
                }
                else
                {
                    //先求两点对应的点斜式方程y=kx+b
                    float k = (p0.Y - p1.Y) / (p0.X - p1.X);
                    float b = p0.Y - k * p0.X;
                    //求出平行线对应的b即可。
                    float b_center = center.Y - k * center.X;
                    linearEquation.A = k;
                    linearEquation.B = -1;//如果此处为-1,则C=b

                    if (b > b_center)
                    {
                        //如果在原点上方

                        linearEquation.C = (b + (float)Math.Abs((distance / (Math.Sin(-Math.PI / 2 - Math.Atan(k))))));
                    }
                    else
                    {
                        //如果在原点下方
                        linearEquation.C = (b - (float)Math.Abs((distance / (Math.Sin(-Math.PI / 2 - Math.Atan(k))))));
                    }
                }
                //this.GenerateLinear(linearEquation);
                lstLines.Add(linearEquation);
            }
            List<PointF> lstNewPoints = new List<PointF>();
            //2.求相邻外扩平行斜线的交点
            for (int i = 0; i < len; i++)
            {
                var line0 = lstLines[i];
                var line1 = lstLines[(i + 1) % len];
                float x = 0.0f;
                float y = 0.0f;
                if (line0.A == 0.0f)
                {
                    y = -line0.C / line0.B;
                    x = line1.GetValueFromY(y);
                }
                else if (line0.B == 0.0f)
                {
                    x = -line0.C / line0.A;
                    y = line1.GetValueFromX(x);
                }
                else if (line1.A == 0.0f)
                {
                    y = -line1.C / line1.B;
                    x = line0.GetValueFromY(y);
                }
                else if (line1.B == 0.0f)
                {
                    x = -line1.C / line1.A;
                    y = line0.GetValueFromX(x);
                }
                else
                {
                    //两个都有斜率的直线的交点
                    float k0 = -line0.A / line0.B;
                    float k1 = -line1.A / line1.B;
                    float b0 = -line0.C / line0.B;
                    float b1 = -line1.C / line1.B;
                    x = (b1 - b0) / (k0 - k1);
                    y = line0.GetValueFromX(x);
                }
                lstNewPoints.Add(new PointF(x, y));
            }
            this.GeneratePolygon(lstNewPoints, false);
            //
            return true;
        }

        private void AxisControl_MouseMove(object sender, MouseEventArgs e)
        {

            this.label2.Text = e.Location.ToString();
            List<PointF> clearP = new List<PointF>();
            foreach (var p in exist_points)
            {
                if (Math.Sqrt((p.X - e.X) * (p.X - e.X) + (p.Y - e.Y) * (p.Y - e.Y)) < 5)
                {
                    Console.WriteLine("距离很近:" + e.Location.ToString() + " ----> " + p.ToString());

                    var g1 = button1.CreateGraphics();
                    g1.Clear(Color.Blue);
                    g1.FillEllipse(Brushes.DarkOliveGreen, button1.Width/2, button1.Height/2, 8, 8);
                    g1.DrawString( e.Location.ToString(), t_Font, Brushes.Red, new PointF( 4,4));
                    clearP.Add(p);
                }
            }

            foreach (var p in clearP)
            {
                exist_points.Remove(p);
            }

            
        }

        public void MoveButton(PointF point)
        {
            PointF real = ConvertScaleToPixls(point);
            button1.Location = new Point((int)real.X, (int)real.Y);
        }

      
    }

    /// <summary>
    /// 坐标轴描述
    /// </summary>
    public class Axis
    {

        /// <summary>
        /// 刻度表示最大值
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string XName { get; set; }

        ///// <summary>
        ///// 间隔
        ///// </summary>
        //public int Interval{get;set;}
    }
}
