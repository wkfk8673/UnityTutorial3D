using System.Collections.Generic;
using UnityEngine;

public class PersonData
{
    public int age;
    public string name;
    public float height;
    public float weight;

    public PersonData(int _age, string _name, float _height, float _weight)
    {
        age = _age;
        name = _name;
        height = _height;
        weight = _weight;
    }
}

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData>();

    private void Start()
    {
        // Dictionary 데이터 추가
        persons.Add("철수", new PersonData(10, "철수", 150f, 30f));
        persons.Add("영희", new PersonData(10, "영희", 150f, 30f));
        persons.Add("동수", new PersonData(10, "동수", 150f, 30f));

        Debug.Log(persons["철수"].age);
        Debug.Log(persons["철수"].name);
        Debug.Log(persons["철수"].height);
        Debug.Log(persons["철수"].weight);

        //key 로 데이터 받아오기
        //int age = persons["동수"];
        //Debug.Log($"철수의 나이는 {age}");

        // value 로 데이터 받아오기
        //string name = persons[15];
        // 중복이 허용되어, 판단 불가
    }
}

