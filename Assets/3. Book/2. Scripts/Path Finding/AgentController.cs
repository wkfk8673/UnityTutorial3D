using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    
    public Transform[] points;
    public int index;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        index = Random.Range(0, points.Length);

    }

    private void Update()
    {
        agent.SetDestination(points[index].position);
        if(agent.remainingDistance <= 1.5f)
        {
            Debug.Log("목적지 변경");
            index++;

            int tmp = index;
            index = Random.Range(0, points.Length);

            if (tmp == index)
                index = Random.Range(0, points.Length);
        }
    }
}
