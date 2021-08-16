using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    class Boom : Objects
    {
        public Boom(int x, int y)
        {
            this.ExistTime = 15;
            this.ShowLevel = 3;
            this.X = x;
            this.Y = y;
        }
    }
}
