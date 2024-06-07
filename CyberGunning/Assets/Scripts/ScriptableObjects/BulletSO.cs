using UnityEngine;

[CreateAssetMenu(fileName = "Projectiles", menuName = "ScriptableObjects/BulletSO")]
public class BulletSO : ScriptableObject
{ 
    public string type;

    public float damage;

    public float speed;

}
