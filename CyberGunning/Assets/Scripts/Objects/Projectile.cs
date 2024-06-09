using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private BulletSO BulletSO;
    [SerializeField] private HealthManagerSO healthManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(BulletSO.speed * transform.localScale.x, 0);
        Destroy(gameObject, 5f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        healthManager.Decreasehealth(BulletSO.damage);
        Debug.Log(healthManager.c_Health);
        Destroy(this.gameObject);
    }
}
