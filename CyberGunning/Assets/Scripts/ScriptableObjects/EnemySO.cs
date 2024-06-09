using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "ScriptableObjects/Enemies")]
public class EnemySO : ScriptableObject
{
    public float moveSpeed;

    public float range;

    public float fireRate;

    public float lineOfSight;
}
