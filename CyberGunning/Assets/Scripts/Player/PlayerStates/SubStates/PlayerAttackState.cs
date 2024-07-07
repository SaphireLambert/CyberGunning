using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Attacks attack;
    public PlayerAttackState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        attack.EnterAttack();
    }

    public override void Exit()
    {
        base.Exit();
        attack.ExitAttack();
    }

    public void SetAttack(Attacks attack)
    {
        this.attack = attack;
        attack.InitializeAttack(this);
    }

    #region Animation Triggers

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

    #endregion
}
