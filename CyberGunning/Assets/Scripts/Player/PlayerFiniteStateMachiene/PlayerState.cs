using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachiene stateMachiene;
    protected PlayerData playerData;

    protected bool isAnimationFinished;

    protected float startTime;

    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachiene = stateMachiene;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }  
    
    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        player.Anim.SetBool(animBoolName, true);
        isAnimationFinished = false;
    }

    public virtual void Exit() 
    {
        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()  { }

    public virtual void AnimationTrigger()  { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
