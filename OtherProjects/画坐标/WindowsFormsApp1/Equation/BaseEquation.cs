using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Equation
{
    /// <summary>
    /// 线性方程和抛物线方程的基类
    /// </summary>
    public abstract class BaseEquation
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }

        /// <summary>
        /// 判断是否有效
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();

        /// <summary>
        /// 通过Y值获取x值
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract float GetValueFromY(float y);
        /// <summary>
        /// 通过X获取Y值
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public abstract float GetValueFromX(float x);
    }
}
