using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    public class PlayerController3 : MonoBehaviour
    {
        private CharacterController cc;
        private Vector2 moveInput;

        public float speed = 5f;

        private void Start()
        {
            cc = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var dir = new Vector3(moveInput.x, 0, moveInput.y);
            cc.Move(dir * speed * Time.deltaTime);
        }

        private void OnMove(InputValue value)
        {
            Debug.Log("OnMove");
        }

        private void OnJump(InputValue value)
        {
            bool isJump = value.isPressed;
            Debug.Log(isJump);
        }

        private void OnInteraction(InputValue value)
        {
            
            Debug.Log(value.isPressed);
        }

        private void OnAttack(InputValue value)
        {
            Debug.Log("OnAttack");
        }
    }
}

