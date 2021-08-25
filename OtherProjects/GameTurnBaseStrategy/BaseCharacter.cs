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
        ///魔法防御
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
                    if (s.times > 0)
                    {
                        s.times -= 1;  
                    }
                    temp = true;

                }
                if (temp)
                    CleanUpState();
                return temp;
            }
        }

        /// <summary>
        /// 清理角色的次数和回合数为一的状态0
        /// </summary>
        public void CleanUpState()
        {

        }

        public void ResetState()
        {
            state.Clear();
        }




    }
}