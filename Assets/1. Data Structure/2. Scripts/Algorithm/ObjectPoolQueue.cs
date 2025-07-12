using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    public GameObject objPrefab;
    public Transform parent; // ������Ʈ ���� ���� �� ���� �����Ƽ� ����η��� �θ� �߰�

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
        obj.SetActive(false); // ������Ʈ �ÿ� �����鼭 ����� ����
    }

    public GameObject DequeueObj() // ������Ʈ ������ ���
    {
        if (objQueue.Count < 10) // � �� ������ ���
            CreateObject(); // ������Ʈ ����

        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

        return obj;
    }
}
