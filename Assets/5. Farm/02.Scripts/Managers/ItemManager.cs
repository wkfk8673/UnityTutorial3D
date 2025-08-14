using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Transform slotGroup;
    [SerializeField] private Slot[] slots;
    [SerializeField] private GameObject slotPrefab;

    [SerializeField] private int slotAmount = 28;
    private int itemCount = 0;

    private void Start()
    {
        for (int i = 0; i < slotAmount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotGroup);
        }
        slots = slotGroup.GetComponentsInChildren<Slot>();
        
    }

    public void GetItem(Crop crop)
    {
        foreach(var slot in slots)
        {
            // 빈 슬롯이 있다면, 해당 슬롯에 crop 데이터 저장
            if (slot.isEmpty)
            {
                slot.AddCrop(crop);
                itemCount++;
                crop.useAction += UseItem; // 델리게이트 체인, useAction 이 돌아갈 때 UseItem 도 실행해달란 소리
                break;
            }
        }
    }

    public bool CheckItemCount()
    {
        bool result = itemCount < slotAmount;
        return result;
    }

    public void UseItem()
    {
        itemCount--;
        Debug.Log($"현재 아이템 갯수 :{itemCount}");
    }
}
