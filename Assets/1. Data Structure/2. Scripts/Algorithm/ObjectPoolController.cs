using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    public ObjectPoolQueue pool;
    public Transform shotPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = pool.DequeueObj();
            bullet.transform.position = shotPos.position;
        }
    }
}
