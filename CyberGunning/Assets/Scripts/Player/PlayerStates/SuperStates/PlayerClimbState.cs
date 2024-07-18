using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerState
{

    protected bool isOnLadder;
    protected int yInput;
    protected int xInput;

    public PlayerClimbState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        yInput = player.InputHandler.NormInputY;
        xInput = player.InputHandler.NormInputX;

        if (isOnLadder && yInput == 0)
        {
            stateMachiene.ChangeState(player.OnLadderState);
        }
        else if (!isOnLadder)
        {
            stateMachiene.ChangeState(player.IdleState);
        }
        else if (xInput != 0 && isOnLadder)
        {
            stateMachiene.ChangeState(player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
