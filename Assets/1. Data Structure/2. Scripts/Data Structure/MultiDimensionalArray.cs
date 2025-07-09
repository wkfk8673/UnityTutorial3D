using UnityEngine;

public class MultiDimensionalArray : MonoBehaviour
{
    public int[,] array1 = new int[3, 3]; // 행과 열이 3개인 2차원 배열
    public int[,,] array2 = new int[3, 3, 3]; // 3차원 배열

    private void Start()
    {
        array1[1, 0] = 1; // 인덱서
    }
}
