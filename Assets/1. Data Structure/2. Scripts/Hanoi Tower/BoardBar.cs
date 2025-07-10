using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public HanoiTower hanoiTower;
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
        if (!CheckDonut(donut)) return;

        if (HanoiTower.currBar != null && HanoiTower.currBar.barType != this.barType) HanoiTower.moveCount++;

        HanoiTower.isSelected = false;
        HanoiTower.selectedDonut = null;

        donut.transform.position = transform.position + Vector3.up * 5f;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        barStack.Push(donut); // Stack�� GameObject�� �ִ� ���
        hanoiTower.countTextUI.text = $"Push : {donut.GetComponent<Donut>().donutNumber} To Bar : {this.barType} | Move Count : {HanoiTower.moveCount}";
    }

    public GameObject PopDonut()
    {
        if (barStack.Count > 0)
        {
            HanoiTower.currBar = this; // ��� bar ���� �̾Ҵ��� �Ǵ��� ���� ���� bar ���� ����
            HanoiTower.isSelected = true;
            GameObject donut = barStack.Pop(); // Stack���� GameObject�� ������ ���

            return donut; // ���� ������ ��ȯ
        }

        return null;
    }


    public void OnMouseDown()
    {
        if (HanoiTower.isMoving) return;
        if (!HanoiTower.isSelected) // ������ �������� ���� ��Ȳ  
        {
            // ������ ���� ���� ������  
            HanoiTower.selectedDonut = PopDonut();
            hanoiTower.countTextUI.text = $"Selected Donut : {HanoiTower.selectedDonut.GetComponent<Donut>().donutNumber}";

        }
        else// ������ ������ ��Ȳ  
        {
            // ������ �ٿ� �־����  
            PushDonut(HanoiTower.selectedDonut);

        }
    }
}
