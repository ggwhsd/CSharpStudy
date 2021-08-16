using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    class Door:Objects
    {
        public Door(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.ShowLevel = 0;
        }
    }
}
