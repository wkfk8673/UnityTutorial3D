using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class StudyStack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();
    public int[] array = new int[3] { 1, 2, 3 };
    public int[] array2;
    
    //LIFO

    void Start()
    {

        //Debug.Log(stack.Pop()); // Last ���� ����
        //Debug.Log(stack.Count);

        //Debug.Log(stack.Peek()); // ������ ���� ���� �Ǵ�
        //Debug.Log(stack.Count);

        //Debug.Log(stack.Pop()); // Last ���� ����
        //Debug.Log(stack.Count);

        stack = new Stack<int>(array);
        array2 = stack.ToArray();
    }
}
