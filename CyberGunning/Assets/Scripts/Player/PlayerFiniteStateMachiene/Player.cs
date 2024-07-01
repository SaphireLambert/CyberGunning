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


    [SerializeField]
    private PlayerData playerData;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb {  get; private set; }
    #endregion

    #region Check Transforms

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private Transform wallCheck;

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

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();

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

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }
    #endregion
}
