using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{

    private NavMeshAgent boss;
    public Transform target;

    private void Start()
    {
        boss = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        boss.SetDestination(target.position);
    }
}
