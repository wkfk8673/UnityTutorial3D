using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    //private object[] array = new object[3];

    /*void Add(object o)
    {
        var temp = new object[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            temp[i] = array[i];
        }

        array = temp;
        array[array.Length - 1] = o;
    }
    */

    public List<int> list1 = new List<int>() { 1, 2, 3 };
    public List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 };
    public List<int> list3 = new List<int>();

    private void Start()
    {
        list1.Add(10);
        list2.Add(10);
        list3.Add(10);

        for (int i = 0; i < 10; i++)
        {
            list1.Add(i);
        }

        list1.Insert(5, 100);
        list1.Remove(1);


        // 임시 코드, 실제 코드에서는 string Builder 를 사용하는 편이 효율적임
        /*
        string str = string.Empty;
        foreach(var x in list1)
        {
            str += x.ToString() + " / ";
        }

        Debug.Log(str);
        */
    }

}
