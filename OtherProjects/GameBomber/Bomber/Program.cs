﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.CursorVisible = false;
            GameCore core = new GameCore();
            core.LoadMapData();
            core.BuildMonsters();
            core.MapRefresh();
            //UNDONE:
            core.Run();
            
        }
    }
}
