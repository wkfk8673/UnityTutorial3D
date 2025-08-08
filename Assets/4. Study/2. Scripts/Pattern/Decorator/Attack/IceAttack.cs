using Pattern.Decorater;
using UnityEngine;

public class IceAttack : AttackDecorator
{
    public IceAttack(IAttack attack) : base(attack)
    {
    }

    public override void Execute()
    {
        base.Execute();
        Debug.Log("얼음 속성 피해");
    }
}
