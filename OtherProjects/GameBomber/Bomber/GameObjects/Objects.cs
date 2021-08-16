using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    class Objects
    {
        private int existTime; // 主要是给炸弹使用的
        private int id;
        private int x;
        private int y;
        //显示分层，地图上有些游戏对象是不能移动的，且有阻挡。有些对象不能移动，但无阻挡，有些对象能移动，有阻挡。
        private int showLevel;

        public int ExistTime { get => existTime; set => existTime = value; }
        public int Id { get => id; set => id = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int ShowLevel { get => showLevel; set => showLevel = value; }
    }
}
