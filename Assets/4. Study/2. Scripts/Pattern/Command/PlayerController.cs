using System.Collections.Generic;
using UnityEngine;


namespace Pattern.Command
{
    public class PlayerController : MonoBehaviour
    {
        public Player player;
        private ICommand attackCommand, jumpCommand, skillCommand;

        // 명령을 캡슐화. 객체화 했으므로 자료구조에 담아둘 수 있음

        private Queue<ICommand> commandQueue = new Queue<ICommand>();
        private Stack<ICommand> executeCommands = new Stack<ICommand>();

        private void Awake()
        {
            attackCommand = new AttackCommand(player);
            jumpCommand = new JumpCommand(player);
            skillCommand = new SkillCommand(player, "Fireball");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                attackCommand.Excute();
                executeCommands.Push(attackCommand);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                jumpCommand.Excute();
                executeCommands.Push(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                skillCommand.Excute();
                executeCommands.Push(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                commandQueue.Enqueue(attackCommand);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                commandQueue.Enqueue(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                commandQueue.Enqueue(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("턴 종료 및 명령 실행");

                while (commandQueue.Count > 0)
                {
                    ICommand command = commandQueue.Dequeue();
                    command.Excute();
                    executeCommands.Push(command);
                }
            }


            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (executeCommands.Count > 0)
                {
                    ICommand lastCommand = executeCommands.Pop(); // 가장 최근 명령어
                    Debug.Log($"명령취소 : {lastCommand.GetType().Name}");
                    lastCommand.Cancel(); // undo
                }
                else
                {
                    Debug.Log("되돌릴 명령이 없습니다.");
                }


            }
        }
    }

}
