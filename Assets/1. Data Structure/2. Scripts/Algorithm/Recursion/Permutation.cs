using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] array = new int[3] { 1, 2, 3 };

    private void Start()
    {
        PermutationFunction(array, 0);// ���� 0 ���� ����, stack �� ��� max ���� ����
    }

    private void PermutationFunction(int[] arr, int start)
    {
        if(start == arr.Length)
        {
            Debug.Log(string.Join(", ", arr));
            return;
        }

        for (int i = start; i < arr.Length; i++)
        {
            var temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

            PermutationFunction(array, start + 1); // 1�� ������

            //���� ���� (BackTracking)

            temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

        }
    }
}
