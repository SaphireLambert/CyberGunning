using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingWallBack;
    private bool isOnLadder;
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
        isTouchingWallBack = player.CheckIfTouchingWallBack();
        isOnLadder = player.CheckIfOnLadder();


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

        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachiene.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachiene.ChangeState(player.SecondaryAttackState);
        }
        else if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachiene.ChangeState(player.LandState);
        }
        else if (jumpInput && (isTouchingWall || isTouchingWallBack))
        {
            player.WallJumpState.WallJumpDirection(isTouchingWall);
            stateMachiene.ChangeState(player.WallJumpState);    
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachiene.ChangeState(player.JumpState);
        }
        else if(isOnLadder)
        {
            stateMachiene.ChangeState(player.OnLadderState);
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
