using UnityEngine;

public class BillboardCamera : MonoBehaviour
{
    private Transform mainCamera;

    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        if (mainCamera.rotation.eulerAngles.x > 80)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.down);
        }
        else
        {
            transform.LookAt(mainCamera);
        }
    }
}
