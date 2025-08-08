using System;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    //접근 제한자 + Func + 매개변수 + (마지막)반환값 + 변수명
    //한 개만 반환 가능.
    public Func<int, int, int> myFunc;

    private void Start()
    {
        myFunc = MinusMethod;
        int result = myFunc(10, 20);
        Debug.Log(result);
    }


    private int AddMethod(int num1, int num2)
    {
        return num1 + num2;
    }

    private int MinusMethod(int num1, int num2)
    {
        return num1 - num2;
    }
}
