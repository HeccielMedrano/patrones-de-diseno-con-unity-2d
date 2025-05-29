using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class INP_Player : MonoBehaviour
{
    [Header("Player Input Values")]
    private Vector2 movement;
    private bool jump;

    private Queue<IPlayerCommand> commandQueue = new Queue<IPlayerCommand>();


#if ENABLE_INPUT_SYSTEM
    private void OnMovement(InputValue value)
    {
        MovementInput(value.Get<Vector2>());
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            commandQueue.Enqueue(new JumpCommand());
        }
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

    public Queue<IPlayerCommand> GetCommands()
    {
        return commandQueue;
    }
    

    public bool HasCommands() => commandQueue.Count > 0;

    public IPlayerCommand GetNextCommand()
    {
        return commandQueue.Dequeue();
    }
    #endregion
}