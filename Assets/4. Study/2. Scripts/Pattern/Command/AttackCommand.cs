using UnityEngine;
using Pattern.Command;

public class AttackCommand : ICommand
{
    private Player player;

    public AttackCommand(Player player)
    {
        this.player = player;
    }

    public void Excute()
    {
        player.Attack();
    }
    public void Cancel()
    {
        player.AttackCancel();
    }
}
