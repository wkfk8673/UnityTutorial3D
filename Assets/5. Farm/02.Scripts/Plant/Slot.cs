using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Crop crop; // 슬롯에 들어올 아이템
    [SerializeField] private Image slotImage;
    [SerializeField] private Button slotButton;

    public bool isEmpty = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        slotButton.onClick.AddListener(UseCrop);
    }

    private void OnEnable()
    {
        slotImage.gameObject.SetActive(!isEmpty);
        slotButton.interactable = !isEmpty;
    }

    public void AddCrop(Crop crop)
    {
        isEmpty = false;

        this.crop = crop;
        slotImage.sprite = crop.icon;
    }

    private void UseCrop()
    {
        if (crop != null)
        {
            crop.Use();
            isEmpty = true;

            slotButton.interactable = false;
            slotImage.gameObject.SetActive(false);
            crop.useAction?.Invoke();
        }

    }
}
