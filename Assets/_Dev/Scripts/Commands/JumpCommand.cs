using UnityEngine;

public class JumpCommand : IPlayerCommand
{
    public void Execute(Rigidbody2D rb, CommandContext context)
    {   
        rb.linearVelocity = new Vector2(rb.linearVelocityX, context.JumpForce);
    }
}

