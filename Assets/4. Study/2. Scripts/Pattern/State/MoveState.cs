using UnityEngine;

public class MoveState : MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("Enter Move");
    }

    public void StateExit()
    {
        Debug.Log("Exit Move");
    }

    public void StateUpdate()
    {
        Debug.Log("Move");
    }
}
