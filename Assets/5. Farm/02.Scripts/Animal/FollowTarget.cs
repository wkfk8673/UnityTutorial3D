using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target;
    private bool isTracking = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
