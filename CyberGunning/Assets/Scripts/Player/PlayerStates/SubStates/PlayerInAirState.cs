using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private bool isTouchingWall;
    private bool jumpInput;
    private bool coyoteTime;

    private int xInput;

    public PlayerInAirState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;

        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachiene.ChangeState(player.LandState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            stateMachiene.ChangeState(player.JumpState);
        }
        else if(isTouchingWall && xInput == player.FacingDirection && player.CurrentVelocity.y <= 0)
        {
            stateMachiene.ChangeState(player.WallSlideState);
        }
        else
        {
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(playerData.movementVelocity * xInput);

            player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
        }
    }

    private void CheckCoyoteTime()
    {
        if(coyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreaseJumpAmount();
        }
    }

    public void StartCoyoteTime() => coyoteTime = true;
}
