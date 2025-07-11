using System.Collections.Generic;
using UnityEngine;

public class DepthFirstSearch : MonoBehaviour
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

    public Stack<int> stack = new Stack<int>();
    private bool[] visited = new bool[8];

    private void Start()
    {
        DFSearch(0);
    }

    /// <summary>
    /// start �������� �����Ͽ� �湮�� ���� ������ ������ ����
    /// </summary>
    /// <param name="start">�׷��� ���� ����</param>
    private void DFSearch(int start)
    {
        stack.Push(start); // 0�� ��� �湮

        // Count == 1
        while (stack.Count > 0)
        {
            int index = stack.Pop(); // ��� �湮
            if (!visited[index]) // �湮 ���� Ȯ��
            {
                visited[index] = true; // �湮
                Debug.Log($"{index} �� ��� �湮");

                for (int i = nodes.GetLength(0) - 1; i >= 0; i--)
                {
                    if (nodes[index,i] == 1 && !visited[i]) // �湮 ���� Ȯ��
                    {
                        stack.Push(i);
                    }
                }
            }
        }
    }
}
