using UnityEngine;

public class DijkstraSearch : MonoBehaviour
{
    private int[,] nodes = new int[6, 6]
    {  //0 1 2 3 4 5
        {0,1,2,0,4,0}, //0
        {1,0,0,0,0,8}, //1
        {2,0,0,3,0,0}, //2
        {0,0,3,0,0,0}, //3
        {4,0,0,0,0,2}, //4
        {0,8,0,0,2,0}  //5
    };

    private void Start()
    {
        int start = 0;
        int[] dist; // 방문 갯수 몰라서 선언만 미리 함
        int[] prev; // 방문한 이전 노드 정보

        Dijkstra(start, out dist, out prev);

        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            Debug.Log($"{start}에서 {i}까지 최단 거리 : {dist[i]}, 경로 : {GetPath(i, prev)}");
        }
    }

    private string GetPath(int end, int[] prev)
    {
        if (prev[end] == -1)
        {
            return end.ToString();
        }

        return $"{GetPath(prev[end], prev)} -> {end}";
    }

    private void Dijkstra(int start, out int[] dist, out int[] prev)
    {
        // out 의 경우 return 전에 미리 제공됨
        int n = nodes.GetLength(0); //6
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            dist[i] = int.MaxValue; // 무한대 값으로 상정 / 거리값 미측정 초기화 값
            prev[i] = -1; // 이전 노드 값 미측정, 초기화 값
            visited[i] = false;
        }

        dist[start] = 0; //0 번 노드에서 시작

        for (int cnt = 0; cnt < n; cnt++) // n = 노드의 갯수
        {
            int u = -1; // 최단거리 노드
            int min = int.MaxValue; // 최단거리 가중치

            // 방문하지 않은 노드 중 최소 거리 노드 선택
            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && dist[j] < min)
                {
                    // 최초 진입 시 무조건 저장될 수 있음
                    min = dist[j];
                    u = j;
                }
            }
            
            if(u == -1) // 해당 노드 최단거리 없음
            {
                break; // 반복문 중단
            }

            visited[u] = true;

            for (int k = 0; k < n; k++)
            {
                if (nodes[u, k] > 0 && !visited[k]) // 방문 가능 확인
                {
                    int newDist = dist[u] + nodes[u, k];
                    if(newDist < dist[k])
                    {
                        dist[k] = newDist;
                        prev[k] = u;
                    }
                }
            }
        }
    }
}
