using System.Collections.Generic;
using UnityEngine;

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, int> persons = new Dictionary<string, int>();

    private void Start()
    {
        // Dictionary 데이터 추가
        persons.Add("철수", 10);
        persons.Add("영희", 15);
        persons.Add("동수", 17);

        //key 로 데이터 받아오기
        int age = persons["동수"];
        Debug.Log($"철수의 나이는 {age}");

        // value 로 데이터 받아오기
        //string name = persons[15];
        // 중복이 허용되어, 판단 불가

        foreach (var person in persons)
        {
            if(person.Value == 15)
            {
                Debug.Log($"15세는 {person.Key}");
            }

            Debug.Log($"{person.Key}의 나이는 {person.Value}");

            if (persons.ContainsKey("철수"))
            {
                Debug.Log("딕셔너리 내 철수 확인");
            }
            if (persons.ContainsValue(17))
            {
                Debug.Log("딕셔너리 내 17살 존재");
            }
        }
    }
}

