using UnityEngine;

public class FPSPlayerRotate : MonoBehaviour
{
    public float rotSpeed = 100f;

    public float mx = 0;
    public float my = 0;

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        float mouse_x = Input.GetAxis("Mouse X");

        // ����
        mx += mouse_x * rotSpeed * Time.deltaTime;

        // ����
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
