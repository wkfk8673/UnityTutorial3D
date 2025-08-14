using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    [SerializeField] private float wanderRadius = 15f;
    private float minWaitTime = 1f;
    private float maxWaitTime = 5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            // 랜덤 목적지 설정
            SetRandomDestination();
            // animation 변경 (걷기)
            anim.SetBool("isWalk", true);

            // 목적지 도착까지 유지
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            // 목적지 도착 이후 애니메이션 전환
            anim.SetBool("isWalk", false);
            float idleTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(idleTime);
        }
    }

    private void SetRandomDestination()
    {
        var randomDir = Random.insideUnitSphere * wanderRadius;
        randomDir += transform.position;

        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomDir, out hit,wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 깃발 랜덤위치 이동
            AnimalEvent.failAction?.Invoke();
            Debug.Log("부딪힘!");
        }
    }
}
