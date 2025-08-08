using UnityEngine;

namespace Pattern.Decorater
{
    public class Player : MonoBehaviour
    {
        private void Start()
        {
            IAttack attack = new BasicAttack();

            attack = new FireAttack(attack);
            attack.Execute();

            attack = new IceAttack(attack);
            attack.Execute();
        }
    }

}

