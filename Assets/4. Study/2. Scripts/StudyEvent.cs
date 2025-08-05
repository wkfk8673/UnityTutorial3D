using UnityEngine;

public class StudyEvent : MonoBehaviour
{
    public delegate void InputKeyHandler();
    // event : 실행을 내부에서만 할 수 있도록 제한, event 를 써야 외부 클래스에서 실행되는 걸 막을 수 있음.
    public event InputKeyHandler onInputKey;

    private void Start()
    {
        onInputKey += InputKeyEvent;
    }

    private void InputKeyEvent()
    {
        Debug.Log("Key Event");
    }
}
