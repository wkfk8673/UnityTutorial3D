using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class AvoidObstaclesMove : MonoBehaviour
{
    public float speed = 10f;
    public float mass = 5f;
    public float force = 50f;
    public float minDistToAvoid = 5f; // �ּ� ȸ�� �Ÿ�

    private float curSpeed;
    private Vector3 targetPoint;
    public float steeringForce = 10f;

    private void Start()
    {
        targetPoint = Vector3.zero; // Ÿ�� �ϴ� 0���� �ʱ�ȭ, 
    }

    private void Update()
    {
        // ���� ī�޶� ���� ��ũ�� Ư�� ����Ʈ���� ������ ��� (���콺 ��ġ)
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            // �Ÿ� : ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                targetPoint = hit.point; // ���콺 Ŭ�� ��ġ�� ��ǥ �������� ����
            }
        }

        Vector3 dir = targetPoint - transform.position;
        dir.Normalize();

        dir = GetAvoidanceDirection(dir); // ��ֹ� ���� Ȯ��, ���� ��� �״�� / ���� ��� ���� ���� ����

        if (Vector3.Distance(targetPoint, transform.position) < 1f)
            return;

        curSpeed = speed * Time.deltaTime;
        transform.position += transform.forward * curSpeed; // �Ʒ����� ������ �����ǹǷ� �̵�

        // ������ �˷��ִ� ���͸� �̿��� �ش� ������ �ٶ� ������ ����
        Quaternion rot = Quaternion.LookRotation(dir); 
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, steeringForce * Time.deltaTime);
        // ���� �̵� / ���� ����, ��ǥ ����, �ʴ� ȸ�� ����

    }

    public Vector3 GetAvoidanceDirection(Vector3 dir)
    {
        RaycastHit hit;
        int layerMask = 1 << 15;
        if (Physics.Raycast(transform.position, transform.forward, out hit, minDistToAvoid, layerMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0f;

            dir = transform.forward + hitNormal * force;
            dir.Normalize();
        }


        return dir;
    }
}

