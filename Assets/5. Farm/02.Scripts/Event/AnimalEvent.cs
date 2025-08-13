using Unity.Cinemachine;
using UnityEngine;

public class AnimalEvent : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.Animal);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.Outside);
        }
    }
}
