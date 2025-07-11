using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStackManager : MonoBehaviour
{
    public Stack<GameObject> uiStack = new Stack<GameObject>();

    public Button[] buttons;
    public GameObject[] popupUIs;

    private void Start()
    {
        buttons[0].onClick.AddListener(() => popupUIs[0].SetActive(true));
    }
}
