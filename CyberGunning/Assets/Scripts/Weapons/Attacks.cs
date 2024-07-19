using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Attacks : MonoBehaviour
{
    [SerializeField] private WeaponDataSO weaponDataSO;

    protected int attackCounter;

    protected Animator attackAnimator;

    protected PlayerAttackState attackState;

    private List<IDamageable> detectedDamageable = new List<IDamageable>();

    private void Start()
    {
        attackAnimator = GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterAttack()
    {
        gameObject.SetActive(true);

        if(attackCounter >= weaponDataSO.amountOfAttacks)
        {
            attackCounter = 0;
        }

        attackAnimator.SetBool("attack", true);
    }

    public virtual void ExitAttack()
    {
        attackAnimator.SetBool("attack", false);

        gameObject.SetActive(false);    
    }
   
    public void InitializeAttack(PlayerAttackState state)
    {
        this.attackState = state;
    }


    #region Triggers
    private void CheckMeleeAttack()
    {
        AttackDetails attackDetails = weaponDataSO.AttackDetails[attackCounter];

        foreach (IDamageable item in detectedDamageable.ToList()
            )
        {
            item.Damage(attackDetails.damageAmount);
        }
    }

    public virtual void AnimationActionTrigger()
    {
        CheckMeleeAttack();
    }

    public virtual void AnimationFinishTrigger()
    {
        attackState.AnimationFinishTrigger();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddToDetected(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFromDetected(collision);
    }
    public void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageable.Add(damageable);
        }
    }
    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageable.Remove(damageable);
        }
    }
    #endregion
}
