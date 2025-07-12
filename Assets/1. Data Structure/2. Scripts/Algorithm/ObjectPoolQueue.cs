using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    public GameObject objPrefab;
    public Transform parent; // 오브젝트 무한 생성 시 보기 안좋아서 묶어두려고 부모 추가

    private void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent);
            EnqueueObj(obj);
        }
    }
    public void EnqueueObj(GameObject obj)
    {
        objQueue.Enqueue(obj);
        obj.SetActive(false); // 오브젝트 플에 넣으면서 기능을 꺼둠
    }

    public GameObject DequeueObj() // 오브젝트 꺼내서 사용
    {
        if (objQueue.Count < 10) // 몇개 안 남았을 경우
            CreateObject(); // 오브젝트 생성

        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

        return obj;
    }
}
