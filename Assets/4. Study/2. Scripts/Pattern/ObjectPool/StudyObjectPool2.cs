using UnityEngine;
using UnityEngine.Pool;

public class StudyObjectPool2 : MonoBehaviour
{
    //stack
    public ObjectPool<GameObject> objPool;
    public GameObject objPrefab;

    private void Awake()
    {
        objPool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleaseObject);
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(objPrefab, transform);
        obj.SetActive(false);

        return obj;
    }

    private void OnGetObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = objPool.Get();
        }

        //생성된 오브젝트에서 사용하는 기능 (되돌아옴)
        //StudyObjectPool2.Instance.objPool.Release(gameObject);
    }
}
