using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f;

    public float mx = 0;
    public float my = 0;

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");

        Vector3 dir = new Vector3(-mouse_y, mouse_x, 0f);

        // ����
        mx += mouse_x * rotSpeed * Time.deltaTime;
        my += mouse_y * rotSpeed * Time.deltaTime;

        // ���� ����
        my = Mathf.Clamp(my, -90f, 90f);

        // ����
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
