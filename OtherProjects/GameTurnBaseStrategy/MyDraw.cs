using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTurnBaseStrateg
{
    /// <summary>
    /// 控制台上输出需要的游戏信息和显示效果
    /// </summary>
    static class MyDraw
    {
        /// 清空指定行
        public static void ClearLine(int line)
        {
            Console.SetCursorPosition(0, line);
            for (int i = 0; i < Program.width; i++)
            {
                Console.Write(' ');
            }
            Console.SetCursorPosition(0, 0);

        }
        /// 在指定行的指定开始位置清空指定宽度的内容
        public static void ClearLine(int line, int start, int width)
        {
            Console.SetCursorPosition(start, line);
            for (int i = 0; i < width; i++)
            {
                Console.Write(' ');
            }
            Console.SetCursorPosition(0, 0);
        }
        //擦除一半的显示
        private static void WriteEmpty()
        {
            WriteEmpty(Program.width/2);
        }

        private static void WriteEmpty(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }
        /// <summary>
        /// 清楚指定序号上的怪物或者玩家
        /// </summary>
        /// <param name="one"></param>
        /// <param name="index"></param>
        private static void ClearCharacterInfo(BaseCharacter one
            , int index)
        {
            if (one.type == CharacterType.Player)
            {
                //每个玩家的显示信息为4行
                Console.SetCursorPosition(0, 4 * index + 2);
                WriteEmpty();
                Console.SetCursorPosition(0, 4 * index + 3);
                WriteEmpty();
                Console.SetCursorPosition(0, 4 * index + 4);
                WriteEmpty();
            }
            else if (one.type == CharacterType.Enemy)
            {
                //每个怪物的显示信息为4行，显示在右边半个屏幕
                int left = Program.width / 2;
                Console.SetCursorPosition(left, 4*index +2) ;
                WriteEmpty();
                Console.SetCursorPosition(left, 4 * index + 3);
                WriteEmpty();
                Console.SetCursorPosition(left, 4 * index + 4);
                WriteEmpty();
            }
            Console.SetCursorPosition(0, 0);

        }

        /// <summary>
        /// 显示角色的状态信息
        /// </summary>
        /// <param name="one"></param>
        /// <param name="index"></param>
        public static void DrawState(BaseCharacter one, int index)
        {
            string temp = "";
            foreach (State s in one.state)
            {
                switch (s.type)
                {
                    case StateType.DamageOverTime:
                        temp += "DOT|";
                        break;
                    case StateType.Silence:
                        temp += "SI|";
                        break;
                    case StateType.Buff:
                        if (s.atkUp > 0)
                            temp += "A+|";
                        if (s.defUp > 0)
                            temp += "D+|";
                        if (s.atkUp < 0)
                            temp += "A-|";
                        if (s.defUp < 0)
                            temp += "D-|";
                        break;
                    case StateType.MagicReflect:
                        temp += "MR|";
                        break;
                    case StateType.PhysicalReflect:
                        temp += "PR|";
                        break;
                    case StateType.PhysicalDamageIncrease:
                        temp += "PD+|";
                        break;
                    case StateType.PhysicalBeDamageIncrease:
                        temp += "PBD+|";
                        break;
                    case StateType.Taunt:
                        temp += "TA|";
                        break;
                    case StateType.Revive:
                        temp += "RE|";
                        break;
                    case StateType.Invincible:
                        temp += "IV|";
                        break;
                    case StateType.HealOverTime:
                        temp += "HOT|";
                        break;
                    case StateType.Dizzy:
                        temp += "DI|";
                        break;
                    case StateType.ForbidHeal:
                        temp += "FH|";
                        break;
                    default:
                        break;
                }
                if (one.type == CharacterType.Player)
                {
                    Console.SetCursorPosition(0, index * 4 + 5);
                    WriteEmpty();
                    Console.SetCursorPosition(0, index * 4 + 5);
                }
                else
                {
                    int len = GetLength(temp);
                    Console.SetCursorPosition(Program.width - len - 1, index * 4 + 5);
                    WriteEmpty(len);
                    Console.SetCursorPosition(Program.width - len - 1, index * 4 + 5);
                }
                if (temp != "")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(temp);
                }
                Console.SetCursorPosition(0, 0);
            }

            
        }
        /// <summary>
        /// 获取指定文本占据的控制台宽度，英文1位，中文2位
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int GetLength(string text)
        {
            byte[] bytes;
            int len = 0;
            for (int i = 0; i < text.Length; i++)
            {
                bytes = Encoding.Default.GetBytes(text.Substring(i, 1));
                len += bytes.Length > 1 ? 2 : 1;
            }
            return len;
        }

        /// 播放玩家攻击怪物时的动画效果
        public static void DrawAttackAnimation(BaseCharacter attacker, int att_index, BaseCharacter target, int tar_index)
        {
            int x1 = GetLength("HP:" + attacker.Hp);
            int x2 = GetLength("HP:" + target.Hp);
            int xStart = x1 + 2;
            int xEnd = Program.width - x2 - 2;
            int xMiddle = (xEnd - xStart) / 2;
            //每个角色的第三行信息为Hp信息
            int yStart = att_index * 4 + 3;
            int yEnd = tar_index * 4 + 3;
            for (int i = xStart; i < xEnd; i = i + 2)
            {
                if (i == xMiddle || i == xMiddle + 1)
                {
                    Console.SetCursorPosition(i - 2, yStart);
                    Console.Write("  ");
                    if (yStart > yEnd)
                    {
                        for (int j = yStart; j >= yEnd; j--)
                        {
                            Console.SetCursorPosition(i, j + 1);
                            Console.Write("  ");
                            Console.SetCursorPosition(i, j);
                            Console.Write("↑");
                            //通过线程睡眠来实现闪烁效果
                            Thread.Sleep(20);
                        }
                    }
                    else if (yStart < yEnd)
                    {
                        for (int j = yStart; j <= yEnd; j++)
                        {
                            Console.SetCursorPosition(i, j - 1);
                            Console.Write("  ");
                            Console.SetCursorPosition(i, j);
                            Console.Write("↓");
                            Thread.Sleep(20);
                        }
                    }
                }
                else if (i < xMiddle)
                {
                    Console.SetCursorPosition(i - 2, yStart);
                    Console.Write("  ");
                    Console.SetCursorPosition(i, yStart);
                    Console.Write("→");
                }
                else
                {
                    Console.SetCursorPosition(i - 2, yEnd);
                    Console.Write("  ");
                    Console.SetCursorPosition(i, yEnd);
                    Console.Write("→");
                }
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(xEnd - 2, yEnd);
            Console.Write("  ");
        }


        /// 播放怪物攻击玩家时的动画效果
        public static void DrawAttackAnimationEnemy(BaseCharacter attacker, int att_index, BaseCharacter target, int tar_index)
        {
            int xStart = Program.width - GetLength("HP:" + attacker.Hp) - 2;
            int xEnd = GetLength("HP:" + target.Hp) + 2;
            int xMiddle = (xStart - xEnd) / 2;
            int yStart = att_index * 4 + 3;
            int yEnd = tar_index * 4 + 3;
            for (int i = xStart; i > xEnd; i = i - 2)
            {
                if (i == xMiddle || i == xMiddle - 1)
                {
                    Console.SetCursorPosition(i + 2, yStart);
                    Console.Write("  ");
                    if (yStart > yEnd)
                    {
                        for (int j = yStart; j >= yEnd; j--)
                        {
                            Console.SetCursorPosition(i, j + 1);
                            Console.Write("  ");
                            Console.SetCursorPosition(i, j);
                            Console.Write("↑");
                            Thread.Sleep(20);
                        }
                    }
                    else if (yStart < yEnd)
                    {
                        for (int j = yStart; j <= yEnd; j++)
                        {
                            Console.SetCursorPosition(i, j - 1);
                            Console.Write("  ");
                            Console.SetCursorPosition(i, j);
                            Console.Write("↓");
                            Thread.Sleep(20);
                        }
                    }
                }
                else if (i < xMiddle)
                {
                    if (i != xStart)
                    {
                        Console.SetCursorPosition(i + 2, yEnd);
                        Console.Write("  ");
                    }
                    Console.SetCursorPosition(i, yEnd);
                    Console.Write("←");
                }
                else
                {
                    if (i != xStart)
                    {
                        Console.SetCursorPosition(i + 2, yStart);
                        Console.Write("  ");
                    }
                    Console.SetCursorPosition(i, yStart);
                    Console.Write("←");
                }
                Thread.Sleep(20);
            }
            Console.SetCursorPosition(xEnd + 2, yEnd);
            Console.Write("  ");
        }

        /// 播放受到伤害时候的动画
        public static void DrawDamageAnimation(BaseCharacter one, int index)
        {
            DrawCharacterInfoOpsColor(one, index, 5, 3);
            Thread.Sleep(100);
            DrawCharacterInfo(one, index);
            Thread.Sleep(100);
            DrawCharacterInfoOpsColor(one, index, 5, 3);
            Thread.Sleep(100);
            DrawCharacterInfo(one, index);
            Thread.Sleep(100);
        }

        /// <summary>
        /// 按照指定颜色显示角色信息，第一个int是玩家信息的颜色，第二个是敌人的颜色，用于闪烁
        /// </summary>
        /// <param name="one"></param>
        /// <param name="index"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        private static void DrawCharacterInfoOpsColor(BaseCharacter one, int index, int color1, int color2)
        {
            ClearCharacterInfo(one, index);
            if (one.type == CharacterType.Player)
            {
                Console.ForegroundColor = (ConsoleColor)(color1);
                Console.SetCursorPosition(0, 4 * index + 2);
                Console.Write(one.Name);
                Console.SetCursorPosition(0, 4 * index + 3);
                Console.Write("HP:" + one.Hp);
                Console.SetCursorPosition(0, 4 * index + 4);
                Console.Write("MP:" + one.Mp);
            }
            if (one.type == CharacterType.Enemy)
            {
                Console.ForegroundColor = (ConsoleColor)(color2);
                int temp = GetLength(one.Name);
                Console.SetCursorPosition(Program.width - temp, 4 * index + 2);
                Console.Write(one.Name);
                temp = GetLength("HP:" + one.Hp);
                Console.SetCursorPosition(Program.width - temp, 4 * index + 3);
                Console.Write("HP:" + one.Hp);
                temp = GetLength("MP:" + one.Mp);
                Console.SetCursorPosition(Program.width - temp, 4 * index + 4);
                Console.Write("MP:" + one.Mp);
            }
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// 显示指定序号的玩家或者敌人信息
        /// </summary>
        /// <param name="one"></param>
        /// <param name="index"></param>
        public static void DrawCharacterInfo(BaseCharacter one, int index)
        {
            ClearCharacterInfo(one, index);
            if (one.type == CharacterType.Player)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, 4 * index + 2);
                Console.Write(one.Name);
                Console.SetCursorPosition(0, 4 * index + 3);
                Console.Write("HP:" + one.Hp);
                Console.SetCursorPosition(0, 4 * index + 4);
                Console.Write("MP:" + one.Mp);
                DrawState(one, index);
            }
            if (one.type == CharacterType.Enemy)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                int temp = GetLength(one.Name);
                Console.SetCursorPosition(Program.width - temp, 4 * index + 2);
                Console.Write(one.Name);
                temp = GetLength("HP:" + one.Hp);
                Console.SetCursorPosition(Program.width - temp, 4 * index + 3);
                Console.Write("HP:" + one.Hp);
                temp = GetLength("MP:" + one.Mp);
                Console.SetCursorPosition(Program.width - temp, 4 * index + 4);
                Console.Write("MP:" + one.Mp);
                DrawState(one, index);
            }
            Console.SetCursorPosition(0, 0);
        }

    }
}
