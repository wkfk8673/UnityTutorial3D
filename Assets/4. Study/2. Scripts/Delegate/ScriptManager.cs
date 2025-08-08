using System;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public Action emergencyStopButton;

    private void Start()
    {
        emergencyStopButton += StopMessage;
    }
    private void StopMessage()
    {
        Debug.Log("긴급 정지 실행");
    }
}
