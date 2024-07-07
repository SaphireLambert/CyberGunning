using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDummy : MonoBehaviour, IDamageable
{
    private Animator animator;

    public void Damage(float amount)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
