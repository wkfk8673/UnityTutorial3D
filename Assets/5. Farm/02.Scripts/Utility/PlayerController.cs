using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;

        private CharacterController cc;
        private Vector3 moveInput;

        //private PlayerInput playerInput;

        private float currentSpeed;
        private float walkSpeed = 5f;
        private float runSpeed = 10f;
        private float turnSpeed = 10f;

        private Vector3 velocity;
        private const float GRAVITY = -9.8f;

        private bool isRun;

        private void Start()
        {
            int characterIndex = LoadSceneManager.Instance.characterIndex;

            transform.GetChild(characterIndex).gameObject.SetActive(true);
            anim = transform.GetChild(characterIndex).GetComponent<Animator>();

            cc = GetComponent<CharacterController>();
        }


        private void Update()
        {
            velocity.y += GRAVITY;

            var dir = moveInput * currentSpeed + Vector3.up * velocity.y;

            cc.Move(dir * Time.deltaTime);
            Turn();
            SetAnimation();
        }

        private void OnMove(InputValue value)
        {
            var move = value.Get<Vector2>();
            moveInput = new Vector3(move.x, 0, move.y);
        }

        private void OnRun(InputValue value)
        {
            isRun = value.isPressed;
        }

        private void Turn()
        {
            if (moveInput != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveInput);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            }
        }

        private void SetAnimation()
        {
            
            float targetValue = 0f;

            if (moveInput != Vector3.zero) // 이동
            {
                targetValue = isRun ? 1f : 0.5f;
                currentSpeed = Mathf.Lerp(currentSpeed, isRun ? runSpeed : walkSpeed, 10f * Time.deltaTime);
            }

            float animValue = anim.GetFloat("Move");

            animValue = Mathf.Lerp(animValue, targetValue, 10f * Time.deltaTime);

            anim.SetFloat("Move", animValue);
        }
    }


}
