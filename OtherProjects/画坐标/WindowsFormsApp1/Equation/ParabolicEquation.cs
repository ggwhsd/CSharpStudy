using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Equation
{
    /// <summary>
    ///  y=ax2+bx+c
    /// </summary>
    public class ParabolicEquation : BaseEquation
    {
        /// <summary>
        /// 判断是否有效的方程
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            //A 不得等于0
            return A != 0;
        }

        /// <summary>
        /// 通过X值得到Y值
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public override float GetValueFromX(float x)
        {
            double y = A * Math.Pow(x, 2) + B * x + C;
            return float.Parse(y.ToString());
        }

        public override float GetValueFromY(float y)
        {
        
            double x = Math.Sqrt(1/A*(y-C+ Math.Pow((B / (2 * A)),2) * A)) - B / (2*A) ;
            return (float)(x);
        }
    }
}
