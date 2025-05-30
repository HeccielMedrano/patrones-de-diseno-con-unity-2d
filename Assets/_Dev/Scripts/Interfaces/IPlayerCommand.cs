using UnityEngine;

public interface IPlayerCommand
{
    void Execute(Rigidbody2D rb, CommandContext context);
}

public class CommandContext
{
    public float JumpForce;
    public PlayerState PlayerState;
}
