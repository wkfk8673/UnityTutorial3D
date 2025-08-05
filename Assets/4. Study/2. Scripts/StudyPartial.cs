using UnityEngine;

public class StudyPartial : MonoBehaviour
{
    private void Start()
    {
        MethodA();
        MethodB();
    }

    private void MethodA()
    {
        Debug.Log("Method A");
    }
    private void MethodB()
    {
        Debug.Log("Method B");
    }
}
