using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;

    private bool JumpInput;
    private bool isGrounded;
    private bool isOnLadder;

    public PlayerGroundedState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
        isOnLadder = player.CheckIfOnLadder();
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
        yInput = player.InputHandler.NormInputY;
        JumpInput = player.InputHandler.JumpInput;

        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachiene.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachiene.ChangeState(player.SecondaryAttackState);
        }
        else if (JumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachiene.ChangeState(player.JumpState);
        }
        else if (!isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachiene.ChangeState(player.InAirState);
        }
        else if (isOnLadder)
        {
            stateMachiene.ChangeState(player.OnLadderState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
