using Unity.VisualScripting;
using UnityEngine;

public class StaticArray : MonoBehaviour
{
    // �ڷ��� [ ] : ���� �迭

    int[] array1; // �迭 ����, ����Ƽ���� �߰� 
    int[] array2 = { 10, 20, 30, 40, 50 }; // �迭 ���� + �ʱ�ȭ
    int[] array3 = new int[5]; // �迭 ���� + ���� �Ҵ�
    int[] array4 = new int[5] { 10, 20, 30, 40, 50 }; // �迭 ���� + ���� �Ҵ� + �ʱ�ȭ


    NewData[] data = new NewData[5];
}

public class NewData
{

}
