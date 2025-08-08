using UnityEngine;

public class StudySingleton : MonoBehaviour
{
    public static StudySingleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 현재 객체를 싱글턴 인스턴스로 생성
        }
        else
        {
            Destroy(gameObject); // 중복 생성 방지
        }
    }
}
