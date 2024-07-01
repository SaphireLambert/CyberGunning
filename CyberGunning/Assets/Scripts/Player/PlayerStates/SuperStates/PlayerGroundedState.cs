using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool JumpInput;

    private bool isGrounded;

    public PlayerGroundedState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.ResetJumpAmount();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        JumpInput = player.InputHandler.JumpInput;

        if (JumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachiene.ChangeState(player.JumpState);
        }
        else if (!isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachiene.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
