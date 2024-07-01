using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = ("Data/Player Data/Base Data"))]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocitry = 15f;
    public int amountOfJumps = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3;

    [Header("Ladder CLimb")]
    public float ladderClimbVelocity = 4;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.5f;
    public float wallCheckDistance = 0.5f;
    public LayerMask whatIsGround;

}
