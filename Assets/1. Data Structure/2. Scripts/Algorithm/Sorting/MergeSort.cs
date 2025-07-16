using System;
using JetBrains.Annotations;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    private void Start()
    {
        Debug.Log("정렬 전 : " + string.Join(",", array));
        MSort(array, 0, array.Length - 1);

    }

    private void MSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MSort(arr, left, mid);
            MSort(arr, mid - 1, right);

            Merge(arr, left, mid, right);
        }
    }

    private void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1; // 왼쪽 배열의 크기
        int n2 = right - mid; // 오른쪽 배열의 크기

        // 배열 생성
        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        for (int i = 0; i < n1; i++)
        {
            leftArr[i] = arr[left + i]; // 왼쪽 배열 값 초기화
        }
        for (int i = 0; i < n2; i++)
        {
            rightArr[i] = arr[mid + 1 + i]; // 오른쪽 배열 값 초기화

        }

        int j = left;
        int u = 0, v = 0;

        while(u < n1 && v < n2)
        {
            if (leftArr[u] <= rightArr[v])
            {
                arr[j] = leftArr[u];
                u++;
            }
            else
            {
                arr[j] = rightArr[v];
                v++;
            }
            j++;
        }

        while(u < n1) // 왼쪽 배열이 남았다면
        {
            arr[j] = leftArr[u];
            u++;
            j++;
        }
        
        while(v < n2) // 오른쪽 배열이 남았다면
        {
            arr[j] = rightArr[v];
            v++;
            j++;
        }
    }
}
