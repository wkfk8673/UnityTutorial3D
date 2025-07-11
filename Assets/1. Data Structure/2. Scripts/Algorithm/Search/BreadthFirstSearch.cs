using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstSearch : MonoBehaviour
{
    private int[,] nodes = new int[8, 8]
{
      // 0 1 2 3 4 5 6 7
        {0,1,1,1,0,0,0,0}, // 0
        {1,0,0,0,1,1,0,0}, // 1
        {1,0,0,0,0,0,0,0}, // 2
        {1,0,0,0,0,0,1,0}, // 3
        {0,1,0,0,0,1,0,0}, // 4
        {0,1,0,0,1,0,0,1}, // 5
        {0,0,0,1,0,0,0,0}, // 6
        {0,0,0,0,0,1,0,0}  // 7
};

    public Queue<int> queue = new Queue<int>();
    private bool[] visited = new bool[8];

    private void Start()
    {
        BFSearch(0);
    }

    /// <summary>
    /// start �������� �����Ͽ� �湮�� ���� ������ ������ ����
    /// </summary>
    /// <param name="start">�׷��� ���� ����</param>
    private void BFSearch(int start)
    {
        queue.Enqueue(start); // 0�� ��� �湮

        // Count == 1
        while (queue.Count > 0)
        {
            int index = queue.Dequeue(); // ��� �湮
            if (!visited[index]) // �湮 ���� Ȯ��
            {
                visited[index] = true; // �湮
                Debug.Log($"{index} �� ��� �湮");

                for (int i = 0; i < nodes.GetLength(0); i++)
                {
                    if (nodes[index, i] == 1 && !visited[i]) // �湮 ���� Ȯ��
                    {
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
