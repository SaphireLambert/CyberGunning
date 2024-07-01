using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbingState : PlayerState
{
    public PlayerClimbingState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityY(playerData.ladderClimbVelocity);
    }
}
