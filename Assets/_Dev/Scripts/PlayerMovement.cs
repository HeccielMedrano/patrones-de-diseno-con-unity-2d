using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 5.5f;

    private INP_Player inputActionsPlayer;
    private Rigidbody2D rb;
    private CommandContext context = new CommandContext();
    #endregion

    private void Awake()
    {
        inputActionsPlayer = GetComponent<INP_Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = inputActionsPlayer.GetMovement();
        rb.linearVelocity = new Vector2(moveDir.x * moveSpeed, rb.linearVelocityY);
        
        context.JumpForce = jumpForce;

        while (inputActionsPlayer.HasCommands())
        {
            inputActionsPlayer.GetNextCommand().Execute(rb, context);
        }
    }
}
