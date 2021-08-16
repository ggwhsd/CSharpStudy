using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    class Map
    {
        //长50，宽20的地图
        private char[,] mapframe = new char[20, 50];

        public char[,] Mapframe { get => mapframe; set => mapframe = value; }
        /// <summary>
        /// 参数没啥意义，这里没有使用，这个函数只是根据mapframe上的数据绘画各个元素。
        /// Background()函数才是从容器中获取元素并映射到地图上。
        /// </summary>
        /// <param name="objectmanager"></param>
        public void ShowMap(ObjectManager objectmanager)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (j == 49 && i != 19)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(this.mapframe[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        if (this.mapframe[i, j] == '口')
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(this.mapframe[i, j]);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            if (this.mapframe[i, j] == '■')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(this.mapframe[i, j]);
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else if (this.mapframe[i, j] == '●')
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(this.mapframe[i, j]);
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else if (this.mapframe[i, j] == '□')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(this.mapframe[i, j]);
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else if (this.mapframe[i, j] == '★')
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(this.mapframe[i, j]);
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else
                                Console.Write(this.mapframe[i, j]);
                        }
                    }
                }
            }

        }

        public Map(ObjectManager objectmanager)
        {
            this.Border();
            this.Background(objectmanager.Objectdict);
        }
        public void Border()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (i != 0 && j != 0 && i != 19 && j != 49)
                    {
                        mapframe[i, j] = '口';
                        //mapframe[i, j] = ' ';
                    }
                    else
                        //mapframe[i, j] = '#';
                        mapframe[i, j] = '■';
                }
            }
        }
        /// <summary>
        /// 不同的游戏对象，需要不同的图形展示，记录不同的展示坐标和展示层次
        /// </summary>
        /// <param name="objectlist"></param>
        public void Background(Dictionary<int, Objects> objectlist)
        {
            List<Objects> Level0Victor = new List<Objects>();
            List<Objects> Level0Speed = new List<Objects>();
            List<Objects> Level0Damage = new List<Objects>();
            List<Objects> Level1Monster = new List<Objects>();
            List<Objects> Level1Brick = new List<Objects>();
            List<Objects> Level1Grass = new List<Objects>();
            List<Objects> Level2 = new List<Objects>();
            foreach (var pair in objectlist)
            {
                if (pair.Value.ShowLevel == 0 && pair.Value is Door)
                {
                    Level0Victor.Add(pair.Value);
                }
                else if (pair.Value.ShowLevel == 0 && pair.Value is SpeedBuff)
                {
                    Level0Speed.Add(pair.Value);
                }
                else if (pair.Value.ShowLevel == 0 && pair.Value is DamageBuff)
                {
                    Level0Damage.Add(pair.Value);
                }
            }
            foreach (var pair in objectlist)
            {
                if (pair.Value.ShowLevel == 1 && pair.Value is Monster)
                {
                    Level1Monster.Add(pair.Value);
                }
                else if (pair.Value.ShowLevel == 1 && pair.Value is Brick)
                {
                    Level1Brick.Add(pair.Value);
                }
                else if (pair.Value.ShowLevel == 1 && pair.Value is Grass)
                {
                    Level1Grass.Add(pair.Value);
                }
            }
            foreach (var pair in objectlist)
            {
                if (pair.Value.ShowLevel == 2)
                {
                    Level2.Add(pair.Value);
                }
            }
            for (int i = 0; i < Level0Victor.Count; i++)
            {
                this.mapframe[Level0Victor[i].X, Level0Victor[i].Y] = 'Π';
            }
            for (int i = 0; i < Level0Speed.Count; i++)
            {
                this.mapframe[Level0Speed[i].X, Level0Speed[i].Y] = 'ξ';
            }
            for (int i = 0; i < Level0Damage.Count; i++)
            {
                this.mapframe[Level0Damage[i].X, Level0Damage[i].Y] = 'Ω';
            }
            for (int i = 0; i < Level1Monster.Count; i++)
            {
                this.mapframe[Level1Monster[i].X, Level1Monster[i].Y] = '●';
            }
            for (int i = 0; i < Level1Brick.Count; i++)
            {
                this.mapframe[Level1Brick[i].X, Level1Brick[i].Y] = '■';
                //this.mapframe[Level1Brick[i].x, Level1Brick[i].y] = '▢';
            }
            for (int i = 0; i < Level1Grass.Count; i++)
            {
                this.mapframe[Level1Grass[i].X, Level1Grass[i].Y] = '□';
            }
            for (int i = 0; i < Level2.Count; i++)
            {
                this.mapframe[Level2[i].X, Level2[i].Y] = '★';
            }
        }
    }
}
