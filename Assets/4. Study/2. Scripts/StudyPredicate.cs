using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    // 반환값이 bool type

    public Predicate<int> myPredicate; // 매개변수 1개만 가능 

    public int level = 10;

    private void Start()
    {
        myPredicate = lv => lv <= 10;
        string msg = myPredicate(level) ? "초보자 사냥터 입장가능" : "초보자 사냥터 입장 불가능";

        Debug.Log(msg);
        
    }

    private void LevelCheck(int Level)
    {
        if(Level <= 10)
        {
            Debug.Log("초보자 사냥터 입장 가능");
        }
        else
        {
            Debug.Log("초보자 사냥터 입장 불가능");
        }
    }
}
