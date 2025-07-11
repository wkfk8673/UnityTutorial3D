using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel = HanoiLevel.Lv1; //레벨 1로 초기화

    public GameObject[] donutPrefabs; // 도넛 오브젝트를 미리 받아둘 배열
    public BoardBar[] bars; // L, C, R 순

    public static GameObject selectedDonut;
    public static bool isSelected = false; // 전체 게임 기준으로 판단해야함
    public static bool isMoving = false; // 전체 게임 기준으로 판단해야함

    public static BoardBar currBar;
    public static int moveCount;

    public TextMeshProUGUI countTextUI;
    public Button HanoiAnswerBtn;

    void Awake()
    {
        HanoiAnswerBtn.onClick.AddListener(HanoiAnswer); // 매개변수 있을 경우 람다식 필요
    }
    IEnumerator Start()
    {
        countTextUI.gameObject.SetActive(false);
        isMoving = true;
        for (int i = (int)hanoiLevel -1; i >= 0; i--) // 반복 문으로 level 만큼 도넛 생성
        {
            GameObject donut = Instantiate(donutPrefabs[i]); // 도넛 생성
            bars[0].PushDonut(donut); // Stack 자료 구조 기준으로 넣어짐, Stack 으로 정해져서 아래거를 못꺼내게됨

            donut.transform.position = new Vector3(-5f, 5f, 0); // 도넛이 위에서 생성되어 낙하

            yield return new WaitForSeconds(1f); // 약간 지연 후 낙하
        }

        moveCount = 0;
        isMoving = false;
        countTextUI.text = "Hanoi Tower Game";
        countTextUI.gameObject.SetActive(true);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currBar.barStack.Push(selectedDonut); // 이미 pop 한 정보의 경우 다시 barStack에 push 하여 저장, 

            isSelected = false;
            selectedDonut = null;
            countTextUI.text = $"cancle";
        }

    }

    public void HanoiAnswer()
    {
        HanoiRoutine((int)hanoiLevel, 0, 1, 2);
    }
    
    private void HanoiRoutine(int n, int from, int temp, int to)
    {
        if (n == 0) // 도넛을 다 옮김
            return;

        if (n == 1)
            Debug.Log($"{n}번 도넛을 {from} 에서 {to}로 이동");
        else
        {
            HanoiRoutine(n-1, from, to, temp);
            Debug.Log($"{n}번 도넛을 {from} 에서 {to}로 이동");

            HanoiRoutine(n-1, temp, from, to);
        }
    }
}
