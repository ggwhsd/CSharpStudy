using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Equation
{
    /// <summary>
    /// Ax+By+C=0(A、B不同时为0)【适用于所有直线】
    /// </summary>
    public class LinearEquation : BaseEquation
    {
        /// <summary>
        /// 输入x，获取y
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public override float GetValueFromX(float x)
        {
            if (B == 0)
            {
                return float.MaxValue;
            }
            return -A * x * 1.0f / B - C * 1.0f / B;
        }
        /// <summary>
        /// 输入y，获取x
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public override float GetValueFromY(float y)
        {
            if (A == 0)
            {
                return float.MaxValue;
            }
            return -B * y * 1.0f / A - C * 1.0f / A;
        }
        /// <summary>
        /// 参数是否可以形成有效的方程
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            bool flag = true;
            if (A == 0 && B == 0)
            {
                flag = false;
            }
            return flag;
        }

        public override string ToString()
        {
            return string.Format("{0}x+{1}y+{2}=0", A, B, C);
        }
    }
}
