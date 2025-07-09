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
        // 바에 도넛이 없을 때는 무관함
        if(barStack.Count > 0)
        {
            // 현재 넣으려는 도넛 값을 확인
            int pushNumber = donut.GetComponent<Donut>().donutNumber;

            // 가장 꼭대기 도넛 값을 확인
            GameObject peekDonut = barStack.Peek();
            int peekNumber = peekDonut.GetComponent<Donut>().donutNumber;

            if(pushNumber < peekNumber)
            {
                return true;
            }
            else
            {
                Debug.Log($"현재 넣으려는 도넛 : {pushNumber}, 꼭대기 도넛 : {peekNumber} 으로 넣을 수 없습니다;");
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
        HanoiTower.isSelected = false; // 성공여부를 여기서 판단
        HanoiTower.selectedDonut = null; // 초기화

        donut.transform.position = transform.position + Vector3.up * 5; // 선택된 바의 상단에서 생성
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // 속도 초기화
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // 속도 초기화

        barStack.Push(donut); // Stack 에 donut 을 저장하는 기능

    }

    public GameObject PopDonut()
    {
        GameObject donut = barStack.Pop(); // Stack 에서 GameObject 를 꺼내는 기능
        return donut; // 해당 도넛을 반환
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
