using System.Collections.Generic;
using UnityEngine;

public class StudyObjectPool : StudyGenericSingleton<StudyObjectPool>
{
    public Queue<GameObject> objQueue = new Queue<GameObject>(); // 오브젝트가 들어갈 풀
    public GameObject objPrefab; // 생성될 오브젝트

    private void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject newObj = Instantiate(objPrefab, transform); // 현재 오브젝트의 하위 자녀 오브젝트로 생성
            objQueue.Enqueue(newObj); // 최초 오브젝트 생성
            newObj.SetActive(false);
        }
    }

    public void EnqueueObject(GameObject obj)
    {
        objQueue.Enqueue(obj);
        obj.SetActive(false);
    }

    public GameObject DequeueObject()
    {
        GameObject obj = objQueue.Dequeue();
        return obj;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (objQueue.Count < 10)
            {
                CreateObject();
            }
            GameObject obj = DequeueObject(); // 풀에서 오브젝트를 뽑아서 사용
            obj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        }

        // 생성된 오브젝트에서 사용하는 기능
        // StudyObjectPool.Instance.EnqueueObject(gameObject);
    }
}
