using System;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Vector3[] points;

    public float radius = 2f;

    internal static string Combine(string persistentDataPath, string v)
    {
        throw new NotImplementedException();
    }

    public Vector3 GetPoint(int index)
    {
        return points[index];
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if(i+1 < points.Length)
                Debug.DrawLine(points[i], points[i + 1], Color.blue);
        }
    }
}
