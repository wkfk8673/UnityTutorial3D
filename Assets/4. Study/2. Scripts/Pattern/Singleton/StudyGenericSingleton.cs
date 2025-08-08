using UnityEngine;

public class StudyGenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance; // 가상의 T (타입)
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();

                if (instance == null)
                {
                    var newObject = new GameObject(typeof(T).ToString()); // 클래스 타입 기반 호출
                }
            }
            return instance;

        }

    }

    protected virtual void Awake() // base awake 에서 다시 생성하여 사용 가능하도록 
    {
        if(instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
