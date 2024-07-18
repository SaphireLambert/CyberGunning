using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackData", menuName = ("Data/Attack Data/Base Data"))]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] private AttackDetails[] attackDetails;
}
