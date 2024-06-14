using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;

    [SerializeField] private CapsuleCollider2D touchingCol;
    [SerializeField] private Animator anim;
    private Rigidbody2D rb;

    private RaycastHit2D[] groundHits = new RaycastHit2D[5];
    private float groundDistance = 0.05f;
    [SerializeField]
    public bool _isGrounded = true;
    public bool IsGrounded 
    {
        get
        {
            return _isGrounded;
        } 
       set
        {
            _isGrounded = value;  

            anim.SetBool(AnimationStrings.IsGroundedBool, value);    

        } 
    }
    private Vector2 wallDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;
    private RaycastHit2D[] wallHits = new RaycastHit2D[5];
    public float wallDistance = 0.05f;
    [SerializeField] private bool _isOnWall;
    public bool IsOnWall 
    { 
        get 
        { 
            return _isOnWall; 
        }
        private set
        { 
            _isOnWall = value;

            anim.SetBool(AnimationStrings.IsOnWallBool, value);

        } 
    }

    private RaycastHit2D[] roofHits = new RaycastHit2D[5];
    public float roofDistance = 0.05f;
    private bool _isOnRoof;
    public bool IsOnRoof 
    {
        get
        {
            return _isOnRoof;
        } 
        private set
        {
            _isOnRoof = value;

            anim.SetBool(AnimationStrings.IsOnRoofBool, value);

        } 
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;

        IsOnWall = touchingCol.Cast(wallDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnRoof = touchingCol.Cast(Vector2.up, castFilter, roofHits, roofDistance) > 0;
    }
}
