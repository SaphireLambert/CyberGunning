using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : MonoBehaviour
{
    private Damageable damageable;

    [SerializeField]
    private Sprite damagedBox;

    [SerializeField]
    private GameObject money;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
       if(damageable.CurrentHealth < 25)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = damagedBox;
        }
       if(damageable.CurrentHealth <= 0)
        {
            Instantiate(money, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }
}
