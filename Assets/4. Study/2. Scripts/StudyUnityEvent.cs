using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onUnityEvent;
    private void Start()
    {
        onUnityEvent.AddListener(MethodA);

    }

    private void OnDisable()
    {
        onUnityEvent.RemoveListener(MethodA);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onUnityEvent?.Invoke();
        }
    }

    private void MethodA()
    {
        Debug.Log("Method A");
    }
}

