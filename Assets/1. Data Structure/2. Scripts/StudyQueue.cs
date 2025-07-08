using System.Collections.Generic;
using UnityEngine;

public class StudyQueue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    private void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            queue.Enqueue(i); // 1 ~ 10 �߰�
        }
        int output = queue.Dequeue(); //�� �̱�
        Debug.Log(output);

        Debug.Log(queue.Peek());
        Debug.Log(queue.Contains(5)); // �� 5�� ���ԵǾ��ִ��� Ȯ��

        queue.Clear(); // ��� �� ����
        Debug.Log(queue.Count); // ���� Ȯ��

    }
}
