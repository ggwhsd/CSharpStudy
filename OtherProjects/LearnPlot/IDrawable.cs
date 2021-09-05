using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnPlot
{
    /// <summary>
    /// 定义一个绘画接口，用于二维物理坐标系上。
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// 在坐标轴x和y上画图，所有后续需要展示的组件，都需要继承这个接口
        /// </summary>
        /// <param name="g"></param>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        void Draw(Graphics g, PhysicalAxis xAxis, PhysicalAxis yAxis);
    }
}
