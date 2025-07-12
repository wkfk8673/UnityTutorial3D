using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] array = new int[3] { 1, 2, 3 };

    private void Start()
    {
        PermutationFunction(array, 0);// 보통 0 부터 시작, stack 일 경우 max 에서 시작
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

            PermutationFunction(array, start + 1); // 1이 더해짐

            //원상 복구 (BackTracking)

            temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

        }
    }
}
