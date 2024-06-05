using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private Animator anim;
    private bool isInvincible = false;
    private float timeSinceHit = 0;
    [SerializeField]
    private float invincibilityTimer = 0.25f;

    [SerializeField]
    private float _maxHealth = 100f;

    public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    private float _currentHealth = 100f;
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            if(_currentHealth <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;

    public bool IsAlive 
    { 
        get 
        { 
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            anim.SetBool(AnimationStrings.IsAliveBool, value);
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(isInvincible)
        {
            if(timeSinceHit > invincibilityTimer)
            {
                //Remove Invinvibilty
                isInvincible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        if (IsAlive && !isInvincible)
        {
            CurrentHealth -= damage;
            isInvincible = true;
        }
    }
}
