using System;
using System.Collections.Generic;

namespace GameTurnBaseStrateg
{
    //角色
    class BaseCharacter
    {
        internal delegate Skill EnemyAction(BaseCharacter bc, List<BaseCharacter> bcList, int counts);
        public string Name { get; set; }
        public int Level { get; set; }
        /// <summary>
        /// 最大血量
        /// </summary>
        public int MaxHp { get; set; }
        /// <summary>
        /// 最大蓝
        /// </summary>
        public int MaxMp { get; set; }
        /// <summary>
        /// 当前血 红
        /// </summary>
        public int Hp { get; set; }
        /// <summary>
        /// 当前魔法 蓝
        /// </summary>
        public int Mp { get; set; }
        /// <summary>
        /// 物理攻击
        /// </summary>
        public int Atk { get; set; }

        ///物理防御
        public int Def { get; set; }
        ///魔法攻击
        public int Mat { get; set; }

        ///<summary>
        ///魔法防御
        ///</summary>
        public int Men { get; set; }
        ///命中率
        public int HitRatio { get; set; }
        ///暴击率
        public int CriticalChance { get; set; }

        public CharacterType type;

        public ActionMode actionType = ActionMode.Normal;
        //若type为Enemy，则该方法表示获取一个技能
        public EnemyAction GetRandomSkill = null;
        /// <summary>
        /// 拥有多个技能
        /// </summary>
        public List<Skill> skill = new List<Skill>();
        /// <summary>
        /// 拥有多个状态
        /// </summary>
        public List<State> state = new List<State>();

        /// <summary>
        /// 判断角色是否包含某种状态类型
        /// </summary>
        /// <param name="stateType"></param>
        /// <returns></returns>
        public bool HasState(StateType stateType)
        {
            foreach (State s in state)
            {
                if (s.type == stateType)
                {
                    return true;
                }
            }
            return false;
        }
        ///是否具有无敌状态
        public bool IsInvincible()
        {
            bool temp = false;
            foreach (State s in state)
            {
                if (s.type == StateType.Invincible)
                {
                    MyDraw.DrawBattleMessageDelay(Name + " 伤害无效: 当前无敌！");
                    if (s.times > 0)
                    {
                        s.times -= 1;  
                    }
                    temp = true;

                }
               
            }
            if (temp)
                CleanUpState();
            return temp;
        }

        public bool IsSilence()
        {
            bool temp = false;
            foreach (State s in state)
            {
                if (s.type == StateType.Silence)
                {
                    MyDraw.DrawBattleMessageDelay(Name + " 无法释放技能：处于沉默状态！");
                    if (s.times > 0)
                    {
                        s.times -= 1;
                    }
                    temp = true;
                }
            }
            if (temp)
                CleanUpState();
            return temp;
        }

        /// <summary>
        /// 判断角色是否具有物理反射
        /// </summary>
        /// <returns></returns>
        public bool IsPhysicalReflect()
        {
            bool temp = false;
            foreach (State s in state)
            {
                if (s.type == StateType.PhysicalReflect)
                {
                    MyDraw.DrawBattleMessageDelay(Name + " 攻击被弹回: 处于物理反射状态！");
                    if (s.times > 0)
                    {
                        s.times -= 1;
                    }
                    temp = true;
                }
            }
            if (temp)
                CleanUpState();
            return temp;
        }

        /// <summary>
        /// 判断角色是否具有魔法反射
        /// </summary>
        /// <returns></returns>
        public bool IsMagicReflect()
        {
            bool temp = false;
            foreach (State s in state)
            {
                if (s.type == StateType.MagicReflect)
                {
                    MyDraw.DrawBattleMessageDelay(Name + " 魔法被弹回:处于魔法反射状态");
                    if (s.times > 0)
                    {
                        s.times -= 1;
                    }
                    temp = true;
                }
            }
            if (temp)
                CleanUpState();
            return temp;
        }
        public bool IsRevive()
        {
            bool temp = false;
            foreach (State s in state)
            {
                if (s.type == StateType.Revive)
                {
                    MyDraw.DrawBattleMessageDelay(Name + "处于复活状态，重新恢复！");
                    Hp = s.hprecover;
                    if (s.times > 0)
                    {
                        s.times -= 1;
                    }
                    temp = true;
                }
            }
            if (temp)
                CleanUpState();
            return temp;
        }

        public bool IsDizzy()
        {
            bool temp = false;
            foreach (State s in state)
            {
                if (s.type == StateType.Dizzy)
                {
                    MyDraw.DrawBattleMessageDelay(Name + "处于" + s.name + " 混乱状态中，无法行动！");
                    if (s.times > 0)
                    {
                        s.times -= 1;
                    }
                    temp = true;
                }
            }
            if (temp)
                CleanUpState();
            return temp;
        }

        public bool IsForbidHeal()
        {
            bool temp = false;
            foreach (State s in state)
            {
                if (s.type == StateType.ForbidHeal)
                {
                    MyDraw.DrawBattleMessageDelay(Name + "处于" + s.name + "状态中，无法恢复生命值！");
                    if (s.times > 0)
                    {
                        s.times -= 1;
                    }
                    temp = true;
                }
            }
            if (temp)
                CleanUpState();
            return temp;
        }

        public double IsTaunt()
        {
            foreach (State s in state)
            {
                if (s.type == StateType.Taunt)
                {
                    MyDraw.DrawBattleMessageDelay(Name + "处于" + s.name + " 嘲讽状态中！");
                    if (s.times > 0)
                    {
                        s.times -= 1;
                    }
                    return s.ratio;
                }
            }
            return -1.0;
        }


        /// <summary>
        /// 判断角色是否能被当前技能选为目标
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CanBeTarget(Skill s)
        {
            if (Hp > 0)
                return true;
            else
            {
                if (s.canDeath)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 添加一个状态
        /// </summary>
        /// <param name="s"></param>
        public void AddState(State s)
        {
            int i = 0;
            for (; i < state.Count; i++)
            {
                if (state[i].name == s.name && state[i].skillName == s.skillName)
                {
                    state[i].times = s.times;
                    state[i].counts = s.counts;
                    MyDraw.DrawBattleMessageDelay(Name + "的" + s.name + "状态持续时间延长！");
                    return;
                }
            }
            s.AddState?.Invoke(this);
            state.Add(s);
            MyDraw.DrawBattleMessageDelay(Name + "获得了" + s.name + "状态");
        }


        /// <summary>
        /// 移除一个状态
        /// </summary>
        /// <param name="s"></param>
        public void RemoveState(State s)
        {
            int i = 0;
            for (; i < state.Count; i++)
            {
                if (state[i].name == s.name && state[i].skillName == s.skillName)
                {
                    state[i]?.RemoveState(this);
                    state.RemoveAt(i);
                    MyDraw.DrawBattleMessageDelay(Name + "失去了" + s.name + "状态");
                    break;
                }
            }
        }

        /// <summary>
        /// 执行HOT效果
        /// </summary>
        /// <param name="index"></param>
        public void ExeCountStartState(int index)
        {
            foreach (State s in state)
            {
                if (s.type != StateType.DamageOverTime && s.type != StateType.HealOverTime)
                    continue;
                string text = string.Format("因为{0}的效果！", s.name);
                if (s.type == StateType.HealOverTime)
                {
                    if (s.times == 0 && s.counts == 0)
                        continue;
                    if (s.times > 0)
                    {
                        s.times--;
                    }
                    MyDraw.DrawBattleMessage(text);
                    if (!IsForbidHeal())
                        GetRecover(s.hprecover, index);
                }
            }
        }

        /// <summary>
        /// 执行DOT效果
        /// </summary>
        /// <param name="index"></param>
        public void ExeCountEndState(int index)
        {
            foreach (State s in state)
            {
                if (s.type != StateType.DamageOverTime && s.type != StateType.HealOverTime)
                    continue;
                string text = string.Format("因为{0}的效果！", s.name);
                if (s.type == StateType.DamageOverTime)
                {
                    if (s.times == 0 && s.counts == 0)
                        continue;
                    if (s.times > 0)
                    {
                        s.times--;
                    }
                    MyDraw.DrawBattleMessage(text);
                    if (!IsInvincible())
                        GetDamage(s.damage, index);
                }
            }
        }

        /// <summary>
        /// 对与持续回合类的状态，持续回合减1
        /// </summary>
        public void StateCountDec()
        {
            foreach (State s in state)
            {
                if (s.counts > 0)
                    s.counts--;
            }
        }
        /// <summary>
        /// 清理角色的次数和回合数为一的状态0
        /// </summary>
        public void CleanUpState()
        {
            List<int> list = new List<int>();
            for (int i = state.Count - 1; i >= 0; i--)
            {
                if (state[i].counts == 0 && state[i].times == 0)
                {
                    list.Add(i);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                string text = string.Format("{0}失去了{1}状态", Name, state[list[i]].name);
                MyDraw.DrawBattleMessageDelay(text);
                state.RemoveAt(list[i]);
            }
        }

        public void ResetState()
        {
            state.Clear();
        }

        /// <summary>
        /// 角色受到伤害
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetDamage(int damage, int index)
        {
            MyDraw.DrawDamageAnimation(this, index);
            int tempDamage = 0;
            if (Hp >= damage)
            {
                tempDamage = damage;
                Hp -= damage;
            }
            else
            {
                tempDamage = Hp;
                Hp = 0;
            }
            string text = string.Format("{0}受到了{1}点伤害", Name, tempDamage);
            MyDraw.DrawCharacterInfo(this, index);
            MyDraw.DrawBattleMessageDelay(text);
            if (!IsAlive())
            {
                if (!IsRevive())
                {
                    MyDraw.DrawBattleMessageDelay(Name + "死亡了");
                    ResetState();
                }
                MyDraw.DrawCharacterInfo(this, index);
            }
            return IsAlive();
        }

        /// <summary>
        /// 角色受到的恢复量
        /// </summary>
        /// <param name="recover"></param>
        /// <param name="index"></param>
        public void GetRecover(int recover, int index)
        {
            MyDraw.DrawEffectAnimation(this, index);
            int tempRecover = 0;
            if (MaxHp <= recover + Hp)
            {
                tempRecover = MaxHp - Hp;
                Hp = MaxHp;
            }
            else
            {
                tempRecover = recover;
                Hp += tempRecover;
            }
            string text = string.Format("{0}恢复了{1}点生命值", Name, tempRecover);
            MyDraw.DrawCharacterInfo(this, index);
            MyDraw.DrawBattleMessageDelay(text);
        }

        /// <summary>
        /// 获取指定状态的伤害加成
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="stateType"></param>
        /// <returns></returns>
        public int GetIncreaseDamage(int damage, StateType stateType)
        {
            int tempDamage = damage;
            foreach (State s in state)
            {
                if (s.type == stateType)
                {
                    if (s.counts > 0 || s.times > 0)
                        tempDamage = Convert.ToInt32(tempDamage * (1 + s.ratio));
                }
            }
            return tempDamage;
        }
        /// <summary>
        /// 指定状态的持续时间减1
        /// </summary>
        /// <param name="stateType"></param>
        public void IncreaseStateDec(StateType stateType)
        {
            foreach (State s in state)
            {
                if (s.type == stateType)
                {
                    if (s.times > 0)
                    {
                        s.times--;
                    }
                }
            }
        }
        public bool IsAlive()
        {
            if (Hp == 0)
                return false;
            return true;
        }



    }
}