using System.Collections;
using TMPro;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs; // 도넛 오브젝트를 미리 받아둘 배열
    public BoardBar[] bars; // L, C, R 순

    public static bool isSelected = false; // 전체 게임 기준으로 판단해야함
    public static GameObject selectedDonut;
    public static BoardBar currBar;
    public static int moveCount;

    public TextMeshProUGUI countTextUI;

    IEnumerator Start()
    {

        for (int i = (int)hanoiLevel -1; i >= 0; i--) // 반복 문으로 level 만큼 도넛 생성
        {
            GameObject donut = Instantiate(donutPrefabs[i]); // 도넛 생성
            bars[0].PushDonut(donut); // Stack 자료 구조 기준으로 넣어짐, Stack 으로 정해져서 아래거를 못꺼내게됨

            donut.transform.position = new Vector3(-5f, 5f, 0); // 도넛이 위에서 생성되어 낙하

            yield return new WaitForSeconds(1f); // 약간 지연 후 낙하
        }

        moveCount = 0;
        countTextUI.text = moveCount.ToString();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currBar.barStack.Push(selectedDonut);

            isSelected = false;
            selectedDonut = null;
        }

        countTextUI.text = moveCount.ToString();
    }
}
