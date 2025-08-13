using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    public class PlayerController2 : MonoBehaviour
    {
        private CharacterController cc;
        private Vector2 moveInput;
        public float speed = 5f;

        private PlayerInput playerInput;

        private InputAction moveAction;
        private InputAction jumpAction;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            moveAction = playerInput.actions.FindAction("Move");
            moveAction = playerInput.actions.FindAction("Jump");

            cc = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            moveAction.Enable();
            moveAction.started += Move;
            moveAction.canceled += MoveCancel;

            jumpAction.Enable();
            jumpAction.performed += Jump;
        }
        private void OnDisable()
        {
            moveAction.Disable();
            moveAction.started -= Move;
            moveAction.canceled -= MoveCancel;

            jumpAction.Disable();
            jumpAction.performed -= Jump;
        }


        private void Update()
        {
            var dir = new Vector3(moveInput.x, 0, moveInput.y).normalized;
            cc.Move(dir * speed * Time.deltaTime);
        }

        public void Move(InputAction.CallbackContext context) // callback : 변경이 있을 경우에만 값을 변경 (key를 누를때만 변경)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        public void MoveCancel(InputAction.CallbackContext context) // callback : 변경이 있을 경우에만 값을 변경 (key를 누를때만 변경)
        {
            moveInput = Vector2.zero;
        }

        public void Jump(InputAction.CallbackContext context)
        {

            Debug.Log("Jump");

        }
    }
}

