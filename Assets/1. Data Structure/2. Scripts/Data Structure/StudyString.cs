using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "Hello World***";

    public string[] str2 = new string[3] { "Hello~~~~", "Unity", "World" };

    private void Start()
    {
        // Debug.Log(str1[0]); // H
        // Debug.Log(str1[2]); // l
        //
        // Debug.Log(str2[0]); // Hello
        // Debug.Log(str2[2]); // World
        //
        // Debug.Log(str1.Length); // ���ڿ��� ���� :
        // Debug.Log(str1.Trim()); // �յ� ���� ���� :
        // Debug.Log(str1.Trim('*')); // �յ� ���� '*' ���� : 

        //Debug.Log(str1.Contains('H')); // �빮�� H�� �ִ���
        //Debug.Log(str1.Contains('h')); // �ҹ��� h�� �ִ���

        //Debug.Log(str1.Contains("Hello")); // Hello�� �ִ���

        //Debug.Log(str1.ToUpper()); ; // �빮�� ��ȯ
        //Debug.Log(str1.ToLower()); ; // �ҹ��� ��ȯ

        Debug.Log(str1.Replace("World", "Unity")); // �ڵ忡�� ��� ��ü
        Debug.Log(str1);

        // ���� ������ ���� �ʿ��� ��� str1 �� �ٽ� ���� �ʿ���

        string text = "Apple,Banana,Orange,Water Melon";
        string[] fruits = text.Split(','); // Ư�� ���ڷ� �ɰ� ���

        foreach(var fruit in fruits)
        {
            Debug.Log(fruit);
        }
    }
}
