using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectiles", menuName = "ScriptableObjects")]
public class BulletSO : ScriptableObject
{ 
    public string type;

    public float damage;

    public float speed;

}
