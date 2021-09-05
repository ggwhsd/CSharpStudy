using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnPlot
{
    class Utils
    {
        /// <summary>
        /// 根据scale计算放大或者缩小后的字体大小
        /// </summary>
        /// <param name="initial">原始字体</param>
        /// <param name="scale">放大或者缩小值</param>
        /// <returns></returns>
        public static Font ScaleFont(Font initial, double scale)
        {
            FontStyle fs = initial.Style;
            GraphicsUnit gu = initial.Unit;
            double sz = initial.Size;
            sz = sz * scale;
            string nm = initial.Name;
            return new Font(nm, (float)sz, fs, gu);
        }
    }
}
