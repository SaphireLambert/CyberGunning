using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField]
    private Transform launchPoint;

    public void FireBullet()
    {
        GameObject projectile = Instantiate(bulletPrefab, launchPoint.position, bulletPrefab.transform.rotation);
        Vector2 originalScale = projectile.transform.localScale;    


        //Flip the projectile based on the direction the character is facing

        projectile.transform.localScale = new Vector2
          (
            originalScale.x * transform.localScale.x > 0 ? 1 : -1, 
            originalScale.y
          );

    }
}
