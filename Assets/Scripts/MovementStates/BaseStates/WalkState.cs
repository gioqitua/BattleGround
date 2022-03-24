using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anime.SetBool("Walking", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.run);

        else if (Input.GetKey(KeyCode.C)) ExitState(movement, movement.crouch);

        else if (movement.moveDirection.magnitude < 0.1f) ExitState(movement, movement.idle);


        if (movement.vInput < 0) movement.currentMoveSpeed = movement.walkBackSpeed;
        else movement.currentMoveSpeed = movement.walkSpeed;
    }
    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anime.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}
