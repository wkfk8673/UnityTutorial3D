using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : Singleton<PoolManager>
{
    /// 유니티 내부에 내장된 pool 기능
    public ObjectPool<GameObject> pool; // object pool
    public GameObject prefab;

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleaseObject);
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);        

        return obj;
    }

    
    private void OnGetObject(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
    }

    private void OnReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = pool.Get();
            obj.SetActive(true);
        }
    }
}
