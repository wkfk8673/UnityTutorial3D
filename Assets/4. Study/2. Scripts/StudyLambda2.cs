using System.Collections.Generic;
using UnityEngine;

public class StudyLambda2 : MonoBehaviour
{
    public List<int> intList = new List<int>();

    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            intList.Add(i);
        }
        intList.RemoveAll(n => n % 2 == 0); // 짞수 모두 삭ㅈㅔ

    }
}
