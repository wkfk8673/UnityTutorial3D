using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    private StudyUnityEvent studyDelegate;
    private StudyAction2 studyaction2;

    private void Start()
    {
        StudyAction2.action += OnLog;
        // event 로 선언시 불가능
        //StudyAction2.action = OnLog;
        //StudyAction2.action?.Invoke();
    }

    private void OnLog()
    {
        Debug.Log("On Log");
        studyaction2.ActionCall();
    }
}
