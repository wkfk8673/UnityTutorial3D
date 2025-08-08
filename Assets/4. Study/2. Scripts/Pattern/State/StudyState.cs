using UnityEngine;

public class StudyState : MonoBehaviour
{
    public IState state; // 디폴트 값 지정

    private IState idleState, moveState, attackState, jumpState;

    private void Awake()
    {
        idleState = gameObject.AddComponent<IdleState>(); // 2번째 방법
        moveState = gameObject.AddComponent<MoveState>();
        attackState = gameObject.AddComponent<AttackState>();
        jumpState = gameObject.AddComponent<JumpState>();

        state = idleState;
    }

    private void Start()
    {
        state.StateEnter();
    }

    private void OnDestroy()
    {
        state.StateExit();
    }


    private void Update()
    {
        state?.StateUpdate(); // null 체크 연산 
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetState(idleState);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) SetState(moveState);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) SetState(attackState);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) SetState(jumpState);
        
    }

    public void SetState(IState newState)
    {

        if (state != newState)
        {
            state.StateExit(); //상태 변경 전
            state = newState; //상태 변경
            state.StateEnter(); //상태 변경 후
        }
    }
}

