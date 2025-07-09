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
        // �ٿ� ������ ���� ���� ������
        if(barStack.Count > 0)
        {
            // ���� �������� ���� ���� Ȯ��
            int pushNumber = donut.GetComponent<Donut>().donutNumber;

            // ���� ����� ���� ���� Ȯ��
            GameObject peekDonut = barStack.Peek();
            int peekNumber = peekDonut.GetComponent<Donut>().donutNumber;

            if(pushNumber < peekNumber)
            {
                return true;
            }
            else
            {
                Debug.Log($"���� �������� ���� : {pushNumber}, ����� ���� : {peekNumber} ���� ���� �� �����ϴ�;");
                return false;
            }
        }
        return true;
    }

    public void PushDonut(GameObject donut)
    {
        if (!CheckDonut(donut))
        {
            return;
        }
        HanoiTower.isSelected = false; // �������θ� ���⼭ �Ǵ�
        HanoiTower.selectedDonut = null; // �ʱ�ȭ

        donut.transform.position = transform.position + Vector3.up * 5; // ���õ� ���� ��ܿ��� ����
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // �ӵ� �ʱ�ȭ
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // �ӵ� �ʱ�ȭ

        barStack.Push(donut); // Stack �� donut �� �����ϴ� ���

    }

    public GameObject PopDonut()
    {
        GameObject donut = barStack.Pop(); // Stack ���� GameObject �� ������ ���
        return donut; // �ش� ������ ��ȯ
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
