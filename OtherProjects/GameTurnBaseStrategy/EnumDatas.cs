using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTurnBaseStrateg
{
    //技能分类
    public enum SkillType
    {

        Damage,
        Heal,//恢复技能
        State,//各种buff技能
        NormalAttack
    }
    //技能释放的目标类型
    public enum TargetType
    {
        PartySingle,
        PartyMulti,
        EnemySingle,
        EnemyMulti,
        Self
    }
    //状态类型
    public enum StateType
    {
        DamageOverTime,
        HealOverTime,
        PhysicalReflect,
        MagicReflect,
        Revive,
        Buff,
        Debuff,
        /// 无敌状态
        Invincible,
        /// 沉默状态
        Silence,
        PhysicalDamageIncrease,
        PhysicalBeDamageIncrease,
        MagicDamageIncrease,
        MagicBeDamageIncrease,
        Dizzy,
        ForbidHeal,
        Taunt,
    }

    public enum CharacterType
    {
        /// 玩家
        Player,
        /// 怪物
        Enemy,
    }
    public enum DamageType
    {
        Physical,
        Magic
    }
    /// <summary>
    /// enemy进行攻击的模式
    /// </summary>
    public enum ActionMode
    {
        MaxHP,
        MinHP,
        Normal
    }


    class EnumDatas
    {

    }
}
