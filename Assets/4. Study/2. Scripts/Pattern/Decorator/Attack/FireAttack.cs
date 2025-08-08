using Pattern.Decorater;
using UnityEngine;

public class FireAttack : AttackDecorator
{
    public FireAttack(IAttack attack) : base(attack)
    {
    }

    public override void Execute()
    {
        base.Execute();
        Debug.Log("불 속성 피해");
    }
}
