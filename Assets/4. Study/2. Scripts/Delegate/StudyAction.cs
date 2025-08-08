using System;
using UnityEngine;

public class StudyAction : MonoBehaviour
{
    //public delegate void MyDelegate();
    //public MyDelegate myDelegate;

    public event Action action; // System, 

    //public delegate void Mydelegate2(string s);
    //public MyDelegate myDelegate2;

    public Action<string> action2;
    public Action<string, int, float, bool> action3;

    private void Start()
    {
        action += () => Debug.Log("Action");
      /*  action += () =>
        {
            Debug.Log("Action 1");
            Debug.Log("Action 2");
        };
      */
        action?.Invoke();

        action2 += msg => Debug.Log(msg);
        action2?.Invoke("Hello Unity");
    }
}
