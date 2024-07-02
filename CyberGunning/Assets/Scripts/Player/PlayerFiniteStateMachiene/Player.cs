using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachiene StateMachiene {  get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set;}
    public PlayerClimbingLadderState ClimbingLadderState { get; set; }
    public PlayerOnLadderState OnLadderState { get; private set;}
    public PlayerWallJumpState WallJumpState { get; private set;}
    public PlayerCrouchState CrouchState { get; private set;}
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondaryAttackState { get; private set; }


    [SerializeField]
    private PlayerData playerData;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb {  get; private set; }

    public CapsuleCollider2D capsuleCollider { get; private set; }
    #endregion

    #region Check Transforms

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private Transform wallCheck;

    [SerializeField]
    private Transform ladderCheck;

    #endregion

    #region Other Variables
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }



    private Vector2 workSpace;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachiene = new PlayerStateMachiene();

        IdleState = new PlayerIdleState(this, StateMachiene, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachiene, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachiene, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachiene, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachiene, playerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachiene, playerData, "wallSlide");
        ClimbingLadderState = new PlayerClimbingLadderState(this, StateMachiene, playerData, "climbingLadder");
        OnLadderState = new PlayerOnLadderState(this, StateMachiene, playerData, "onLadder");
        WallJumpState = new PlayerWallJumpState(this, StateMachiene, playerData, "inAir");
        CrouchState = new PlayerCrouchState(this, StateMachiene, playerData, "crouch");
        PrimaryAttackState = new PlayerAttackState(this, StateMachiene, playerData, "attack");
        SecondaryAttackState = new PlayerAttackState(this, StateMachiene, playerData, "attack");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();  

        StateMachiene.Initialize(IdleState);
        FacingDirection = 1;
    }

    private void Update()
    {
        StateMachiene.CurrentState.LogicUpdate();
        CurrentVelocity = rb.velocity;
    }

    private void FixedUpdate()
    {
        StateMachiene.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        rb.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y);
        rb.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity);
        rb.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    #endregion

    #region Check Functions

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }
    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }
    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }
    public bool CheckIfOnLadder()
    {
        return Physics2D.OverlapCircle(ladderCheck.position, playerData.ladderCheckDistance, playerData.whatIsLadder);
    }
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    
    #endregion

    #region Other Functions

    private void AnimationTrigger() => StateMachiene.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachiene.CurrentState.AnimationFinishTrigger();

    public void SetColliderHeight(float height)
    {
        Vector2 center = capsuleCollider.offset;
        workSpace.Set(capsuleCollider.size.x, height);

        center.y += (height - capsuleCollider.size.y) / 2;

        capsuleCollider.size = workSpace;
        capsuleCollider.offset = center;
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }
    #endregion
}
