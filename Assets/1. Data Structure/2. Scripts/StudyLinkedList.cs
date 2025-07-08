using System.Collections.Generic;
using UnityEngine;

public class StudyLinkedList : MonoBehaviour
{
    public LinkedList<int> linkedList1 = new LinkedList<int>();

    void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            linkedList1.AddLast(i); // ���� �������� �߰�
        }
        linkedList1.AddFirst(100); // ���� �տ� �߰�
        linkedList1.AddLast(500); // ���� �տ� �߰�

        var node = linkedList1.AddFirst(1);

        linkedList1.AddAfter(node, 321565); // ���� �տ� �߰�
        linkedList1.AddBefore(node, 545455); // ���� �տ� �߰�
    }
}
