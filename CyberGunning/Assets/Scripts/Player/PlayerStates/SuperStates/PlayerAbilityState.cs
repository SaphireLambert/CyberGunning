using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;

    private bool isGrounded;

    public PlayerAbilityState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
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
        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        base.LogicUpdate();
        if (isAbilityDone)
        {
            if (isGrounded && player.CurrentVelocity.y < 0.01f)
            {
                stateMachiene.ChangeState(player.IdleState);
            }
            else
            {
                stateMachiene.ChangeState(player.InAirState);
            }
        }
    }
}
