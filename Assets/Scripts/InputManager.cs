using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public bool exit;
    public bool click;

    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnExit(InputValue value)
    {
        ExitInput(value.isPressed);
    }

    public void OnClick(InputValue value)
    {
        ClickInput(value.isPressed);
    }

    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }

    public void ExitInput(bool newExitState)
    {
        exit = newExitState;
    }

    public void ClickInput(bool newClickState)
    {
        click = newClickState;
    }
}
