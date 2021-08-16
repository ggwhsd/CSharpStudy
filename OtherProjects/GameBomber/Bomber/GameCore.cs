using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 炸弹人，比俄罗斯方块在元素上复杂一些，俄罗斯方块的元素只有两个元素：一个是活动的方块，一个是下一个方块，其他都是属于地图上的点，静态的。
/// 炸弹人里面有怪物、玩家、炸弹等三个自己会移动的元素，在一般游戏开发框架中叫做精灵。
/// 因此，需要计算每个精灵在每个时间单位内的变化，碰撞检测，交互计算，还涉及到元素定时。
/// 俄罗斯方块的碰撞检测是多个格子，而此处的所有元素都只是一个格子，所以检测机制最为简单。
/// 控制台游戏核心调度逻辑，没有额外引入C++的dll。
/// 参考的网上的一个例子，边看边学。
/// 键盘事件通过Console.KeyAvailable判断是否右键被按过，如果有才会读取，否则进入下一帧。
/// 
/// @Author: GUGW
/// 
/// </summary>
namespace Bomber
{
    class GameCore
    {
        //对象管理器，所有生成的元素，都统一纳入，方便计算管理。
        private ObjectManager objectmanager;
        //炸弹人，即玩家，继承于自定义的Objects
        private SuperBomber player;
        private Map gameMap;
        private Random random;
        private string mapFilePath;

        public GameCore()
        {
            objectmanager = new ObjectManager();
            player = new SuperBomber(5, 5);
            objectmanager.Objectdict[0] = player;
            random = new Random();
            mapFilePath = "Map1.txt";
        }

        public Random Random { get => random; }
        public string MapFilePath { get => mapFilePath; }
        internal ObjectManager Objectmanager { get => objectmanager; }
        internal SuperBomber Player { get => player; }
        internal Map GameMap { get => gameMap; }
        private List<Monster> monsters = new List<Monster>();

        /// <summary>
        /// 生成怪物
        /// </summary>
        public void BuildMonsters()
        {
            Monster MonsterA = new Monster(15, 11);
            objectmanager.AddObject(MonsterA);
            monsters.Add(MonsterA);
            Monster MonsterB = new Monster(1, 8);
            objectmanager.AddObject(MonsterB);
            monsters.Add(MonsterB);
            Monster MonsterC = new Monster(9, 27);
            objectmanager.AddObject(MonsterC);
            monsters.Add(MonsterC);
            Monster MonsterD = new Monster(3, 38);
            objectmanager.AddObject(MonsterD);
            monsters.Add(MonsterD);
            Monster MonsterE = new Monster(15, 19);
            objectmanager.AddObject(MonsterE);
            monsters.Add(MonsterE);
            Monster MonsterF = new Monster(17, 39);
            objectmanager.AddObject(MonsterF);
            monsters.Add(MonsterF);
            Monster MonsterG = new Monster(17, 45);
            objectmanager.AddObject(MonsterG);
            monsters.Add(MonsterG);
        }

        public bool isPlayerDie()
        {
            //id = 0 即玩家
            if (!objectmanager.Objectdict.ContainsKey(0))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 加载地图，地图上有些格子会出现多个元素，比如草丛，一个草丛里面可能有一些加速符、门等。
        /// </summary>
        public void LoadMapData()
        {
            FileStream fileStream = new FileStream(mapFilePath, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(fileStream, Encoding.Default);
            string s = null;
            //从第二列第二行开始，因为地图第0行和第0列是画边界的。第一行和第一列都是路。
            int x = 2;
            while ((s = read.ReadLine()) != null)
            {
                for (int y = 2; y < s.Length; y++)
                {
                    if (s[y] == '#')
                    {
                        Brick brick = new Brick(x, y);
                        objectmanager.AddObject(brick);
                    }
                    else if (s[y] == 'W')
                    {
                        Grass grass = new Grass(x, y);
                        objectmanager.AddObject(grass);
                    }
                    else if (s[y] == 'V')
                    {
                        Grass grass = new Grass(x, y);
                        objectmanager.AddObject(grass);
                        Door door = new Door(x, y);
                        objectmanager.AddObject(door);
                    }
                    else if (s[y] == 'K')
                    {
                        Grass grass = new Grass(x, y);
                        objectmanager.AddObject(grass);
                        SpeedBuff speedBuff = new SpeedBuff(x, y);
                        objectmanager.AddObject(speedBuff);
                    }
                    else if (s[y] == 'D')
                    {
                        Grass grass = new Grass(x, y);
                        objectmanager.AddObject(grass);
                        DamageBuff damageBuff = new DamageBuff(x, y);
                        objectmanager.AddObject(damageBuff);
                    }
                }
                x += 1;
            }
        }
        /// <summary>
        /// 刷新地图
        /// </summary>
        public void MapRefresh()
        {
            Console.Clear();
            Map map = new Map(objectmanager);
            map.ShowMap(objectmanager);
        }
        public void ShowPlayerInfo()
        {
            Console.SetCursorPosition(0, 22);
            Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.WriteLine("玩家Id:"+player.Id);
            Console.WriteLine("Speed:"+player.Speed+" ");
            Console.WriteLine("当前位置:"+player.X + ","+ player.Y +"    ");
            
            Console.ForegroundColor = ConsoleColor.White;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="objectmanager"></param>
        /// <returns></returns>
        private bool ExistBrick(int x, int y, ObjectManager objectmanager)
        {
            foreach (var pair in objectmanager.Objectdict)
            {
                if (pair.Value.X == x && pair.Value.Y == y && pair.Value is Brick)
                {
                    return true;
                }
                else if (pair.Value.X == x && pair.Value.Y == y)
                {
                    return false;
                }
                else
                { }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="objectmanager"></param>
        /// <returns></returns>
        private bool ExistGrass(int x, int y, ObjectManager objectmanager)
        {
            foreach (var pair in objectmanager.Objectdict)
            {
                if (pair.Value.X == x && pair.Value.Y == y && pair.Value is Grass)
                {
                    return true;
                }
                else if (pair.Value.X == x && pair.Value.Y == y)
                {
                    return false;
                }
                else
                {

                }
            }
            return false;
        }
        /// <summary>
        /// 爆炸之后，调用以下方法删除游戏对象(不包含炸弹本身，为了显示炸弹效果)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="objectmanager"></param>
        private void KillObject(int x, int y, ObjectManager objectmanager)
        {
            if (x > 18 || x < 1 || y > 48 || y < 0)
                return;
            int id = 0;
            bool kill = false;
            foreach (var pair in objectmanager.Objectdict)
            {
                if (x == pair.Value.X && y == pair.Value.Y)
                {
                    if (pair.Value is SuperBomber || pair.Value is Monster || pair.Value is Grass)
                    {
                        id = pair.Value.Id;
                        kill = true;
                        
                    }
                }
            }
            if (kill)
            {
                objectmanager.RemoveObjectByid(id);
            }
        }
        /// <summary>
        /// 炸弹爆炸
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objectmanager"></param>
        /// <param name="character"></param>
        private void Boomeffect(int id, ObjectManager objectmanager, SuperBomber player)
        {
            int i = player.Damage;
            int x = objectmanager.Objectdict[id].X;
            int y = objectmanager.Objectdict[id].Y;
            Console.SetCursorPosition(2 * y, x);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("※");
            Console.ForegroundColor = ConsoleColor.Gray;
            KillObject(x, y, objectmanager);
            //炸弹伤害范围，左范围
            for (int j = 1; j <= i; j++) 
            {
                int t = 0;
                if (x > 18 || x < 1 || y - j > 48 || y - j < 0)
                    break;
                if (ExistBrick(x, y - j, objectmanager))
                    break;
                Console.SetCursorPosition(2 * (y - j), x);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("※");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (ExistGrass(x, y - j, objectmanager))
                    t = 1;
                KillObject(x, y - j, objectmanager);
                if (t == 1)
                    break;
            }
            //上范围
            for (int j = 1; j <= i; j++)
            {
                int t = 0;
                if (x - j > 18 || x - j < 1 || y > 48 || y < 0)
                    break;
                if (ExistBrick(x - j, y, objectmanager))
                    break;
                Console.SetCursorPosition(2 * y, x - j);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("※");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (ExistGrass(x - j, y, objectmanager))
                    t = 1;
                KillObject(x - j, y, objectmanager);
                if (t == 1)
                    break;
            }
            //右范围
            for (int j = 1; j <= i; j++)
            {
                int t = 0;
                if (x > 18 || x < 1 || y + j > 48 || y + j < 0)
                    break;
                if (ExistBrick(x, y + j, objectmanager))
                    break;
                Console.SetCursorPosition(2 * (y + j), x);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("※");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (ExistGrass(x, y + j, objectmanager))
                    t = 1;
                KillObject(x, y + j, objectmanager);
                if (t == 1)
                    break;
            }
            //下范围
            for (int j = 1; j <= i; j++)
            {
                int t = 0;
                if (x + j > 18 || x + j < 1 || y > 48 || y < 0)
                    break;
                if (ExistBrick(x + j, y, objectmanager))
                    break;
                Console.SetCursorPosition(2 * y, x + j);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("※");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (ExistGrass(x + j, y, objectmanager))
                    t = 1;
                KillObject(x + j, y, objectmanager);
                if (t == 1)
                    break;
            }
        }
        
        public void Run()
        {
            int time = 999;
            Dictionary<int, int> tempdict = new Dictionary<int, int>();
            while (true)
            {
                int max = 0;

                Console.SetCursorPosition(0, 20);

                Console.Write("剩余时间: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(time);
                Console.ForegroundColor = ConsoleColor.White;

                time -= 1;
                #region 计算炸弹影响的游戏对象
                List<int> boomed = new List<int>();
                foreach (var pair in objectmanager.Objectdict)
                {
                    if (pair.Value is Boom)
                    {
                        if (pair.Value.ExistTime > 0)
                        {
                            pair.Value.ExistTime -= 1;
                        }
                        else if (pair.Value.ExistTime == 0)
                        {
                            boomed.Add(pair.Value.Id);
                        }
                    }
                }
                for (int i = 0; i < boomed.Count; i++)
                {
                    Boomeffect(boomed[i], objectmanager, player);
                }
                #endregion


                while (Console.KeyAvailable)
                {
                    max++;
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    tempdict.Clear();
                    //玩家接收到按键后移动
                    BufferRecord(objectmanager, tempdict);
                    player.Move(objectmanager,key);
                    ShowPlayerInfo();
                    BufferShow(objectmanager, tempdict);

                    if (max > player.Speed)
                    {
                        //单个按键内，超过了速度之后，后续按键都忽略掉
                        
                        while (Console.KeyAvailable)
                        {
                            Console.ReadKey(true);
                        }
                        break;
                    }

                }
                //怪物移动
                foreach (var gameObject in monsters)
                {
                    tempdict.Clear();
                    if (objectmanager.Objectdict.ContainsKey(gameObject.Id))
                    {
                        BufferRecord(objectmanager, tempdict);
                        gameObject.AIMove(random.Next(0, 4), objectmanager.Objectdict);
                        BufferShow(objectmanager, tempdict);
                    }
                    
                }

                if (time < 0)
                    break;
                System.Threading.Thread.Sleep(100);

                for (int i = 0; i < boomed.Count; i++)
                {
                    Boomharm(boomed[i], objectmanager, player);
                }
                if (isPlayerDie() || player.Win == 1)
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 5);
                    Console.Write("Win.");
                    break;
                }
            }

            Console.SetCursorPosition(30, 5);
            Console.Write("游戏结束.");
            Console.ReadKey();
        }

        /// <summary>
        /// 当前坐标节点的显示刷新
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="objectmanager"></param>
        private void RefreshPoint(int x, int y, ObjectManager objectmanager)
        {
            if (x > 18 || x < 1 || y > 48 || y < 0)
                return;
            int Level0Victor = 0;
            int Level0Speed = 0;
            int Level0Damage = 0;
            int Level1Monster = 0;
            int Level1Brick = 0;
            int Level1Grass = 0;
            int Level2 = 0;
            int Level3 = 0;
            foreach (var pair in objectmanager.Objectdict)
            {
                if (pair.Value.X == x && pair.Value.Y == y)
                {
                    if (pair.Value.ShowLevel == 0 && pair.Value is Door)
                    {
                        Level0Victor += 1;
                    }
                    else if (pair.Value.ShowLevel == 0 && pair.Value is SpeedBuff)
                    {
                        Level0Speed += 1;
                    }
                    else if (pair.Value.ShowLevel == 0 && pair.Value is DamageBuff)
                    {
                        Level0Damage += 1;
                    }
                    if (pair.Value.ShowLevel == 1 && pair.Value is Monster)
                    {
                        Level1Monster += 1;
                    }
                    else if (pair.Value.ShowLevel == 1 && pair.Value is Brick)
                    {
                        Level1Brick += 1;
                    }
                    else if (pair.Value.ShowLevel == 1 && pair.Value is Grass)
                    {
                        Level1Grass += 1;
                    }
                    if (pair.Value.ShowLevel == 2)
                    {
                        Level2 += 1;
                    }
                    if (pair.Value.ShowLevel == 3)
                    {
                        Level3 += 1;
                    }
                }
            }
            Console.SetCursorPosition(2 * y, x);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("口");
            Console.ForegroundColor = ConsoleColor.Gray;
            if(Level0Victor>0)
            {
                Console.SetCursorPosition(2 * y, x);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Π");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if(Level0Speed>0)
            {
                Console.SetCursorPosition(2 * y, x);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("ξ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if(Level0Damage>0)
            {
                Console.SetCursorPosition(2 * y, x);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Ω");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if(Level1Monster>0)
            {
                Console.SetCursorPosition(2 * y, x);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("●");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if(Level1Brick>0)
            {
                Console.SetCursorPosition(2 * y, x);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("■");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if(Level1Grass>0)
            {
                Console.SetCursorPosition(2 * y, x);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("□");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if(Level2>0)
            {
                Console.SetCursorPosition(2 * y, x);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("★");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if(Level3>0)
            {
                Console.SetCursorPosition(2 * y, x);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("⊙");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        /// <summary>
        /// 炸弹本身删除，并且刷新界面消除炸弹范围的显示效果。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objectmanager"></param>
        /// <param name="player"></param>
        private void Boomharm(int id, ObjectManager objectmanager, SuperBomber player)
        {
            int i = player.Damage;
            int x = objectmanager.Objectdict[id].X;
            int y = objectmanager.Objectdict[id].Y;
            objectmanager.RemoveObjectByid(id);
            RefreshPoint(x, y, objectmanager);
            for (int j = 1; j <= i; j++)
                RefreshPoint(x, y - j, objectmanager);
            for (int j = 1; j <= i; j++)
                RefreshPoint(x - j, y, objectmanager);
            for (int j = 1; j <= i; j++)
                RefreshPoint(x, y + j, objectmanager);
            for (int j = 1; j <= i; j++)
                RefreshPoint(x + j, y, objectmanager);
        }
        /// <summary>
        /// 缓存记录，记录当前所有对象的位置信息
        /// </summary>
        /// <param name="objectmanager"></param>
        /// <param name="tempdict"></param>
        public void BufferRecord(ObjectManager objectmanager, Dictionary<int, int> tempdict)
        {
            foreach (var pair in objectmanager.Objectdict)
            {
                tempdict.Add(pair.Key, pair.Value.X * 49 + pair.Value.Y);
            }
        }
        /// <summary>
        /// 比较缓存数据和当前数据，判断是否有对象发生变化：消失、移动等。
        /// 若发生变化，则重绘变化的部分
        /// </summary>
        /// <param name="objectmanager"></param>
        /// <param name="tempdict"></param>
        public void BufferShow(ObjectManager objectmanager, Dictionary<int, int> tempdict)
        {
            bool isMoved = false;
            int buffer_X = 0;
            int buffer_Y = 0;
            int current_X = 0;
            int current_Y = 0;
            int objectType = 0;
            int Level0Victor = 0;
            int Level0Speed = 0;
            int Level0Damage = 0;
            int Level1Monster = 0;
            int Level1Brick = 0;
            int Level1Grass = 0;
            int Level2 = 0;
            int Level3 = 0;
            foreach (var pairNow in objectmanager.Objectdict)
            {
                foreach (var pairBuffer in tempdict)
                {
                    if (pairBuffer.Key == pairNow.Key)
                    {
                        //游戏对象的坐标发生了变化
                        if (!((pairBuffer.Value / 49) == pairNow.Value.X && (pairBuffer.Value % 49) == pairNow.Value.Y))
                        {
                            isMoved = true;
                            buffer_X = pairBuffer.Value / 49;
                            buffer_Y = pairBuffer.Value % 49;
                            current_X = pairNow.Value.X;
                            current_Y = pairNow.Value.Y;
                            if (pairNow.Value is SuperBomber)
                            {
                                objectType = 1;
                            }
                            else if (pairNow.Value is Monster)
                            {
                                objectType = 2;
                            }
                            //检查该对象的缓存位置上，当前存在哪些对象。
                            foreach (var pair in objectmanager.Objectdict)
                            {
                                if (pair.Value.X == buffer_X && pair.Value.Y == buffer_Y)
                                {
                                    if (pair.Value.ShowLevel == 0 && pair.Value is Door)
                                    {
                                        Level0Victor += 1;
                                    }
                                    else if (pair.Value.ShowLevel == 0 && pair.Value is SpeedBuff)
                                    {
                                        Level0Speed += 1;
                                    }
                                    else if (pair.Value.ShowLevel == 0 && pair.Value is DamageBuff)
                                    {
                                        Level0Damage += 1;
                                    }
                                    if (pair.Value.ShowLevel == 1 && pair.Value is Monster)
                                    {
                                        Level1Monster += 1;
                                    }
                                    else if (pair.Value.ShowLevel == 1 && pair.Value is Brick)
                                    {
                                        Level1Brick += 1;
                                    }
                                    else if (pair.Value.ShowLevel == 1 && pair.Value is Grass)
                                    {
                                        Level1Grass += 1;
                                    }
                                    if (pair.Value.ShowLevel == 2)
                                    {
                                        Level2 += 1;
                                    }
                                    if (pair.Value.ShowLevel == 3)
                                    {
                                        Level3 += 1;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            //当前有对象移动了。
            if (isMoved == true)
            {
                //因为这里符号都是占用两个char，CusorPosition参数是left和top，对应Y和X。
                Console.SetCursorPosition(2 * buffer_Y, buffer_X);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("口");
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < Level0Victor; i++)
                {
                    Console.SetCursorPosition(2 * buffer_Y, buffer_X);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Π");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                for (int i = 0; i < Level0Speed; i++)
                {
                    Console.SetCursorPosition(2 * buffer_Y, buffer_X);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("ξ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                for (int i = 0; i < Level0Damage; i++)
                {
                    Console.SetCursorPosition(2 * buffer_Y, buffer_X);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Ω");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                for (int i = 0; i < Level1Monster; i++)
                {
                    Console.SetCursorPosition(2 * buffer_Y, buffer_X);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("●");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                for (int i = 0; i < Level1Brick; i++)
                {
                    Console.SetCursorPosition(2 * buffer_Y, buffer_X);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("■");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                for (int i = 0; i < Level1Grass; i++)
                {
                    Console.SetCursorPosition(2 * buffer_Y, buffer_X);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("□");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                for (int i = 0; i < Level2; i++)
                {
                    Console.SetCursorPosition(buffer_Y, buffer_X);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("★");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                for (int i = 0; i < Level3; i++)
                {
                    Console.SetCursorPosition(2 * buffer_Y, buffer_X);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("⊙");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.SetCursorPosition(2 * current_Y, current_X);
                switch (objectType)
                {
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("★");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        }
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("●");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
