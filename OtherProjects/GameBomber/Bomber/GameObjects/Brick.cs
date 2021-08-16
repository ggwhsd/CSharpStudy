using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    /// <summary>
    /// 砖头墙，可以炸掉
    /// </summary>
    class Brick: Objects
    {
        public Brick(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.ShowLevel = 1;
        }
    }
}
