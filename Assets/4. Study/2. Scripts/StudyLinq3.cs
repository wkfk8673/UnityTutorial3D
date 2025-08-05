using UnityEngine;
using System.Linq;

public class StudyLinq3 : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };

    private void Start()
    {
        /*
        var result = from number in numbers
                     where number > 1
                     orderby number descending
                     select number;
        */

        // 람다식 + linq 이용하여 정렬
        var result = numbers.Where(n => n > 1).OrderByDescending(n => n);

        foreach (var number in result)
        {
            Debug.Log(number);
        }

    }
}
