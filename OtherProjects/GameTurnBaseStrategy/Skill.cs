using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTurnBaseStrateg
{
    class Skill
    {
        //计算最终a对b造成的伤害
        internal delegate int SkillDamage(BaseCharacter a, BaseCharacter b);

        internal delegate void SkillEffect(BaseCharacter a, BaseCharacter b);

        public string name;

        public SkillType type;
        public TargetType targetType;
        public DamageType damageType;
        /// 使用技能需要的HP
        public int hpCost = 0;
        /// 使用技能需要的MP
        public int mpCost = 0;
        /// 释放一次技能的攻击次数或恢复次数
        public int hitTimes = 1;
        /// <summary>
        /// 技能伤害的离散度
        /// </summary>
        public int dispersion = 0;
        /// 技能是否能对自己释放
        public bool self = false;
        /// 是否可以对死亡角色使用
        public bool canDeath = false;
        /// 技能是否包含即死效果
        public bool isDeathNow = false;
        public int deathRatio = 0;/// 即死概率
        /// 技能是否必定命中
        public bool noMiss = false;
        /// 技能是否必定暴击
        public bool mustCrit = false;
        /// 技能描述，包括消耗和效果
        public string description = "";
        /// 技能的效果计算公式，damage和heal都可以使用
        public SkillDamage skillDamage = null;
        /// 技能附加的状态效果
        public SkillEffect skillEffect = null;
        /// <summary>
        /// 判断某个角色是否可以使用技能
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public bool CanUseSkill(BaseCharacter attacker)
        {
            if (attacker.Hp <= hpCost || attacker.Mp < mpCost)
            {
                MyDraw.DrawBattleMessage("无法使用技能：Hp或者mp不满足技能的最小消耗！");
                return false;
            }
            if (attacker.IsSilence() && type != SkillType.NormalAttack)
            {
                MyDraw.DrawBattleMessage(attacker.Name + " 无法使用技能: 被沉默了！");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 群体释放技能
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="attack_index">第几个攻击者</param>
        /// <param name="targets"></param>
        public void UseSkillMulti(BaseCharacter attacker, int attack_index,
            List<BaseCharacter> targets)
        {
            //TODO:
        }
        /// <summary>
        /// 释放单体技能
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="attack_index"></param>
        /// <param name="target"></param>
        public void UseSkillSingle(BaseCharacter attacker, int att_index, BaseCharacter target, int tar_index)
        {
            attacker.Hp -= hpCost;
            attacker.Mp -= mpCost;
            UseSkill(attacker, att_index, target, tar_index);
            if (type == SkillType.Damage)
            {
                if (skillDamage != null)
                {
                    if (damageType == DamageType.Magic)
                    {
                        attacker.IncreaseStateDec(StateType.MagicDamageIncrease);
                        target.IncreaseStateDec(StateType.MagicBeDamageIncrease);
                    }
                    else if (damageType == DamageType.Physical)
                    {
                        attacker.IncreaseStateDec(StateType.PhysicalDamageIncrease);
                        target.IncreaseStateDec(StateType.PhysicalBeDamageIncrease);
                    }
                }
            }
            MyDraw.DrawState(attacker, att_index);
            MyDraw.DrawState(target, tar_index);
        }


        /// <summary>
        /// 使用技能的最底层实现方法，用于其他方法调用
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="attack_index"></param>
        /// <param name="target"></param>
        /// <param name="target_index"></param>
        private void UseSkill(BaseCharacter attacker,
            int attack_index,
            BaseCharacter target,
            int target_index)
        {
            //过程中生存游戏提示信息的文本
            string text = "";
            int tempdamage = 0;
            MyDraw.DrawCharacterInfo(attacker, attack_index);
            text = string.Format("{0}对{1}施放了{2}", attacker.Name, target.Name, name);
            MyDraw.DrawBattleMessageDelay(text);
            if (targetType == TargetType.EnemyMulti || targetType == TargetType.EnemySingle)
            {
                if (attacker.type == CharacterType.Player)
                    MyDraw.DrawAttackAnimation(attacker, attack_index, target, target_index);
                else
                    MyDraw.DrawAttackAnimationEnemy(attacker, attack_index, target, target_index);
            }
            //对即时伤害的技能的处理
            if (type == SkillType.Damage || type == SkillType.NormalAttack)
            {
                //获取技能的基础伤害值
                if (skillDamage != null)
                {
                    tempdamage = skillDamage.Invoke(attacker, target);
                    //判断目标是否无敌
                    if (target.IsInvincible())
                    {
                        return;
                    }
                    //判断目标是否具有技能伤害类型对应的反射状态
                    if (damageType == DamageType.Physical)
                    {
                        if (target.IsPhysicalReflect())
                        {
                            if (target.type == CharacterType.Player)
                                MyDraw.DrawAttackAnimation(target, attack_index, attacker, target_index);
                            else
                                MyDraw.DrawAttackAnimationEnemy(target, attack_index, attacker, target_index);
                            if (attacker.IsInvincible())
                            {
                                return;
                            }
                            else
                            {
                                //获取攻击方的物理攻击加深BUFF并且计算他们的效果
                                tempdamage = attacker.GetIncreaseDamage(tempdamage, StateType.PhysicalDamageIncrease);
                                //因为目标由有物理反射，所以也要计算攻击方自身是否有 受物理攻击加深BUFF
                                tempdamage = attacker.GetIncreaseDamage(tempdamage, StateType.PhysicalBeDamageIncrease);

                                attacker.GetDamage(tempdamage, attack_index);
                                return;
                            }
                        }
                        if (!IsHit(attacker) && noMiss == false)
                        {
                            text = string.Format("{0}未能击中目标！", attacker.Name);
                            MyDraw.DrawBattleMessageDelay(text);
                            return;
                        }
                        if (IsCrit(attacker) || mustCrit == true)
                        {
                            text = string.Format("{0}触发了会心一击！", attacker.Name);
                            MyDraw.DrawBattleMessageDelay(text);
                            tempdamage = tempdamage * 15 / 10;
                        }
                        //获取攻击方的物理攻击加深BUFF并且计算他们的效果
                        tempdamage = attacker.GetIncreaseDamage(tempdamage, StateType.PhysicalDamageIncrease);
                        //计算目标自身是否有 受物理攻击加深BUFF
                        tempdamage = target.GetIncreaseDamage(tempdamage, StateType.PhysicalBeDamageIncrease);
                    }
                    else if (damageType == DamageType.Magic)
                    {
                        if (target.IsMagicReflect())
                        {
                            if (target.type == CharacterType.Player)
                                MyDraw.DrawAttackAnimation(target, target_index, attacker, attack_index);
                            else
                                MyDraw.DrawAttackAnimationEnemy(target, target_index, attacker, attack_index);
                            if (attacker.IsInvincible())
                            {
                                return;
                            }
                            else
                            {
                               
                                tempdamage = attacker.GetIncreaseDamage(tempdamage, StateType.MagicDamageIncrease);
                                tempdamage = attacker.GetIncreaseDamage(tempdamage, StateType.MagicBeDamageIncrease);
                                attacker.GetDamage(tempdamage, attack_index);
                                return;
                            }
                        }
                        else
                        {
                           
                            tempdamage = attacker.GetIncreaseDamage(tempdamage, StateType.MagicDamageIncrease);
                            tempdamage = target.GetIncreaseDamage(tempdamage, StateType.MagicBeDamageIncrease);
                        }
                    }

                    //进行即时伤害并且生成对应的文字信息
                    for (int t = 0; t < hitTimes; t++)
                    {
                        int realdamage = Convert.ToInt32(tempdamage + tempdamage * Program.random.Next(-dispersion, dispersion) * 0.01);
                        //处理即死效果
                        if (isDeathNow)
                        {
                            if (Program.random.Next(0, 100) < deathRatio)
                            {
                                MyDraw.DrawBattleMessageDelay("触发了即死效果。");
                                realdamage = target.MaxHp;
                            }
                        }
                        if (!target.GetDamage(realdamage, target_index))
                        {
                            break;
                        }
                    }
                }
                //如果技能有特殊效果，执行特殊效果
                if (skillEffect != null)
                {
                    MyDraw.DrawEffectAnimation(target, target_index);
                    skillEffect.Invoke(attacker, target);
                    MyDraw.DrawState(target, target_index);
                }
                return;
            }

            //对即时回复类技能的处理
            if (type == SkillType.Heal)
            {
                if (skillDamage != null)
                {
                    tempdamage = skillDamage.Invoke(attacker, target);
                    if (!target.IsForbidHeal())
                    {
                        target.GetRecover(tempdamage, target_index);
                    }
                }
                if (skillEffect != null)
                {
                    MyDraw.DrawEffectAnimation(target, target_index);
                    skillEffect.Invoke(attacker, target);
                    
                    MyDraw.DrawState(target, target_index);
                }
                return;
            }

            //对状态类技能的处理，主要是Buff,Debuff等
            if (type == SkillType.State)
            {
                if (skillEffect != null)
                {
                    MyDraw.DrawEffectAnimation(target, target_index);
                    skillEffect.Invoke(attacker, target);
                    MyDraw.DrawState(target, target_index);
                }
            }
            return;
        }
        /// <summary>
        /// 当前攻击对象是否可以命中对手
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool IsHit(BaseCharacter one)
        {
            int temp = Program.random.Next(1, 101);
            if (temp > one.HitRatio)
                return false;
            return true;
        }
        /// <summary>
        /// 是否出现暴击
        /// </summary>
        /// <param name="one"></param>
        /// <returns></returns>
        public bool IsCrit(BaseCharacter one)
        {
            int temp = Program.random.Next(1, 101);
            if (temp < one.CriticalChance)
                return true;
            return false;
        }

    }
}
