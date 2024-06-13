using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private TouchingDirections touchingDirections;
    private FireProjectile fireProjectile;
    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private HealthManagerSO healthManager;

    private LaderSystem laderSystem;

    private float speed = 5f;
    private float jumpingPower = 12f;

    private Vector2 moveInput;
    public float CurrentMoveSpeed
    {
        get
        {
            if(IsRunning && touchingDirections.IsOnWall)
            {
                //Idle Speed is 0
                return 0;
            }
            else 
            {
                return speed;
            }
        }
    }

    public bool _isFacingRight = true;
    private bool IsFacingRight
    { get
        {
            return _isFacingRight;
        }
       set
       {
            if(_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }

            _isFacingRight = value;
       }
    }

    private bool _isRunning = false;
    public bool IsRunning 
    { 
        get 
        {
            return _isRunning;
        } 
        private set
        {
            _isRunning = value;

            anim.SetBool(AnimationStrings.IsRunningBool, value);

        }
    }

    public bool IsClimbingLadder
    {
        get
        {
            return laderSystem.isClimbing;
        }
        set
        {
            anim.SetBool(AnimationStrings.IsClimbing, true);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        fireProjectile = GetComponent<FireProjectile>();
        if(laderSystem != null)
        {
            laderSystem = GameObject.FindGameObjectWithTag("Ladder").GetComponent<LaderSystem>();
        }
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        if(healthManager.c_Health <= 0)
        {
            gameOverUI.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);

        anim.SetFloat(AnimationStrings.YVelocity, rb.velocity.y);
    }

    public void MoveCharacter(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsRunning = moveInput != Vector2.zero;

        CheckMovementDirection(moveInput);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirections.IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            anim.SetTrigger(AnimationStrings.JumpTrigger);

        }
    }

    public void FireGun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            anim.SetTrigger(AnimationStrings.FireGunTrigger);

            fireProjectile.FireBullet();
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirections.IsGrounded) 
        {
            anim.SetBool(AnimationStrings.IsCrouchedBool, true);
            
        }
        if (context.canceled)
        {
            anim.SetBool(AnimationStrings.IsCrouchedBool, false);
        }
    }

    private void CheckMovementDirection(Vector2 moveInput)
    {
        if (!IsFacingRight && moveInput.x > 0f)
        {
            IsFacingRight = true;
        }
        else if (IsFacingRight && moveInput.x < 0f)
        {
            IsFacingRight = false;
        }
    }

}
