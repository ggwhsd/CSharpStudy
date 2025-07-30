using ScottPlot;
using ScottPlot.Colormaps;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottplotTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        private Scatter scatter;
        private void button1_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            //解决中文乱码
            formsPlot1.Plot.Font.Automatic();
            double[] xs = Enumerable.Range(0, 50).Select(i => i * 0.1).ToArray();
            double[] ys = xs.Select(x => Math.Sin(x)).ToArray();
            var plt =formsPlot1.Plot;
            
            scatter = plt.Add.Scatter(xs, ys);

            scatter.MarkerSize = 10;//增大标记，方便点击
            scatter.MarkerColor = ScottPlot.Color.FromColor(System.Drawing.Color.Blue);

            plt.Title("散点图");
            //自动调整坐标轴数值范围
            formsPlot1.Plot.Axes.AutoScale();

           

            

            formsPlot1.MouseMove += FormsPlot1_MouseMove;

            formsPlot1.Invalidate();

        }
        private int selectedPointIndex = -1;

        private void FormsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left)
            //    return;
            //if (selectedPointIndex == -1)
            //    return; // 无选中点则不处理

            // 转换鼠标位置到数据坐标
            var data_coordinate = formsPlot1.Plot.GetCoordinates(e.X, e.Y);
            
            Console.WriteLine($" coor {data_coordinate.X} {data_coordinate.Y}");

            formsPlot1.Refresh(); // 刷新图表
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            //解决中文乱码
            formsPlot1.Plot.Font.Automatic();
            var plt = formsPlot1.Plot;


            plt.Title("季度销售堆叠图");
            //图例
            plt.Legend.IsVisible = true;
            plt.Legend.Alignment = Alignment.UpperLeft;
            ScottPlot.Palettes.Category10 palette = new ScottPlot.Palettes.Category10(); //内置的调色板
            plt.Legend.ManualItems.Add(new LegendItem() { LabelText = "Monday", FillColor = palette.GetColor(0) });
            plt.Legend.ManualItems.Add(new LegendItem() { LabelText = "Tuesday", FillColor = palette.GetColor(0) });
            plt.Legend.ManualItems.Add(new LegendItem() { LabelText = "Wednesday", FillColor = palette.GetColor(0) });

            var bars = new[]
            {
    new ScottPlot.Bar { Position = 1, ValueBase = 0, Value = 150, FillColor =palette.GetColor(0) },
    new ScottPlot.Bar { Position = 2, ValueBase = 0, Value = 430, FillColor = palette.GetColor(1) },
    new ScottPlot.Bar { Position = 3, ValueBase = 0, Value = 550, FillColor = palette.GetColor(2) },

    new ScottPlot.Bar { Position = 4, ValueBase = 0, Value = 150, FillColor = palette.GetColor(0) },
     new ScottPlot.Bar { Position = 5, ValueBase = 0, Value = 150, FillColor = palette.GetColor(1) },
      new ScottPlot.Bar { Position = 6, ValueBase = 0, Value = 150, FillColor = palette.GetColor(2) },

      new ScottPlot.Bar {Position = 7, ValueBase = 0,   Value = 150, FillColor = palette.GetColor(0) },
       new ScottPlot.Bar { Position = 8, ValueBase = 0, Value = 150, FillColor = palette.GetColor(1) },
      new ScottPlot.Bar { Position = 9, ValueBase = 0, Value = 150, FillColor = palette.GetColor(2) },
    // Q2、Q3 数据略...
};

            plt.Add.Bars(bars);
            //设置横坐标显示
            Tick[] ticks = {
            new Tick(2, "Group 1"),
            new Tick(5, "Group 2"),
            new Tick(8, "Group 3"),
            };
            plt.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks); //替换默认数字显示
            plt.Axes.Bottom.MajorTickStyle.Length = 0;

            // 隐藏网格
            plt.HideGrid();

            // 设置底部边距
            //plt.Axes.Margins(bottom: 0);
            //自动设置坐标轴范围
            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Invalidate();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            //解决中文乱码
            formsPlot1.Plot.Font.Automatic();
            var plt = formsPlot1.Plot;
            var logger = plt.Add.DataLogger();

            // 模拟实时数据
            for (int i = 0; i < 1000; i++)
            {
                logger.Add(i, Math.Sin(i * 0.1));
            }
            plt.Axes.AutoScale();
        }
    }
}