using System;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private string name;
    private enum CropPlant { Carrot = 50,Corn = 60,Eggplant = 120, Pumpkin = 150, Tomato = 160, Turnip = 170 }
    CropPlant cropPlant;

    public Sprite icon;
    public Action useAction;

    private void Start()
    {
        useAction += Use; // action 에 등록해두면 매번 저 멀리까지 가서 접근 안해도 됨
    }

    private void OnDisable()
    {
        useAction = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Get();
        }
    }

    //작물 추가
    public void Get()
    {
        if (GameManager.Instance.item.CheckItemCount())
        {
            GameManager.Instance.item.GetItem(this);
            gameObject.SetActive(false);

            Debug.Log($"{name}을 획득하였습니다.");
        }
        else
        {
            Debug.Log("Inventory Full!");
        }


    }

    public void Use()
    {
        // 체력이나 스태미너 회복
        // 인벤토리에서 버튼 눌렀을 때 실행
        GameManager.Instance.item.UseItem();
        CropPlant currPlant = (CropPlant)Enum.Parse(typeof(CropPlant), name);


        GameManager.cash += (int)currPlant;
        Debug.Log($"{name} 판매, {GameManager.cash} 를 벌었습니다.");
        GameManager.Instance.UpdateMoneyUI();
    }
}
