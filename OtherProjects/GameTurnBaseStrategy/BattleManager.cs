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
                ExeStateAtCountStart();
                PlayerAction();
                EnemyAction();
                ExeStateAtCountEnd();
                StateCountDec();
                if (IsGameOver())
                {
                    break;
                }
                gameCounts++;
                ClearUpState();
                MyDraw.DrawIntroText("按任意建进入下一回合");
                Console.ReadKey(true);
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
                SetSkillPos();
                DrawPlayerSkills();
                MyDraw.DrawIntroText($"当前回合为{players[actionIndex].Name}行动了，请选择指令：");
                tempSkill = players[actionIndex].skill[GetSkillChoice(players[actionIndex])];
                MyDraw.DrawBattleMessage(players[actionIndex].Name + "选择了技能 " + tempSkill.name);
                //技能一共作用对象为5种：单个敌人、多个敌人、单个队友、多个队友、只能自身
                
                if (tempSkill.targetType == TargetType.EnemySingle)
                {
                    MyDraw.DrawIntroText("请选择目标：");
                    
                    SetEnemyPos();
                    DrawEnemy();

                    chooseEnemyIndex = GetEnemyChoice();
                    if (chooseEnemyIndex == -1)
                    {
                        i--;
                        continue;
                    }
                    tempSkill.UseSkillSingle(players[actionIndex], actionIndex, enemys[chooseEnemyIndex], chooseEnemyIndex);
                }
                if (tempSkill.targetType == TargetType.EnemyMulti)
                {
                    tempSkill.UseSkillMulti(players[actionIndex], actionIndex, enemys);
                }
                if (tempSkill.targetType == TargetType.PartySingle)
                {
                    MyDraw.DrawIntroText("请选择目标：");
                    SetPartyPos();
                    DrawParty();
                    choosePartyIndex = GetPartyChoice();
                    if (choosePartyIndex == -1)
                    {
                        i--;
                        continue;
                    }
                    tempSkill.UseSkillSingle(players[actionIndex], actionIndex, players[choosePartyIndex], choosePartyIndex);
                }
                if (tempSkill.targetType == TargetType.PartyMulti)
                {
                    tempSkill.UseSkillMulti(players[actionIndex], actionIndex, players);
                }
                if (tempSkill.targetType == TargetType.Self)
                {
                    tempSkill.UseSkillSingle(players[actionIndex], actionIndex, players[actionIndex], actionIndex);
                }
                textPos.Clear();
            }
        }

        private void EnemyAction()
        {
            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i].Hp == 0 || enemys[i].IsDizzy())
                    continue;
                Skill temp = enemys[i].GetRandomSkill(enemys[i], enemys, gameCounts);
                if (temp.targetType == TargetType.Self)
                {
                    temp.UseSkillSingle(enemys[i], i, enemys[i], i);
                }
                if (temp.targetType == TargetType.EnemySingle)
                {
                    int target = GetRandomAttackerTarget(enemys[i], temp, players);
                    //处理嘲讽状态
                    for (int j = 0; j < players.Count; j++)
                    {
                        double tauntRatio = players[j].IsTaunt();
                        if (players[j].Hp > 0 && tauntRatio != -1.0)
                        {
                            if (tauntRatio > Program.random.NextDouble())
                            {
                                target = j;
                                MyDraw.DrawBattleMessageDelay(string.Format("{0}处于嘲讽状态下，敌人的攻击转了过去。", players[j].Name));
                            }
                            break;
                        }
                    }
                    temp.UseSkillSingle(enemys[i], i, players[target], target);
                }
                if (temp.targetType == TargetType.EnemyMulti)
                {
                    temp.UseSkillMulti(enemys[i], i, players);
                }
                if (temp.targetType == TargetType.PartySingle)
                {
                    int target = 0;
                    if (temp.type == SkillType.Heal)
                        target = GetHealTarget(temp, enemys);
                    else
                        target = GetRandomAttackerTarget(enemys[i], temp, enemys);
                    temp.UseSkillSingle(enemys[i], i, enemys[target], target);
                }
                if (temp.targetType == TargetType.PartyMulti)
                {
                    temp.UseSkillMulti(enemys[i], i, enemys);
                }
            }
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

        /// <summary>
        /// 设置当前玩家拥有的所有skill的名称长度形成的数组,后续用于计算显示技能的位置
        /// </summary>
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
        /// <summary>
        /// 为了一行显示所有怪物的名字，这里先计算好每个名字的长度
        /// </summary>
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

        public int GetEnemyChoice()
        {
            int temp = 0;
            MyDraw.DrawChoiced(temp, enemys[temp].Name, textPos[temp]);
            bool enter = false;
            while (!enter)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (temp > 0)
                    {
                        MyDraw.ClearLine(21);
                        MyDraw.DrawChoiceText(temp, enemys[temp].Name, textPos[temp]);
                        temp = temp - 1;
                        MyDraw.DrawChoiced(temp, enemys[temp].Name, textPos[temp]);
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (temp < textPos.Count - 1)
                    {
                        MyDraw.ClearLine(21);
                        MyDraw.DrawChoiceText(temp, enemys[temp].Name, textPos[temp]);
                        temp = temp + 1;
                        MyDraw.DrawChoiced(temp, enemys[temp].Name, textPos[temp]);
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (enemys[temp].CanBeTarget(tempSkill))
                    {
                        MyDraw.ClearChoiceText();
                        break;
                    }
                    else
                    {
                        MyDraw.DrawBattleMessage("无法选择已经死亡的目标，请重新选择");
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    MyDraw.ClearLine(1);
                    return -1;
                }
            }
            return temp;
        }


        public int GetPartyChoice()
        {
            int temp = 0;
            MyDraw.DrawChoiced(temp, players[temp].Name, textPos[temp]);
            bool enter = false;
            while (!enter)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (temp > 0)
                    {
                        MyDraw.ClearLine(21);
                        MyDraw.DrawChoiceText(temp, players[temp].Name, textPos[temp]);
                        temp = temp - 1;
                        MyDraw.DrawChoiced(temp, players[temp].Name, textPos[temp]);
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (temp < textPos.Count - 1)
                    {
                        MyDraw.ClearLine(21);
                        MyDraw.DrawChoiceText(temp, players[temp].Name, textPos[temp]);
                        temp = temp + 1;
                        MyDraw.DrawChoiced(temp, players[temp].Name, textPos[temp]);
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (players[temp].CanBeTarget(tempSkill))
                    {
                        MyDraw.ClearChoiceText();
                        break;
                    }
                    else
                    {
                        MyDraw.DrawBattleMessage("无法选择已经死亡的目标，请重新选择");
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    MyDraw.ClearLine(1);
                    return -1;
                }
            }
            return temp;
        }
    }
}
