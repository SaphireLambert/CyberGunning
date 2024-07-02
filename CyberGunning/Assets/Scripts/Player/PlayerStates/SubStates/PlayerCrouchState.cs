using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchState : PlayerGroundedState
{
    public PlayerCrouchState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityX(0);
        player.SetColliderHeight(playerData.crouchColliderHeight);
    }

    public override void Exit()
    {
        base.Exit();

        player.SetColliderHeight(playerData.standColliderHeight);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            player.CheckIfShouldFlip(xInput);
            if(yInput != 0 && xInput == 0)
            {
                stateMachiene.ChangeState(player.IdleState);
            }
            if(yInput != -1 && xInput != 0) 
            {
                stateMachiene.ChangeState(player.MoveState);
            }
        }
    }
}
