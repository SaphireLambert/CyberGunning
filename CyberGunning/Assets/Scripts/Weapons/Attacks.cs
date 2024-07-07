using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    protected WeaponData weaponData;

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

    private void CheckMeleAttack()
    {
        foreach (IDamageable item in detectedDamageable)
        {
            item.Damage(10);
        }
    }

    #region Triggers

    public virtual void AnimationActionTrigger()
    {
        CheckMeleAttack();
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
