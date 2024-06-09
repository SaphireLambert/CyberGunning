using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour

{
    [SerializeField]
    private EnemySO enemyStats;

    [SerializeField]
    private HealthBarManager healthBarManager;

    private Transform player;
    private float nextFireTime;

    private FireProjectile fire;

    private Rigidbody2D rb;

    private Animator anim;
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
        rb = GetComponent<Rigidbody2D>();
        fire = GetComponent<FireProjectile>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < enemyStats.lineOfSight && distanceFromPlayer > enemyStats.range)
        {

            //Moves the character towards the player
            //transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed  * Time.deltaTime);
            rb.velocity = new Vector2(walkDirectionVector.x * enemyStats.moveSpeed, rb.velocity.y);
            //rb.MovePosition((Vector2)transform.position + walkDirectionVector * enemyStats.moveSpeed * Time.deltaTime);
            anim.SetBool(AnimationStrings.IsRunningBool, true);
        }
        else if (distanceFromPlayer <= enemyStats.range && nextFireTime < Time.time)
        {
            Flip();
            fire.FireBullet();
            anim.SetTrigger(AnimationStrings.FireGunTrigger);
            nextFireTime = Time.time + enemyStats.fireRate;
        }
    }

    private void Update()
    {
        IsDead();
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

    private void IsDead()
    {
        if (!healthBarManager.isCharacterAlive)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyStats.lineOfSight);
        Gizmos.DrawWireSphere(transform.position, enemyStats.range);
    }
}
