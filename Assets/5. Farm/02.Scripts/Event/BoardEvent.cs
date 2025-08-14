using UnityEngine;

public class BoardEvent : MonoBehaviour
{

    [SerializeField] private GameObject BoardSelectUI;
    [SerializeField] private GameObject AIBoardUI;
    [SerializeField] private GameObject SingleBoardUI;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BoardSelectUI.SetActive(true);
            Single_BoardController.StartAction?.Invoke();

            GameManager.Instance.SetCameraState(CameraState.Board);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BoardSelectUI.SetActive(false);
            SingleBoardUI.SetActive(false);
            AIBoardUI.SetActive(false);

            GameManager.Instance.SetCameraState(CameraState.House);
        }
    }
}
