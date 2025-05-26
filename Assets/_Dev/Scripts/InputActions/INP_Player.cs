using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class INP_Player : MonoBehaviour
{
    [Header("Player Input Values")]
    private Vector2 movement;
    private bool jump;


#if ENABLE_INPUT_SYSTEM
    private void OnMovement(InputValue value)
    {
        MovementInput(value.Get<Vector2>());
    }

    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }
#endif


    private void MovementInput(Vector2 newMoveDirection)
    {
        movement = newMoveDirection;
    } 

    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }


    #region GETTERS
    public Vector2 GetMovement()
    {
        return movement;
    }

    public bool GetJump()
    {
        return jump;
    }
    #endregion
}