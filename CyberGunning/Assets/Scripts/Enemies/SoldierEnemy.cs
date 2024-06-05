
using System;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.CompilerServices;

using UnityEngine;

public class SoldierEnemy : MonoBehaviour
{
    private float walkSpeed = 3f;


    private Rigidbody2D rb;
    TouchingDirections touchDir;

    private float timer;
    public float sightLine = 6f;

    FireProjectile fireProjectile;

    public enum WalkDirection { Right, Left }

    private Vector2 walkDirectionVector = Vector2.right;
    private WalkDirection _walkDir;
    public WalkDirection WalkDir 
    {  
        get 
        { 
            return _walkDir; 
        } 
        set 
        { 
            if (_walkDir != value)
            {
                //Flip Direction
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else if (value == WalkDirection.Left)
                {
                    walkDirectionVector = Vector2.left;  
                } 
            }
            _walkDir = value; 
        } 
    }


    private GameObject player;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchDir = GetComponent<TouchingDirections>();

        fireProjectile = GetComponent<FireProjectile>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void FixedUpdate()
    {
        if(touchDir.IsOnWall && touchDir.IsGrounded)
        {
            FlipDirection();
        }

        rb.velocity = new Vector2 (walkSpeed * walkDirectionVector.x, rb.velocity.y);

        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);
        if(distanceFromPlayer > 0)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, walkSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < sightLine)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                fireProjectile.FireBullet();
            }

        }

    }

    private void FlipDirection()
    {
        if(WalkDir == WalkDirection.Right)
        {
            WalkDir = WalkDirection.Left;
        }
        else if (WalkDir == WalkDirection.Left)
        {
            WalkDir = WalkDirection.Right;
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightLine);

    }
}
