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
                Debug.Log($"현재 넣으려는 도넛은 {pushNumber}이고, 해당 기둥의 제일 위의 도넛은 {peekNumber}입니다.");
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
        
        barStack.Push(donut); // Stack에 GameObject를 넣는 기능

    }

    public GameObject PopDonut()
    {
        if (barStack.Count > 0)
        {
            HanoiTower.currBar = this;
            HanoiTower.isSelected = true;
            GameObject donut = barStack.Pop(); // Stack에서 GameObject를 꺼내는 기능

            return donut; // 꺼낸 도넛을 반환
        }

        return null;
    }


    public void OnMouseDown()
    {
        if (!HanoiTower.isSelected) // 도넛을 선택하지 않은 상황
        {
            HanoiTower.isSelected = true;
            // 선택한 도넛 정보 가져옴
            HanoiTower.selectedDonut = PopDonut();
        }
        else // 도넛을 선택한 상황
        {
            // 선택한 바에 넣어야함
            PushDonut(HanoiTower.selectedDonut);
        }


    }
}
