using UnityEngine;

public class MultiDimensionalArray : MonoBehaviour
{
    public int[,] array1 = new int[3, 3]; // ��� ���� 3���� 2���� �迭
    public int[,,] array2 = new int[3, 3, 3]; // 3���� �迭

    private void Start()
    {
        array1[1, 0] = 1; // �ε���
    }
}
