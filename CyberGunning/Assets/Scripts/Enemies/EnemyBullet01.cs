using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet01 : MonoBehaviour
{
    public BulletSO bulletSO;
    private GameObject player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSO.speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(rot, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
