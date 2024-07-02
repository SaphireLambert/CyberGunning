using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbingLadderState : PlayerClimbState
{
    public PlayerClimbingLadderState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.SetVelocityY(playerData.ladderClimbVelocity * yInput);

        if(yInput == 0)
        {
            stateMachiene.ChangeState(player.OnLadderState);
        }
    }
}
