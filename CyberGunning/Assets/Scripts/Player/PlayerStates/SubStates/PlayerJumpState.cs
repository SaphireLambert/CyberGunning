using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int amountOfJumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityY(playerData.jumpVelocitry);
        isAbilityDone = true;
        amountOfJumpsLeft--;
    }

    public bool CanJump()
    {
        if(amountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetJumpAmount() => amountOfJumpsLeft = playerData.amountOfJumps;

    public void DecreaseJumpAmount() => amountOfJumpsLeft--;
}
