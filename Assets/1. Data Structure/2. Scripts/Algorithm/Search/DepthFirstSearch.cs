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
    /// start 지점에서 시작하여 방문할 곳이 없어질 때까지 진행
    /// </summary>
    /// <param name="start">그래프 시작 지점</param>
    private void DFSearch(int start)
    {
        stack.Push(start); // 0번 노드 방문

        // Count == 1
        while (stack.Count > 0)
        {
            int index = stack.Pop(); // 대상 방문
            if (!visited[index]) // 방문 여부 확인
            {
                visited[index] = true; // 방문
                Debug.Log($"{index} 번 노드 방문");

                for (int i = nodes.GetLength(0) - 1; i >= 0; i--)
                {
                    if (nodes[index,i] == 1 && !visited[i]) // 방문 여부 확인
                    {
                        stack.Push(i);
                    }
                }
            }
        }
    }
}
