using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    /// <summary>
    /// 炸弹伤害提升的buff，获取可以提升炸弹的为例
    /// </summary>
    class DamageBuff : Objects
    {
        public DamageBuff(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.ShowLevel = 0;
        }
    }
}
