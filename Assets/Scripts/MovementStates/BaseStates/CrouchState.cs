using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anime.SetBool("Crouching", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.run);

        else if (Input.GetKeyDown(KeyCode.C)) ExitState(movement, movement.walk);


        if (movement.vInput < 0) movement.currentMoveSpeed = movement.crouchBackSpeed;
        else movement.currentMoveSpeed = movement.crouchSpeed;
    }
    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anime.SetBool("Crouching", false);
        movement.SwitchState(state);
    }
}
