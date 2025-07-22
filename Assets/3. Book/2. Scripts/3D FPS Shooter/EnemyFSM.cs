using System.Collections;
using UniHumanoid;
using UnityEngine;
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
    private float attackDelay = 2f; // ���� ������ �ð�

    public int attackPower = 5;
    public int hp = 15;
    private int maxHp = 15;
    public Slider hpSlider;

    private Vector3 originPos;
    private Quaternion originRot;
    public float moveDistance = 20f;

    private Animator anim;

    private void Start()
    {
        m_State = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        originRot = transform.rotation;

        anim = transform.GetComponentInChildren<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
                // Damaged(); ������Ʈ ������ �ʹ� ���� ȣ���
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
            m_State = EnemyState.Move; // ���� ��ȭ�� 1ȸ�� �߻��ϵ��� ���� �ʿ�
            anim.SetTrigger("IdleToMove");
            Debug.Log("���� ��ȯ : Idle > Move");
        }
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("���� ��ȯ : Move > Return");
        }
        else if (Vector3.Distance(transform.position, player.position) > attackDistance) // Ÿ���� ���� �Ÿ����� �� ��� �̵�
        {
            Vector3 dir = (player.position - transform.position).normalized; // 
            transform.forward = dir;
            cc.Move(dir * moveSpeed * Time.deltaTime);

        }
        else
        {
            currentTime = attackDelay;
            m_State = EnemyState.Attack;
            anim.SetTrigger("MoveToAttackDelay");
            Debug.Log("���� ��ȯ : Move > Attack");

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
                Debug.Log("����");
            }
        }
        else // ���� ���� �ۿ� ���� ��� Move ��ȯ
        {
            currentTime = 0f;
            m_State = EnemyState.Move;
            anim.SetTrigger("AttackToMove");
            Debug.Log("���� ��ȯ : Attack > Move");
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
            Vector3 dir = (originPos - transform.position).normalized; // ����ġ�� ����
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
        else // ���� ��ġ ����
        {
            transform.position = originPos;
            transform.rotation = originRot;
            hp = 15;

            anim.SetTrigger("MoveToIdle");

            m_State = EnemyState.Idle;
            Debug.Log("���� ��ȯ : Return > Idle");

        }
    }

    public void HitEnemy(int hitPower)
    {
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return)
        {
            return;
        }

        hp -= hitPower;

        if (hp > 0)
        {
            m_State = EnemyState.Damaged;
            anim.SetTrigger("Damaged");
            Debug.Log("���� ��ȯ : Any State > Damaged");
            Damaged();
        }
        else // ������ �޾� �׾��ٸ�
        {
            anim.SetTrigger("Die");
            m_State = EnemyState.Die;
            Debug.Log("���� ��ȯ : Any State > Die");
            Die();
        }
    }

    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1f); // �ǰ� �ִϸ��̼� ��ŭ ��� 
        m_State = EnemyState.Move;
        Debug.Log("���� ��ȯ: Damaged > Move");
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
        Debug.Log("�Ҹ�");
        Destroy(gameObject);
    }


}
