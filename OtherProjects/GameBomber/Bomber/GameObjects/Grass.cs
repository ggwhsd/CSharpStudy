using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    /// <summary>
    /// 草
    /// </summary>
    class Grass:Objects
    {
        public Grass(int x, int y)
        {
            this.ShowLevel = 1;
            this.X = x;
            this.Y = y;
        }
    }
}
