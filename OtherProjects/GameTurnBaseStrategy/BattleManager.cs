using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTurnBaseStrateg
{
    //该游戏的引擎类
    class BattleManager
    {
        public List<BaseCharacter> players;
        public List<BaseCharacter> enemys;

        public List<int> textPos;
        /// <summary>
        /// 当前触发的技能
        /// </summary>
        public Skill tempSkill;
        /// <summary>
        /// 当前回合行动的角色
        /// </summary>
        public int actionIndex;

        public int chooseEnemyIndex;

        public int choosePartyIndex;

        /// <summary>
        /// 游戏回合数
        /// </summary>
        public int gameCounts;

        public BattleManager()
        {
            players = new List<BaseCharacter>();
            enemys = new List<BaseCharacter>();
            textPos = new List<int>();
            gameCounts = 1;

        }
        /// <summary>
        /// 绘制游戏场景、人物
        /// </summary>
        public void DrawBattleField()
        {
            for (int i = 0; i < players.Count; i++)
            {
                MyDraw.DrawCharacterInfo(players[i], i);
            }
            for(int j = 0; j<enemys.Count; j++)
            {
                MyDraw.DrawCharacterInfo(enemys[j], j);
            }

        }

        public void BattleRun()
        {
            while(true)
            {
                actionIndex = 0;
                chooseEnemyIndex = 0;
                MyDraw.DrawCounts(gameCounts);


            }
        }

        /// <summary>
        /// 每回合开始前，执行相关状态
        /// </summary>
        private void ExeStateAtCountStart()
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].ExeCountStartState(i);
            }
            for (int i = 0; i < enemys.Count; i++)
            {
                enemys[i].ExeCountStartState(i);
            }
        }
        /// <summary>
        /// 回车结束时，执行相关状态
        /// </summary>
        private void ExeStateAtCountEnd()
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].ExeCountEndState(i);
            }
            for (int i = 0; i < enemys.Count; i++)
            {
                enemys[i].ExeCountEndState(i);
            }
        }
        /// <summary>
        /// 所有状态，每回合自动减去状态持续回合数1
        /// </summary>
        private void StateCountDec()
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].StateCountDec();
            }
            for (int i = 0; i < enemys.Count; i++)
            {
                enemys[i].StateCountDec();
            }
        }

        /// <summary>
        /// 清楚回合数为0的状态
        /// </summary>
        private void ClearUpState()
        {
            foreach (BaseCharacter player in players)
            {
                player.CleanUpState();
            }
            foreach (BaseCharacter enery in enemys)
            {
                enery.CleanUpState();
            }
        }
        /// <summary>
        /// 检查游戏是否已经结束
        /// </summary>
        /// <returns></returns>
        private bool IsGameOver()
        {
            if (IsAllDead(enemys))
            {
                MyDraw.DrawBattleMessage("敌人全灭，玩家胜利！");
                return true;
            }
            if (IsAllDead(players))
            {
                MyDraw.DrawBattleMessage("玩家全灭，战斗失败！");
                return true;
            }
            return false;
        }

        private bool IsAllDead(List<BaseCharacter> bcList)
        {
            bool isAllDead = true;
            foreach (BaseCharacter b in bcList)
            {
                if (b.Hp > 0)
                {
                    isAllDead = false;
                }
            }
            return isAllDead;
        }
        /// <summary>
        /// 玩家开始行动
        /// </summary>
        private void PlayerAction()
        {
            for(int i = 0; i<players.Count; i++)
            {
                if (players[i].Hp <= 0 || players[i].IsDizzy())
                {
                    //混乱的，也不能行动
                    continue;
                }

                actionIndex = i;
                textPos.Clear();
                

            }
        }

        private void EnemyAction()
        {
        }


        private int GetRandomAttackerTarget(BaseCharacter attacker, Skill s, List<BaseCharacter> bcList)
        {
            int temp = 0;
            int tempHp = bcList[0].Hp;
            //选取血量最多的目标
            if (attacker.actionType == ActionMode.MaxHP)
            {
                for (int i = 0; i < bcList.Count; i++)
                {
                    if (!bcList[i].CanBeTarget(s))
                        continue;
                    if (bcList[i].Hp > tempHp)
                    {
                        temp = i;
                        tempHp = bcList[i].Hp;
                    }
                }
                return temp;
            }
            //选取血量最少的目标
            else if (attacker.actionType == ActionMode.MinHP)
            {
                for (int i = 0; i < bcList.Count; i++)
                {
                    if (!bcList[i].CanBeTarget(s))
                        continue;
                    if (bcList[i].Hp < tempHp)
                    {
                        temp = i;
                        tempHp = bcList[i].Hp;
                    }
                }
                return temp;
            }
            else
            {
                List<int> tempList = new List<int>();
                for (int i = 0; i < bcList.Count; i++)
                {
                    if (bcList[i].CanBeTarget(s))
                        tempList.Add(i);
                }
                return tempList[Program.random.Next(0, tempList.Count)];
            }
        }

        /// <summary>
        /// 选择需要恢复的角色
        /// </summary>
        /// <param name="s"></param>
        /// <param name="bcList"></param>
        /// <returns></returns>
        private int GetHealTarget(Skill s, List<BaseCharacter> bcList)
        {
            int temp = 0;
            int tempHp = bcList[0].Hp;
            for (int i = 0; i < bcList.Count; i++)
            {
                if (!bcList[i].CanBeTarget(s))
                    continue;
                if (bcList[i].Hp < tempHp)
                {
                    temp = i;
                    tempHp = bcList[i].Hp;
                }
            }
            return temp;
        }

        private void SetSkillPos()
        {
            textPos.Clear();
            int len = 0;
            for (int i = 0; i < players[actionIndex].skill.Count; i++)
            {
                textPos.Add(len);
                len += MyDraw.GetLength((1 + i) + "." + players[actionIndex].skill[i].name + "  ");
            }
        }

        private void SetEnemyPos()
        {
            textPos.Clear();
            int len = 0;
            for (int i = 0; i < enemys.Count; i++)
            {
                textPos.Add(len);
                len += MyDraw.GetLength((1 + i) + "." + enemys[i].Name + "  ");
            }
        }

        private void SetPartyPos()
        {
            textPos.Clear();
            int len = 0;
            for (int i = 0; i < players.Count; i++)
            {
                textPos.Add(len);
                len += MyDraw.GetLength((1 + i) + "." + players[i].Name + "  ");
            }
        }

        /// <summary>
        /// 绘制玩家的所有技能名
        /// </summary>
        private void DrawPlayerSkills()
        {
            for (int i = 0; i < players[actionIndex].skill.Count; i++)
            {
                MyDraw.DrawChoiceText(i, players[actionIndex].skill[i].name, textPos[i]);
            }
        }
        /// <summary>
        /// 绘制怪物的名字
        /// </summary>
        private void DrawEnemy()
        {
            for (int i = 0; i < enemys.Count; i++)
            {
                MyDraw.DrawChoiceText(i, enemys[i].Name, textPos[i]);
            }
        }

        private void DrawParty()
        {
            for (int i = 0; i < players.Count; i++)
            {
                MyDraw.DrawChoiceText(i, players[i].Name, textPos[i]);
            }
        }

        /// <summary>
        /// 等待用户选择技能，选择不同的技能，会显示对应的技能介绍
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GetSkillChoice(BaseCharacter b)
        {
            int temp = 0;
            //默认显示第一个技能
            MyDraw.DrawChoiced(temp, b.skill[temp].name, textPos[temp]);
            MyDraw.DrawChoiceInfo(b.skill[temp]);
            bool enter = false;
            while (!enter)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                //选择←
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (temp > 0)
                    {
                        //清空技能介绍
                        MyDraw.ClearLine(21);
                        //显示对应技能选中的颜色效果
                        MyDraw.DrawChoiceText(temp, b.skill[temp].name, textPos[temp]);
                        temp = temp - 1;
                        //显示左边的技能和对应介绍
                        MyDraw.DrawChoiced(temp, b.skill[temp].name, textPos[temp]);
                        MyDraw.DrawChoiceInfo(b.skill[temp]);
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (temp < textPos.Count - 1)
                    {
                        MyDraw.ClearLine(21);
                        MyDraw.DrawChoiceText(temp, b.skill[temp].name, textPos[temp]);
                        temp = temp + 1;
                        MyDraw.DrawChoiced(temp, b.skill[temp].name, textPos[temp]);
                        MyDraw.DrawChoiceInfo(b.skill[temp]);
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (b.skill[temp].CanUseSkill(b))
                    {
                        //选中技能之后，清楚技能信息
                        MyDraw.ClearChoiceText();
                        break;
                    }
                }
            }
            
            return temp;
        }


    }
}
