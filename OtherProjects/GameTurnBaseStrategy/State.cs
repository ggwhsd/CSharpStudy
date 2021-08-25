using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTurnBaseStrateg
{
    /*
     * 游戏中的各种状态（buff）
     */
    class State
    {
        //状态对应效果
        public delegate void StateEffect(BaseCharacter a);
        //状态名称
        public string name;
        //状态由哪个技能生成
        public string skillName;
        //状态生效次数,回合数是客观时间，次数是根据触发情况而来,比如由的buff持续五回合，但是只要触发一次就失效
        public int times = 0;
        //状态生效回合数
        public int counts = 0;

        public int damage = 0;

        public int hprecover = 0;

        public double ratio = 0;
        //物理攻击力提升点数
        public int atkUp = 0;
        //魔法攻击提升
        public int matUp = 0;
        //物理防御提升
        public int defUp = 0;
        //魔法防御提升
        public int menUp = 0;
        //表示当前的状态属于的状态类型
        public StateType type;
        //第一次执行状态时调用
        public StateEffect AddState = null;
        //移除该状态时调用
        public StateEffect RemoveState = null;





    }
}
