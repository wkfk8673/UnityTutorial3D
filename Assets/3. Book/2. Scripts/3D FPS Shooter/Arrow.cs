using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float moveSpeed = 100f;
    public bool isMove = true;
    void Update()
    {
        if (isMove)
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 대상이 화살의 닿은 위치 (point) 에 고정
        var closetPos = other.ClosestPoint(transform.position);

        transform.position = closetPos;
        transform.SetParent(other.transform);
        isMove = false;

    }
}
