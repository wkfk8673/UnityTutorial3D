using UnityEngine;

public class ObserverListener : MonoBehaviour, IObserver
{
    public void Notify(int score)
    {
        Debug.Log("알림");
    }
}
