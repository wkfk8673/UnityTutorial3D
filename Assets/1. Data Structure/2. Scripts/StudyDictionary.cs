using System.Collections.Generic;
using UnityEngine;

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, int> persons = new Dictionary<string, int>();

    private void Start()
    {
        // Dictionary ������ �߰�
        persons.Add("ö��", 10);
        persons.Add("����", 15);
        persons.Add("����", 17);

        //key �� ������ �޾ƿ���
        int age = persons["����"];
        Debug.Log($"ö���� ���̴� {age}");

        // value �� ������ �޾ƿ���
        //string name = persons[15];
        // �ߺ��� ���Ǿ�, �Ǵ� �Ұ�

        foreach (var person in persons)
        {
            if(person.Value == 15)
            {
                Debug.Log($"15���� {person.Key}");
            }

            Debug.Log($"{person.Key}�� ���̴� {person.Value}");

            if (persons.ContainsKey("ö��"))
            {
                Debug.Log("��ųʸ� �� ö�� Ȯ��");
            }
            if (persons.ContainsValue(17))
            {
                Debug.Log("��ųʸ� �� 17�� ����");
            }
        }
    }
}

