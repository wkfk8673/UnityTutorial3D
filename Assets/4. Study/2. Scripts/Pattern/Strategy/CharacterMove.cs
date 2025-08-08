using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private IMovement movement;

    private void Start()
    {
        movement = new MoveWalk(3f);
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            movement = new MoveWalk(2f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            movement = new MoveRun(4f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            movement = new MoveFly(5f);
        }
    }

    private void Move()
    {
        movement.Move(transform);
    }
}
