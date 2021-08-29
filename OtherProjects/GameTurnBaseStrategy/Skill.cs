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
        public void useSkillSingle(BaseCharacter attacker, int attack_index, BaseCharacter target)
        {
            //TODO:
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
            //TODO:
        }
        /// <summary>
        /// 当前攻击对象是否可以命中对手
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool IsHit(BaseCharacter one)
        {
            //TODO:
            return false;
        }
        /// <summary>
        /// 是否出现暴击
        /// </summary>
        /// <param name="one"></param>
        /// <returns></returns>
        public bool IsCrit(BaseCharacter one)
        {
            //TODO:
            return false;
        }

    }
}
