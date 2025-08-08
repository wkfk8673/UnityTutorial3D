using System.Collections;
using UnityEngine;

public class IdleState : MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("Enter Idle");
        StartCoroutine(MethodA());
    }

    public void StateExit()
    {
        Debug.Log("Exit Idle");
    }

    public void StateUpdate()
    {
        Debug.Log("Idle");
    }

    IEnumerator MethodA()
    {
        yield return null;
    }
}
