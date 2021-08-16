using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    class Monster: Objects
    {
        public Monster(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.ShowLevel = 1;
        }
        /// <summary>
        /// 怪兽需要自己移动
        /// </summary>
        /// <param name="randomchoice">移动方向，上下左右以及停留原地，五种可能</param>
        /// <param name="objectsdict">所有的游戏对象</param>
        public void AIMove(int randomchoice, Dictionary<int, Objects> objectsdict)
        {
            switch (randomchoice)
            {
                case 0:
                    {   //左移动,碰到炸弹人，则炸弹人死亡。
                        int die = -1;
                        foreach (var pair in objectsdict)
                        {
                            if (pair.Value.X == (this.X) && pair.Value.Y == (this.Y - 1) && !(pair.Value is SuperBomber))
                                return;
                            else if (pair.Value.X == (this.X) && pair.Value.Y == (this.Y - 1) && pair.Value is SuperBomber)
                                die = pair.Value.Id;
                        }
                        if (die != -1)
                        {
                            objectsdict.Remove(die);
                        }
                        if (this.Y > 1)
                        {
                            this.Y -= 1;
                        }
                        break;
                    }
                case 1:
                    {
                        int die = -1;
                        foreach (var pair in objectsdict)
                        {
                            if (pair.Value.Y == (this.Y) && pair.Value.X == (this.X + 1) && !(pair.Value is SuperBomber))
                                return;
                            else if (pair.Value.X == (this.X + 1) && pair.Value.Y == this.Y && pair.Value is SuperBomber)
                                die = pair.Value.Id;
                        }
                        if (die != -1)
                        {
                            objectsdict.Remove(die);
                        }
                        if (this.X < 18)
                        {
                            this.X += 1;
                        }
                        break;
                    }
                case 2:
                    {
                        int die = -1;
                        foreach (var pair in objectsdict)
                        {
                            if (pair.Value.X == (this.X) && pair.Value.Y == (this.Y + 1) && !(pair.Value is SuperBomber))
                                return;
                            else if (pair.Value.X == (this.X) && pair.Value.Y == (this.Y + 1) && pair.Value is SuperBomber)
                                die = pair.Value.Id;
                        }
                        if (die != -1)
                        {
                            objectsdict.Remove(die);
                        }
                        if (this.Y < 48)
                        {
                            this.Y += 1;
                        }
                        break;
                    }
                case 3:
                    {
                        int die = -1;
                        foreach (var pair in objectsdict)
                        {
                            if (pair.Value.Y == (this.Y) && pair.Value.X == (this.X - 1) && !(pair.Value is SuperBomber))
                                return;
                            else if (pair.Value.X == (this.X - 1) && pair.Value.Y == (this.Y) && pair.Value is SuperBomber)
                                die = pair.Value.Id;
                        }
                        if (die != -1)
                        {
                            objectsdict.Remove(die);
                        }
                        if (this.X > 1)
                        {
                            this.X -= 1;
                        }
                        break;
                    }
                default:
                    return;
            }

        }
    }
}
