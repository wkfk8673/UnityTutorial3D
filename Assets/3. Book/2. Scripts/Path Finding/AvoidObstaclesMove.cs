using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class AvoidObstaclesMove : MonoBehaviour
{
    public float speed = 10f;
    public float mass = 5f;
    public float force = 50f;
    public float minDistToAvoid = 5f; // 최소 회피 거리

    private float curSpeed;
    private Vector3 targetPoint;
    public float steeringForce = 10f;

    private void Start()
    {
        targetPoint = Vector3.zero; // 타겟 일단 0으로 초기화, 
    }

    private void Update()
    {
        // 메인 카메라 기준 스크린 특정 포인트에서 레이저 쏘기 (마우스 위치)
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            // 거리 : 무한
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                targetPoint = hit.point; // 마우스 클릭 위치를 목표 지점으로 설정
            }
        }

        Vector3 dir = targetPoint - transform.position;
        dir.Normalize();

        dir = GetAvoidanceDirection(dir); // 장애물 여부 확인, 없을 경우 그대로 / 있을 경우 변경 방향 적용

        if (Vector3.Distance(targetPoint, transform.position) < 1f)
            return;

        curSpeed = speed * Time.deltaTime;
        transform.position += transform.forward * curSpeed; // 아래에서 방향이 고정되므로 이동

        // 방향을 알려주는 벡터를 이용해 해당 방향을 바라 보도록 설정
        Quaternion rot = Quaternion.LookRotation(dir); 
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, steeringForce * Time.deltaTime);
        // 보간 이동 / 현재 각도, 목표 각도, 초당 회전 비율

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

