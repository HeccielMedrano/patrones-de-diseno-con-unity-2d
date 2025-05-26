using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 5.5f;

    private INP_Player inputActionsPlayer;
    private Rigidbody2D rb;
    #endregion


    #region LIFETIME
    private void Awake()
    {
        inputActionsPlayer = GetComponent<INP_Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = inputActionsPlayer.GetMovement().x * moveSpeed;

        if (inputActionsPlayer.GetJump())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    #endregion
}
