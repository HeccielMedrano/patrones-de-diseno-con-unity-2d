using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 5.5f;
    [SerializeField] private LayerMask groundLayer;

    private INP_Player inputActionsPlayer;
    private Rigidbody2D rb;
    private CommandContext context = new CommandContext();
    private Collider2D col;
    private PlayerState currentState;
    private Animator animationComponent;
    private AudioManager audioManager;
    #endregion

    private void Awake()
    {
        inputActionsPlayer = GetComponent<INP_Player>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animationComponent = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        HandleStateTransitions();
        HandleAnimations();
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = inputActionsPlayer.GetMovement();
        rb.linearVelocity = new Vector2(moveDir.x * moveSpeed, rb.linearVelocityY);

        context.JumpForce = jumpForce;
        context.PlayerState = currentState;
        context.AudioManager = audioManager;

        while (inputActionsPlayer.HasCommands())
        {
            inputActionsPlayer.GetNextCommand().Execute(rb, context);
        }
    }


    #region STATE MACHINE
    private void HandleStateTransitions()
    {
        if (!IsGrounded())
        {
            if (rb.linearVelocity.y > 0.1f)
                currentState = PlayerState.JUMPING;
            else if (rb.linearVelocity.y < -0.1f)
                currentState = PlayerState.FALLING;
        }
        else
        {
            if (Mathf.Abs(rb.linearVelocity.x) > 0.1f)
                currentState = PlayerState.RUNNING;
            else
                currentState = PlayerState.IDLE;
        }
    }
    
    private void HandleAnimations()
    {
        string newAnimation = currentState switch
        {
            PlayerState.IDLE => "ANIM_PlayerIdle",
            PlayerState.RUNNING => "ANIM_PlayerRun",
            PlayerState.JUMPING => "ANIM_PlayerJump",
            PlayerState.FALLING => "ANIM_PlayerFall",
            _ => ""
        };

        animationComponent.Play(newAnimation);
    }


    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D hit = Physics2D.BoxCast(
            col.bounds.center,
            col.bounds.size,
            0f,
            Vector2.down,
            extraHeight,
            groundLayer
        );

        return hit.collider != null;
    }
    #endregion

}
