using System;
using JetBrains.Annotations;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    private void Start()
    {
        Debug.Log("���� �� : " + string.Join(",", array));
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
        int n1 = mid - left + 1; // ���� �迭�� ũ��
        int n2 = right - mid; // ������ �迭�� ũ��

        // �迭 ����
        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        for (int i = 0; i < n1; i++)
        {
            leftArr[i] = arr[left + i]; // ���� �迭 �� �ʱ�ȭ
        }
        for (int i = 0; i < n2; i++)
        {
            rightArr[i] = arr[mid + 1 + i]; // ������ �迭 �� �ʱ�ȭ

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

        while(u < n1) // ���� �迭�� ���Ҵٸ�
        {
            arr[j] = leftArr[u];
            u++;
            j++;
        }
        
        while(v < n2) // ������ �迭�� ���Ҵٸ�
        {
            arr[j] = rightArr[v];
            v++;
            j++;
        }
    }
}
