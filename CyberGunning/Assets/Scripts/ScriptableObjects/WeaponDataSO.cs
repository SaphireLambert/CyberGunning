using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackData", menuName = ("Data/Attack Data/Base Data"))]
public class WeaponDataSO : ScriptableObject
{
    public int amountOfAttacks {  get; set; }
    [SerializeField] protected AttackDetails[] attackDetails;

    public AttackDetails[] AttackDetails { get => attackDetails; private set => attackDetails = value; }

    private void OnEnable()
    {
        amountOfAttacks = attackDetails.Length;
    }
}
