namespace GameTurnBaseStrateg
{
    //角色
    public class BaseCharacter
    {
        internal delegate Skill EnemyAction(BaseCharacter bc, List<BaseCharacter> bcList, int counts);
    }
}