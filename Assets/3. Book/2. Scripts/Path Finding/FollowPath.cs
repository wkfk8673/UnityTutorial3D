using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// ���� ���� ���� ���
/// </summary>
public class FollowPath : MonoBehaviour
{
    public Path path;
    public float speed = 5f;
    public float mass = 5f;
    public bool isLooping = true;

    private float curSpeed;
    private int curPathIndex;
    private int pathLength;
    private Vector3 targetPoint;

    private Vector3 velocity;

    private void Start()
    {
        pathLength = path.points.Length;
        curPathIndex = 0;

        velocity = transform.forward; // ����
    }

    private void Update()
    {
        curSpeed = speed * Time.deltaTime;
        targetPoint = path.GetPoint(curPathIndex); // 0 ���� n������ �̵�

        if (Vector3.Distance(transform.position, targetPoint) < path.radius)
        {
            if (curPathIndex < pathLength - 1)
            {
                curPathIndex++;
            }
            else if (isLooping == true)
            {
                curPathIndex = 0;
            }
            else
            {
                return;
            }
        }
        if (curPathIndex >= pathLength)
            return;
        if (curPathIndex >= pathLength - 1 && !isLooping)
        {
            velocity += Steer(targetPoint, true);
        }
        else
        {
            velocity += Steer(targetPoint); // ���� ��ȯ
        }

        transform.position += velocity; // �̵� ���
        transform.rotation = Quaternion.LookRotation(velocity); // ����
    }

    public Vector3 Steer(Vector3 target, bool isFinalPoint = false)
    {
        Vector3 targetDir = target - transform.position;
        float dist = target.magnitude;

        targetDir.Normalize();

        if (isFinalPoint && dist < 10f)
        {
            targetDir *= curSpeed * (dist / 10);
        }
        else
        {
            targetDir *= curSpeed;
        }

        Vector3 steeringForce = targetDir - velocity;
        Vector3 acceleration = steeringForce / mass;

        return acceleration;
    }
}
