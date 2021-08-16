using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    /// <summary>
    /// 炸弹人，亦玩家，主要属性：威力、移动速度、是否赢、位置xy、元素唯一Id、显示层级（不同显示层级对应炸弹的处理逻辑不一样，且碰撞检测也不一样）
    /// 炸弹人的行为有 上下左右移动，啥都不做，放置炸弹。
    /// @Author: GUGW
    /// </summary>
    class SuperBomber : Objects
    {
        private int damage;
        private int speed = 0;
        private int win;

        public int Damage { get => damage; set => damage = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Win { get => win; set => win = value; }
        public SuperBomber(int x, int y)
        {
            this.win = 0;
            this.damage = 2;
            this.Id = 0;
            this.X = x;
            this.Y = y;
            this.ShowLevel = 2;
        }
        enum OpAction
        {
            Left,
            Down,
            Up,
            Right,
            Boom,//放置炸弹
            None
        };
        OpAction moveDirection;
        private bool isMoveToLeft()
        {
            return (moveDirection == OpAction.Left);
        }
        private bool isMoveToUp()
        {
            return (moveDirection == OpAction.Up);
        }
        private bool isMoveToRight()
        {
            return (moveDirection == OpAction.Right);
        }
        private bool isMoveToDown()
        {
            return (moveDirection == OpAction.Down);
        }
        /// <summary>
        /// 判断当前操作按键之后，炸弹人是否碰到坐标为X、Y上的其他元素
        /// </summary>
        /// <param name="key"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        private bool isExistObjectsIfMove(ConsoleKey key, int X, int Y)
        {
            if (key == ConsoleKey.Spacebar)
            {
                moveDirection = OpAction.Boom;
                return false;
            }
            else if (key == ConsoleKey.A)
            {
                moveDirection = OpAction.Left;
                if ( (X == this.X) && (Y == this.Y - 1))
                {
                    
                    return true;
                }
                else
                    return false;
            }
            else if (key == ConsoleKey.S)
            {
                moveDirection = OpAction.Down;
                if (Y == (this.Y) && X == (this.X + 1))
                {
                    
                    return true;
                }
                else
                    return false;
            }
            else if (key == ConsoleKey.D)
            {
                moveDirection = OpAction.Right;
                if (Y == (this.Y + 1) && X == (this.X))
                {
                    
                    return true;
                }
                else
                    return false;
            }
            else if (key == ConsoleKey.W)
            {
                moveDirection = OpAction.Up;
                if (Y == (this.Y) && X == (this.X - 1))
                {
                    
                    return true;
                }
                else
                    return false;
            }
            else
            {
                moveDirection = OpAction.None;
                return false;
            }
        }
        /// <summary>
        /// 炸弹人行动，不仅仅只有移动，炸弹也算。
        /// </summary>
        /// <param name="objectmanager">元素容器</param>
        /// <param name="key">当前按键</param>
        public void Move(ObjectManager objectmanager,ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Spacebar)
            {
                //炸弹人元素id为0，只有炸弹人存在，才可以放置炸弹。
                if (objectmanager.Objectdict.ContainsKey(0))
                    objectmanager.AddObject(new Boom(this.X, this.Y));
                return;
            }
            int id = -1;
            int win = 0;
            int count = 0;
            foreach (var pair in objectmanager.Objectdict)
            {
                //碰撞检测
                //判断往左走，是否有游戏对象
                if (isExistObjectsIfMove(key.Key,pair.Value.X, pair.Value.Y)==true)
                {
                    //判断该游戏对象不是为门或者buff,只有这几种对象是没有阻挡的，其他对象都是有阻挡不可移动
                    if (!(pair.Value is SpeedBuff || pair.Value is DamageBuff || pair.Value is Door))
                    {
                        return;
                    }
                    else
                    {
                        //是，则需要增益buff
                        id = pair.Value.Id;
                        if (pair.Value is SpeedBuff)
                        {
                            this.Speed++;
                        }
                        else if (pair.Value is DamageBuff)
                        {
                            this.Damage+=2;
                        }
                        else
                        {
                            win += 1;
                        }
                    }
                }
            }
            //移除Buff游戏对象
            if (objectmanager.Objectdict.ContainsKey(id) && !(objectmanager.Objectdict[id] is Door))
                objectmanager.RemoveObjectByid(id);
            //检查怪物数量
            foreach (var pair in objectmanager.Objectdict)
            {
                if (pair.Value is Monster)
                {
                    count += 1;
                }
            }
            //怪物没有了，且，走到门口
            if (count == 0 && win == 1)
            {
                this.win = 1;
            }
            if (isMoveToLeft())
            {
                //往左走，纵坐标-1
                if (this.Y > 1)
                {
                    this.Y -= 1;
                    return;
                }
                else
                    return;
            }
            if (isMoveToRight())
            {
                //往左走，纵坐标-1
                if (this.Y < 48)
                {
                    this.Y += 1;
                    return;
                }
                else
                    return;
            }
            else if (isMoveToDown())
            {
                if (this.X < 18)
                {
                    this.X += 1;
                    return;
                }
                else
                    return;
            }
            else if (isMoveToUp())
            {
                if (this.X > 1)
                {
                    this.X -= 1;
                    return;
                }
                else
                    return;
            }


        }
    }
}
