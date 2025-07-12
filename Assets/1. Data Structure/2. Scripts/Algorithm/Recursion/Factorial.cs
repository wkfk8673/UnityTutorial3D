using System.Runtime.InteropServices;
using UnityEngine;

public class Factorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int result = FactorialFunction(i);
            Debug.Log(result);
        }
    }

    private int FactorialFunction(int n)
    {
        if (n == 0)
            return 1;
        else
        {
            return n * FactorialFunction(n - 1);
        }
    }
}
