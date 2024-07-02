using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput {  get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }

    public bool[] AttackInputs { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.02f;

    private float jumpInputStartTime;

    private void Start()
    {
        int count = Enum.GetValues(typeof(CombatInputs)).Length;    
        AttackInputs = new bool[count];
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
    }
    public void OnPrimaryAttck(InputAction.CallbackContext context) //This is the gun attack
    {
        if(context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }

        if(context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }
    public void OnSecondaryAttack(InputAction.CallbackContext context) // This is the kick attack
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            JumpInput = true;

            jumpInputStartTime = Time.time;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
}

public enum CombatInputs 
{ 
    primary,
    secondary
}

