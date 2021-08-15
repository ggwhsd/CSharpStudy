using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTetris
{
    public class MyMap
    {
        private int[,] arr_map;
        //横坐标 size_x，横坐标上的位置，实际上是坐标点的列
        private static int size_x = 24;
        //纵坐标 size_y
        private static int size_y = 48;

        public MyMap()
        {
            
           
             arr_map = new int[size_x, size_y];
            for (int x = 0; x < arr_map.GetLength(0); x++)
            {
                for (int y = 0; y < arr_map.GetLength(1); y++)
                {
                    if (x == 0 || y == arr_map.GetLength(1) - 1 || x == arr_map.GetLength(0) - 1)
                    {
                        arr_map[x, y] = (int)ConsoleColor.White;
                    }
                    else
                        arr_map[x, y] = -1;
                }
            }
            Map = arr_map;
        }

        public int[,] Map { get => arr_map; set => arr_map = value; }
        public static int Size_x { get => size_x; set => size_x = value; }
        public static int Size_y { get => size_y; set => size_y = value; }

        public void AddBlocks(TetrisBlock block)
        {
            foreach (MyPoint p in block.Blocks)
            {
                Map[p.X, p.Y + 4] = (int)block.Color;
            }
        }

        public int FullCheck()
        {
            List<int> rows = new List<int>();
            for (int y = 4; y < Map.GetLength(1) - 1; y++)
            {
                bool isFull = true;
                for (int x = 1; x < Map.GetLength(0) - 1; x++)
                {
                    if (Map[x, y] == -1)
                    {
                        isFull = false;
                    }
                }
                if (isFull)
                {
                    rows.Add(y);
                }
            }
            if (rows.Count > 0)
            {
                ClearFull(rows);
                return rows.Count;
            }
            return 0;
        }

        private void ClearFull(List<int> rows)
        {
            foreach (int row in rows)
            {
                for (int y = row; y >= 0; y--)
                {
                    for (int x = 1; x < Map.GetLength(0) - 1; x++)
                    {
                        if (y == 0)
                        {
                            Map[x, y] = -1;
                        }
                        else
                        {
                            Map[x, y] = Map[x, y - 1];
                        }
                    }
                }
            }
        }

        public bool CanNotRotate(TetrisBlock block)
        {
            foreach (var p in block.Blocks)
            {
                if (Map[p.X, p.Y + 4] != -1)
                    return true;
            }
            return false;
        }

        public bool CheckOver()
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 1; x < Map.GetLength(0) - 1; x++)
                {
                    if (Map[x, y] != -1)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 利用俄罗斯方块的右边界坐标点，来检测是否已经靠到右边了。即有边界点上是否已经其他方块。
        /// </summary>
        public bool IsRightTouch(TetrisBlock block)
        {
            foreach (var p in block.BoundsRight)
            {
                if (Map[p.X, p.Y + 4] != -1)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 利用俄罗斯方块的左边界坐标点，来检测是否已经靠到右边了。即左边界点上是否已经其他方块。
        /// </summary>
        public bool IsLeftTouch(TetrisBlock block)
        {
            foreach (var p in block.BoundsLeft)
            {
                if (Map[p.X, p.Y + 4] != -1)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 利用俄罗斯方块的下边界坐标点，来检测是否已经靠到右边了。即下边界点上是否已经其他方块。
        /// </summary>
        public bool IsDownTouch(TetrisBlock block)
        {
            foreach (var p in block.BoundsDown)
            {
                if (Map[p.X, p.Y + 4] != -1)
                    return true;
            }
            return false;
        }


    }
}
