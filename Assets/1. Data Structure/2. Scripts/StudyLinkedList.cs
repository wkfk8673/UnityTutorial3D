using System.Collections.Generic;
using UnityEngine;

public class StudyLinkedList : MonoBehaviour
{
    public LinkedList<int> linkedList1 = new LinkedList<int>();

    void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            linkedList1.AddLast(i); // 가장 마지막에 추가
        }
        linkedList1.AddFirst(100); // 가장 앞에 추가
        linkedList1.AddLast(500); // 가장 앞에 추가

        var node = linkedList1.AddFirst(1);

        linkedList1.AddAfter(node, 321565); // 가장 앞에 추가
        linkedList1.AddBefore(node, 545455); // 가장 앞에 추가
    }
}
