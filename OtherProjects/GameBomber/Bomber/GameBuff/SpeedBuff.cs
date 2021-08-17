using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    /// <summary>
    /// 加速的buff，获得可以提升移动速度
    /// </summary>
    class SpeedBuff:Objects
    {
        public SpeedBuff(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.ShowLevel = 0;
        }
    }
}
