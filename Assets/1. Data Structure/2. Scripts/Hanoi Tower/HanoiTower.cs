using System.Collections;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs; // ���� ������Ʈ�� �̸� �޾Ƶ� �迭
    public BoardBar[] bars; // L, C, R ��

    public static bool isSelected = false; // ��ü ���� �������� �Ǵ��ؾ���
    public static GameObject selectedDonut;

    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel -1; i >= 0; i--) // �ݺ� ������ level ��ŭ ���� ����
        {
            GameObject donut = Instantiate(donutPrefabs[i]); // ���� ����
            bars[0].PushDonut(donut); // Stack �ڷ� ���� �������� �־���, Stack ���� �������� �Ʒ��Ÿ� �������Ե�

            donut.transform.position = new Vector3(-5f, 5f, 0); // ������ ������ �����Ǿ� ����

            yield return new WaitForSeconds(1f); // �ణ ���� �� ����
        }
    }
}
