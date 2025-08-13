using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject outSideUI;
    [SerializeField] private GameObject fieldUI;
    [SerializeField] private GameObject houseUI;
    [SerializeField] private GameObject animalUI;
    [SerializeField] private GameObject SeedUI;
    [SerializeField] private GameObject InventoryUI;



    [SerializeField] private Button seedButton;
    [SerializeField] private Button harvestButton;
    [SerializeField] private Button[] plantButtons;

    private void Awake()
    {
        seedButton.onClick.AddListener(OnSeedBtn);
        harvestButton.onClick.AddListener(OnHarvestBtn);

        for (int i = 0; i < plantButtons.Length; i++)
        {
            // Closer 이슈
            int j = i;
            plantButtons[i].onClick.AddListener(() => GameManager.Instance.field.SetPlant(j));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }

    private void OnSeedBtn()
    {
        GameManager.Instance.field.SetState(FieldManager.FieldState.Seed);
        SeedUI.SetActive(true); 
    }

    private void OnHarvestBtn()
    {
        GameManager.Instance.field.SetState(FieldManager.FieldState.Harvest);
        SeedUI.SetActive(false); 
    }

    public void ActivateFieldUI(bool isActive)
    {
        fieldUI.SetActive(isActive);
    }
}
