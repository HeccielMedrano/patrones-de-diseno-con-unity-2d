using UnityEngine;

public class JumpCommand : IPlayerCommand
{
    public void Execute(Rigidbody2D rb, CommandContext context)
    {
        if (context.PlayerState == PlayerState.IDLE || context.PlayerState == PlayerState.RUNNING)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, context.JumpForce);
            context.AudioManager.PlaySFX("SFX_Jump");
        }
    }
}

