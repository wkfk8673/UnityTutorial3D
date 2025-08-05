using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { Idle = -1, Move, Attack, Return, Damaged, Die } // -1, 0, 1, 2, 3, 4
    private EnemyState m_State;

    private Transform player;
    private CharacterController cc;

    public float findDistance = 8f;
    public float attackDistance = 2f;
    public float moveSpeed = 8f;
    private float currentTime = 0f;
    private float attackDelay = 2f; // 공격 딜레이 시간

    public int attackPower = 5;
    public int hp = 15;
    private int maxHp = 15;
    public Slider hpSlider;

    private Vector3 originPos;
    private Quaternion originRot;
    public float moveDistance = 20f;

    private Animator anim;
    private NavMeshAgent smith;

    private void Start()
    {
        m_State = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        originRot = transform.rotation;
        smith = GetComponent<NavMeshAgent>();

        anim = transform.GetComponentInChildren<Animator>();
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;

            case EnemyState.Move:
                Move();
                break;

            case EnemyState.Attack:
                Attack();
                break;

            case EnemyState.Return:
                Return();
                break;

            case EnemyState.Damaged:
                // Damaged(); 업데이트 문에서 너무 자주 호출됨
                break;

            case EnemyState.Die:
                // Die();
                break;
        }

        hpSlider.value = (float)hp / (float)maxHp;
    }

    private void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move; // 상태 변화는 1회만 발생하도록 제한 필요
            anim.SetTrigger("IdleToMove");
            Debug.Log("상태 전환 : Idle > Move");
        }
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("상태 전환 : Move > Return");
        }
        else if (Vector3.Distance(transform.position, player.position) > attackDistance) // 타겟이 공격 거리보다 멀 경우 이동
        {
            smith.isStopped = true;
            smith.ResetPath();

            // 목적지 설정 후 멈춤 / 이동 경로 리셋
            smith.stoppingDistance = attackDistance;
            smith.SetDestination(player.position);
        }
        else
        {
            currentTime = attackDelay;
            m_State = EnemyState.Attack;
            anim.SetTrigger("MoveToAttackDelay");
            Debug.Log("상태 전환 : Move > Attack");

        }
    }

    private void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                currentTime = 0f;
                //player.GetComponent<PlayerMovement>().DamageAction(attackPower);
                anim.SetTrigger("StartAttack");
                Debug.Log("공격");
            }
        }
        else // 공격 범위 밖에 있을 경우 Move 전환
        {
            currentTime = 0f;
            m_State = EnemyState.Move;
            anim.SetTrigger("AttackToMove");
            Debug.Log("상태 전환 : Attack > Move");
        }
    }

    public void AttackAction()
    {
        player.GetComponent<PlayerMovement>().DamageAction(attackPower);
    }

    private void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            smith.SetDestination(originPos);
            smith.stoppingDistance = 0f;
        }
        else // 원래 위치 도착
        {
            smith.isStopped = true;
            smith.ResetPath();

            transform.position = originPos;
            transform.rotation = originRot;
            hp = 15;

            anim.SetTrigger("MoveToIdle");

            m_State = EnemyState.Idle;
            Debug.Log("상태 전환 : Return > Idle");

        }
    }

    public void HitEnemy(int hitPower)
    {
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return)
        {
            return;
        }


        hp -= hitPower;
        Debug.Log($"아니 공격이 먹히긴해? {hp}");

        smith.isStopped = true;
        smith.ResetPath();

        if (hp > 0)
        {
            m_State = EnemyState.Damaged;
            anim.SetTrigger("Damaged");
            Debug.Log("상태 전환 : Any State > Damaged");
            Damaged();
        }
        else // 공격을 받아 죽었다면
        {
            anim.SetTrigger("Die");
            m_State = EnemyState.Die;
            Debug.Log("상태 전환 : Any State > Die");
            Die();
        }
    }

    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1f); // 피격 애니메이션 만큼 대기 
        m_State = EnemyState.Move;
        Debug.Log("상태 전환: Damaged > Move");
    }

    private void Die()
    {
        StopAllCoroutines();
        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;

        yield return new WaitForSeconds(2f);
        Debug.Log("소멸");
        Destroy(gameObject);
    }


}
