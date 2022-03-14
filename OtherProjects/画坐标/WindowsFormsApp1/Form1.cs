using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Equation;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axisControl1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.uC_Point1.IsValid())
            {
                float x = this.uC_Point1.X;
                float y = this.uC_Point1.Y;
                PointF point = new PointF(x, y);
                
                if (!this.axisControl1.CheckPointIsValid(point))
                {
                    MessageBox.Show("输入的点不在坐标轴内");
                    return;
                }
                bool flag = this.axisControl1.GeneratePoint(point);
                if (!flag)
                {
                    MessageBox.Show("生成点失败");
                    return;
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.uC_Line1.IsValid())
            {
                var a = this.uC_Line1.A;
                var b = this.uC_Line1.B;
                var c = this.uC_Line1.C;
                //判断方程的参数，是否有效
                LinearEquation linear = new LinearEquation() { A = a, B = b, C = c };
                if (!linear.IsValid())
                {
                    MessageBox.Show("输入的方程参数无效");
                    return;
                }
                if (!this.axisControl1.CheckLineIsValid(linear))
                {
                    MessageBox.Show("输入的方程不在坐标轴内");
                    return;
                }
                bool flag = this.axisControl1.GenerateLinear(linear);
                if (!flag)
                {
                    MessageBox.Show("生成直线失败");
                    return;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.uC_Parabola1.IsValid())
            {
                var a = this.uC_Parabola1.A;
                var b = this.uC_Parabola1.B;
                var c = this.uC_Parabola1.C;
                //判断方程的参数，是否有效
                ParabolicEquation parabolic = new ParabolicEquation() { A = a, B = b, C = c };
                if (!parabolic.IsValid())
                {
                    MessageBox.Show("输入的方程参数无效");
                    return;
                }
                if (!this.axisControl1.CheckParabolicIsValid(parabolic))
                {
                    MessageBox.Show("输入的方程不在坐标轴内");
                    return;
                }
                bool flag = this.axisControl1.GenerateParabolic(parabolic);
                if (!flag)
                {
                    MessageBox.Show("生成抛物线失败");
                    return;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<PointF> lstPoints = new List<PointF>() {
                new PointF(1,2),
                new PointF(2,0),
                new PointF(1,-2),
                new PointF(-1,-2),
                new PointF(-2,0),
                new PointF(-1,2)
            };
            this.axisControl1.GeneratePolygon(lstPoints);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<PointF> lstPoints = new List<PointF>() {
                new PointF(1,2),
                new PointF(2,0),
                new PointF(1,-2),
                new PointF(-1,-2),
                new PointF(-2,0),
                new PointF(-1,2)
            };
            this.axisControl1.GenerateExpandPolygon(lstPoints,new PointF(0,0),1);
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (this.uC_Parabola1.IsValid())
            {
                var a = this.uC_Parabola1.A;
                var b = this.uC_Parabola1.B;
                var c = this.uC_Parabola1.C;
                //判断方程的参数，是否有效
                ParabolicEquation parabolic = new ParabolicEquation() { A = a, B = b, C = c };
                if (!parabolic.IsValid())
                {
                    MessageBox.Show("输入的方程参数无效");
                    return;
                }
                if (!this.axisControl1.CheckParabolicIsValid(parabolic))
                {
                    MessageBox.Show("输入的方程不在坐标轴内");
                    return;
                }
                List<PointF> lstPoints= this.axisControl1.GetPointFromEquation(parabolic);
                foreach (var ele in lstPoints)
                {

                    axisControl1.GeneratePoint(ele);
                    await Task.Delay(500);
                }

                

            }
        }

        private void axisControl1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.uC_Line1.IsValid())
            {
                var a = this.uC_Line1.A;
                var b = this.uC_Line1.B;
                var c = this.uC_Line1.C;
                //判断方程的参数，是否有效
                LinearEquation linear = new LinearEquation() { A = a, B = b, C = c };
                if (!linear.IsValid())
                {
                    MessageBox.Show("输入的方程参数无效");
                    return;
                }
                if (!this.axisControl1.CheckLineIsValid(linear))
                {
                    MessageBox.Show("输入的方程不在坐标轴内");
                    return;
                }

                List<PointF> lstPoints = this.axisControl1.GetLinerPointsFromLinearEquation(linear);
                foreach (var ele in lstPoints)
                {

                    axisControl1.GeneratePoint(ele);
                    
                }

            }
        }
        private Brush rush = Brushes.Red;
        private async void button9_Click(object sender, EventArgs e)
        {
            List<PointF> lstPoints = this.axisControl1.GetAllPointsFromAxis();

            await Task.Run(new Action( () => { axisControl1.GeneratePointSimple(lstPoints, rush); }));

            if (rush == Brushes.Red)
            {
                rush = Brushes.Green;
            }
            else {
                rush = Brushes.Red;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<PointF> lstPoints = this.axisControl1.GetAllPointsFromAxis();

            axisControl1.GeneratePointSimpleHighEffective(lstPoints, rush);

            if (rush == Brushes.Red)
            {
                rush = Brushes.Green;
            }
            else
            {
                rush = Brushes.Red;
            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            if (this.uC_Line1.IsValid())
            {
                var a = this.uC_Line1.A;
                var b = this.uC_Line1.B;
                var c = this.uC_Line1.C;
                //判断方程的参数，是否有效
                LinearEquation linear = new LinearEquation() { A = a, B = b, C = c };
                if (!linear.IsValid())
                {
                    MessageBox.Show("输入的方程参数无效");
                    return;
                }
                if (!this.axisControl1.CheckLineIsValid(linear))
                {
                    MessageBox.Show("输入的方程不在坐标轴内");
                    return;
                }
                int x = -axisControl1.AxisY.Max;
                List<PointF> lstPoints = new List<PointF>();
                while (x < axisControl1.AxisY.Max)
                {
                    float y = linear.GetValueFromX(x);
                    lstPoints.Add(new PointF(x,y));
                    x++;
                }

           

                foreach (var ele in lstPoints)
                {
                    
                    //axisControl1.GeneratePoint(ele);
                    axisControl1.MoveButton(ele);
                    await Task.Delay(30);
                }
            }
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            if (this.uC_Line1.IsValid())
            {
                var a = this.uC_Line1.A;
                var b = this.uC_Line1.B;
                var c = this.uC_Line1.C;
                //判断方程的参数，是否有效
                LinearEquation linear = new LinearEquation() { A = a, B = b, C = c };
                if (!linear.IsValid())
                {
                    MessageBox.Show("输入的方程参数无效");
                    return;
                }
                if (!this.axisControl1.CheckLineIsValid(linear))
                {
                    MessageBox.Show("输入的方程不在坐标轴内");
                    return;
                }
                int x = -axisControl1.AxisY.Max;
                List<PointF> lstPoints = new List<PointF>();

                int acc = 1;
                double t = 1;
                while (x < axisControl1.AxisY.Max)
                {
                    float y = linear.GetValueFromX(x);
                    lstPoints.Add(new PointF(x, y));
                    t += 1;
                    x = (int)(acc*t*t/2);
                }



                foreach (var ele in lstPoints)
                {

                    //axisControl1.GeneratePoint(ele);
                    axisControl1.MoveButton(ele);
                    await Task.Delay(30);
                }
            }
        }
    }
}
