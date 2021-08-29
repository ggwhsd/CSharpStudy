using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTurnBaseStrateg
{
    /// <summary>
    /// 创建技能、创建人物对象,
    /// 每个人物角色都由四个技能：
    ///     1.一个无消耗的普通攻击，战士为物理攻击，法师为魔法攻击。
    ///     2.三个消耗MP或者HP的特殊技能。
    /// </summary>
    class DataManager
    {
        /// <summary>
        /// 普通攻击技能
        /// </summary>
        /// <param name="hitTimes"></param>
        /// <param name="dispersion"></param>
        /// <param name="damageType"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static Skill CreateAttackSkill(
            int hitTimes,
            int dispersion,
            DamageType damageType,
            TargetType targetType)
        {
            Skill skill = new Skill();
            skill.name = "攻击";
            skill.hpCost = 0;
            skill.mpCost = 0;
            skill.hitTimes = hitTimes;
            skill.dispersion = dispersion;
            skill.type = SkillType.NormalAttack;
            skill.damageType = damageType;
            skill.targetType = targetType;
            return skill;
        }
        /// <summary>
        /// 创建状态技能
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hpCost"></param>
        /// <param name="mpCost"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Skill CreateStateSkill(
            string name,
            int hpCost,
            int mpCost,
            TargetType type
            )
        {
            Skill skill = new Skill();
            skill.name = name;
            skill.hpCost = hpCost;
            skill.mpCost = mpCost;
            skill.type = SkillType.State;
            skill.targetType = type;
            return skill;
        }
        /// <summary>
        /// 创建一个伤害技能
        /// </summary>
        /// <param name="name">技能名字</param>
        /// <param name="hpCost">消耗HP</param>
        /// <param name="mpCost">消耗MP</param>
        /// <param name="damage">伤害值，不为0的时候会覆盖掉effect里的伤害公式</param>
        /// <param name="hitTimes">攻击次数</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="damageType">伤害类型</param>
        public static Skill CreateDamageSkill(
            string name,
            int hpCost,
            int mpCost,
            int hitTimes,
            int dispersion,
            TargetType targetType,
            DamageType damageType
            )
        {
            Skill skill = new Skill();
            skill.name = name;
            skill.hpCost = hpCost;
            skill.mpCost = mpCost;
            skill.hitTimes = hitTimes;
            skill.dispersion = dispersion;
            skill.targetType = targetType;
            skill.damageType = damageType;
            skill.type = SkillType.Damage;
            return skill;
        }

        /// <summary>
        /// 创建一个恢复技能
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hpCost"></param>
        /// <param name="mpCost"></param>
        /// <param name="hitTimes">技能生效的次数</param>
        /// <param name="dispersion">技能的恢复量，不为零的时候会覆盖后面的恢复量公式</param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static Skill CreateHealSkill(
            string name, 
            int hpCost, 
            int mpCost, 
            int hitTimes, 
            int dispersion, 
            TargetType targetType)
        {
            Skill skill = new Skill();
            skill.name = name;
            skill.hpCost = hpCost;
            skill.mpCost = mpCost;
            skill.hitTimes = hitTimes;
            skill.dispersion = dispersion;
            skill.targetType = targetType;
            skill.type = SkillType.Heal;
            return skill;
        }

        /// <summary>
        /// 创建一个buff状态
        /// </summary>
        /// <param name="name"></param>
        /// <param name="times"></param>
        /// <param name="counts"></param>
        /// <returns></returns>
        public static State CreateBuffState(
            string name, 
            int times, 
            int counts)
        {
            State state = new State();
            state.name = name;
            state.times = times;
            state.counts = counts;
            state.type = StateType.Buff;
            return state;
        }

        /// <summary>
        /// 创建一个Debuff状态
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="times">次数</param>
        /// <param name="counts">持续回合</param>
        /// <returns></returns>
        public static State CreateDebuffState(
            string name, 
            int times, 
            int counts)
        {
            State state = new State();
            state.name = name;
            state.times = times;
            state.counts = counts;
            state.type = StateType.Debuff;
            return state;
        }

        /// <summary>
        /// 创建一个DOT持续伤害的类型状态
        /// </summary>
        /// <param name="name"></param>
        /// <param name="times"></param>
        /// <param name="counts"></param>
        /// <param name="damage"></param>
        /// <returns></returns>
        public static State CreateDOTState(
            string name, 
            int times, 
            int counts, 
            int damage)
        {
            State state = new State();
            state.name = name;
            state.times = times;
            state.counts = counts;
            state.damage = damage;
            state.type = StateType.DamageOverTime;
            return state;
        }

        /// <summary>
        /// 创建一个HOT持续治疗类型的状态
        /// </summary>
        /// <param name="name"></param>
        /// <param name="times"></param>
        /// <param name="counts"></param>
        /// <param name="hprecover"></param>
        /// <returns></returns>
        public static State CreateHOTState(
            string name, 
            int times, 
            int counts, 
            int hprecover)
        {
            State state = new State();
            state.name = name;
            state.times = times;
            state.counts = counts;
            state.hprecover = hprecover;
            state.type = StateType.HealOverTime;
            return state;
        }

        /// <summary>
        ///  创建一个特殊状态
        /// </summary>
        /// <param name="name"></param>
        /// <param name="times">该状态使用次数</param>
        /// <param name="counts">该状态持续回合</param>
        /// <returns></returns>
        public static State CreateSpecialState(
            string name, 
            int times, 
            int counts)
        {
            State state = new State();
            state.name = name;
            state.times = times;
            state.counts = counts;
            return state;
        }

        
        /// <summary>
        /// 创建一个伤害提高或减少的状态。
        /// 调用后，在其他方法中会指定State是物理还是魔法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="times"></param>
        /// <param name="counts"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        public static State CreateIncOrDecState(
            string name, 
            int times, 
            int counts, 
            double ratio)
        {
            State state = new State();
            state.name = name;
            state.times = times;
            state.counts = counts;
            state.ratio = ratio;
            return state;
        }


        public static BaseCharacter CreateCharSatsuki()
        {
            //角色的基本属性
            BaseCharacter player = new BaseCharacter();
            player.Name = "五月";
            player.MaxHp = 421;
            player.MaxMp = 196;
            player.Hp = 421;
            player.Mp = 196;
            player.Atk = 42;
            player.Def = 23;
            player.Mat = 17;
            player.Men = 18;
            player.HitRatio = 95;
            player.CriticalChance = 10;
            player.Level = 5;
            player.type = CharacterType.Player;
            //1.统统攻击技能：创建一个单体物理攻击力为10，攻击次数为1的攻击技能
            Skill normalAttack = CreateAttackSkill(1, 10, DamageType.Physical, TargetType.EnemySingle);
            normalAttack.description = "普通攻击，物理伤害。";
            normalAttack.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int temp = attacker.Atk * 2 - target.Def;
                return temp > 0 ? temp : 1;
            };
            player.skill.Add(normalAttack);

            //2.技能：蓄力，消耗MP
            Skill charge = CreateStateSkill("蓄力", 0, 30, TargetType.Self);
            charge.description = "MP【30】：积蓄力量，使得下一次的物理攻击伤害翻倍。";
            charge.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State chargeState = CreateIncOrDecState("伤害提高", 1, 0, 2.0);
                chargeState.type = StateType.PhysicalDamageIncrease;
                chargeState.skillName = charge.name;
                attacker.AddState(chargeState);
            };
            player.skill.Add(charge);

            //消耗MP
            Skill berserker = CreateStateSkill("狂化", 0, 20, TargetType.Self);
            berserker.description = "MP【20】：引发自己的吸血冲动，在3回合内增加物理攻击力，降低物理防御力。";
            berserker.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State berserkerBuff = CreateBuffState("物理攻击力上升", 0, 4);
                berserkerBuff.skillName = berserker.name;
                berserkerBuff.AddState = (BaseCharacter a) =>
                {
                    berserkerBuff.atkUp = a.Atk / 2;
                    a.Atk = a.Atk + berserkerBuff.atkUp;
                };
                berserkerBuff.RemoveState = (BaseCharacter a) =>
                {
                    a.Atk = a.Atk - berserkerBuff.atkUp;
                };
                attacker.AddState(berserkerBuff);
                State berserkerDebuff = CreateBuffState("物理防御力下降", 0, 4);
                berserkerDebuff.skillName = berserker.name;
                berserkerDebuff.AddState = (BaseCharacter a) =>
                {
                    berserkerDebuff.defUp = 0 - a.Def / 2;
                    a.Def = a.Def + berserkerDebuff.defUp;
                };
                berserkerDebuff.RemoveState = (BaseCharacter a) =>
                {
                    a.Def = a.Def - berserkerDebuff.defUp;
                };
                attacker.AddState(berserkerDebuff);
            };
            player.skill.Add(berserker);

            //3.技能：添加技能“BAKA杀”,消耗MP
            Skill bakaKill = CreateDamageSkill("八嘎杀", 0, 30, 3, 20, TargetType.EnemySingle, DamageType.Physical);
            bakaKill.description = "MP【30】：高速的连续攻击，对单个敌人造成3次小幅度的物理伤害。";
            bakaKill.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int temp = (attacker.Atk * 2 - target.Def) * 5 / 10;
                return temp > 0 ? temp : 1;
            };
            player.skill.Add(bakaKill);
            //消耗MP
            Skill drynessGarden = CreateDamageSkill("枯渴庭院", 0, 80, 1, 10, TargetType.EnemyMulti, DamageType.Physical);
            drynessGarden.description = "MP【80】:迅速的抽空大气中的魔力，对敌方全体造成伤害并且减少魔法值。";
            drynessGarden.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                target.Mp = target.Mp - attacker.Atk / 2;
                return attacker.Atk * 3 - target.Def * 2;
            };
            player.skill.Add(drynessGarden);
            return player;

        }

        /// <summary>
        /// 创建角色艾露露，治疗
        /// </summary>
        /// <returns></returns>
        public static BaseCharacter CreateCharEruruu()
        {
            BaseCharacter eruruu = new BaseCharacter();
            eruruu.Name = "艾露露";
            eruruu.MaxHp = 288;
            eruruu.MaxMp = 321;
            eruruu.Hp = 288;
            eruruu.Mp = 321;
            eruruu.Atk = 0;
            eruruu.Def = 17;
            eruruu.Mat = 23;
            eruruu.Men = 27;
            eruruu.HitRatio = 95;
            eruruu.CriticalChance = 10;
            eruruu.Level = 5;
            eruruu.type = CharacterType.Player;

            Skill herb = CreateHealSkill("草药", 0, 15, 1, 10, TargetType.PartySingle);
            herb.description = "MP【15】:艾露露自制的草药，恢复己方单体生命值。";
            herb.skillDamage = new Skill.SkillDamage((BaseCharacter attacker, BaseCharacter target) =>
            {
               
                return attacker.Men * 2;
            });
            eruruu.skill.Add(herb);
            Skill rest = CreateStateSkill("摩洛洛粥", 0, 0, TargetType.Self);
            rest.description = "艾露露为自己准备的家乡的小食，恢复自身的MP值。";
            rest.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int temp = Convert.ToInt32(attacker.Men * 1.34);
                if (attacker.Mp + temp > attacker.MaxMp)
                    temp = attacker.MaxMp - attacker.Mp;
                attacker.Mp += temp;
                MyDraw.DrawCharacterInfo(eruruu, 1);
                MyDraw.DrawBattleMessageDelay(string.Format("艾露露恢复了{0}点魔法值", temp));
            };
            eruruu.skill.Add(rest);

            Skill lilac = CreateHealSkill("花语", 0, 40, 1, 0, TargetType.PartyMulti);
            lilac.description = "艾露露利用山野中的鲜花特质的线香，为己方全体施加生命恢复效果。（MP：40）";
            lilac.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int tempRecover = Convert.ToInt32(attacker.Men * 3.0 / 2);
                State lilacState = CreateHOTState("花语", 0, 3, tempRecover);
                lilacState.skillName = lilac.name;
                target.AddState(lilacState);
            };
            eruruu.skill.Add(lilac);

            Skill mandara = CreateDamageSkill("毒雾", 0, 30, 1, 0, TargetType.EnemyMulti, DamageType.Magic);
            mandara.description = "艾露露利用山中的毒草制成的迷雾攻击敌方全体，一定概率使得敌方中毒。（MP：30）";
            mandara.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int tempRecover = Convert.ToInt32(target.MaxHp * 0.07);
                if (Program.random.Next(0, 100) > 70)
                {
                    State mandaraState = CreateDOTState("中毒", 0, 3, tempRecover);
                    mandaraState.skillName = mandara.name;
                    target.AddState(mandaraState);
                }
            };
            eruruu.skill.Add(mandara);

            Skill callBack = CreateHealSkill("复活", 0, 50, 1, 10, TargetType.PartySingle);
            callBack.description = "艾露露复活一名已经阵亡的队友,恢复其30%HP。（MP：50）";
            callBack.canDeath = true;
            callBack.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                return Convert.ToInt32(target.MaxHp * 0.3);
            };
            eruruu.skill.Add(callBack);

            Skill lifeLoop = CreateHealSkill("子守歌", 0, 60, 1, 20, TargetType.PartyMulti);
            lifeLoop.description = "艾露露唱起小时候听过的子守歌，恢复己方全体的生命值。（MP：60）";
            lifeLoop.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                return Convert.ToInt32(attacker.Mat * 2.3 + 16);
            };
            eruruu.skill.Add(lifeLoop);

            return eruruu;

        }


        /// <summary>
        /// 创建角色玲，魔法师
        /// </summary>
        /// <returns></returns>
        public static BaseCharacter CreateCharRenne()
        {
            BaseCharacter renne = new BaseCharacter();
            renne.Name = "玲";
            renne.MaxHp = 267;
            renne.MaxMp = 352;
            renne.Hp = 267;
            renne.Mp = 352;
            renne.Atk = 10;
            renne.Def = 14;
            renne.Mat = 32;
            renne.Men = 23;
            renne.HitRatio = 90;
            renne.CriticalChance = 5;
            renne.Level = 5;
            renne.type = CharacterType.Player;

            Skill normalAttack = CreateAttackSkill(1, 10, DamageType.Magic, TargetType.EnemySingle);
            normalAttack.description = "普通攻击，魔法伤害。";
            normalAttack.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int temp = attacker.Mat * 2 - target.Men;
                return temp > 0 ? temp : 1;
            };
            renne.skill.Add(normalAttack);

            Skill stone = CreateStateSkill("石化光线", 0, 20, TargetType.EnemySingle);
            stone.description = "召唤帕蒂尔·玛蒂尔释放石化光线，有70%的概率使敌人进入石化状态3回合。（MP：20）";
            stone.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                if (Program.random.Next(0, 100) > 70)
                {
                    return;
                }
                MyDraw.DrawBattleMessageDelay("触发了石化效果！");
                State dizzy = CreateSpecialState("石化", 0, 3);
                dizzy.type = StateType.Dizzy;
                dizzy.skillName = stone.name;
                target.AddState(dizzy);
                State damageDec = CreateIncOrDecState("物理抗性提升", 0, 3, -0.5);
                damageDec.type = StateType.PhysicalBeDamageIncrease;
                damageDec.skillName = stone.name;
                target.AddState(damageDec);
            };
            renne.skill.Add(stone);

            Skill renneKill = CreateDamageSkill("玲·歼灭", 20, 40, 1, 15, TargetType.EnemyMulti, DamageType.Magic);
            renneKill.description = "玲挥动收割敌人的生命，对敌方全体造成伤害并且低概率即死。（HP:20，MP：40）";
            renneKill.isDeathNow = true;
            renneKill.deathRatio = 15;
            renneKill.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int temp = Convert.ToInt32(attacker.Mat * 1.67);
                return temp;
            };
            renne.skill.Add(renneKill);

            Skill silence = CreateDamageSkill("天国之门", 0, 32, 1, 13, TargetType.EnemySingle, DamageType.Magic);
            silence.description = "开启天国之门，对单个敌人造成魔法伤害并且必定沉默。（MP：32）";
            silence.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int temp = Convert.ToInt32(attacker.Mat * 2.44 - target.Men * 0.83);
                return temp;
            };
            silence.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State silenceState = CreateSpecialState("沉默", 0, 3);
                silenceState.skillName = silence.name;
                silenceState.type = StateType.Silence;
                target.AddState(silenceState);
            };
            renne.skill.Add(silence);

            Skill PatelMattel = CreateDamageSkill("帕蒂尔·玛蒂尔", 0, 83, 3, 10, TargetType.EnemyMulti, DamageType.Magic);
            PatelMattel.description = "帕蒂尔·玛蒂尔用加农炮轰击前方的全体敌人，血量越低伤害越高。（MP：83）";
            PatelMattel.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int temp = Convert.ToInt32((attacker.Mat * 2.5 - target.Men * 0.6) * (2 - target.Hp * 1.0 / target.MaxHp));
                return temp;
            };
            renne.skill.Add(PatelMattel);

            return renne;
        }

        /// <summary>
        /// 创建角色马修，骑士
        /// </summary>
        /// <returns></returns>
        public static BaseCharacter CreateCharMatthew()
        {
            BaseCharacter matthew = new BaseCharacter();
            matthew.Name = "马修";
            matthew.MaxHp = 631;
            matthew.MaxMp = 214;
            matthew.Hp = 631;
            matthew.Mp = 214;
            matthew.Atk = 19;
            matthew.Def = 42;
            matthew.Mat = 17;
            matthew.Men = 23;
            matthew.HitRatio = 80;
            matthew.CriticalChance = 10;
            matthew.Level = 5;
            matthew.type = CharacterType.Player;

            Skill normalAttack = CreateAttackSkill(1, 10, DamageType.Physical, TargetType.EnemySingle);
            normalAttack.description = "普通攻击，物理伤害。";
            normalAttack.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int temp = attacker.Atk * 2 - target.Def;
                return temp > 0 ? temp : 1;
            };
            matthew.skill.Add(normalAttack);

            Skill invincible = CreateStateSkill("白垩之壁", 0, 30, TargetType.PartySingle);
            invincible.description = "撑起扰乱时间的屏障，为己方单人赋予一次无敌效果。（MP：30）";
            invincible.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State invState = CreateSpecialState("无敌", 1, 0);
                invState.type = StateType.Invincible;
                invState.skillName = invincible.name;
                target.AddState(invState);
            };
            matthew.skill.Add(invincible);

            Skill defUp = CreateStateSkill("雪花之壁", 0, 28, TargetType.PartyMulti);
            defUp.description = "为己方全体撑起精神护盾，提高全体的物理防御力。（MP：28）";
            defUp.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State defupState = CreateBuffState("物理防御力上升", 0, 4);
                defupState.type = StateType.Buff;
                defupState.AddState = (BaseCharacter one) =>
                {
                    defupState.defUp = Convert.ToInt32(one.Def * 0.3);
                    one.Def += defupState.defUp;
                };
                defupState.RemoveState = (BaseCharacter one) =>
                {
                    one.Def -= defupState.defUp;
                };
                defupState.skillName = defUp.name;
                target.AddState(defupState);
            };
            matthew.skill.Add(defUp);

            Skill taunt = CreateStateSkill("决意之盾", 0, 17, TargetType.Self);
            taunt.description = "坚定守护队友的决心，一定时间内提高自己被攻击的概率。（MP：17）";
            taunt.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State tauntState = CreateSpecialState("嘲讽", 0, 4);
                tauntState.skillName = taunt.name;
                tauntState.ratio = 0.5;
                tauntState.type = StateType.Taunt;
                attacker.AddState(tauntState);
            };
            matthew.skill.Add(taunt);

            Skill revive = CreateStateSkill("神圣之城", 0, 44, TargetType.PartySingle);
            revive.description = "为队友附加神圣的守护，使一名队友能够复活一次。（MP：44）";
            revive.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State revState = CreateSpecialState("复活", 1, 0);
                revState.skillName = revive.name;
                revState.type = StateType.Revive;
                target.AddState(revState);
            };
            matthew.skill.Add(revive);

            return matthew;
        }

        /// <summary>
        /// 创建一个怪物红色史莱姆
        /// </summary>
        /// <returns></returns>
        public static BaseCharacter CreateCharSlimeRed()
        {
            BaseCharacter slime = new BaseCharacter();
            slime.Name = "红色史莱姆";
            slime.MaxHp = 1351;
            slime.MaxMp = 385;
            slime.Hp = 1351;
            slime.Mp = 385;
            slime.Atk = 40;
            slime.Def = 40;
            slime.Mat = 20;
            slime.Men = 20;
            slime.HitRatio = 80;
            slime.CriticalChance = 5;
            slime.Level = 15;
            slime.type = CharacterType.Enemy;
            slime.actionType = ActionMode.MaxHP;
            Skill normalAttack = CreateAttackSkill(1, 20, DamageType.Physical, TargetType.EnemySingle);
            normalAttack.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                return attacker.Atk * 2 - target.Def;
            };
            slime.skill.Add(normalAttack);

            Skill strongeAttack = CreateDamageSkill("强击", 0, 10, 1, 10, TargetType.EnemySingle, DamageType.Physical);
            strongeAttack.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                return attacker.Atk * 3 - target.Def;
            };
            slime.skill.Add(strongeAttack);

            Skill softBody = CreateStateSkill("柔化", 0, 20, TargetType.Self);
            softBody.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State softState = CreateIncOrDecState("物理伤害降低", 0, 4, -0.5);
                softState.type = StateType.PhysicalBeDamageIncrease;
                softState.skillName = softBody.name;
                attacker.AddState(softState);
            };
            slime.skill.Add(softBody);

            Skill phyReflect = CreateStateSkill("物理反射", 0, 20, TargetType.Self);
            phyReflect.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State phyReflectState = CreateSpecialState("物理反射", 1, 0);
                phyReflectState.type = StateType.PhysicalReflect;
                phyReflectState.skillName = phyReflect.name;
                attacker.AddState(phyReflectState);
            };
            slime.skill.Add(phyReflect);

            //史莱姆的技能选择逻辑,就是最简单的AI
            slime.GetRandomSkill = (BaseCharacter bc, List<BaseCharacter> bcList, int counts) =>
            {
                //每7回合用一次柔化
                if (counts % 7 == 1)
                {
                    if (bc.skill[2].CanUseSkill(bc))
                        return bc.skill[2];
                }
                //血量低于一半的时候如果自身没有物理反射状态，释放物理反射技能
                if (bc.Hp < (bc.MaxHp / 2))
                {
                    if (!bc.HasState(StateType.PhysicalReflect))
                        if (bc.skill[3].CanUseSkill(bc))
                            return bc.skill[3];
                }
                //其他情况下，优先在普通攻击和强击中选择技能
                List<int> tempList = new List<int>();
                for (int i = 0; i < 2; i++)
                {
                    if (bc.skill[i].CanUseSkill(bc))
                        tempList.Add(i);
                }
                return bc.skill[tempList[Program.random.Next(0, tempList.Count)]];
            };
            return slime;
        }


        /// <summary>
        /// 创造一个史莱姆王
        /// </summary>
        /// <returns></returns>
        public static BaseCharacter CreateCharSlimeKing()
        {
            BaseCharacter slimeKing = new BaseCharacter();
            slimeKing.Name = "史莱姆王";
            slimeKing.MaxHp = 5428;
            slimeKing.MaxMp = 2301;
            slimeKing.Hp = 5428;
            slimeKing.Mp = 2301;
            slimeKing.Atk = 50;
            slimeKing.Def = 30;
            slimeKing.Mat = 42;
            slimeKing.Men = 19;
            slimeKing.HitRatio = 85;
            slimeKing.CriticalChance = 15;
            slimeKing.Level = 15;
            slimeKing.type = CharacterType.Enemy;

            Skill normalAttack = CreateAttackSkill(1, 20, DamageType.Physical, TargetType.EnemySingle);
            normalAttack.skillDamage = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int temp = Convert.ToInt32(attacker.Atk * 1.78 - target.Def);
                return temp > 0 ? temp : 1;
            };
            slimeKing.skill.Add(normalAttack);

            Skill damageDec = CreateStateSkill("伤害加深", 0, 40, TargetType.EnemySingle);
            damageDec.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                State damageIncState = CreateIncOrDecState("物理伤害加深", 0, 3, 0.4);
                damageIncState.skillName = damageDec.name;
                damageIncState.type = StateType.PhysicalBeDamageIncrease;
                target.AddState(damageIncState);

                State damageIncState2 = CreateIncOrDecState("魔法伤害加深", 0, 3, 0.4);
                damageIncState2.skillName = damageDec.name;
                damageIncState2.type = StateType.MagicBeDamageIncrease;
                target.AddState(damageIncState2);
            };
            slimeKing.skill.Add(damageDec);

            Skill recover = CreateStateSkill("再生", 0, 52, TargetType.Self);
            recover.skillEffect = (BaseCharacter attacker, BaseCharacter target) =>
            {
                int hprecover = Convert.ToInt32(attacker.MaxHp * 0.02);
                State recoverState = CreateHOTState("再生", 0, 3, hprecover);
                recoverState.skillName = damageDec.name;
                target.AddState(recoverState);
            };
            slimeKing.skill.Add(recover);

            slimeKing.GetRandomSkill = (BaseCharacter bc, List<BaseCharacter> bcList, int counts) =>
            {
                //如果掉血了且不处于再生状态下，释放再生技能
                if (bc.Hp < bc.MaxHp)
                {
                    if (!bc.HasState(StateType.HealOverTime))
                        if (bc.skill[2].CanUseSkill(bc))
                            return bc.skill[2];
                }

                if (counts % 4 == 2)
                    if (bc.skill[1].CanUseSkill(bc))
                        return bc.skill[2];

                return bc.skill[0];
            };

            return slimeKing;
        }
    }
}
