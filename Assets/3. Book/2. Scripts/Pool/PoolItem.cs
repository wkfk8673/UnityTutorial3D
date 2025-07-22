using UnityEngine;

public class PoolItem : MonoBehaviour
{
    private PoolManager poolManager;

    private bool isInit = false;

    private void Awake()
    {
        poolManager = GameObject.FindFirstObjectByType<PoolManager>();
    }


    private void OnEnable()
    {
        if (!isInit)
            isInit = true;
        else
            Invoke("ReturnObject", 3f);
    }

    private void ReturnObject()
    {
        poolManager.pool.Release(gameObject);
    }
}
