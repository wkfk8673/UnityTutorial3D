using Unity.VisualScripting;
using UnityEngine;

public class StaticArray : MonoBehaviour
{
    // 자료형 [ ] : 정적 배열

    int[] array1; // 배열 선언, 유니티에서 추가 
    int[] array2 = { 10, 20, 30, 40, 50 }; // 배열 선언 + 초기화
    int[] array3 = new int[5]; // 배열 선언 + 공간 할당
    int[] array4 = new int[5] { 10, 20, 30, 40, 50 }; // 배열 선언 + 공간 할당 + 초기화


    NewData[] data = new NewData[5];
}

public class NewData
{

}
