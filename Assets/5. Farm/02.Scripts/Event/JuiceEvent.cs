using UnityEngine;
using UnityEngine.UI;

public class JuiceEvent : MonoBehaviour
{
    [SerializeField] private GameObject JuiceUI;
    [SerializeField] private Button buyButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JuiceUI.SetActive(true);
            GameManager.Instance.SetCameraState(CameraState.Juice);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JuiceUI.SetActive(false);
            GameManager.Instance.SetCameraState(CameraState.Outside);
        }
    }

    public void BuyJuice()
    {
        GameManager.cash -= 200;
        GameManager.Instance.UpdateMoneyUI();
    }

}
