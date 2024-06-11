using UnityEngine;

public class Damageable : MonoBehaviour
{
    private Animator anim;

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
                Destroy(gameObject, 0.5f);
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


    public void TakeDamage(float damage)
    {
        if (IsAlive)
        {
            CurrentHealth -= damage;

        }
    }
}
