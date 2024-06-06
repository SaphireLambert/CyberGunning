using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopEnemy : MonoBehaviour
{
    private float moveSpeed = 3;
    private Transform player;
    private float nextFireTime;
    private float fireRate = 1;

    [SerializeField]
    private FireProjectile fire;
    [SerializeField]
    private float lineOfSite = 7;
    [SerializeField]
    private float range = 6;

    public enum WalkDirection { Right, Left}

    private WalkDirection _walkDir;
    private Vector2 walkDirectionVector;

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
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                
                if(value == WalkDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                if (value == WalkDirection.Left)
                {
                    walkDirectionVector = Vector2.left; 
                }
            }
            _walkDir = value;
        }
    }
  
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > range)
        {
            //Moves the character towards the player
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed  * Time.deltaTime);
            
        }
        else if (distanceFromPlayer <= range && nextFireTime < Time.time)
        {
            
            fire.FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Flip()
    {
        if(WalkDir == WalkDirection.Left)
        {
            WalkDir = WalkDirection.Right;
        }
        if(WalkDir == WalkDirection.Right)
        {
            WalkDir = WalkDirection.Left;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
