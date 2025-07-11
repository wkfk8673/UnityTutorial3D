using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel = HanoiLevel.Lv1; //���� 1�� �ʱ�ȭ

    public GameObject[] donutPrefabs; // ���� ������Ʈ�� �̸� �޾Ƶ� �迭
    public BoardBar[] bars; // L, C, R ��

    public static GameObject selectedDonut;
    public static bool isSelected = false; // ��ü ���� �������� �Ǵ��ؾ���
    public static bool isMoving = false; // ��ü ���� �������� �Ǵ��ؾ���

    public static BoardBar currBar;
    public static int moveCount;

    public TextMeshProUGUI countTextUI;
    public Button HanoiAnswerBtn;

    void Awake()
    {
        HanoiAnswerBtn.onClick.AddListener(HanoiAnswer); // �Ű����� ���� ��� ���ٽ� �ʿ�
    }
    IEnumerator Start()
    {
        countTextUI.gameObject.SetActive(false);
        isMoving = true;
        for (int i = (int)hanoiLevel -1; i >= 0; i--) // �ݺ� ������ level ��ŭ ���� ����
        {
            GameObject donut = Instantiate(donutPrefabs[i]); // ���� ����
            bars[0].PushDonut(donut); // Stack �ڷ� ���� �������� �־���, Stack ���� �������� �Ʒ��Ÿ� �������Ե�

            donut.transform.position = new Vector3(-5f, 5f, 0); // ������ ������ �����Ǿ� ����

            yield return new WaitForSeconds(1f); // �ణ ���� �� ����
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
            currBar.barStack.Push(selectedDonut); // �̹� pop �� ������ ��� �ٽ� barStack�� push �Ͽ� ����, 

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
        if (n == 0) // ������ �� �ű�
            return;

        if (n == 1)
            Debug.Log($"{n}�� ������ {from} ���� {to}�� �̵�");
        else
        {
            HanoiRoutine(n-1, from, to, temp);
            Debug.Log($"{n}�� ������ {from} ���� {to}�� �̵�");

            HanoiRoutine(n-1, temp, from, to);
        }
    }
}
