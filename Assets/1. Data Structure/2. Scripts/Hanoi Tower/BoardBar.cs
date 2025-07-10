using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType { Left, Center, Right }
    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();

    public bool CheckDonut(GameObject donut)
    {
        if (barStack.Count > 0)
        {
            int pushNumber = donut.GetComponent<Donut>().donutNumber;

            GameObject peekDonut = barStack.Peek();
            int peekNumber = peekDonut.GetComponent<Donut>().donutNumber;

            if (pushNumber < peekNumber)
                return true;
            else
            {
                Debug.Log($"���� �������� ������ {pushNumber}�̰�, �ش� ����� ���� ���� ������ {peekNumber}�Դϴ�.");
                return false;
            }
        }

        return true;
    }

    public void PushDonut(GameObject donut)
    {
        if (!CheckDonut(donut))
            return;

        HanoiTower.moveCount++;

        HanoiTower.isSelected = false;
        HanoiTower.selectedDonut = null;

        donut.transform.position = transform.position + Vector3.up * 5f;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        barStack.Push(donut); // Stack�� GameObject�� �ִ� ���

    }

    public GameObject PopDonut()
    {
        if (barStack.Count > 0)
        {
            HanoiTower.currBar = this;
            HanoiTower.isSelected = true;
            GameObject donut = barStack.Pop(); // Stack���� GameObject�� ������ ���

            return donut; // ���� ������ ��ȯ
        }

        return null;
    }


    public void OnMouseDown()
    {
        if (!HanoiTower.isSelected) // ������ �������� ���� ��Ȳ
        {
            HanoiTower.isSelected = true;
            // ������ ���� ���� ������
            HanoiTower.selectedDonut = PopDonut();
        }
        else // ������ ������ ��Ȳ
        {
            // ������ �ٿ� �־����
            PushDonut(HanoiTower.selectedDonut);
        }


    }
}
