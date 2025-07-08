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
        // Dictionary ������ �߰�
        persons.Add("ö��", new PersonData(10, "ö��", 150f, 30f));
        persons.Add("����", new PersonData(10, "����", 150f, 30f));
        persons.Add("����", new PersonData(10, "����", 150f, 30f));

        Debug.Log(persons["ö��"].age);
        Debug.Log(persons["ö��"].name);
        Debug.Log(persons["ö��"].height);
        Debug.Log(persons["ö��"].weight);

        //key �� ������ �޾ƿ���
        //int age = persons["����"];
        //Debug.Log($"ö���� ���̴� {age}");

        // value �� ������ �޾ƿ���
        //string name = persons[15];
        // �ߺ��� ���Ǿ�, �Ǵ� �Ұ�
    }
}

