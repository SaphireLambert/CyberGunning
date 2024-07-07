using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = ("Data/Player Data/Base Data"))]
public class PlayerData : ScriptableObject
{
    [Header("UI Stats")]
    public float maxHealth;
    public float currentHealth;

    [Header("Character Upgrades")]
    public bool canDoubleJump;
    public bool hasArmour;
    public bool canWallJump;

    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocitry = 15f;
    public int amountOfJumps = 1;

    [Header("wall Jump State")]
    public float wallJumpVelocity = 20;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("In Air State")]
    public float coyoteTime = 0.2f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3;

    [Header("Ladder CLimb State")]
    public float ladderClimbVelocity = 4;

    [Header("Crouch State")]
    public float crouchMovementVelocity = 0;
    public float crouchColliderHeight = 0.5f;
    public float standColliderHeight = 1.6f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.5f;
    public float wallCheckDistance = 0.5f;
    public float ladderCheckDistance = 0.1f;
    public LayerMask whatIsGround;
    public LayerMask whatIsLadder;

}
